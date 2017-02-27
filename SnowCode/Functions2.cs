using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;

namespace Basics
{
    /// <summary>
    /// In this class contains solutions are created using Linq and other libraries
    /// </summary>
    public class Functions2
    {
        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value">String to reverse.</param>
        /// <returns>Reversed string.</returns>
        public static string ReverseString(string value)
        {
            return new string(value.Reverse().ToArray());
        }

        /// <summary>
        /// Calculates the Nth fibonacci number.
        /// </summary>
        /// <param name="n">Fibonacci number to calculate.</param>
        /// <returns>The nth fibonacci number.</returns>
        /// https://en.wikibooks.org/wiki/Algorithm_Implementation/Mathematics/Fibonacci_Number_Program#Alternate_exponentiation_by_squaring
        public static int CalculateNthFibonacciNumber(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            int i = n - 1, a = 1, b = 0, c = 0, d = 1, t;
            while (i > 0)
            {
                while (i % 2 == 0)
                {
                    t = d * (2 * c + d);
                    c = c * c + d * d;
                    d = t;
                    i = i / 2;
                }
                t = d * (b + a) + c * b;
                a = d * b + c * a;
                b = t;
                i--;
            }
            return a + b;
        }

        /// <summary>
        /// Pads a number with up to four zeroes.
        /// </summary>
        /// <param name="number">Number to pad.</param>
        /// <returns>Zero-padded number.</returns>
        /// <remarks>Can only pad unsigned numbers up to 99999.</remarks>
        public static string PadNumberWithZeroes(int number)
        {
            return number.ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// Determines if a year is a leap year.
        /// </summary>
        /// <param name="year">Year to determine.</param>
        /// <returns>True if leap year, false if not.</returns>
        public static bool IsLeapYear(int year)
        {
            DateTime dt;

            DateTime.TryParseExact(string.Format("{0:0000}-29-02", year),
                                   "yyyy-dd-MM",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dt);

            return dt != DateTime.MinValue;
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
            return numbers.OrderBy(x => x).Take(nthLargestNumber).Last();
        }

        /// <summary>
        /// Selects the prime numbers from a enumerable with numbers.
        /// </summary>
        /// <param name="numbers">Enumerable with numbers.</param>
        /// <returns>An enumerable with only prime numbers.</returns>
        public static IEnumerable<int> SelectPrimeNumbers(IEnumerable<int> numbers)
        {
            return numbers.AsParallel().Where(x =>
            {
                if (x == 1) return false;
                if (x == 2) return true;
                if (x % 2 == 0) return false;
                for (int i = 3; i < x; i += 2) if (x % i == 0) return false;
                return true;
            }).OrderBy(x => x).ToArray();
        }

        /// <summary>
        /// Determines if the bit pattern of value the same if you reverse it.
        /// </summary>
        /// <param name="value">Value to inspect.</param>
        /// <returns>True if the bit value is a palindrome otherwise false.</returns>
        public static bool IsPalindrome(int value)
        {
            var bits = new BitArray(BitConverter.GetBytes(value)).Cast<bool>().ToArray();
            bits = bits.Take(Array.FindLastIndex(bits, x => x) + 1).ToArray();
            return bits.SequenceEqual(bits.Reverse());
        }

        /// <summary>
        /// Counts all bits in an int value.
        /// </summary>
        /// <param name="value">Integer value to count bits in.</param>
        /// <returns>Number of bits in integer value.</returns>
        public static int CountSetBits(int value)
        {
            return Array.FindLastIndex(new BitArray(BitConverter.GetBytes(value)).Cast<bool>().ToArray(), x => x) + 1;
        }
    }
}
