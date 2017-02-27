using System;
using System.Collections.Generic;

namespace Basics
{
    /// <summary>
    /// Here are solutions without using Linq or any other libraries in addition to those that were originally in the test
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value">String to reverse.</param>
        /// <returns>Reversed string.</returns>
        public static string ReverseString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            var reversed = new char[value.Length];
            var maxIndex = value.Length - 1;
            for (var i = maxIndex; i >= 0; i--)
            {
                reversed[maxIndex - i] = value[i];
            }
            return new string(reversed);
        }

        /// <summary>
        /// Calculates the Nth fibonacci number.
        /// </summary>
        /// <param name="n">Fibonacci number to calculate.</param>
        /// <returns>The nth fibonacci number.</returns>
        /// https://en.wikibooks.org/wiki/Algorithm_Implementation/Mathematics/Fibonacci_Number_Program#Binet.27s_formula
        public static int CalculateNthFibonacciNumber(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            var sqrt5 = Math.Sqrt(5f);
            var phi = (1 + sqrt5) / 2;
            return (int)((Math.Pow(phi, n) - Math.Pow(-phi, -n)) / sqrt5);
        }

        /// <summary>
        /// Pads a number with up to four zeroes.
        /// </summary>
        /// <param name="number">Number to pad.</param>
        /// <returns>Zero-padded number.</returns>
        /// <remarks>Can only pad unsigned numbers up to 99999.</remarks>
        public static string PadNumberWithZeroes(int number)
        {
            return number.ToString("D5");
        }

        /// <summary>
        /// Determines if a year is a leap year.
        /// </summary>
        /// <param name="year">Year to determine.</param>
        /// <returns>True if leap year, false if not.</returns>
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        /// Find the N:th largest number in a range of numbers.
        /// </summary>
        /// <param name="numbers">List of integers.</param>
        /// <returns>The third largest number in list.</returns>
        public static int FindNthLargestNumber(List<int> numbers, int nthLargestNumber)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }
            if (numbers.Count < nthLargestNumber || nthLargestNumber <= 0)
            {
                throw new IndexOutOfRangeException("The 'nthLargestNumber' must be greater than zero and less than the length of 'numbers'");
            }
            numbers.Sort();
            return numbers[nthLargestNumber - 1];
        }

        /// <summary>
        /// Selects the prime numbers from a enumerable with numbers.
        /// </summary>
        /// <param name="numbers">Enumerable with numbers.</param>
        /// <returns>An enumerable with only prime numbers.</returns>
        public static IEnumerable<int> SelectPrimeNumbers(IEnumerable<int> numbers)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                var isPrime = true;
                if (number == 1)
                {
                    isPrime = false;
                }
                else if (number == 2)
                {
                    isPrime = true;
                }
                else if (number % 2 == 0)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = 3; i < number; i += 2)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                if (isPrime)
                {
                    result.Add(number);
                }
            }
            return result;
        }

        /// <summary>
        /// Determines if the bit pattern of value the same if you reverse it.
        /// </summary>
        /// <param name="value">Value to inspect.</param>
        /// <returns>True if the bit value is a palindrome otherwise false.</returns>
        public static bool IsPalindrome(int value)
        {
            var s = Convert.ToString(value, 2);
            return s == ReverseString(s);
        }

        /// <summary>
        /// Counts all bits in an int value.
        /// </summary>
        /// <param name="value">Integer value to count bits in.</param>
        /// <returns>Number of bits in integer value.</returns>
        public static int CountSetBits(int value)
        {
            var count = 0;
            while (value != 0)
            {
                count++;
                value >>= 1;
            }
            return count;
        }
    }
}
