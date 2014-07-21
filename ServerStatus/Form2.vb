Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Label1.Text = FormularMessage
        Timer2.Interval = 2000     '5 Sekunden
        Timer2.Enabled = True
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'Me.Close()      'statt CLOSE .visible=false?
        Me.Visible = False
    End Sub
End Class