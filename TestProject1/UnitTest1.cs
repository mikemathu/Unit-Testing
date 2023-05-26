using ExchangeRate.Web;
using System.Text.RegularExpressions;
using System;

namespace TestProject1
{
    public class UnitTest1
    {
        //Unit test for ConvertToGbp using expected arguments
        [Fact] //Marks the method as a test method
        public void ConvertToGbp_ConvertsCorrectly()
        {
            //Use Arrange, Act, Assert (AAA) style
            var converter = new CurrencyConverter(); //The “system under test” (SUT) i.e the class to test
            //The parameters of the test that will be passed
            decimal value = 3;
            decimal rate = 1.5m;
            int dp = 4;
            decimal expected = 2; //result expected
            var actual = converter.ConvertToGbp(value, rate, dp); //executes the method and captures the result
            Assert.Equal(expected, actual); //Verifies that the expected and actual values match. If they don’t, this will throw an exception.
        }

        //Theory test for ConvertToGbp testing multiple sets of values
        [Theory] //Marks the method as a parameterized test(parameterizing your test methods, effectively taking your test method and running it multiple times with different arguments. Each set of arguments is considered a different test.)
        [InlineData(0, 3, 0)]
        [InlineData(3, 1.5, 2)]
        [InlineData(3.75, 2.5, 1.5)]
        public void TheoryTest_ConvertToGbp_ConvertsCorrectly( decimal value, decimal rate, decimal expected)
        {
            var converter = new CurrencyConverter();
            int dps = 4;
            var actual = converter.ConvertToGbp(value, rate, dps); //executes system under test
            Assert.Equal(expected, actual); //verifies the results
        }


      /*  The Assert.Throws method executes the lambda and catches the exception. If the
        exception thrown matches the expected type, the test will pass. If no exception is
        thrown or the exception thrown isn’t of the expected type, the Assert.Throws
        method will throw an exception and fail the test.*/

        [Fact]
        public void ThrowsExceptionIfRateIsZero()
        {
            var converter = new CurrencyConverter();
            const decimal value = 1;
            const decimal rate = 0; //An Invalid Value
            const int dp = 2;
            var ex = Assert.Throws<ArgumentException>(() => converter.ConvertToGbp(value, rate, dp)); //The method to excecute which should throw an exception
            // Further assertions on the exception thrown, ex
        }
    }
}