using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    /// <summary>
    /// Class that generate and print questions
    /// </summary>
    /// <Author>Belyi Egor</Author>
    public static partial class Generator
    {
        /// <summary>
        /// Метод для перемешки списка ответов
        /// </summary>
        /// <param name="originalList"></param>
        /// <Author>Veremeychik Alex</Author>
        public static void Shuffling(List<string> originalList)
        {
            Random random = new Random();
            for (int i = originalList.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // Обменять значения originalList[j] и originalList[i]
                string temp = originalList[j];
                originalList[j] = originalList[i];
                originalList[i] = temp;
            }
        }
        /// <summary>
        /// Генерация билета с указанным числом вопросов
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="questAmount">число вопросов в билете</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static void GenerateTicket(MyData[] mas, int questAmount)
        {
            Random rand = new Random();
            int countOfTypes = 5;//число типов вопросов (их  5 потом будет)
            int[] questions = new int[countOfTypes];
            for (int i = 0; i < questAmount; i++)
            {
                int type;
                do
                {
                    type = rand.Next(countOfTypes);
                }
                while (questions[type] > questAmount / countOfTypes);
                // if (type == prevType) type = rand.Next(countOfTypes);
                switch (type)
                {
                    case 0:
                        GenerateLinear(mas, 5, 1, true);
                        questions[0]++;
                        break;
                    case 1:
                        GenerateLinear(mas, 5, 1, false);
                        questions[1]++;
                        break;
                    case 2:
                        GenerateEnum(mas, 5, 1);
                        questions[2]++;
                        break;
                    case 3:
                        GenerateIsIt(mas, 1);
                        questions[3]++;
                        break;

                    case 4:
                        GenerateGroup(mas, 5, 1);
                        questions[4]++;
                        break;
                }

            }
        }

        /// <summary>
        /// Function that generate and print enum questions,  
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static void GenerateEnum(MyData[] mas, int ogr, int amount)
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

                    if (mas[i].type == 1)
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

            void GenerateQuest1(List<int> a, List<int> b, int k)
            {
                Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                k--;
                while (k-- > 0)
                {
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    b.RemoveAt(IA);

                    Console.WriteLine($"T){AA.text}");
                }
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {

                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                    GenerateQuest1(a, b, k - 2);
                    Console.WriteLine($"T)Все перечисленное");
                    Console.WriteLine($"T)Ничего из перечисленного");
                }
                else if (allOrNo == 1)//если все являются
                {
                    while (k-- > 0)
                    {
                        int IA = rand.Next(a.Count);
                        var AA = mas[a[IA]];
                        a.RemoveAt(IA);

                        Console.WriteLine($"T){AA.text}");
                    }
                    Console.WriteLine($"1)Все перечисленное");
                    Console.WriteLine($"T)Ничего из перечисленного");
                }
                else if (allOrNo == 2)//если все не являются
                {
                    while (k-- > 0)
                    {
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        b.RemoveAt(IA);

                        Console.WriteLine($"T){AA.text}");
                    }
                    Console.WriteLine($"T)Все перечисленное");
                    Console.WriteLine($"1)Ничего из перечисленного");
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                //  Console.WriteLine($"{amount}");
                Console.WriteLine();
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(4, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                //intQuest.RemoveAt(IQ);

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

        

        /// <summary>
        /// Function that generate and print enum questions with probability
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static void GenerateEnum(MyDataWithProbability[] mas, int ogr, int amount)
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

                    if (mas[i].type == 1)
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

            void GenerateQuest1(List<int> a, List<int> b, int k)
            {
                    Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                    List<int> appearedAnswers = new List<int>();
                    k--;
                    int ca = 0;
                    while (k-- > 0)
                    {
                        if (b.Count == 0)
                        {
                            if (ca < 2)//для того, чтобы было минимум 2 варианта ответа
                            {
                                b = intTrueAns.Slice(0, intFalseAns.Count);
                                appearedAnswers.ForEach(delegate (int index)
                                {
                                    b.Remove(index);
                                });
                                k ++;
                            }
                            else
                                break;
                        }
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        if (AA.probability != 1)
                        {
                            int c = (int)Math.Round(1 / AA.probability);
                            int rnd = rand.Next(c);
                            if (rnd == 1)
                            {
                                Console.WriteLine($"T){AA.text}");
                                ca++;
                                appearedAnswers.Add(b[IA]);
                            }
                            else k++;
                        }
                        else
                        {
                            Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(b[IA]);
                        }
                        b.RemoveAt(IA);
                    }
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {

                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                    GenerateQuest1(a, b, k );
                    Console.WriteLine($"T)Все перечисленное");
                    Console.WriteLine($"T)Ничего из перечисленного");
                }
                else if (allOrNo == 1)//если все являются
                {
                    List<int> appearedAnswers = new List<int>();
                    int ca = 0;
                    while (k-- > 0)
                    {
                        if (a.Count == 0) {
                            if (ca < 2)//для того, чтобы было минимум 2 варианта ответа
                            {
                                a = intTrueAns.Slice(0, intTrueAns.Count);
                                appearedAnswers.ForEach(delegate (int index)
                                {
                                    a.Remove(index);
                                });
                                k ++;
                            }
                            else
                                break;
                        }
                        int IA = rand.Next(a.Count);
                        var AA = mas[a[IA]];
                        if (AA.probability != 1)
                        {
                            int c = (int)Math.Round(1 / AA.probability);
                            int rnd = rand.Next(c);
                            if (rnd == 1)
                            {
                                Console.WriteLine($"T){AA.text}");
                                ca++;
                                appearedAnswers.Add(a[IA]);
                            }
                            else k++;
                        }
                        else
                        {
                            Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(a[IA]);
                        }
                        a.RemoveAt(IA);

                    }
                    Console.WriteLine($"1)Все перечисленное");
                    Console.WriteLine($"T)Ничего из перечисленного");
                }
                else if (allOrNo == 2)//если все не являются
                {
                    List<int> appearedAnswers = new List<int>();
                    int ca = 0;
                    while (k-- > 0)
                    {
                        if (b.Count == 0)
                        {
                            if (ca < 2)//для того, чтобы было минимум 2 варианта ответа
                            {
                                b = intFalseAns.Slice(0, intFalseAns.Count);
                                appearedAnswers.ForEach(delegate (int index)
                                {
                                    b.Remove(index);
                                });
                                    k ++;
                            }
                            else
                                break;
                        }
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        if (AA.probability != 1)
                        {
                            int c = (int)Math.Round(1 / AA.probability);
                            int rnd = rand.Next(c);
                            if (rnd == 1)
                            {
                                Console.WriteLine($"T){AA.text}");
                                ca++;
                                appearedAnswers.Add(b[IA]);
                            }
                            else k++;
                        }
                        else
                        {
                            Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(b[IA]);
                        }
                        b.RemoveAt(IA);

                    }
                    Console.WriteLine($"T)Все перечисленное");
                    Console.WriteLine($"1)Ничего из перечисленного");
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                //  Console.WriteLine($"{amount}");
                Console.WriteLine();
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(2, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                //intQuest.RemoveAt(IQ);

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
