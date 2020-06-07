using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataRange
{
    public class EndPoints
    {
        #region GetEndPoints
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
                    RangeFirstNumber = RangeFirstNumber + 1;
                    RangeSecondNumber = RangeSecondNumber - 1;
                    Result.Add(RangeFirstNumber);
                    Result.Add(RangeSecondNumber);
                    break;
                case "[]":
                    Result.Add(RangeFirstNumber);
                    Result.Add(RangeSecondNumber);
                    break;
                case "(]":
                    RangeFirstNumber = RangeFirstNumber + 1;
                    Result.Add(RangeFirstNumber);
                    Result.Add(RangeSecondNumber);
                    break;
                case "[)":
                    RangeSecondNumber = RangeSecondNumber - 1;
                    Result.Add(RangeFirstNumber);

                    Result.Add(RangeSecondNumber);
                    break;
            }

            return Result;
        }
        #endregion
    }
}
