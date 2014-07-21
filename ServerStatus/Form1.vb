Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports System
Imports System.IO
Imports System.Collections


Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objReader As New StreamReader("E:\--- PROGRAMME ---\SERVERWATCH\servers.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim arrDetail() As String

        'DataGridView aus Textdatei füllen
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each sLine In arrText
            'Format: "KIZZY", "81.19.209.26", 27017, 0, True
            arrDetail = sLine.Split(";")
            DataGridView1.Rows.Add(arrDetail(0), arrDetail(1), arrDetail(2), arrDetail(3), arrDetail(4))
        Next

        'DataGridView füllen
        'DataGridView1.Rows.Add("POLSKA", "91.230.202.25", 27073, 0, False)

        Timer1.Interval = 30000     'alle 30 Sekunden
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim anzPlayer As Short
        Dim txtAlleServer As String
        Dim i As Integer
        'Abfrage Polen-Server    ALT
        'Wichtig ist der \0 am Ende, sonst klappt es nicht!
        'anzPlayer = ClientAbfragePlayer("91.204.161.168", 27066, Chr(255) & Chr(255) & Chr(255) & Chr(255) & Chr("&H54") & "Source Engine Query" & Chr(0))
        'MsgBox("Anzahl Spieler aktuell:" + Str(anzPlayer))

        'Neuer Player dabei?
        'If Convert.ToInt32(Label1.Text) <> anzPlayer Then
        '    Label1.Text = Str(anzPlayer)
        '    Label1.ForeColor = Color.Red
        '    My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        '    FormularMessage = "NEUER PLAYER"

        '    Form2.ShowDialog()
        '    Label1.ForeColor = Color.Black
        'End If
        txtAlleServer = ""

        For i = 0 To DataGridView1.Rows.Count - 1
            'Hier passiert die Server-Abfrage

            'MESSAGEBOX-Test
            'anzPlayer = ClientAbfragePlayer("81.19.209.26", 27017, Chr(255) & Chr(255) & Chr(255) & Chr(255) & Chr("&H54") & "Source Engine Query" & Chr(0))
            'txtAlleServer = txtAlleServer + " " + DataGridView1.Item(0, i).Value.ToString + ":" + DataGridView1.Item(1, i).Value.ToString

            'Checkbox enabled? Dann Abfrage
            If DataGridView1.Item(4, i).Value = True Then
                anzPlayer = ClientAbfragePlayer(DataGridView1.Item(1, i).Value.ToString, DataGridView1.Item(2, i).Value, Chr(255) & Chr(255) & Chr(255) & Chr(255) & Chr("&H54") & "Source Engine Query" & Chr(0))
            End If
            'Neuer Player dabei?
            If Convert.ToInt32(DataGridView1.Item(3, i).Value) <> anzPlayer Then
                DataGridView1.Item(3, i).Value = anzPlayer
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                FormularMessage = "NEUER SPIELER"
                Form2.ShowDialog()
            End If
        Next
        'MsgBox(txtAlleServer)

    End Sub


    Function ClientAbfragePlayer(srv As String, port As Integer, msg As String) As Short
        Dim udpClient As New UdpClient()
        Dim aktuellePlayer As Short
        Dim i As Integer, count As Short

        aktuellePlayer = 0   'Init
        count = 0

        Try
            'Dim GLOIP As IPAddress
            Dim GLOIP As String
            Dim GLOINTPORT As Integer
            Dim bytCommand As Byte() = New Byte() {}
            Dim pRet As Integer


            'GLOIP = IPAddress.Parse(srv)
            GLOIP = srv
            GLOINTPORT = port
            udpClient.Connect(GLOIP, GLOINTPORT)

            '
            ' SENDEN

            '
            'bytCommand = Encoding.ASCII.GetBytes(msg)      'nur 127 Bit!!!
            bytCommand = Encoding.Default.GetBytes(msg)    'volle Codepage!
            pRet = udpClient.Send(bytCommand, bytCommand.Length)
            'Console.WriteLine("No of bytes send " & pRet)

            '
            ' EMPFANGEN
            '
            ' IPEndPoint object will allow us to read datagrams sent from any source.
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)

            ' UdpClient.Receive blocks until a message is received from a remote host.
            Dim receiveBytes As [Byte]() = udpClient.Receive(RemoteIpEndPoint)
            Dim returnData As String = DelSpecChar(Encoding.Default.GetString(receiveBytes))

            'falsch, da Player immer an anderer Stelle stehen
            aktuellePlayer = Convert.ToInt32(receiveBytes(45))

            For i = 0 To receiveBytes.Length - 1
                If count = 5 Then
                    aktuellePlayer = receiveBytes(i)
                    i = receiveBytes.Length - 1
                End If
                If receiveBytes(i) = "&H00" Then
                    count += 1
                End If
            Next

            'nicht viel besser
            'Dim returnData As String = ByteArrayToString(receiveBytes)

            ' Which one of these two hosts responded?
            'MsgBox("This is the message you received " + _
            '                             returnData.ToString() + _
            '                         "This message was sent from " + _
            '                            RemoteIpEndPoint.Address.ToString() + _
            '                             " on their port number " + _
            '                             RemoteIpEndPoint.Port.ToString())
            udpClient.Close()

            Return aktuellePlayer
        Catch e As Exception
            'Console.WriteLine(e.ToString())
            FormularMessage = "Server nicht erreichbar"
            Form2.ShowDialog()
            Return 99
        End Try

    End Function


    'Sonderzeichen aus String e
    Function DelSpecChar(strSource As String) As String
        Dim i As Long
        Dim strTmp As String
        strTmp = ""

        For i = 1 To Len(strSource)
            Select Case Asc(Mid$(strSource, i, 1))
                Case 48 To 57, 65 To 90, 97 To 122
                    strTmp = strTmp & Mid$(strSource, i, 1)
                Case Else
                    strTmp = strTmp & "."
            End Select
        Next i

        DelSpecChar = strTmp
    End Function

End Class
