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

  /*  new("элементами дороги",0,false,false, 1),
    new("Какие из перечисленных элементов являются элементами дороги?",1,false,false, 1),
    new("Какие из перечисленных элементов(при их наличии) являются элементами дороги?",1,false,false, 1),
    new("Что является элементом дороги?",1,false,false, 1),
    new("Что входит в элементы дороги?",1,false,false, 1),
    new("Какие из перечисленных элементов не являются элементами дороги?",1,true,false, 1),
    new("Какие из перечисленных элементов(при их наличии) не являются элементами дороги?",1,true,false, 1),
    new("Что не является элементом дороги?",1,true,false, 1),
    new("Что не входит в элементы дороги?",1,true,false, 1),
    new("Разделительные полосы",2,false,true, 1),
    new("Разделительные зоны",2,false,true, 0.5),
    new("Трамвайные пути",2,false,true, 1),
    new("Островки безопасности",2,false,true, 0.5),
    new("Островки, выделенные только разметкой",2,false,false, 0.25),
    new("Проезжие части",2,false,true, 0.5),
    new("Тротуары",2,false,true, 0.5),
    new("Обочины",2,false,true, 1),
    new("Пешеходные дорожки",2,false,true, 1),
    new("Велосипедные дорожки",2,false,true, 0.5),
    new("Обособленные велосипедные дорожки",2,false,false, 0.5),
    new("Пешеходные переходы",2,false,false, 1),
    new("Велосипедные переезды",2,false,false, 0.5),
    new("Перекрестки",2,false,false, 1),
    new("Кюветы", 2, false, false, 0.5),
    new("Обрезы", 2, false, false, 0.25),
    new("Придорожные насаждения", 2, false, false, 1),
    new("Кустарник при дороге", 2, false, false, 1),
    new("Дорожки для всадников", 2, false, false, 0.5)*/
      //в вопросах эти вероятности наверное не нужны, но нужно было поле чем то заполнить
      //бессмысленный короткий массив данных для отладки, чтоб увидеть результат
   new("В каком направлении разрешено продолжить движение в показанной ситуации?",1,true, 1),
    new("В каком направлении запрещено продолжить движение в показанной ситуации?",1,false, 1),
    new("Прямо", 2, true, 1),
    new("Направо", 2, true, 1),
    new("Налево", 2, true, 1),
    new("На разворот", 2, false, 1),
    new("В обратном направлении", 2, false, 0.5)
    };

MyDataWithProbability[] mymas =
{
    new("Что из перечисленного верно? var1",1,true,0),
    new("Что из перечисленного верно? var2",1,true,0),
    new("Что из перечисленного верно? var3",1,true,0),
    new("Что из перечисленного верно? var4",1,true,0),
    new("Что из перечисленного верно? var5",1,true,0),


    new("10 = ",2,true,10),
    new("15 = ",2,true,15),
    new("20 = ",2,true,20),
    new("1.2 = ",2,true,1.2),
    new("1.5 = ",2,true,1.5),
    new("150 = ",2,true,150),
    new("0.5 = ",2,true,0.5),
    new("3.2 = ",2,true,3.2),
    new("300 = ",2,true,300),
    new("30 = ",2,true,30)
};
Random n = new Random();
Generator.GenerateGroup(mas2, 5, 10);
//Generator.GenerateEnum(mas2, 5, 10);
Question q = new Question("sd", null, 1, "sdas");




