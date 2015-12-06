using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public static class MyExtensions
    {
        public static bool SameSkuCode(this SkuInfo obj1, SkuInfo obj2)
        {
            if (null == obj1 || null == obj2)
                return false;
            if (obj1.SkuCode.Equals(obj2.SkuCode))
            {
                return true;
            }
            return false;
        }
        public static bool EqualSku(this SkuInfo obj1, SkuInfo obj2)
        {
            if (null == obj1 || null == obj2)
                return false;
            if (obj1.SkuCode.Equals(obj2.SkuCode) && obj1.BatchNo.Equals(obj2.BatchNo))
            {
                return true;
            }
            return false;
        }

        public static List<SkuInfo> ToSkuInfo(this Bill bill)
        {
            List<SkuInfo> skus = new List<SkuInfo>();

            foreach (SkuInfo item in bill.skus)
            {
                skus.Add(item.Clone() as SkuInfo);

            }
            return skus;
        }
    }
}
