namespace FizzBuzzAPI.Models
{
    public class ErrorResult
    {
        public List<string> Result { get; }

        public ErrorResult(List<string> errors)
        {
            Result = errors;
        }
    }
}
