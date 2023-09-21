using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services.FizzBuzz.Service.FizzBuzzServiceClasses;

namespace FizzBuzzAPI.Services.FizzBuzz.Service
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public FizzBuzzResult SolveFizzBuzz(FizzBuzzInput inputs)
        {
            /*
             * utilize a new solver to fetch the results. This is a little empty here, 
             * but the design is that if it needs to be it can be expanded quite easily at this point
             * */
            IFizzBuzzSolver solver = new FizzBuzzSolver(inputs);
            return solver.GetResult();
        }
    }
}
