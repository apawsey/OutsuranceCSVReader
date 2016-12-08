using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CsvHelper;

namespace CSVReader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("CSV Person Processor");
            var parserResult = Parser.Default.ParseArguments<Options>(args);
            if (parserResult.Tag == ParserResultType.NotParsed)
                return;
            parserResult.WithParsed(options =>
            {
                if (!File.Exists(options.InputFile))
                {
                    Console.WriteLine("Input file does not exist.");
                    return;
                }

                if (!Directory.Exists(options.OutputFolder))
                {
                    Console.WriteLine("Output folder does not exist.");
                    return;
                }

                FileStream fileStream;
                try
                {
                    fileStream = new FileStream(options.InputFile, FileMode.Open, FileAccess.Read);
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occurred trying to open the input file.  Please check and try again.");
                    return;
                }

                List<Person> records;

                using (CsvReader csv = new CsvReader(new StreamReader(fileStream)))
                {
                    csv.Configuration.IncludePrivateProperties = true;
                    try
                    {
                        records = csv.GetRecords<Person>().ToList();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occurred trying to read the data from the input file.  Please check the formatting and try again.");
                        return;
                    }
                }

                Console.WriteLine($"Read {records.Count} from input file {options.InputFile}.");

                StringBuilder fileContents = new StringBuilder();

                foreach (KeyValuePair<string, int> nameFrequency in
                    records.GetNameFrequencies()
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key))
                {
                    fileContents.AppendLine($"{nameFrequency.Key}, {nameFrequency.Value}");
                }

                string nameFrequencyDataOutputPath = Path.Combine(options.OutputFolder, options.NameFrequenciesFileName);
                try
                {
                    File.WriteAllText(nameFrequencyDataOutputPath, fileContents.ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine($"An error occurred trying to write the name frequencies output file {nameFrequencyDataOutputPath}");
                    return;
                }
                Console.WriteLine($"Name frequency data written to {nameFrequencyDataOutputPath}");


                fileContents = new StringBuilder();
                foreach (Person person in records.OrderedByStreetName())
                {
                    fileContents.AppendLine(person.Address);
                }

                string addressesDataOutputPath = Path.Combine(options.OutputFolder, options.AddressesFileName);
                try
                {
                    File.WriteAllText(addressesDataOutputPath, fileContents.ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine($"An error occurred trying to write the addresses output file {addressesDataOutputPath}");
                    return;
                }
                Console.WriteLine($"Addresses data written to {addressesDataOutputPath}");
            });
        }
    }
}
