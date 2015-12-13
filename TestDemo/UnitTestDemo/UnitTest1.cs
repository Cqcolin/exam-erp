using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Biz biz = new Biz();

            IInvCosFactory invCosFactory = InvCosFactory.GetFIFOCalFactory();
            biz.SetCosFactory(invCosFactory);
            Console.WriteLine("{0}", biz.GetInvCos());

            //sku003    +10
            biz.AddInv(new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString(), Amount = 10, Price = 2, InInvTime = new DateTime(2015, 2, 2) });

            Assert.AreEqual(10, biz.GetSkuAmount(SkuCodeEnum.sku003.ToString()));
            Assert.AreEqual(2, biz.GetSkuPrice(SkuCodeEnum.sku003.ToString()));

            biz.GetInvCos(new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });

            #region Bill1


            Console.WriteLine("***********************  Begin1  ************************\n");

            biz.DealBill(new List<Bill>()
            {
                new Bill("bill001",DirectionEnum.In,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 10,
                        Price = 12,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,12,12)
                    },
                     new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 10,
                        Price = 1,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,1,1)
                    }, 
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 10,
                        Price = 5,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,5,5)
                    },
                     new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 10,
                        Price = 3,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,3,3)
                    },
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku001.ToString(),
                        Amount = 10,
                        Price = 1201,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,12,01)
                    },
                     new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku001.ToString(),
                        Amount = 10,
                        Price = 1203,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,12,03)
                    },
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku001.ToString(),
                        Amount = 10,
                        Price = 1202,
                        BatchNo = BatchNoEnum.s11111.ToString(),
                        InInvTime = new DateTime(2015,12,02)
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
            //sku003 库存数量
            Assert.AreEqual(50, biz.GetSkuAmount(SkuCodeEnum.sku003.ToString()));
            //价格。
            Assert.AreEqual(1, biz.GetSkuPrice(SkuCodeEnum.sku003.ToString()));

            //sku001 库存数量
            Assert.AreEqual(42, biz.GetSkuAmount(SkuCodeEnum.sku001.ToString()));
            //价格。
            Assert.AreEqual(4, biz.GetSkuPrice(SkuCodeEnum.sku001.ToString()));


            Console.WriteLine("***********************  End1  ************************\n");

            #endregion


            biz.GetInvCos(new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });
            biz.GetInvCos(new SkuInfo() { SkuCode = SkuCodeEnum.sku001.ToString() });


            #region Bill2

            Console.WriteLine("***********************  Begin2  ************************\n");
            biz.DealBill(new List<Bill>()
            {
                new Bill("bill002",DirectionEnum.Out,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 11,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    },
                    new SkuInfo()
                    {
                        SkuCode = SkuCodeEnum.sku001.ToString(),
                        Amount = 4,
                        BatchNo = BatchNoEnum.s22222.ToString()
                    }
                })   ,
                 new Bill("bill003",DirectionEnum.Out,new List<SkuInfo>()
                {
                    new SkuInfo()
                    {
                        SkuCode =  SkuCodeEnum.sku003.ToString(),
                        Amount = 15,
                        BatchNo = BatchNoEnum.s11111.ToString()
                    }
                })       
            });

            //sku003 库存数量
            Assert.AreEqual(24, biz.GetSkuAmount(SkuCodeEnum.sku003.ToString()));
            //价格。
            Assert.AreEqual(3, biz.GetSkuPrice(SkuCodeEnum.sku003.ToString()));


            Console.WriteLine("***********************  end2  ************************\n");

            #endregion


            biz.GetInvCos(new SkuInfo() { SkuCode = SkuCodeEnum.sku003.ToString() });

        }
     
    }
}
