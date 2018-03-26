namespace FizzBuzzServices
{
    public class DivisibleByThree : IDivisibleBy
    {
        public DivisibleByThree()
        {
            Sequence = 1;

            Color = "blue";
        }

        public int Sequence { get; set; }

        public string Color { get; set; }

        public bool IsDivisible(int input)
        {
            return input % 3 == 0;
        }
    }
}
