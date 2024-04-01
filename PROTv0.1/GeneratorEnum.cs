﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROTv0._1
{
    public static partial class Generator
    {
        /// <summary>
        /// Function that generate and print enum questions,  
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static Question[] GenerateEnum(MyData[] mas, int ogr, int amount)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<string> ans = new List<string>();
            Question[] questions = new Question[amount];
            int IndAnswer = 0;
            int l = 0;
            string AQQQQ = null;
            string MyHash = "DBNAME-G1-";
            String ANSW1 = "Все перечисленное.";
            String ANSW2 = "Ничего из перечисленного";
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
                ans.Clear();
                int i = a[rand.Next(a.Count)];
                ans.Add(mas[i].text);
                //Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                MyHash += $"{i}-";
                while (k-- > 0)
                {
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    ans.Add(AA.text);
                    MyHash += $"{b[IA]}-";
                    b.RemoveAt(IA);
               
                    //Console.WriteLine($"T){AA.text}");

                }
                ans.Add(ANSW1);
                ans.Add(ANSW2);
                questions[l] = new Question(AQQQQ, ans.ToArray(), IndAnswer, MyHash + "0");
                l++;
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                int kk = k;
                List<String> ans2 = new List<String>();
                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                 GenerateQuest1(a, b, k - 2);
                    //   Console.WriteLine($"T)Все перечисленное");
                    //    Console.WriteLine($"T)Ничего из перечисленного");
                }
                else if (allOrNo == 1)//если все являются
                {

                    MyHash += $"{k-2}-";
                    while (k-- > 0)
                    {
                        int IA = rand.Next(a.Count);
                        var AA = mas[a[IA]];
                       
                        ans2.Add(AA.text);
                        MyHash += $"{a[IA]}-";
                        a.RemoveAt(IA);
                        //   Console.WriteLine($"T){AA.text}");
                    }
                    //     Console.WriteLine($"1)Все перечисленное");
                    //     Console.WriteLine($"T)Ничего из перечисленного");
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk-2, MyHash + "0");
                    l++;
                }
                else if (allOrNo == 2)//если все не являются
                {
                    MyHash += $"{k-1}-";
                    while (k-- > 0)
                    {
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        ans2.Add(AA.text);
                        MyHash += $"{b[IA]}-";
                        b.RemoveAt(IA);
                        //    Console.WriteLine($"T){AA.text}");
                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                  //  Console.WriteLine($"T)Все перечисленное");
                   // Console.WriteLine($"1)Ничего из перечисленного");
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk-1, MyHash + "0");
                    l++;
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                MyHash = "DBNAME-G1-";
                //  Console.WriteLine($"{amount}");
           //     Console.WriteLine();
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(4, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                //intQuest.RemoveAt(IQ);
                MyHash += $"{IQ}-{k}-";
                //intQuest.RemoveAt(IQ);
                AQQQQ = AQ.text;
             //   Console.WriteLine($"{AQ.text}");
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }
            return questions;
        }



        /// <summary>
        /// Function that generate and print enum questions with probability
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static Question[] GenerateEnum(MyDataWithProbability[] mas, int ogr, int amount)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<string> ans = new List<string>();
            Question[] questions = new Question[amount];
            int IndAnswer = 0;
            int l = 0;
            string AQQQQ = null;
            string MyHash = "DBNAME-G1-";
            String ANSW1 = "Все перечисленное.";
            String ANSW2 = "Ничего из перечисленного";

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
                ans.Clear();
                int i = a[rand.Next(a.Count)];
                ans.Add(mas[i].text);
                //Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                MyHash += $"{i}-";
                // Console.WriteLine($"1){mas[a[rand.Next(a.Count)]].text}");
                List<int> appearedAnswers = new List<int>();
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
                            k++;
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
                          //  Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(b[IA]);
                            ans.Add(AA.text);
                            MyHash += $"{b[IA]}-";
                        }
                        else k++;
                    }
                    else
                    {
                     //   Console.WriteLine($"T){AA.text}");
                        ca++;
                        appearedAnswers.Add(b[IA]);
                        ans.Add(AA.text);
                        MyHash += $"{b[IA]}-";
                    }
                    b.RemoveAt(IA);
                }
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                int kk = k;
                List<String> ans2 = new List<String>();
                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                    GenerateQuest1(a, b, k);
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    //   Console.WriteLine($"T)Все перечисленное");
                    //   Console.WriteLine($"T)Ничего из перечисленного");
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), k - 1, MyHash + "0");
                    l++;
                }
                else if (allOrNo == 1)//если все являются
                {
                    List<int> appearedAnswers = new List<int>();
                    int ca = 0;
                    while (k-- > 0)
                    {
                        if (a.Count == 0)
                        {
                            if (ca < 2)//для того, чтобы было минимум 2 варианта ответа
                            {
                                a = intTrueAns.Slice(0, intTrueAns.Count);
                                appearedAnswers.ForEach(delegate (int index)
                                {
                                    a.Remove(index);
                                });
                                k++;
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
                                ans2.Add(AA.text);
                                MyHash += $"{a[IA]}-";
                      //          Console.WriteLine($"T){AA.text}");
                                ca++;
                                appearedAnswers.Add(a[IA]);
                            }
                            else k++;
                        }
                        else
                        {
                            ans2.Add(AA.text);
                            MyHash += $"{a[IA]}-";
                      //      Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(a[IA]);
                        }
                        a.RemoveAt(IA);

                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    //    Console.WriteLine($"1)Все перечисленное");
                    //    Console.WriteLine($"T)Ничего из перечисленного");
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk-2, MyHash + "0");
                    l++;
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
                                k++;
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
                           //     Console.WriteLine($"T){AA.text}");
                                ca++;
                                appearedAnswers.Add(b[IA]);
                                ans2.Add(AA.text);
                                MyHash += $"{b[IA]}-";
                            }
                            else k++;
                        }
                        else
                        {
                     //       Console.WriteLine($"T){AA.text}");
                            ca++;
                            appearedAnswers.Add(b[IA]);
                            ans2.Add(AA.text);
                            MyHash += $"{b[IA]}-";
                        }
                        b.RemoveAt(IA);
                       

                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    //    Console.WriteLine($"T)Все перечисленное");
                    //    Console.WriteLine($"1)Ничего из перечисленного");
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk-1, MyHash + "0");
                    l++;
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                //  Console.WriteLine($"{amount}");
             //   Console.WriteLine();
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(2, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                //intQuest.RemoveAt(IQ);
                AQQQQ = AQ.text;
                //   Console.WriteLine($"{AQ.text}");
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }
            return questions;
        }
    }
}
