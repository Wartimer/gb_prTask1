using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gb_prTasks8_5
{
    public class StudentsDB
    {
        
        private string fileName;
        private List<Student> list;

        public event Action<string> ConvertedToXmlSuccess;


        public string FileName
        {
            set { fileName = value; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Student this[int index]
        {
            get { return list[index]; }
        }

        public StudentsDB(string fileName)
        {
            this.fileName = fileName;
            list = new List<Student>();
        }

        public void Add(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            list.Add(new Student(firstName, lastName, university, faculty, department, age, course, group, city));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
            ConvertedToXmlSuccess?.Invoke(fileName);

        }

    }
}
