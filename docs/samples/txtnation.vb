Imports System.Web

Module Module1
    Public Function SendSMS(ByVal msisdn As String, ByVal username As String, ByVal password As String, ByVal output As String)
        Dim webClient As New System.Net.WebClient
        Dim url As String = "http://smsc.txtnation.com:5002/checkHLR?" & "msisdn=" & msisdn & "&username=" & username & "&password=" & password & "&output=" & output
        Dim result As String = webClient.DownloadString(url)
        SendSMS = result
    End Function

    Sub Main()
        Dim result As String = SendSMS("msisdn", "username", "password", "xml|json")
        Console.WriteLine(result)
        Console.ReadKey()
    End Sub

End Module







