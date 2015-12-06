using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    /// <summary>
    /// 后进先出
    /// </summary>
    public class LIFOCalFactory : InvCosFactoryBase, IInvCosFactory
    {
        protected override List<SkuInfo> GetCovSkus(List<SkuInfo> skus)
        {
            List<SkuInfo> rlt = new List<SkuInfo>();
            var list = (from s in skus
                        group s by new { s.ID }
                            into g
                            select g.Key.ID).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                var list1 = skus.Where(o => o.ID == list[i]).OrderByDescending(o => o.InInvTime).ToList();
                foreach (var item in list1)
                {
                    var s = item.Clone() as SkuInfo;
                    s.Price = list1.First().Price;
                    rlt.Add(s);
                }
            }
            return rlt;
        }

        protected override void Out(List<SkuInfo> invs, SkuInfo sku)
        {
            throw new NotImplementedException();
        }
    }

}
