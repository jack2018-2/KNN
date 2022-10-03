using ConsoleApp10.DataPreparing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Algorythm
{
    public class KNN
    {
        /// <summary>
        /// Существующие классы
        /// </summary>
        private List<Classes> _classes;

        /// <summary>
        /// Значение параметра K
        /// </summary>
        private int _k;

        /// <summary>
        /// Список всех точек обучающей выборки
        /// </summary>
        private List<Dot> _dots;

        /// <summary>
        /// Классифицируемая точка
        /// </summary>
        private Dot _classifyingDot;

        public KNN()
        {
            prepare();
            var row = new CoffeeTeaDataSet()
            {
                SleepHoures = 8,
                IsWorking = 0,
                Weight = 70,
                Height = 170,
                Distance = 1,
                Parents = "кч",
                Klass = "к"
            };
            _classifyingDot = new Dot(row, _classes);
        }

        private void prepare()
        {
            _k = int.Parse(ConfigurationManager.AppSettings.Get("k"));
            var preparer = new DataPreparer(ConfigurationManager.AppSettings.Get("sourceDataPath"));
            preparer.PrepareData();
            _dots = preparer.Dots;
            _classes = preparer.Classes;
        }

        public void DoKNN()
        {
            Dictionary<Dot, double> distances = new Dictionary<Dot, double>();

            foreach (Dot dot in _dots)
            {
                double distance = Utils.pairDotsDistance(dot, _classifyingDot);
                distances.Add(dot, distance);
            }

            var orderedDistances = distances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            SimpleVote(orderedDistances);
            WeightedVote(orderedDistances);

        }

        /// <summary>
        /// невзвешенное голосование
        /// </summary>
        /// <param name="distances">отсортированные по возрастанию расстояния от всех точек до классифицируемой точки</param>
        private void SimpleVote(Dictionary<Dot, double> distances)
        {
            var nearestClass = distances
                .Take(_k)
                .GroupBy(x => x.Key.Klass)
                .Select(x =>
                    new KeyValuePair<Classes, int>(x.Key, x.Count()))
                .OrderByDescending(x => x.Value)
                .First().Key;

            _classifyingDot.Klass = nearestClass;
            Console.WriteLine($"Точка множества классифицирована в класс {nearestClass.Classname} методом простого голосования, k={_k}");
        }

        /// <summary>
        /// взвешенное голосование
        /// </summary>
        /// <param name="distances">отсортированные по возрастанию расстояния от всех точек до классифицируемой точки</param>
        private void WeightedVote(Dictionary<Dot, double> distances)
        {
            Dictionary<string, double> votes = new Dictionary<string, double>();

            foreach (var klass in _classes)
            {
                votes[klass.Classname] = 0d;
            }

            for (var i = 0; i < _k && i < distances.Count(); i++)
            {
                var distance = distances.ElementAt(i);
                votes[distance.Key.Klass.Classname] += 1d / distance.Value;
            }

            var nearestClass = votes
                .Select(x =>
                    new KeyValuePair<Classes, double>(_classes.Find(y => y.Classname == x.Key), x.Value))
                .OrderByDescending(x => x.Value)
                .First().Key;

            _classifyingDot.Klass = nearestClass;
            Console.WriteLine($"Точка множества классифицирована в класс {nearestClass.Classname} методом взвешенного голосования, k={_k}");
        }
    }
}
