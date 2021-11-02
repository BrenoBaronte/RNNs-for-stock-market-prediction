using System;
using System.Collections.Generic;
using System.IO;

namespace LabelsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var datasetCodes = new[] { "T", "H" };
            var daysToLookBackCodes = new[] { "30", "60" };
            var optimizerAlgorithmsCodes = new[] { "A", "S" };
            var lossAlgorithmsCodes = new[] { "MSE", "MAE" };
            var epochsCodes = new[] { "L", "C" };
            var batchSizeCodes = new[] { "16", "32", "64" };
            var layersCodes = new[] { "5C", "6C", "9C", "XC", "GC" };

            var linesToWrite = new List<string>();

            foreach (var datasetCode in datasetCodes)
                foreach (var daysToLookBackCode in daysToLookBackCodes)
                    foreach (var optimizerAlgorithmsCode in optimizerAlgorithmsCodes)
                        foreach (var lossAlgorithmsCode in lossAlgorithmsCodes)
                            foreach (var epochCode in epochsCodes)
                                foreach (var batchSizeCode in batchSizeCodes)
                                    foreach (var layerCode in layersCodes)
                                        linesToWrite.Add(
                                            datasetCode +
                                            daysToLookBackCode +
                                            optimizerAlgorithmsCode +
                                            lossAlgorithmsCode +
                                            epochCode +
                                            batchSizeCode +
                                            layerCode);

            var path = Directory.GetCurrentDirectory() + "\\labels.txt";
            var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(linesToWrite);
            streamWriter.Flush();
            streamWriter.Close();

            Console.WriteLine($"{linesToWrite.Count} lines wrote on file {path}.");
            Console.ReadKey();
        }
    }
}
