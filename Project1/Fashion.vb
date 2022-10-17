Imports System.Data.SqlClient
Public Class Fashion

    Private Sub Fashion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GroupBox1.Enabled = False
        Label5.Enabled = False
        TextBox2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Fashion"
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim Table2 As New DataTable
        Table2.Clear()
        da.Fill(Table2)
        DataGridView1.DataSource = Table2
        DataGridView1.MultiSelect = True
        Con.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = " select * from Login  where PhoneNumber ='" & TextBox1.Text & "' "
        Dim cmd = New SqlCommand(query1, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        Dim Table2 As New DataTable
        da.Fill(Table2)

        Dim row() As DataRow = Table2.Select("PhoneNumber = '" & TextBox1.Text & "' ")

        If row.Count = 0 Then
            MessageBox.Show(" Invalid Number ")
            Label5.Enabled = False
            TextBox2.Enabled = False
            Button4.Enabled = False
            Button3.Enabled = False
            Refresh()
        Else
            Label5.Enabled = True
            TextBox2.Enabled = True
            Button4.Enabled = True
            Button3.Enabled = False


        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = " select * from Fashion where Product ='" & TextBox2.Text & "' "
        Dim cmd = New SqlCommand(query1, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        Dim Table2 As New DataTable
        da.Fill(Table2)

        Dim row() As DataRow = Table2.Select("Product = '" & TextBox2.Text & "' ")

        If row.Count = 0 Then
            MessageBox.Show(" Invalid Product ")
            GroupBox1.Enabled = False
            Button3.Enabled = False
            Refresh()
        Else
            Button3.Enabled = True
            GroupBox1.Enabled = True
            Label6.Text = row(0).Item("AvailableQuantity").ToString
            Price.Text = row(0).Item("Price").ToString()
            Label11.Text = row(0).Item("Size").ToString()
        End If
        If Label6.Text = "0" Then
            MessageBox.Show("Product Not Available")
            GroupBox1.Enabled = False
            Button3.Enabled = False
        Else
            GroupBox1.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        GroupBox1.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label9.Text = TextBox1.Text
        Label5.Enabled = False
        TextBox2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox2.Text <> "" And TextBox3.Text <> "") Then

            TextBox1.Text = Label9.Text
            TextBox5.Text = Price.Text * TextBox3.Text
            Label6.Text = Label6.Text - TextBox3.Text
            Dim query1 = "insert into [Table2] values ('" & TextBox2.Text & "','" & Price.Text & "','" & TextBox3.Text & "','" & Label11.Text & "','" & Label9.Text & "','" & DateTimePicker1.Text & "')"

            Dim query2 = "Update Fashion set AvailableQuantity='" & Label6.Text & "' where Product='" & TextBox2.Text & "'"

            Dim cmd2 As SqlCommand
            Dim cmd1 As SqlCommand
            Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
            Con.Open()
            cmd1 = New SqlCommand(query1, Con)
            cmd2 = New SqlCommand(query2, Con)
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            MessageBox.Show("Product is added")
            Button3.Enabled = False
            Refresh()

        Else

            MessageBox.Show("Enter all the Fields")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shopping.Show()
        Me.Close()
    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New Check_Fashion
        a.StringPass = TextBox5.Text
        a.Show()
        Me.Close()
    End Sub
End Class