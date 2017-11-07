Imports System.Text
Imports System.IO
Imports System.IO.StreamWriter
Imports Microsoft.Win32
Imports System.Net
Imports System.Security
Imports System.Drawing.Drawing2D
Imports System.Xml
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Net.Sockets
Imports System.Reflection

Public Class frmMain
#Region "Declaration"
    'Private Declare Function ReleaseCapture Lib "user32" () As Long

    'Private Declare Function SendMessage Lib "user32" _
    'Alias "SendMessageA" _
    '(ByVal hwnd As Long, _
    ' ByVal wMsg As Long, _
    'ByVal wParam As Long, _
    'lParam As Long) As Long

    'Private Const WM_SYSCOMMAND = &H112
    'Private Const MOUSE_MOVE = &HF012

    Private WithEvents myScanner As clsScanner
    Private WithEvents myScanner1 As clsScanner

    Private isMouseDown As Boolean = False
    Private mouseLoc As New Point

    Private hidFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\CodeMonkey"
    Private confAppPath As String = ""
    Private confConfPath As String = ""
    Private confVersionPath As String = ""
    Private confServer As String = ""
    Private confIPs As String = ""
    Private confDomain As String = ""
    Private confServVersion As String = ""
    Private appName As String = "AsbagVPN"
    Private confName As String = "config.ini"
    Private confAppName As String = appName & ".exe"
    Private oVPNapp As String = Application.StartupPath & "\data\bin\openvpn.exe"
    'Private oVPNappAlt As String = Application.StartupPath & "\data\bin\openvpn_alt.exe"
    Private tap64path As String = "\data\bin\tapinstall64.exe"
    Private tap32path As String = "\data\bin\tapinstall32.exe"
    Private oLogPath As String = Chr(34) & hidFolder.Replace("\", "/") & "/cm.log" & Chr(34)
    Private tmpoLogPath As String = Chr(34) & hidFolder & "\cm.log" & Chr(34)
    Private caPath As String = Chr(34) & hidFolder.Replace("\", "/") & "/cm.cert" & Chr(34)
    Private autoScan As Boolean

    Private sKey As String = "Test"

    Const sServerList As String = "server.lst"
    Const confFolder As String = "\"
    Const sVersion As String = "version.xml"
    Private confUpdatePath As String = ""
    Private serversDL() As Uri
    Private confServers As Integer
    Private serverCnt As Integer
    Private currentServer As Integer
    Private servers() As String
    Private serverVersion As String

    Private siteLink As String
    Private portList() As String
    'Private pingIndex As Integer = 0
    Private assignedIP As String
    Private AuthReq As Boolean
    Private isAlt As Boolean
    Private servList() As String

    Private smartIP() As String
    Private smartTCPConfig As String
    Private smartUDPConfig As String
    Private smartServers As Integer
    Private smartTCPPort As String
    Private smartUDPPort As String
    Private smartServerAlias() As String
    Private smartTCPports() As String
    Private smartUDPports() As String
    Private smartDefTCPLport As String
    Private smartDefUDPLport As String
    Private smartLports() As String
    Private smartCert As String = ""

    Private LastProc As Integer = 0
    Private torrents() As String
    Private torrentsex() As String

    Private vpnStat As String

    Private tempDec As String

    Private isConnected As Boolean = False
    Private isInit As Boolean = False
    Private isAuth As Boolean = False
    Private isRecon As Boolean = False
    Private isUEnter As Boolean = False
    Private isPEnter As Boolean = False
    Private isProxy As Boolean = False
    Private isSocksProxy As Boolean = False
    Private isAutoStart As Boolean = False
    Private isMinTray As Boolean = True
    Private isBind As Boolean = False
    Private osType As Integer = 4
    Private ovpnProc As Process = New Process

    Dim currDir As String = Application.StartupPath

    Private currentproto As Integer = 1
    Private serverport As Integer = 0
    Private portctr As Integer = 1
    Private lportctr As Integer = 1
    Private lasttemp As String = ""
    Dim xPos As Integer

    Dim fWidth = 277
    Dim fHeight = 560

    Private WithEvents webList As New Net.WebClient
    Private WithEvents webDownload As New Net.WebClient
#End Region

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("pinger")
        For Each p As Process In pProcess
            p.Kill()
        Next

        My.Settings.UseProxy = chkUseProxy.CheckState
        My.Settings.ProxyIP = txtProxyIP.Text
        My.Settings.ProxyPort = txtProxyPort.Text
        My.Settings.UseSocks = chkSocks.CheckState

        SaveUser(cmbAltServer.SelectedItem)

        DeleteFiles()

        KillProcess()
    End Sub

    Private Sub frmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        isMouseDown = True
        mouseLoc = New Point(Cursor.Position.X - Me.Location.X, Cursor.Position.Y - Me.Location.Y) '// get coordinates.
    End Sub

    Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        If isMouseDown = True Then
            Me.Location = New Point(Cursor.Position.X - mouseLoc.X, Cursor.Position.Y - mouseLoc.Y) '// set coordinates.
        End If
    End Sub

    Private Sub frmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        isMouseDown = False
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox(GetMyIP())
        If IO.Directory.Exists(hidFolder) = False Then IO.Directory.CreateDirectory(hidFolder)
        IO.File.SetAttributes(hidFolder, FileAttributes.Directory + FileAttributes.Hidden + FileAttributes.System)

        If Not IsAdmin() Then
            MsgBox("WARNING: You are not running AsbagVPN as admininistrator!")
        End If

        Dim isSocks As Boolean = False

        osType = IntPtr.Size

        'checkTap()
        checkTapHSS()

        'regVersion.Close()
        lblTAP.Text = "Driver Installed"
        cmdInstall.Enabled = False
        cmdUninstall.Enabled = True

        Dim sOld As New FileInfo(currDir & "\" & confName & ".old")
        Try
            If sOld.Length > 0 Then sOld.Delete()
        Catch
        End Try

        Dim sOld1 As New FileInfo(currDir & "\" & confAppName & ".old")
        Try
            If sOld1.Length > 0 Then sOld1.Delete()
        Catch
        End Try

        Me.Width = fWidth

        CenterForm()

        If My.Settings.SaveName Then
            txtSmartUsername.Text = My.Settings.Username
            txtSmartPassword.Text = DecryptString128Bit(My.Settings.Password, "Tomoe")
        Else
            txtSmartUsername.Text = ""
            txtSmartPassword.Text = ""
        End If
        chkRemember.Checked = My.Settings.SaveName
        txtProxyIP.Text = My.Settings.ProxyIP
        txtProxyPort.Text = My.Settings.ProxyPort
        isSocks = My.Settings.UseSocks
        txtProxyIP.Enabled = My.Settings.UseProxy
        txtProxyPort.Enabled = My.Settings.UseProxy
        chkUseProxy.Checked = My.Settings.UseProxy
        chkSocks.Enabled = My.Settings.UseSocks

        chkOption.Checked = My.Settings.Flush

        chkTray.Checked = My.Settings.Minimize
        isMinTray = My.Settings.Minimize

        chkWinStart.Checked = My.Settings.WindowsStart

        chkRemote.Checked = My.Settings.ManualRemote
        cmbPort.Enabled = Not My.Settings.ManualRemote
        txtRemotePort.Enabled = My.Settings.ManualRemote

        chkLocal.Checked = My.Settings.ManualLocal
        cmbLports.Enabled = Not My.Settings.ManualLocal
        txtLocalPort.Enabled = My.Settings.ManualLocal

        chkAppStart.Checked = My.Settings.AutoStart
        isAutoStart = My.Settings.AutoStart

        chkNobind.Checked = My.Settings.NoBind
        isBind = My.Settings.NoBind
        chkLocal.Enabled = My.Settings.NoBind
        txtLocalPort.Enabled = chkLocal.CheckState

        txtPingInt.Text = My.Settings.PingInterval

        If txtPingInt.Text = "0" Then
            tmrPinger.Enabled = False
        Else
            tmrPinger.Interval = CInt(txtPingInt.Text) * 1000
        End If

        txtLocalPort.Text = My.Settings.LocalPort
        txtRemotePort.Text = My.Settings.RemotePort

        LoadSettings()
        LoadConfig(cmbAltServer.SelectedItem.ToString)
        GetUser(cmbAltServer.SelectedItem.ToString)

        'cmbAltServer_SelectedIndexChanged(Nothing, Nothing)

        niIcon.Text = appName & " - Disconnected"
        DeleteFiles()
        ReduceMemoryUsage()
        'MsgBox(System.IO.Directory.GetCurrentDirectory)
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        If MsgBox("Do you really want to exit?", vbYesNo) = vbYes Then
            Reset()
            KillProcess()
            Application.Exit()
        End If
    End Sub

    Private Sub lblMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMin.Click
        Me.Visible = False
    End Sub

    Private Sub niIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niIcon.MouseDoubleClick
        Me.Show()
        Me.BringToFront()
        Me.WindowState = FormWindowState.Normal
        Me.Focus()
        'Me.Focus = True
    End Sub

    Private Sub subExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subExit.Click
        lblClose_Click(Nothing, Nothing)
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        cmbServer.Items.Clear()

        If Not smartServerAlias(0) = "N/A" Then
            For x = 0 To smartServerAlias.Length - 1
                'cmbServer.Items.Add(smartIP(x))
                cmbServer.Items.Add(smartServerAlias(x))
            Next
        Else
            For x = 0 To smartServers - 1
                'cmbServer.Items.Add(smartIP(x))
                cmbServer.Items.Add(vpnStat & " Server " & x + 1)
            Next
        End If

        cmbPort.Items.Clear()
        If cmbType.SelectedIndex = 0 Then
            For i = 0 To smartTCPports.Length - 1
                cmbPort.Items.Add(smartTCPports(i).Trim)
            Next
        Else
            For i = 0 To smartUDPports.Length - 1
                cmbPort.Items.Add(smartUDPports(i).Trim)
            Next
        End If

        If cmbType.SelectedIndex = 0 Then
            cmbPort.SelectedIndex = CInt(smartTCPPort)
        Else
            cmbPort.SelectedIndex = CInt(smartUDPPort)
        End If

        cmbLports.Items.Clear()
        For i = 0 To smartLports.Length - 1
            cmbLports.Items.Add(smartLports(i).Trim)
        Next
        'cmbLports.SelectedIndex = 0

        'cmbServer.SelectedIndex = 0
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Dim currConfig As String

        If Not lblTAP.Text = "Driver Installed" Then
            MsgBox("No Driver Installed.")
            Exit Sub
        End If

        DeleteFiles()
        DisableAll()
        isConnected = False
        isInit = False
        isAuth = False
        isUEnter = False
        isPEnter = False
        xPos = 0

        If cmdConnect.Text = "Connect" Then
            ExtractCert()

            ovpnProc.StartInfo.FileName = oVPNapp

            If AuthReq Then
                If txtSmartUsername.Text <= "" Then
                    lblStatus.Text = "Username required"
                    Reset()
                    Exit Sub
                End If

                If txtSmartPassword.Text <= "" Then
                    Reset()
                    lblStatus.Text = "Password required."
                    Exit Sub
                End If
            End If

            'If AuthReq = True Then
            SaveUser(cmbAltServer.SelectedItem.ToString)
            'End If

            If chkUseProxy.CheckState Then
                If chkSocks.CheckState Then
                    oLogPath = oLogPath & " --socks-proxy " & txtProxyIP.Text & " " & txtProxyPort.Text & " --socks-proxy-retry"
                Else
                    oLogPath = oLogPath & " --http-proxy " & txtProxyIP.Text & " " & txtProxyPort.Text
                End If
            Else
                oLogPath = tmpoLogPath.Replace("\", "/")
            End If

            portctr = 1
            serverport = cmbServer.SelectedIndex
            currentproto = cmbType.SelectedIndex

            If autoScan Then
                If cmbType.SelectedIndex = 1 Then
                    If chkRemote.Checked = CheckState.Unchecked Then
                        If cmbPort.SelectedItem.ToString = "AUTO" Then
                            cmdConnect.Text = "Checking"
                            myScanner = New clsScanner(smartIP(cmbServer.SelectedIndex), smartUDPports(portctr), smartUDPports(portctr))
                            lblStatus.Text = "Checking port " & smartUDPports(portctr)
                            myScanner.Start()
                            Exit Sub
                        End If
                    End If
                Else
                    If chkRemote.Checked = CheckState.Unchecked Then
                        If cmbPort.SelectedItem.ToString = "AUTO" Then
                            cmdConnect.Text = "Checking"
                            myScanner = New clsScanner(smartIP(cmbServer.SelectedIndex), smartTCPports(portctr), smartTCPports(portctr))
                            lblStatus.Text = "Checking port " & smartTCPports(portctr)
                            myScanner.Start()
                            Exit Sub
                        End If
                    End If
                End If

                If chkLocal.Checked = True Then
                    If cmbLports.SelectedItem.ToString = "AUTO" Then
                        cmdConnect.Text = "Checking"
                        myScanner1 = New clsScanner(smartIP(cmbServer.SelectedIndex), smartLports(lportctr), smartLports(lportctr))
                        lblStatus.Text = "Checking port " & smartLports(lportctr)
                        myScanner1.Start()
                        Exit Sub
                    End If
                End If
            End If
            'MsgBox("test")
            If cmbType.SelectedIndex = 0 Then
                If smartTCPConfig = "N/A" Then
                    lblStatus.Text = "No TCP Config"
                    cmdConnect.Text = "Connect"
                    SetBalloon("disconnected", "No TCP Config")
                    Exit Sub
                End If
                If cmbPort.SelectedItem.ToString = "N/A" Then
                    lblStatus.Text = "No Port Selected"
                    cmdConnect.Text = "Connect"
                    SetBalloon("disconnected", "No Port Selected")
                    Exit Sub
                End If
                currConfig = smartTCPConfig.Replace("%server%", smartIP(cmbServer.SelectedIndex))

                If isBind Then
                    currConfig = currConfig & " --lport %lport%"
                Else
                    currConfig = currConfig & " --nobind"
                End If

                If chkLocal.Checked Then
                    currConfig = currConfig.Replace("%lport%", cmbLports.SelectedItem.ToString)
                Else
                    currConfig = currConfig.Replace("%lport%", smartDefTCPLport)
                End If

                If chkRemote.Checked Then
                    currConfig = currConfig.Replace("%port%", txtRemotePort.Text) & " --log " & Chr(34) & oLogPath & Chr(34)
                Else
                    currConfig = currConfig.Replace("%port%", cmbPort.SelectedItem.ToString) & " --log " & Chr(34) & oLogPath & Chr(34)
                End If
            Else
                If smartUDPConfig = "N/A" Then
                    lblStatus.Text = "No UDP Config"
                    cmdConnect.Text = "Connect"
                    SetBalloon("disconnected", "No UDP Config")
                    Exit Sub
                End If
                If cmbPort.SelectedItem.ToString = "N/A" Then
                    lblStatus.Text = "No Port Selected"
                    cmdConnect.Text = "Connect"
                    SetBalloon("disconnected", "No Port Selected")
                    Exit Sub
                End If
                currConfig = smartUDPConfig.Replace("%server%", smartIP(cmbServer.SelectedIndex))

                If isBind Then
                    currConfig = currConfig & " --lport %lport%"
                Else
                    currConfig = currConfig & " --nobind"
                End If

                If chkLocal.Checked Then
                    currConfig = currConfig.Replace("%lport%", cmbLports.SelectedItem.ToString)
                Else
                    currConfig = currConfig.Replace("%lport%", smartDefUDPLport)
                End If

                If chkRemote.Checked Then
                    currConfig = currConfig.Replace("%port%", txtRemotePort.Text) & " --log " & Chr(34) & oLogPath & Chr(34)
                Else
                    currConfig = currConfig.Replace("%port%", cmbPort.SelectedItem.ToString) & " --log " & Chr(34) & oLogPath & Chr(34)
                End If
            End If
            currConfig = currConfig & " --ca " & Chr(34) & caPath & Chr(34)
            lblStatus.Text = "Connecting to " & cmbServer.SelectedItem
            Delay(2)
            'MsgBox(currConfig)
            'Clipboard.SetText(currConfig)
            ovpnProc.StartInfo.Arguments = currConfig '& " --up " & Chr(34) & Application.StartupPath & "\data\config\flush-dns.bat" & Chr(34)
            ovpnProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            ovpnProc.StartInfo.Verb = "runas"
            ovpnProc.StartInfo.CreateNoWindow = True
            'ovpnProc.PriorityClass
            ovpnProc.StartInfo.UseShellExecute = False
            ovpnProc.StartInfo.RedirectStandardInput = True
            ovpnProc.Start()
            ovpnProc.PriorityClass = ProcessPriorityClass.Normal

            cmdConnect.Text = "Connecting"
            SetBalloon("connecting", "Connecting")

            tmrStat.Enabled = True

            Delay(2.2)
            Dim sCert As New FileInfo(hidFolder & "\cm.cert")
            If sCert.Exists Then sCert.Delete()
        Else
            'KillProcess()
            'EnableAll()
            Reset()
            ReduceMemoryUsage()
        End If

        'sFile.Delete()
    End Sub

    Private Sub tmrStat_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStat.Tick
        Dim sTemp As String
        Dim sLogFile As New FileStream(tmpoLogPath.Replace(Chr(34), ""), FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite)
        'IO.File.SetLastWriteTime(tmpoLogPath, New Date(2012, 12, 12))
        Dim sLogF As New System.IO.StreamReader(sLogFile)

        'sStatF.Close()
        'sStatFile.Close()

        Dim tempPos As Integer

        If sLogFile.Length > 0 Then
            sTemp = sLogF.ReadToEnd
            'ListBox1.Items.Add(sTemp)
            If isConnected = False Then
                tempPos = sTemp.IndexOf("Options error")
                If tempPos > -1 Then
                    lblStatus.Text = "Options error"
                    SetBalloon("disconnected", "Options error")
                    Reset()
                End If

                If sTemp.IndexOf("Connection refused") > 0 Or sTemp.IndexOf("Cannot parse IP address") > 0 Then
                    lblStatus.Text = "Can't connect to proxy"
                    SetBalloon("disconnected", "Can't connect to proxy")
                    'ovpnProc.Dispose()
                    Reset()
                End If
                'If isAuth = False Then
                tempPos = sTemp.IndexOf("Peer Connection Initiated", xPos)
                If tempPos > xPos Then
                    lblStatus.Text = "Finalizing..."
                    'isAuth = True
                    xPos = tempPos + 25
                End If
                'End If
                If isInit = False Then
                    tempPos = sTemp.IndexOf("TLS: Initial packet from", xPos)
                    If tempPos > xPos Then
                        lblStatus.Text = "Initiating connection..."
                        'ovpnProc.StandardInput.WriteLine("\x3")
                        'ovpnProc.StandardInput.Close()
                        'ovpnProc.CloseMainWindow()
                        isInit = True
                        xPos = tempPos + 24
                    End If
                End If
                'If ix3 > 0 Then ix3 = ix3 + 18

                tempPos = sTemp.IndexOf("AUTH_FAILED")
                If tempPos > xPos Then
                    lblStatus.Text = "Check Username/Password"
                    SetBalloon("disconnected", "Check Username/Password")
                    Reset()
                End If

                If isUEnter = False Then
                    tempPos = sTemp.IndexOf("Enter Auth Username")
                    If tempPos > xPos Then
                        ovpnProc.StandardInput.WriteLine(txtSmartUsername.Text)
                        isUEnter = True
                        xPos = tempPos + 19
                    End If
                End If
                If isPEnter = False Then
                    tempPos = sTemp.IndexOf("Enter Auth Password")
                    If tempPos > xPos Then
                        ovpnProc.StandardInput.WriteLine(txtSmartPassword.Text)
                        isPEnter = True
                        xPos = tempPos + 19
                    End If
                End If

                tempPos = sTemp.IndexOf("Initialization Sequence Completed", xPos)
                If tempPos > xPos Then

                    Try
                        Dim tmpLst1 As Integer
                        Dim tmpLst2 As Integer
                        tmpLst1 = sTemp.IndexOf("TAP-WIN32 device [", xPos)
                        tmpLst2 = sTemp.IndexOf("]", tmpLst1)
                        sLAN = sTemp.Substring(tmpLst1 + 18, tmpLst2 - (tmpLst1 + 18))

                        'MsgBox(sLAN)
                    Catch
                    End Try

                    'tmrNetStat.Start()

                    xPos = tempPos + 33

                    If chkOption.CheckState = CheckState.Checked Then
                        Application.DoEvents()
                        lblStatus.Text = "Stoping DNS Cache"
                        Shell("net.exe stop dnscache", AppWinStyle.Hide, True)
                        Application.DoEvents()
                        lblStatus.Text = "Starting DNS Cache"
                        Shell("net.exe start dnscache", AppWinStyle.Hide, True)
                        Application.DoEvents()
                        lblStatus.Text = "Flushing DNS"
                        Shell("ipconfig.exe /flushdns", AppWinStyle.Hide, False)
                        Application.DoEvents()
                        lblStatus.Text = "Registering DNS"
                        Shell("ipconfig.exe /registerdns", AppWinStyle.Hide, True)
                    End If

                    lblStatus.Text = "Connected to " & cmbServer.SelectedItem


                    cmdConnect.Text = "Disconnect"
                    SetBalloon("connected", "Connected")
                    isConnected = True

                    If isMinTray Then
                        Me.Hide()
                    End If

                    If Not txtPingInt.Text = "0" Then tmrPinger.Enabled = True : tmrPinger.Start()

                    'bw.CancelAsync()
                    'bw.RunWorkerAsync()

                    If cmbServer.SelectedItem.ToString.IndexOf("Torrent") <= 0 Then
                        tmrBlocker.Start()
                    End If

                    ReduceMemoryUsage()
                End If

                tempPos = sTemp.IndexOf("WSAEADDRINUSE", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isUEnter = True
                    lblStatus.Text = "Address already in use"
                    SetBalloon("reconnecting", "Address in use. Retrying...")
                    xPos = tempPos + 13
                End If

                tempPos = sTemp.IndexOf("WSAETIMEDOUT", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isPEnter = True
                    lblStatus.Text = "Timed out. Retrying..."
                    SetBalloon("reconnecting", "Timed out")
                    xPos = tempPos + 12
                End If

                tempPos = sTemp.IndexOf("process restarting", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isPEnter = True
                    lblStatus.Text = "Error. Retrying..."
                    SetBalloon("reconnecting", "Retrying")
                    xPos = tempPos + 18
                End If

                tempPos = sTemp.IndexOf("Inactivity timeout", xPos)
                If tempPos > xPos Then
                    lblStatus.Text = "Inactivity timeout"
                    SetBalloon("disconnected", "Inactivity timeout")
                    xPos = tempPos + 18
                    Reset()
                End If

                tempPos = sTemp.IndexOf("WSAECONNRESET")
                If tempPos > 0 Then
                    lblStatus.Text = "Connection reset"
                    Reset()

                    SetBalloon("disconnected", "Server is down or full. Please try another server")
                    KillProcess()
                    cmdConnect_Click(Nothing, Nothing)
                End If
            Else
                tempPos = sTemp.IndexOf("Options error")
                If tempPos > -1 Then
                    lblStatus.Text = "Options error"
                    SetBalloon("disconnected", "Options error")
                    Reset()
                End If

                tempPos = sTemp.IndexOf("WSAEADDRINUSE", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isPEnter = True
                    lblStatus.Text = "Address in use. Retrying..."
                    SetBalloon("reconnecting", "Address already in use")
                    xPos = tempPos + 13
                End If

                tempPos = sTemp.IndexOf("WSAETIMEDOUT", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isPEnter = True
                    lblStatus.Text = "Timed out. Retrying..."
                    SetBalloon("reconnecting", "Timed out")
                    xPos = tempPos + 12
                End If

                tempPos = sTemp.IndexOf("process restarting", xPos)
                If tempPos > xPos Then
                    isConnected = False
                    isInit = False
                    isAuth = False
                    isUEnter = True
                    isPEnter = True
                    lblStatus.Text = "Error. Retrying..."
                    SetBalloon("reconnecting", "Retrying")
                    xPos = tempPos + 18
                End If

                tempPos = sTemp.IndexOf("Inactivity timeout", xPos)
                If tempPos > xPos Then
                    lblStatus.Text = "Inactivity timeout"
                    SetBalloon("disconnected", "Inactivity timeout")
                    xPos = tempPos + 18
                    Reset()
                End If

                tempPos = sTemp.IndexOf("TLS handshake failed")
                If tempPos > 0 Then
                    lblStatus.Text = "TLS handshake failed"
                    Reset()

                    SetBalloon("disconnected", "TLS handshake failed")
                    KillProcess()
                    cmdConnect_Click(Nothing, Nothing)
                End If

                tempPos = sTemp.IndexOf("WSAECONNRESET")
                If tempPos > 0 Then
                    lblStatus.Text = "Connection reset"
                    Reset()

                    SetBalloon("disconnected", "Server is down or full. Please try another server")
                    KillProcess()
                    cmdConnect_Click(Nothing, Nothing)
                End If

            End If

            sLogF.Close()
            sLogFile.Close()
            'sLogF.Dispose()
            'sLogFile.Dispose()
        End If
    End Sub

    Private Sub cmdInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInstall.Click
        InstallTapAll()
    End Sub

    Private Sub cmdUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUninstall.Click
        UninstallTapAll()
    End Sub

    Private Sub txtIMEI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("1234567890", Chr(KeyAscii)) = 0 And KeyAscii <> 8 Then KeyAscii = 0
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub tmrNetStat_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub webList_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles webList.DownloadFileCompleted
        Dim sTemp As String
        Dim sLogFile As New FileStream(currDir & confFolder & sServerList, FileMode.OpenOrCreate, FileAccess.Read, System.IO.FileShare.ReadWrite)
        Dim sLogF As New StreamReader(sLogFile)
        sTemp = sLogF.ReadToEnd
        sLogF.Close()
        servers = sTemp.Split(vbNewLine)
        serverCnt = servers.Length - 1
        ReDim serversDL(0 To serverCnt)

        For x = 0 To serverCnt
            serversDL(x) = New Uri(confUpdatePath & servers(x).Trim)
        Next

        lblStatus.Text = "Server List Downloaded"

        Application.DoEvents()

        Try
            webDownload.DownloadFileAsync(serversDL(currentServer), currDir & confFolder & servers(currentServer).Trim)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub webList_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles webList.DownloadProgressChanged
        Try
            lblStatus.Text = "Downloading server list..."
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            progress1.Value = Integer.Parse(Math.Truncate(percentage).ToString())
        Catch
        End Try
    End Sub

    Private Sub webDownload_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles webDownload.DownloadFileCompleted
        If currentServer = serverCnt Then
            Dim sOld As New FileInfo(currDir & "\" & confName & ".new")
            Try
                If sOld.Length > 0 Then
                    File.Move(currDir & "\" & confName, currDir & "\" & confName & ".old")
                    File.Move(currDir & "\" & confName & ".new", currDir & "\" & confName)
                    File.Delete(currDir & "\" & confName & ".old")
                End If
            Catch
            End Try

            Dim appnew As New FileInfo(Application.ExecutablePath & ".new")
            Try
                If appnew.Length > 0 Then
                    File.Move(Application.ExecutablePath, Application.ExecutablePath & ".old")
                    File.Move(Application.ExecutablePath & ".new", Application.ExecutablePath)
                End If
            Catch
            End Try

            lblStatus.Text = "Update Complete"
            MsgBox("Update(s) will take effect on the next start.")
            'Dim ans As MsgBoxResult
            'ans = MsgBox("The program requires a restart to apply the updates. Do you want to restart?", MsgBoxStyle.YesNo)
            'If ans = MsgBoxResult.Yes Then
            'Application.Restart()
            'End If
        Else
            lblStatus.Text = servers(currentServer).Trim & " Downloaded"
            currentServer = currentServer + 1
            Try
                webDownload.DownloadFileAsync(serversDL(currentServer), currDir & confFolder & servers(currentServer).Trim)
                Application.DoEvents()
                lblStatus.Text = "Downloading " & servers(currentServer).Trim
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub webDownload_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles webDownload.DownloadProgressChanged
        Try
            lblStatus.Text = "Downloading " & servers(currentServer).Trim
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            progress1.Value = Integer.Parse(Math.Truncate(percentage).ToString())
        Catch
        End Try
    End Sub

    Private Sub chkUseProxy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseProxy.CheckedChanged
        My.Settings.UseProxy = chkUseProxy.CheckState
        My.Settings.ProxyIP = txtProxyIP.Text
        My.Settings.ProxyPort = txtProxyPort.Text
        txtProxyIP.Enabled = chkUseProxy.CheckState
        txtProxyPort.Enabled = chkUseProxy.CheckState
        chkSocks.Checked = chkUseProxy.CheckState
        isProxy = chkUseProxy.CheckState
    End Sub

    Private Sub txtProxyIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProxyIP.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("1234567890.", Chr(KeyAscii)) = 0 And KeyAscii <> 8 Then KeyAscii = 0
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtProxyPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProxyPort.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("1234567890", Chr(KeyAscii)) = 0 And KeyAscii <> 8 Then KeyAscii = 0
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmdRandom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRandom.Click
        Dim rd As New Random()
        'Randomize(cmbServer.Items.Count - 1)
        cmbServer.SelectedIndex = rd.Next(cmbServer.Items.Count - 1)
        cmdConnect_Click(Nothing, Nothing)
    End Sub

    Private Sub chkRemember_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRemember.CheckedChanged
        My.Settings.SaveName = chkRemember.CheckState
        My.Settings.Username = txtSmartUsername.Text
        My.Settings.Password = EncryptString128Bit(txtSmartPassword.Text, "Tomoe")
    End Sub

    Private Sub cmbAltServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAltServer.SelectedIndexChanged
        'LoadConfig(cmbAltServer.SelectedItem.ToString)
        'If AuthReq = True Then
        'txtSmartUsername.Enabled = True
        'txtSmartPassword.Enabled = True
        'Else
        'txtSmartUsername.Text = "Not Applicable"
        'txtSmartPassword.Text = "Not Applicable"
        'txtSmartUsername.Enabled = False
        'txtSmartPassword.Enabled = False
        'End If
        'LoadUser(cmbAltServer.SelectedItem.ToString)
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start(siteLink)
    End Sub

    Private Sub chkOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOption.CheckedChanged
        My.Settings.Flush = chkOption.CheckState
    End Sub

    Private Sub tmrPinger_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPinger.Tick
        Dim ipAddy As String = "google.com.ph"
        Dim pinger As New Net.NetworkInformation.Ping()
        AddHandler pinger.PingCompleted, AddressOf PingCompleted
        Try
            pinger.SendAsync(ipAddy, 5000, ipAddy)
            'pinger = Nothing
        Catch
            CType(pinger, IDisposable).Dispose()
        End Try
        'GC.Collect()
    End Sub

    Private Sub PingCompleted(ByVal sender As Object, ByVal e As Net.NetworkInformation.PingCompletedEventArgs)
        Try

        Catch

        Finally
            CType(sender, IDisposable).Dispose()
            'GC.Collect()
        End Try
    End Sub

#Region "Misc"
    Private Sub CheckUpdate()
        Dim DLPath As New Uri(confUpdatePath & sServerList)
        'Dim versionAD As String = confVersionPath
        Dim Str As System.IO.Stream
        Dim srRead As System.IO.StreamReader

        lblStatus.Text = "Checking for updates..."
        Application.DoEvents()

        Try
            ' make a Web request
            Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(confUpdatePath & sVersion)
            Dim resp As System.Net.WebResponse = req.GetResponse
            req.Timeout = 10000

            Str = resp.GetResponseStream
            srRead = New System.IO.StreamReader(Str)
            serverVersion = srRead.ReadToEnd.Trim
            'MsgBox(confServVersion.Trim)
            Application.DoEvents()
            If Not confServVersion.Trim = serverVersion And serverVersion > "" Then
                lblStatus.Text = "Updates found"
                progress1.Value = 0
                currentServer = 0
                Application.DoEvents()
                Try
                    'DeleteDirContents(New IO.DirectoryInfo(currDir & confFolder.Substring(0, confFolder.Length - 1)))
                    'MsgBox(currDir & confFolder.Substring(0, confFolder.Length - 1))
                    webList.DownloadFileAsync(DLPath, currDir & confFolder & sServerList)
                    Application.DoEvents()
                    lblStatus.Text = "Fetching list..."
                Catch ex As Exception
                    lblStatus.Text = ex.Message
                End Try
            Else
                lblStatus.Text = "Up-to-date"
            End If
            srRead.Close()
            Str.Close()
        Catch ex As Exception
            lblStatus.Text = "Connected to server"
        End Try
    End Sub

    Private Sub DeleteFiles()
        Dim sLog As New FileInfo(tmpoLogPath.Replace(Chr(34), ""))
        Dim sCert As New FileInfo((hidFolder & "\cm.cert").Replace(Chr(34), ""))

        On Error Resume Next
        If sLog.Exists Then sLog.Delete()
        If sCert.Exists Then sCert.Delete()
        On Error GoTo 0
    End Sub

    Private Sub DisableAll()
        cmbType.Enabled = False
        cmbServer.Enabled = False
        cmbPort.Enabled = False
        cmdRandom.Enabled = False
        cmbAltServer.Enabled = False
        '.Enabled = False
        txtSmartPassword.Enabled = False
        txtSmartUsername.Enabled = False
    End Sub

    Private Sub EnableAll()
        cmbType.Enabled = True
        cmbServer.Enabled = True

        If chkRemote.Checked Then
            cmbPort.Enabled = False
        Else
            cmbPort.Enabled = True
        End If
        cmdRandom.Enabled = True
        cmbAltServer.Enabled = True
        'Panel3.Enabled = True

        If AuthReq Then
            txtSmartPassword.Enabled = True
            txtSmartUsername.Enabled = True
            chkRemember.Enabled = True
        Else
            txtSmartPassword.Enabled = False
            txtSmartUsername.Enabled = False
            chkRemember.Enabled = False
        End If
    End Sub

    Private Sub KillProcess()
        If ovpnProc IsNot Null Then
            Try
                ovpnProc.Kill()
                'ovpnProc.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub LoadUser(ByVal accnt As String)
        Dim regRkey As RegistryKey

        regRkey = Registry.CurrentUser.OpenSubKey("Software\\Code Monkey\\" & appName, True)
        If regRkey Is Nothing Then
            regRkey = Registry.CurrentUser.CreateSubKey("Software\\Code Monkey\\" & appName, RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If

        If AuthReq = True Then
            txtSmartUsername.Text = ""
            txtSmartPassword.Text = ""
        Else
            txtSmartUsername.Text = "Not Applicable"
            txtSmartPassword.Text = "Not Applicable"
        End If



        regRkey = Registry.CurrentUser.OpenSubKey("Software\\Code Monkey\\" & accnt, True)
        If regRkey Is Nothing Then
            'txtSmartUsername.Text = "Not Applicable"
            'txtSmartPassword.Text = "Not Applicable"
            Exit Sub
        End If

        If AuthReq = True Then
            txtSmartUsername.Text = My.Settings.Username
            txtSmartPassword.Text = DecryptString128Bit(My.Settings.Password, "Tomoe")
        Else
            txtSmartUsername.Text = "Not Applicable"
            txtSmartPassword.Text = "Not Applicable"
        End If

        txtSmartUsername.Enabled = AuthReq
        txtSmartPassword.Enabled = AuthReq

        cmbType.SelectedIndex = My.Settings.Proto
        cmbPort.SelectedIndex = My.Settings.Port
        cmbLports.SelectedIndex = My.Settings.LPort

        regRkey.Close()
    End Sub

    Private Sub SaveUser(ByVal accnt As String)
        My.Settings.Username = txtSmartUsername.Text
        My.Settings.Password = EncryptString128Bit(txtSmartPassword.Text, "Tomoe")

        My.Settings.Server = cmbServer.SelectedIndex
        My.Settings.Port = cmbPort.SelectedIndex
        My.Settings.Proto = cmbType.SelectedIndex
        My.Settings.LPort = cmbLports.SelectedIndex
    End Sub

    Private Sub GetUser(ByVal accnt As String)
        cmbType.SelectedIndex = My.Settings.Proto
        cmbServer.SelectedIndex = My.Settings.Server
        cmbPort.SelectedIndex = My.Settings.Port
        cmbLports.SelectedIndex = My.Settings.LPort
    End Sub

    Private Sub LoadSettings()
        Try
            Dim sServ As New FileStream(Application.StartupPath & "\" & confName, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim sServF As New System.IO.StreamReader(sServ)
            tempDec = DecryptString128Bit(sServF.ReadToEnd, sKey)
            'tempDec = sServF.ReadToEnd
            'MsgBox(tempDec)
            'MsgBox(tempDec)
            Dim xmlString As String = tempDec
            Dim doc As New Xml.XmlDocument
            doc.LoadXml(xmlString)

            Dim reader As New Xml.XmlNodeReader(doc)
            Dim i As Integer

            While reader.Read()
                If reader.NodeType = Xml.XmlNodeType.Element Then
                    Select Case reader.Name
                        Case "version"
                            confServVersion = reader.ReadString
                            lblVersion.Text = confServVersion
                        Case "updatepath"
                            confUpdatePath = reader.ReadString
                        Case "servers"
                            servList = reader.ReadString.Split("|")
                            cmbAltServer.Items.Clear()

                            For i = 0 To servList.Length - 1
                                cmbAltServer.Items.Add(servList(i).Trim)
                            Next
                            cmbAltServer.SelectedIndex = 0
                        Case "domain"
                            confDomain = reader.ReadString
                        Case "torrent"
                            torrents = reader.ReadString.ToLower.Split("|")
                            If torrents.Length > 0 Then tmrBlocker.Enabled = True
                        Case "torrentex"
                            torrentsex = reader.ReadString.ToLower.Split("|")
                        Case "autoscan"
                            autoScan = CInt(reader.ReadString.ToLower)
                    End Select

                End If
            End While
            reader.Close()
            tempDec = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadConfig(ByVal NetVPN As String)
        Try
            Dim sServ As New FileStream(Application.StartupPath & "\" & confName, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite)
            Dim sServF As New System.IO.StreamReader(sServ)
            tempDec = DecryptString128Bit(sServF.ReadToEnd, sKey)
            'tempDec = sServF.ReadToEnd
            'MsgBox(tempDec)
            Dim xmlString As String = tempDec
            Dim doc As New Xml.XmlDocument
            doc.LoadXml(xmlString)

            Dim m_node_s As XmlNode
            Dim m_node As XmlNode


            m_node_s = doc.SelectSingleNode("/settings/" & NetVPN.ToLower & "/smart")
            m_node = doc.SelectSingleNode("/settings/" & NetVPN.ToLower)

            vpnStat = NetVPN

            siteLink = m_node("reg").InnerText.Trim
            AuthReq = CBool(m_node("auth").InnerText.Trim)

            If AuthReq Then
                txtSmartPassword.Enabled = True
                txtSmartUsername.Enabled = True
                chkRemember.Enabled = True
            Else
                txtSmartPassword.Enabled = False
                txtSmartUsername.Enabled = False
                chkRemember.Enabled = False
            End If

            isAlt = CBool(m_node("alt").InnerText.Trim)

            smartTCPports = m_node_s("tcpports").InnerText.Trim.Split("|")
            smartUDPports = m_node_s("udpports").InnerText.Trim.Split("|")
            smartLports = m_node_s("lports").InnerText.Trim.Split("|")

            smartServers = CInt(m_node_s("server").InnerText.Trim)
            smartIP = m_node_s("ip").InnerText.Trim.Split("|")
            'smartIP = GetRandomIP().Trim.Split("|")
            smartTCPConfig = m_node_s("configtcp").InnerText.Trim.Trim
            smartUDPConfig = m_node_s("configudp").InnerText.Trim
            smartTCPPort = m_node_s("tcpport").InnerText.Trim
            smartUDPPort = m_node_s("udpport").InnerText.Trim
            smartServerAlias = m_node_s("alias").InnerText.Trim.Split("|")

            'ReDim smartServerAlias(0 To 29)
            'For x As Integer = 1 To 30
            'smartServerAlias(x - 1) = "HSS Server " & x
            'Next

            smartDefTCPLport = m_node_s("tcplport").InnerText.Trim
            smartDefUDPLport = m_node_s("udplport").InnerText.Trim
            smartCert = m_node_s("cert").InnerText.Trim

            tempDec = ""
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox("Can't find config. Application will exit.")
            Application.Exit()
        End Try

        'cmbWenzServer.SelectedIndex = 0
        cmbType.SelectedIndex = 1
        cmbType_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub SetBalloon(ByVal sStatus As String, ByVal msg As String)
        Select Case sStatus
            Case "connected"
                'niIcon.Text = appName & " - " & msg
                niIcon.Text = appName & " - " & msg '& vbCrLf & "Connected to: " & cmbServer.SelectedItem.ToString & vbCrLf & "Connected since: " & String.Format(Now, "mm dd, hh:nn") & vbCrLf & "Assigned IP: " & assignedIP
                'niIcon.Icon = My.Resources.connected
            Case "disconnected"
                niIcon.Text = appName & " - " & msg
                'niIcon.Icon = My.Resources.disconnected
            Case "connecting"
                niIcon.Text = appName & " - " & msg
                'niIcon.Icon = My.Resources.connecting
            Case "reconnecting"
                niIcon.Text = appName & " - " & msg
                'niIcon.Icon = My.Resources.reconnecting
            Case Else
        End Select
        'niIcon.Icon = My.Resources.Untitled_1
        If Not niIcon.BalloonTipText = (appName & " - " & msg) Then
            niIcon.BalloonTipText = appName & " - " & msg
            niIcon.ShowBalloonTip(500)
        End If
    End Sub

    Private Sub checkTapHSS()
        Dim regVersion As RegistryKey
        Dim tapHSS As Boolean = False
        Dim tmp As MsgBoxResult
        Dim regTmp As RegistryKey
        Dim regTmpVal As String

        Try
            regVersion = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\Root\\NET", False)
            If regVersion Is Nothing Then
                GoTo NoTap
            Else
                For Each x As String In regVersion.GetSubKeyNames
                    regTmp = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\Root\\NET\\" & x.Trim, False)
                    regTmpVal = regTmp.GetValue("Service")
                    If tapHSS = False Then
                        If regTmpVal = "taphss6" Then
                            tapHSS = True
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

NoTap:
        If tapHSS = False Then
            tmp = MsgBox("This program requires TAP HSS driver. Do you want to install the driver?", MsgBoxStyle.YesNo, appName)

            If tmp = MsgBoxResult.Yes Then
                InstallTap("HSS")
                cmdInstall.Enabled = False
                cmdUninstall.Enabled = True
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub checkTap()
        Dim regVersion As RegistryKey
        Dim tap0901 As Boolean = False
        Dim tmp As MsgBoxResult
        Dim regTmp As RegistryKey
        Dim regTmpVal As String

        Try
            regVersion = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\Root\\NET", False)
            If regVersion Is Nothing Then
                GoTo NoTap
            Else
                For Each x As String In regVersion.GetSubKeyNames
                    regTmp = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\Root\\NET\\" & x.Trim, False)
                    regTmpVal = regTmp.GetValue("Service")
                    If tap0901 = False Then
                        If regTmpVal = "tap0901" Then
                            tap0901 = True
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

NoTap:
        If tap0901 = False Then
            tmp = MsgBox("This program requires TAP 0901 driver. Do you want to install the driver?", MsgBoxStyle.YesNo, appName)

            If tmp = MsgBoxResult.Yes Then
                InstallTapAll()
                cmdInstall.Enabled = False
                cmdUninstall.Enabled = True
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub InstallTap(ByVal type As String)
        If type = "HSS" Then
            If osType = 8 Then
                Shell(currDir & tap64path & " install " & Chr(34) & currDir & "\data\driverhss\win64\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            Else
                Shell(currDir & tap32path & " install " & Chr(34) & currDir & "\data\driverhss\win32\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            End If
        Else
            If osType = 8 Then
                Shell(currDir & tap64path & " install " & Chr(34) & currDir & "\data\driver0901\win64\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
            Else
                Shell(currDir & tap32path & " install " & Chr(34) & currDir & "\data\driver0901\win32\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
            End If
        End If
    End Sub

    Private Sub InstallTapAll()
        lblTAP.Text = "Installing..."
        If osType = 8 Then
            Shell(currDir & tap64path & " install " & Chr(34) & currDir & "\data\driverhss\win64\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            'Shell(currDir & tap64path & " install " & Chr(34) & currDir & "\data\driver0901\win64\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
        Else
            Shell(currDir & tap32path & " install " & Chr(34) & currDir & "\data\driverhss\win32\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            'Shell(currDir & tap32path & " install " & Chr(34) & currDir & "\data\driver0901\win32\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
        End If
        cmdInstall.Enabled = False
        cmdUninstall.Enabled = True
        Application.DoEvents()
        lblTAP.Text = "Driver Installed"
    End Sub

    Private Sub UninstallTapAll()
        lblTAP.Text = "Uninstalling..."
        If osType = 8 Then
            Shell(currDir & tap64path & " remove " & Chr(34) & currDir & "\data\driverhss\win64\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            'Shell(currDir & tap64path & " remove " & Chr(34) & currDir & "\data0901\driver\win64\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
        Else
            Shell(currDir & tap32path & " remove " & Chr(34) & currDir & "\data\driverhss\win32\taphss6.inf" & Chr(34) & " taphss6", AppWinStyle.Hide, True)
            'Shell(currDir & tap32path & " remove " & Chr(34) & currDir & "\data0901\driver\win32\taphss6.inf" & Chr(34) & " tap0901", AppWinStyle.Hide, True)
        End If
        cmdInstall.Enabled = True
        cmdUninstall.Enabled = False
        Application.DoEvents()
        lblTAP.Text = "No Driver Installed"
    End Sub

    Private Sub CenterForm()
        Dim mainScreen As Screen = Screen.FromPoint(Me.Location)
        Dim X As Integer = ((mainScreen.WorkingArea.Width - Me.Width) / 2 + mainScreen.WorkingArea.Left)
        Dim Y As Integer = (mainScreen.WorkingArea.Height - Me.Height) / 2 + mainScreen.WorkingArea.Top

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)

    End Sub

    Private Sub Reset()
        cmdConnect.Text = "Connect"
        lblStatus.Text = "Disconnected"
        'SetBalloon("disconnected", "Disconnected")
        EnableAll()
        tmrStat.Enabled = False
        tmrPinger.Enabled = False
        tmrBlocker.Stop()
        isConnected = False
        isInit = False
        isAuth = False
        isUEnter = False
        isPEnter = False
        KillProcess()
        myScanner = Nothing
        myScanner1 = Nothing
        DeleteFiles()
        'tmrNetStat.Stop()
    End Sub

    Public Function isWindowsAdministrator() As Boolean
        My.User.InitializeWithWindowsUser()
        If My.User.IsAuthenticated Then
            If My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator) Then
                Return True
            End If
        End If
        Return False
    End Function
#End Region

    Private Sub pnlHandle2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlHandle2.Paint

    End Sub

    Private Sub tmrTrial_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTrial.Tick
        KillProcess()
        Application.Exit()
    End Sub

    Private Sub chkWinStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWinStart.CheckedChanged
        Dim regRkey As RegistryKey
        regRkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
        If regRkey Is Nothing Then
            regRkey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If

        My.Settings.WindowsStart = chkWinStart.CheckState

        If chkWinStart.CheckState = CheckState.Checked Then
            regRkey.SetValue(appName, Application.ExecutablePath, RegistryValueKind.String)
        Else
            regRkey.DeleteValue(appName)
        End If
        regRkey.Close()
    End Sub

    Private Sub chkAppStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAppStart.CheckedChanged
        My.Settings.AutoStart = chkAppStart.CheckState
        isAutoStart = chkAppStart.CheckState
    End Sub

    Private Sub chkTray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTray.CheckedChanged
        My.Settings.Minimize = chkTray.CheckState
        isMinTray = chkTray.CheckState
    End Sub

    Private Sub chkNobind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNobind.CheckedChanged

        My.Settings.NoBind = chkNobind.CheckState
        isBind = chkNobind.CheckState

        chkLocal.Enabled = chkNobind.CheckState
        txtLocalPort.Enabled = chkNobind.CheckState
        cmbLports.Enabled = chkNobind.CheckState
    End Sub

    Private Sub txtPingInt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPingInt.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("1234567890.", Chr(KeyAscii)) = 0 And KeyAscii <> 8 Then KeyAscii = 0
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLocalPort_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalPort.GotFocus
        lasttemp = txtLocalPort.Text
    End Sub

    Private Sub txtLocalPort_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalPort.LostFocus
        If txtLocalPort.Text <= "" Or CInt(txtLocalPort.Text) > 65500 Then
            txtLocalPort.Text = lasttemp
        End If

        My.Settings.LocalPort = txtLocalPort.Text
    End Sub

    Private Sub txtRemotePort_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRemotePort.GotFocus
        lasttemp = txtRemotePort.Text
    End Sub

    Private Sub txtRemotePort_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRemotePort.LostFocus
        If txtRemotePort.Text <= "" Or CInt(txtLocalPort.Text) > 65500 Then
            txtRemotePort.Text = lasttemp
        End If
        My.Settings.RemotePort = txtRemotePort.Text
    End Sub

    Private Sub lblRemember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRemember.Click
        If chkRemember.Checked Then
            chkRemember.Checked = False
        Else
            chkRemember.Checked = True
        End If
        chkRemember_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub chkRemote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRemote.CheckedChanged
        My.Settings.ManualRemote = chkRemote.CheckState
        txtRemotePort.Enabled = chkRemote.CheckState
        cmbPort.Enabled = Not chkRemote.CheckState
    End Sub

    Private Sub chkLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocal.CheckedChanged
        My.Settings.ManualLocal = chkLocal.CheckState
        txtLocalPort.Enabled = chkLocal.CheckState
        cmbLports.Enabled = Not chkLocal.CheckState
    End Sub

    Private Sub myScanner_PortClosed(ByVal Host As String, ByVal Port As Integer) Handles myScanner.PortClosed
        If Not cmdConnect.Text = "Checking" Then Exit Sub
        'MsgBox(Port & " closed")
        If currentproto = 1 Then
            If portctr >= smartUDPports.Length Then
                Me.Invoke(Sub()
                              Reset()
                          End Sub)
                SetStatus("No open port found")
                Exit Sub
            Else
                myScanner = New clsScanner(smartIP(serverport), smartUDPports(portctr), smartUDPports(portctr))
                SetStatus("Checking port " & smartUDPports(portctr))
                myScanner.Start()
                portctr = portctr + 1
            End If
        Else
            If portctr >= smartTCPports.Length Then

                Me.Invoke(Sub()
                              Reset()
                          End Sub)
                SetStatus("No open port found")
                Exit Sub
            Else
                myScanner = New clsScanner(smartIP(serverport), smartTCPports(portctr), smartTCPports(portctr))
                SetStatus("Checking port " & smartTCPports(portctr))
                myScanner.Start()
                portctr = portctr + 1
            End If
        End If
    End Sub

    Private Sub myScanner_PortOpen(ByVal Host As String, ByVal Port As Integer) Handles myScanner.PortOpen
        If Not cmdConnect.Text = "Checking" Then Exit Sub
        Me.Invoke(Sub()
                      myScanner = Nothing
                      cmbPort.SelectedIndex = portctr
                      If cmbLports.SelectedIndex > 0 Then
                          cmdConnect.Text = "Connect"
                          cmdConnect_Click(Nothing, Nothing)
                      End If
                  End Sub)
    End Sub

    Private Sub SetStatus(ByVal stat As String)
        Me.Invoke(Sub()
                      lblStatus.Text = stat
                  End Sub)
    End Sub

    Private Sub chkLocal_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLocal.MouseHover
        ttTip.SetToolTip(chkLocal, "Override local port")
    End Sub

    Private Sub chkRemote_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemote.MouseHover
        ttTip.SetToolTip(chkRemote, "Override remote port")
    End Sub

    Private Sub bwUpdate_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        bwUpdate.Dispose()
    End Sub


    Private Sub myScanner1_PortClosed(ByVal Host As String, ByVal Port As Integer) Handles myScanner1.PortClosed
        If lportctr >= smartLports.Length Then
            Me.Invoke(Sub()
                          Reset()
                      End Sub)
            SetStatus("No open port found")
            Exit Sub
        Else
            myScanner1 = New clsScanner(smartIP(serverport), smartLports(lportctr), smartLports(lportctr))
            SetStatus("Checking port " & smartLports(lportctr))
            myScanner1.Start()
            lportctr = lportctr + 1
        End If
    End Sub

    Private Sub myScanner1_PortOpen(ByVal Host As String, ByVal Port As Integer) Handles myScanner1.PortOpen
        If Not cmdConnect.Text = "Checking" Then Exit Sub
        Me.Invoke(Sub()
                      myScanner1 = Nothing
                      cmbLports.SelectedIndex = lportctr
                      cmdConnect.Text = "Connect"
                      cmdConnect_Click(Nothing, Nothing)
                  End Sub)
    End Sub

    Private Sub tsmStats_Click(sender As Object, e As EventArgs) Handles tsmStats.Click
        If frmStats.Visible Then
            frmStats.Hide()
            tsmStats.Text = "Show Statistics"
        Else
            frmStats.Show()
            tsmStats.Text = "Hide Statistics"
        End If
    End Sub

    Private Sub lblOptions_Click(sender As Object, e As EventArgs) Handles lblOptions.Click
        If Me.Width = fWidth Then
            Me.Width = fHeight
        Else
            Me.Width = fWidth
        End If
        Me.CenterForm()
    End Sub

    Private Sub CloseItem(ByVal ItemName As String)
        Try
            Dim pro As Process
            For Each pro In System.Diagnostics.Process.GetProcesses
                Dim strex As String
                Dim ex As Boolean = False
                For Each strex In torrentsex
                    If pro.ProcessName.ToLower = strex.ToLower Then
                        ex = True
                    End If
                Next
                If ex = False Then
                    If InStr(pro.MainWindowTitle.ToLower, ItemName.ToLower, CompareMethod.Text) Then
                        pro.Kill()
                        pro.CloseMainWindow()
                        'Form2.Show()
                    End If
                End If
                ex = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tmrBlocker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlocker.Tick
        Dim CurrProc As Integer = System.Diagnostics.Process.GetCurrentProcess.Threads.Count
        If Not LastProc = CurrProc Then
            Dim str As String
            For Each str In torrents
                CloseItem(str)
            Next
        End If
        LastProc = System.Diagnostics.Process.GetCurrentProcess.Threads.Count
    End Sub

    Private Sub ExtractCert()
        'Dim sFile As New stre(tmpoLogPath, FileMode.Create, FileAccess.Write, System.IO.FileShare.ReadWrite)
        Dim sFileW As New System.IO.StreamWriter(hidFolder & "\cm.cert")
        sFileW.Write(smartCert)
        sFileW.Close()
        IO.File.SetCreationTime(hidFolder & "\cm.cert", New Date(2012, 12, 12))
    End Sub

    Private Sub picEasterEgg_DoubleClick(sender As Object, e As EventArgs) Handles picEasterEgg.DoubleClick
        Shell("notepad.exe " & tmpoLogPath, AppWinStyle.NormalFocus)
    End Sub

    Private Function IsAdmin() As Boolean
        Return My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator)
    End Function

    Private Sub cmbLports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLports.SelectedIndexChanged
        My.Settings.LPort = cmbLports.SelectedIndex
    End Sub

    Private Sub lnkWebsite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWebsite.LinkClicked
        System.Diagnostics.Process.Start("http://codemonkeydev.blogspot.com/")
    End Sub

    Private Sub lnkFB_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFB.LinkClicked
        System.Diagnostics.Process.Start("http://fb.com/CodeMonkeyDev")
    End Sub

    Private Sub lnkSymb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSymb.LinkClicked
        System.Diagnostics.Process.Start("http://www.symbianize.com/member.php?u=60642")
    End Sub
End Class