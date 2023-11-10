using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;

namespace DAGlyn;

// NodeEditor 는 ItemContainer 를 Item 으로 갖지는 클래스이다.
public class NodeEditor : SelectingItemsControl
{
    // ListBox 에서 가져왔는데 VirtualizingCanvas 구현 필요.
    // 잊어버릴까바 일단 넣어놓음.
    private static readonly FuncTemplate<Panel?> DefaultPanel =
        new(() => new VirtualizingStackPanel());
    
    static NodeEditor()
    {
        ItemsPanelProperty.OverrideDefaultValue<NodeEditor>(DefaultPanel);
        /*
        KeyboardNavigation.TabNavigationProperty.OverrideDefaultValue(
            typeof(ListBox),
            KeyboardNavigationMode.Once);
            */
    }
}