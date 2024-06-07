using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_product_lab2
{
    internal class SinFunc : IFunction
    {
        public float Calc(float x)
        {
            return (float)Math.Sin(x);
        }
    }
}
