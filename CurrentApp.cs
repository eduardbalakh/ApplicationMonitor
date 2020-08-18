using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ApplicationMonitor
{
    class CurrentApp : Process//, IEnumerable<Process>, IEnumerator<Process>
    {
        //protected Process p;
       // protected TimeSpan ts;

        protected TimeSpan TS
        {
            get
            {
                return DateTime.Now.Subtract(this.StartTime);
            }
        }

        public static Process[] processes;

        public CurrentApp this[int index]
        {
            get => (CurrentApp)processes[index];
        }
        static CurrentApp()
        {
            CurrentApp.processes = Process.GetProcesses();
        }

        public CurrentApp ConvertToCurrentAPP(Process item)
        {
            CurrentApp cA = new CurrentApp();
            cA = (CurrentApp)item;
            return cA;
        }

        public CurrentApp[] GetApps()
        {

            return (CurrentApp[])Process.GetProcesses();
        }

        //public IEnumerator<Process> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //public bool MoveNext()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Reset()
        //{
        //    throw new NotImplementedException();
        //}

        //public Process Current { get; }

        //object? IEnumerator.Current => Current;
    }
}
