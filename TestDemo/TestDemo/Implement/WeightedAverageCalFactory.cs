using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{

    /// <summary>
    /// 加权平均
    /// </summary>
    public class WeightedAverageCalFactory : InvCosFactoryBase, IInvCosFactory
    {
        protected override List<SkuInfo> GetCovSkus(List<SkuInfo> skus)
        {
            var list = (from s in skus
                        group s by new { s.ID }
                            into g
                            select g.Key.ID).ToList();
            List<SkuInfo> lstSkus = new List<SkuInfo>();
            for (int i = 0; i < list.Count(); i++)
            {
                var s = skus.Where(o => o.ID == list[i]).ToList();
                s = SortSku(s);
                lstSkus.AddRange(GetSkuInfo(s));
            }
            return lstSkus;
        }

        protected virtual List<SkuInfo> SortSku(List<SkuInfo> skus)
        {
            return skus;
        }
        protected List<SkuInfo> GetSkuInfo(List<SkuInfo> skus)
        {
            if (skus.Count == 1)
            {
                return skus;
            }

            List<SkuInfo> rlt = new List<SkuInfo>();
            rlt.Add(skus.First());
            return GetSkuInfo(skus.Skip(1).ToList(), skus.First(), rlt);

        }

        protected virtual List<SkuInfo> GetSkuInfo(List<SkuInfo> skus, SkuInfo sku, List<SkuInfo> rlt)
        {
            var temp = skus.First();
            temp.Price = (temp.Price * temp.Amount + sku.Amount * sku.Price) / (temp.Amount + sku.Amount);
            rlt.Add(temp);
            if (skus.Count == 1)
            {
                return rlt;
            }
            return GetSkuInfo(skus.Skip(1).ToList(), sku, rlt);
        }

        protected override void Out(List<SkuInfo> invs, SkuInfo sku)
        {
            throw new NotImplementedException();
        }
    }

}
