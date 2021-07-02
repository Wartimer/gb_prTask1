using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gb_prTasks6
{
    public class Task2
    {
        double x, a, b, h;
        double min = double.MaxValue;
        string fileName;
        public delegate double Fun2(double x);

        public double Min { get { return min; } }

        public Task2(string filename, double a, double b, double h)
        {
            this.fileName = filename;
            this.a = a;
            this.b = b;
            this.h = h;
        }


        public void Task2Launch()
        {
            var mdl = new List<Fun2> { new Fun2(F1), new Fun2(F2), new Fun2(F3)};
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

            Console.WriteLine("Please choose function you want to use:");
            Console.WriteLine("0. Sin(x)\n1. x^3\n2. x^2");

            var input = int.Parse(Console.ReadLine());
            if(input <= mdl.Count && input >= 0)
                SaveFunc(filePath, mdl[input]);
            else
                Console.WriteLine("Please enter valid menu number");

        }


        private double F1(double x)
        {
            return Math.Sin(x);
        }

        private double F2(double x)
        {
            return x * x * x;
        }

        private double F3(double x)
        {
            return x * x;
        }


        public void SaveFunc(string filePath, Fun2 F)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }

            bw.Close();
            fs.Close();
        }


        public double[] Load(string filePath, out double[] allArr)
        {
            double[] arr2 = new double[0];
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                Array.Resize(ref arr2, arr2.Length + 1);
                arr2[i] = d;
                if (d < min) min = d;
            }

            bw.Close();
            fs.Close();
            allArr = arr2;
            return allArr;
        }

    }
}
