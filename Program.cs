using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KolawaAdela
{
    class Program
    {
        //<summary>Array numbers of semiprimes within specified ranges.</summary>
        //<param name="N">The most semiprime in array. </param>
        //<param name="P">Array first number of specified range.</param>
        //<param name="M">Array last number of specified range.</param>
        //<returns>Array queries about the number of semiprimes within specified ranges</returns>

        public static int[] NumberSemiprimes(int N, int[] P, int[] Q, int M)
        {

            int[] NumberSemiprime = new int[M];
            int q = 0;
            int r;
            int[] Prime = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            int[] SemiPrime = new int[100];
            for (int i = 0; i < Prime.Length; i++)
            {
                for (int j = 0; j < Prime.Length; j++)
                {
                    if (Prime[i] * Prime[j] <= N && (j >= i))
                    {
                        SemiPrime[q] = Prime[i] * Prime[j];
                        q++;
                    }
                }
            }

            for (int i = 0; i < M; i++)
            {
                r = 0;
                for (int j = 0; j < SemiPrime.Length; j++)
                {
                    if (SemiPrime[j] >= P[i] && SemiPrime[j] <= Q[i])
                    {
                        r++;
                    }
                }

                NumberSemiprime[i] = r;

            }


            return NumberSemiprime;

        }
        static void Main(string[] args)
        {
            int[] P = new int[] { 1, 4, 16 };
            int[] Q = new int[] { 26, 10, 20 };
            foreach (int i in Program.NumberSemiprimes(26, P, Q, 3))
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }

    [TestClass]
    public class TestProgram
    {
        [TestMethod]
        public void TestNumberSemiprimes()
        {
            int[] P = new int[] {1,4,16};
            int[] Q = new int[] {26,10,20};
            int[] R = new int[] { 10, 4, 0 };
            for(int i=0; i<R.Length;i++)
            {
                Assert.AreEqual(R[i],Program.NumberSemiprimes(26,P,Q,3)[i]);
            }

          
        }
    }
}
