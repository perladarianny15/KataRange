using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataRange
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            int opcion = 0;
            bool endApp = false;
            List<string> RangeList = new List<string>();
            string RangePattern = @"-?[0-9]";
            RangeList.Add("(2,8)");
            RangeList.Add("[3,5]");
            RangeList.Add("(5,9]");
            RangeList.Add("1,6");

            while (!endApp)
            {
                Console.WriteLine("---Welcome to Kata Range, What operation do you want: --- \n");

                Console.WriteLine("" +
                    "1. GetConstructor \n" +
                    "2. Contains \n" +
                    "3. DoesNotContains \n" +
                    "4. GetAllPoints \n" +
                    "5. ContainsRange \n" +
                    "6. DoesNotContainsRange \n" +
                    "7. GetEndPoints \n" +
                    "8. OverlapsRange \n" +
                    "9. DoesNotOverlaps \n" +
                    "10. Equals \n" +
                    "11. NotEquals \n" +
                    "12. Salir..."
                    );
                Console.WriteLine("Select your option: \n");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        GetConstructor(RangeList, RangePattern);
                        break;
                    case 2:
                        Contains(RangeList, RangePattern);
                        break;
                    case 3:
                        DoesNotContains(RangeList, RangePattern);
                        break;
                    case 4:
                        GetAllPoints(RangeList, RangePattern);
                        break;
                    case 7:
                        GetEndPoints(RangeList, RangePattern);
                        break;
                    case 10:
                        IsEqual(RangeList, RangePattern);
                        break;
                    case 11:
                        IsNotEqual(RangeList, RangePattern);
                        break;
                    case 12:
                        Console.WriteLine("Saliendo...");
                        break;
                }
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }

        #region GetConstructor
        public static void GetConstructor(List<string> RangeList, string RangePattern)
        {
            string Range = string.Empty;
            string delimitersResult, itemsResult, CompleteResult = string.Empty;
            List<string> ResultList = new List<string>();

            Console.WriteLine("\t\t ---GetConstructors--- \t\t\t");
            Console.WriteLine("Range \t\t" + "Delimn \t\t" + "Output \t \n");

            for (int i = 0; i < RangeList.Count(); i++)
            {
                Range = RangeList[i];

                var newRange = RangeList[i].Replace(",", "");

                var delimiters = Regex.Split(newRange, RangePattern);

                var items = Regex
                   .Matches(RangeList[i], RangePattern)
                   .OfType<Match>()
                   .Select(match => match.Value)
                   .ToArray();

                delimitersResult = string.Join("\t", delimiters);
                itemsResult = string.Join("\t", items);
                CompleteResult = $"{Range} \t\t {delimitersResult} \t {itemsResult}";
                ResultList.Add(CompleteResult);
            }

            foreach(var item in ResultList)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Constains

        public static void Contains(List<string> RangeList, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;

            bool ContainsResult, FirstResult = true;
            bool SecondResult = true;
            bool ThirdResult = true;
            bool FouthResult = true;

            int[] FirstParameters = {3,4,5,6 };
            int[] SecondParameters = {2,7};
            int[] ThirdParameters = { 6, 7, 8, 9 };
            int[] FouthParameters = { -1, 0, 1, 2, 3 };

            #region OutputList
            List<bool> FirstResultList = new List<bool>();
            List<bool> SecondResultList = new List<bool>();
            List<bool> ThirdResultList = new List<bool>();
            List<bool> FouthResultList = new List<bool>();
            #endregion

            Console.WriteLine("\t\t ---Contains--- \t\t\t");
            Console.WriteLine($"Range \t\t Parameters \t\t Output");

            foreach (var Range in RangeList)
            {
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

                if (delimitersResult == "()")
                {
                    for(int i = 0; i < FirstParameters.Length; i++)
                    {
                        ContainsResult = ParenthesesContains(FirstParameters[i], RangeFirstNumber, RangeSecondNumber);
                        FirstResultList.Add(ContainsResult);
                    }
                    if (FirstResultList.Contains(false))
                    {
                        FirstResult = false;
                    }
                    var str = String.Join(",", FirstParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {FirstResult}" );
                }

                if (delimitersResult == "[]")
                {

                    for (int i = 0; i < SecondParameters.Length; i++)
                    {
                        ContainsResult = BracketsContains(SecondParameters[i], RangeFirstNumber, RangeSecondNumber);
                        SecondResultList.Add(ContainsResult);
                    }
                    if (SecondResultList.Contains(false))
                    {
                        SecondResult = false;
                    }
                    var str = String.Join(",", SecondParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {SecondResult}");
                }
                if (delimitersResult == "(]")
                {
                    for (int i = 0; i < ThirdParameters.Length; i++)
                    {
                        ContainsResult = PBContains(ThirdParameters[i], RangeFirstNumber, RangeSecondNumber);
                        ThirdResultList.Add(ContainsResult);
                    }
                    if (ThirdResultList.Contains(false))
                    {
                        ThirdResult = false;
                    }
                    var str = String.Join(",", ThirdParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {ThirdResult}");
                }
                if (delimitersResult == "[)")
                {
                    for (int i = 0; i < FouthParameters.Length; i++)
                    {
                        ContainsResult = BPContains(FouthParameters[i], RangeFirstNumber, RangeSecondNumber);
                        FouthResultList.Add(ContainsResult);
                    }
                    if (FouthResultList.Contains(false))
                    {
                        FouthResult = false;
                    }
                    var str = String.Join(",", FouthParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t {FouthResult}");
                }
            }
        }
        #endregion

        #region Doesnt Contains

        public static void DoesNotContains(List<string> RangeList, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;

            bool ContainsResult, FirstResult = true;
            bool SecondResult = true;
            bool ThirdResult = true;
            bool FouthResult = true;

            int[] FirstParameters = { -2, -1, 0, 1 };
            int[] SecondParameters = { 4, 5 };
            int[] ThirdParameters = { -1,-2,-3,2,3,4};
            int[] FouthParameters = { 1, 3, 4 };

            #region OutputList
            List<bool> FirstResultList = new List<bool>();
            List<bool> SecondResultList = new List<bool>();
            List<bool> ThirdResultList = new List<bool>();
            List<bool> FouthResultList = new List<bool>();
            #endregion

            Console.WriteLine("\t\t ---DoesNotContains--- \t\t\t");
            Console.WriteLine($"Range \t\t Parameters \t\t Output");

            foreach (var Range in RangeList)
            {
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

                if (delimitersResult == "()")
                {
                    for (int i = 0; i < FirstParameters.Length; i++)
                    {
                        ContainsResult = ParenthesesContains(FirstParameters[i], RangeFirstNumber, RangeSecondNumber);
                        FirstResultList.Add(ContainsResult);
                    }
                    if (FirstResultList.Contains(true))
                    {
                        FirstResult = false;
                    }
                    var str = String.Join(",", FirstParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {FirstResult}");
                }

                if (delimitersResult == "[]")
                {

                    for (int i = 0; i < SecondParameters.Length; i++)
                    {
                        ContainsResult = BracketsContains(SecondParameters[i], RangeFirstNumber, RangeSecondNumber);
                        SecondResultList.Add(ContainsResult);
                    }
                    if (SecondResultList.Contains(true))
                    {
                        SecondResult = false;
                    }
                    var str = String.Join(",", SecondParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {SecondResult}");
                }
                if (delimitersResult == "(]")
                {
                    for (int i = 0; i < ThirdParameters.Length; i++)
                    {
                        ContainsResult = PBContains(ThirdParameters[i], RangeFirstNumber, RangeSecondNumber);
                        ThirdResultList.Add(ContainsResult);
                    }
                    if (ThirdResultList.Contains(true))
                    {
                        ThirdResult = false;
                    }
                    var str = String.Join(",", ThirdParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t {ThirdResult}");
                }
                if (delimitersResult == "[)")
                {
                    for (int i = 0; i < FouthParameters.Length; i++)
                    {
                        ContainsResult = BPContains(FouthParameters[i], RangeFirstNumber, RangeSecondNumber);
                        FouthResultList.Add(ContainsResult);
                    }
                    if (FouthResultList.Contains(true))
                    {
                        FouthResult = false;
                    }
                    var str = String.Join(",", FouthParameters);
                    Console.WriteLine($"{Range} \t\t [ {str} ] \t\t {FouthResult}");
                }
            }
        }

        #endregion

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

        #region GetAllPoints

        public static void GetAllPoints(List<string> RangeList, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;
            List<int> FirstOutput = new List<int>();
            List<int> SecondOutput = new List<int>();
            List<int> ThirdOutput = new List<int>();
            List<int> FouthOutput = new List<int>();

            foreach (var Range in RangeList)
            {
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

                Console.WriteLine("\t\t ---GetAllPoints--- \t\t\t");
                Console.WriteLine($"Range \t\t\t Output");

                if (delimitersResult == "()")
                {
                    for (int i = RangeFirstNumber + 1; i < RangeSecondNumber; i++)
                    {
                        FirstOutput.Add(i);
                    }
                    var str = String.Join(",", FirstOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }

                if (delimitersResult == "[]")
                {
                    for (int i = RangeFirstNumber; i <= RangeSecondNumber; i++)
                    {
                        SecondOutput.Add(i);
                    }
                    var str = String.Join(",", SecondOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
                if (delimitersResult == "(]")
                {
                    for (int i = RangeFirstNumber + 1 ; i <= RangeSecondNumber; i++)
                    {
                        ThirdOutput.Add(i);
                    }
                    var str = String.Join(",", ThirdOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
                if (delimitersResult == "[)")
                {
                    for (int i = RangeFirstNumber; i < RangeSecondNumber; i++)
                    {
                        FouthOutput.Add(i);
                    }
                    var str = String.Join(",", FouthOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
            }
        }
        #endregion

        #region GetEndPoints
        public static void GetEndPoints(List<string> RangeList, string RangePattern)
        {
            string delimitersResult = string.Empty;
            int RangeFirstNumber, RangeSecondNumber = 0;
            List<int> FirstOutput = new List<int>();
            List<int> SecondOutput = new List<int>();
            List<int> ThirdOutput = new List<int>();
            List<int> FouthOutput = new List<int>();


            Console.WriteLine("\t\t ---GetEndPoints--- \t\t\t");
            Console.WriteLine($"Range \t\t\t Output");

            foreach (var Range in RangeList)
            {
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

                if (delimitersResult == "()")
                {
                    RangeFirstNumber = RangeFirstNumber + 1;
                    RangeSecondNumber = RangeSecondNumber - 1;
                    FirstOutput.Add(RangeFirstNumber);
                    FirstOutput.Add(RangeSecondNumber);

                    var str = String.Join(",", FirstOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }

                if (delimitersResult == "[]")
                {
                    SecondOutput.Add(RangeFirstNumber);
                    SecondOutput.Add(RangeSecondNumber);

                    var str = String.Join(",", SecondOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
                if (delimitersResult == "(]")
                {
                    RangeFirstNumber = RangeFirstNumber + 1;
                    ThirdOutput.Add(RangeFirstNumber);
                    ThirdOutput.Add(RangeSecondNumber);

                    var str = String.Join(",", ThirdOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
                if (delimitersResult == "[)")
                {
                    RangeSecondNumber = RangeSecondNumber - 1;
                    FouthOutput.Add(RangeFirstNumber);

                    FouthOutput.Add(RangeSecondNumber);

                    var str = String.Join(",", FouthOutput);
                    Console.WriteLine($"{Range} \t\t\t [ {str} ]");
                }
            }
        }
        #endregion

        #region IsEqual
        public static void IsEqual(List<string> RangeList, string RangePattern)
        {
            bool Result = false;
            string FirstValue = string.Empty;
            string SecondValue = string.Empty;

            List<string> SecondRangeList = new List<string>();
            SecondRangeList.Add("{3,10)");
            SecondRangeList.Add("[3,5]");
            SecondRangeList.Add("{11,15)");
            SecondRangeList.Add("[1,6)");

            Console.WriteLine("\t\t ---IsEqual--- \t\t\t");
            Console.WriteLine($"Range \t\t Parameters \t\t Output");

            for(int i = 0; i < RangeList.Count(); i++)
            {
                FirstValue = RangeList[i];
                SecondValue = SecondRangeList[i];

                if (FirstValue.Equals(SecondValue))
                {
                    Result = true;
                    Console.WriteLine($"{RangeList[i]} \t\t {SecondRangeList[i]} \t\t\t {Result}");
                }
                else
                {
                    Console.WriteLine($"{RangeList[i]} \t\t {SecondRangeList[i]} \t\t {Result}");
                }

                Result = false;
            }
        }
        #endregion

        #region IsNotEqual
        public static void IsNotEqual(List<string> RangeList, string RangePattern)
        {
            bool Result = false;
            string FirstValue = string.Empty;
            string SecondValue = string.Empty;

            List<string> SecondRangeList = new List<string>();
            SecondRangeList.Add("(1,9)");
            SecondRangeList.Add("{6,8}");
            SecondRangeList.Add("(5,9]");
            SecondRangeList.Add("[1,6)");

            Console.WriteLine("\t\t ---IsNotEqual--- \t\t\t");
            Console.WriteLine($"Range \t\t Parameters \t\t Output");

            for (int i = 0; i < RangeList.Count(); i++)
            {
                FirstValue = RangeList[i];
                SecondValue = SecondRangeList[i];

                if (!FirstValue.Equals(SecondValue))
                {
                    Result = true;
                }

                Console.WriteLine($"{RangeList[i]} \t\t {SecondRangeList[i]} \t\t\t {Result}");
               
                Result = false;
            }
        }

        #endregion
    }
}
