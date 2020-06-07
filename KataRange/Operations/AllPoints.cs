using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataRange
{
    public class AllPoints
    {
        #region GetAllPoints

        public static List<int> Get(string Range, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;
            List<int> Result = new List<int>();

            var newRange = Range.Replace(",", "");

            var delimiters = Regex.Split(newRange, RangePattern);

            var items = Regex
               .Matches(Range, RangePattern)
               .OfType<Match>()
               .Select(match => match.Value)
               .ToArray();

            delimitersResult = string.Join("", delimiters);

            RangeFirstNumber = Convert.ToInt32(items[0]);

            RangeSecondNumber = Convert.ToInt32(items[1]);
            switch (delimitersResult)
            {
                case "()":
                    for (int i = RangeFirstNumber + 1; i < RangeSecondNumber; i++)
                    {
                        Result.Add(i);
                    }

                    break;
                case "[]":
                    for (int i = RangeFirstNumber; i <= RangeSecondNumber; i++)
                    {
                        Result.Add(i);
                    }

                    break;
                case "(]":
                    for (int i = RangeFirstNumber + 1; i <= RangeSecondNumber; i++)
                    {
                        Result.Add(i);
                    }

                    break;
                case "[)":
                    for (int i = RangeFirstNumber; i < RangeSecondNumber; i++)
                    {
                        Result.Add(i);
                    }

                    break;
            }

            return Result;
        }
        #endregion
    }
}
