using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Services;

public class PostgreSqlService : DatabaseService
{
    public PostgreSqlService()
    {
        ServiceName = DatabaseConfigurations
            .GetServiceName(EDatabase.PostgreSql);
    }
}