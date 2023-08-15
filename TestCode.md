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