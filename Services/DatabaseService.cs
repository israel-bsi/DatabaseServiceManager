using DatabaseServiceManager.Common;
using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Services;

public abstract class DatabaseService : IServiceCommand
{
    protected string ServiceName { get; init; } = null!;
    private CommandService CommandService { get; } = new();
    private CommandResultModel Result { get; set; } = null!;
    public CommandResultModel ExecuteCommand()
    {
        Result = CommandService.ExecuteIsRunning(ServiceName);
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
        return CommandService.ExecuteIsRunning(ServiceName);
    }
    private void Start()
    {
        Result = CommandService.ExecuteStart(ServiceName);
    }
    private void Stop()
    {
        Result = CommandService.ExecuteStop(ServiceName);
    }
}