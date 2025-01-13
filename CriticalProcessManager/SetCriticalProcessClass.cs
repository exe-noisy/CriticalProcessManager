using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CriticalProcessManager
{
    internal class SetCriticalProcessClass
    {
        const int ProcessBreakOnTermination = 29;

        private static class NativeMethods
        {
            [DllImport("ntdll.dll", SetLastError = true)]
            public static extern int NtSetInformationProcess(
                IntPtr hProcess, 
                int processInformationClass, 
                ref int processInformation, 
                int processInformationLength);

            [DllImport("ntdll.dll", SetLastError = true)]
            public static extern uint NtQueryInformationProcess(
                IntPtr hProcess,
                int processInformationClass,
                ref uint processInformation,
                uint processInformationLength,
                out uint returnLength);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenProcess(
                ProcessAccessFlags processAccess,
                bool bInheritHandle,
                int processId);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool CloseHandle(
                IntPtr hObject);

            [Flags]
            public enum ProcessAccessFlags : uint
            {
                PROCESS_ALL_ACCESS = 0xFFFF
            }
        }

        public struct CriticalProcessInfo
        {
            public string pName;
            public int pid;
            public bool isCritical;
        }

        public static CriticalProcessInfo[] FindCriticalProcess()
        {
            Process[] processes = Process.GetProcesses();

            CriticalProcessInfo[] cInfo = new CriticalProcessInfo[processes.Length];

            for (int i = 0; i < processes.Length; i++)
            {
                IntPtr processHandle = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.PROCESS_ALL_ACCESS, false, processes[i].Id);
                if (processHandle != IntPtr.Zero)
                {
                    cInfo[i].pName = processes[i].ProcessName;
                    cInfo[i].pid = processes[i].Id;

                    uint isCritical = 0;
                    NativeMethods.NtQueryInformationProcess(processHandle, ProcessBreakOnTermination, ref isCritical, sizeof(uint), out _);
                    cInfo[i].isCritical = isCritical == 1;

                    NativeMethods.CloseHandle(processHandle);
                }
            }

            return cInfo;
        }

        public static void SetCriticalProcess(int pid, int isCritical)
        {
            Process.EnterDebugMode();

            IntPtr hProcess = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.PROCESS_ALL_ACCESS, false, pid);

            NativeMethods.NtSetInformationProcess(hProcess, ProcessBreakOnTermination, ref isCritical, sizeof(int));
        }

        public static CriticalProcessInfo CreateCriticalProcess(string programPath)
        {
            Process p = Process.Start(programPath);
            p.WaitForInputIdle();

            string fileName;
            try
            {
                fileName = p.ProcessName;
            }
            catch (InvalidOperationException)
            {
                fileName = "Error";
            }

            SetCriticalProcess(p.Id, 1);

            CriticalProcessInfo cInfo = new CriticalProcessInfo();
            cInfo.pName = fileName;
            cInfo.pid = p.Id;
            cInfo.isCritical = true;
            
            return cInfo;
        }

        public static void KillCriticalProcess(int pid)
        {
            SetCriticalProcess(pid, 0);

            Process.GetProcessById(pid).Kill();
        }
    }
}
