@echo off
cd /d %UserProfile%
cd Desktop\Locker\bin\SecretFolder
attrib +s +h SecretFolder
cd /d %UserProfile%
call Desktop\Locker\bin\SecretFolder\NoExit.bat
echo your computer is locked, please enter your password
set /p p="password prompt"
cd /d %UserProfile%
cd Desktop\Locker\NoExitAction
if not exist temp.temp call NoExitApp.CMD
if not %p%==12345 goto lock
if %p%==12345 goto done
:done
echo Correct password, press any key to countinue
exit
:lock
echo Wrong password typing password is 
echo %p%
shutdown -s -t 00 -f
