using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "police_101_call_data.csv";

            var dataReader = new DataReader();
            dataReader.FileName = fileName;
            dataReader.ReadData();

            Console.WriteLine(String.Format("Average total calls: {0}", dataReader.AverageTotalCalls));
            Console.WriteLine(String.Format("Number of rows: {0}", dataReader.NumberOfForces));
            Console.WriteLine("Press enter key to exit");
            Console.ReadLine();
        }
    }

    public class DataReader
    {
        public string FileName { get; set; }

        public int AverageTotalCalls { get; set; }
        public int NumberOfForces { get; set; }
        public string HighestAbandonmentRateName { get; set; }

        public List<string> RankedListJan { get; set; }

        public void ReadData()
        {
            double highestAbandonmentRate = 0;
            using (StreamReader reader = new StreamReader(FileName))
            {
                RankedListJan = new List<string>();
                var totalCalls = 0;
                var line = reader.ReadLine();
                Dictionary<string, double> ForcesWithAnsTime = new Dictionary<string, double>();
                while (!reader.EndOfStream)
                {
                    NumberOfForces++;
                    line = reader.ReadLine();
                    var columns = line.Split(",");
                    int.TryParse(columns[1], out int num);
                    totalCalls += num;

                    highestAbandonmentRate = SetAbandonmentRate(columns, highestAbandonmentRate);

                }


                AverageTotalCalls = totalCalls / NumberOfForces;
            }
        }


        private double SetAbandonmentRate(string[] columns, double highestAbandonmentRate)
        {
            int startCol = 27;
            int endCol = 39;
            
            double totalAbandonment = 0;
            for (int i = startCol; i < endCol; i++)
            {
                double.TryParse(columns[i], out double num);
                totalAbandonment += num;
            }

            if (totalAbandonment > highestAbandonmentRate)
            {
                highestAbandonmentRate = totalAbandonment;
                HighestAbandonmentRateName = columns[0];
            }

            return highestAbandonmentRate;
        }
    }
        
}
