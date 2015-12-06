using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public interface IInvCosFactory
    {
        /// <summary>
        /// 总的库存成本
        /// </summary>
        /// <param name="skus">库存流水</param>
        decimal GetInvCos(List<SkuInfo> skus);

        /// <summary>
        /// 单个物料库存成本
        /// </summary>
        /// <param name="invs">库存流水</param>
        /// <param name="sku">显示的物料</param>
        void GetInvCos(List<SkuInfo> invs, SkuInfo sku);

        void DealBills(List<SkuInfo> invs, Bill bill);
    }

}
