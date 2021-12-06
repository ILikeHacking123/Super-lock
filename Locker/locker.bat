@echo off
cd C:\Users\Admin\Desktop\Locker\MainData
set /a psswd=12345
Tuanminh > UserUI.info
echo your computer is locked, please enter your password
set /p "%3234%=[password prompt]>"
< runner.lua
cd C:\Users\Admin\Desktop\Locker\NoExitAction
if not exist temp.temp call NoExitApp.CMD 
if not %3234%==%psswd% goto locked
if %3234%==%psswd% (
  echo please wait to the countdown count done
  timeout /t 10 /nobreak
  goto done
)
  :: 12345 is password, change it to what password you want
:done
echo Correct password, press any key to countinue
pause
cls
echo thanks for use, we are developer and debugger, so thanks you
  :: taskkill to exit force to the while application
  :: the while helps i cannot exit by everyone
  :: you need to go github to see new releases
taskkill /IM "NoExit.bat" /F
taskkill /IM "NoExitAction.CMD" /F
cd C:\Users\Admin\Desktop\Locker\MainData
del UserUI.info
  :: application need to delete UserUI.info everytime
exit
:locked
Wrong password: typing password is %3234% >> Wrong.log
taskkill /IM "NoExit.bat" /F
taskkill /IM "NoExitAction.CMD" /F
timeout /T 10 /nobreak
exit
shutdown -l -t 00 -f
