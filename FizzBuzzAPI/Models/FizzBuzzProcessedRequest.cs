namespace FizzBuzzAPI.Models
{
    public class FizzBuzzProcessedRequest
    {
        public FizzBuzzInput Input { get; }
        public List<string> Errors { get; }

        public FizzBuzzProcessedRequest(FizzBuzzInput input, List<string> errors)
        {
            Input = input;
            Errors = errors;
        }
    }
}
