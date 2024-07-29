namespace DatabaseServiceManager.Common;

public class DatabaseConfigurations
{
    private static readonly Dictionary<EDatabase, string> DatabaseServices = new()
    {
        { EDatabase.MySql, "MySQL80" },
        { EDatabase.PostgreSql, "postgresql-x64-16" },
        { EDatabase.Firebird, "FirebirdServerDefaultInstance" },
        { EDatabase.SqlServer, "MSSQL$SQLEXPRESS" }
    };

    public static string GetServiceName(EDatabase eDatabase)
    {
        return DatabaseServices[eDatabase];
    }
}