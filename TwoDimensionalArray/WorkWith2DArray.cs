using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwoDimensionalArray
{

    public class My2DArray
    {
     /*
        а) - Реализовать библиотеку с классом для работы с двумерным массивом. *
           - Реализовать конструктор, заполняющий массив случайными числами. *
           - Создать методы, которые возвращают сумму всех элементов массива. *
           - Сумму всех элементов массива больше заданного. *
           - Свойство, возвращающее минимальный элемент массива. *
           - Свойство, возвращающее максимальный элемент массива. *
           - Метод, возвращающий номер максимального элемента массива(через 
             параметры, используя модификатор ref или out). *
        б) - Добавить конструктор и методы, которые загружают данные
             из файла и записывают данные в файл.
        в) - Обработать возможные исключительные ситуации при работе с файлами.
     */
        private int[,] ww2dArray;
        private int row;
        private int col;

        public int Min
        {
            get
            {
                int min = ww2dArray[0, 0];
                for (int i = 0; i < ww2dArray.GetLength(0); i++)
                {
                    for (int j = 0; j < ww2dArray.GetLength(1); j++)
                    {
                        if (ww2dArray[i, j] < min) min = ww2dArray[i, j];
                    }
                }
                return min;
            }

        }

        public int Max
        {
            get
            {
                int max = ww2dArray[0, 0];
                for (int i = 0; i < ww2dArray.GetLength(0); i++)
                {
                    for (int j = 0; j < ww2dArray.GetLength(1); j++)
                    {
                        if (ww2dArray[i, j] > max) max = ww2dArray[i, j];
                    }
                }
                return max;
            }

        }

        public My2DArray(int row, int col)
        {
            this.row = row;
            this.col = col;

            Random rnd = new Random();
            ww2dArray = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    ww2dArray[i,j] = rnd.Next(-10000, 10000);
                }
            }
        }

        public My2DArray(string fileName)
        {
            int rows = 0;
            int cols = 0;
            char[] charSeparators = new char[] { ' ' };
            

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        var str = (reader.ReadLine());
                        cols = str.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToArray().Length;
                        rows++;
                    }

                }

                ww2dArray = new int[rows, cols];

                using (var reader = new StreamReader(fileName))
                {

                    while (!reader.EndOfStream)
                    {
                        for (int i = 0; i < ww2dArray.GetLength(0); i++)
                        {
                            var str = reader.ReadLine();
                            string[] transitionArr = str.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                for (int j = 0; j < ww2dArray.GetLength(1); j++)
                                {
                                  ww2dArray[i, j] = Convert.ToInt32(transitionArr[j]);
                                }
                        }
                    }
                }
            }

            else
            {
                throw new FileNotFoundException($"{fileName}");
            }

        }

        public void PrintArray()
        {
            for (int i = 0; i < ww2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < ww2dArray.GetLength(1); j++)
                {
                    Console.Write($"{ww2dArray[i,j]}   ");
                }
                Console.WriteLine();
            }
        }

        public int SumOfArrayElements()
        {
            int sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    sum += ww2dArray[i, j];
                }
            }
            return sum;
        }

        public int SumOfArrayElementsMoreThen(int startRow, int startCol)
        {
            int sum = 0;
            for (int i = startRow; i < row; i++)
            {
                for (int j = startCol; j < col; j++)
                {
                    sum += ww2dArray[i, j];
                }
            }
            return sum;
        }

        public string IndexOfMax(ref int[,] arr, out string indexOfMax)
        {
            indexOfMax = "";
            
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (ww2dArray[i, j] > max)
                    {
                            max = ww2dArray[i, j];
                            indexOfMax = i + "-" + j;            
                    }
                }
            }
            return indexOfMax;
        }

        public void WriteArrayToFile(string fileName)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "FilesFromArray";

            bool dirExists = Directory.Exists(filePath);

            if (!dirExists)
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "FilesFromArray"));
            }

            using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, "DataFromArray.txt")))
            {
                for (int i = 0; i < ww2dArray.GetLength(0); i++)
                {
                    for (int j = 0; j < ww2dArray.GetLength(1); j++)
                    {
                        writer.Write(ww2dArray[i, j] + " ");
                    }
                        writer.Write("\n");
                }
            }
        }

    }

}
