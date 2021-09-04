a = MsgBox("Welcome in PCLocker! Disclaimer: Our team do not take any responsibility of any harm due to our aplication. Clicking Yes button will start PCLocker app. Then it will ask to elevate it. Clicking X or No button will close the app safely", vbYesNo + vbExclamation + vbSystemModal, "PCLocker v.X.X")
If a = vbYes Then
	Dim shell
	Set shell = CreateObject("WScript.Shell")
	shell.Run "elevator.bat"
End If
