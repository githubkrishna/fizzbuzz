namespace FizzBuzzServices.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DivisibleByFiveTests
    {
        [Test]
        public void WhenInputIsMultiplesOfFiveItShouldReturnTrue()
        {
            //Arrange
            var divisionChecker = new DivisibleByFive();
            //Act
            var result = divisionChecker.IsDivisible(15);
            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void WhenInputIsNotMultiplesOfFiveItShouldReturnFalse()
        {
            //Arrange
            var divisionChecker = new DivisibleByFive();
            //Act
            var result = divisionChecker.IsDivisible(8);
            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
