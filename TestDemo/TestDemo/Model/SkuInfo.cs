using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class SkuInfo : ICloneable
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string SkuCode { get; set; }
        public string BatchNo { get; set; }

        public decimal Price { get; set; }
        public int Amount { get; set; }

        public DateTime InInvTime { get; set; }


        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public static SkuInfo CreateSkuA(int amount, decimal price, BatchNoEnum batchno)
        {
            return new SkuInfo() { ID = 1, SkuCode = SkuCodeEnum.sku001.ToString(), Amount = amount, BatchNo = batchno.ToString(), Price = price,Name = "A物料"};
        }

        public static SkuInfo CreateSkuB(int amount, decimal price, BatchNoEnum batchno)
        {
            return new SkuInfo() { ID = 2, SkuCode = SkuCodeEnum.sku002.ToString(), Amount = amount, BatchNo = batchno.ToString(), Price = price,Name = "B物料"};
        }
        public static SkuInfo CreateSkuC(int amount, decimal price, BatchNoEnum batchno)
        {
            return new SkuInfo() { ID = 3, SkuCode = SkuCodeEnum.sku003.ToString(), Amount = amount, BatchNo = batchno.ToString(), Price = price,Name = "C物料"};
        }

    }
}
