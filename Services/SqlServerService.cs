using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Services;

public class SqlServerService : DatabaseService
{
    public SqlServerService()
    {
        ServiceName = DatabaseConfigurations
            .GetServiceName(EDatabase.SqlServer);
    }
}