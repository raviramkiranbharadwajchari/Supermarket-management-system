Public Class Bill
    Public Property StringPass As String
   
    Private Sub Bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = StringPass
    End Sub
End Class