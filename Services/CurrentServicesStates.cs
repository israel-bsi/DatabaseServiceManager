using DatabaseServiceManager.Common;

namespace DatabaseServiceManager.Services;
public class ServiceInfo(IServiceCommand handler, Button button, string serviceName)
{
    private readonly IServiceCommand _handler = handler;
    private readonly Button _button = button;
    private readonly string _serviceName = serviceName;
    public static void UpdateServiceButton(ServiceInfo service)
    {
        var result = service._handler.IsServiceRunning();
        service._button.Text = result.IsRunning 
            ? $"Parar serviço {service._serviceName}"
            : $"Iniciar serviço {service._serviceName}";
    }
}