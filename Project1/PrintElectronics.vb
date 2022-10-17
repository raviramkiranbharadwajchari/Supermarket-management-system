Imports System.Data.SqlClient
Public Class PrintElectronics
    Public Property StringPass As String
    Private Sub PrintElectronics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label7.Text = StringPass

        Label11.Visible = False
        ProgressBar1.Visible = False
        Label9.Visible = False

        Button4.Visible = False
        DataGridView1.Visible = False
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from Table3 "
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
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Dim query = "select * from  Table3  where [PhoneNumber] = '" & TextBox2.Text & "'And [Date] ='" & DateTimePicker1.Text & "'"
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then
            MessageBox.Show("Invalid Number")
            DataGridView1.Visible = False

            Button4.Visible = False

        Else

            Button4.Visible = True
            DataGridView1.Visible = True
            da.SelectCommand = cmd
            Dim Table2 As New DataTable
            Table2.Clear()
            da.Fill(Table2)
            DataGridView1.DataSource = Table2

        End If
    End Sub
    Dim i As Integer
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
       
            ProgressBar1.Visible = True
            Timer1.Enabled = True
            ProgressBar1.Maximum = 100
            i = 1

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 1
        Label11.Text = " Loading" & i & " % Completed "
        i += 1
        ProgressBar1.Enabled = False
        If i > 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            Button4.Visible = False
            TextBox1.Enabled = False

            Label10.Visible = True
            TextBox2.Visible = False
            Button2.Visible = False
            Label8.Text = "The Items Are"
            Label11.Text = ""
            Label9.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = " select * from Login where PhoneNumber ='" & TextBox1.Text & "' "
        Dim cmd = New SqlCommand(query1, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        Dim Table2 As New DataTable
        da.Fill(Table2)

        Dim row() As DataRow = Table2.Select("PhoneNumber = '" & TextBox1.Text & "' ")

        If row.Count = 0 Then
            MessageBox.Show(" Invalid Number ")
            GroupBox1.Enabled = False

            Refresh()
        Else

            GroupBox1.Enabled = True
            Label5.Text = row(0).Item("Name").ToString
            Label4.Text = row(0).Item("Address").ToString
            TextBox2.Text = row(0).Item("PhoneNumber").ToString

        End If

        Refresh()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ProgressBar1.Visible = True
        Timer1.Enabled = True
        ProgressBar1.Maximum = 100
        i = 1
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class