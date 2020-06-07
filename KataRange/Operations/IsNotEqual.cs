using System;
using System.Collections.Generic;
using System.Linq;

namespace KataRange
{
    public class IsNotEqual
    {
        #region IsNotEqual
        
        public static bool Get(string FirstValue, string SecondValue )
        {
            bool Result = false;

            if (!FirstValue.Equals(SecondValue))
            {
                Result = true;
            }
            return Result;
        }

        #endregion
    }
}
