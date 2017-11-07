Public Class frmStats

    Private Sub tmrNetStat_Tick(sender As Object, e As EventArgs) Handles tmrNetStat.Tick
        If Me.Visible = False Then Exit Sub

        If sLAN <= "" Then Exit Sub

        If isTapFound = False Then
            'ListBox1.Items.Clear()
            For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
                'ListBox1.Items.Add(nic.Name)
                If nic.Name.Trim.ToLower = sLAN.Trim.ToLower Then
                    nicInfo = nic
                    'MsgBox(nic.Name)
                    isTapFound = True

                    'Dim address As IPAddress

                    'For Each address In nic.GetIPProperties.
                    'assignedIP = address.ToString
                    'Next
                    Exit For
                Else
                    isTapFound = False
                End If
            Next
        End If

        If isTapFound Then
            'If Me.Width >= 530 Then
            Try
                Dim interfaceStatistic As Net.NetworkInformation.IPv4InterfaceStatistics = nicInfo.GetIPv4Statistics

                bytesSentSpeed = CLng(interfaceStatistic.BytesSent - lngBytesSend) / 1024
                bytesReceivedSpeed = CLng(interfaceStatistic.BytesReceived - lngBtyesReceived) / 1024
                If bytesReceivedSpeed > 9000 Or bytesSentSpeed > 9000 Then Exit Sub
                lngBytesSend = interfaceStatistic.BytesSent
                lngBtyesReceived = interfaceStatistic.BytesReceived

                'If lblTab3.ForeColor = Color.LimeGreen Then

                lblStatusD.Text = ByteConv(CDbl(interfaceStatistic.BytesReceived))
                lblStatusU.Text = ByteConv(CDbl(interfaceStatistic.BytesSent))
                lblUpload.Text = bytesSentSpeed & " KB/s"
                lblDownload.Text = bytesReceivedSpeed & " KB/s"
                chartD.UpdateChart(bytesReceivedSpeed, bytesSentSpeed)

                'End If
            Catch

            End Try
            'End If
        End If
    End Sub

    Private Sub frmStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.BringToFront()
        Me.TopMost = True
        'Me.Location = New Point(0, 0)
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property 'CreateParams
End Class