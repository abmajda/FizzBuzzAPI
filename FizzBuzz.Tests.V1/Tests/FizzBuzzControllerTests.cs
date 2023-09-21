using FizzBuzzAPI.Services.FizzBuzz.Service;
using FizzBuzzAPI.Services.FizzBuzz.RequestProcessor;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzAPI.Contracts.FizzBuzz;
using FizzBuzzAPI.Controllers;

namespace FizzBuzz.Tests.V1.Tests
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public void GetFizzBuzz_InputIsNull_ReturnsSuccess()
        {
            // Arrange
            var controller = new FizzBuzzController(new FizzBuzzService(), new FizzBuzzRequestProcessor());

            // Act
            var result = controller.GetFizzBuzz(null);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetFizzBuzz_InputIsNormal_ReturnsSuccess()
        {
            // Arrange
            var controller = new FizzBuzzController(new FizzBuzzService(), new FizzBuzzRequestProcessor());
            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(3, "hello"));
            values.Add(new FizzBuzzRequestLine(6, "world"));
            var request = new FizzBuzzRequest(100, values);

            // Act
            var result = controller.GetFizzBuzz(request);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetFizzBuzz_InputIsInvalid_ReturnsBadInput()
        {
            // Arrange
            var controller = new FizzBuzzController(new FizzBuzzService(), new FizzBuzzRequestProcessor());
            var values = new List<FizzBuzzRequestLine>();
            values.Add(new FizzBuzzRequestLine(-12, "hello"));
            values.Add(new FizzBuzzRequestLine(6, ""));
            var request = new FizzBuzzRequest(9000, values);

            // Act
            var result = controller.GetFizzBuzz(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
