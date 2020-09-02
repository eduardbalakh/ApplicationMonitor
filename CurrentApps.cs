using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ApplicationMonitor
{
    class CurrentApps : CurrentApp
    {
        //Fields
        private List<Process> procList;     //Collection of processes
        private int numProc;                //Number of processes
        private List<Process> oldProcesses; //Collection of old processes


        //Properties
        public List<Process> ProcList       //Prop: Collection of properties
        {
            get
            {
                return procList;
            }
            set
            {
                oldProcesses.Clear();
                oldProcesses.AddRange(procList);
                procList = value;
                procList.Sort();
            }
        }
        
        public int NumProc => procList.Count;

        public bool IsUpdateNeeded  //Think over it
        {
            get => this.NumProc != Process.GetProcesses().Length;
            set => throw new NotImplementedException();
        }


        //ctor
        public CurrentApps()
        {
            procList = new List<Process>();
            oldProcesses = new List<Process>();
            ProcList.AddRange(Process.GetProcesses());
        }

        //Methods
        public List<Process> UpdateProcesses(ref CurrentApps obj)
        {
            obj.ProcList.AddRange(CurrentApp.GetProcesses().ToList());
            return ProcList;
        }

        public override string ToString()
        {
            return this.ProcList.Where(instance => instance.MainWindowTitle != "").
                Aggregate("", (current, instance) =>
                    current + $"MainWindowTitle: {instance.MainWindowTitle}  StartTime: {instance.StartTime} Time in use: {DateTime.Now.Subtract(instance.StartTime)}" + Environment.NewLine);
        }
    }
}
