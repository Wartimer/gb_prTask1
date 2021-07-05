using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace gb_prTasks8_1
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Task 1
            PrintDateTimeProps();
            #endregion
        }

        public static PropertyInfo GetPropertyInfo(DateTime obj, string propName)
        {
            return obj.GetType().GetProperty(propName);
        }

        public static void PrintDateTimeProps()
        {
            DateTime time = new DateTime();
            Console.WriteLine("Names of all properties\n");
            var propNames = new PropertyInfo[time.GetType().GetProperties().Length];
            var propValues = new object[time.GetType().GetProperties().Length];
            for (int i = 0; i < propNames.Length; i++)
            {
                propNames[i] = time.GetType().GetProperties()[i];
                propValues[i] = time.GetType().GetProperties()[i].GetValue(time);
            }

            for (int i = 0; i < propNames.Length; i++)
            {
                Console.WriteLine($"{propNames[i]} : {propValues[i].ToString()}");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
