namespace FizzBuzzServices
{
    public class DivisibleByFive : IDivisibleBy
    {
        public DivisibleByFive()
        {
            Sequence = 2;

            Color = "green";
        }

        public int Sequence { get; set; }

        public string Color { get; set; }

        public bool IsDivisible(int input)
        {
            return input % 5 == 0;
        }
    }
}
