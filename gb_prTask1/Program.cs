using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTask1
{
    class Program
    {
        //Переменные для задачи №1
        public static string name, surname, city = "";
        public static int age, height, weight;

        //Переменные для задание №3
        static double x1 = 1.2,
                      x2 = -6.0,
                      y1 = 3.4,
                      y2 = 4.2;

        static void Main(string[] args)
        {
            #region Рыжков Д.И. Задание №1
            //1. Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). 
            //В результате вся информация выводится в одну строчку:
            //а) используя склеивание;
            //б) используя форматированный вывод;
            //в) используя вывод со знаком $.

            GetPersonInfo();
            Console.WriteLine($"Ваше имя: {name}\n" +
                              $"Ваша фамилия: {surname}\n" +
                              $"Ваш возраст: {age}\n" +
                              $"Ваш рост: {height}\n" +
                              $"Ваш вес: {weight} \n");

            Console.WriteLine("Форматированный вывод: \n");
            Console.WriteLine("Ваше имя: {0}\n" +
                              "Ваша фамилия: {1}\n" +
                              "Ваш возраст: {2}\n" +
                              "Ваш рост: {3}\n" +
                              "Ваш вес: {4}", name, surname, age, height, weight);
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Рыжков Д.И. Задание №2
            //Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) 
            //по формуле I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах.
            Console.WriteLine("Индекс Массы Тела: " + CountBMI(weight, height).ToString());
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Рыжков Д.И. Задание №3
            //а) Написать программу, которая подсчитывает расстояние между точками 
            //с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            //Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            Console.WriteLine("Рассчет расстояния между точками");
            Console.WriteLine("Рассточние между координатами: {0:f2}", CountDistance(x1, x2, y1, y2));
            Console.Clear();
            #endregion

            #region Рыжков Д.И. Задание №4
            //Рыжков Д.И. Задание №4
            //Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
            //а) с использованием третьей переменной;
            //б) *без использования третьей переменной.
            //Переменные для задания №4
            int a, b;
            Console.WriteLine("Введите значение переменной a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение переменной b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Значения переменных до обмена значениями:");
            Console.WriteLine("a = {0}\n" +
                              "b = {1}\n", a, b);
            int temp;
            temp = b;
            b = a;
            a = temp;

            Console.WriteLine("Результат обмена значениями с использованием 3-й переменной:");
            Console.WriteLine("a = {0}\n" +
                              "b = {1}\n", a, b);

            //Обмен значениями без использования 3-й переменной
            Console.WriteLine("Введите значение переменной a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение переменной b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Значения переменных до обмена значениями:");
            Console.WriteLine("a = {0}\n" +
                              "b = {1}\n", a, b);
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;

            Console.WriteLine("Результат обмена значениями без использования 3-й переменной:");
            Console.WriteLine("a = {0}\n" +
                              "b = {1}\n", a, b);

            Console.ReadLine();
            Console.Clear();

            #endregion

            #region Рыжков Д.И. Задание №5
            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) Сделать задание, только вывод организовать в центре экрана.
            //в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).

            string text = "";
            text = GetPersonInfo2();
            int centerX = (Console.WindowWidth / 2) - (text.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.WriteLine(text);
            Console.ReadLine();
            Console.Clear();

            // Печать с использованием  собственного метода.
            string text2 = "";
            text2 = GetPersonInfo2();
            MyUtilityMethods.Print(text2, centerX, centerY);
            Console.ReadLine();
            Console.Clear();

            #endregion

        }



        public static void GetPersonInfo()
        {
            Console.WriteLine("Напишите свое имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Напишите свою фамилию: ");
            surname = Console.ReadLine();
            Console.WriteLine("Напишите свой возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Напишите свой рост: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Напишите свой вес: ");
            weight = Convert.ToInt32(Console.ReadLine());
        }

        public static string GetPersonInfo2()
        {
            Console.WriteLine("Введите свое имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите свою фамилию: ");
            surname = Console.ReadLine();
            Console.WriteLine("Введите ваш город проживания: ");
            city = Console.ReadLine();
            var str = name + " " + surname + " " + city;

            return str;
        }




        public static double CountBMI(int weight, int height)
        {
            return weight / (Math.Pow(height, 2));
        }


        public static double CountDistance(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }


    }

    public class MyUtilityMethods
    {

        public static void Print(string text, int centerX, int centerY)
        {
            int centX = centerX;
            int centY = centerY;
            Console.SetCursorPosition(centX, centY);
            Console.WriteLine(text);
        }

    }
}
