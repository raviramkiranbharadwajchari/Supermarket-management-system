Imports System.Data.SqlClient
Public Class RemoveFashion

    Private Sub RemoveFashion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Fashion "
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim Table2 As New DataTable
        Table2.Clear()
        da.Fill(Table2)
        DataGridView1.DataSource = Table2
        DataGridView1.MultiSelect = True
        Button3.Visible = False
        GroupBox1.Visible = False
        Con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = " select * from [Fashion]  where Product ='" & TextBox1.Text & "' "
        Dim cmd = New SqlCommand(query1, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        Dim Table2 As New DataTable
        da.Fill(Table2)

        Dim row() As DataRow = Table2.Select("Product = '" & TextBox1.Text & "' ")

        If row.Count = 0 Then
            MessageBox.Show("invalid Product")
            Button3.Visible = False
            GroupBox1.Visible = False
            Refresh()
        Else

            GroupBox1.Visible = True
            Button3.Visible = True
            TextBox3.Text = row(0).Item("Price").ToString()
            TextBox2.Text = row(0).Item("AvailableQuantity").ToString()


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()

        Dim query1 = "Delete from Fashion  where Product ='" & TextBox1.Text & "'"
        Dim cmd1 As SqlCommand
        cmd1 = New SqlCommand(query1, Con)
        cmd1.ExecuteNonQuery()
        Con.Close()
        MessageBox.Show("Data as deleted")
        Refresh()
        GroupBox1.Visible = False
    End Sub
    Public Sub Refresh()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Saller.Show()
        Me.Hide()

    End Sub
End Class