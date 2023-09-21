using FizzBuzzAPI.Contracts.FizzBuzz;
using FizzBuzzAPI.Services.FizzBuzz.RequestProcessor;
using System.Text;

namespace FizzBuzz.Tests.V1.Tests
{
    public class FizzBussRequestProcessorTests
    {
        [Fact]
        public void FizzBuzzProcessor_CorrectInputs_ReturnsNoErrors()
        {
            // Arrange

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(null);

            // Assert
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_IncorrectMaxSize_ReturnsErrors()
        {
            // Arrange
            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(3, "Fizz"));
            values.Add(new FizzBuzzRequestLine(5, "Buzz"));
            FizzBuzzRequest input = new FizzBuzzRequest(500, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_InputsSizeTooLarge_ReturnsErrors()
        {
            // Arrange
            var values = new List<FizzBuzzRequestLine>();

            // create a too large input
            for (int i = 0; i < 101; i++)
            {
                values.Add(new FizzBuzzRequestLine(1, "test"));
            }
            FizzBuzzRequest input = new FizzBuzzRequest(100, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_InputsSizeTooSmall_ReturnsErrors()
        {
            // Arrange
            var values = new List<FizzBuzzRequestLine>();
            FizzBuzzRequest input = new FizzBuzzRequest(100, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_LineNumberIncorrect_ReturnsErrors()
        {
            // Arrange
            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(500, "Fizz"));
            values.Add(new FizzBuzzRequestLine(-3, "Buzz"));
            FizzBuzzRequest input = new FizzBuzzRequest(100, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_LineWordTooSmall_ReturnsErrors()
        {
            // Arrange
            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(3, ""));
            values.Add(new FizzBuzzRequestLine(5, "Buzz"));
            FizzBuzzRequest input = new FizzBuzzRequest(100, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FizzBuzzProcessor_LineWordTooLarge_ReturnsErrors()
        {
            // Arrange
            var largeWord = new StringBuilder();
            for (int i = 0; i < 100; i++) 
            {
                largeWord.Append("This will be a very large word");
            }
            var finalWord = largeWord.ToString();

            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(3, finalWord));
            values.Add(new FizzBuzzRequestLine(5, "Buzz"));
            FizzBuzzRequest input = new FizzBuzzRequest(100, values);

            // Act
            FizzBuzzRequestProcessor processor = new FizzBuzzRequestProcessor();
            var result = processor.ProcessRequest(input);

            // Assert
            Assert.NotEmpty(result.Errors);
        }
    }
}
