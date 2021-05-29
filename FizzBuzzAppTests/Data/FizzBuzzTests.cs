using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApp.Data.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void GenerateFizzBuzzThree()
        {
            var number = 3;
            var fizzBuzz = FizzBuzz.FizzBuzzGenerator(number);

            Assert.AreEqual("fizz", fizzBuzz);
        }

        [TestMethod]
        public void GenerateFizzBuzzFive()
        {
            var number = 5;
            var fizzBuzz = FizzBuzz.FizzBuzzGenerator(number);

            Assert.AreEqual("buzz", fizzBuzz);
        }

        [TestMethod]
        public void GenerateFizzBuzzFifteen()
        {
            var number = 15;
            var fizzBuzz = FizzBuzz.FizzBuzzGenerator(number);

            Assert.AreEqual("fizz buzz", fizzBuzz);
        }

        [TestMethod]
        public void GenerateFizzBuzzNotDivisible()
        {
            var number = 11;
            var fizzBuzz = FizzBuzz.FizzBuzzGenerator(number);

            Assert.AreEqual(number.ToString(), fizzBuzz);
        }

        [TestMethod]
        public void GenerateFizzBuzzNegative()
        {
            var number = -1;
            var fizzBuzz = FizzBuzz.GetFizzBuzz(number);

            Assert.AreEqual("negative", fizzBuzz[0]);
        }

        [TestMethod]
        public void FizzCount()
        {
            var fizzBuzz = FizzBuzz.GetFizzBuzz();

            Assert.AreEqual(27, fizzBuzz.Count(f => f == "fizz"));
        }

        [TestMethod]
        public void BuzzCount()
        {
            var fizzBuzz = FizzBuzz.GetFizzBuzz();

            Assert.AreEqual(14, fizzBuzz.Count(f => f == "buzz"));
        }

        [TestMethod]
        public void FizzBuzzCount()
        {
            var fizzBuzz = FizzBuzz.GetFizzBuzz();

            Assert.AreEqual(6, fizzBuzz.Count(f => f == "fizz buzz"));
        }

        [TestMethod]
        public void FizzBuzzTotalCount()
        {
            var fizzBuzz = FizzBuzz.GetFizzBuzz();

            Assert.AreEqual(100, fizzBuzz.Count);
        }
    }
}