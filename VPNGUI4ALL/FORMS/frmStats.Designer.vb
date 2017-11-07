<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStats
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStats))
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblStatusD = New System.Windows.Forms.Label()
        Me.lblUpload = New System.Windows.Forms.Label()
        Me.lblDownload = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblStatusU = New System.Windows.Forms.Label()
        Me.tmrNetStat = New System.Windows.Forms.Timer(Me.components)
        Me.chartD = New CodeMonkey.SystemMonitor.DataChart()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Teal
        Me.Label19.Location = New System.Drawing.Point(179, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 12)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "SENT:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.Label18.ForeColor = System.Drawing.Color.Teal
        Me.Label18.Location = New System.Drawing.Point(10, 171)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 12)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "RECV:"
        '
        'lblStatusD
        '
        Me.lblStatusD.AutoSize = True
        Me.lblStatusD.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblStatusD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusD.Location = New System.Drawing.Point(47, 170)
        Me.lblStatusD.Name = "lblStatusD"
        Me.lblStatusD.Size = New System.Drawing.Size(24, 12)
        Me.lblStatusD.TabIndex = 56
        Me.lblStatusD.Text = "0 KB"
        Me.lblStatusD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUpload
        '
        Me.lblUpload.AutoSize = True
        Me.lblUpload.BackColor = System.Drawing.Color.Transparent
        Me.lblUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUpload.Location = New System.Drawing.Point(216, 158)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.Size = New System.Drawing.Size(32, 12)
        Me.lblUpload.TabIndex = 52
        Me.lblUpload.Text = "0 KB/s"
        Me.lblUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDownload
        '
        Me.lblDownload.AutoSize = True
        Me.lblDownload.BackColor = System.Drawing.Color.Transparent
        Me.lblDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDownload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDownload.Location = New System.Drawing.Point(36, 158)
        Me.lblDownload.Name = "lblDownload"
        Me.lblDownload.Size = New System.Drawing.Size(32, 12)
        Me.lblDownload.TabIndex = 53
        Me.lblDownload.Text = "0 KB/s"
        Me.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(191, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 12)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "UL:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Lime
        Me.Label13.Location = New System.Drawing.Point(10, 158)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 12)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "DL:"
        '
        'lblStatusU
        '
        Me.lblStatusU.AutoSize = True
        Me.lblStatusU.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusU.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.lblStatusU.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblStatusU.Location = New System.Drawing.Point(216, 171)
        Me.lblStatusU.Name = "lblStatusU"
        Me.lblStatusU.Size = New System.Drawing.Size(24, 12)
        Me.lblStatusU.TabIndex = 57
        Me.lblStatusU.Text = "0 KB"
        Me.lblStatusU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrNetStat
        '
        Me.tmrNetStat.Enabled = True
        Me.tmrNetStat.Interval = 1000
        '
        'chartD
        '
        Me.chartD.BackColor = System.Drawing.Color.Black
        Me.chartD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chartD.ChartType = CodeMonkey.SystemMonitor.ChartType.Stick
        Me.chartD.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chartD.GridPixels = 19
        Me.chartD.InitialHeight = 0
        Me.chartD.LineColor = System.Drawing.Color.Lime
        Me.chartD.LineColor1 = System.Drawing.Color.Red
        Me.chartD.Location = New System.Drawing.Point(10, 60)
        Me.chartD.Name = "chartD"
        Me.chartD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chartD.Size = New System.Drawing.Size(250, 95)
        Me.chartD.TabIndex = 60
        '
        'frmStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.CodeMonkey.My.Resources.Resources.statback
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(270, 190)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblStatusD)
        Me.Controls.Add(Me.lblUpload)
        Me.Controls.Add(Me.chartD)
        Me.Controls.Add(Me.lblDownload)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblStatusU)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStats"
        Me.Opacity = 0.7R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblStatusD As System.Windows.Forms.Label
    Friend WithEvents lblUpload As System.Windows.Forms.Label
    Friend WithEvents chartD As CodeMonkey.SystemMonitor.DataChart
    Friend WithEvents lblDownload As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblStatusU As System.Windows.Forms.Label
    Friend WithEvents tmrNetStat As System.Windows.Forms.Timer
End Class
