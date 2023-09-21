using FizzBuzzAPI.Models;
using System.Text;

namespace FizzBuzzAPI.Services.FizzBuzz.Service.FizzBuzzServiceClasses
{
    public class FizzBuzzSolver : IFizzBuzzSolver
    {
        private int MaxSize { get; set; }
        private List<FizzBuzzLineInput> Inputs { get; set; }
        private List<string> ResultString { get; set; }

        public FizzBuzzSolver(FizzBuzzInput inputs)
        {
            MaxSize = inputs.MaxNumber;
            Inputs = inputs.Inputs;
            ResultString = new();
        }

        public FizzBuzzResult GetResult()
        {
            // for each line, check if we should add to the value
            for (int i = 1; i <= MaxSize; i++)
            {
                ResultString.Add(CheckInputs(i));
            }
            return new FizzBuzzResult(ResultString);
        }

        private string CheckInputs(int lineNumber)
        {
            // set up our initial string builder for the line
            var wordLine = new StringBuilder();
            wordLine.Append(lineNumber.ToString() + ": ");

            for (var i = 0; i < Inputs.Count; i++)
            {
                // if we match the value, append the word
                if (lineNumber % Inputs[i].Line == 0)
                {
                    wordLine.Append(Inputs[i].Word);
                }
            }

            return wordLine.ToString();
        }
    }
}
