namespace FizzBuzzServices
{
    using System;

    using System.Collections.Generic;

    public interface IFizzBuzzDescriptionProvider
    {
        IList<string> GetDescriptions(DayOfWeek currentDay, DayOfWeek restrictedDayOfWeek);
    }
}
