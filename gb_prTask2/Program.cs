using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gb_prTask2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Задача 1.
            int a = 5, b = 2, c = 1;
            Console.WriteLine($"Numbers input: {a}, {b}, {c}");
            Console.WriteLine(ReturnMin(a, b, c));
            CnslClear();

            //Задача 2.
            //Пока программа без дефенсив программинга, мы верим в то что пользователь
            // все вводит правильно.
            Console.WriteLine();
            Console.WriteLine("Введите число");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Количество цифр в вашем числе: " + CountNumberOfDigits(number));
            CnslClear();

            //Задача 3.
            CountAllOddNumbers();
            CnslClear();

            //Задача 4.
            var count = 0;
            string login;
            string password;
            do
            {
                Console.WriteLine("Enter login: ");
                login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();

                if (!Login(login, password) && count < 3)
                {
                    Console.WriteLine("Login or password are incorrect.");
                    count++;
                    Console.WriteLine($"You have {3 - count} attemts to enter left.");
                }
                else if (!Login(login, password) && count == 3)
                    Console.WriteLine("You have run out of input attempts!");
                else
                {
                    Console.WriteLine("You are welcome!");
                    break;
                }

            } while (count < 3);
            CnslClear();


            //Задача 5.
            int height = AskPersonHeight();
            int weight = AskPersonWeight();
            int idealweight = CountIdealWeight(height);
            int weightDifference = CountDifference(idealweight, weight);
            double bmi = CountBMI(weight, height);
            PrintBMIRes(bmi, weightDifference);
            CnslClear();

            //Задача 6.
            CountGoodNumbers();

            CnslClear();

            //Задача 7.
            AToB(1, 10);
            CnslClear();

            Console.WriteLine(AToBSum(6, 4));
            CnslClear();
        }      
    

        #region Задача №1
        //Рыжков Д.И.
        //1. Написать метод, возвращающий минимальное из трёх чисел.

        public static int ReturnMin(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));                      
        }
        #endregion

        #region Задача №2
        //2. Написать метод подсчета количества цифр числа.
        public static int CountNumberOfDigits(int number)
        {
                var numbers = number.ToString();
                    return numbers.Length;
        }
        #endregion

        #region Задача №3

        //3. С клавиатуры вводятся числа, пока не будет введен 0. 
        //Подсчитать сумму всех нечетных положительных чисел.

        public static void CountAllOddNumbers()
        {
            int number;
            int summ = 0;
            Console.WriteLine("Summ all Odd positive numbers");
            do
            {
                Console.WriteLine("Enter the number: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (number % 2 != 0 && number > 0)
                    summ += number;
            } while (number != 0);

            Console.WriteLine($"Sum of Odd numbers is: {summ}");

        }
        #endregion

        #region Задача №4
        //4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.

        public static bool Login(string login, string password)
        {
            var correctLogin = "root";
            var correctPass = "GeekBrains";
            if (login == correctLogin && password == correctPass)
                return true;

            return false;
        }

        #endregion

        #region Задача №5
        //5.
        //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        public static int AskPersonHeight()
        {
            int h;
            Console.WriteLine("Напишите свой рост в см: ");
            h = Convert.ToInt32(Console.ReadLine());
            return h;
        }

        public static int AskPersonWeight()
        {
            int w;
            Console.WriteLine("Напишите свой вес в кг: ");
            w = Convert.ToInt32(Console.ReadLine());
            return w;
        }

        public static double CountBMI(int weight, int height)
        {
            return weight * 10000 / (Math.Pow(height, 2));
        }

        public static int CountIdealWeight(int height)
        {
            if (height < 165)
                return height - 100;
            else if (height < 175)
                return height - 105;

            return height - 110;
        }

        public static int CountDifference(int idealWeight, int currentWeight)
        {
            if (idealWeight > currentWeight)
                return idealWeight - currentWeight;
            else if (idealWeight < currentWeight)
                return currentWeight - idealWeight;

            return 0;
        }

        public static void PrintBMIRes(double bmi, int wDifference)
        {
            Console.WriteLine("Индекс массы тела получается:{0}", bmi.ToString("n2"));
            // Далее выводы для тел мужского пола от 19 до 25 лет и женского до 24 лет
            if (bmi < 16)
            {
                Console.WriteLine("Выраженный дефицит массы тела");
                Console.WriteLine($"Вам нужно набрать {wDifference} кг");
            }
            else if (bmi <= 18.5)
            {
                Console.WriteLine("Дифицит массы тела.");
                Console.WriteLine($"Вам нужно набрать {wDifference} кг");
            }
            else if (bmi <= 25)
            {
                Console.WriteLine("Нормальная масса тела.");
            }
            else if (bmi <= 30)
            {
                Console.WriteLine("Избыточная масса тела.");
                Console.WriteLine($"Вам нужно сбросить {wDifference} кг");
            }
            else if (bmi <= 35)
            {
                Console.WriteLine("Ожирение I степени.");
                Console.WriteLine($"Вам нужно сбросить {wDifference} кг");
            }
            else if (bmi <= 40)
            {
                Console.WriteLine("Ожирение II степени.");
                Console.WriteLine($"Вам нужно сбросить {wDifference} кг");
            }
            else if (bmi > 40)
            {
                Console.WriteLine("Ожирение III степени.");
                Console.WriteLine($"Вам нужно сбросить {wDifference} кг");
            }
        }

        #endregion

        #region Задача №6

        public static void CountGoodNumbers()
        {
            int count = 0;
            DateTime startTime, endTime;
            startTime = DateTime.Now;
            for (int i = 1; i <= 1000000; i++)
            {
                if (i % SumOfI(i.ToString()) == 0)
                {
                    //Console.WriteLine($"The {i} number is good");
                    count++;
                }
            }
            endTime = DateTime.Now;
            double totalTime = ((endTime - startTime)).TotalMilliseconds;
            Console.WriteLine("Good numbers found: {0}", count);
            Console.WriteLine("Time it took to find all GoodNumbers: {0:F2} milliseconds", totalTime);
        }

        public static int SumOfI(string str)
        {
            int sum = 0;
            foreach(var ch in str)
            {
                sum += Convert.ToInt32(Char.GetNumericValue(ch)); ;
            }
            //Console.WriteLine($"The sum of digits in num {str} is: {sum}");
            return sum;
        }

        #endregion

        #region Задача №7

        public static void AToB(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine(b);
                return;
            }
            Console.WriteLine(a);
            AToB((a + 1), b);
        }

        public static int AToBSum(int a, int b)
        {
            if (a > b) throw new Exception("a can't be greater than b");
            return a == b ? b : a + AToBSum(a + 1, b);            
        }

        #endregion

        public static void CnslClear()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
