Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Module modMain
    Public isTapFound As Boolean = False
    Public nicInfo As Net.NetworkInformation.NetworkInterface
    Public lngBytesSend As Long
    Public lngBtyesReceived As Long
    Public bytesSentSpeed As Long
    Public bytesReceivedSpeed As Long
    Public sLAN As String = ""

    Dim globcookie As String
    Dim globalcookie As New CookieContainer

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32

    Public Sub ReduceMemoryUsage()
        GC.Collect()
        GC.Collect()
        SetProcessWorkingSetSize(Diagnostics.Process.GetCurrentProcess.Handle, -1, -1)
    End Sub

    Public Function GetAuthorization(ByVal user As String, ByVal pass As String) As String
        Dim authBytes() As Byte = Encoding.UTF8.GetBytes(user & ":" & pass)
        Return "Basic " & Convert.ToBase64String(authBytes)
    End Function

    Public Function GetCookie(ByVal host As String, ByVal username As String, ByVal password As String) As String

        Dim _urlPath As Uri
        Dim loginlink As String = ""
        Dim refererlink As String = ""
        Dim postData As String = ""
        Dim test As String = ""
        Dim tmp As String
        loginlink = "http://" & host & "/login"
        refererlink = "http://" & host & "/login"
        postData = "user_name=" & username & "&user_pass=" & password & "&submit=Login"
        'postData = "email=" & username & "&redirect=%2F&password=" & password

        _urlPath = New Uri(loginlink)
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(_urlPath), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = tempCookies
        postReq.ServicePoint.Expect100Continue = False
        postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1"

        postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
        postReq.Accept = "application/json, text/javascript, */*; q=0.01"
        postReq.Headers.Add("Accept-Language", "en-us,en;q=0.5")
        'postReq.Headers.Add("Accept-Encoding", "gzip, deflate")
        postReq.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7")
        postReq.AllowAutoRedirect = True
        'postReq.Referer = refererlink
        postReq.ContentLength = byteData.Length
        postReq.Timeout = 300000
        Dim postreqstream As Stream = postReq.GetRequestStream()

        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()
        Dim postresponse As HttpWebResponse

        Try
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)

            Dim stre As New StreamReader(postresponse.GetResponseStream)

            test = stre.ReadToEnd

            Dim dur1 As Integer
            Dim dur2 As Integer

            'globcookie.Add(postresponse.Cookies)

            If test.IndexOf("Inactive") > 1 Then
                tmp = "Inactive Account"
            ElseIf test.IndexOf("Login error") > 1 Then
                tmp = "Invalid Login"
            Else
                dur1 = test.IndexOf("<!--START-->")
                dur2 = test.IndexOf("<!--END-->", dur1)
                tmp = test.Substring(dur1 + 12, dur2 - (dur1 + 12))
            End If
            'Dim dur As Strin

        Catch ex As Exception
            tmp = "Error Fetching Info"
            'MsgBox(ex.Message)
        End Try

        Return tmp
    End Function

    Public Sub GetCookie1(ByVal host As String, ByVal username As String, ByVal password As String)

        Dim _urlPath As Uri
        Dim loginlink As String = ""
        Dim refererlink As String = ""
        Dim postData As String = ""
        Dim test As String = ""
        loginlink = "http://" & host & "/login"
        refererlink = "http://" & host & "/login"
        postData = "user_name=" & username & "&user_pass=" & password & "&submit=Login"
        'postData = "email=" & username & "&redirect=%2F&password=" & password

        _urlPath = New Uri(loginlink)
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(_urlPath), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = tempCookies
        postReq.ServicePoint.Expect100Continue = False
        postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1"

        postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
        postReq.Accept = "application/json, text/javascript, */*; q=0.01"
        postReq.Headers.Add("Accept-Language", "en-us,en;q=0.5")
        'postReq.Headers.Add("Accept-Encoding", "gzip, deflate")
        postReq.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7")
        postReq.AllowAutoRedirect = False
        'postReq.Referer = refererlink
        postReq.ContentLength = byteData.Length
        postReq.Timeout = 300000
        Dim postreqstream As Stream = postReq.GetRequestStream()

        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()
        Dim postresponse As HttpWebResponse

        Try
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)

            Dim stre As New StreamReader(postresponse.GetResponseStream)

            test = stre.ReadToEnd

            If test.IndexOf("Inactive") > 1 Then
                globcookie = ""
            ElseIf test.IndexOf("Login error") > 1 Then
                globcookie = ""
            Else
                'globcookie.Add(postresponse.Cookies)
                globalcookie.Add(postresponse.Cookies)
                For Each cookieValue As Cookie In postresponse.Cookies
                    globcookie = globcookie & cookieValue.ToString & ";"
                    'MsgBox(cookieValue.ToString)
                Next
            End If
            'Dim dur As Strin

        Catch ex As Exception
            globcookie = ""
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetVoucher(ByVal host As String, ByVal code As String, ByVal action As String, ByVal user As String, ByVal pass As String) As String
        GetCookie1(host, user, pass)

        If IsNothing(globcookie) Or globcookie <= "" Then
            Return "Error"
            Exit Function
        End If

        Dim _urlPath As Uri
        Dim loginlink As String = ""
        Dim refererlink As String = ""
        Dim postData As String = ""
        Dim test As String = ""
        Dim tmp As String
        loginlink = "http://" & host & "/vouchers"
        refererlink = "http://" & host & "/vouchers"
        postData = "voucher=" & code & "&action_voucher=" & action & "&validate_code=Submit"
        'postData = "user_name=" & username & "&user_pass=" & password & "&submit=Login"
        'postData = "email=" & username & "&redirect=%2F&password=" & password

        _urlPath = New Uri(loginlink)
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(_urlPath), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = globalcookie
        'postReq.Headers.Add("Authorization", GetAuthorization(user, pass))

        postReq.ServicePoint.Expect100Continue = False
        postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1"

        postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
        postReq.Accept = "application/json, text/javascript, */*; q=0.01"
        postReq.Headers.Add("Accept-Language", "en-us,en;q=0.5")
        'postReq.Headers.Add("Accept-Encoding", "gzip, deflate")
        postReq.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7")
        postReq.Headers.Add("Cookie", globcookie)
        'postReq.Referer = refererlink
        postReq.ContentLength = byteData.Length
        postReq.Timeout = 300000
        Dim postreqstream As Stream = postReq.GetRequestStream()

        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()
        Dim postresponse As HttpWebResponse

        Try
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)

            Dim stre As New StreamReader(postresponse.GetResponseStream)

            test = stre.ReadToEnd

            If test.IndexOf("Invalid Voucher Code!") > 1 Then
                tmp = "Invalid Voucher Code!"
            ElseIf test.IndexOf("Success!") > 1 Then
                tmp = "Success!"
            Else
                tmp = "Invalid account info!"
            End If
            'Dim dur As Strin

        Catch ex As Exception
            tmp = ""
            MsgBox(ex.Message)
        End Try

        Return tmp
    End Function

    Public Sub GetStatus1(ByVal host As String, ByVal lst As ListView)

        Dim _urlPath As Uri
        Dim loginlink As String = ""
        Dim refererlink As String = ""
        Dim postData As String = ""
        Dim test As String = ""
        'Dim tmp(server - 1) As String
        loginlink = "http://" & host & "/server/ss2.php"
        refererlink = "http://" & host & "/server/ss2.php"
        'postData = "user_name=" & username & "&user_pass=" & password & "&submit=Login"
        'postData = "email=" & username & "&redirect=%2F&password=" & password

        _urlPath = New Uri(loginlink)
        'Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        'Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(_urlPath), HttpWebRequest)
        postReq.Method = "GET"
        postReq.KeepAlive = True
        'postReq.CookieContainer = tempCookies
        postReq.ServicePoint.Expect100Continue = False
        postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1"
        postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
        postReq.Accept = "application/json, text/javascript, */*; q=0.01"
        postReq.Headers.Add("Accept-Language", "en-us,en;q=0.5")
        postReq.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7")
        'postReq.Referer = refererlink
        'postReq.ContentLength = byteData.Length
        postReq.Timeout = 300000
        Dim postresponse As HttpWebResponse
        lst.Items.Clear()
        Try
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)

            Dim stre As New StreamReader(postresponse.GetResponseStream)

            test = stre.ReadToEnd
            'MsgBox(test)
            Dim durval1 As Integer
            Dim durval2 As Integer
            Dim durval3 As String = ""

            Dim durval4 As Integer
            Dim durval5 As Integer
            Dim durval6 As String = ""

            Dim durval7 As Integer
            Dim durval8 As Integer
            Dim durval9 As String = ""

            Dim durlast1 As Integer
            Dim durlast2 As Integer
            Dim durlast3 As String = ""

            Dim lastind As Integer = 0
            Dim currpos As Integer = 0
            lastind = test.LastIndexOf("<!--STATUS-->")

            If lastind <= 0 Then

            End If

            Do
                durval1 = test.IndexOf("<!--NAME-->", currpos)
                If durval1 > currpos Then
                    durval2 = test.IndexOf("<!--NAME-->", durval1 + 11)
                    durval3 = test.Substring(durval1 + 11, durval2 - (durval1 + 11))
                    currpos = durval2
                End If

                durval4 = test.IndexOf("<!--STATUS-->", currpos)
                If durval4 > currpos Then
                    durval5 = test.IndexOf("<!--STATUS-->", durval4 + 13)
                    durval6 = test.Substring(durval4 + 13, durval5 - (durval4 + 13))
                    currpos = durval5
                End If

                durval7 = test.IndexOf("<!--TCP-->", currpos)
                If durval7 > currpos Then
                    durval8 = test.IndexOf("<!--TCP-->", durval7 + 10)
                    durval9 = test.Substring(durval7 + 10, durval8 - (durval7 + 10))
                    currpos = durval8
                End If

                durlast1 = test.IndexOf("<!--UDP-->", currpos)
                If durlast1 > currpos Then
                    durlast2 = test.IndexOf("<!--UDP-->", durlast1 + 10)
                    durlast3 = test.Substring(durlast1 + 10, durlast2 - (durlast1 + 10))
                    currpos = durlast2
                End If

                'If durlast3 > "" Then
                Dim newl As ListViewItem = lst.Items.Add(durval3.Trim)
                newl.SubItems.Add(durval6.Trim)
                newl.SubItems.Add(durval9.Trim)
                newl.SubItems.Add(durlast3.Trim)
                If durval6.Trim = "Offline" Then
                    newl.BackColor = Color.Red
                Else
                    newl.BackColor = Color.Green
                End If
                'End If
            Loop Until currpos = lastind Or currpos > lastind


        Catch ex As Exception
            'tmp(0) = ""
            MsgBox(ex.Message)
        End Try

    End Sub

    Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Function EnryptString(ByVal strEncrypted As String) As String
        Try
            Dim b As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted)
            Dim encryptedConnectionString As String = Convert.ToBase64String(b)
            Return encryptedConnectionString
        Catch
            Throw
        End Try
    End Function

    Function DecryptString(ByVal encrString As String) As String
        Try
            Dim b As Byte() = Convert.FromBase64String(encrString)
            Dim decryptedConnectionString As String = System.Text.ASCIIEncoding.ASCII.GetString(b)
            Return decryptedConnectionString
        Catch
            Throw
        End Try
    End Function

    Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop
    End Sub

    Function GetPingMs(ByRef hostNameOrAddress As String) As String
        Dim ping As New System.Net.NetworkInformation.Ping
        Try
            Return ping.Send(hostNameOrAddress).RoundtripTime
        Catch
            Return "offline"
        End Try
    End Function

    Public Function ByteConv(ByVal b As Double) As String
        Dim bSize(8) As String
        Dim i As Integer

        bSize(0) = "Bytes"
        bSize(1) = "KB"
        bSize(2) = "MB"
        bSize(3) = "GB"
        bSize(4) = "TB"
        bSize(5) = "PB"
        bSize(6) = "EB"
        bSize(7) = "ZB"
        bSize(8) = "YB"

        b = CDbl(b)
        For i = bSize.Length - 1 To 0 Step -1
            If b >= (1024 ^ i) Then
                Return Putal(b / (1024 ^ i)) & " " & bSize(i)
                Exit For
            End If
        Next

    End Function

    Public Function Putal(ByVal value As Double) As String
        If value >= 100 Then
            Return Format$(CInt(value))
        ElseIf value >= 10 Then
            Return Format$(value, "0.0")
        Else
            Return Format$(value, "0.00")
        End If
    End Function

    Public Function EncryptString128Bit(ByVal vstrTextToBeEncrypted As String, _
                                    ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream()
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ******  Strip any null character from string to be encrypted    ******
        '   **********************************************************************

        vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged()

        '   ***********************************************************************
        '   ******  Create the encryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
              objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
              CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch



        End Try

        '   ***********************************************************************
        '   ******   Return encryptes value (converted from  byte Array to   ******
        '   ******   a base64 string).  Base64 is MIME encoding)             ******
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    Public Function DecryptString128Bit(ByVal vstrStringToBeDecrypted As String, _
                                        ByVal vstrDecryptionKey As String) As String
        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged()
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        'Dim intCtr As Integer
        Dim strReturnString As String = String.Empty
        'Dim achrCharacterArray() As Char
        'Dim intIndex As Integer

        '   *****************************************************************
        '   ******   Convert base64 encrypted value to byte array      ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Create the decryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   *****************************************
        '   ******   Return decypted value     ******
        '   *****************************************

        Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

    End Function


    Public Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

    Function ReturnLogInDescOrder(ByVal LogFilePath As String) As String

        ' Read all lines from a text file and display in reverse order 
        Dim strArray() As String = System.IO.File.ReadAllLines(LogFilePath)
        Dim strTemp As String = ""

        Array.Reverse(strArray)

        For Each _string As String In strArray
            strTemp &= _string & "<br />"
        Next

        Return strTemp

    End Function

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function GetRandomIP() As String
        Dim ips As String() = {"112.207.*.%", "50.117.*.%", "50.18.*.%", "216.172.*.%", "204.14.*.%", "204.236.*.%"}

        Dim rndIP As String = ""
        Dim genIPs As String = ""

        For x As Integer = 1 To 30
            rndIP = ips(GetRandom(0, 5))
            genIPs = genIPs & rndIP.Replace("*", GetRandom(1, 254)).Replace("%", GetRandom(1, 254)) & "|"
        Next

        Return genIPs.Remove(genIPs.Length - 1, 1)
    End Function

    Public Function GetMyIP() As string
        Dim outputIP As String
        Using wClient As New WebClient
            Dim myIP As String = wClient.DownloadString("http://www.findipinfo.com/")
            Dim regex As New RegularExpressions.Regex("Your IP Address Is: (?<name>.*)</h1>")
            Dim matches As MatchCollection = regex.Matches(myIP)
            'MsgBox(matches.Count)
            If matches.Count > 0 Then
                For Each match As Match In matches
                    'MsgBox(match.Groups("name").ToString)
                    If match.Success Then
                        outputIP = match.Groups("name").ToString
                    End If
                Next
            End If
        End Using
        Return outputIP
    End Function
End Module
