using AutoMapper;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Queries;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.UsersTests
{
    public class ProfileQueryHandlerTest : TestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public ProfileQueryHandlerTest()
        {
            _mapper = CreateMapper();
            _fakeUnitOfWork = CreateUnitOfWorkMock();
        }

        [Fact]
        public async Task Should_returns_correct_mapped_profileDto()
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
