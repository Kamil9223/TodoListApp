using Xunit;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration
{
    [CollectionDefinition(DatabaseFixture.DbCollection)]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {

    }
}
