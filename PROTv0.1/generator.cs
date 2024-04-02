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
        public static Question[] GenerateTicket(MyData[] mas, int questAmount)
        {
            Question[] questions1 = new Question[questAmount];
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
                        questions1[i] = GenerateLinear(mas, 5, 1, true)[0];
                        questions[0]++;
                        break;
                    case 1:
                        questions1[i] = GenerateLinear(mas, 5, 1, false)[0];
                        questions[1]++;
                        break;
                    case 2:
                        questions1[i] = GenerateEnum(mas, 5, 1)[0];
                        questions[2]++;
                        break;
                    case 3:
                        questions1[i] = GenerateIsIt(mas, 1)[0];
                        questions[3]++;
                        break;

                    case 4:
                        questions1[i] = GenerateGroup(mas, 5, 1)[0];
                        questions[4]++;
                        break;
                }

            }
            return questions1;
        }


    }
}
