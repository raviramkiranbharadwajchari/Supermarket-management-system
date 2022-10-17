Imports System.Data.SqlClient
Public Class Sigin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox5.TextLength < 10 Then
            MessageBox.Show("enter the Valid PhoneNumber")
            Refresh()
        End If
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Login  where UserID='" & TextBox3.Text & "'"
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then
            If (TextBox1.Text <> "" And TextBox3.Text <> "" And RichTextBox1.Text <> "" And TextBox2.Text <> "" And TextBox5.Text <> "") Then
                Dim query1 = "insert into Login values ('" & TextBox3.Text & "','" & TextBox2.Text & "','" & RichTextBox1.Text & "','" & TextBox1.Text & "','" & TextBox5.Text & "')"
                Dim cmd1 As SqlCommand
                cmd1 = New SqlCommand(query1, Con)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Data Saved")
                Refresh()
            Else
                MessageBox.Show("Enter all the Fields")
            End If

        Else
            MessageBox.Show("User Id Already Exists")
        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox2.Text = ""
        RichTextBox1.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Sign_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub




    Public Sub Refresh()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox2.Text = ""
        RichTextBox1.Text = ""
    End Sub




    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) Then
            MessageBox.Show("Enter OnlyNumbers")
        End If




    End Sub





End Class