Public Class Shopping

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Glossary.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Fashion.Show()
        Me.Close()

    End Sub

    Private Sub Shopping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Electronics.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Homepage.Show()
        Me.Close()

    End Sub
End Class