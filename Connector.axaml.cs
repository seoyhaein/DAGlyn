using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;

// IDisposable 때문에 넣었지만 이건 테스트 해서 살펴봐야 할듯하다. 
// 일단 주석처리 해두었다.
using System;

namespace DAGlyn;

public delegate void PreviewLocationChanged(Point newLocation);
public class Connector : TemplatedControl, IDisposable
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
        public void Dispose()
        {
            /*PendingConnectionStarted -= OnPendingConnectionStarted;
            PendingConnectionCompleted -= OnPendingConnectionCompleted;
            PendingConnectionDrag -= OnPendingConnectionDrag;*/

            GC.SuppressFinalize(this);
        }

        #endregion

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            Thumb = e.NameScope.Find<Ellipse>("PART_Connector");
        }
       
        #region Fields

        // TODO 추후 수정할 수 있음.
        // Ellipse 를 Control 로 바꿀지 살펴본다.
        protected Ellipse? Thumb { get; private set; }
        private Point _thumbCenter;

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
        
        // 일단 수정할 것들이 무척이나 많다.
        public void UpdateAnchor(Point location, Control parent)
        {
            // Avalonia 에서는 Vector 로 변경하는게 쉽지 않은데...
            /*var thumbSize = Thumb.Bounds.Size;
            var renderedSize = parent.Bounds.Size;
            var desiredSize = parent.DesiredSize;
            Vector containerMargin = renderedSize - desiredSize;
            Point relativeLocation = Thumb.TranslatePoint((Point)(thumbSize / 2 - containerMargin / 2), Container);
                
            Anchor = new Point(location.X + relativeLocation.X, location.Y + relativeLocation.Y);*/
        }

}