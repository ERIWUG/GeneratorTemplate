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

        
        
      

        

        /// <param name="mas"></param>
        /// <param name="ogr"></param>
        /// <param name="amount"></param>
        /// <Author>Alex Veremeychik</Author>>

        public static void GenerateGroup(MyData[] mas, int ogr, int amount)
        {
            Random rand = new Random();
            int amQuest = 0;
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<int> intAnswer = new List<int>();

            List<string> AllAnsw = new List<string>();
            List<string> CorrectAnswers = new List<string>();
            List<string> GroupOfAnswers = new List<string>();

            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length - 1)
                {

                    if (mas[i].type == 1)
                    {
                        intQuest.Add(i);
                    }
                    if (mas[i].type == 2)
                    {
                        intAnswer.Add(i);
                        if (mas[i].flag)
                        {
                            intTrueAns.Add(i);
                        }
                        else
                        {
                            intFalseAns.Add(i);
                        }
                    }
                }
            }


            string GenerateRandomStrings(List<string> list)
            {
                // Создание копии списка для извлечения элементов без повторений
                List<string> tempList = new List<string>(list);
                List<string> randomElements = new List<string>();

                // Определение случайного количества элементов для выборки
                int numberOfElements = rand.Next(0, tempList.Count + 1);
                if (numberOfElements == 0)
                {
                    return "Ничего из перечисленного";
                }
                // Выбор случайных элементов без повторений и в исходном порядке
                while (randomElements.Count < numberOfElements)
                {
                    int index = rand.Next(tempList.Count);
                    randomElements.Add(tempList[index]);
                    tempList.RemoveAt(index); // Удаление выбранного элемента, чтобы избежать повторений
                }
                randomElements.Sort((a, b) => list.IndexOf(a).CompareTo(list.IndexOf(b)));
                return String.Join("; ", randomElements);
            }




            void GenerateAnswers(List<int> full, bool sign, int k)
            {
                while (k-- > 0)
                {
                    int IA = rand.Next(full.Count);
                    var AA = mas[full[IA]];
                    full.RemoveAt(IA);
                    Console.WriteLine($"----{AA.text},  {AA.flag}\n");
                    AllAnsw.Add(AA.text);
                    if (sign)
                    {
                        if (AA.flag)
                        {
                            CorrectAnswers.Add(AA.text);
                        }
                    }
                    else
                    {
                        if (!AA.flag)
                        {
                            CorrectAnswers.Add(AA.text);
                        }
                    }
                }
                string CorrectString = String.Join("; ", CorrectAnswers);

                if (CorrectString == null || CorrectAnswers.Count == 0)
                {
                    CorrectString = "Ничего из перечисленного";
                }

                int minvalue = 3;
                int maxvalue = 5;
                if (AllAnsw.Count == 3)
                {
                    maxvalue = 4;
                }
                int NumberOfAnswers = rand.Next(minvalue, maxvalue);

                GroupOfAnswers.Add(CorrectString);
                while (GroupOfAnswers.Count < NumberOfAnswers)
                {
                    string randomString = GenerateRandomStrings(AllAnsw);
                    if (!GroupOfAnswers.Contains(randomString))
                    {
                        GroupOfAnswers.Add(randomString);
                    }


                }
                int n = 0;
                Shuffling(GroupOfAnswers);
                foreach (string str in GroupOfAnswers)
                {
                    n++;
                    Console.WriteLine(Convert.ToString(n) + " " + str);
                }
                Console.WriteLine();

                GroupOfAnswers.Clear();
            }


            ParseData(mas);

            while (amount-- > 0)
            {
                Console.WriteLine($"{amount}");
                List<int> Answers = new List<int>(intAnswer);
                int AmountOfAnswersWithQuestion = rand.Next(2, ogr);

                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                AllAnsw.Clear();
                CorrectAnswers.Clear();

                Console.WriteLine($"{AQ.text}\n");
                if (!AQ.flag)
                {
                    GenerateAnswers(Answers, false, AmountOfAnswersWithQuestion);
                }
                else
                {
                    GenerateAnswers(Answers, true, AmountOfAnswersWithQuestion);
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
