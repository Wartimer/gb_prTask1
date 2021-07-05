using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gb_prTasks8_4
{
    public class RecipiesDB
    {
        private long fsLim = 1024;
        private string fileName;
        private List<Recipe> list;

        public event Action<long> FileSizeExcess;


        public string FileName
        {
            set { fileName = value; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Recipe this[int index]
        {
            get { return list[index]; }
        }

        public RecipiesDB(string fileName)
        {
            this.fileName = fileName;
            list = new List<Recipe>();
        }

        public void Add(string title, List<string> ingredients, int cookingTime, int rating)
        {
            list.Add(new Recipe(title, ingredients, cookingTime, rating));
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
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Recipe>));
                    using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        list =(List<Recipe>)xmlSerializer.Deserialize(stream);
                    }
                }  
                
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Recipe>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
        }

    }
}
