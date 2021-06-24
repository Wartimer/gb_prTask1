using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTasks5
{
    public static class Message
    {
        public static void PrintWords(int wLength, string text)
        {
            foreach(var substr in text.Split(' '))
            {
                if(substr.Length <= wLength)
                    Console.WriteLine(substr);
            }
        }

        public static string DeleteWordsWithEnding(char symbol, string text)
        {
            var newStr = "";
            string[] arr = text.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {               
                if (Convert.ToChar(arr[i][arr[i].Length -1]) != symbol)
                {
                    newStr += arr[i].ToString() + " ";                       
                }
            }

            return newStr;
        }

        public static string FindTheLongestWord(string text)
        {
            var word = "";
            int longestW = 0;
            char[] separators = { '.',' ',',' };
            string[] arr = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach(var str in arr)
            {
                if(str.Length > longestW)
                {
                    longestW = str.Length;
                    word = str;
                }
            }
            return word;
        }

        public static string CreateStringFromLongestWords(string text, int wordLength)
        {
            StringBuilder stringbuilder = new StringBuilder();
            char[] separators = { '.', ' ', ',' };
            string[] arr = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in arr)
            {
                if (str.Length >= wordLength)
                {
                    stringbuilder.Append(" " + str);
                }
            }

            return stringbuilder.ToString();
        }

        public static Dictionary<string, int> FrequencyAnalisation(string[] arr, string text)
        {
            char[] separators = { '.', ' ', ','};
            string[] arrFromText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] fr = new int[arrFromText.Length];

            var wordFreqs = new Dictionary<string, int>();

            int visited = -1;

            for (int i = 0; i < arr.Length; i++)
            {

                for (int j = 0; j < arrFromText.Length; j++)
                {
                    int count = 1;
                    for (int k = 0; k < arrFromText.Length; k++)
                    {
                        if (arr[i] == arrFromText[k])
                        {
                            count++;

                            //To avoid counting same element again  
                            fr[k] = visited;
                        }
                    }
                        if (fr[j] != visited)
                            fr[j] = count;
                if (!wordFreqs.ContainsKey(arr[i]))
                    wordFreqs.Add(arr[i], fr[i]);

                }

            }

            return wordFreqs;
        }
    }
}
