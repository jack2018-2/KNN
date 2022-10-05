using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp10.DataPreparing
{
    public class CsvParser : IFileParser
    {
        private readonly string _filePath;

        public CsvParser(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<T> Parse<T>()
        {
            IEnumerable<T> res;
            var CSVConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Encoding = System.Text.Encoding.GetEncoding("Windows-1251"),
                Delimiter = ";"
            };

            using (var stream = new StreamReader(_filePath, System.Text.Encoding.GetEncoding("Windows-1251")))
            using (var csv = new CsvReader(stream, CSVConfig))
                res = csv.GetRecords<T>().ToList();
            return res;
        }
    }
}
