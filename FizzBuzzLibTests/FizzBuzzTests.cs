using System;
using FizzBuzzLib;
using FluentAssertions;
using Xunit;

namespace FizzBuzzLibTests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void FizzBuz_Not3Not5_ReturnsNumber()
        {
            //arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            //act
            var returnedValue = fizzBuzz.Echo(2);

            //assert
            returnedValue.Should().Be("2");
        }

        [Fact]
        public void FizzBuzzEcho_WhenMultipleOf3_ReturnsStringFizz()
        {
            //arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            //act
            var returnedValue = fizzBuzz.Echo(3);

            //assert
            returnedValue.Should().Be("Fizz");
        }

        [Fact]
        public void FizzBuzzEcho_WhenMultipleOf5_ReturnsStringBuzz()
        {
            //arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            //act
            var returnedValue = fizzBuzz.Echo(5);

            //assert
            returnedValue.Should().Be("Buzz");
        }

        [Fact]
        public void FizzBuzzEcho_WhenMultipleOf3And5_ReturnsFizzBuzz()
        {
            //arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            //act
            var returnedValue = fizzBuzz.Echo(15);

            //assert
            returnedValue.Should().Be("FizzBuzz");
        }
    }
}
