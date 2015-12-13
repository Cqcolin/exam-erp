using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{

    public abstract class InvCosFactoryBase : IInvCosFactory
    {
        public virtual decimal GetInvCos(List<SkuInfo> skus)
        {
            skus = GetCovSkus(skus);
            return skus.Sum(s => s.Amount * s.Price);
        }

        protected virtual List<SkuInfo> GetCovSkus(List<SkuInfo> skus)
        {
            return skus;
        }

        public void GetInvCos(List<SkuInfo> invs, SkuInfo sku)
        {
            var list = invs.Where(o => o.SkuCode.Equals(sku.SkuCode));
            Console.WriteLine("物料：{0}，库存为：{1},库存成本为:{2} 。\n", sku.SkuCode, invs.Where(o => o.SkuCode.Equals(sku.SkuCode)).Sum(o => o.Amount), GetInvCos(list.ToList()));
        }
        public void DealBills(List<SkuInfo> invs, Bill bill)
        {
            switch (bill.Direction)
            {
                case DirectionEnum.In:
                    InInv(invs, bill);
                    break;
                default:
                    Out(invs, bill);
                    break;
            }
        }

        protected virtual void InInv(List<SkuInfo> invs, Bill bill)
        {
            invs.AddRange(bill.ToSkuInfo());
        }

        protected virtual void Out(List<SkuInfo> invs, Bill bill)
        {
            foreach (SkuInfo item in bill.skus)
            {
                Out(invs, item);
            }
        }


        public virtual decimal GetSkuPrice(List<SkuInfo> invs, SkuInfo sku)
        {
            var inv = invs.FirstOrDefault(s => s.SkuCode.Equals(sku.SkuCode) && s.Amount > 0);
            return inv == null ? 0 : inv.Price;
        }

        public int GetSkuAmount(List<SkuInfo> invs, SkuInfo sku)
        {
            return invs.Where(s => s.SkuCode.Equals(sku.SkuCode) && s.Amount > 0).Sum(s => s.Amount);
        }


        protected abstract void Out(List<SkuInfo> invs, SkuInfo sku);



    }
}
