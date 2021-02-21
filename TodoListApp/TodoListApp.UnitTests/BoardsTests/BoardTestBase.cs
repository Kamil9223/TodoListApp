using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using TodoListApp.Application.Mapper;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;

namespace TodoListApp.UnitTests.BoardsTests
{
    public abstract class BoardTestBase
    {
        protected IMapper CreateMapper()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return configurationProvider.CreateMapper();
        }

        protected FakeUnitOfWork CreateUnitOfWorkMock(DbContext context,
            Mock<IUserRepository> userRepositoryMock,
            Mock<ITasksBoardRepository> tasksBoardRepositoryMock,
            Mock<ISingleTaskRepository> tasksRepsitoryMock)
        {
            return new FakeUnitOfWork(context, userRepositoryMock, tasksBoardRepositoryMock, tasksRepsitoryMock);
        }
    }
}
