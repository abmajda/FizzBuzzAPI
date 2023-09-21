using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Services.FizzBuzz.Service
{
    public interface IFizzBuzzService
    {
        FizzBuzzResult SolveFizzBuzz(FizzBuzzInput input);
    }
}
