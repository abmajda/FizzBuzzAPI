using FizzBuzzAPI.Contracts.FizzBuzz;
using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Services.FizzBuzz.RequestProcessor
{
    public interface IFizzBuzzRequestProcessor
    {
        public FizzBuzzProcessedRequest ProcessRequest(FizzBuzzRequest? request);
    }
}
