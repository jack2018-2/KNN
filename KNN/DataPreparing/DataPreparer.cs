using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10.DataPreparing
{
    public class DataPreparer
    {
        /// <summary>
        /// Путь к файлу с обучающей выборкой
        /// </summary>
        private string _pathToFile { get; }

        public List<Dot> Dots { get; set; }

        public List<Classes> Classes { get; set; }

        public DataPreparer(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void PrepareData()
        {
            var parser = new CsvParser(_pathToFile);
            var collectedData = parser.Parse<CoffeeTeaDataSet>();
            getExistingClasses(collectedData);
            getDots(collectedData);
        }

        private void getDots(IEnumerable<CoffeeTeaDataSet> collectedData)
        {
            var rows = new List<Dot>();
            foreach (var row in collectedData)
            {
                rows.Add(new Dot(row, Classes));
            }
            Dots = rows;
        }

        private void getExistingClasses(IEnumerable<CoffeeTeaDataSet> collectedData)
        {
            var iterator = 0;
            var classes = new HashSet<Classes>(new ClassesComparer());
            foreach (var row in collectedData)
            {
                if (classes.Add(new Classes(row.Klass, iterator)))
                    iterator++;
            }
            Classes = classes.ToList();
        }
    }
}
