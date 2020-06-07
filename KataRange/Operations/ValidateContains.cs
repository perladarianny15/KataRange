using System;
namespace KataRange.Operations
{
    public class ValidateContains
    {

        #region Contains Validations
        public static bool ParenthesesContains(int value, int minimum, int maximum)
        {
            return value > minimum && value < maximum;
        }
        public static bool BracketsContains(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }
        public static bool PBContains(int value, int minimum, int maximum)
        {
            return value > minimum && value <= maximum;
        }
        public static bool BPContains(int value, int minimum, int maximum)
        {
            return value >= minimum && value < maximum;
        }
        #endregion
    }
}
