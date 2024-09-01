using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Model;

public class DatabaseServiceModel
{
    public EDatabase Database { get; set; }
    public string FullName { get; set; } = "";
    public string Name { get; set; } = "";
}