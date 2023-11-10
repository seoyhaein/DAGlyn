using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace DAGlyn;

// OverlayLayer 는 좀더 살펴보자.
// 그냥 Panel 을 상속받을지 생각해봐야 한다.
// ZoomIn, ZoomOut 관련해서 생각해보자.

public class EditorCanvas : OverlayLayer
{
    public static readonly StyledProperty<Rect> ExtentProperty =
        AvaloniaProperty.Register<EditorCanvas, Rect>(nameof(Extent));
    
    public Rect Extent
    {
        get => (Rect)GetValue(ExtentProperty);
        set => SetValue(ExtentProperty, value);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        var minX = double.MaxValue;
        var minY = double.MaxValue;

        var maxX = double.MinValue;
        var maxY = double.MinValue;
        
        // 이 코드 넣었을때와 안넣었을때 비교해보자.
        //var availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
        
        foreach (var child in Children)
        {
            var item = (ICanvasItem)child;
            var location = item.Location;
            var size = child.Bounds.Size;

            // Arrange the child
            item.Arrange(new Rect(location, item.DesiredSize));

            // Find min and max X, Y coordinates
            minX = Math.Min(location.X, minX);
            minY = Math.Min(location.Y, minY);

            var sizeX = location.X + size.Width;
            var sizeY = location.Y + size.Height;

            maxX = Math.Max(sizeX, maxX);
            maxY = Math.Max(sizeY, maxY);

            // Measure the child (optional, if needed)
            child.Measure(availableSize);
            
            // 이거 추가했는데 위의 자세히 살펴보자.
            child.Measure(availableSize);
        }

        return availableSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        var availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
        foreach (var child in Children)
        {
            child.Measure(availableSize);
        }
        // 이부분 자세히 살펴보자.
        return base.ArrangeOverride(finalSize);
    }
}