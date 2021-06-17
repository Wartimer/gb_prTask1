using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTask3
{
     //  3. * Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.

     //Добавить свойства типа int для доступа к числителю и знаменателю;
     //Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
     //Добавить проверку, чтобы знаменатель не равнялся 0. 
     //Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
     //Добавить упрощение дробей.

    class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("The Denominator can't be zero");
                else
                    denominator = value;
            }
        }

        public double DecimalFraction { get { return (double)(this.numerator) / (double)(this.denominator); } }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("The Denominator can't be zero");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(int number) : this(number, 1) { }

        public Fraction Addition(Fraction x)
        {
            if (this.denominator == x.denominator)
                return new Fraction(this.numerator + x.numerator, this.denominator);
            else
            {
                // Наименьшее общее кратное знаменателей
                int leastCommonMultiple = GetLeastCommonMultiple(this.denominator, x.denominator);
                // Дополнительный множитель к первой дроби
                int additionalMultiplierFirst = leastCommonMultiple / this.denominator;
                // Дополнительный множитель ко второй дроби
                int additionalMultiplierSecond = leastCommonMultiple / x.denominator;

                int operationResult = (this.numerator * additionalMultiplierFirst) + (x.numerator * additionalMultiplierSecond);

                return new Fraction(operationResult, this.denominator * additionalMultiplierFirst);
            }
                
        }

        public Fraction Subtraction(Fraction x)
        {
            if (this.denominator == x.denominator)
                return new Fraction(this.numerator - x.numerator, this.denominator);
            else
            {
                // Наименьшее общее кратное знаменателей
                int leastCommonMultiple = GetLeastCommonMultiple(this.denominator, x.denominator);
                // Дополнительный множитель к первой дроби
                int additionalMultiplierFirst = leastCommonMultiple / this.denominator;
                // Дополнительный множитель ко второй дроби
                int additionalMultiplierSecond = leastCommonMultiple / x.denominator;

                int operationResult = (this.numerator * additionalMultiplierFirst) - (x.numerator * additionalMultiplierSecond);

                return new Fraction(operationResult, this.denominator * additionalMultiplierFirst);
            }
        }

        public Fraction Multiplication(Fraction x)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("The Denominator can't be zero");
            }

            return new Fraction(this.numerator * x.numerator, this.denominator * x.denominator);
        }

        public Fraction Division(Fraction x)
        { 
            return new Fraction(this.numerator * x.GetReverse().numerator, this.denominator * x.GetReverse().denominator);
        }

        private static int GetLeastCommonMultiple(int a, int b)
        {
            return a * b / GetGreatestCommonDivisor(a, b);
        }

        private static int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private Fraction GetReverse()
        {
            return new Fraction(this.denominator, this.numerator);
        }

        public Fraction Reduce()
        {
            Fraction result = this;
            int greatestCommonDivisor = GetGreatestCommonDivisor(this.numerator, this.denominator);
            result.numerator /= greatestCommonDivisor;
            result.denominator /= greatestCommonDivisor;
            return result;
        }


        public override string ToString()
        {
            if(this.numerator == 0)
            {
                return "0";
            }

            string result = "";
            if (this.numerator == this.denominator)
                return result + 1;
            if(this.denominator == 1)
            {
                return result + this.numerator;
            }

            return result + this.numerator + "/" + this.denominator;
        }
    }
}
