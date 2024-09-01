using DatabaseServiceManager.Common;
using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Services;

public class DatabaseService : IService
{
    private DatabaseServiceModel ServiceName { get; set; } = null!;
    private CommandService CommandService { get; } = new();
    private CommandResultModel Result { get; set; } = null!;
    public IService SetServiceName(EDatabase database)
    {
        ServiceName = DatabaseConfigurations
            .GetServiceName(database);
        return this;
    }
    public string GetServiceName()
    {
        return ServiceName.Name;
    }
    public CommandResultModel ExecuteCommand()
    {
        Result = CommandService.ExecuteIsRunning(ServiceName.FullName);
        if (Result.IsRunning)
        {
            Stop();
            return Result;
        }
        Start();
        return Result;
    }
    public CommandResultModel IsServiceRunning()
    {
        return CommandService.ExecuteIsRunning(ServiceName.FullName);
    }
    private void Start()
    {
        Result = CommandService.ExecuteStart(ServiceName.FullName);
    }
    private void Stop()
    {
        Result = CommandService.ExecuteStop(ServiceName.FullName);
    }
}