using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Application.Mapper;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;

namespace TodoListApp.UnitTests.UsersTests
{
    public abstract class UserTestBase
    {
        protected IMapper CreateMapper()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return configurationProvider.CreateMapper();
        }

        protected FakeUnitOfWork CreateUnitOfWorkMock(DbContext context, IUserRepository userRepository)
        {
            return new FakeUnitOfWork(context, userRepository);
        }
    }
}
