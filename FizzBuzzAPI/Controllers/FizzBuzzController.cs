using FizzBuzzAPI.Contracts.FizzBuzz;
using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services.FizzBuzz.RequestProcessor;
using FizzBuzzAPI.Services.FizzBuzz.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("V1/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;
        private readonly IFizzBuzzRequestProcessor _fizzBuzzRequestProcessor;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService, IFizzBuzzRequestProcessor fizzBuzzRequestProcessor)
        {
            _fizzBuzzService = fizzBuzzService;
            _fizzBuzzRequestProcessor = fizzBuzzRequestProcessor;
        }

        /// <summary>
        /// Takes in a request object and generates a solve for the provided fizzbuzz configuration. If none is sent in, default fizzbuzz will be used
        /// </summary>
        /// <returns> An object containg a list of string called result. If an error occurs there will be a list of strings containing the violations</returns>
        [HttpPost()]
        public IActionResult GetFizzBuzz(FizzBuzzRequest? request)
        {
            // reassign to internal model
            var processedRequest = _fizzBuzzRequestProcessor.ProcessRequest(request);
            var fizzBuzzInputs = processedRequest.Input;

            // log the input
            Log.Information("V1/FizzBuzz POST called with parameters: {@request}", request);

            // handle errors
            if (processedRequest.Errors.Count > 0)
            {
                var errors = processedRequest.Errors;
                var result = new ErrorResult(errors);

                // log the errors
                Log.Information("V1/FizzBuzz POST response with parameters: {@result}", result);

                return BadRequest(result);
            }

            // Solve fizzbuzz
            try
            {
                var result = _fizzBuzzService.SolveFizzBuzz(fizzBuzzInputs);

                // log the output
                Log.Information("V1/FizzBuzz POST called with parameters: {@result}", result);

                return Ok(result);
            } 
            catch (Exception ex)
            {
                Log.Error("V1/FizzBuzz POST called with parameters: {@request} and failed with with expection {@ex}", request, ex);
                return Problem("There was an internal server error");
            }
        }
    }
}
