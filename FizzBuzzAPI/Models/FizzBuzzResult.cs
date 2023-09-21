namespace FizzBuzzAPI.Models
{
    public class FizzBuzzResult
    {
        public List<string> Result { get; }

        public FizzBuzzResult(List<string> lines)
        {
            Result = lines;
        }
    }
}
