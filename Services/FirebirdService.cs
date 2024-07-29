using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Services;

public class FirebirdService : DatabaseService
{
    public FirebirdService()
    {
        ServiceName = DatabaseConfigurations
            .GetServiceName(EDatabase.Firebird);
    }
}