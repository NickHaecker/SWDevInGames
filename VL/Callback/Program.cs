using System;

namespace Callback // Note: actual namespace depends on the project name.
{

    // public interface IProgressReporter
    // {
    //     void ReportProgress(int percentDone);
    // }


    public delegate void ProgressReporter(int percentDone);
    public delegate void ResultReceiver(int result);

    public class Calculator
    {
        public event ProgressReporter PR;
        public event ResultReceiver RR;
        public void SomeLengthyCalculation()
        {
            new Task(DoCalculate).Start();
        }
        private void DoCalculate()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                // Console.WriteLine()
                // p(i + 1);
                PR(i + 1);
            }
            // return 42;
            RR(42);
        }

    }

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
        public static void ResultReceiver(int percentDone)
        {
            Console.WriteLine(percentDone);
        }
        static void Main(string[] args)
        {
            // ProgressReporter p = new ProgressReporter();
            Console.WriteLine("Hello World!");


            // int result = Calculator.SomeLengthyCalculation(ReportProgress);


            // Calculator calculator = new Calculator { PR = ReportProgress, RR = ResultReceiver };
            Calculator calculator = new Calculator();
            calculator.PR += ReportProgress;
            calculator.PR += (percent) =>
            {
                Console.WriteLine("hallo");
                Console.WriteLine(percent);
            };

            // Closure

            calculator.RR += ResultReceiver;
            calculator.SomeLengthyCalculation();
            Thread.Sleep(20000);

            // Console.WriteLine(result);
        }
    }
}