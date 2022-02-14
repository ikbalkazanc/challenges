using Pazarama.Homework.Core.Types;

namespace Pazarama.Homework.Core.Settings;

public static class EnvironmentSettings
{
    public static EnviromentTypes Env => FindEnviroment();

    private static EnviromentTypes FindEnviroment()
    {
        if (string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER")))
            return EnviromentTypes.Local;
        else
            return EnviromentTypes.Docker;
    }
}