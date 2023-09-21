using System.ComponentModel.DataAnnotations;

namespace FizzBuzzAPI.Models
{
    public class FizzBuzzInput
    {
        [Required]
        [Range(1, 250, ErrorMessage = "MaxLength must be between 1 and 250")]
        public int MaxNumber { get; }
        [Required]
        [MinLength(1, ErrorMessage = "There must be at least 1 input")]
        [MaxLength(100, ErrorMessage = "There must be at no more than 100 inputs")]
        public List<FizzBuzzLineInput> Inputs { get; }

        public FizzBuzzInput()
        {
            // initialize the defaults
            MaxNumber = 100;
            Inputs = CreateDefaultInputs();
        }

        public FizzBuzzInput(int maxNumber, List<FizzBuzzLineInput> inputs)
        {
            MaxNumber = maxNumber;
            Inputs = inputs;
        }

        private List<FizzBuzzLineInput> CreateDefaultInputs()
        {
            var inputs = new List<FizzBuzzLineInput>
            {
                new FizzBuzzLineInput(3, "Fizz"),
                new FizzBuzzLineInput(5, "Buzz")
            };

            return inputs;
        }
    }
}
