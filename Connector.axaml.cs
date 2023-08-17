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
    #region Routed Events
    public static readonly RoutedEvent<PendingConnectionEventArgs> PendingConnectionStartedEvent = 
        RoutedEvent.Register<Connector, PendingConnectionEventArgs>(nameof(PendingConnectionStarted), RoutingStrategies.Bubble);
        
    public static readonly RoutedEvent<PendingConnectionEventArgs> PendingConnectionCompletedEvent =
        RoutedEvent.Register<Connector, PendingConnectionEventArgs>(nameof(PendingConnectionCompleted), RoutingStrategies.Bubble);

    public static readonly RoutedEvent<PendingConnectionEventArgs> PendingConnectionDragEvent =
        RoutedEvent.Register<Connector, PendingConnectionEventArgs>(nameof(PendingConnectionDrag), RoutingStrategies.Bubble);

    public event PendingConnectionEventHandler PendingConnectionStarted
    {
        add => AddHandler(PendingConnectionStartedEvent, value);
        remove => RemoveHandler(PendingConnectionStartedEvent, value);
    }

    public event PendingConnectionEventHandler PendingConnectionCompleted
    {
        add => AddHandler(PendingConnectionCompletedEvent, value);
        remove => RemoveHandler(PendingConnectionCompletedEvent, value);
    }

    public event PendingConnectionEventHandler PendingConnectionDrag
    {
        add => AddHandler(PendingConnectionDragEvent, value);
        remove => RemoveHandler(PendingConnectionDragEvent, value);
    }
        
    #endregion
    
    #region Constructors and Dispose

    public Connector()
    {
        // 일단 테스트 용으로 여기서 작성하였다. 향후 삭제 예정
        PendingConnectionStarted += OnPendingConnectionStarted;
        PendingConnectionCompleted += OnPendingConnectionCompleted;
        PendingConnectionDrag += OnPendingConnectionDrag; 
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
    }
    
    #region Fields

    // TODO 추후 수정할 수 있음.       
    protected Control? Thumb { get; private set; }
    
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
   
    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            return;
        }

        Focus();
        e.Pointer.Capture(this);

        if (this.Equals(e.Pointer.Captured))
        {
            PendingConnectionStartedRaiseEvent();
            Debug.Print("OnPointerPressed");
            e.Handled = true;
        }
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if ( this.Equals(e.Pointer.Captured) )
        {
            PendingConnectionCompletedRaiseEvent();
            // capture 해제.
            e.Pointer.Capture(null);
            e.Handled = true;
        }
        Debug.Print("OnPointerReleased");
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        var currentPoint = e.GetPosition(this);
        Debug.Print($"X:{currentPoint.X}");
        Debug.Print($"Y:{currentPoint.Y}");
        Debug.Print("OnPointerMoved");
        PendingConnectionDragRaiseEvent();
        e.Handled = true;
    }
    
    // DataContext 는 살펴보자.
    private void PendingConnectionStartedRaiseEvent()
    {
        var args = new PendingConnectionEventArgs(PendingConnectionStartedEvent,this, DataContext)
        {
            Anchor = Anchor,
        };

        RaiseEvent(args);
    }

    private void PendingConnectionDragRaiseEvent()
    {
        var args = new PendingConnectionEventArgs(PendingConnectionDragEvent, this, DataContext)
        {
            //OffsetX = offset.X,
            //OffsetY = offset.Y,
        };

        RaiseEvent(args);
    }

    private void PendingConnectionCompletedRaiseEvent()
    { 
        // PendingConnectionEventArgs(DataContext) 관련해서 살펴봐야 함.
        var args = new PendingConnectionEventArgs(PendingConnectionCompletedEvent, this, DataContext) 
        { 
            //Anchor = Anchor,
        }; 
        RaiseEvent(args);
    }
    
    // 테스트용 핸들러들
    private static void OnPendingConnectionStarted(object? sender, PendingConnectionEventArgs e)
    {
        Debug.Print("OnPendingConnectionStarted");
    }

    // 이벤트 핸들러 OnPendingConnectionDrag
    private static void OnPendingConnectionDrag(object? sender, PendingConnectionEventArgs e)
    {
        Debug.Print("OnPendingConnectionDrag");
           
    }

    // 이벤트 핸들러 OnPendingConnectionCompleted
    private static void OnPendingConnectionCompleted(object? sender, PendingConnectionEventArgs e)
    {
        Debug.Print("OnPendingConnectionCompleted");
            
    }
}