using FizzBuzzAPI.Models;
using FizzBuzzAPI.Services.FizzBuzz.Service.FizzBuzzServiceClasses;

namespace FizzBuzz.Tests.V1.Tests
{
    public class FizzBuzzSolverTests
    {
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void FizzBuzzSolver_VariableMaxNumberInput_ReturnsExpectedNumberOfRows(int maxNumber)
        {
            // Arrange
            var values = new List<FizzBuzzLineInput>();
            values.Add(new FizzBuzzLineInput(3, "Fizz"));
            values.Add(new FizzBuzzLineInput(5, "Buzz"));
            var input = new FizzBuzzInput(maxNumber, values);

            // Act
            var solver = new FizzBuzzSolver(input);
            var result = solver.GetResult();

            // Assert
            Assert.Equal(maxNumber, result.Result.Count);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void FizzBuzzSolver_VariableIntervalInput_ReturnsExpectedNumberOfRows(int interval)
        {
            // Arrange
            string testValue = "A";

            var values = new List<FizzBuzzLineInput>();
            values.Add(new FizzBuzzLineInput(interval, testValue));
            var input = new FizzBuzzInput(10, values);

            // Act
            var solver = new FizzBuzzSolver(input);
            var result = solver.GetResult();

            bool correct = false;
            // look through each line
            for (var  i = 0; i < result.Result.Count; i++)
            {
                if ((i + 1) % interval == 0)
                {
                    if (result.Result[i].Contains(testValue))
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                        break;
                    }
                }
                else
                {
                    if (result.Result[i].Contains(testValue))
                    {
                        correct = false;
                        break;
                    }
                }
            }

            // Assert
            Assert.True(correct);
        }
    }
}
