using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace gb_prTasks6
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int age;
        public int group;
        public string city;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    class Program
    {

        //ПОДСКАЗКА ДЛЯ ВЫПОЛНЕНИЯ ДЗ 6:

        //Задание 1: Начальная программа находится на стр. 2 методички.
        //Задание 2: Задача находится на стр. 20 методички.
        //Задание 3: Задача находится на стр. 16 методички, там же описан формат файла.
        //Я прикреплю тестовый файл к материалам урока.

        #region Task 1 dels and methods
        public delegate double Fun(double x, double a);

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double b)
        {
            return a * (b * b);
        }

        public static double MyFunc2(double a, double b)
        {
            return a * Math.Sin(b);
        }

        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        #endregion

        #region Task3 methods

        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }

        static int MyDelegat2(Student st1, Student st2)
        {
            return st1.age.CompareTo(st2.age);
        }

        static int MyDelegat3(Student st1, Student st2)
        {
            return (st1.age - st1.course).CompareTo(st2.age - st2.course);
        }

        #endregion

        static void Main(string[] args)
        {
            #region Task 1
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);

            Console.WriteLine("Таблица функции а*х^2: ");
            Table(MyFunc, -2, 2);

            Console.WriteLine("Таблица функции а*sin(x): ");
            Table(MyFunc2, -2, 2);

            #endregion

            #region Task2
            //2.Модифицировать программу нахождения минимума функции так, 
            //чтобы можно было передавать функцию в виде делегата.
            //а) Сделать меню с различными функциями и представить пользователю выбор, 
            //для какой функции и на каком отрезке находить минимум.
            //Использовать массив(или список) делегатов, в котором хранятся различные функции.
            //б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
            //    Пусть она возвращает минимум через параметр(с использованием модификатора out).



            #endregion

            #region Task 2

            var task = new Task2("ResultsTask2.bin", -100, 100, 0.5);

            task.Task2Launch();

            double[] arr;

            task.Load("ResultsTask2.bin", out arr);

            Console.WriteLine($"Minimum: {task.Min}");

            foreach (var el in arr)
            {
                Console.WriteLine(el);
            }
            #endregion

            #region Task 3
            int bakalavr = 0;
            int magistr = 0;
            int stdsOfcourses = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            string fileName = "students.csv";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4],
                                            int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                    if (int.Parse(s[7]) == 5 || int.Parse(s[7]) == 6)
                        stdsOfcourses++;


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();


            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Сортировка по возрасту");
            list.Sort(new Comparison<Student>(MyDelegat2));
            foreach (var v in list) Console.WriteLine($"{v.firstName} {v.lastName} {v.age}");
            Console.WriteLine();



            Console.WriteLine("Сортировка по возрасту");
            list.Sort(new Comparison<Student>(MyDelegat2));
            var list2 = list.ToList();
            list2.Sort(new Comparison<Student>(MyDelegat3));
            foreach (var v in list) Console.WriteLine($"{v.firstName} {v.lastName} {v.age} {v.course}");
            Console.WriteLine();

            Console.WriteLine("Количество студентов на курсах");
            Console.WriteLine("       Курс        Кол-во     ");
            foreach (var keyValue in Freq(list))
            {
                Console.WriteLine($"          {keyValue.Key}   |   {keyValue.Value}");
            }
            Console.WriteLine();

            #endregion

            #region Task 4



            #endregion
        }



        #region Task 3 method
        public static Dictionary<int, int> Freq(List<Student> stList)
        {
            int visited = -1;
            int[] coursesArr = new int[0];
            var youngStdnts = new List<Student>();

            foreach(var stdnt in stList)
            {
                if (stdnt.age >= 18 && stdnt.age <= 20)
                    youngStdnts.Add(stdnt);
            }

            for (int i = 0; i < youngStdnts.Count; i++)
            {
                Array.Resize(ref coursesArr, coursesArr.Length + 1);
                coursesArr[i] = youngStdnts[i].course;
            }

            int[] fr = new int[coursesArr.Length];
            var courseStdnts = new Dictionary<int, int>();

            for (int i = 0; i < coursesArr.Length; i++)
            {
                    int count = 1;

                    for (int j = i + 1; j < coursesArr.Length; j++)
                    {
                        if (coursesArr[i] == coursesArr[j])
                        {                         
                                count++;

                                fr[j] = visited;
                        }

                    }
                    if (fr[i] != visited)
                        fr[i] = count;
                    if (!courseStdnts.ContainsKey(coursesArr[i]))
                        courseStdnts.Add(coursesArr[i], fr[i]);
            }

            return courseStdnts;
        }
        #endregion

        #region Task 4 methods
        //Это не успел доделать. Могу чуть позже как доделаю скинуть. Плюс чат почему то не работал весь день.
        // возникло несколько вопросов по 4-му заданию. Откуда брать файлы для считывания. И мы это вроде бы так досконально не проходили на курсе. Это отдельно надо самому изучать.
        #endregion
    }


}


