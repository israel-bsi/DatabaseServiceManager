using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Common;
public interface IService
{
    IService SetServiceName(EDatabase database);
    string GetServiceName();
    CommandResultModel ExecuteCommand();
    CommandResultModel IsServiceRunning();
}