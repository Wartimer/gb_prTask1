using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace gb_prTasks5
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Task 1
            //1.Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
            //а) без использования регулярных выражений;
            //б) **с использованием регулярных выражений.
            //CheckLP();
            //CheckLonginRegEx();
            #endregion

            #region Task 2
            //2.Разработать статический класс Message, 
            //  содержащий следующие статические методы для обработки текста:
            //а) Вывести только те слова сообщения, которые содержат не более n букв.
            //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            //в) Найти самое длинное слово сообщения.
            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            //д) ***Создать метод, который производит частотный анализ текста.
            //В качестве параметра в него передается массив слов и текст, 
            //в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
            //Здесь требуется использовать класс Dictionary.

            string text = "Соотношение терминов «рассказ» и «новелла» не получило однозначной трактовки в российском, а ранее советском литературоведении. Большинству языков различие между этими понятиями вообще неизвестно. Б. В. Томашевский называет рассказ специфически русским синонимом международного термина «новелла». Другой представитель школы формализма, Б. М. Эйхенбаум, предлагал разводить эти понятия на том основании, что новелла сюжетна, а рассказ — более психологичен и рефлексивен, ближе к бессюжетному очерку. На остросюжетность новеллы указывал ещё Гёте, считавший её предметом «свершившееся неслыханное событие»[12]. При таком толковании новелла и очерк — две противоположные ипостаси рассказа.";

            Console.WriteLine("Printing Words");
            Message.PrintWords(5, text);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Delete words with specified char at the end");
            Console.WriteLine(Message.DeleteWordsWithEnding('и', text));
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("The longest word");
            Console.WriteLine(Message.FindTheLongestWord(text));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Generating string using string builder");
            Console.WriteLine(Message.CreateStringFromLongestWords(text, 10));
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Dictionary of word frequency");
            string[] stringArr = { "что", "а", "рассказ", "русским", "эти", "в", "новелла" };
            foreach(KeyValuePair<string, int> keyValue in Message.FrequencyAnalisation(stringArr, text))
                Console.WriteLine("    " + keyValue.Key + "  |  " + keyValue.Value);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Task 3
            Console.WriteLine("Task №3");
            Console.WriteLine("Is one string a permutation of another");
            var str1 = "abcd";
            var str2 = "dcba";
            Console.WriteLine(Rearranged(str1, str2));
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Task 4

            PrintLowestScores();
            #endregion
        }

        #region Task 1 methods
        public static void CheckLP()
        {
            Console.WriteLine("Checking login");
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();



            if (login.Length < 2 || login.Length > 10)
            {
                Console.WriteLine("Неверная длина логина (не менее 2 и не более 10 символов");
            }

            if (Char.IsDigit(login[0]))
            {
                Console.WriteLine("Неверный формат ввода логина");
            }
            bool flag = true;
            for (int i = 0; i < login.Length; i++)
            {
                if (!(char.IsDigit(login[i]) || login[i] >= 'a' && login[i] <= 'z' || login[i] >= 'A' && login[i] <= 'Z'))
                {
                    flag = false;
                    Console.WriteLine("Введены недопустимые символы");
                    Console.ReadKey();
                    break;
                }
            }
            if (flag)
                Console.WriteLine("Логин корректен");
            Console.ReadKey();
            Console.Clear();

        }

        public static void CheckLonginRegEx()
        {
            Regex hasNumberInBegining = new Regex(@"^\d");
            Regex hasLatinAndDigits = new Regex(@"[a-zA-Z0-9]");
            var hasRightLength = new Regex(@".{2,10}");

            Console.WriteLine("Checking login with RegEX");
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();

            if(hasNumberInBegining.IsMatch(login))
                Console.WriteLine("Your login must not start with digit");
            else if(!hasRightLength.IsMatch(login))
                Console.WriteLine("Your password must be >= 2 and <= 10 characters");
            else if(hasLatinAndDigits.IsMatch(login) && hasRightLength.IsMatch(login))
                Console.WriteLine("Your login is Correct");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Task 3 methods
        public static bool Rearranged(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            var chArr1 = str1.ToCharArray();
            Array.Sort(chArr1);
            var chArr2 = str2.ToCharArray();
            Array.Sort(chArr2);
            for (int i = 0; i < chArr1.Length; i++)
            {
                if (chArr1[i] != chArr2[i])
                    return false;
            }

            return true;
        }


        #endregion

        #region Task 4 methods
        //  Требуется написать как можно более эффективную программу, 
        //  которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
        //  Если среди остальных есть ученики, набравшие тот же средний балл, 
        //  что и один из трёх худших, следует вывести и их фамилии и имена.

        public static void PrintLowestScores()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExamResults.txt";
            var exp1 = new Regex(@"^[а-яА-Я]{2,20}\s{1}[а-яА-Я]{2,15}\s{1}");
            var exp2 = new Regex(@"(\d\s{1}\d\s{1}\d)$");

            Dictionary<string, double> lowestAvgScores = new Dictionary<string, double>();
            

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {    
                    var str = reader.ReadLine();
                    int amofstds;
                    int.TryParse(str, out amofstds);
                    if (amofstds < 10 || amofstds > 100)
                    {
                        Console.WriteLine("The list of students must be from 10 to 100");
                    }
                    else
                    {
                        while (!reader.EndOfStream)
                        {
                            str = reader.ReadLine();

                            if (exp1.IsMatch(str) && exp2.IsMatch(str))
                            {
                                lowestAvgScores.Add(exp1.Match(str).ToString(), Average(exp2.Match(str).ToString()));

                            }
                            else
                                Console.WriteLine("No Match. Write the correct name or scores");

                        } 
                    }
                }
            }

            Print(lowestAvgScores);

        }

        public static double Average(string str)
        {
            string[] arr = str.Split(' ');
            int sum = 0;
            foreach(var s in arr)
            {
                sum += int.Parse(s);
                
            }

            return (sum / 3.0);
        }

        public static void Print(Dictionary<string, double> lowestAvgScores)
        {
            var sortedDict1 = from x in lowestAvgScores orderby x.Value ascending select x;

            double minScore = 5;

            foreach (var key in lowestAvgScores)
            {
                if (minScore > key.Value)
                    minScore = key.Value;
            }

            int count = 0;
            foreach(var key in sortedDict1)
            {
                if (key.Value == minScore) count++;
            }

            var stdsWLS = (from x in lowestAvgScores
                              orderby x.Value 
                              ascending select x).Take(count);


            Console.WriteLine("Scores of all students");
            foreach (KeyValuePair<string, double> keyValue in sortedDict1)
            {
                Console.WriteLine($"{keyValue.Key} : {keyValue.Value:F2}");
            }
            Console.WriteLine();


            Console.WriteLine("Students with lowest Exam Score");

            foreach (var keyValue in stdsWLS)
            {
                Console.WriteLine($"{keyValue.Key} : {keyValue.Value:F2}");
            }
            
        }
        #endregion
    }
}
