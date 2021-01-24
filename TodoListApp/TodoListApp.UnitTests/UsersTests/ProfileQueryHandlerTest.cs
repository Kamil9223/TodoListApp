using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Queries;
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
            var userRepositoryMock = UserRepositoryMock.Create();
            _fakeUnitOfWork = CreateUnitOfWorkMock(dbContext.Object, userRepositoryMock.Object);
        }

        [Fact]
        public async Task Should_return_correct_mapped_profile_dto()
        {
            var profileQueryHandler = new ProfileQueryHandler(_fakeUnitOfWork, _mapper);

            var result = await profileQueryHandler.Handle(new ProfileQuery
            {
                userId = 1
            }, CancellationToken.None);

            result.Email.Should().Be(UserRepositoryMock.UserEmail);
        }
    }
}
