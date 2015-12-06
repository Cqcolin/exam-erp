using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    /// <summary>
    /// 个别计算
    /// </summary> 
    public class IndividualCalFactory : InvCosFactoryBase, IInvCosFactory
    {
        protected override void Out(List<SkuInfo> invs, SkuInfo sku)
        {
            throw new NotImplementedException();
        }
    }

}
