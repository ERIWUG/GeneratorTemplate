using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    /// <summary>
    /// Class that generate and print questions
    /// </summary>
    internal static class Generator
    {
        
        /// <summary>
        /// Function that generate and print question
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>>
        public static void GenerateLinear(MyData[] mas,int ogr,int amount) {
            Random rand = new Random();
            int amQuest = 0;
            List<int> intTrueAns = new List<int> ();
            List<int> intFalseAns = new List<int> ();
            List<int> intQuest = new List<int> ();

            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length-1)
                {
                    
                    if (mas[i].priz == 1)
                    {
                        intQuest.Add (i);
                    }
                    else
                    {
                        if (mas[i].isTrue)
                        {
                            intTrueAns.Add (i);
                        }
                        else
                        {
                            intFalseAns.Add (i);
                        }
                    }
                }
            }

            void GenerateQuest(List<int> a,List<int> b,int k)
            {
                Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}\n");
                k--;
                while (k-- > 0)
                {
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    b.RemoveAt(IA);

                    Console.WriteLine($"T){AA.text}\n");
                }
            }

            ParseData(mas);

            while (amount-- > 0)
            {
                Console.WriteLine($"{amount}");
                List<int> mT = intTrueAns;
                List<int> mF = intFalseAns;
                int k = rand.Next(2, ogr);

                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                intQuest.RemoveAt(IQ);

                Console.WriteLine($"{AQ.text}\n");
                if (AQ.isNeg)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }

        }

        


    }
}
