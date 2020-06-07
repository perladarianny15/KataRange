using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataRange
{
    public class Constructor
    {

        #region GetConstructor
        public static bool Get(string Range, string RangePattern)
        {
            string delimitersResult = string.Empty;
            bool Result = false;
            var newRange = Range.Replace(",", "");

            var delimiters = Regex.Split(newRange, RangePattern);

            delimitersResult = string.Join("", delimiters);

            if (delimitersResult == "()")
            {
                Result = true;
            }else if (delimitersResult == "[]")
            {
                Result = true;
            }else if (delimitersResult == "(]")
            {
                Result = true;
            }else if (delimitersResult == "[)")
            {
                Result = true;
            }
            else
            {
                return Result;
            }

            return Result;
        }
        #endregion
    }
}
