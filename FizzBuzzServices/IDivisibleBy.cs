namespace FizzBuzzServices
{
    public interface IDivisibleBy
    {
        int Sequence { get; set; }

        string Color { get; set; }

        bool IsDivisible(int input);
    }
}
