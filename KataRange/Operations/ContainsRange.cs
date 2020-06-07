using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using KataRange.Operations;

namespace KataRange
{
    public class ContainsRange
    {
        public static bool Get(string Range, int[] Parameter, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;

            bool ContainsResult, Result = true;

            #region OutputList
            List<bool> FirstResultList = new List<bool>();
            List<bool> SecondResultList = new List<bool>();
            List<bool> ThirdResultList = new List<bool>();
            List<bool> FouthResultList = new List<bool>();
            #endregion

            var newRange = Range.Replace(",", "");

            var delimiters = Regex.Split(newRange, RangePattern);

            delimitersResult = string.Join("", delimiters);


            var items = Regex
               .Matches(Range, RangePattern)
               .OfType<Match>()
               .Select(match => match.Value)
               .ToArray();

            RangeFirstNumber = Convert.ToInt32(items[0]);

            RangeSecondNumber = Convert.ToInt32(items[1]);
            switch (delimitersResult)
            {
                case "()":
                    for (int i = 0; i < Parameter.Length; i++)
                    {
                        ContainsResult = ValidateContains.ParenthesesContains(Parameter[i], RangeFirstNumber, RangeSecondNumber);
                        FirstResultList.Add(ContainsResult);
                    }
                    if (FirstResultList.Contains(false))
                    {
                        Result = false;
                    }

                    break;
                case "[]":
                    for (int i = 0; i < Parameter.Length; i++)
                    {
                        ContainsResult = ValidateContains.BracketsContains(Parameter[i], RangeFirstNumber, RangeSecondNumber);
                        SecondResultList.Add(ContainsResult);
                    }
                    if (SecondResultList.Contains(false))
                    {
                        Result = false;
                    }

                    break;
                case "(]":
                    for (int i = 0; i < Parameter.Length; i++)
                    {
                        ContainsResult = ValidateContains.PBContains(Parameter[i], RangeFirstNumber, RangeSecondNumber);
                        ThirdResultList.Add(ContainsResult);
                    }
                    if (ThirdResultList.Contains(false))
                    {
                        Result = false;
                    }

                    break;
                case "[)":
                    for (int i = 0; i < Parameter.Length; i++)
                    {
                        ContainsResult = ValidateContains.BPContains(Parameter[i], RangeFirstNumber, RangeSecondNumber);
                        FouthResultList.Add(ContainsResult);
                    }
                    if (FouthResultList.Contains(false))
                    {
                        Result = false;
                    }

                    break;
                case "":
                    Result = false;
                    break;
            }

            return Result;
        }

    }
}
