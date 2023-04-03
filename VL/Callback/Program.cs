using System;

namespace Callback // Note: actual namespace depends on the project name.
{

    // public interface IProgressReporter
    // {
    //     void ReportProgress(int percentDone);
    // }


    public delegate void ProgressReporter(int percentDone);


    public static class Calculator
    {
        public static int SomeLengthyCalculation(ProgressReporter p)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                // Console.WriteLine()
                p(i + 1);
            }
            return 42;
        }

    }
✔
    // class ProgressReporter : IProgressReporter
    // {
    //     public void ReportProgress(int percentDone)
    //         Console.WriteLine(percentDone);
    //     }
    // }


    internal class Program
    {
        public static void ReportProgress(int percentDone)
        {
            Console.WriteLine(percentDone);
        }
        static void Main(string[] args)
        {
            // ProgressReporter p = new ProgressReporter();
            Console.WriteLine("Hello World!");
            int result = Calculator.SomeLengthyCalculation(ReportProgress);
            Console.WriteLine(result);
        }
    }
}