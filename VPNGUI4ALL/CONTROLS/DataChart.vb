Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace SystemMonitor

    ''' <summary>
    ''' Summary description for DataChart.
    ''' </summary>
    Public Class DataChart
        Inherits System.Windows.Forms.UserControl

        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Private _arrayList As ArrayList
        Private _arrayList1 As ArrayList

        Private _colorLine As Color
        Private _colorLine1 As Color

        Private _colorGrid As Color

        Private _yMaxInit As Integer

        Private _gridPixel As Integer

        Private _chartType As ChartType
#Region "Constructor/Dispose"

        Public Sub New()
            MyBase.New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()
            BackColor = Color.Silver
            _colorLine = Color.DarkBlue
            _colorLine1 = Color.DarkRed
            _colorGrid = Color.Yellow
            _yMaxInit = 1000
            _gridPixel = 0
            _chartType = ChartType.Line
            _arrayList = New ArrayList
            _arrayList1 = New ArrayList
        End Sub

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (Not (components) Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
#End Region

        Public Sub UpdateChart(ByVal d As Double, ByVal e As Double)
            Dim rt As Rectangle = Me.ClientRectangle
            Dim dataCount As Integer = (rt.Width / 2)
            If (_arrayList.Count >= dataCount) Then
                _arrayList.RemoveAt(0)
            End If

            If (_arrayList1.Count >= dataCount) Then
                _arrayList1.RemoveAt(0)
            End If

            _arrayList.Add(d)
            _arrayList1.Add(e)
            Invalidate()
        End Sub
#Region "Component Designer generated code"

        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'DataChart
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.DoubleBuffered = True
            Me.Name = "DataChart"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Size = New System.Drawing.Size(230, 95)
            Me.ResumeLayout(False)

        End Sub
#End Region
#Region "Properties"

        <Description("Gets or sets the current Line Color in chart"), _
         Category("DataChart")> _
        Public Property LineColor() As Color
            Get
                Return _colorLine
            End Get
            Set(ByVal value As Color)
                _colorLine = value
            End Set
        End Property

        <Description("Gets or sets the current Line Color in chart"), _
 Category("DataChart")> _
        Public Property LineColor1() As Color
            Get
                Return _colorLine1
            End Get
            Set(ByVal value As Color)
                _colorLine1 = value
            End Set
        End Property

        <Description("Gets or sets the current Grid Color in chart"), _
         Category("DataChart")> _
        Public Property GridColor() As Color
            Get
                Return _colorGrid
            End Get
            Set(ByVal value As Color)
                _colorGrid = value
            End Set
        End Property

        <Description("Gets or sets the initial maximum Height for sticks in chart"), _
         Category("DataChart")> _
        Public Property InitialHeight() As Integer
            Get
                Return _yMaxInit
            End Get
            Set(ByVal value As Integer)
                _yMaxInit = value
            End Set
        End Property

        <Description("Gets or sets the current chart Type for stick or Line"), _
         Category("DataChart")> _
        Public Property ChartType() As ChartType
            Get
                Return _chartType
            End Get
            Set(ByVal value As ChartType)
                _chartType = value
            End Set
        End Property

        <Description("Enables grid drawing with spacing of the Pixel number"), _
         Category("DataChart")> _
        Public Property GridPixels() As Integer
            Get
                Return _gridPixel
            End Get
            Set(ByVal value As Integer)
                _gridPixel = value
            End Set
        End Property
#End Region
#Region "Drawing"

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim count As Integer = _arrayList.Count
            Dim count1 As Integer = _arrayList1.Count

            If (count = 0) And (count1 = 0) Then
                Return
            End If

            Dim yMax As Double = InitialHeight
            'Dim yMax1 As Double = InitialHeight
            Dim y As Double = 0
            'Dim y1 As Double = 0
            Dim i As Integer = 0
            'Dim i1 As Integer = 0

            Do While (i < count)
                y = Convert.ToDouble(_arrayList(i))
                If (y > yMax) Then
                    yMax = y
                End If
                i = (i + 1)
            Loop

            Dim rt As Rectangle = Me.ClientRectangle
            If yMax = 0 Then
                y = 1
            Else
                y = rt.Height / yMax
            End If

            Dim xStart As Integer = rt.Width
            Dim yStart As Integer = rt.Height
            Dim nY As Integer
            Dim nX As Integer
            Dim nY1 As Integer
            Dim nX1 As Integer
            Dim pen As Pen = Nothing
            Dim pen1 As Pen = Nothing

            e.Graphics.Clear(BackColor)

            If (GridPixels <> 0) Then
                pen = New Pen(GridColor, 1)
                nX = (rt.Width / GridPixels)
                nY = (rt.Height / GridPixels)
                For i = 1 To nX
                    e.Graphics.DrawLine(pen, (i * GridPixels), 0, (i * GridPixels), yStart)
                Next
                For i = 1 To nX
                    e.Graphics.DrawLine(pen, 0, (i * GridPixels), xStart, (i * GridPixels))
                Next
            End If

            If (ChartType = ChartType.Stick) Then
                pen = New Pen(LineColor, 2)
                For i = (count - 1) To 0 Step -1
                    nX = (xStart - (2 * (count - i)))
                    If (nX <= 0) Then
                        Exit For
                    End If
                    nY = CType((yStart - (y * Convert.ToDouble(_arrayList(i)))), Integer)
                    e.Graphics.DrawLine(pen, nX, yStart, nX, nY)
                Next

                pen1 = New Pen(LineColor1, 2)
                For i = (count1 - 1) To 0 Step -1
                    nX1 = (xStart - (2 * (count1 - i)))
                    If (nX1 <= 0) Then
                        Exit For
                    End If
                    nY1 = CType((yStart - (y * Convert.ToDouble(_arrayList1(i)))), Integer)
                    e.Graphics.DrawLine(pen1, nX1, yStart, nX1, nY1)
                Next
            ElseIf (ChartType = ChartType.Line) Then
                pen = New Pen(LineColor, 1)
                pen1 = New Pen(LineColor1, 1)
                Dim nX0 As Integer = (xStart - 2)
                Dim nY0 As Integer = CType((yStart - (y * Convert.ToDouble(_arrayList((count - 1))))), Integer)

                For i = (count - 2) To 0 Step -1
                    nX = (xStart - (2 * (count - i)))
                    If (nX <= 0) Then
                        Exit For
                        'Exit Do
                    End If
                    nY = CType((yStart - (y * Convert.ToDouble(_arrayList(i)))), Integer)
                    e.Graphics.DrawLine(pen, nX0, nY0, nX, nY)
                    nX0 = nX
                    nY0 = nY
                Next

                Dim nnX1 As Integer = (xStart - 2)
                Dim nnY1 As Integer = CType((yStart - (y * Convert.ToDouble(_arrayList1((count1 - 1))))), Integer)

                For i = (count - 2) To 0 Step -1
                    nX1 = (xStart - (2 * (count1 - i)))
                    If (nX1 <= 0) Then
                        Exit For
                        'Exit Do
                    End If
                    nY1 = CType((yStart - (y * Convert.ToDouble(_arrayList1(i)))), Integer)
                    e.Graphics.DrawLine(pen, nnX1, nnY1, nX1, nY1)
                    nnX1 = nX1
                    nnY1 = nY1
                Next
            End If
            'e.Graphics.DrawString("DL Max: " & yMax.ToString & " KB/s", New System.Drawing.Font("Arial", 8, FontStyle.Bold), Brushes.Red, 0, 0)
            'e.Graphics.DrawString("UL Max: " & yMax1.ToString & " KB/s", New System.Drawing.Font("Arial", 8, FontStyle.Bold), Brushes.Red, 0, 5)
            MyBase.OnPaint(e)
        End Sub
#End Region
    End Class

    Public Enum ChartType

        Stick

        Line
    End Enum
End Namespace