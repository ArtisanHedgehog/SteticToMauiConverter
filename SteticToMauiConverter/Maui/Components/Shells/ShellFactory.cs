using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Stetic;

namespace SteticToMauiConverter.Maui.Components.Shells;
public class ShellFactory
{
    private readonly ILogger<ShellFactory> _logger;

    public ShellFactory(ILogger<ShellFactory> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Shell CreateShell(Widget widget)
    {
        var result = new Shell();

        if (widget.Properties is not null)
        {
            foreach (var property in widget.Properties)
            {
                switch (property.Name)
                {
                    default:
                        _logger.LogWarning("{UIElement}'s property {Property} is not supported", result.GetType(), property.Name);
                        break;
                }
            }
        }

        if (widget.Signals is not null)
        {
            foreach (var signal in widget.Signals)
            {
                switch (signal.Name)
                {
                    default:
                        _logger.LogWarning("Signal {Signal} is not supported", signal.Name);
                        break;
                }
            }
        }

        return result;
    }
}
