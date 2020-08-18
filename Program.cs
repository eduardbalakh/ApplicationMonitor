using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UIAutomationClient;
using System.Windows.Automation;
using System.Windows;
using System.Threading;

namespace ApplicationMonitor
{
    class Program
    {
        static int _x, _y;
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        static void ShowMousePosition()
        {
            POINT point;
            if (GetCursorPos(out point) && point.X != _x && point.Y != _y)
            {
                Console.Clear();
                Console.WriteLine("({0},{1})", point.X, point.Y);
                _x = point.X;
                _y = point.Y;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");          
            CurrentApps curApps = new CurrentApps();    //Возможно класс следует сделать статическим, но не факт
            Console.WriteLine(curApps.ToString());

            Thread trackerThread = new Thread(ShowMousePosition);
            trackerThread.Start();

            /*Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                // the chrome process must have a window
                if (chrome.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                // find the automation element
                AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));

                // if it can be found, get the value from the URL bar
                if (elmUrlBar != null)
                {
                    AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                    {
                        ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);
                        Console.WriteLine("Chrome URL found: " + val.Current.Value);
                    }
                }
            }*/

            // there are always multiple chrome processes, so we have to loop through all of them to find the
            // process with a Window Handle and an automation element of name "Address and search bar"
            //System.Windows.Automation.
            // Console.WriteLine(GetActiveTabUrl());

            Console.CursorVisible = false;
            while (!Console.KeyAvailable)
            {
                ShowMousePosition();
            }
            Console.CursorVisible = true;



            Console.ReadKey(true);
        }
    }
}
