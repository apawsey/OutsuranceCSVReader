using System.IO;
using CommandLine;

namespace CSVReader
{
    public class Options
    {
        private string _outputFolder;

        [Option('i', "inputFile", HelpText = "The path to the input csv data file", Required = true)]
        public string InputFile { get; private set; }

        [Option("namesFileName", HelpText = "The file name for the name frequencies output.", Default = "NameFrequencies.txt")]
        public string NameFrequenciesFileName { get; private set; }
        [Option("addressesFileName", HelpText = "The file name for the addresses output.", Default = "Addresses.txt")]
        public string AddressesFileName { get; private set; }

        [Option('o', "output", HelpText = "The path to the folder to place the output files.  Defaults to the folder containing the input file.", Required = false)]
        public string OutputFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(_outputFolder) || string.IsNullOrWhiteSpace(InputFile)) return _outputFolder;
                try
                {
                    //Easiest to use full fileInfo class in case of relative paths, should be optimised though
                    FileInfo inputFileInfo = new FileInfo(InputFile);
                    return inputFileInfo.DirectoryName;
                }
                catch
                {
                    return null;
                }
            }

            private set { _outputFolder = value; }
        }
    }
}