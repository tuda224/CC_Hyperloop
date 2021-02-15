using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CC_HyperloopTraining
{
    public class Level2
    {
        private static World world;

        private static void OutputLevel2()
        {
            PrintResult(string.Join(' ', world.TargetsInSameAreaAsStartPoint()));
        }

        private static void ReadInput()
        {
            Console.WriteLine("Using input file: C:\\temp\\input.txt\nPress Return for run.");
            Console.ReadLine();
            var lines = File.ReadLines("C:\\temp\\input.txt").ToArray();
            var lineCounter = 0;

            var angle1String = lines[lineCounter++].Split(' ');
            var angle2String = lines[lineCounter++].Split(' ');
            world.Separators = (new Coordinates
            {
                X = int.Parse(angle1String[0]),
                Y = int.Parse(angle1String[1])
            }, new Coordinates
            {
                X = int.Parse(angle2String[0]),
                Y = int.Parse(angle2String[1])
            });

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
            //public int SeparatorY { get; set; } = 0;

            public (Coordinates first, Coordinates second) Separators;

            public List<Coordinates> TargetsInSameAreaAsStartPoint()
            {
                var angle1 = Math.Atan2(Separators.first.Y, Separators.first.X);
                var angle2 = Math.Atan2(Separators.second.Y, Separators.second.X);

                if (angle1 < angle2)
                {
                    return Targets
                        .Where(t => Math.Atan2(t.Y, t.X) < angle1 || Math.Atan2(t.Y, t.X) > angle2).ToList();
                }

                return Targets
                        .Where(t => Math.Atan2(t.Y, t.X) > angle1 || Math.Atan2(t.Y, t.X) < angle2).ToList();
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