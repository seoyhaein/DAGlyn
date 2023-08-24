using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Templates;

namespace DAGlyn;

public class InputConnector : Connector
{
    #region Dependency Properties

    public static readonly StyledProperty<object> HeaderProperty =
        AvaloniaProperty.Register<InputConnector, object>(nameof(Header));

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    
    public static readonly StyledProperty<DataTemplate> HeaderTemplateProperty =
        AvaloniaProperty.Register<InputConnector, DataTemplate>(nameof(HeaderTemplate));

    public DataTemplate HeaderTemplate
    {
        get => GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    #endregion
}