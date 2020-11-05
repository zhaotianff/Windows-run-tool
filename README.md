# Run-List  
Here is a list of all running items supported in Windows+R

<p align="center">
<a href="https://github.com/zhaotianff/Windows-run-tool" target="_blank">
<img align="center" alt="Windows-run-tool" src="Windows-run-tool/Icon/logo.png" />
</a>
</p>
<p align="center">
<a href="https://github.com/zhaotianff/Windows-run-tool/stargazers" target="_blank">
 <img alt="GitHub stars" src="https://img.shields.io/github/stars/zhaotianff/Windows-run-tool.svg" />
</a>
<a href="https://github.com/zhaotianff/Windows-run-tool/releases" target="_blank">
 <img alt="All releases" src="https://img.shields.io/github/downloads/zhaotianff/Windows-run-tool/total.svg" />
</a>
<a href="https://github.com/zhaotianff/Windows-run-tool/network/members" target="_blank">
 <img alt="Github forks" src="https://img.shields.io/github/forks/zhaotianff/Windows-run-tool.svg" />
</a>
<a href="https://github.com/zhaotianff/Windows-run-tool/issues" target="_blank">
 <img alt="All issues" src="https://img.shields.io/github/issues/zhaotianff/Windows-run-tool.svg" />
</a>
</p>

## Run-list include the following item
* All Executable item(.COM;.EXE;.BAT;.CMD;.VBS;.VBE;.JS;.JSE;.WSF;.WSH;.MSC;.CPL) in Path Environment Variables
* Installed software that registered in Register
* Control Panel Items(control.exe & .cpl)
* MMC Items(.msc)
* DLL Items that can be run by rundll32.exe

## Full list

rundll32.exe|Description(en-US/zh-CN)
:--:|:--:
shell32.dll,Control_RunDLL desk.cpl,,2|Open the Desktop Background page of Personalization(壁纸设置)
shell32.dll,SHHelpShortcuts_RunDLL AddPrinter|Run the Add Printer wizard(添加打印机向导)
tcpmonui.dll,LocalAddPortUI|Printer User Interface(TCP/IP 打印机端口向导)
Shell32.dll,SHHelpShortcuts_RunDLL PrintersFolder|Printers folder(打印机)
shell32.dll,Control_RunDLL|Open Control Panel(控制面板)
shell32.dll,Control_RunDLL timedate.cpl|Configure Date and Time(日期时间)
shell32.dll,Control_RunDLL timedate.cpl,,1|Set up additional clocks in the Date and Time applet(附加时钟)
shell32.dll,Control_RunDLL desk.cpl,,0|Configure Desktop icons(桌面图标设置)
devmgr.dll DeviceManager_Execute|Open Device Manager(设备管理器)
shell32.dll,Control_RunDLL desk.cpl|Change Display Settings(显示设置)
shell32.dll,Control_RunDLL access.cpl|Open Ease of Access Center(轻松使用)
shell32.dll,Options_RunDLL 0|Open File Explorer Options at the General tab(文件资源管理器选项)
shell32.dll,Options_RunDLL 2|Open File Explorer Options at the Search tab(文件资源管理器选项-搜索选项卡)
shell32.dll,Options_RunDLL 7|Open File Explorer Options at the View tab(文件资源管理器选项-查看选项卡)
Shell32.dll,SHHelpShortcuts_RunDLL FontsFolder|Open the Fonts folder(字体)
keymgr.dll,PRShowSaveWizardExW|Run the Forgotten Password wizard(启动忘记密码向导)
shell32.dll,Control_RunDLL joy.cpl|Open the Game Controllers applet(游戏控制器)
powrprof.dll, SetSuspendState 0,1,0|Hibernate or Sleep your PC.(进入待机状态（休眠 rundll32.exe powrprof.dll, SetSuspendState 1,1,0）)
user32.dll,LockWorkStation|Lock your computer(锁屏)
shell32.dll,Control_RunDLL srchadmin.dll|Change Indexing options(索引选项)
shell32.dll,Control_RunDLL irprops.cpl|Open the Infared applet(红外线)
shell32.dll,Control_RunDLL ncpa.cpl|Open Network Connections(网络连接)
Shell32.dll,SHHelpShortcuts_RunDLL Connect|Run the Map Network Drive wizard(映射网络驱动器)
User32.dll,SwapMouseButton|Swap left and right mouse buttons(交换鼠标左右键)
Shell32.dll,Control_RunDLL main.cpl @0,0|Open the Mouse Properties dialog window(鼠标属性)
l32.dll,Control_RunDLL odbccp32.cpl|ODBC Data Source Administrator(ODBC数据源)
shell32.dll,Control_RunDLL tabletpc.cpl|Open the Pen and Touch settings(Tablet和笔设置)
Shell32.dll,Control_RunDLL powercfg.cpl|Open Power Options(电源选项)
advapi32.dll,ProcessIdleTasks|Process idle tasks(处理空闲任务？)
shell32.dll,Control_RunDLL appwiz.cpl,,0|Open Programs and Features(程序和功能)
Shell32.dll,Control_RunDLL Intl.cpl,,0|Open the Region applet at the Formats tab(区域设置-格式选项卡)
Shell32.dll,Control_RunDLL Intl.cpl,,1|Open the Region applet at the Location tab(区域设置-位置选项卡)
Shell32.dll,Control_RunDLL Intl.cpl,,2|Open the Region applet at the Administrative tab(区域设置-管理选项卡)
Shell32.dll,Control_RunDLL HotPlug.dll|Run the Safely Remove Hardware wizard(安全删除硬件)
shell32.dll,Control_RunDLL desk.cpl,,1|Open the Screen Saver settings(屏幕保护设置)
shell32.dll,Control_RunDLL wscui.cpl|Open Security and Maintenance(安全和维护)
shell32.dll,Control_RunDLL appwiz.cpl,,3|Configure default programs(默认程序)
shell32.dll,Control_RunDLL NetSetup.cpl|Run the Set Up a Network wizard(设置网络)
Shell32.dll,Control_RunDLL Mmsys.cpl,,0|Open the Sounds applet at the Playback tab(声音-播放选项卡)
Shell32.dll,Control_RunDLL Mmsys.cpl,,1|Open the Sounds applet at the Recording tab(声音-录音选项卡)
Shell32.dll,Control_RunDLL Mmsys.cpl,,2|Open the Sounds applet at the Sounds tab(声音-声音选项卡)
Shell32.dll,Control_RunDLL Mmsys.cpl,,3|Open the Sounds applet at the Communications tab(声音-通信选项卡)
shell32.dll,Options_RunDLL 3|Open Settings at the Personalization - Start page(个性化)
Shell32.dll,Control_RunDLL Sysdm.cpl,,1|Open System Properties at the Computer Name tab(系统属性-计算机名)
keymgr.dll,KRShowKeyMgr|Stored User Names and Passwords(存储的用户名和密码)
Shell32.dll,Control_RunDLL Sysdm.cpl,,1|Open System Properties at the Computer Name tab(系统属性-计算机名选项卡)
Shell32.dll,Control_RunDLL Sysdm.cpl,,2|Open System Properties at the Hardware tab(系统属性-硬件选项卡)
Shell32.dll,Control_RunDLL Sysdm.cpl,,3|Open System Properties at the Advanced tab(系统属性-高级选项卡)
Shell32.dll,Control_RunDLL Sysdm.cpl,,4|Open System Properties at the System Protection tab(系统属性-系统保护选项卡)
Shell32.dll,Control_RunDLL Sysdm.cpl,,5|Open System Properties at the Remote tab(系统属性-远程选项卡)
shell32.dll,Options_RunDLL 1|Open Taskbar Settings in the Settings app(任务栏设置)
shell32.dll,Control_RunDLL nusrmgr.cpl|Open the User Accounts applet(用户账户)
shell32.dll,Control_RunDLL appwiz.cpl,,2|Open Windows Features(启用或关闭Windows功能)
shell32.dll,Control_RunDLL firewall.cpl|Open Windows Firewall(Windows防火墙)
shell32.dll,Control_RunDLL main.cpl @1|Open Keyboard Properties(键盘属性)
SHELL32.DLL,ShellAbout|Open the About Windows dialog window(关于Windows)
InetCpl.cpl,ClearMyTracksByProcess 255|Delete all browsing history in Internet Explorer(删除IE记录)

```
rundll32.exe SHELL32.DLL,ShellAbout
```

<p align="center"><strong>DLL Items that can be run by rundll32.exe</strong></p>


## Screenshots
<div align="center">
	<img align="center" alt="Windows run tool" src="Screenshots/1.png"></img>
</div>  
<br/>
<br/>
<div align="center">
	<img align="center" alt="Windows run tool" src="Screenshots/2.jpg"></img>
</div>
<br/>
<br/>
<div align="center">
	<img align="center" alt="Windows run tool" src="Screenshots/3.gif"></img>
	<p>demo(Windows 10 v1703 Some ms-settings are not supported)</p>
</div>

## License
[Code Licensed under the MIT](LICENSE)
