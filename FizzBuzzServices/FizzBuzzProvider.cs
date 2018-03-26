namespace FizzBuzzServices
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using FizzBuzzDataModels;

    public class FizzBuzzProvider : IFizzBuzzProvider
    {
        private readonly IList<IDivisibleBy> fizzBuzzDivisibilityCheckers;

        private readonly IFizzBuzzDescriptionProvider fizzBuzzdescriptionProvider;

        public FizzBuzzProvider(IList<IDivisibleBy> fizzBuzzDivisibilityCheckerList, IFizzBuzzDescriptionProvider fizzBuzzDescriptionsProvider)
        {
            fizzBuzzDivisibilityCheckers = fizzBuzzDivisibilityCheckerList.OrderBy(x => x.Sequence).ToList();

            fizzBuzzdescriptionProvider = fizzBuzzDescriptionsProvider;
        }

        public FizzBuzzResponse GetFizzBuzzList(FizzBuzzRequest input)
        {
            var fizzBuzzList = new List<FizzBuzz>();

            for (var number = 1; number <= input.UserInput; number++)
            {
                fizzBuzzList.Add(GetFizzBuzz(number));
            }

            return new FizzBuzzResponse()
            {
                FizzBuzzList = fizzBuzzList
            };
        }

        private FizzBuzz GetFizzBuzz(int input)
        {
            var numberOfRulesPassed = 0;

            var fizzBuzzDescriptions = fizzBuzzdescriptionProvider.GetDescriptions(DateTime.Today.DayOfWeek, DayOfWeek.Wednesday);

            var textColor = string.Concat(fizzBuzzDivisibilityCheckers[0].Color, " ", fizzBuzzDivisibilityCheckers[1].Color);

            var fizzBuzz = new FizzBuzz() { Description = input.ToString(), Color = string.Empty };

            for (var counter = 0; counter < fizzBuzzDivisibilityCheckers.Count; counter++)
            {
                if (fizzBuzzDivisibilityCheckers[counter].IsDivisible(input))
                {
                    fizzBuzz.Description = fizzBuzzDescriptions[counter];

                    fizzBuzz.Color = fizzBuzzDivisibilityCheckers[counter].Color;

                    numberOfRulesPassed++;
                }
            }

            if (numberOfRulesPassed <= 1) { return fizzBuzz; }

            fizzBuzz.Description = fizzBuzzDescriptions[numberOfRulesPassed];

            fizzBuzz.Color = textColor;

            return fizzBuzz;
        }
    }
}
