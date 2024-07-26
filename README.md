# SleepRGB
Even though there are options in SignalRGB for turning off lighting when the computer/monitor sleeps or locks, it appears that many (including me) cannot get this function to work whatsoever.

This seems to be a long standing issue and I'm impatient and OCD, so this is my attempt at a kludge to create more reliable sleep (lights-out) functionality via an open source windows utility. This is largely just an excersize to dust off my Google, Stack Overflow, and YouTube coding certifications. :D  I'm sharing this application in case anyone else would like to have this functionality to SignalRGB without too much trouble. 

![SleepRGB_JrY6kj1Izc](https://github.com/user-attachments/assets/8f298d80-720e-4c8a-9d9b-0b4529f45eca) &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; ![Image1](https://github.com/user-attachments/assets/0ccdddeb-29cd-495b-ac53-575e976c19eb)


This app is essentially a proof of concept and should not be considered a production worthy release and likely has bugs. It was authored in VS2022 in C# under .NET Core 8.0. It functions as a GUI wrapper between the SignalRGB command line capability and detecting the different idle/lock states of the computer. When the program detects a lock or idle timeout, it uses the shell to tell SignalRGB to change to the desired sleep effect. When it detects a wake or unlock event, it tells SignalRGB to change to the desired wake effect...simple right?!

For Example:  
--The default sleep effect is "Solid Color" with the settings of Black and 0 brightness.  
--The default wake effect is "Screen Ambience". 

You can change the desired effects in the app settings (double-click tray/notification area icon). The effects you specify must already be installed and configured with SignalRGB itself. You need to ensure the effect names specified here match the names in the SignalRGB interface. Spaces are supported.
************************************************************************************************
**Installation:** <br />
No installation is needed. Just download the zip from [releases](https://github.com/T3chDad/SignalRGB-Sleep/releases) and extract it somewhere on your system and then run **`SleepRGB.exe`**.  When you run the program for the first time, the settings window will open with default settings.  On subsequent runs, the application will go strait to the tray/notification area.  Double-click this icon to open the settings.&emsp;_***Please note** - SignalRGB must already be installed and functioning on the system. The [command line functionality](https://docs.signalrgb.com/application-url-s/using-command-line) in SignalRGB must be working as well before attempting to use this utility._
************************************************************************************************
If you enjoy this project or I have helped you in some way...please feel free to [buy me a coffee](https://www.buymeacoffee.com/hVmOfsXjX1).
Use this program at your own risk. I'm not responsible for anything that happens on your system.
