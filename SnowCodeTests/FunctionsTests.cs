using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Basics.Tests
{
    [TestClass()]
    public class FunctionsTests
    {
        [TestMethod()]
        public void ReverseStringTest()
        {
            Assert.IsTrue(Functions.ReverseString("erawtfoS wonS") == "Snow Software");
            Assert.IsTrue(Functions2.ReverseString("erawtfoS wonS") == "Snow Software");
        }

        [TestMethod()]
        public void CalculateNthFibonacciNumberTest()
        {
            Assert.IsTrue(Functions.CalculateNthFibonacciNumber(0) == 0);
            Assert.IsTrue(Functions.CalculateNthFibonacciNumber(1) == 1);
            int a = 0,
                b = 1,
                fib = 1,
                n = 2,
                maxN;
            while (fib > 0) // when overflows the value becomes negative
            {
                fib = a + b;
                a = b;
                b = fib;
                if (fib > 0 && Functions.CalculateNthFibonacciNumber(n++) != fib)
                {
                    Assert.Fail();
                }
            }
            maxN = n;

            Assert.IsTrue(Functions2.CalculateNthFibonacciNumber(0) == 0);
            Assert.IsTrue(Functions2.CalculateNthFibonacciNumber(1) == 1);
            a = 0;
            b = 1;
            fib = 1;
            n = 2;
            while (n < maxN)
            {
                fib = a + b;
                a = b;
                b = fib;
                if (Functions2.CalculateNthFibonacciNumber(n++) != fib)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void PadNumberWithZeroesTest()
        {
            Assert.IsTrue(Functions.PadNumberWithZeroes(5) == "00005");
            Assert.IsTrue(Functions.PadNumberWithZeroes(15) == "00015");
            Assert.IsTrue(Functions.PadNumberWithZeroes(9999) == "09999");
            Assert.IsTrue(Functions.PadNumberWithZeroes(99999) == "99999");
            Assert.IsTrue(Functions2.PadNumberWithZeroes(5) == "00005");
            Assert.IsTrue(Functions2.PadNumberWithZeroes(15) == "00015");
            Assert.IsTrue(Functions2.PadNumberWithZeroes(9999) == "09999");
            Assert.IsTrue(Functions2.PadNumberWithZeroes(99999) == "99999");
        }

        [TestMethod()]
        public void IsLeapYearTest()
        {
            foreach (var year in Enumerable.Range(DateTime.MinValue.Year, DateTime.MaxValue.Year - DateTime.MinValue.Year + 1))
            {
                if (Functions.IsLeapYear(year) != DateTime.IsLeapYear(year) ||
                   Functions2.IsLeapYear(year) != DateTime.IsLeapYear(year))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FindNthLargestNumberTest()
        {
            Assert.IsTrue(Functions.FindNthLargestNumber(new[] { 1, 4, 2, 5, 3 }.ToList(), 4) == 4);
            Assert.IsTrue(Functions2.FindNthLargestNumber(new[] { 1, 4, 2, 5, 3 }.ToList(), 4) == 4);
        }

        [TestMethod()]
        public void SelectPrimeNumbersTest()
        {
            var numbers = Enumerable.Range(2, 1000);

            var prime = numbers.AsParallel().Select(x =>
                {
                    for (int i = 2; i <= x / 2; i++)
                    {
                        if (i == x)
                            i = i + 1;
                        if (x % i == 0)
                        {
                            return -1;
                        }
                    }
                    return x;
                }).Where(x => x > 0).OrderBy(x => x).ToArray();

            Assert.IsTrue(prime.SequenceEqual(Functions.SelectPrimeNumbers(numbers)));
            Assert.IsTrue(prime.SequenceEqual(Functions2.SelectPrimeNumbers(numbers)));

        }

        [TestMethod()]
        public void IsPalindromeTest()
        {
            var a = 9; // 1001
            var b = 11; // 1011
            Assert.IsTrue(Functions.IsPalindrome(a));
            Assert.IsFalse(Functions.IsPalindrome(b));
            Assert.IsTrue(Functions2.IsPalindrome(a));
            Assert.IsFalse(Functions2.IsPalindrome(b));
        }

        [TestMethod()]
        public void CountSetBitsTest()
        {
            var a = 123;  // 1111011
            var b = 456;  // 111001000
            var c = 1000; // 1111101000
            Assert.IsTrue(Functions.CountSetBits(a) == 7);
            Assert.IsTrue(Functions.CountSetBits(b) == 9);
            Assert.IsTrue(Functions.CountSetBits(c) == 10);
            Assert.IsTrue(Functions2.CountSetBits(a) == 7);
            Assert.IsTrue(Functions2.CountSetBits(b) == 9);
            Assert.IsTrue(Functions2.CountSetBits(c) == 10);
        }
    }
}