using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Stetic;

namespace SteticToMauiConverter.Maui.Components.Tables;
public class TableFactory
{
    private readonly ILogger<TableFactory> _logger;

    public TableFactory(ILogger<TableFactory> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public TableView CreateTable(Widget widget)
    {
        var result = new TableView();

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
