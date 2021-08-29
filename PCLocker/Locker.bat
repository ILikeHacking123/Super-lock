@color 04
@echo Searching the drive for password file...
@for /f "delims=" %%F in ('dir /b /s "C:\password.dat" 2^>nul') do set p=%%F
@set /p pssw=<%p%
net user %username% %pssw%
rundll32.exe user32.dll,LockWorkStation
