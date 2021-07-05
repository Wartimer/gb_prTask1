using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
/// <summary>
/// / Connected libraries.
using WorkingWithArrayLib;
using TwoDimensionalArray;
/// </summary>

namespace gb_prTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1.
            Random rnd = new Random();
            int[] myArray = new int[17];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rnd.Next(-10000, 10000);
            }

            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"{FindPairs(myArray)} elements in array which divide by 3");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Task 2.

            Console.WriteLine("Task 2.a");
            Console.WriteLine($"There are {ArrayProcessor.ArrayProcessing(myArray)} elements in array which divide by 3");

            Console.WriteLine("Task 2.b");
            int[] myArrayFromFile = ArrayProcessor.LoadArrFromFile(AppDomain.CurrentDomain.BaseDirectory + "ArrayList.txt");

            foreach (var el in myArrayFromFile)
                Console.WriteLine(el);

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Task 3.

            Console.WriteLine("Print array\n");
            WorkWithArray myArrayClass = new WorkWithArray(25, 5);
            myArrayClass.PrintArray();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Task 3.Inversed Array\n");
            var inversedArray = myArrayClass.Inverse();
            foreach (var item in inversedArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Task 3.Multiplicated Array\n");
            var multiplicatedArray = myArrayClass.Multi(7);
            foreach (var item in multiplicatedArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Sum of all elements: {myArrayClass.Sum}");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Print array again\n");
            myArrayClass.PrintArray();
            Console.ReadKey();
            Console.Clear();



            int[] myArr = { 1, 3, 1, 4, 5, 6, 15, 34, 26, 5, 9, 98, 198, 3, 6, 23, 34, 5 };

            Console.WriteLine("Return Max Count");
            ArrOperation myArr2 = new ArrOperation(myArr);
            Console.WriteLine($"{myArr2.MaxCount}");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Return frequency Lambda");
            Console.WriteLine($" Number | Frequency");
            foreach (KeyValuePair<int, int> keyValue in CountFrequencyLambda(myArr))
            {
                Console.WriteLine("    " + keyValue.Key + "  |  " + keyValue.Value);
            }
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Return frequency RawCode");
            Console.WriteLine($" Number | Frequency ");
            foreach (KeyValuePair<int, int> keyValue in CountFrequencyRaw(myArr))
            {
                Console.WriteLine("    " + keyValue.Key + "  |  " + keyValue.Value);
            }
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Task 4.
            //Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
            Account myAccnt = new Account();
            string[] loginInfo = LoadLoginInfoFromFile(AppDomain.CurrentDomain.BaseDirectory + "LoginInfo.txt");
            int count = 0;
            do
            {
                Console.WriteLine("Enter login: ");
                myAccnt.login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                myAccnt.password = Console.ReadLine();

                if (!Login(loginInfo, myAccnt) && count < 3)
                {
                    Console.WriteLine("Login or password are incorrect.");
                    count++;
                    Console.WriteLine($"You have {3 - count} attemts to enter left.");
                }
                else if (!Login(loginInfo, myAccnt) && count == 3)
                    Console.WriteLine("You have run out of input attempts!");
                else
                {
                    Console.WriteLine("You are welcome!");
                    break;
                }

            } while (count < 3);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Task 5.


            My2DArray my2DArr02 = new My2DArray(5,5);
            my2DArr02.PrintArray();
            Console.WriteLine($"Sum of all elements: {my2DArr02.SumOfArrayElements()}");

            Console.WriteLine("Input row: ");
            int sRow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input col: ");
            int sCol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Sum of all elements more then {sRow}-{sCol}: " +
                $"{my2DArr02.SumOfArrayElementsMoreThen(sRow, sCol)}");

            Console.WriteLine($"Max element of array: {my2DArr02.Max}");
            Console.WriteLine($"Min element of array: {my2DArr02.Min}");
            Console.WriteLine();

            string indexOfMax;
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 23, 10, 23 } };
            Console.WriteLine($"Index of Max element of the array: " +
                $"{my2DArr02.IndexOfMax(ref multiDimensionalArray2, out indexOfMax)}");
            Console.ReadKey();
            Console.Clear();

            My2DArray my2DArrFromFile = new My2DArray(AppDomain.CurrentDomain.BaseDirectory + "TwoDimDemoData.txt");

            my2DArrFromFile.PrintArray();

            string fileName = "DataFromArray.txt";
            my2DArrFromFile.WriteArrayToFile(fileName);
            #endregion
        }


        #region Task 1 method


        //1. Дан целочисленный массив из 20 элементов.
        //Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
        //Заполнить случайными числами. 
        //Написать программу, позволяющую найти и вывести количество пар элементов массива, 
        //в которых только одно число делится на 3. 
        //В данной задаче под парой подразумевается два подряд идущих элемента массива.
        //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.


        public static int FindPairs(int[] arr)
        {
            int count = 0;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] % 3 == 0 && arr[i - 1] % 3 == 0)
                    count++;
            }
            return count;
        }
        #endregion

        #region Task 2 method

        public static Dictionary<int, int> CountFrequencyLambda(int[] arr)
        {
            return arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }

        public static Dictionary<int, int> CountFrequencyRaw(int[] arr)
        {
            int[] fr = new int[arr.Length];
            var valuesFreq = new Dictionary<int, int>();
            
            int visited = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;

                        //To avoid counting same element again  
                        fr[j] = visited;
                    }
                }
                if (fr[i] != visited)
                    fr[i] = count;

                if(!valuesFreq.ContainsKey(arr[i]))
                    valuesFreq.Add(arr[i], fr[i]);
            }

            return valuesFreq;
        }

        #endregion

        #region Task 4 methods

        public static string[] LoadLoginInfoFromFile(string fileName)
        {
            string[] arr = new string[0];
            if (File.Exists(fileName))
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        string str = reader.ReadLine().ToString();
                        arr[arr.Length - 1] = str;
                    }
                }
            else
            {
                throw new FileNotFoundException($"{fileName}");
            }

            return arr;
        }


        public static bool Login(string[] arr, Account accnt)
        {
            return (arr[0] == accnt.login && arr[1] == accnt.password) ? true : false;
        }

        #endregion
    }
}
