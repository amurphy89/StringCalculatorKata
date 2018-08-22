using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string input)
        {
            if (input == String.Empty)
                return 0;

            var numbers = ParseNumbers(input);

            bool containsNegative = numbers.Any(x => x < 0);

            if (containsNegative)
                throw new ArgumentOutOfRangeException();

            return numbers.Sum();
        }

        private IEnumerable<int> ParseNumbers(string input)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (input.Contains("//"))
            {
                var regex = new Regex(@"(?<=\/\/)[^[]|(?<=\[).+?");
                var m = regex.Matches(input);
                for (int i = 0; i <= m.Count - 1; i++)
                {
                    delimiters.Add(Char.Parse(m[i].Value));
                }
            }

            string[] splitString = input.Split(
                            delimiters.ToArray(),
                            StringSplitOptions.None
                            );

            return splitString
                .Where(x => Int32.TryParse(x, out int y))
                .Select(x => Int32.Parse(x))
                .Where(x => x < 1001);
        }
    }
}
