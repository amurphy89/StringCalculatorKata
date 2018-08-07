using System;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorTests
{
    [TestFixture]
    public class UnitTest1
    {
        private StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void Add_Zero_Numbers_Return_Zero()
        {
            int result = _calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_One_Number_Return_Input_Number()
        {
            int result = _calculator.Add("3");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_Two_Numbers_Return_Sum()
        {
            int result = _calculator.Add("2,3");

            Assert.AreEqual(5, result);
        }

        [TestCase("3,4,5", 12)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("10,20,30,40,50", 150)]
        public void Add_Multiple_Inputs_Return_Sum(string input, int expected)
        {
            int result =_calculator.Add(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Allow_Newline_Delimiter_Return_Sum()
        {
            int result = _calculator.Add("1\n2, 3");

            Assert.AreEqual(6, result);
        }

        [TestCase("//:\n1:2", 3)]
        [TestCase("//.\n1.2", 3)]
        [TestCase("//@\n1,2\n1@2", 6)]
        public void Add_User_Defined_Delimiter_Return_Sum(string input, int expected)
        {
            int result = _calculator.Add(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Negative_Number_Throw_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add("-100"));
            Assert.That(ex.Message, Is.EqualTo("Specified argument was out of the range of valid values."));
        }

        [Test]
        public void Add_Numbers_Over_1000_Return_Sum_Ignore_Numbers_Over_1000()
        {
            int result = _calculator.Add("2,1001");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void Add_Multiple_User_Delimiters_Return_Sum()
        {
            int result = _calculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, result);
        }
    }
}
