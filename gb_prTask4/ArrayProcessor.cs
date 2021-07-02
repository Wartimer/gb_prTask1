using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gb_prTask4
{
    //2. Реализуйте задачу 1 в виде статического класса StaticClass;
    //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    //б) Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
    //в)* Добавьте обработку ситуации отсутствия файла на диске.

    public static class ArrayProcessor
    {
        public static int ArrayProcessing(int[] arr)
        {
            int count = 0;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] % 3 == 0 && arr[i - 1] % 3 == 0)
                    count++;
            }
            return count;
        }
        

        public static int[] LoadArrFromFile(string fileName)
        {
            int[] arr = new int[0];
            if(File.Exists(fileName))
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        int number = int.Parse(reader.ReadLine());
                        arr[arr.Length-1] = number;
                    }
                }
            else
            {
                throw new FileNotFoundException($"{fileName}");
            }
            
            return arr;
        }
    }
}
