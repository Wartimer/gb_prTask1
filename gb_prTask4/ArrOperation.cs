using System;


    //3.
    //а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
    //Создать свойство Sum, которое возвращает сумму элементов массива, 
    //Метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений),
    //Метод Multi, умножающий каждый элемент массива на определённое число, 
    //Свойство MaxCount, возвращающее количество максимальных элементов.
    //б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
    //в) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)

    public class ArrOperation
    {
        private int[] wwArr;
        private int maxCount;
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (var el in wwArr)
                {
                    sum += el;
                }
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int[] fr = new int[wwArr.Length];
                this.maxCount = 1;
                int visited = -1;

                for (int i = 0; i < wwArr.Length; i++)
                {
                    int count = 1;

                    for (int j = i + 1; j < wwArr.Length; j++)
                    {
                        if (wwArr[i] == wwArr[j])
                        {
                            count++;
                            if (maxCount < count) maxCount = count;
                            fr[j] = visited;
                        }
                    }
                    if (fr[i] != visited)
                        fr[i] = count;
                }

                return maxCount;
            }

        }

        public ArrOperation(int[] arr)
        {
            wwArr = arr;
        }

        public ArrOperation(int arrLength, int initialValue)
        {
            wwArr = new int[arrLength];
            for (int i = 0; i < wwArr.Length; i++)
            {
                wwArr[i] = initialValue;
                initialValue += initialValue;
            }
        }

        public void PrintArray()
        {
            foreach (var number in wwArr)
            {
                Console.WriteLine(number);
            }
        }

        public int[] Inverse()
        {
            var wwArr2 = new int[wwArr.Length];
            for (int i = 0; i < wwArr.Length; i++)
            {
                wwArr2[i] = wwArr[i] * (-1);
            }

            return wwArr2;
        }

        public int[] Multi(int number)
        {
            int[] wwArr2 = new int[wwArr.Length];
            for (int i = 0; i < wwArr.Length; i++)
            {
                wwArr2[i] = wwArr[i] * number;
            }

            return wwArr2;
        }

    }

