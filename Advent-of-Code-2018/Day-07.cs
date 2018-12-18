﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace Advent_of_Code_2018
{
    class Day_07
    {
        private static string[] _rawInput = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-07-input.txt");
        private static Dictionary<string, List<string>> _steps = new Dictionary<string, List<string>>();

        static Day_07()
        {
            foreach (var line in _rawInput)
            {
                var words = Regex.Matches(line, @"\w+"); // 1, 7

                if (!_steps.ContainsKey(words[7].Value))
                    _steps.Add(words[7].Value, new List<string> { words[1].Value });
                else
                    _steps[words[7].Value].Add(words[1].Value);

                if (!_steps.ContainsKey(words[1].Value))
                    _steps.Add(words[1].Value, new List<string>());
            }
        }

        public static void Puzzle()
        {
            List<string> result = new List<string>();
            int len = _steps.Count;
            var startSteps = _steps.Where(v => v.Value.Count == 0).OrderBy(e => e.Key);

            foreach (var step in startSteps)
            {
                result.Add(step.Key);
                _steps.Remove(step.Key);
            }

            

            while (result.Count < len)
            {
                string next = _steps.Where(step => step.Value.All(
                    s => result.Contains(s))).Min(s => s.Key);

                result.Add(next);
                _steps.Remove(next);
            }

            foreach (var line in result)
                Write(line);

            /*foreach (var step in _steps)
            {
                WriteLine(step.Key);
                foreach (var val in step.Value)
                {
                    Write(val + " ");
                }
                WriteLine("\n");
            }*/
        }
    }
}
