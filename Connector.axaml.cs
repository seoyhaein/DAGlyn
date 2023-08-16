using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.VisualTree;
using Avalonia.Input;
using Avalonia.Interactivity;

// IDisposable 때문에 넣었지만 이건 테스트 해서 살펴봐야 할듯하다. 
// 일단 주석처리 해두었다.
using System;
using System.Diagnostics;
using Avalonia.Controls.Presenters;

namespace DAGlyn;

public delegate void PreviewLocationChanged(Point newLocation);
public class Connector : TemplatedControl
{
    #region Constructors and Dispose

    public Connector()
    {
            /*PendingConnectionStarted += OnPendingConnectionStarted;
            PendingConnectionCompleted += OnPendingConnectionCompleted;
            PendingConnectionDrag += OnPendingConnectionDrag;*/
           
    }

        // TODO 이 부분은 추후 테스트를 진행햐야 한다.
        // 안해줘도 될꺼 같은데 일단 해주었다.
        /*public void Dispose()
        {
            /*PendingConnectionStarted -= OnPendingConnectionStarted;
            PendingConnectionCompleted -= OnPendingConnectionCompleted;
            PendingConnectionDrag -= OnPendingConnectionDrag;#1#

            GC.SuppressFinalize(this);
        }*/
    #endregion
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        Thumb = e.NameScope.Find<Ellipse>("PART_Connector");

        Loaded += OnLoaded; 
    }
    
    #region Fields

    // TODO 추후 수정할 수 있음.       
    protected Control? Thumb { get; private set; }
    //private Point _thumbCenter;

    #endregion

    #region Dependency Properties

    public static readonly StyledProperty<Point> AnchorProperty = 
        AvaloniaProperty.Register<Connector, Point>(nameof(Anchor));

    public Point Anchor
    {
        get => GetValue(AnchorProperty);
        set => SetValue(AnchorProperty, value);
    }
   #endregion
        
   // 이 메서드는 Canvas 안에서 Connector 를 가지고 있는 아이템의 위치값을 통해서 Connector 의 원의 위치를 찾기 위해서 만들어 졌다.
   // 간단히 테스트 해볼려면 Canvas 안에 StackPanel 을 넣고 테스트를 한번 진행해보자.
    public Point? UpdateAnchor(Control parent, Point parentLocation)
    {
        // Bounds.Size 는 RenderedSize 이다.
        var w = parent.Width;
        var renderedSize = parent.Bounds.Size;
        var desiredSize = parent.DesiredSize;

        if (Thumb?.Bounds.Size == null) return null;
        var thumbSizeVector = new Vector(Thumb.Bounds.Size.Width, Thumb.Bounds.Size.Height);
        var renderedSizeVector = new Vector(renderedSize.Width, renderedSize.Height);
        var desiredSizeVector = new Vector(desiredSize.Width, desiredSize.Height);

        var containerMargin = renderedSizeVector - desiredSizeVector;
        var parentMargin = containerMargin / 2;
        var halfThumbSize = thumbSizeVector / 2;
        var newPoint = (Point)halfThumbSize - parentMargin;
        var relativeLocation = Avalonia.VisualExtensions.TranslatePoint(Thumb, newPoint, parent);
        
        if (relativeLocation == null) return null;
            
        Anchor = new Point(parentLocation.X + relativeLocation.Value.X, parentLocation.Y + relativeLocation.Value.Y);

        return Anchor;

    }

   // 테스트 용도로 만들어 짐. 부모인 StackPanel 를 찾음. 
    public Control? FindParent()
    {
        //var parentOfType = Avalonia.VisualTree.VisualExtensions.FindAncestorOfType<Canvas>(this, false);
        var parentOfType = this.FindAncestorOfType<StackPanel>();
        if (parentOfType == null) return null;
        return parentOfType;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        var parent = FindParent();

        if (parent != null)
        {
            Point position = new Point(100, 20);
            var site = UpdateAnchor(parent, position);
        }
    }
}