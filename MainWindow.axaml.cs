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