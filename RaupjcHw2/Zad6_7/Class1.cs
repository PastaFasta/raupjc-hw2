using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad6_7
{
    public class Class1
    {
        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }
        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await FactorialDigitSum(n);
        }

        //Ignore this part.
        static void Main(string[] args)
        {
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        public static async Task<int> FactorialDigitSum(int n)
        {
            int result = await Task.Run(() => DigitSum(n));

            return result;
        }

        public static int DigitSum(int n)
        {
            int factoriel = 1, sum = 0;
            for (int i = 2; i <= n; i++)
            {
                factoriel *= i;
            }
            while (factoriel != 0)
            {
                sum += factoriel % 10;
                factoriel /= 10;
            }
            return sum;
        }
    }
}
