using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using TodoListApp.Application.Mapper;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;

namespace TodoListApp.UnitTests
{
    public abstract class TestBase
    {
        protected IMapper CreateMapper()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return configurationProvider.CreateMapper();
        }

        protected FakeUnitOfWork CreateUnitOfWorkMock()
        {
            return new FakeUnitOfWork(
                new Mock<DbContext>().Object,
                new Mock<IUserRepository>(),
                new Mock<ITasksBoardRepository>(),
                new Mock<ISingleTaskRepository>());
        }
    }
}
