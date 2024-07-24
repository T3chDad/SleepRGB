# signalRGB-Sleep
It would be so awesome if the signalRGB team would add a "Turn off RGB when screen is off/idle" option.  

I'm impatient, so this is my attempt at a kludge to add this functionality via an open source windows utility. This is largely just an excersize to dust off my coding activities. I'm sharing this application in case anyone else would like to have this functionality to signalRGB without too much trouble. No installation is needed. Just download the zip and extract it somewhere on your system that signalRGB is installed on and set the signalRGB-Sleep.exe to start with Windows.

This app is essentially a proof of concept and should not be considered a production worthy release and likely has bugs. It functions as a GUI wrapper between the signalRGB command line capability and detecting the different idle/lock state of the computer. When the program detects a lock or idle timeout, it uses the shell to tell signalRGB to change to the desired "OFF" effect. When it detects a wake or unlock event, it tells signalRGB to change to the desired "ON" effect.

For Example:  
--The default "OFF" effect is "Solid Color" with the settings of Black and 0 brightness.  
--The default "ON" effect is "Screen Ambience". 

You can change the desired effects in the app settings (double-click tray/notification area icon). The effects you specify must already be installed and configured with signalRGB itself. You need to ensure the effect names specified here must match the names in the signalRGB interface. Spaces are supported.

************************************************************************************************
Use this program at your own risk. I'm not responsible for anything that happens on your system.
************************************************************************************************
