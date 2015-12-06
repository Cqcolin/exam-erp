using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{

    /// <summary>
    /// 移动加权平均
    /// </summary>
    public class MovingWeightedAverageCalFactory : WeightedAverageCalFactory, IInvCosFactory
    {
        protected override List<SkuInfo> GetSkuInfo(List<SkuInfo> skus, SkuInfo sku, List<SkuInfo> rlt)
        {
            var temp = skus.First();
            temp.Price = (temp.Price * temp.Amount + sku.Amount * sku.Price) / (temp.Amount + sku.Amount);
            rlt.Add(temp);
            if (skus.Count == 1)
            {
                return rlt;
            }
            return GetSkuInfo(skus.Skip(1).ToList(), temp, rlt);
        }
    }

}
