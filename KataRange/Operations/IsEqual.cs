using System;
using System.Collections.Generic;
using System.Linq;

namespace KataRange
{
    public class IsEqual
    {
        #region IsEqual
        public static bool Get(string FirstValue, string SecondValue)
        {
            bool Result = false;

            if (FirstValue.Equals(SecondValue))
            {
                Result = true;
            }
            return Result;
        }
        #endregion
    }
}
