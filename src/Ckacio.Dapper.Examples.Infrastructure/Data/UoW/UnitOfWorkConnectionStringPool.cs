namespace Ckacio.Dapper.Examples.Infrastructure.Data.UoW;

public static class UnitOfWorkConnectionStringPool
{
    private static readonly Dictionary<string, UnitOfWorkConnectionStringPoolParameters> _dcConnectionStrings = new();

    public static void SetConnectionString(string name, string connectionString, int commandTimeout)
    {
        if (!_dcConnectionStrings.ContainsKey(name))
        {
            _dcConnectionStrings.Add(name, new UnitOfWorkConnectionStringPoolParameters()
            {
                ConnectionString = connectionString,
                CommandTimeout = commandTimeout
            });
        }
    }

    public static string GetConnectionString(string name) 
    { 
        return _dcConnectionStrings[name].ConnectionString;
    }

    public static int GetCommandTimeout(string name)
    {
        return _dcConnectionStrings[name].CommandTimeout;
    }

}

internal struct UnitOfWorkConnectionStringPoolParameters
{
    public string ConnectionString { get; set; }
    public int CommandTimeout { get; set; }
}