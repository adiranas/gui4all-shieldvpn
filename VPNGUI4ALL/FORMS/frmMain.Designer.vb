<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblRemember = New System.Windows.Forms.Label()
        Me.txtSmartUsername = New System.Windows.Forms.TextBox()
        Me.txtSmartPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkRemember = New System.Windows.Forms.CheckBox()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.cmdRandom = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbLports = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkLocal = New System.Windows.Forms.CheckBox()
        Me.chkRemote = New System.Windows.Forms.CheckBox()
        Me.chkNobind = New System.Windows.Forms.CheckBox()
        Me.txtRemotePort = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtPingInt = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkTray = New System.Windows.Forms.CheckBox()
        Me.chkAppStart = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkOption = New System.Windows.Forms.CheckBox()
        Me.pnlHandle2 = New System.Windows.Forms.Panel()
        Me.cmdInstall = New System.Windows.Forms.Button()
        Me.cmdUninstall = New System.Windows.Forms.Button()
        Me.lblTAP = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkSocks = New System.Windows.Forms.CheckBox()
        Me.chkUseProxy = New System.Windows.Forms.CheckBox()
        Me.txtProxyPort = New System.Windows.Forms.TextBox()
        Me.txtProxyIP = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.chkWinStart = New System.Windows.Forms.CheckBox()
        Me.txtLocalPort = New System.Windows.Forms.TextBox()
        Me.progress1 = New System.Windows.Forms.ProgressBar()
        Me.niIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsConMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmStats = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.subExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrStat = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPinger = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTrial = New System.Windows.Forms.Timer(Me.components)
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.ttTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrBlocker = New System.Windows.Forms.Timer(Me.components)
        Me.picEasterEgg = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblOptions = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.cmbAltServer = New System.Windows.Forms.ComboBox()
        Me.bwUpdate = New System.ComponentModel.BackgroundWorker()
        Me.lnkWebsite = New System.Windows.Forms.LinkLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lnkFB = New System.Windows.Forms.LinkLabel()
        Me.lnkSymb = New System.Windows.Forms.LinkLabel()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlHandle2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.cmsConMenu.SuspendLayout()
        CType(Me.picEasterEgg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblRemember)
        Me.Panel3.Controls.Add(Me.txtSmartUsername)
        Me.Panel3.Controls.Add(Me.txtSmartPassword)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.chkRemember)
        Me.Panel3.Location = New System.Drawing.Point(13, 115)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 85)
        Me.Panel3.TabIndex = 59
        '
        'lblRemember
        '
        Me.lblRemember.AutoSize = True
        Me.lblRemember.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemember.ForeColor = System.Drawing.Color.White
        Me.lblRemember.Location = New System.Drawing.Point(84, 63)
        Me.lblRemember.Name = "lblRemember"
        Me.lblRemember.Size = New System.Drawing.Size(76, 13)
        Me.lblRemember.TabIndex = 25
        Me.lblRemember.Text = "Remember Me"
        '
        'txtSmartUsername
        '
        Me.txtSmartUsername.BackColor = System.Drawing.Color.Gray
        Me.txtSmartUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSmartUsername.ForeColor = System.Drawing.Color.White
        Me.txtSmartUsername.Location = New System.Drawing.Point(71, 8)
        Me.txtSmartUsername.Name = "txtSmartUsername"
        Me.txtSmartUsername.Size = New System.Drawing.Size(168, 20)
        Me.txtSmartUsername.TabIndex = 19
        Me.txtSmartUsername.Text = "NOT APPLICABLE"
        '
        'txtSmartPassword
        '
        Me.txtSmartPassword.BackColor = System.Drawing.Color.Gray
        Me.txtSmartPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSmartPassword.ForeColor = System.Drawing.Color.White
        Me.txtSmartPassword.Location = New System.Drawing.Point(71, 36)
        Me.txtSmartPassword.Name = "txtSmartPassword"
        Me.txtSmartPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSmartPassword.Size = New System.Drawing.Size(168, 20)
        Me.txtSmartPassword.TabIndex = 22
        Me.txtSmartPassword.Text = "NOT APPLICABLE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(2, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(2, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Password"
        '
        'chkRemember
        '
        Me.chkRemember.AutoSize = True
        Me.chkRemember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRemember.ForeColor = System.Drawing.Color.Black
        Me.chkRemember.Location = New System.Drawing.Point(71, 64)
        Me.chkRemember.Name = "chkRemember"
        Me.chkRemember.Size = New System.Drawing.Size(12, 11)
        Me.chkRemember.TabIndex = 23
        Me.chkRemember.UseVisualStyleBackColor = True
        '
        'cmbServer
        '
        Me.cmbServer.BackColor = System.Drawing.Color.Gray
        Me.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.Items.AddRange(New Object() {"- SELECT SERVER -"})
        Me.cmbServer.Location = New System.Drawing.Point(6, 7)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(234, 21)
        Me.cmbServer.TabIndex = 61
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.Gray
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"TCP", "UDP"})
        Me.cmbType.Location = New System.Drawing.Point(56, 41)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(73, 21)
        Me.cmbType.TabIndex = 62
        '
        'cmbPort
        '
        Me.cmbPort.BackColor = System.Drawing.Color.Gray
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(167, 41)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(73, 21)
        Me.cmbPort.TabIndex = 63
        '
        'cmdConnect
        '
        Me.cmdConnect.BackColor = System.Drawing.Color.Gray
        Me.cmdConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConnect.Location = New System.Drawing.Point(13, 286)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(169, 29)
        Me.cmdConnect.TabIndex = 64
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = False
        '
        'cmdRandom
        '
        Me.cmdRandom.BackColor = System.Drawing.Color.Gray
        Me.cmdRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRandom.Location = New System.Drawing.Point(188, 286)
        Me.cmdRandom.Name = "cmdRandom"
        Me.cmdRandom.Size = New System.Drawing.Size(75, 29)
        Me.cmdRandom.TabIndex = 65
        Me.cmdRandom.Text = "Random"
        Me.cmdRandom.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbServer)
        Me.Panel1.Controls.Add(Me.cmbPort)
        Me.Panel1.Controls.Add(Me.cmbType)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Location = New System.Drawing.Point(13, 208)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 71)
        Me.Panel1.TabIndex = 66
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(134, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Port"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(3, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Protocol"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbLports)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.chkLocal)
        Me.Panel2.Controls.Add(Me.chkRemote)
        Me.Panel2.Controls.Add(Me.chkNobind)
        Me.Panel2.Controls.Add(Me.txtRemotePort)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.txtPingInt)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.chkTray)
        Me.Panel2.Controls.Add(Me.chkAppStart)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.chkOption)
        Me.Panel2.Location = New System.Drawing.Point(293, 203)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 148)
        Me.Panel2.TabIndex = 68
        '
        'cmbLports
        '
        Me.cmbLports.BackColor = System.Drawing.Color.Gray
        Me.cmbLports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLports.FormattingEnabled = True
        Me.cmbLports.Location = New System.Drawing.Point(80, 113)
        Me.cmbLports.Name = "cmbLports"
        Me.cmbLports.Size = New System.Drawing.Size(70, 21)
        Me.cmbLports.TabIndex = 64
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(26, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 15)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Bind"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(26, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(189, 15)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Minimize to Tray on Connect"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(26, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(214, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Autoconnect on Application Start"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(26, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Auto-flush"
        '
        'chkLocal
        '
        Me.chkLocal.AutoSize = True
        Me.chkLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLocal.Location = New System.Drawing.Point(50, 117)
        Me.chkLocal.Name = "chkLocal"
        Me.chkLocal.Size = New System.Drawing.Size(12, 11)
        Me.chkLocal.TabIndex = 54
        Me.chkLocal.UseVisualStyleBackColor = True
        '
        'chkRemote
        '
        Me.chkRemote.AutoSize = True
        Me.chkRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRemote.Location = New System.Drawing.Point(156, 117)
        Me.chkRemote.Name = "chkRemote"
        Me.chkRemote.Size = New System.Drawing.Size(12, 11)
        Me.chkRemote.TabIndex = 43
        Me.chkRemote.UseVisualStyleBackColor = True
        '
        'chkNobind
        '
        Me.chkNobind.AutoSize = True
        Me.chkNobind.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkNobind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNobind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNobind.ForeColor = System.Drawing.Color.Black
        Me.chkNobind.Location = New System.Drawing.Point(12, 67)
        Me.chkNobind.Name = "chkNobind"
        Me.chkNobind.Size = New System.Drawing.Size(12, 11)
        Me.chkNobind.TabIndex = 42
        Me.chkNobind.UseVisualStyleBackColor = True
        '
        'txtRemotePort
        '
        Me.txtRemotePort.BackColor = System.Drawing.Color.Gray
        Me.txtRemotePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemotePort.Enabled = False
        Me.txtRemotePort.ForeColor = System.Drawing.Color.White
        Me.txtRemotePort.Location = New System.Drawing.Point(188, 113)
        Me.txtRemotePort.MaxLength = 5
        Me.txtRemotePort.Name = "txtRemotePort"
        Me.txtRemotePort.Size = New System.Drawing.Size(47, 20)
        Me.txtRemotePort.TabIndex = 40
        Me.txtRemotePort.Text = "9200"
        Me.txtRemotePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label30.Location = New System.Drawing.Point(169, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 13)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "R:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label29.Location = New System.Drawing.Point(63, 116)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(18, 13)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "L:"
        '
        'txtPingInt
        '
        Me.txtPingInt.BackColor = System.Drawing.Color.Gray
        Me.txtPingInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPingInt.ForeColor = System.Drawing.Color.White
        Me.txtPingInt.Location = New System.Drawing.Point(140, 85)
        Me.txtPingInt.MaxLength = 2
        Me.txtPingInt.Name = "txtPingInt"
        Me.txtPingInt.Size = New System.Drawing.Size(25, 20)
        Me.txtPingInt.TabIndex = 31
        Me.txtPingInt.Text = "1"
        Me.txtPingInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label28.Location = New System.Drawing.Point(9, 89)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(129, 13)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "Ping Interval (in sec):"
        '
        'chkTray
        '
        Me.chkTray.AutoSize = True
        Me.chkTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTray.ForeColor = System.Drawing.Color.Black
        Me.chkTray.Location = New System.Drawing.Point(12, 47)
        Me.chkTray.Name = "chkTray"
        Me.chkTray.Size = New System.Drawing.Size(12, 11)
        Me.chkTray.TabIndex = 27
        Me.chkTray.UseVisualStyleBackColor = True
        '
        'chkAppStart
        '
        Me.chkAppStart.AutoSize = True
        Me.chkAppStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAppStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAppStart.ForeColor = System.Drawing.Color.Black
        Me.chkAppStart.Location = New System.Drawing.Point(12, 28)
        Me.chkAppStart.Name = "chkAppStart"
        Me.chkAppStart.Size = New System.Drawing.Size(12, 11)
        Me.chkAppStart.TabIndex = 26
        Me.chkAppStart.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label26.Location = New System.Drawing.Point(9, 116)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(40, 13)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "Ports:"
        '
        'chkOption
        '
        Me.chkOption.AutoSize = True
        Me.chkOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOption.ForeColor = System.Drawing.Color.Black
        Me.chkOption.Location = New System.Drawing.Point(12, 9)
        Me.chkOption.Name = "chkOption"
        Me.chkOption.Size = New System.Drawing.Size(12, 11)
        Me.chkOption.TabIndex = 6
        Me.chkOption.UseVisualStyleBackColor = True
        '
        'pnlHandle2
        '
        Me.pnlHandle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlHandle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHandle2.Controls.Add(Me.cmdInstall)
        Me.pnlHandle2.Controls.Add(Me.cmdUninstall)
        Me.pnlHandle2.Controls.Add(Me.lblTAP)
        Me.pnlHandle2.Location = New System.Drawing.Point(293, 27)
        Me.pnlHandle2.Name = "pnlHandle2"
        Me.pnlHandle2.Size = New System.Drawing.Size(250, 58)
        Me.pnlHandle2.TabIndex = 69
        '
        'cmdInstall
        '
        Me.cmdInstall.BackColor = System.Drawing.Color.Gray
        Me.cmdInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdInstall.Location = New System.Drawing.Point(8, 8)
        Me.cmdInstall.Name = "cmdInstall"
        Me.cmdInstall.Size = New System.Drawing.Size(113, 23)
        Me.cmdInstall.TabIndex = 72
        Me.cmdInstall.Text = "Install"
        Me.cmdInstall.UseVisualStyleBackColor = False
        '
        'cmdUninstall
        '
        Me.cmdUninstall.BackColor = System.Drawing.Color.Gray
        Me.cmdUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUninstall.Location = New System.Drawing.Point(127, 8)
        Me.cmdUninstall.Name = "cmdUninstall"
        Me.cmdUninstall.Size = New System.Drawing.Size(113, 23)
        Me.cmdUninstall.TabIndex = 71
        Me.cmdUninstall.Text = "Uninstall"
        Me.cmdUninstall.UseVisualStyleBackColor = False
        '
        'lblTAP
        '
        Me.lblTAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTAP.Location = New System.Drawing.Point(7, 32)
        Me.lblTAP.Name = "lblTAP"
        Me.lblTAP.Size = New System.Drawing.Size(230, 20)
        Me.lblTAP.TabIndex = 3
        Me.lblTAP.Text = "Driver Installed"
        Me.lblTAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.chkSocks)
        Me.Panel4.Controls.Add(Me.chkUseProxy)
        Me.Panel4.Controls.Add(Me.txtProxyPort)
        Me.Panel4.Controls.Add(Me.txtProxyIP)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Location = New System.Drawing.Point(293, 91)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(250, 106)
        Me.Panel4.TabIndex = 67
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(94, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 15)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Socks"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(26, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 15)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Use Proxy"
        '
        'chkSocks
        '
        Me.chkSocks.AutoSize = True
        Me.chkSocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSocks.ForeColor = System.Drawing.Color.Black
        Me.chkSocks.Location = New System.Drawing.Point(81, 84)
        Me.chkSocks.Name = "chkSocks"
        Me.chkSocks.Size = New System.Drawing.Size(12, 11)
        Me.chkSocks.TabIndex = 10
        Me.chkSocks.UseVisualStyleBackColor = True
        '
        'chkUseProxy
        '
        Me.chkUseProxy.AutoSize = True
        Me.chkUseProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseProxy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseProxy.ForeColor = System.Drawing.Color.Black
        Me.chkUseProxy.Location = New System.Drawing.Point(12, 8)
        Me.chkUseProxy.Name = "chkUseProxy"
        Me.chkUseProxy.Size = New System.Drawing.Size(12, 11)
        Me.chkUseProxy.TabIndex = 9
        Me.chkUseProxy.UseVisualStyleBackColor = True
        '
        'txtProxyPort
        '
        Me.txtProxyPort.BackColor = System.Drawing.Color.Gray
        Me.txtProxyPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProxyPort.Enabled = False
        Me.txtProxyPort.ForeColor = System.Drawing.Color.White
        Me.txtProxyPort.Location = New System.Drawing.Point(81, 55)
        Me.txtProxyPort.MaxLength = 4
        Me.txtProxyPort.Name = "txtProxyPort"
        Me.txtProxyPort.Size = New System.Drawing.Size(61, 20)
        Me.txtProxyPort.TabIndex = 8
        Me.txtProxyPort.Text = "80"
        '
        'txtProxyIP
        '
        Me.txtProxyIP.BackColor = System.Drawing.Color.Gray
        Me.txtProxyIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProxyIP.Enabled = False
        Me.txtProxyIP.ForeColor = System.Drawing.Color.White
        Me.txtProxyIP.Location = New System.Drawing.Point(81, 26)
        Me.txtProxyIP.MaxLength = 16
        Me.txtProxyIP.Name = "txtProxyIP"
        Me.txtProxyIP.Size = New System.Drawing.Size(151, 20)
        Me.txtProxyIP.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label21.Location = New System.Drawing.Point(10, 59)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Proxy Port"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label20.Location = New System.Drawing.Point(10, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Proxy IP"
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Cyan
        Me.lblVersion.Location = New System.Drawing.Point(387, 336)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 70
        Me.lblVersion.Text = "Protocol"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkWinStart
        '
        Me.chkWinStart.AutoSize = True
        Me.chkWinStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWinStart.Location = New System.Drawing.Point(778, 53)
        Me.chkWinStart.Name = "chkWinStart"
        Me.chkWinStart.Size = New System.Drawing.Size(51, 17)
        Me.chkWinStart.TabIndex = 72
        Me.chkWinStart.Text = "Bind"
        Me.chkWinStart.UseVisualStyleBackColor = True
        '
        'txtLocalPort
        '
        Me.txtLocalPort.BackColor = System.Drawing.Color.Gray
        Me.txtLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocalPort.Enabled = False
        Me.txtLocalPort.ForeColor = System.Drawing.Color.White
        Me.txtLocalPort.Location = New System.Drawing.Point(778, 24)
        Me.txtLocalPort.MaxLength = 5
        Me.txtLocalPort.Name = "txtLocalPort"
        Me.txtLocalPort.Size = New System.Drawing.Size(47, 20)
        Me.txtLocalPort.TabIndex = 71
        Me.txtLocalPort.Text = "53"
        Me.txtLocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLocalPort.Visible = False
        '
        'progress1
        '
        Me.progress1.Location = New System.Drawing.Point(778, 79)
        Me.progress1.Name = "progress1"
        Me.progress1.Size = New System.Drawing.Size(234, 12)
        Me.progress1.TabIndex = 73
        Me.progress1.Visible = False
        '
        'niIcon
        '
        Me.niIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niIcon.ContextMenuStrip = Me.cmsConMenu
        Me.niIcon.Icon = CType(resources.GetObject("niIcon.Icon"), System.Drawing.Icon)
        Me.niIcon.Text = "AsbagVPN - Disconnected"
        Me.niIcon.Visible = True
        '
        'cmsConMenu
        '
        Me.cmsConMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmStats, Me.ToolStripSeparator1, Me.subExit})
        Me.cmsConMenu.Name = "ContextMenuStrip1"
        Me.cmsConMenu.Size = New System.Drawing.Size(147, 54)
        '
        'tsmStats
        '
        Me.tsmStats.Name = "tsmStats"
        Me.tsmStats.Size = New System.Drawing.Size(146, 22)
        Me.tsmStats.Text = "Show Statistics"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'subExit
        '
        Me.subExit.Name = "subExit"
        Me.subExit.Size = New System.Drawing.Size(146, 22)
        Me.subExit.Text = "Exit"
        '
        'tmrStat
        '
        Me.tmrStat.Interval = 1000
        '
        'tmrPinger
        '
        Me.tmrPinger.Interval = 5000
        '
        'tmrTrial
        '
        Me.tmrTrial.Interval = 300000
        '
        'bw
        '
        Me.bw.WorkerSupportsCancellation = True
        '
        'tmrBlocker
        '
        Me.tmrBlocker.Interval = 5000
        '
        'picEasterEgg
        '
        Me.picEasterEgg.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.picEasterEgg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picEasterEgg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEasterEgg.Location = New System.Drawing.Point(13, 77)
        Me.picEasterEgg.Name = "picEasterEgg"
        Me.picEasterEgg.Size = New System.Drawing.Size(203, 31)
        Me.picEasterEgg.TabIndex = 75
        Me.picEasterEgg.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(13, 321)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(250, 29)
        Me.lblStatus.TabIndex = 76
        Me.lblStatus.Text = "(Status)"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOptions
        '
        Me.lblOptions.BackColor = System.Drawing.Color.Transparent
        Me.lblOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptions.ForeColor = System.Drawing.Color.White
        Me.lblOptions.Image = Global.CodeMonkey.My.Resources.Resources.gear_24
        Me.lblOptions.Location = New System.Drawing.Point(217, 77)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(33, 31)
        Me.lblOptions.TabIndex = 63
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.BackColor = System.Drawing.Color.Transparent
        Me.lblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.ForeColor = System.Drawing.Color.White
        Me.lblMin.Location = New System.Drawing.Point(249, 90)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(14, 13)
        Me.lblMin.TabIndex = 25
        Me.lblMin.Text = "_"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.BackColor = System.Drawing.Color.Transparent
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(250, 77)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(13, 13)
        Me.lblClose.TabIndex = 26
        Me.lblClose.Text = "x"
        '
        'cmbAltServer
        '
        Me.cmbAltServer.BackColor = System.Drawing.Color.Gray
        Me.cmbAltServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAltServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAltServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAltServer.FormattingEnabled = True
        Me.cmbAltServer.Items.AddRange(New Object() {"- SELECT SERVER -"})
        Me.cmbAltServer.Location = New System.Drawing.Point(760, 116)
        Me.cmbAltServer.Name = "cmbAltServer"
        Me.cmbAltServer.Size = New System.Drawing.Size(234, 21)
        Me.cmbAltServer.TabIndex = 78
        '
        'bwUpdate
        '
        Me.bwUpdate.WorkerSupportsCancellation = True
        '
        'lnkWebsite
        '
        Me.lnkWebsite.AutoSize = True
        Me.lnkWebsite.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lnkWebsite.LinkColor = System.Drawing.Color.White
        Me.lnkWebsite.Location = New System.Drawing.Point(15, 86)
        Me.lnkWebsite.Name = "lnkWebsite"
        Me.lnkWebsite.Size = New System.Drawing.Size(81, 13)
        Me.lnkWebsite.TabIndex = 79
        Me.lnkWebsite.TabStop = True
        Me.lnkWebsite.Text = "Official Website"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(760, 143)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(250, 88)
        Me.Panel5.TabIndex = 81
        '
        'lnkFB
        '
        Me.lnkFB.AutoSize = True
        Me.lnkFB.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lnkFB.LinkColor = System.Drawing.Color.White
        Me.lnkFB.Location = New System.Drawing.Point(96, 86)
        Me.lnkFB.Name = "lnkFB"
        Me.lnkFB.Size = New System.Drawing.Size(55, 13)
        Me.lnkFB.TabIndex = 82
        Me.lnkFB.TabStop = True
        Me.lnkFB.Text = "Facebook"
        '
        'lnkSymb
        '
        Me.lnkSymb.AutoSize = True
        Me.lnkSymb.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lnkSymb.LinkColor = System.Drawing.Color.White
        Me.lnkSymb.Location = New System.Drawing.Point(152, 86)
        Me.lnkSymb.Name = "lnkSymb"
        Me.lnkSymb.Size = New System.Drawing.Size(60, 13)
        Me.lnkSymb.TabIndex = 83
        Me.lnkSymb.TabStop = True
        Me.lnkSymb.Text = "Symbianize"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(558, 365)
        Me.ControlBox = False
        Me.Controls.Add(Me.lnkSymb)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lnkFB)
        Me.Controls.Add(Me.lnkWebsite)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.cmbAltServer)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.lblOptions)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.picEasterEgg)
        Me.Controls.Add(Me.chkWinStart)
        Me.Controls.Add(Me.txtLocalPort)
        Me.Controls.Add(Me.progress1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHandle2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdRandom)
        Me.Controls.Add(Me.cmdConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AsbagVPN"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlHandle2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.cmsConMenu.ResumeLayout(False)
        CType(Me.picEasterEgg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblRemember As System.Windows.Forms.Label
    Friend WithEvents txtSmartUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtSmartPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents cmbServer As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cmdRandom As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbLports As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkLocal As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemote As System.Windows.Forms.CheckBox
    Friend WithEvents chkNobind As System.Windows.Forms.CheckBox
    Friend WithEvents txtRemotePort As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPingInt As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chkTray As System.Windows.Forms.CheckBox
    Friend WithEvents chkAppStart As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkOption As System.Windows.Forms.CheckBox
    Friend WithEvents pnlHandle2 As System.Windows.Forms.Panel
    Friend WithEvents cmdInstall As System.Windows.Forms.Button
    Friend WithEvents cmdUninstall As System.Windows.Forms.Button
    Friend WithEvents lblTAP As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkSocks As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseProxy As System.Windows.Forms.CheckBox
    Friend WithEvents txtProxyPort As System.Windows.Forms.TextBox
    Friend WithEvents txtProxyIP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents chkWinStart As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocalPort As System.Windows.Forms.TextBox
    Friend WithEvents progress1 As System.Windows.Forms.ProgressBar
    Friend WithEvents niIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsConMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmStats As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents subExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrStat As System.Windows.Forms.Timer
    Friend WithEvents tmrPinger As System.Windows.Forms.Timer
    Friend WithEvents tmrTrial As System.Windows.Forms.Timer
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents ttTip As System.Windows.Forms.ToolTip
    Friend WithEvents tmrBlocker As System.Windows.Forms.Timer
    Friend WithEvents picEasterEgg As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblOptions As System.Windows.Forms.Label
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents cmbAltServer As System.Windows.Forms.ComboBox
    Friend WithEvents bwUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents lnkWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lnkFB As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSymb As System.Windows.Forms.LinkLabel
End Class
