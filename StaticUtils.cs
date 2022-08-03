using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotkeys
{
    internal class StaticUtils
    {
        public static bool AppAlreadyRunning()
        {
            try
            {
                // Getting collection of process  
                Process currentProcess = Process.GetCurrentProcess();

                // Check with other process already running   
                foreach (var p in Process.GetProcesses())
                {
                    // Check running process
                    if (p.Id != currentProcess.Id && p.ProcessName.Equals(currentProcess.ProcessName))   
                    {
                        return true;
                    }
                }
                return false;
            }
            catch { return true; }
        }

    }
}
