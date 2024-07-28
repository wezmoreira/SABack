using Moq;
using solidariedadeAnonima.Domain.Commands.UserCommand;
using solidariedadeAnonima.Domain.Handlers.Pages;
using solidariedadeAnonima.Domain.Interfaces;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Tests.HandlerTests.RegisterTests
{
    public class RegisterHandlerTests
    {
        private readonly RegisterHandler _handler;
        private readonly IRegisterRepository _registerRepository;

        public RegisterHandlerTests()
        {
            _registerRepository = new FakeRegisterRepository();

            _handler = new RegisterHandler(_registerRepository);
        }

        private CreateUserCommand CreateValidCommand()
        {
            return new CreateUserCommand
            {
                Email = "wesley@email.com",
                Username = "wesley",
                Password = "123456",
                City = "Maringá",
                Address = "Rua dos Bobos",
                State = "PR",
                Cep = "123456",
                Number = "123",
            };
        }

        [Fact]
        public async Task HandleAsync_WhenValidCommand_ReturnsSuccessResult()
        {
            // Arrange
            var command = CreateValidCommand();

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Usuario criado com sucesso", result.Message);
            Assert.True((bool)result.Data);
        }

        [Theory]
        [InlineData("1", "O Password precisa ter mais do que 5 caracteres", "Algo deu errado, não foi possível criar usuário")]
        public async Task HandleAsync_WhenInvalidCommand_ReturnsFailureResult(string password, string expectedCommandMessage, string expectedReturnMessage)
        {
            // Arrange
            var command = CreateValidCommand();
            command.Password = password;

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(expectedReturnMessage, result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(command.Notifications);
            Assert.Contains(command.Notifications, n => n.Message == expectedCommandMessage);
        }
    }
}
