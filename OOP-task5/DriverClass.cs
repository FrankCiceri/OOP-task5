using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPtask5
{
    internal class DriverClass
    {

        public static void Main(string[] args) {
            //I made the constructor so it receives the coefficients from the greater to the less exponent 
            // Bassically I am doing  – 12x^7  + 5x^5 + 4x^2 - 3 
            Poly poly1 = new Poly(-12, 0, 5, 0, 0, 0, 4,-3);
            Console.WriteLine(poly1);


            Poly poly2 = new Poly(-1, 0, 5, 0, 0, 1, 4, -3);
            Console.WriteLine(poly2);

            Console.WriteLine(poly1+poly2);

            Console.WriteLine(poly1 - poly2);

            Console.WriteLine(poly1 * poly2);  //https://shorturl.at/hAOQ0 url for the comparison of the result, you can use the same page for + and -

        }

    }
}
