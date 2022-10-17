Imports System.Data.SqlClient
Public Class Glossary
    Private Sub Glossary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        GroupBox1.Enabled = False
        Label5.Enabled = False
        TextBox2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Glossary1"
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
   
    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shopping.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = " select * from Glossary1 where Product ='" & TextBox2.Text & "' "
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox2.Text <> "" And TextBox3.Text <> "") Then

            TextBox5.Text = Price.Text * TextBox3.Text
            Label12.Text = "Grocery"
            Label6.Text = Label6.Text - TextBox3.Text
            Dim query1 = "insert into [Table1] values ('" & TextBox3.Text & "','" & Price.Text & "','" & TextBox2.Text & "','" & Label9.Text & "','" & DateTimePicker1.Text & "','" & Label12.Text & "')"

            Dim query2 = "Update Glossary1 set AvailableQuantity='" & Label6.Text & "' where Product='" & TextBox2.Text & "'"

            Dim cmd2 As SqlCommand
            Dim cmd1 As SqlCommand
            Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
            Con.Open()
            cmd1 = New SqlCommand(query1, Con)
            cmd2 = New SqlCommand(query2, Con)
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            MessageBox.Show("Product is added")
            Button1.Enabled = True
            refresh()


        Else

            MessageBox.Show("Enter all the Fields")
        End If

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Label5.Text = "product"
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TextBox1.TextLength < 10 Then
            MessageBox.Show("enter the Valid PhoneNumber")
            refresh()
        End If
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
            Button1.Enabled = False
            refresh()
        Else
            Button1.Enabled = False
            Label5.Enabled = True
            TextBox2.Enabled = True
            Button4.Enabled = True
            Button3.Enabled = False


        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) Then
            MessageBox.Show("Enter OnlyNumbers")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label9.Text = TextBox1.Text
        Label5.Enabled = False
        TextBox2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim a As New Check


            a.Stringpass = TextBox5.Text
            a.Show()


        Else
            MessageBox.Show("enter the phone number and product name ")
        End If


    End Sub
    Public Sub refresh()

        Price.Text = ""
        Label6.Text = ""
        TextBox3.Text = ""
    End Sub
End Class