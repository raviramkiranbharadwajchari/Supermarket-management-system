Imports System.Data.SqlClient
Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.Equals("Seller") And TextBox2.Text.Equals("Seller123") Then
            Dim str = TextBox1.Text
            Dim frg = New Homepage
            frg.Label1.Text = "Welcome " + str

            frg.Show()
            Me.Hide()

        Else
            Dim query = "select * from Login  where UserID='" & TextBox1.Text & "'and password= '" & TextBox2.Text & "' "
            Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
            Dim cmd = New SqlCommand(query, Con)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MessageBox.Show("Invalid User ID")

            Else
                Dim str = TextBox1.Text
                Dim frg = New Homepage
                frg.Label1.Text = "Welcome " + str
                frg.Show()
                Me.Hide()
            End If

        End If
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MessageBox.Show("")

        End If
        refresh()
    End Sub


    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Forget.Show()

    End Sub
    Public Sub refresh()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Sigin.Show()
        Me.Hide()

    End Sub
End Class
