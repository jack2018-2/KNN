using ConsoleApp10.DataPreparing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Dot
    {
        /// <summary>
        /// Массив признаков точки
        /// </summary>
        public List<decimal> Signs;

        /// <summary>
        /// Массив модификаторов для признаков
        /// </summary>
        // ToDo внести в Signs
        public List<double> SignsWeights;

        /// <summary>
        /// Принадлежность к классу
        /// </summary>
        public Classes Klass;

        public Dot(CoffeeTeaDataSet row, List<Classes> classes)
        {
            var parentClasses = ConvertToNumber(row.Parents, classes);

            Signs = new List<decimal>()
            {
                row.SleepHoures,
                row.IsWorking,
                row.Weight,
                row.Height,
                row.Distance
            };
            Signs.AddRange(parentClasses);

            // ToDo костыльььььььььььь
            // увеличивает вес родителей в признаках
            SignsWeights = new List<double>(ArrayList.Repeat(1, Signs.Count()).ToArray().Select(x => Convert.ToDouble(x)));
            SignsWeights[5] = 5;

            Klass = new Classes(row.Klass, classes.Find(x => x.Classname == row.Klass).NumericValue);
        }

        private IEnumerable<decimal> ConvertToNumber(string parents, List<Classes> existClasses)
        {
            var result = new List<Classes>();
            var classes = parents.ToCharArray();
            foreach (var klass in classes)
            {
                result.Add(existClasses.First(x => x.Classname == klass.ToString()));
            }
            return result.Select(x => (decimal)x.NumericValue);
        }
    }
}
