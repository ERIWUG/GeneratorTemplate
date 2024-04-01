using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    /// <summary>
    /// Class that calculates the power of generators
    /// </summary>
    /// <Author>Nichyporuk V.A.</Author>
    internal class PowerCalculator
    {
        /// <summary>
        /// Function calculates the power of generateLinear
        /// </summary>
        /// <param name="n">Количество вопросов</param>
        /// <param name="m">Количество ответов</param>
        /// <param name="k">Число вариантов ответов</param>
        /// <returns></returns>
        public static int powerLinear(int n, int m, int k)
        {
            long c = Factorial(m) / (Factorial(m - k) * Factorial(k));
            return (int) c * n;
        }

        /// Function calculates the power of generateEnum
        /// </summary>
        /// <param name="n">Количество вопросов</param>
        /// <param name="m">Количество ответов</param>
        /// <param name="k">Число вариантов ответов</param>
        /// <returns></returns>
        public static int powerEnum(int n, int m, int k)
        {
            return powerLinear(n, m, k - 2);
        }

        /// Function calculates the power of generateIsIt
        /// </summary>
        /// <param name="n">Количество вопросов</param>
        /// <param name="m">Количество ответов</param>
        /// <param name="k">Число вариантов ответов</param>
        /// <returns></returns>
        public static int powerIsIt(int n, int m)
        {
            return m;
        }

        /// Function calculates the power of generateGroup
        /// </summary>
        /// <param name="n">Количество вопросов</param>
        /// <param name="m">Количество ответов</param>
        /// <param name="k">Число вариантов ответов</param>
        /// <returns></returns>
        public static int powerGroup(int n, int m, int k)
        {
            long c = 1;
            for (int i = 0;i<=k; i++)
                c+= Factorial(m) / (Factorial(m - i) * Factorial(i));
            return (int)c*n;
        }


       /// <author>Chepeleva TI</author>
        public static long Factorial(int f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}
