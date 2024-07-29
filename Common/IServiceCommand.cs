using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Common;
public interface IServiceCommand
{
    public CommandResultModel ExecuteCommand();
    public CommandResultModel IsServiceRunning();
}