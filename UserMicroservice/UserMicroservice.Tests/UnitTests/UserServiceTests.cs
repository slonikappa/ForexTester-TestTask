using Xunit;
using Moq;

using UserMicroservice.Domain.Infastructure.Interfaces;
using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Infrastructure.BusinessLogic.Services;

namespace UserMicroservice.Tests.UnitTests;

public class UserServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUsersRepository> _usersRepositoryMock;

    public UserServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _usersRepositoryMock = new Mock<IUsersRepository>();
        _unitOfWorkMock.Setup(uow => uow.UsersRepository).Returns(_usersRepositoryMock.Object);
    }

    [Fact]
    public async Task AddUserWithSubscription_Should_Add_User_To_Repository()
    {
        // Arrange
        var userService = new UserService(_unitOfWorkMock.Object);
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "johndoe@example.com",
            SubscriptionId = 1,
            Subscription = new Subscription
            {
                Id = 1,
                Type = Domain.Core.Enums.SubscriptionType.Free,
                endDate = DateTime.Now,
                startDate = DateTime.Now,
            }
        };

        _usersRepositoryMock.Setup(repo => repo.Add(user));
        _unitOfWorkMock.Setup(uow => uow.SaveChanges(It.IsAny<Action>())).Callback<Action>(a => a.Invoke());

        // Act
        await userService.AddUserWithSubscription(user);

        // Assert
        _unitOfWorkMock.Verify(uow => uow.SaveChanges(It.IsAny<Action>()), Times.Once);
        _usersRepositoryMock.Verify(repo => repo.Add(user), Times.Once);
    }

    [Fact]
    public async Task GetUsers_Should_Return_List_Of_Users_From_Repository()
    {
        // Arrange
        var userService = new UserService(_unitOfWorkMock.Object);
        var expectedUsers = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                SubscriptionId = 1
            },
            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "janesmith@example.com",
                SubscriptionId = 2
            }
        };
        _usersRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedUsers);

        // Act
        var actualUsers = await userService.GetUsers();

        // Assert
        Assert.Equal(expectedUsers, actualUsers);
        _usersRepositoryMock.Verify(repo => repo.GetAll(), Times.Once);
    }
}
