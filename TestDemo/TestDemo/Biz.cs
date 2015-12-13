using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class Biz
    {
        private List<SkuInfo> TotalInv = new List<SkuInfo>();
        private  IInvCosFactory invCosFactory = new FIFOCalFactory();

        public void SetCosFactory(IInvCosFactory value)
        {
            invCosFactory = value;
        }

        public Biz()
        {
            TotalInv.Add(SkuInfo.CreateSkuA(1, 4, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuA(5, 2, BatchNoEnum.s22222));
            TotalInv.Add(SkuInfo.CreateSkuA(3, 1, BatchNoEnum.s33333));
            TotalInv.Add(SkuInfo.CreateSkuA(3, 1, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuB(10, 10, BatchNoEnum.s11111));
            TotalInv.Add(SkuInfo.CreateSkuC(0, 1, BatchNoEnum.s11111));
        }


        public void DealBill(List<Bill> bills)
        {
            foreach (Bill bill in bills)
            {
                invCosFactory.DealBills(TotalInv, bill);
            }
        }



        public void GetInvCos(SkuInfo sku)
        {
            invCosFactory.GetInvCos(TotalInv, sku);
        }

        public decimal GetInvCos()
        {
            return invCosFactory.GetInvCos(TotalInv);
        }


        public decimal GetSkuPrice(string skucode)
        {
            return invCosFactory.GetSkuPrice(TotalInv, new SkuInfo() { SkuCode = skucode });
        }
        public int GetSkuAmount(string skucode)
        {
            return invCosFactory.GetSkuAmount(TotalInv, new SkuInfo() { SkuCode = skucode });
        }
        public void AddInv(SkuInfo sku)
        {
            TotalInv.Add(sku);
        }

    }
}
