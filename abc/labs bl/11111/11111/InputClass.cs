using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace _11111
{
    class InputClass
    {
        public static string GetInputNumber13()
        {
            string result;
            Regex regex = new Regex(@"^[0-9abcABC]+$");

            while (!regex.IsMatch(result = ReadLine()))
            {
                WriteLine("Wrong input!!!");
            }

            return result.ToUpper();
        }

        public static string GetInputNumberBinary()
        {
            string result;
            Regex regex = new Regex(@"^[0-1]+$");

            while (!regex.IsMatch(result = ReadLine()))
            {
                WriteLine("Wrong input!!!");
            }

            return result.ToUpper();
        }
        public static string GetInputNumberOctal()
        {
            string result;
            Regex regex = new Regex(@"^[0-7]+$");

            while (!regex.IsMatch(result = ReadLine()))
            {
                WriteLine("Wrong input!!!");
            }

            return result.ToUpper();
        }

        public static int GetInputInt()
        {
            int result;

            while (!int.TryParse(ReadLine(), out result))
            {
                WriteLine("Wrong input!!!");
            }

            return result;
        }
    }
}
