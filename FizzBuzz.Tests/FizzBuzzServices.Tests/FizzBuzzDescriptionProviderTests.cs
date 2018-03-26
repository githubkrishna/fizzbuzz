namespace FizzBuzzServices.Tests
{
    using System;

    using FizzBuzzServices;

    using NUnit.Framework;

    [TestFixture]
    public class FizzBuzzDescriptionProviderTests
    {
        [Test]
        public void WhenCurrentDayIsNotWednesdayDescriptionProviderShouldReturnFizzBuzzList()
        {
            //Arrange
            var descriptionProvider = new FizzBuzzDescriptionProvider();

            //Act
            var result = descriptionProvider.GetDescriptions(DayOfWeek.Monday, DayOfWeek.Wednesday);

            //Assert
            Assert.AreEqual(result[0], "Fizz");
        }

        [Test]
        public void WhenCurrentDayIsWednesdayDescriptionProviderShouldReturnWizzWuzzList()
        {
            //Arrange
            var descriptionProvider = new FizzBuzzDescriptionProvider();

            //Act
            var result = descriptionProvider.GetDescriptions(DayOfWeek.Wednesday, DayOfWeek.Wednesday);

            //Assert
            Assert.AreNotEqual(result[0], "Fizz");
        }
    }
}
