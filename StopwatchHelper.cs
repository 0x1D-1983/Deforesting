using System;
using System.Diagnostics;

namespace Deforesting
{
    public static class StopwatchHelper
    {
        public static void StopwatchAction(Action action)
        {
            // Stopwatch to determine the execution time for an application
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            // Stop measuring time
            stopwatch.Stop();

            // Format and display the TimeSpan value.
            var ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
