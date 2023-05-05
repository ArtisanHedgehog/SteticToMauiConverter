﻿namespace SteticToMauiConverter.Maui.Factories;

using Microsoft.Extensions.Logging;
using SteticToMauiConverter.Maui.Components;
using SteticToMauiConverter.Stetic;

public class ButtonsFactory
{
    private readonly ILogger<ButtonsFactory> _logger;

    public ButtonsFactory(ILogger<ButtonsFactory> logger)
    {
        _logger = logger;
    }

    public ImageButton CreateImageButton(Widget widget)
    {
        var button = new ImageButton();

        if (widget.Properties is null)
        {
            return button;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "Label":
                    button.Text = property.Value;
                    break;
                case "Tooltip":
                    button.Tooltip = property.Value;
                    break;
                case "Icon":
                    button.Source = property.Value ?? string.Empty;
                    break;
                case "Sensitive":
                    button.IsEnabled = property.Value;
                    break;
                case "Type": // Not used here
                case "UseUnderline": // Gtk uses it for enable mnemonic characters
                case "MemberName": // Unused property
                case "CanFocus": // Unused property
                    break;
                default:
                    _logger.LogWarning("{UIElement}'s property {Property} is not supported", nameof(Button), property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return button;
        }

        foreach (var signal in widget.Signals)
        {
            switch (signal.Name)
            {
                case "Toggled":
                case "Clicked":
                    button.Clicked = signal.Handler;
                    break;
                default:
                    _logger.LogWarning("{UIElement}'s Signal {Signal} is not supported", nameof(Button), signal.Name);
                    break;
            }
        }

        return button;
    }

    public Button CreateButton(Widget widget)
    {
        var button = new Button();

        if (widget.Properties is null)
        {
            return button;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "Label":
                    button.Text = property.Value;
                    break;
                case "Tooltip":
                    button.Tooltip = property.Value;
                    break;
                case "Sensitive":
                    button.IsEnabled = property.Value;
                    break;
                case "Type": // Not used here
                case "Icon": // Not used in button
                case "UseUnderline": // Gtk uses it for enable mnemonic characters
                case "MemberName": // Unused property
                case "CanFocus": // Unused property
                    break;
                default:
                    _logger.LogWarning("{UIElement}'s property {Property} is not supported", nameof(Button), property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return button;
        }

        foreach (var signal in widget.Signals)
        {
            switch (signal.Name)
            {
                case "Toggled":
                case "Clicked":
                    button.Clicked = signal.Handler;
                    break;
                default:
                    _logger.LogWarning("{UIElement}'s Signal {Signal} is not supported", nameof(Button), signal.Name);
                    break;
            }
        }

        return button;
    }

    public RadioButton CreateRadioButton(Widget widget)
    {
        var radioButton = new RadioButton();

        if (widget.Properties is null)
        {
            return radioButton;
        }

        foreach (var property in widget.Properties)
        {
            switch (property.Name)
            {
                case "Group":
                    radioButton.GroupName = property.Value;
                    break;
                case "Label":
                    radioButton.Content = property.Value;
                    break;
                case "Active":
                    radioButton.IsChecked = true;
                    break;
                case "UseUnderline": // Gtk uses it for enable mnemonic characters
                case "MemberName": // Unused property
                case "CanFocus": // Unused property
                case "HasLabel": // Unused property
                    break;
                default:
                    _logger.LogWarning("{UIElement}'s property {Property} is not supported", nameof(RadioButton), property.Name);
                    break;
            }
        }

        if (widget.Signals is null)
        {
            return radioButton;
        }

        foreach (var signal in widget.Signals)
        {
            switch (signal.Name)
            {
                default:
                    _logger.LogWarning("{UIElement}'s Signal {Signal} is not supported", nameof(Button), signal.Name);
                    break;
            }
        }

        return radioButton;
    }
}
