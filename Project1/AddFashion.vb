Imports System.Data.SqlClient
Public Class AddFashion

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Saller.Show()
        Me.Close()
    End Sub
    


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from [Fashion]  where Product ='" & TextBox1.Text & "' "
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then
            If (TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And ComboBox1.Text <> "") Then
                Dim query1 = "insert into Fashion  values ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "' )"
                Dim cmd1 As SqlCommand
                cmd1 = New SqlCommand(query1, Con)
                cmd1.ExecuteNonQuery()
                Con.Close()
                MessageBox.Show("Data Saved")
                Refresh()
            Else
                MessageBox.Show("Enter all the Fields")
            End If

        Else
            MessageBox.Show("Product Already Exists")
        End If
    End Sub

    
    Public Sub Refresh()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub AddFashion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class