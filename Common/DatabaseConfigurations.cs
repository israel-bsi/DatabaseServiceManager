using DatabaseServiceManager.Model;

namespace DatabaseServiceManager.Common;

public class DatabaseConfigurations
{
    private static readonly Dictionary<EDatabase, (string, string)> DatabaseServices = new()
    {
        { EDatabase.MySql, ("MySQL80", EDatabase.MySql.ToString()) },
        { EDatabase.PostgreSql, ("postgresql-x64-16", EDatabase.PostgreSql.ToString()) },
        { EDatabase.Firebird, ("FirebirdServerDefaultInstance", EDatabase.Firebird.ToString()) },
        { EDatabase.SqlServer, ("MSSQL$SQLEXPRESS", EDatabase.SqlServer.ToString()) }
    };
    public static DatabaseServiceModel GetServiceName(EDatabase eDatabase)
    {
        return new DatabaseServiceModel
        {
            Database = eDatabase,
            FullName = DatabaseServices[eDatabase].Item1,
            Name = DatabaseServices[eDatabase].Item2
        };
    }
}