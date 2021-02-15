using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CC_HyperloopTraining
{
    public class Level1
    {
        private static World world;

        private static void OutputLevel1()
        {
            PrintResult(string.Join(' ', world.TargetsInSameAreaAsStartPoint()));
        }

        private static void ReadInput()
        {
            Console.WriteLine("Using input file: C:\\temp\\input.txt\nPress Return for run.");
            Console.ReadLine();
            var lines = File.ReadLines("C:\\temp\\input.txt").ToArray();

            var lineCounter = 0;
            world.SeparatorY = int.Parse(lines[lineCounter++]);

            var numberOfTargets = int.Parse(lines[lineCounter++]);
            for (int i = 0; i < numberOfTargets; i++)
            {
                var targetCoordinates = lines[lineCounter++].Split(' ');
                world.Targets.Add(new Coordinates
                {
                    X = int.Parse(targetCoordinates[0]),
                    Y = int.Parse(targetCoordinates[1])
                });
            }
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

        public class World
        {
            public int[,] Map { get; set; }
            public Coordinates StartPoint { get; set; } = new Coordinates { X = 0, Y = 0 };
            public List<Coordinates> Targets { get; set; } = new List<Coordinates>();
            public int SeparatorY { get; set; } = 0;

            public List<Coordinates> TargetsInSameAreaAsStartPoint()
            {
                if (StartPoint.Y < SeparatorY)
                {
                    return Targets.Where(t => t.Y < SeparatorY).ToList();
                }

                return Targets.Where(t => t.Y > SeparatorY).ToList();
            }
        }

        public class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"{X} {Y}";
            }
        }
    }
}