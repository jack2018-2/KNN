using CsvHelper.Configuration.Attributes;

namespace ConsoleApp10.DataPreparing
{
    public class CoffeeTeaDataSet
    {
        [Index(0)]
        public int SleepHoures { get; set; }

        [Index(1)]
        public int IsWorking { get; set; }

        [Index(2)]
        public int Weight { get; set; }

        [Index(3)]
        public int Height { get; set; }

        [Index(4)]
        public decimal Distance { get; set; }

        [Index(5)]
        public string Parents { get; set; }

        [Index(6)]
        public string Klass { get; set; }
    }
}
