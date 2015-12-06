using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public static class InvCosFactory
    {
        public static IndividualCalFactory GetIndividualCalFactory()
        {
            return new IndividualCalFactory();
        }


        public static FIFOCalFactory GetFIFOCalFactory()
        {
            return new FIFOCalFactory();
        }


        public static LIFOCalFactory GetLIFOCalFactory()
        {
            return new LIFOCalFactory();
        }


        public static IInvCosFactory GetWeightedAverageCalFactoryy()
        {
            return new WeightedAverageCalFactory();
        }


        public static IInvCosFactory GetMovingWeightedAverageCalFactory()
        {
            return new MovingWeightedAverageCalFactory();
        }


        public static IInvCosFactory GetLIFOMovingWeightedAverageCalFactory()
        {
            return new LIFOMovingWeightedAverageCalFactory();
        }

        public static IInvCosFactory GetFIFOMovingWeightedAverageCalFactory()
        {
            return new FIFOMovingWeightedAverageCalFactory();
        }

    }

}
