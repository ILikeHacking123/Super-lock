local tuanminh
-- it created by tuanminh, modifi and edited by cj05 (or you can call him is cjiscool)
-- the file modified at 29/08/2021, newest edition
-- TODO:
-- no exit while added
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
