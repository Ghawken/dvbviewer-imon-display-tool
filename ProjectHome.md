# dvbviewer-imon-display-tool #

## Description ##
This project connects DVBViewer Software with Soundgraph iMon Displays. <br>
Information like Channel, Title, Progress, ... is shown on the iMon Display.<br>
At the moment Soundgraph iMon VFD and LCD Displays are supported.<br>

Development is discussed in DVBViewer Forum: <a href='http://www.dvbviewer.tv/forum/topic/43959-entwicklung-eines-imon-display-plugins-vfdlcd/'>http://www.dvbviewer.tv/forum/topic/43959-entwicklung-eines-imon-display-plugins-vfdlcd/</a>

<h2>Prerequisites</h2>
iMon Manager ver 7.91.0929 or newer<br>
Microsoft .NET Framework 4.0 Client Profile<br>

<h2>Known Problems</h2>
- crash when return from standby or hibernate<br>
<br>
<h2>Changelog:</h2>
v0.5.2.0<br>
- fixed bug: german special chars like äöüß are replaced for VFD displays<br>
- fixed bug: crash if "close graph" in DVBViewer<br>
v0.5.0.0<br>
- fixed bug: VFD in 0.4.0.0 not working correct - VFD should now work with upper and lower line<br>
- Added support for media-playback including progress bar<br>
- fixed bug: text stays at display if closing dvbviewer while playing media files<br>
v0.4.0.0<br>
- Added speaker icons<br>
- Added record icons and rotating disc icon<br>
- fixed bug: crash if zap to channels which not provide EPG information<br>
v0.3.0.0<br>
- Added "Log-to-file" function. A file (debug.log) is created in Application Directory<br>
- Added System Tray. If Main Window is minimized a tray icon is created<br>
- Added Settings Form<br>
- No bugfixes or new Display functions<br>
v0.2.0.0<br>
- Anzeige von Sendername, Sendungstitel und Sendungsfortschritt auf LCDs<br>
- zweizeilige VFD Displays unterstützt (nur Sendername und Sendungstitel)<br>
- Stabilität gegen plötzliches Beenden/Starten von iMon-Manager und DVBViewer erhöht<br>
v0.1.0.0<br>
- Erster Release (benötigt iMon Manager ab ver 7.91.0929 und .NET Framework 4.0 Client Profile)<br>

<h2>Pictures</h2>
Only a dummy picture - i haven´t taken a photo yet<br>
<img src='http://www.rpgmerchants.com/IMON-LCD.jpg' />

<h2>Develop</h2>
The project was developed with Microsoft Visual Studio C# 2010. C# (C Sharp) was choosen as programming language. You can Checkout the whole project from svn and open it in Visual Studio 2010 or later.