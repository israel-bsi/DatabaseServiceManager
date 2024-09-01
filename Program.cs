using Microsoft.Extensions.DependencyInjection;

namespace DatabaseServiceManager;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var serviceProvider = DependencyInjectionConfig.Configure();
        var mainForm = serviceProvider.GetRequiredService<FrmMain>();
        var mutex = new Mutex(true, "UniqueAppId", out var result);
        if (!result)
        {
            MessageBox.Show("A aplicação já está sendo executada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        Application.Run(mainForm);
        GC.KeepAlive(mutex);
    }
}