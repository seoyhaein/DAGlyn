using Avalonia.Reactive;

using System;
using System.Diagnostics;

// AvaloniaEdit Utils 참고.
// 완벽하게 이해하진 못했음.
namespace DAGlyn
{
    public static class ExtensionMethods
    {
        [Conditional("DEBUG")]
        public static void Log(bool condition, string format, params object[] args)
        {
            if (condition)
            {
                string output = DateTime.Now.ToString("hh:MM:ss") + ": " + string.Format(format, args); //+ Environment.NewLine + Environment.StackTrace;
                //Console.WriteLine(output);
                Debug.WriteLine(output);
            }
        }

        public static IDisposable Subscribe<T>(this IObservable<T> observable, Action<T> action)
        {
            return observable.Subscribe(new AnonymousObserver<T>(action));
        }
    }
}
