using System;
using System.IO;

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
        public string HighestAbandonmentRate { get; set; }

        public void ReadData()
        {
            var totalCallsColumn = 2;
            double startCol = 27;
            double endCol = 39;
            double totalAbandonment = 0;
            double highestAbandonmentRate = 0;

            using (StreamReader reader = new StreamReader(FileName))
            {
                var totalCalls = 0;
                var line = reader.ReadLine(); // Read the header line, which doesn't contain data
                string forecName = "";
                while (!reader.EndOfStream)
                {
                    NumberOfForces++;
                    line = reader.ReadLine();
                    var columns = line.Split(",");  // What if there's a comma inside a data column?
                    
                    int.TryParse(columns[1], out int num);
                    totalCalls += num;

                    for (int i = (int)startCol; i< endCol; i++)
                    {
                        totalAbandonment += double.Parse(columns[i]);
                    }

                    if (totalAbandonment > highestAbandonmentRate) 
                    {
                        forecName = columns[0];
                        HighestAbandonmentRate = forecName;
                        highestAbandonmentRate = totalAbandonment;
                    }

                    totalAbandonment = 0;
                }
                AverageTotalCalls = totalCalls / NumberOfForces;
            }
        }
      
    }
        
}
