using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
     public class Calculadora : ICalculadora
    {
        public int Suma(int a, int b)
        {
            return a + b;
        }
        public int Resta(int a, int b)
        {
            return a - b;
        }
        public int Multiplicacion(int a, int b)
        {
            return a * b;
        }
    }
}
