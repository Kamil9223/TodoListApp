using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Queries;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.UsersTests
{
    public class ProfileQueryHandlerTest : UserTestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public ProfileQueryHandlerTest()
        {
            _mapper = CreateMapper();

            var dbContext = new Mock<DbContext>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tasksBoardRepositoryMock = new Mock<ITasksBoardRepository>();
            var tasksRepositoryMock = new Mock<ISingleTaskRepository>();
            _fakeUnitOfWork = CreateUnitOfWorkMock(dbContext.Object, userRepositoryMock, tasksBoardRepositoryMock, tasksRepositoryMock);
        }

        [Fact]
        public async Task Should_returns_correct_mapped_profile_dto()
        {
            var profileQueryHandler = new ProfileQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.UsersMock.SetupUser();

            var result = await profileQueryHandler.Handle(new ProfileQuery
            {
                userId = 1
            }, CancellationToken.None);

            result.Email.Should().Be(UserRepositoryTestData.UserEmail);
            result.Points.Should().Be(11);
        }
    }
}
