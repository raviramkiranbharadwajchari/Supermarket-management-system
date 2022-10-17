Imports System.Data.SqlClient
Public Class Forget

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.TextLength < 10 Then
            MessageBox.Show("enter the Valid PhoneNumber")
            refresh()
        End If
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Login where PhoneNumber='" & TextBox1.Text & "'"
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then
            MessageBox.Show("Invalid Number")
            GroupBox1.Enabled = False
            Button3.Enabled = False
            refresh()
        Else

            GroupBox1.Enabled = True
            Button3.Enabled = True

        End If


    End Sub
    Private Sub Forget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
            Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
            Con.Open()
            If TextBox3.Text <> TextBox4.Text Then
                MessageBox.Show("New Password and Confirm Password Not Matching")
            Else


                Dim Query1 = "Update Login set Password='" & TextBox4.Text & "' where PhoneNumber='" & TextBox1.Text & "'"


                Dim cmd1 = New SqlCommand(Query1, Con)
                cmd1.ExecuteNonQuery()
                Con.Close()
                MessageBox.Show("Data Updated")

                refresh()
                Button3.Enabled = False
                GroupBox1.Enabled = False
            End If
        Else
            MessageBox.Show("enter all the fields")
        End If
    End Sub
    Public Sub refresh()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) Then
            MessageBox.Show("Enter OnlyNumbers")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
   