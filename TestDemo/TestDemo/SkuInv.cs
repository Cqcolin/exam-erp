using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class SkuInv
    {
        private List<SkuInfo> TotalInv = new List<SkuInfo>();

        public SkuInv()
        {
            TotalInv.Add(SkuInfo.CreateSkuA(1, 4, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuA(5, 2, BatchNoEnum.s22222));
            TotalInv.Add(SkuInfo.CreateSkuA(3, 1, BatchNoEnum.s33333));
            TotalInv.Add(SkuInfo.CreateSkuA(3, 1, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuB(10, 10, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuC(0, 1, BatchNoEnum.s11111));
        }


        public void DealBill(IInvCosFactory invCosFactory, List<Bill> bills)
        {
            foreach (Bill bill in bills)
            {
                invCosFactory.DealBills(TotalInv, bill);
            }
        }

        public void GetInvCos(IInvCosFactory invCosFactory, SkuInfo sku)
        {
            invCosFactory.GetInvCos(TotalInv, sku);
        }

        public decimal GetInvCos(IInvCosFactory invCosFactory)
        {
            return invCosFactory.GetInvCos(TotalInv);
        }

        public void AddInv(SkuInfo sku)
        {
            TotalInv.Add(sku);
        }

    }
}
