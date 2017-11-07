Class MemoryHelper
    Private Shared _Toggle As Boolean = True

    Friend Shared Sub ReduceMemory()
        Try
            System.Diagnostics.Debug.WriteLine("Reducing memory...")
            Dim loProcess As Process = Process.GetCurrentProcess
            If _Toggle Then
                loProcess.MaxWorkingSet = CType((CType(loProcess.MaxWorkingSet, Integer) - 1), IntPtr)
                loProcess.MinWorkingSet = CType((CType(loProcess.MinWorkingSet, Integer) - 1), IntPtr)
            Else
                loProcess.MaxWorkingSet = CType((CType(loProcess.MaxWorkingSet, Integer) + 1), IntPtr)
                loProcess.MinWorkingSet = CType((CType(loProcess.MinWorkingSet, Integer) + 1), IntPtr)
            End If
            _Toggle = Not _Toggle
        Catch x As Exception
            Debug.WriteLine(x)
        End Try
    End Sub
End Class