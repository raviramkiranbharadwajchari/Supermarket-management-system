Public Class Form1
    Dim i As Integer
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        ProgressBar1.Maximum = 100
        i = 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 1
        Label11.Text = "Loading " & i & " % Completed "
        i += 1
        ProgressBar1.Enabled = False
        If i > 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            Login.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        ProgressBar1.Maximum = 100
        i = 1

        Timer1.Start()
    End Sub
End Class