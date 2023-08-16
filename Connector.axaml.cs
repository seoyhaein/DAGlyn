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
            //Thumb = e.NameScope.Find<Ellipse>("PART_Connector");

            //var tester = e.NameScope.Find<ContentPresenter>("PART_Tester");

            /*var parentOfType = this.FindAncestorOfType<Canvas>();
            if (parentOfType != null)
            {
                // 부모와 관련된 작업 수행
            }*/
            var str =  FindParent();
            Debug.Print(str);
            
        }
       
        #region Fields

        // TODO 추후 수정할 수 있음.
        // Ellipse 를 Control 로 바꿀지 살펴본다. Visual 과 Control 비교 해보자.
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
        
        // 기본 기능 테스트 후 업데이트 시키자. 일단 구현
        public void UpdateAnchor(Point location, Control parent)
        {
            // Bounds.Size 는 RenderedSize 이다.
            var renderedSize = parent.Bounds.Size;
            var desiredSize = parent.DesiredSize;

            if (Thumb?.Bounds.Size == null) return;
            
            var thumbSizeVector = new Vector(Thumb.Bounds.Size.Width, Thumb.Bounds.Size.Height);
            var renderedSizeVector = new Vector(renderedSize.Width, renderedSize.Height);
            var desiredSizeVector = new Vector(desiredSize.Width, desiredSize.Height);

            var containerMargin = renderedSizeVector - desiredSizeVector;
            var parentMargin = containerMargin / 2;
            var halfThumbSize = thumbSizeVector / 2;


            var newPoint = (Point)halfThumbSize - parentMargin;
            
            var relativeLocation = Avalonia.VisualExtensions.TranslatePoint(Thumb, newPoint, parent);
            if (relativeLocation == null) return;
            
            Anchor = new Point(location.X + relativeLocation.Value.X, location.Y + relativeLocation.Value.Y);
        }

        // 기본 기능은 하는데 좀더 고도화 시키자. 왜 이렇게 개발 속도가 느리냐. 정말 
        public string? FindParent()
        {
            var parentOfType = Avalonia.VisualTree.VisualExtensions.FindAncestorOfType<Canvas>(this, false);
            //var parentOfType = this.FindAncestorOfType<Canvas>();
            if (parentOfType == null) return null;

            return parentOfType.Name;
        }

}