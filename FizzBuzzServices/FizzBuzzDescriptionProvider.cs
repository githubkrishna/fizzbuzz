namespace FizzBuzzServices
{
    using System;

    using System.Collections.Generic;

    public class FizzBuzzDescriptionProvider : IFizzBuzzDescriptionProvider
    {
        public IList<string> GetDescriptions(DayOfWeek currentDayOfWeek, DayOfWeek restricteDayOfWeek)
        {
            return (currentDayOfWeek == restricteDayOfWeek) ? new List<string> { "Wizz", "Wuzz", "Wizz Wuzz" } : new List<string> { "Fizz", "Buzz", "Fizz Buzz" };
        }
    }
}
