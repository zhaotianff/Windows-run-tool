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
* Modern UI settings(Windows 10)

## Full list

.cpl|Path|Description
:--:|:--:|:--:
appwiz.cpl|C:\Windows\system32\appwiz.cpl|Shell Application Manager
desk.cpl|C:\Windows\system32\desk.cpl|Desktop Settings Control Panel
FlashPlayerCPLApp.cpl|C:\Windows\system32\FLASHP~1.CPL|Adobe Flash Player Control Panel Applet
hdwwiz.cpl|C:\Windows\system32\hdwwiz.cpl|Add Hardware Control Panel Applet
inetcpl.cpl|C:\Windows\system32\inetcpl.cpl|Internet Control Panel
intl.cpl| C:\Windows\system32\intl.cpl|Control Panel DLL
main.cpl| C:\Windows\system32\main.cpl|Mouse and Keyboard Control Panel Applets
mmsys.cpl|C:\Windows\system32\mmsys.cpl|Audio Control Panel
ncpa.cpl| C:\Windows\system32\ncpa.cpl|Network Connections Control-Panel Stub
powercfg.cpl|C:\Windows\system32\powercfg.cpl|Power Management Configuration Control Panel Applet
sysdm.cpl|C:\Windows\system32\sysdm.cpl|System Applet for the Control Panel
telephon.cpl|C:\Windows\system32\telephon.cpl|Telephony Control Panel
timedate.cpl|C:\Windows\system32\timedate.cpl|Time Date Control Panel Applet
firewall.cpl|C:\Windows\system32\firewall.cpl|Windows Firewall
joy.cpl|C:\Windows\system32\joy.cpl|Game Controller

<p align="center"><strong>Control Panel Items</strong></p>
<br/>

MMC Items|Descrpition
:--:|:--:
azman.msc|    C:\Windows\system32\azman.msc
certlm.msc|   C:\Windows\system32\certlm.msc                         
certmgr.msc|  C:\Windows\system32\certmgr.msc  
comexp.msc|   C:\Windows\system32\comexp.msc  
compmgmt.msc| C:\Windows\system32\compmgmt.msc  
devmgmt.msc|  C:\Windows\system32\devmgmt.msc   
diskmgmt.msc| C:\Windows\system32\diskmgmt.msc   
eventvwr.msc| C:\Windows\system32\eventvwr.msc  
fsmgmt.msc|   C:\Windows\system32\fsmgmt.msc 
gpedit.msc|   C:\Windows\system32\gpedit.msc 
gpmc.msc|     C:\Windows\system32\gpmc.msc                           
gpme.msc|     C:\Windows\system32\gpme.msc
lusrmgr.msc|  C:\Windows\system32\lusrmgr.msc
perfmon.msc|  C:\Windows\system32\perfmon.msc  
rsop.msc|     C:\Windows\system32\rsop.msc 
services.msc| C:\Windows\system32\services.msc  
tapimgmt.msc| C:\Windows\system32\tapimgmt.msc
taskschd.msc| C:\Windows\system32\taskschd.msc
tpm.msc|      C:\Windows\system32\tpm.msc   
WF.msc|       C:\Windows\system32\WF.msc 

<p align="center"><strong>MMC Items</strong></p>
<br/>

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
<br/>


ms-settings|Description
:--:|:--:
ms-settings:workplace|             Access work or school
ms-settings:emailandaccounts|      Email   app accounts
ms-settings:otherusers|            Family   other people
ms-settings:assignedaccess|        Set up a kiosk
ms-settings:signinoptions|         Sign-in options
ms-settings:signinoptions-dynamiclock|                     Sign-in options
ms-settings:sync||Sync your settings
ms-settings:signinoptions-launchfaceenrollment|            Windows Hello setup
ms-settings:signinoptions-launchfingerprintenrollment|     Windows Hello setup
ms-settings:yourinfo|              Your info
ms-settings:appsfeatures|          Apps   Features
ms-settings:appsfeatures-app|      App features
ms-settings:appsforwebsites|       Apps for websites
ms-settings:defaultapps|           Default apps
ms-settings:optionalfeatures|      Manage optional features
ms-settings:maps||Offline Maps
ms-settings:maps-downloadmaps|     Offline Maps
ms-settings:startupapps|           Startup apps
ms-settings:videoplayback|         Video playback
ms-settings:cortana-notifications| Cortana across my devices
ms-settings:cortana-moredetails|   More details
ms-settings:cortana-permissions|   Permissions   History
ms-settings:cortana-windowssearch| Searching Windows
ms-settings:cortana-language|      Talk to Cortana
ms-settings:cortana|               Talk to Cortana
ms-settings:cortana-talktocortana| Talk to Cortana
ms-settings:autoplay|              AutoPlay
ms-settings:bluetooth|             Bluetooth
ms-settings:connecteddevices|      Connected Devices
ms-settings:camera|                Default camera
ms-settings:mousetouchpad|         Mouse   touchpad
ms-settings:pen|| Pen   Windows Ink
ms-settings:printers|              Printers   scanners
ms-settings:devices-touchpad|      Touchpad
ms-settings:typing|                Typing
ms-settings:usb|| USB
ms-settings:wheel|                 Wheel
ms-settings:mobile-devices|        Your phone
ms-settings:easeofaccess-audio|    Audio
ms-settings:easeofaccess-closedcaptioning|                 Closed captions
ms-settings:easeofaccess-colorfilter|                      Color filters
ms-settings:easeofaccess-cursorandpointersize|             Cursor   pointer size
ms-settings:easeofaccess-display|  Display
ms-settings:easeofaccess-eyecontrol|                       Eye control
ms-settings:fonts|                 Fonts
ms-settings:easeofaccess-highcontrast|                     High contrast
ms-settings:easeofaccess-keyboard| Keyboard
ms-settings:easeofaccess-magnifier|Magnifier
ms-settings:easeofaccess-mouse|    Mouse
ms-settings:easeofaccess-narrator| Narrator
ms-settings:easeofaccess-otheroptions|                     Other options
ms-settings:easeofaccess-speechrecognition|                Speech
ms-settings:extras|                Extras
ms-settings:gaming-broadcasting|   Broadcasting
ms-settings:gaming-gamebar|        Game bar
ms-settings:gaming-gamedvr|        Game DVR
ms-settings:gaming-gamemode|       Game Mode
ms-settings:quietmomentsgame|      Playing a game full screen
ms-settings:gaming-trueplay|       TruePlay
ms-settings:gaming-xboxnetworking| Xbox Networking
ms-settings:holographic-audio|     Audio and speech
ms-settings:privacy-holographic-environment|               Environment
ms-settings:holographic-headset|   Headset display
ms-settings:holographic-management|Uninstall
ms-settings:network-airplanemode|  Airplane mode
ms-settings:proximity|             Airplane mode
ms-settings:network-cellular|      Cellular   SIM
ms-settings:datausage|             Data usage
ms-settings:network-dialup|        Dial-up
ms-settings:network-directaccess|  DirectAccess
ms-settings:network-ethernet|      Ethernet
ms-settings:network-wifisettings|  Manage known networks
ms-settings:network-mobilehotspot| Mobile hotspot
ms-settings:nfctransactions|       NFC
ms-settings:network-proxy|         Proxy
ms-settings:network-status|        Status
ms-settings:network|               Status
ms-settings:network-vpn|           VPN
ms-settings:network-wifi|          Wi-Fi
ms-settings:network-wificalling|   Wi-Fi Calling
ms-settings:personalization-background|                    Background
ms-settings:personalization-start-places|                  Choose which folders appear on Start
ms-settings:personalization-colors|Colors
ms-settings:colors|                Colors
ms-settings:personalization-glance|Glance
ms-settings:lockscreen|            Lock screen
ms-settings:personalization-navbar|Navigation bar
ms-settings:personalization|       Personalization (category)
ms-settings:personalization-start| Start
ms-settings:taskbar|               Taskbar
ms-settings:themes|                Themes
ms-settings:mobile-devices|        Your phone
ms-settings:mobile-devices-addphone|                       Your phone
ms-settings:mobile-devices-addphone-direct|                Your phone
ms-settings:privacy-accessoryapps| Accessory apps
ms-settings:privacy-accountinfo|   Account info
ms-settings:privacy-activityhistory|                       Activity history
ms-settings:privacy-advertisingid| Advertising ID
ms-settings:privacy-appdiagnostics|App diagnostics
ms-settings:privacy-automaticfiledownloads|                Automatic file downloads
ms-settings:privacy-backgroundapps|Background Apps
ms-settings:privacy-calendar|      Calendar
ms-settings:privacy-callhistory|   Call history
ms-settings:privacy-webcam|        Camera
ms-settings:privacy-contacts|      Contacts
ms-settings:privacy-documents|     Documents
ms-settings:privacy-email|         Email
ms-settings:privacy-eyetracker|    Eye tracker
ms-settings:privacy-feedback|      Feedback   diagnostics
ms-settings:privacy-broadfilesystemaccess|                 File system
ms-settings:privacy|               General
ms-settings:privacy-speechtyping|  Inking   typing
ms-settings:privacy-location|      Location
ms-settings:privacy-messaging|     Messaging
ms-settings:privacy-microphone|    Microphone
ms-settings:privacy-motion|        Motion
ms-settings:privacy-notifications| Notifications
ms-settings:privacy-customdevices| Other devices
ms-settings:privacy-phonecalls|    Phone calls
ms-settings:privacy-pictures|      Pictures
ms-settings:privacy-radios|        Radios
ms-settings:privacy-speech|        Speech
ms-settings:privacy-tasks|         Tasks
ms-settings:privacy-videos|        Videos
ms-settings:privacy-voiceactivation|                       Voice activation
ms-settings:surfacehub-accounts|   Accounts
ms-settings:surfacehub-sessioncleanup|                     Session cleanup
ms-settings:surfacehub-calling|    Team Conferencing
ms-settings:surfacehub-devicemanagenent|                   Team device management
ms-settings:surfacehub-welcome|    Welcome screen
ms-settings:about|                 About
ms-settings:display-advanced|      Advanced display settings
ms-settings:apps-volume|           App volume and device preferences
ms-settings:batterysaver|          Battery Saver
ms-settings:batterysaver-settings| Battery Saver settings
ms-settings:batterysaver-usagedetails|                     Battery use
ms-settings:clipboard|             Clipboard
ms-settings:display|               Display
ms-settings:savelocations|         Default Save Locations
ms-settings:screenrotation|        Display
ms-settings:quietmomentspresentation|                      Duplicating my display
ms-settings:quietmomentsscheduled| During these hours
ms-settings:deviceencryption|      Encryption
ms-settings:quiethours|            Focus assist
ms-settings:display-advancedgraphics|                      Graphics Settings
ms-settings:messaging|             Messaging
ms-settings:multitasking|          Multitasking
ms-settings:nightlight|            Night light settings
ms-settings:phone-defaultapps|     Phone
ms-settings:project|               Projecting to this PC
ms-settings:crossdevice|           Shared experiences
ms-settings:tabletmode|            Tablet mode
ms-settings:taskbar|               Taskbar
ms-settings:notifications|         Notifications   actions
ms-settings:remotedesktop|         Remote Desktop
ms-settings:phone|                 Phone
ms-settings:powersleep|            Power   sleep
ms-settings:sound|                 Sound
ms-settings:storagesense|          Storage
ms-settings:storagepolicies|       Storage Sense
ms-settings:dateandtime|           Date   time
ms-settings:regionlanguage-jpnime| Japan IME settings
ms-settings:regionformatting|      Region
ms-settings:keyboard|              Language
ms-settings:regionlanguage|        Language
ms-settings:regionlanguage-bpmfime|Language
ms-settings:regionlanguage-cangjieime|                     Language
ms-settings:regionlanguage-chsime-pinyin-domainlexicon|    Language
ms-settings:regionlanguage-chsime-pinyin-keyconfig|        Language
ms-settings:regionlanguage-chsime-pinyin-udp|              Language
ms-settings:regionlanguage-chsime-wubi-udp|                Language
ms-settings:regionlanguage-quickime|                       Language
ms-settings:regionlanguage-chsime-pinyin|                  Pinyin IME settings
ms-settings:speech|                Speech
ms-settings:regionlanguage-chsime-wubi|                    Wubi IME settings
ms-settings:activation|            Activation
ms-settings:backup|                Backup
ms-settings:delivery-optimization| Delivery Optimization
ms-settings:findmydevice|          Find My Device
ms-settings:developers|            For developers
ms-settings:recovery|              Recovery
ms-settings:troubleshoot|          Troubleshoot
ms-settings:windowsdefender|       Windows Security
ms-settings:windowsinsider|        Windows Insider Program
ms-settings:windowsupdate|         Windows Update
ms-settings:windowsupdate-action|  Windows Update
ms-settings:windowsupdate-options| Windows Update-Advanced options
ms-settings:windowsupdate-restartoptions|                  Windows Update-Restart options
ms-settings:windowsupdate-history| Windows Update-View update history
ms-settings:workplace-provisioning|Provisioning
ms-settings:provisioning|          Provisioning
ms-settings:windowsanywhere|       Windows Anywhere

<p align="center"><strong>Windows 10 Modern UI Settings</strong></p>

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
