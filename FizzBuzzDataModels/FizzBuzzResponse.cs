namespace FizzBuzzDataModels
{
    using System.Collections.Generic;

    public class FizzBuzzResponse
    {
        public string ErrorMessage { get; set; }

        public IList<FizzBuzz> FizzBuzzList { get; set; }
    }
}
