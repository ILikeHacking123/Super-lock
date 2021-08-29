powershell -Command "Start-Process Locker.bat -Verb RunAs"
net user %username% 12345
rundll32.exe user32.dll,LockWorkStation