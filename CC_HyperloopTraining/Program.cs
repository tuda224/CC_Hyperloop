using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CC_HyperloopTraining
{
    public class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                ReadInput();
            }
        }

        private static void ReadInput()
        {
            Console.WriteLine("Using input file: C:\\temp\\input.txt\nPress Return for run.");
            Console.ReadLine();
            var lines = File.ReadLines("C:\\temp\\input.txt").ToArray();

            var lineCounter = 0;
        }

        private static int GetInt(string s)
        {
            return int.Parse(s);
        }

        private static void PrintResult(string s)
        {
            PrintResult(new List<string> {
                s
            });
        }

        private static void PrintResult(IEnumerable<string> lines)
        {
            File.WriteAllLines("C:\\temp\\result.txt", lines);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}