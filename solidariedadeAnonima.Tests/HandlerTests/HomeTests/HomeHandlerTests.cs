using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.HomeCommand;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Handlers.Pages;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Tests.Repositories;
using Xunit;

namespace solidariedadeAnonima.Tests.HandlerTests.HomeTests
{
    public class HomeHandlerTests
    {
        private readonly IHomeRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly HomeHandler _handler;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;

        public HomeHandlerTests()
        {
            _repository = new FakeHomeRepository();
            _userRepository = new FakeUserRepository();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            SetupHttpContextAccessor();

            _handler = new HomeHandler(_repository, _httpContextAccessorMock.Object, _userRepository);
        }

        private void SetupHttpContextAccessor()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, "wesley@email.com")
            };
            var identity = new ClaimsIdentity(claims, "User");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext
            {
                User = claimsPrincipal
            };

            _httpContextAccessorMock.Setup(_ => _.HttpContext).Returns(httpContext);
        }

        private CreateCardCommand CreateValidCommand()
        {
            return new CreateCardCommand
            {
                Title = "Test Card title",
                Description = "Description tests",
                ImageLarge = "large.jpg",
                ImageOriginal = "original.jpg",
                ImagePortrait = "portrait.jpg",
                ImageLandscape = "landscape.jpg",
                ImageTiny = "tiny.jpg"
            };
        }

        [Fact]
        public async Task HandleAsync_WithValidCommand_ShouldReturnSuccessResult()
        {
            // Arrange
            var command = CreateValidCommand();

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Cards retornados com sucesso", result.Message);
            Assert.IsType<CardPrincipal>(result.Data);
        }

        [Theory]
        [InlineData("Invalid", "O Title precisa ter mais do que 10 caracteres.")]
        public async Task HandleAsync_WithInvalidCommand_ShouldReturnFailureResult(string title, string expectedMessage)
        {
            // Arrange
            var command = CreateValidCommand();
            command.Title = title;

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Payload inválido", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(command.Notifications);
            Assert.Contains(command.Notifications, n => n.Message == expectedMessage);
        }
    }
}

