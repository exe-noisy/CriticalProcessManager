# Critical Process Manager
Use the "NtSetInformationProcess()" function to cause CRITICAL_PROCESS_DIED in notepad.exe or other processes

![image](https://github.com/user-attachments/assets/3e57bc9b-a4bd-484b-a806-ba44871ae4c3)
## Download
Windows : https://github.com/exeeeeeeeeeeee/CriticalProcessManager/releases/tag/v1.0.0
## Features
 - Set critical or not critical.
 - Create new critical process.
 - Terminate critical process.
## What is "Critical Process"
> What  `RtlSetProcessIsCritical`  does is set your process to a system critical status. This means that the process is now "critical" to the running of Windows, which also means that on termination of your process, Windows itself terminates as well. When a system critical process ends/terminates, the stop code is  `CRITICAL_PROCESS_DIED`  (0xEF) for process exiting, and  `CRITICAL_OBJECT_TERMINATION`  (0xF4) if the process was abnormally terminated. Although this can, technically, be used to "protect" a process against people terminating it, I recommend you find other methods of doing so, because if a user terminates a critical process by accident or a process crashes when it is critical, the system will crash instantly as well. This would be highly annoying to users.
>  
> This type of behavior can also be seen in processes such as  _winlogon.exe_,  _csrss.exe_,  _services.exe_,  _smss.exe_, and  _lsass.exe_. All of these processes are known to call  `RtlSetProcessIsCritical`.

Details: https://www.codeproject.com/Articles/43405/Protecting-Your-Process-with-RtlSetProcessIsCritic
