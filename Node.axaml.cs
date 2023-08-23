using Avalonia;
using Avalonia.Media;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Templates;

using System.Collections;
using System.Diagnostics;

namespace DAGlyn;

public class Node : TemplatedControl
{
    #region Constructors

    public Node()
    {
        this.PropertyChanged += OnPropertyChanged;
    }
    
    // TODO Reactive 방식 추후 적용할지 고민해보자.
    /*static Node()
    {
        //FooterProperty.Changed.Subscribe(OnFooterChanged);
    }*/

    #endregion
    #region Dependency Properties
    /*
        protected internal static readonly DependencyPropertyKey HasFooterPropertyKey = DependencyProperty.RegisterReadOnly(nameof(HasFooter), typeof(bool), typeof(Node), new FrameworkPropertyMetadata(BoxValue.False));
        public static readonly DependencyProperty HasFooterProperty = HasFooterPropertyKey.DependencyProperty;
     */
        // Brush 를 사용할 때 Media 가 적절한지는 좀더 살펴보자.
        public static readonly StyledProperty<Brush> ContentBrushProperty =
            AvaloniaProperty.Register<Node, Brush>(nameof(ContentBrush));
        
        public Brush ContentBrush
        {
            get => (Brush)GetValue(ContentBrushProperty);
            set => SetValue(ContentBrushProperty, value);
        }

        public static readonly StyledProperty<Brush> HeaderBrushProperty =
            AvaloniaProperty.Register<Node, Brush>(nameof(HeaderBrush));
        
        public Brush HeaderBrush
        {
            get => (Brush)GetValue(HeaderBrushProperty);
            set => SetValue(HeaderBrushProperty, value);
        }
        
        public static readonly StyledProperty<Brush> FooterBrushProperty =
            AvaloniaProperty.Register<Node, Brush>(nameof(FooterBrush));
        
        public Brush FooterBrush
        {
            get => (Brush)GetValue(FooterBrushProperty);
            set => SetValue(FooterBrushProperty, value);
        }
        

        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<Node, object>(nameof(Header));
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        
        // default method 잡아줘야함.
        public static readonly StyledProperty<object> FooterProperty =
            AvaloniaProperty.Register<Node, object>(nameof(Footer));
        public object Footer
        {
            get => GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
        }
        public static readonly StyledProperty<DataTemplate> InputConnectorTemplateProperty =
            AvaloniaProperty.Register<Node, DataTemplate>(nameof(InputConnectorTemplate));
        public DataTemplate InputConnectorTemplate
        {
            get => GetValue(InputConnectorTemplateProperty);
            set => SetValue(InputConnectorTemplateProperty, value);
        }
        
        public static readonly StyledProperty<DataTemplate> OutputConnectorTemplateProperty =
            AvaloniaProperty.Register<Node, DataTemplate>(nameof(OutputConnectorTemplate));
        public DataTemplate OutputConnectorTemplate
        {
            get => GetValue(InputConnectorTemplateProperty);
            set => SetValue(InputConnectorTemplateProperty, value);
        }
        
        public static readonly StyledProperty<IEnumerable> InputProperty =
            AvaloniaProperty.Register<Node, IEnumerable>(nameof(Input));
        public IEnumerable Input
        {
            get => GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }
        
        public static readonly StyledProperty<IEnumerable> OutputProperty =
            AvaloniaProperty.Register<Node, IEnumerable>(nameof(Output));
        public IEnumerable Output
        {
            get => GetValue(OutputProperty);
            set => SetValue(OutputProperty, value);
        }

        #endregion

        #region Methods

        private static void OnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == HeaderProperty)
            {
                // HeaderProperty 변경되었을 때의 로직
            }
            
            if (e.Property == FooterProperty)
            {
                // FooterProperty가 변경되었을 때의 로직
            }
            
        }

        #endregion
}