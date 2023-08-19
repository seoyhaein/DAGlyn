## 실험적으로 테스트 코드들을 임시로 기록한다.

### 1. Connection.cs 테스트 코드

```xaml

<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
		xmlns:controls="clr-namespace:DAGlyn"
        x:Class="DAGlyn.MainWindow"
        x:DataType="controls:ConnectionsViewModel"
        x:CompileBindings="True"
        Title="DAGlyn">
        
<!--MainWindow.xaml 에서-->		
		<Grid>
		    <controls:Node Width="100" Height="100"/>		
	    </Grid>
</Window>
```

```csharp

// MainWindow.cs 에서
using Avalonia;
using Avalonia.Controls;

using System.ComponentModel;
using System.Collections.ObjectModel;


namespace DAGlyn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //CreatePendingConnection();
            //Tester.ItemsSource = Setup();
            //var connectionsViewModel = new ConnectionsViewModel();
            //DataContext = connectionsViewModel;
        }
        
        /*private void CreatePendingConnection()
        {
            Point sourceAnchor = new Point(10, 10);
            Point targetAnchor = new Point(100, 100);
            AvaloniaList<double>? strokeDashArray = null;
            IBrush? stroke = Brushes.Black;
            double strokeThickness = 2;
            ConnectionDirection direction = ConnectionDirection.Forward;
            IBrush? fill = Brushes.Black;

            PendingConnection pendingConnection = new PendingConnection(sourceAnchor, targetAnchor, strokeDashArray, stroke, strokeThickness, direction, fill);

            // Grid�� �߰�
            var grid = this.FindControl<Grid>("grid");
            grid.Children.Add(pendingConnection);

            // ������ PendingConnection �ν��Ͻ��� ��Ʈ�� Ʈ���� �߰��ϰų� �ٸ� �۾��� �����մϴ�.
            // ����: this.Content = pendingConnection;
        }*/
    }

    public class ConnectionsViewModel 
    {
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();
        
        // 테스트 용
        public ObservableCollection<string> Lists { get; } = new ObservableCollection<string>();
        public ConnectionsViewModel()
        {
            Connections.Add(new ConnectionViewModel
            {
                Source = new ConnectorViewModel
                {
                    Title = "Start",
                    Anchor = new Point(10, 10)
                },

                Target = new ConnectorViewModel
                {
                    Title = "End",
                    Anchor = new Point(100, 100)
                }
            });
            
            Lists.Add("item1");
            Lists.Add("item2");
        }
        /*
        public static ObservableCollection<ConnectionViewModel> Setup()
        {
            ObservableCollection<ConnectionViewModel> Connections = new ObservableCollection<ConnectionViewModel>
            {
                new ConnectionViewModel
                {
                    Source = new ConnectorViewModel
                    {
                        Title = "Start",
                        Anchor = new Point(10, 10)
                    },

                    Target = new ConnectorViewModel
                    {
                        Title = "End",
                        Anchor = new Point(100, 100)
                    }
                }
            };

            return Connections;
        }
        */
    }

    public class ConnectionViewModel
    {
        public ConnectorViewModel Source { get; set; }
        public ConnectorViewModel Target { get; set; }

        public ConnectionViewModel()
        {
            Source = new ConnectorViewModel();
            Target = new ConnectorViewModel();
        }
    }

    public class ConnectorViewModel : INotifyPropertyChanged
    {
        private Point _anchor;
        public Point Anchor
        {
            set
            {
                _anchor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Anchor)));
            }
            get => _anchor;
        }

        public string? Title { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
```

### 2. ItemsControl 테스트 코드

```xaml

<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
		xmlns:controls="clr-namespace:DAGlyn"
        x:Class="DAGlyn.MainWindow"
        x:DataType="controls:ConnectionsViewModel"
        x:CompileBindings="True"
        Title="DAGlyn">
		<Window.DataContext>
			<controls:ConnectionsViewModel/>
		</Window.DataContext>
		<Grid>
			<ItemsControl x:Name="Tester" ItemsSource="{Binding Lists}">
			<ItemsControl.ItemTemplate>
				<DataTemplate>
					<Grid >
						<Border IsVisible="False"
						        x:Name="Highlight"/>
						<StackPanel Orientation="Horizontal"
						            Margin="5">
							<Ellipse Width="14" Height="14" StrokeThickness="2" Fill="Blue" />
							<ContentPresenter  Content="{Binding}" />
						</StackPanel>
					</Grid>
				</DataTemplate>
			</ItemsControl.ItemTemplate>
		</ItemsControl>
	</Grid>
</Window>

```

### 3. Connector 테스트 코드

```csharp

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
```
MainWindow.xaml
```xaml

<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
		xmlns:controls="clr-namespace:DAGlyn"
        x:Class="DAGlyn.MainWindow"
        x:DataType="controls:ConnectionsViewModel"
        x:CompileBindings="True"
        Title="DAGlyn">
		<Canvas x:Name="Tester" Width="800" Height="400" Background="Yellow">
			<StackPanel x:Name="Container" Background="Green" Width="100" Height="200" Canvas.Left="100" Canvas.Top="20">
				<controls:Connector />
			</StackPanel>
		</Canvas>
</Window>

```

MainWindow.cs
```csharp
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

using System.ComponentModel;
using System.Collections.ObjectModel;
using SkiaSharp;


namespace DAGlyn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //CreatePendingConnection();
            //Tester.ItemsSource = Setup();
            //var connectionsViewModel = new ConnectionsViewModel();
            //DataContext = connectionsViewModel;
            Loaded += OnLoaded;
        }
        
        private void OnLoaded(object? sender, RoutedEventArgs e)
        {
            Ellipse dot = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = Brushes.Red
            };

            // 점의 위치를 Canvas에 설정
            Canvas.SetLeft(dot, 150);
            Canvas.SetTop(dot, 27);

            // Canvas에 점 추가
            Tester.Children.Add(dot);
        }

        /*private void CreatePendingConnection()
        {
            Point sourceAnchor = new Point(10, 10);
            Point targetAnchor = new Point(100, 100);
            AvaloniaList<double>? strokeDashArray = null;
            IBrush? stroke = Brushes.Black;
            double strokeThickness = 2;
            ConnectionDirection direction = ConnectionDirection.Forward;
            IBrush? fill = Brushes.Black;

            PendingConnection pendingConnection = new PendingConnection(sourceAnchor, targetAnchor, strokeDashArray, stroke, strokeThickness, direction, fill);

            // Grid�� �߰�
            var grid = this.FindControl<Grid>("grid");
            grid.Children.Add(pendingConnection);

            // ������ PendingConnection �ν��Ͻ��� ��Ʈ�� Ʈ���� �߰��ϰų� �ٸ� �۾��� �����մϴ�.
            // ����: this.Content = pendingConnection;
        }*/
    }

    public class ConnectionsViewModel 
    {
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();
        
        // 테스트 용
        public ObservableCollection<string> Lists { get; } = new ObservableCollection<string>();
        public ConnectionsViewModel()
        {
            Connections.Add(new ConnectionViewModel
            {
                Source = new ConnectorViewModel
                {
                    Title = "Start",
                    Anchor = new Point(10, 10)
                },

                Target = new ConnectorViewModel
                {
                    Title = "End",
                    Anchor = new Point(100, 100)
                }
            });
            
            Lists.Add("item1");
            Lists.Add("item2");
        }
        /*
        public static ObservableCollection<ConnectionViewModel> Setup()
        {
            ObservableCollection<ConnectionViewModel> Connections = new ObservableCollection<ConnectionViewModel>
            {
                new ConnectionViewModel
                {
                    Source = new ConnectorViewModel
                    {
                        Title = "Start",
                        Anchor = new Point(10, 10)
                    },

                    Target = new ConnectorViewModel
                    {
                        Title = "End",
                        Anchor = new Point(100, 100)
                    }
                }
            };

            return Connections;
        }
        */
    }

    public class ConnectionViewModel
    {
        public ConnectorViewModel Source { get; set; }
        public ConnectorViewModel Target { get; set; }

        public ConnectionViewModel()
        {
            Source = new ConnectorViewModel();
            Target = new ConnectorViewModel();
        }
    }

    public class ConnectorViewModel : INotifyPropertyChanged
    {
        private Point _anchor;
        public Point Anchor
        {
            set
            {
                _anchor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Anchor)));
            }
            get => _anchor;
        }

        public string? Title { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
```

```xaml
<Grid>
    <controls:Connector 
        PendingConnectionStarted="OnPendingConnectionStarted"
	    PendingConnectionCompleted="OnPendingConnectionCompleted"
	    PendingConnectionDrag="OnPendingConnectionDrag"/>
</Grid>
```

```csharp
        private void OnPendingConnectionStarted(object? sender, PendingConnectionEventArgs e)
        {
            Debug.Print("OnPendingConnectionStarted");
        }

        private void OnPendingConnectionCompleted(object? sender, PendingConnectionEventArgs e)
        {
            Debug.Print("OnPendingConnectionCompleted");
        }

        private void OnPendingConnectionDrag(object? sender, PendingConnectionEventArgs e)
        {
            Debug.Print("OnPendingConnectionDrag");
        }
```