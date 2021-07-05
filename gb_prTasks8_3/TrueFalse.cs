using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gb_prTasks8_3
{
    public class TrueFalse
    {
        private long fsLim = 1024;
        private string fileName;
        private List<Question> list;
        public event Action<long> FileSizeExcess;


        public string FileName
        {
            set { fileName = value; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        public void Load()
        {

                FileInfo fi = new FileInfo(fileName);
                long size = fi.Length;

                if(size / 1024 > fsLim) FileSizeExcess?.Invoke(fsLim);

                else
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
                    using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        list =(List<Question>)xmlSerializer.Deserialize(stream);
                    }
                }  
                
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
        }

    }
}
