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
    public class FIFOMovingWeightedAverageCalFactory : MovingWeightedAverageCalFactory, IInvCosFactory
    {
        protected override List<SkuInfo> SortSku(List<SkuInfo> skus)
        {
            return skus.OrderBy(o => o.InInvTime).ToList();
        }
    }
}
