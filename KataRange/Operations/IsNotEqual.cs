using System;
using System.Collections.Generic;
using System.Linq;

namespace KataRange
{
    public class IsNotEqual
    {
        #region IsNotEqual
        
        public static string Get(string FirstValue, string SecondValue )
        {
            bool Result = false;
            string CheckIsEmpty = string.Empty;

            if (string.IsNullOrEmpty(FirstValue))
            {
                return CheckIsEmpty;
            }
            else
            {
                return "valor";
            }

            if (!FirstValue.Equals(SecondValue))
            {
                Result = true;
            }
            return CheckIsEmpty;
        }

        #endregion
    }
}
