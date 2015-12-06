using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDemo;

namespace UnitTestDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            //初始值
            // 物料      数量
            //sku001    12    
            //sku002    10
            //sku003     0
            SkuInv inv = new SkuInv();
            IInvCosFactory invCosFactory = InvCosFactory.GetFIFOCalFactory();
            Console.WriteLine("{0}", inv.GetInvCos(invCosFactory));
            inv.GetInvCos(invCosFactory, new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });

            //sku003    +10
            inv.AddInv(new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString(), Amount = 10, Price = 2 });
            inv.GetInvCos(invCosFactory, new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });

            inv.DealBill(invCosFactory, new List<Bill>()
            {
                new Bill("bill001",DirectionEnum.In,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 10,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    },
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku001.ToString(),
                        Amount = 10,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    },
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku001.ToString(),
                        Amount = 10,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    },
                    
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku002.ToString(),
                        Amount = 10,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    }
                })            
            });
            inv.GetInvCos(invCosFactory, new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });
            inv.GetInvCos(invCosFactory, new SkuInfo() { SkuCode = SkuCodeEnum.sku001.ToString() });

            inv.DealBill(invCosFactory, new List<Bill>()
            {
                new Bill("bill002",DirectionEnum.Out,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 11,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    },
                    new SkuInfo()
                    {
                        SkuCode = SkuCodeEnum.sku001.ToString(),
                        Amount = 4,
                        Price = 2,
                        BatchNo = BatchNoEnum.s22222.ToString()
                    }
                })   ,
                 new Bill("bill003",DirectionEnum.Out,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 5,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    }
                })       
            });
            inv.GetInvCos(invCosFactory, new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });

        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    DateTime now = DateTime.Now;
        //    List<SkuInfo> skus = new List<SkuInfo>()
        //    {
        //        new SkuInfo(){ID = 2,Name = "WCF 高级编程",Amount = 1,Price = 40,InInvTime = now.AddDays(-30)},
        //        new SkuInfo(){ID = 2,Name = "WCF 高级编程",Amount = 1,Price = 30,InInvTime = now.AddDays(-20)},
        //        new SkuInfo(){ID = 1,Name = "ASP.NET从入门到精通",Amount = 2,Price = 50,InInvTime = now.AddDays(-30)},
        //        new SkuInfo(){ID = 1,Name = "ASP.NET从入门到精通",Amount = 1,Price = 50,InInvTime =now.AddDays(-30)},
        //        new SkuInfo(){ID = 1,Name = "ASP.NET从入门到精通",Amount = 3,Price = 80,InInvTime =now.AddDays(-20)},
        //        new SkuInfo(){ID = 1,Name = "ASP.NET从入门到精通",Amount = 2,Price = 50,InInvTime = now.AddDays(-30)},
        //        new SkuInfo(){ID = 1,Name = "ASP.NET从入门到精通",Amount = 3,Price = 55,InInvTime =now.AddDays(-10)}
        //    };
        //    IInvCosFactory invCos;
        //    invCos = InvCosFactory.GetIndividualCalFactory();

        //    // 70+240+165+250 = 725
        //    Console.WriteLine(string.Format("{0}:{1}\n", "个别计算", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));
        //    //80+550 =630
        //    invCos = InvCosFactory.GetFIFOCalFactory();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "先进先出", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));

        //    //60+605 = 665
        //    invCos = InvCosFactory.GetLIFOCalFactory();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "后进先出", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));

        //    //40+
        //    invCos = InvCosFactory.GetWeightedAverageCalFactoryy();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "加权平均", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));


        //    invCos = InvCosFactory.GetMovingWeightedAverageCalFactory();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "移动加权平均", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));


        //    invCos = InvCosFactory.GetFIFOMovingWeightedAverageCalFactory();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "移动加权平均(FIFO)", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));


        //    invCos = InvCosFactory.GetLIFOMovingWeightedAverageCalFactory();
        //    Console.WriteLine(string.Format("{0}:{1}\n", "移动加权平均(LIFO)", invCos.GetInvCos(skus)));
        //    Console.WriteLine(string.Format("-------------------------------------------\n"));


        //}

    }
}
