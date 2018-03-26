namespace FizzBuzzServices.Tests
{
    using FizzBuzzServices;

    using NUnit.Framework;

    [TestFixture]
    public class DivisbleByThreeTests
    {
        [Test]
        public void WhenInputIsMultiplesOfThreeItShouldReturnTrue()
        {
            //Arrange
            var divisionChecker = new DivisibleByThree();
            //Act
            var result = divisionChecker.IsDivisible(9);
            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void WhenInputIsNotMultiplesOfThreeItShouldReturnFalse()
        {
            //Arrange
            var divisionChecker = new DivisibleByThree();
            //Act
            var result = divisionChecker.IsDivisible(8);
            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
