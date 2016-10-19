DockCheck.exe 1.0
Written by jgeau in c# requires .net 4.0 or higher

DockCheck.exe is just a simple command line tool that does nothing more than return a 0 or 1 as an exit code.
If the dock is plugged in it will return 1 and show "The Dock is plugged" in at the command prompt.
If the dock is not plugged in will return 0 and show "The Dock is not plugged" in at the command prompt.

It may also echo the exit code to the screen.

Usage
This is intended to be used with other programs that may need to know if the dock is plugged in.

example in powershell can run DockCheck.exe The look at $LASTEXITCODE

If $LASTEXITCODE is 0 then the dock is not plugged in
IF $LASTEXITCODE is 1 then the dock is plugged in


In an SCCM task sequence just run the command DockCheck.exe in a "run command line" step
The task sequence will see and exit code of 0 if the dock is not plugged in and continue
The task sequence will see and exit code of 1 if the dock is plugged in and exit unless you have the "continue on error" option checked.

Basic Design: 
looks at wmi in the Win32_PnPEntity for anything with the Manufacturer = 'DisplayLink'.
If the dock is plugged in you will see a couple of thing from that Manufacturer. 
If it isn’t then you won’t even if the drivers are installed.

