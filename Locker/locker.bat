@echo off
cd C:\Users\Admin\Desktop\Locker\bin\SecretFolder
attrib +s +h SecretFolder
call C:\Users\Admin\Desktop\Locker\bin\SecretFolder\NoExit.bat
echo your computer is locked, please enter your password
set /p "%3234%=[password prompt]>"
cd C:\Users\Admin\Desktop\Locker\NoExitAction
if not exist temp.temp call NoExitApp.CMD
if not %3234%==12345 goto locked
if %3234%==12345 goto done
:done:
echo Correct password, press any key to countinue
pause
exit
:locked:
Wrong password: typing password is %3234%
shutdown -s -t 00 -f