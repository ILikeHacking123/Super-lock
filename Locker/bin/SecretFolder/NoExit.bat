cls
@echo off
Echo this runned in the secret folder, and you never can find it
cd /d %UserProfile%
cd Desktop\Locker\
if not exist Welcome.txt call locker.bat
pause
