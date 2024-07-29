using System.Diagnostics;
using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Services;
public class CommandService
{
    public CommandResultModel ExecuteStart(string serviceName)
    {
        var result = ExecuteCommand($"net start {serviceName}");
        if(result.Success)
            result.IsRunning = true;
        return result;
    }
    public CommandResultModel ExecuteStop(string serviceName)
    {
        var result = ExecuteCommand($"net stop {serviceName}");
        if(result.Success)
            result.IsRunning = false;
        return result;
    }
    public CommandResultModel ExecuteIsRunning(string serviceName)
    {
        return ExecuteCommand($"sc query {serviceName}");
    }
    private CommandResultModel ExecuteCommand(string command)
    {
        var process = new Process();

        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = $"/C {command}";
        process.StartInfo.Verb = "runas";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();

        var error = process.StandardError.ReadToEnd();
        var output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return new CommandResultModel
        {
            Output = output,
            Error = error,
            IsRunning = output.Contains("RUNNING")
        };
    }
}