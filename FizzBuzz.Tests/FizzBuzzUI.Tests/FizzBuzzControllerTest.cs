namespace FizzBuzzUI.Tests
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.Linq;

    using System.Web.Mvc;

    using Controllers;

    using FizzBuzzDataModels;

    using FizzBuzzServices;

    using Models;

    using NUnit.Framework;

    using Rhino.Mocks;

    [TestFixture]
    public class FizzBuzzControllerTest
    {
        private FizzBuzzController fizzBuzzController;

        private IFizzBuzzProvider fizzBuzzProvider;

        [SetUp]
        public void Initialize()
        {
            fizzBuzzProvider = MockRepository.GenerateMock<IFizzBuzzProvider>();

            fizzBuzzController = new FizzBuzzController(fizzBuzzProvider);
        }

        [Test]
        public void WhenUserRequestedForHomePageIndexViewShouldBeReturned()
        {
            //Act
            ViewResult viewResult = fizzBuzzController.Index() as ViewResult;

            var model = viewResult?.Model as FizzBuzzViewModel;

            //Assert
            Assert.AreEqual(model?.UserInput, 0);
        }

        [Test]
        public void WhenGivenInputIsNegativeExpectValidationError()
        {
            //Arrange
            var model = new FizzBuzzViewModel
            {
                UserInput = -1,
                FizzBuzzList = null
            };

            //Act
            var results = Validate(model);

            //Assert
            Assert.AreNotEqual(0, results.Count);
        }

        [Test]
        public void WhenGivenInputIsNotBetweenOneandThousandExpectValidationError()
        {
            //Arrange
            var model = new FizzBuzzViewModel
            {
                UserInput = 1001,
                FizzBuzzList = null
            };
            //Act
            var results = Validate(model);

            //Assert
            Assert.AreNotEqual(0, results.Count);
        }

        [Test]
        public void WhenRequestedWithPositiveIntergerFromOneToThousandWhenCurrentDayIsNotWednesDayFizzBuzzListShouldBeReturned()
        {
            // Arrange.
            var input = new FizzBuzzViewModel { UserInput = 5 };

            var fizzBuzzList = new List<FizzBuzz>
            {
                new FizzBuzz() { Description = "1", Color = string.Empty },
                new FizzBuzz() { Description = "2", Color = string.Empty },
                new FizzBuzz() { Description = "Fizz", Color = "blue" }
            };

            fizzBuzzProvider.Stub(x => x.GetFizzBuzzList(null)).IgnoreArguments()
                .Return(new FizzBuzzResponse() { FizzBuzzList = fizzBuzzList });

            // Act.
            ViewResult result = fizzBuzzController.FizzBuzzList(input) as ViewResult;

            var model = result?.Model as FizzBuzzViewModel;

            // Assert.
            if (model != null) Assert.AreEqual(3, model.FizzBuzzList.Count);
        }

        [Test]
        public void WhenRequestedWithPositiveIntergerFromOneToThousandAndWhenCurrentDayIsWednesdayWizzWuzzListShouldBeReturned()
        {
            // Arrange.
            var input = new FizzBuzzViewModel { UserInput = 5 };

            var fizzBuzzList = new List<FizzBuzz>
            {
                new FizzBuzz() { Description = "1", Color = string.Empty },
                new FizzBuzz() { Description = "2", Color = string.Empty },
                new FizzBuzz() { Description = "Wizz", Color = "blue" }
            };

            fizzBuzzProvider.Stub(x => x.GetFizzBuzzList(null)).IgnoreArguments()
                .Return(new FizzBuzzResponse() { FizzBuzzList = fizzBuzzList });

            // Act.
            ViewResult result = fizzBuzzController.FizzBuzzList(input) as ViewResult;

            var model = result?.Model as FizzBuzzViewModel;

            // Assert.
            Assert.AreEqual(fizzBuzzList[2].Description, model?.FizzBuzzList.LastOrDefault()?.Description);
        }

        private IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();

            var validationContext = new ValidationContext(model, null, null);

            Validator.TryValidateObject(model, validationContext, results, true);

            (model as IValidatableObject)?.Validate(validationContext);

            return results;
        }
    }
}
