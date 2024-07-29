namespace DatabaseServiceManager.Model;

public class CommandResultModel
{
    public string? Output { get; set; }
    public string? Error { get; set; }
    public bool IsRunning { get; set; }
    public bool Success => string.IsNullOrEmpty(Error);
}