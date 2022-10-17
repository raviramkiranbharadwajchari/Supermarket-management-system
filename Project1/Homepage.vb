Public Class Homepage

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shopping.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Saller.Show()
        Me.Close()

    End Sub

    Private Sub Homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Label1.Text.Equals("Welcome Seller") Then
            Button1.Enabled = True
            Button3.Enabled = True
        Else
            Button1.Enabled = True
            Button3.Enabled = False
        End If

    End Sub

End Class