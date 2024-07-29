using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Services;

public class MySqlService : DatabaseService
{
    public MySqlService()
    {
        ServiceName = DatabaseConfigurations
            .GetServiceName(EDatabase.MySql);
    }
}