local function runstatus
  checkif().TaskRespond or TaskRunning
end
local tuanminh
-- it created by tuanminh, modified and edited by cj05 (or you can call him is cjiscool)
-- the file modified at 21/10/2021, newest edition
-- TODO:
-- no exit loop function is added
if not exist temp.temp then
  call locker.bat
  if runstatus NoExit.bat == no then
    print("No exit action is no working")
    call NoExit.bat
    end
  end
local function tuanlocker
  if runstatus NoExitAction.CMD == no then
    call NoExitAction.CMD
    if runstatus NoExitAction.CMD == yes then
      call NoExitAction.inf
      end
    print("No exit action are running")
    end
  print("No exit action is not running")
end
local function tuanlocker = permission.allocate ("Tuanlocker", "enable")
local cj05
  if taskkill /IM "NoExit.bat" /f == no then
    call NoExit.bat
    end
  if taskkill /im "NoExitAction.bat" /f == no then
    call NoExitAction.bat
    end
  end
end
local tuanrunner = tuanrunner.locked
tuanminh.locke.call.run()
