using FizzBuzzAPI.Models;
using System.ComponentModel.DataAnnotations;
using FizzBuzzAPI.Contracts.FizzBuzz;

namespace FizzBuzzAPI.Services.FizzBuzz.RequestProcessor
{
    public class FizzBuzzRequestProcessor : IFizzBuzzRequestProcessor
    {
        public FizzBuzzProcessedRequest ProcessRequest(FizzBuzzRequest? request)
        {
            // set up the returns
            var errors = new List<string>();
            FizzBuzzInput input;

            if (request == null)
            {
                input = new FizzBuzzInput();
            }
            else
            {
                // store validation errors
                ICollection<ValidationResult> lineValidationErrors = new List<ValidationResult>();

                // convert the inputs to our internal classes
                var inputs = new List<FizzBuzzLineInput>();
                for (var i = 0; i < request.Inputs.Count; i++)
                {
                    var requestInput = request.Inputs[i];
                    var lineInput = new FizzBuzzLineInput(requestInput.Line, requestInput.Word);
                    inputs.Add(lineInput);

                    // validate the input
                    Validator.TryValidateObject(lineInput, new ValidationContext(lineInput), lineValidationErrors, true);

                    // add each line with its number
                    foreach (var error in lineValidationErrors)
                    {
                        if (error.ErrorMessage != null)
                        {
                            errors.Add("Input " + i + ": " + error.ErrorMessage);
                        }
                    }

                    // reset for the next one
                    lineValidationErrors = new List<ValidationResult>();
                }

                // create our final internal model
                input = new FizzBuzzInput(request.MaxNumber, inputs);

                // create storage for highter level validation errors
                ICollection<ValidationResult> validationErrors = new List<ValidationResult>();

                // ensure validation
                Validator.TryValidateObject(input, new ValidationContext(input), validationErrors, true);

                foreach (var error in validationErrors)
                {
                    if (error.ErrorMessage != null)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }

            // return the processed request
            return new FizzBuzzProcessedRequest(input, errors);
        }
    }
}
