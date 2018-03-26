namespace FizzBuzzServices.Tests
{
    using System;

    using System.Collections.Generic;

    using FizzBuzzDataModels;

    using FizzBuzzServices;

    using NUnit.Framework;

    using Rhino.Mocks;

    [TestFixture]
    public class FizzBuzzProviderTests
    {
        private IList<IDivisibleBy> divisibileCheckers;

        private IDivisibleBy divisibleByThreeChecker;

        private IDivisibleBy divisibleByFiveChecker;

        private FizzBuzzProvider fizzBuzzProvider;

        private IFizzBuzzDescriptionProvider fizzBuzzDescriptionProvider;

        [SetUp]
        public void Initialize()
        {
            divisibleByThreeChecker = MockRepository.GenerateMock<IDivisibleBy>();

            divisibleByFiveChecker = MockRepository.GenerateMock<IDivisibleBy>();

            fizzBuzzDescriptionProvider = MockRepository.GenerateMock<IFizzBuzzDescriptionProvider>();

            divisibileCheckers = new List<IDivisibleBy> { divisibleByThreeChecker, divisibleByFiveChecker };

            fizzBuzzProvider = new FizzBuzzProvider(divisibileCheckers, fizzBuzzDescriptionProvider);
        }

        [Test]
        public void WhenUserInputIsPositiveIntegerFromOneToThousandAndWhenCurrentDayIsWednesDayWizzWuzzShouldBeReturned()
        {
            //Arrange
            var descriptionList = new List<string> { "Wizz", "Wuzz", "Wizz Wuzz" };

            fizzBuzzDescriptionProvider.Stub(x => x.GetDescriptions(DayOfWeek.Wednesday, DayOfWeek.Wednesday)).IgnoreArguments().Return(descriptionList);

            var input = new FizzBuzzRequest() { UserInput = 5 };

            SetUpDependencies();

            fizzBuzzProvider = new FizzBuzzProvider(divisibileCheckers, fizzBuzzDescriptionProvider);

            FizzBuzzResponse expectedResponse = new FizzBuzzResponse
            {
                FizzBuzzList = new List<FizzBuzz>
                {
                    new FizzBuzz { Description = "1" },
                    new FizzBuzz { Description = "2" },
                    new FizzBuzz { Description = "Wizz" },
                    new FizzBuzz { Description = "4" },
                    new FizzBuzz { Description = "Wuzz" }
                }
            };

            //Act
            var result = fizzBuzzProvider.GetFizzBuzzList(input);

            //Assert
            Assert.AreEqual(expectedResponse.FizzBuzzList[0].Description, result.FizzBuzzList[0].Description);
        }

        [Test]
        public void WhenUserInputIsPositiveIntegerFromOneToThousandAndWhenCurrentDayIsNotWednesDayFizzBuzzListShouldBeReturned()
        {
            //Arrange
            var descriptionList = new List<string> { "Fizz", "Buzz", "Fizz Buzz" };

            fizzBuzzDescriptionProvider.Stub(x => x.GetDescriptions(DayOfWeek.Monday, DayOfWeek.Wednesday)).IgnoreArguments().Return(descriptionList);

            var input = new FizzBuzzRequest() { UserInput = 5 };

            SetUpDependencies();

            fizzBuzzProvider = new FizzBuzzProvider(divisibileCheckers, fizzBuzzDescriptionProvider);

            FizzBuzzResponse expectedResponse = new FizzBuzzResponse
            {
                FizzBuzzList = new List<FizzBuzz>
                {
                    new FizzBuzz { Description = "1" },
                    new FizzBuzz { Description = "2" },
                    new FizzBuzz { Description = "Fizz" },
                    new FizzBuzz { Description = "4" },
                    new FizzBuzz { Description = "Buzz" }
                }
            };

            //Act
            var result = fizzBuzzProvider.GetFizzBuzzList(input);

            //Assert
            Assert.AreEqual(expectedResponse.FizzBuzzList[0].Description, result.FizzBuzzList[0].Description);
        }

        private void SetUpDependencies()
        {
            // Mock for 1 to 5
            divisibleByThreeChecker.Stub(x => x.IsDivisible(1)).Return(false);
            divisibleByFiveChecker.Stub(x => x.IsDivisible(1)).Return(false);

            divisibleByThreeChecker.Stub(x => x.IsDivisible(2)).Return(false);
            divisibleByFiveChecker.Stub(x => x.IsDivisible(2)).Return(false);

            divisibleByThreeChecker.Stub(x => x.IsDivisible(3)).Return(true);
            divisibleByThreeChecker.Stub(x => x.Color).Return("blue");
            divisibleByThreeChecker.Stub(x => x.Sequence).Return(0);
            divisibleByFiveChecker.Stub(x => x.IsDivisible(3)).Return(false);

            divisibleByThreeChecker.Stub(x => x.IsDivisible(4)).Return(false);
            divisibleByFiveChecker.Stub(x => x.IsDivisible(4)).Return(false);

            divisibleByThreeChecker.Stub(x => x.IsDivisible(5)).Return(false);
            divisibleByFiveChecker.Stub(x => x.IsDivisible(5)).Return(true);
            divisibleByFiveChecker.Stub(x => x.Color).Return("green");
        }
    }
}
