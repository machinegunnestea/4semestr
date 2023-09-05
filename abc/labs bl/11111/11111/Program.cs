using System;
using static System.Console;

namespace _11111
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSystem;
            string number;
            string number2;
            int number10;
            Write("Input system: ");
            numberSystem = InputClass.GetInputInt();

            Write($"Input number in {numberSystem} system: ");
            number = InputClass.GetInputNumber13();
            WriteLine($"Convert to dec from {numberSystem}: {Converter.ConvertTo10(numberSystem, number)}");

            Write("Input number in 10 system: ");
            number10 = InputClass.GetInputInt();
            WriteLine($"Convert to {numberSystem} from 10: {Converter.ConvertFrom10(numberSystem, number10)}");

            Write("Input number in 2 system: ");
            number = InputClass.GetInputNumberBinary();
            WriteLine($"Convert to 16 from 2: {Converter.ConvertFrom2To16(number)}");

            Write($"Input number in 8 system: ");
            number = InputClass.GetInputNumberOctal();
            WriteLine($"Convert to 2 from 8: {Converter.ConvertFrom8To2(number)}");

            Write($"Input two numbers in {numberSystem} system: ");
            number = InputClass.GetInputNumber13();
            number2 = InputClass.GetInputNumber13();
            WriteLine($"Sum {number} + {number2}: {Converter.SumSystem13(numberSystem, number, number2)}");
            WriteLine($"Difference {number} - {number2}: {Converter.MinusSystem13(numberSystem, number, number2)}");
            WriteLine($"Multiply {number} * {number2}: {Converter.MultiplySystem13(numberSystem, number, number2)}");
            WriteLine($"Division {number} / {number2}: {Converter.DivisionSystem13(numberSystem, number, number2)}");
            ReadKey();
        }
    }
}
