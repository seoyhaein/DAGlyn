using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace DAGlyn;

// 자세히 살펴보자.
public class VirtualizingCanvas : VirtualizingPanel, IScrollSnapPointsInfo
{
    protected override Control? ScrollIntoView(int index)
    {
        throw new NotImplementedException();
    }

    protected override Control? ContainerFromIndex(int index)
    {
        throw new NotImplementedException();
    }

    protected override int IndexFromContainer(Control container)
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<Control>? GetRealizedContainers()
    {
        throw new NotImplementedException();
    }

    protected override IInputElement? GetControl(NavigationDirection direction, IInputElement? from, bool wrap)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<double> GetIrregularSnapPoints(Orientation orientation, SnapPointsAlignment snapPointsAlignment)
    {
        throw new NotImplementedException();
    }

    public double GetRegularSnapPoints(Orientation orientation, SnapPointsAlignment snapPointsAlignment, out double offset)
    {
        throw new NotImplementedException();
    }

    public bool AreHorizontalSnapPointsRegular { get; set; }
    public bool AreVerticalSnapPointsRegular { get; set; }
    public event EventHandler<RoutedEventArgs>? HorizontalSnapPointsChanged;
    public event EventHandler<RoutedEventArgs>? VerticalSnapPointsChanged;
}