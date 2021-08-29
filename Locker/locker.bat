@echo off
cd C:\Users\Admin\Desktop\Locker\MainData
Tuanminh > UserUI.info
echo your computer is locked, please enter your password
set /p "%3234%=[password prompt]>"
cd C:\Users\Admin\Desktop\Locker\NoExitAction
if not exist temp.temp call NoExitApp.CMD
if not %3234%==12345 goto locked
if %3234%==12345 goto done
:done:
echo Correct password, press any key to countinue
pause
taskkill /IM "NoExit.bat" /F
taskkill /IM "NoExitAction.CMD" /F
cd C:\Users\Admin\Desktop\Locker\MainData
del UserUI.info
exit
:locked:
Wrong password: typing password is %3234% >> Wrong.log
taskkill /IM "NoExit.bat" /F
taskkill /IM "NoExitAction.CMD" /F
exit
shutdown -s -t 00 -f
