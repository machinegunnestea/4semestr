using System;
using System.Collections.Generic;
using System.Linq;

namespace _11111
{
    class Converter
    {
        private static readonly IDictionary<int, string> _numberSystem13Dictionary = new Dictionary<int, string>
        {
            { 10, "A" },
            { 11, "B" },
            { 12, "C" },           
        };
        private static readonly IDictionary<string, int> _backwardsNumberSystem13Dictionary = new Dictionary<string, int>
        {
            { "A", 10 },
            { "B", 11 },
            { "C", 12 },           
        };
        private static readonly IDictionary<string, string> _numberSystemBinaryDictionary = new Dictionary<string, string>
        {
            ["1010"] = "A",
            ["1011"] = "B",
            ["1100"] = "C",      
        };

        public static string ConvertFrom10(int numberSystem, int number) // 10 to 13
        {
            List<string> convertedNumber = new List<string>();

            do
            {
                int result = number % numberSystem;
                if (!_numberSystem13Dictionary.ContainsKey(result))
                {
                    convertedNumber.Add(result.ToString());
                    number /= numberSystem;
                    continue;
                }

                convertedNumber.Add(_numberSystem13Dictionary[result]);
                number /= numberSystem;
            } while (number >= numberSystem);

            if (number != 0)
            {
                if (!_numberSystem13Dictionary.ContainsKey(number))
                {
                    convertedNumber.Add(number.ToString());
                }
                else
                {
                    convertedNumber.Add(_numberSystem13Dictionary[number]);
                }
            }
            convertedNumber.Reverse();

            return string.Join("", convertedNumber);
        }
        public static int ConvertTo10(int numberSystem, string number) // 13 to 10
        {
            int result = 0;
            char[] numberArray = number.ToCharArray();

            for (int i = 0; i < numberArray.Length; i++)
            {
                int convertedNumber;
                if (int.TryParse(numberArray[i].ToString(), out convertedNumber))
                {
                    if (!_numberSystem13Dictionary.ContainsKey(convertedNumber))
                    {
                        result += (int)(convertedNumber * Math.Pow(numberSystem, numberArray.Length - i - 1));
                        continue;
                    }
                }

                result += (int)(_backwardsNumberSystem13Dictionary[numberArray[i].ToString()] * Math.Pow(numberSystem, numberArray.Length - i - 1));
            }

            return result;
        }
        public static string ConvertFrom2To16(string number) // 2 to 16
        {
            List<string> convertedNumber = new List<string>();
            string[] numberArray = number.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();

            for (int i = 0; i < numberArray.Length; i += 4)
            {
                string result;

                if (i + 4 >= numberArray.Length)
                {
                    result = string.Join("", numberArray, i, numberArray.Length - i);
                }
                else
                {
                    result = string.Join("", numberArray, i, 4);
                }

                result = string.Join("", result.Reverse().Select(obj => string.Format($"{obj}")).ToArray());

                if (!_numberSystemBinaryDictionary.ContainsKey(result))
                {
                    convertedNumber.Add(string.Format($"{ConvertTo10(2, result)}"));
                    continue;
                }

                convertedNumber.Add(_numberSystemBinaryDictionary[result]);
            }

            convertedNumber.Reverse();

            return string.Join("", convertedNumber);
        }

        public static string ConvertFrom8To2(string number) // 8 to 2
        {
            List<string> convertedNumber = new List<string>();
            string[] numberArray = number.ToCharArray().Select(obj => string.Format($"{obj}")).ToArray();

            for (int i = 0; i < numberArray.Length; i++)
            {
                string result = ConvertFrom10(2, int.Parse(numberArray[i]));

                if (result.Length < 3)
                {
                    for (int j = 0; j < 3 - result.Length; j++)
                    {
                        result = "0" + result;
                    }
                }

                convertedNumber.Add(result);
            }

            return string.Join("", convertedNumber);
        }
        public static string SumSystem13(int numberSystem, string number1, string number2)
        {
            List<string> resultNumber = new List<string>();
            string[] numberArray1 = number1.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();
            string[] numberArray2 = number2.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();

            int length = numberArray1.Length >= numberArray2.Length ? numberArray1.Length : numberArray2.Length;
            int tmp = 0;

            for (int i = 0; i < length; i++)
            {
                int resultNum1;
                int resultNum2;
                string result;

                if (numberArray1.Length <= i)
                {
                    resultNum1 = 0;

                    if (!int.TryParse(numberArray2[i], out resultNum2))
                    {
                        resultNum2 = _backwardsNumberSystem13Dictionary[numberArray2[i]];
                    }

                    result = ConvertFrom10(numberSystem, resultNum1 + resultNum2 + tmp);

                    if (result.Length > 1)
                    {
                        resultNumber.Add(string.Format($"{result[1]}"));
                        tmp = int.Parse(string.Format($"{result[0]}"));
                        continue;
                    }

                    resultNumber.Add(result);
                    tmp = 0;
                    continue;
                }

                if (numberArray2.Length <= i)
                {
                    resultNum2 = 0;

                    if (!int.TryParse(numberArray1[i], out resultNum1))
                    {
                        resultNum1 = _backwardsNumberSystem13Dictionary[numberArray1[i]];
                    }

                    result = ConvertFrom10(numberSystem, resultNum1 + resultNum2 + tmp);

                    if (result.Length > 1)
                    {
                        resultNumber.Add(string.Format($"{result[1]}"));
                        tmp = int.Parse(string.Format($"{result[0]}"));
                        continue;
                    }

                    resultNumber.Add(result);
                    tmp = 0;
                    continue;
                }

                if (!int.TryParse(numberArray1[i], out resultNum1))
                {
                    resultNum1 = _backwardsNumberSystem13Dictionary[numberArray1[i]];
                }

                if (!int.TryParse(numberArray2[i], out resultNum2))
                {
                    resultNum2 = _backwardsNumberSystem13Dictionary[numberArray2[i]];
                }

                result = ConvertFrom10(numberSystem, resultNum1 + resultNum2 + tmp);

                if (result.Length > 1)
                {
                    resultNumber.Add(string.Format($"{result[1]}"));
                    tmp = int.Parse(string.Format($"{result[0]}"));
                    continue;
                }

                resultNumber.Add(result);
                tmp = 0;
            }

            if (tmp != 0)
            {
                resultNumber.Add(tmp.ToString());
            }

            resultNumber.Reverse();

            return string.Join("", resultNumber);
        }
        public static string MinusSystem13(int numberSystem, string number1, string number2)
        {
            List<string> resultNumber = new List<string>();
            string[] numberArray1 = number1.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();
            string[] numberArray2 = number2.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();

            int length = numberArray1.Length >= numberArray2.Length ? numberArray1.Length : numberArray2.Length;
            int tmp = 0;
            bool flag = false;

            for (int i = 0; i < length; i++)
            {
                int resultNum1;
                int resultNum2;
                string result;

                if (numberArray1.Length <= i)
                {
                    resultNum1 = 0;

                    if (!int.TryParse(numberArray2[i], out resultNum2))
                    {
                        resultNum2 = _backwardsNumberSystem13Dictionary[numberArray2[i]];
                    }

                    result = ConvertFrom10(numberSystem, resultNum1 - resultNum2 - tmp);

                    if (result.Length > 1)
                    {
                        resultNumber.Add(string.Format($"{result[1]}"));
                        continue;
                    }

                    resultNumber.Add(result);
                    continue;
                }

                if (numberArray2.Length <= i)
                {
                    resultNum2 = 0;

                    if (!int.TryParse(numberArray1[i], out resultNum1))
                    {
                        resultNum1 = _backwardsNumberSystem13Dictionary[numberArray1[i]];
                    }

                    result = ConvertFrom10(numberSystem, resultNum1 - resultNum2 - tmp);

                    if (result.Length > 1)
                    {
                        resultNumber.Add(string.Format($"{result[1]}"));
                        continue;
                    }

                    resultNumber.Add(result);
                    continue;
                }

                if (!int.TryParse(numberArray1[i], out resultNum1))
                {
                    resultNum1 = _backwardsNumberSystem13Dictionary[numberArray1[i]];
                }

                if (!int.TryParse(numberArray2[i], out resultNum2))
                {
                    resultNum2 = _backwardsNumberSystem13Dictionary[numberArray2[i]];
                }

                if (resultNum1 < resultNum2)
                {
                    resultNum1 += numberSystem;
                    flag = true;
                }

                result = ConvertFrom10(numberSystem, resultNum1 - resultNum2 - tmp);

                if (result.Length > 1)
                {
                    resultNumber.Add(string.Format($"{result[1]}"));
                    continue;
                }

                resultNumber.Add(result);
                tmp = 0;

                if (flag)
                {
                    tmp = 1;
                    flag = false;
                }
            }

            resultNumber.Reverse();

            return string.Join("", resultNumber);
        }
        public static string MultiplySystem13(int numberSystem, string number1, string number2)
        {
            string resultNumber;
            string[] numberArray1 = number1.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();
            string[] numberArray2 = number2.ToCharArray().Select(obj => string.Format($"{obj}")).Reverse().ToArray();

            int length1 = numberArray2.Length;
            int length2 = numberArray1.Length;

            List<string>[] numbers = new List<string>[length1];

            string tmp = "0";

            for (int j = 0; j < length1; j++)
            {
                numbers[j] = new List<string>();

                for (int k = 0; k < j; k++)
                {
                    numbers[j].Add("0");
                }

                for (int i = 0; i < length2; i++)
                {
                    int resultNum1;
                    int resultNum2;
                    string result;
                    int temp;

                    if (!int.TryParse(numberArray1[i], out resultNum1))
                    {
                        resultNum1 = _backwardsNumberSystem13Dictionary[numberArray1[i]];
                    }

                    if (!int.TryParse(numberArray2[j], out resultNum2))
                    {
                        resultNum2 = _backwardsNumberSystem13Dictionary[numberArray2[j]];
                    }

                    if (!int.TryParse(tmp, out temp))
                    {
                        temp = _backwardsNumberSystem13Dictionary[tmp];
                    }

                    result = ConvertFrom10(numberSystem, resultNum1 * resultNum2 + temp);

                    if (result.Length > 1)
                    {
                        numbers[j].Add(string.Format($"{result[1]}"));
                        tmp = string.Format($"{result[0]}");
                        continue;
                    }

                    numbers[j].Add(result);
                    tmp = "0";
                }

                if (tmp != "0")
                {
                    numbers[j].Add(tmp);
                }

                numbers[j].Reverse();
                tmp = "0";
            }

            resultNumber = string.Join("", numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                resultNumber = SumSystem13(numberSystem, string.Join("", numbers[i]), resultNumber);
            }

            return resultNumber;
        }

        public static string DivisionSystem13(int numberSystem, string number1, string number2)
        {
            List<string> resultNumber = new List<string>();
            string[] numberArray1 = number1.ToCharArray().Select(obj => string.Format($"{obj}")).ToArray();

            int length = Math.Abs(number2.Length - number1.Length) + 1;

            string resultNum1 = numberArray1[0];
            string resultNum2;
            string result;
            int i = 1;

            while (i != number1.Length)
            {
                while (ConvertTo10(numberSystem, resultNum1) / ConvertTo10(numberSystem, number2) == 0)
                {
                    resultNum1 += numberArray1[i];
                    i++;
                }

                result = ConvertFrom10(numberSystem, ConvertTo10(numberSystem, resultNum1) / ConvertTo10(numberSystem, number2));

                resultNumber.Add(result);

                resultNum2 = MultiplySystem13(numberSystem, result, number2);

                resultNum1 = MinusSystem13(numberSystem, resultNum1, resultNum2);
            }

            return string.Join("", resultNumber);
        }
    }
}
