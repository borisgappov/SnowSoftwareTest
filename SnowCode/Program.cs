using Basics;
using System;
using System.Linq;

namespace SnowCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- ReverseString -------");
            Console.Write("Source: 'erawtfoS wonS', result: ");
            Console.WriteLine(Functions.ReverseString("erawtfoS wonS"));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- CalculateNthFibonacciNumber -------");
            var number = 6;
            Console.WriteLine(string.Format("Fibonacci({0}) is {1}", number, Functions.CalculateNthFibonacciNumber(number)));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- PadNumberWithZeroes -------");
            number = 5;
            Console.WriteLine(string.Format("Zero filled {0} is {1}", number, Functions.PadNumberWithZeroes(5)));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- IsLeapYear -------");
            var year = 2020;
            Console.WriteLine(string.Format("The year {0} is {1}leap", year, Functions.IsLeapYear(year) ? string.Empty : "not "));
            year = 2022;
            Console.WriteLine(string.Format("The year 2022 is {1}leap", year, Functions.IsLeapYear(year) ? string.Empty : "not "));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- FindNthLargestNumber -------");
            var sequence = new[] { 4, 3, 5, 1, 2 };
            Console.WriteLine(string.Format("3-th largest number of sequence [{0}] is {1}",
                string.Join(", ", sequence),
                Functions.FindNthLargestNumber(sequence.ToList(), 3)));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- SelectPrimeNumbers -------");
            int min = 0, max = 10;
            Console.WriteLine(string.Format("The prime numbers in an array from {0} to {1} is [{2}]",
                min, max,
                string.Join(", ", Functions.SelectPrimeNumbers(Enumerable.Range(min, max)))));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- IsPalindrome -------");
            number = 9;
            Console.WriteLine(string.Format("The number {0} ({1}) is {2}palindrome",
                number, Convert.ToString(number, 2), Functions.IsPalindrome(number) ? string.Empty : "not "));
            number = 11;
            Console.WriteLine(string.Format("The number {0} ({1}) is {2}palindrome",
                number, Convert.ToString(number, 2), Functions.IsPalindrome(number) ? string.Empty : "not "));

            Console.WriteLine(string.Empty);
            Console.WriteLine("------- CountSetBits -------");
            number = 123;
            Console.WriteLine(string.Format("Number of bits in {0} ({1}) is {2}",
                number, Convert.ToString(number, 2), Functions.CountSetBits(number)));

            Console.Read();
        }
    }
}
