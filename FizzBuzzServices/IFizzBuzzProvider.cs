namespace FizzBuzzServices
{
    using FizzBuzzDataModels;

    public interface IFizzBuzzProvider
    {
        FizzBuzzResponse GetFizzBuzzList(FizzBuzzRequest input);
    }
}
