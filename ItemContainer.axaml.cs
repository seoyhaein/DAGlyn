using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace DAGlyn;

public interface ICanvasItem
{
    // 이것만 구현하면됨. 아래 두개는 상속받는 클래스에서 이미 구현되어 있음.
    Point Location { get; }
    
    Size DesiredSize { get; }
    
    void Arrange(Rect rect);
}

// 일단 테스트 용도로 간단하게 작성한다.
public class ItemContainer : ContentControl, ICanvasItem
{
    #region Dependency Properties
    
    public static readonly StyledProperty<Point> LocationProperty = 
        AvaloniaProperty.Register<ItemContainer, Point>(nameof(Location));

    public Point Location
    {
        get => GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }
    #endregion

    #region Constructor

    static ItemContainer()
    {
        // 일단 초기값으로 focus를 가질 수 있도록 설정한다.
        FocusableProperty.OverrideDefaultValue<ItemContainer>(true);
    }

    #endregion
}