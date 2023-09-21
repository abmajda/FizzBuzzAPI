namespace FizzBuzzAPI.Contracts.FizzBuzz
{
    public record FizzBuzzRequest(
        int MaxNumber,
        List<FizzBuzzRequestLine> Inputs
    );

    public record FizzBuzzRequestLine(
        int Line,
        string Word
    );
}
