using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTask3
{
    class Program
    {
        struct Complex
        {
            public double re;
            public double im;

            public Complex ComplexSubtract(Complex x)
            {
                Complex y;
                y.re = this.re - x.re;
                y.im = this.im - x.im;

                return y;
            }

            public override string ToString()
            {
                return $"{re} + {im}";
            }

        }

        class MyComplex
        {
            private double re;
            private double im;

            public double Re { get { return re; } set { re = value; } }
            public double Im { get { return im; } set { im = value; } }

            public MyComplex() { }

            public MyComplex(double re, double im)
            {
                if (im == 0)
                    throw new Exception("Недопустимое число.");
                this.re = re;
                this.im = im;
            }

            public MyComplex Plus(MyComplex x)
            {
                return new MyComplex(Re + x.Re, Im + x.Im);
            }

            public MyComplex Subtract(MyComplex x)
            {
                return new MyComplex(Re - x.Re, Im - x.Im);
            }

            public override string ToString()
            {
                return $"{re} + {im}i";
            }
        }

        static void Main(string[] args)
        {
            //Задача 1.

            Complex complex01;
            complex01.re = 10.4;
            complex01.im = 5.2;

            Complex complex02;
            complex02.re = 12.9;
            complex02.im = 24.1;

            complex01.ComplexSubtract(complex02);

            Console.WriteLine("Вычитаем одно комплексное число из другого: ");
            Console.WriteLine(complex01.ComplexSubtract(complex02).ToString());

            Console.ReadKey();
            Console.Clear();


            MyComplex myComplex01 = new MyComplex();
            MyComplex myComplex02 = new MyComplex();


            Console.WriteLine("Введите действительную часть комлексного числа myComplex01: ");
            myComplex01.Re = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите мнимую часть комплексного числа myComplex01: ");
            myComplex01.Im = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите действительную часть комлексного числа myComplex02: ");
            myComplex02.Re = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите мнимую часть комплексного числа myComplex02: ");
            myComplex02.Im = Convert.ToDouble(Console.ReadLine());

            string str = "";
            Console.WriteLine("Какую операцию вы хотите совершить с данными числами?");
            Console.WriteLine("Чтобы сложить числа введите +");
            Console.WriteLine("Чтобы получить разницу чисел -");

            str = Console.ReadLine().ToString();

            switch (str)
            {
                case "+":
                    Console.WriteLine("Сумма комплексных чисел: ");
                    Console.WriteLine(myComplex01.Plus(myComplex02).ToString());
                    break;
                case "-":
                    Console.WriteLine("Разница комплексных чисел: ");
                    Console.WriteLine(myComplex01.Subtract(myComplex02).ToString());
                    break;
                default:
                    Console.WriteLine("Операция не выбрана");
                    break;
            }

            //Задача 2.

            CountAllOddNumbers();
            Console.ReadKey();
            Console.Clear();


            //Задача 3.
            Fraction a = new Fraction(6, 7);
            Fraction b = new Fraction(4, 7);

            Console.WriteLine(a.Addition(b).Reduce().ToString());
            Console.WriteLine(a.Subtraction(b).Reduce().ToString());
            Console.WriteLine(a.Multiplication(b).ToString());
            Console.WriteLine(a.Division(b).Reduce().ToString());
            Console.WriteLine($"Вывод десятичного вида дроби 'a': {a.DecimalFraction:F2}");
            Console.WriteLine($"Вывод десятичного вида дроби 'b': {b.DecimalFraction:F2}");

            Console.ReadKey();
        }

        public static void CountAllOddNumbers()
        {
            var str = "";
            int number;
            int summ = 0;
            Console.WriteLine("Summ all Odd positive numbers");
            do
            {
                Console.WriteLine("Enter the number: ");
                str = Console.ReadLine();
                bool success = int.TryParse(str, out number);

                    if (success)
                    {
                        if (number % 2 != 0 && number > 0)
                            summ += number;
                    }
                    else
                        Console.WriteLine("This is not a number!");

            } while (number != 0);

            Console.WriteLine($"Sum of Odd positive numbers is: {summ}");

        }
    }
}
