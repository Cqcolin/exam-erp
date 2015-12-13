using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{

    /// <summary>
    /// 先进先出
    /// </summary>
    public class FIFOCalFactory : InvCosFactoryBase, IInvCosFactory
    {
        protected override List<SkuInfo> GetCovSkus(List<SkuInfo> skus)
        {
            List<SkuInfo> rlt = new List<SkuInfo>();
            var list = (from s in skus
                        group s by new { s.SkuCode }
                            into g
                            select g.Key.SkuCode).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                var list1 = skus.Where(o => o.SkuCode == list[i] && o.Amount > 0).OrderBy(o => o.InInvTime).ToList();
                foreach (var item in list1)
                {
                    var s = item.Clone() as SkuInfo;
                    s.Price = list1.First().Price;
                    rlt.Add(s);
                }
            }
            return rlt;
        }

        protected override void Out(List<SkuInfo> invs, Bill bill)
        {
            if (bill.skus.Count > 0)
            {
                var listSkuCode = from sku in bill.skus
                                  group sku by new { sku.SkuCode }
                                      into g
                                      select g;
                foreach (var skucode in listSkuCode)
                {
                    Console.WriteLine("***********************************\n");
                    SkuInfo tmpSku = new SkuInfo() { SkuCode = skucode.Key.SkuCode };
                    Console.WriteLine("{1}开始处理物料：{0}.....", tmpSku.SkuCode, bill.BillNumber);
                    Console.Write("处理前库存及成本：");
                    GetInvCos(invs, tmpSku);
                    Console.WriteLine("单据号:{0},物料{1}成本单价为：{2}。\n", bill.BillNumber, tmpSku.SkuCode, invs.First(o => o.SkuCode.Equals(tmpSku.SkuCode) && o.Amount > 0).Price);
                    var list = bill.skus.Where(o => o.SkuCode.Equals(tmpSku.SkuCode));
                    foreach (SkuInfo skuInfo in list)
                    {
                        SkuInfo tmpOutSku = skuInfo.Clone() as SkuInfo;
                        Out(invs, tmpOutSku);
                    }
                    Console.Write("处物料{0}后：", "");
                    GetInvCos(invs, tmpSku);
                }
            }
        }

        public override decimal GetSkuPrice(List<SkuInfo> invs, SkuInfo sku)
        {
            var inv = invs.OrderBy(s => s.InInvTime).FirstOrDefault(s => s.SkuCode.Equals(sku.SkuCode) && s.Amount > 0);

            return inv == null ? 0 : inv.Price;

        }

        protected override void Out(List<SkuInfo> invs, SkuInfo sku)
        {
            SkuInfo outSku = null;
            var curInvs = invs.OrderBy(s => s.InInvTime).Where(o => o.SkuCode.Equals(sku.SkuCode) && o.Amount > 0);

            //var sameBathchInvs = curInvs.Where(o => o.BatchNo.Equals(sku.BatchNo));
            //outSku = sameBathchInvs.FirstOrDefault();
            if (outSku == null)
            {
                outSku = curInvs.FirstOrDefault();
            }

            if (outSku.Amount < sku.Amount)
            {
                sku.Amount = sku.Amount - outSku.Amount;
                invs.Remove(outSku);
                Out(invs, sku);
            }
            else
            {
                outSku.Amount = outSku.Amount - sku.Amount;
            }

        }
    }


}
