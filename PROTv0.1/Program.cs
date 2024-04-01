﻿using PROTv0._1;


var mas = new MyData[]{

    new("элементами дороги",0,true),
    new("Какие из перечисленных элементов являются элементами дороги?",1,true),
    new("Какие из перечисленных элементов(при их наличии) являются элементами дороги?",1,true),
    new("Что является элементом дороги?",1,true),
    new("Что входит в элементы дороги?",1,true),
    new("Какие из перечисленных элементов не являются элементами дороги?",1,false),
    new("Какие из перечисленных элементов(при их наличии) не являются элементами дороги?",1,false),
    new("Что не является элементом дороги?",1,false),
    new("Что не входит в элементы дороги?",1,false),
    new("Разделительные полосы",2,true),
    new("Разделительные зоны",2,true),
    new("Трамвайные пути",2,true),
    new("Островки безопасности",2,true),
    new("Островки, выделенные только разметкой",2,false),
    new("Проезжие части",2,true),
    new("Тротуары",2,true),
    new("Обочины",2,true),
    new("Пешеходные дорожки",2,true),
    new("Велосипедные дорожки",2,true),
    new("Обособленные велосипедные дорожки",2,false),
    new("Пешеходные переходы",2,false),
    new("Велосипедные переезды",2,false),
    new("Перекрестки",2,false),
    new("Кюветы", 2, false),
    new("Обрезы", 2, false),
    new("Придорожные насаждения", 2, false),
    new("Кустарник при дороге", 2, false),
    new("Дорожки для всадников", 2, false),

    };

var mas2 = new MyDataWithProbability[]{

    new("элементами дороги",0,false, 1),
    new("Какие из перечисленных элементов являются элементами дороги?",1,false, 1),
    new("Какие из перечисленных элементов(при их наличии) являются элементами дороги?",1,false, 1),
    new("Что является элементом дороги?",1,false, 1),
    new("Что входит в элементы дороги?",1,false, 1),
    new("Какие из перечисленных элементов не являются элементами дороги?",1,true, 1),
    new("Какие из перечисленных элементов(при их наличии) не являются элементами дороги?",1,true, 1),
    new("Что не является элементом дороги?",1,true, 1),
    new("Что не входит в элементы дороги?",1,true, 1),
    new("Разделительные полосы",2,true, 1),
    new("Разделительные зоны",2,true, 0.5),
    new("Трамвайные пути",2,true, 1),
    new("Островки безопасности",2,true, 0.5),
    new("Островки, выделенные только разметкой",2,false, 0.25),
    new("Проезжие части",2,true, 0.5),
    new("Тротуары",2,true, 0.5),
    new("Обочины",2,true, 1),
    new("Пешеходные дорожки",2,true, 1),
    new("Велосипедные дорожки",2,true, 0.5),
    new("Обособленные велосипедные дорожки",2,false, 0.5),
    new("Пешеходные переходы",2,false, 1),
    new("Велосипедные переезды",2,false, 0.5),
    new("Перекрестки",2,false, 1),
    new("Кюветы", 2, false, 0.5),
    new("Обрезы", 2, false, 0.25),
    new("Придорожные насаждения", 2, false, 1),
    new("Кустарник при дороге", 2, false, 1),
    new("Дорожки для всадников", 2, false, 0.5)
      //в вопросах эти вероятности наверное не нужны, но нужно было поле чем то заполнить
      //бессмысленный короткий массив данных для отладки, чтоб увидеть результат
 /*  new("В каком направлении разрешено продолжить движение в показанной ситуации?",1,true, 1),
    new("В каком направлении запрещено продолжить движение в показанной ситуации?",1,false, 1),
    new("Прямо", 2, true, 1),
    new("Направо", 2, true, 1),
    new("Налево", 2, true, 1),
    new("На разворот", 2, false, 1),
    new("В обратном направлении", 2, false, 0.5)*/
    };
Random n = new Random();
Question[] q = Generator.GenerateEnum(mas2, 4, 5);
for (int i=0; i<q.Length; i++) q[i].print();
/*Console.WriteLine("8 вопросов, 19 ответов");
Console.WriteLine("generateLinear, по 2 варианта ответа === "+ PowerCalculator.powerLinear(8, 19, 2));
Console.WriteLine("generateLinear, по 3 варианта ответа === " + PowerCalculator.powerLinear(8, 19, 3));
Console.WriteLine("generateLinear, по 4 варианта ответа === " + PowerCalculator.powerLinear(8, 19, 4));
Console.WriteLine("generateIsIt  === " + PowerCalculator.powerIsIt(8, 19));
Console.WriteLine("generateLinear, по 4 варианта ответа === " + PowerCalculator.powerEnum(8, 19, 4));
Console.WriteLine("generateLinear, по 5 варианта ответа === " + PowerCalculator.powerEnum(8, 19, 5));
Console.WriteLine("generateLinear, по 6 варианта ответа === " + PowerCalculator.powerEnum(8, 19, 6));
Console.WriteLine("generateGroup, по 2 варианта ответа === " + PowerCalculator.powerGroup(8, 19, 2));
Console.WriteLine("generateGroup, по 3 варианта ответа === " + PowerCalculator.powerGroup(8, 19, 3));
Console.WriteLine("generateGroup, по 4 варианта ответа === " + PowerCalculator.powerGroup(8,19,4));
Console.WriteLine("generateGroup, по 5 варианта ответа === " + PowerCalculator.powerGroup(8, 19, 5));*/

