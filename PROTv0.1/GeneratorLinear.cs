using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    public static partial class Generator
    {
        /// <summary>
        /// Function that generate and print linear question, can generate true and false questions
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>>
        /// <param name="mark">bool is Negative?</param>>
        /// <Author>Belyi Egor</Author>
        public static Question GenerateLinear(MyData[] mas, int ogr, int amount, bool mark)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<string> ans = new List<string>();
            int IndAnswer = 0;
            string AQQQQ = null;
            string MyHash = "DBNAME-G1-";
            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length - 1)
                {

                    if (mas[i].type == 1 && mas[i].flag == mark)
                    {
                        intQuest.Add(i);
                    }
                    else
                    {
                        if (mas[i].flag && mas[i].type == 2)
                        {
                            intTrueAns.Add(i);
                        }
                        if (!mas[i].flag && mas[i].type == 2)
                        {
                            intFalseAns.Add(i);
                        }
                    }
                }
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                int i = a[rand.Next(a.Count)];
                ans.Add(mas[i].text);
                //Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                MyHash += $"{i}-";
                while (k-- > 0)
                {
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    b.RemoveAt(IA);
                    ans.Add(AA.text);
                    MyHash += $"{b[IA]}-";
                    //Console.WriteLine($"T){AA.text}");
                }
            }

            ParseData(mas);

            while (amount-- > 0)
            {
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(2, ogr);

                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                MyHash += $"{IQ}-{k}-";
                //intQuest.RemoveAt(IQ);
                AQQQQ = AQ.text;
                //Console.WriteLine($"{AQ.text}");
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }
            return new Question(AQQQQ, ans.ToArray(), IndAnswer, MyHash + "0");

        }




        /// <summary>
        /// Function that generate and print linear question with probability, can generate true and false questions
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>>
        /// <param name="flag">bool is Negative?</param>>
        public static void GenerateLinear(MyDataWithProbability[] mas, int ogr, int amount, bool flag)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();

            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length - 1)
                {

                    if (mas[i].type == 1 && mas[i].flag == flag)
                    {
                        intQuest.Add(i);
                    }
                    else
                    {
                        if (mas[i].flag && mas[i].type == 2)
                        {
                            intTrueAns.Add(i);
                        }
                        if (!mas[i].flag && mas[i].type == 2)
                        {
                            intFalseAns.Add(i);
                        }
                    }
                }
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                k--;
                while (k-- > 0)
                {
                    if (b.Count == 0) break;
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    if (AA.probability != 1)
                    {
                        int c = (int)Math.Round(1 / AA.probability);
                        int rnd = rand.Next(c);
                        if (rnd == 1) Console.WriteLine($"T){AA.text}");
                        else k++;
                    }
                    else
                    {
                        Console.WriteLine($"T){AA.text}");
                    }
                    b.RemoveAt(IA);
                }
            }

            ParseData(mas);

            while (amount-- > 0)
            {
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                //  int k = rand.Next(2, ogr);
                //эта строка заменена для отладки
                int k = ogr;
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];

                Console.WriteLine($"{AQ.text}");
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }
            Console.WriteLine();

        }
    }
}
