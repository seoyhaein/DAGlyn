using Avalonia;
using Avalonia.Controls;

namespace DAGlyn;

public interface ICanvasItem
{
    /// <summary>The location of the item.</summary>
    Point Location { get; }

    /// <summary>The desired size of the item.</summary>
    Size DesiredSize { get; }

    /// <inheritdoc cref="UIElement.Arrange(Rect)" />
    /// 이건 Avalonia 로 변경한다.
    void Arrange(Rect rect);
}
// ICanvasItem 상속 받도록 해야 한다.
// 일단 이렇게 남겨 놓고, 일단 xaml 을 붙여서 수정하고 이 코드는 삭제한다.
// 향후 이건 ItemsControl 등에 Item 으로 들어 갈 수 있다.
public class ItemContainer : ContentControl
{
    
}