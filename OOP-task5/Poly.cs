using System.Text;

namespace OOPtask5
{
    public class Poly
    {
        private readonly int[] coeffs;



        public Poly(params int[] coeffs)
        {

            this.coeffs = coeffs;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            for (int i = coeffs.Length - 1; i >= 0; i--)
            {
                if (coeffs[i] == 0) // if the value we are working with is 0, it means that we have no coefficient there
                    continue;

                if (i != coeffs.Length - 1 && coeffs[i] > 0) //if the coeffieficcient is not the last one, and is positive
                    sb.Append(" + ");                        // then we can append a +, that way we avoid placing a + when our first element
                else if (coeffs[i] < 0)                      // in the sb is positive
                    sb.Append(" - ");

                int absVal = Math.Abs(coeffs[i]);
              
                if (absVal != 1)
                    sb.Append(absVal);

                int exp = (coeffs.Length - 1) - i;
                if (exp > 0)
                    sb.Append(exp==1? "x" : "x^" + (exp));
            }

            return sb.ToString();
        }



        public static Poly operator +(Poly p1, Poly p2)
        {
            
            var (min, max) = MinMax(p1, p2);
            int[] newCoeffs = new int[max];

            for (int i = 0; i < min; i++) {
                newCoeffs[i] = p1.coeffs[i] + p2.coeffs[i];
            
            }

            for (int i = min; i < max; i++)
            {
                newCoeffs[i] = p1.coeffs.Length < p2.coeffs.Length ? p2.coeffs[i] : p1.coeffs[i];

            }

            return new Poly(newCoeffs);
             
        }
        public static Poly operator -(Poly p1, Poly p2)
        {

            var (min, max) = MinMax(p1, p2);
            int[] newCoeffs = new int[max];

            for (int i = 0; i < min; i++)
            {
                newCoeffs[i] = p1.coeffs[i] - p2.coeffs[i];

            }

            for (int i = min; i < max; i++)
            {
                newCoeffs[i] = p1.coeffs.Length < p2.coeffs.Length ? -p2.coeffs[i] : p1.coeffs[i];

            }

            return new Poly(newCoeffs);

        }

        public static Poly operator *(Poly p1, Poly p2)
        {

            int[] newCoeffs = new int[p1.coeffs.Length + p2.coeffs.Length - 1];

            for (int i = 0; i < p1.coeffs.Length; i++)
            {
                for (int j = 0; j < p2.coeffs.Length; j++)
                {
                    newCoeffs[i + j] += p1.coeffs[i] * p2.coeffs[j];
                }
            }

            return new Poly(newCoeffs);

        }

        private static (int, int) MinMax(Poly p1, Poly p2) {
         
            if (p1.coeffs.Length <=p2.coeffs.Length)
            {
                return (p1.coeffs.Length, p2.coeffs.Length);
            }
            
          return (p2.coeffs.Length, p1.coeffs.Length);

        }
    }
}