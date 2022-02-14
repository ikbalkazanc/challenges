using Pazarama.Homework.Core.Settings;
using Pazarama.Homework.Core.Types;

namespace Pazarama.Homework.Core.Constant;

public static class ConnectionStrings
{
    public static string PostgreSql => EnvironmentSettings.Env switch
    {
        EnviromentTypes.Docker => "User ID=postgres;Password=topsecret;Host=localhost;Port=5432;Database=books;",
        EnviromentTypes.Local => "User ID=postgres;Password=topsecret;Host=localhost;Port=5432;Database=books;",
        _ => throw new ArgumentNullException()
    };
}