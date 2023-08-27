using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SkiaSharp;


namespace DAGlyn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // contstructor 에 AddHandler 넣어도 됨.
        private void OnPendingConnectionStarted(object? sender, PendingConnectionEventArgs e)
        {
            Debug.Print("InputConnector OnPendingConnectionStarted");
        }
    }

    public class ConnectionsViewModel
    {
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();

        // 테스트 용
        public ObservableCollection<string> Lists { get; } = new ObservableCollection<string>();

        public string BindingText { get; set; }

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

            BindingText = "hello world";
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