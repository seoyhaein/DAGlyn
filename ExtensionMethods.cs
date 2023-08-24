using Avalonia.Reactive;

using System;

// AvaloniaEdit Utils 참고.
// 완벽하게 이해하진 못했음.
namespace DAGlyn
{
    public static class ExtensionMethods
    {
        public static IDisposable Subscribe<T>(this IObservable<T> observable, Action<T> action)
        {
            return observable.Subscribe(new AnonymousObserver<T>(action));
        }
    }
}
