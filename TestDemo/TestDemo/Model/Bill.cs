using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{

    public class Bill
    {
        public Bill(string billno, DirectionEnum direction, List<SkuInfo> listsku)
        {
            skus =  new List<SkuInfo>();
            BillNumber = billno;
            Direction = direction;

            if (listsku.Count > 0)
            {
                skus.AddRange(listsku);
            }

        }
        public string BillNumber { get; set; }

        public DirectionEnum Direction { get; set; }

        public List<SkuInfo> skus { get; set; }

    }
}
