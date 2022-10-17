Imports System.Data.SqlClient
Public Class card
    Public Property StringPass As String
   

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        If TextBox2.TextLength < 10 Then

            MessageBox.Show("enter the valid number")
        End If
        If (TextBox2.Text = "") Then
            MessageBox.Show("enter the Phone Number")
        Else


            Dim query = "select * from Table1 where [PhoneNumber] = '" & TextBox2.Text & "' and [Date] = '" & DateTimePicker1.Text & "'"
            Dim cmd = New SqlCommand(query, Con)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New DataSet()
            Dim Table2 As New DataTable
            da.Fill(Table2)

            Dim row() As DataRow = Table2.Select("PhoneNumber = '" & TextBox2.Text & "' ")

            If row.Count = 0 Then
                MessageBox.Show(" Invalid Number ")
                Button1.Enabled = False
                TextBox1.Enabled = False
                ComboBox1.Enabled = False
                ComboBox2.Enabled = False
                DateTimePicker2.Enabled = False
                TextBox5.Enabled = False
            Else

                TextBox1.Enabled = True
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                DateTimePicker2.Enabled = True
                TextBox5.Enabled = True
                Button1.Enabled = True
            End If
        End If
        Con.Close()


    End Sub

    Private Sub card_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = StringPass
        TextBox3.Visible = False
        Button1.Enabled = False
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        DateTimePicker2.Enabled = False
        TextBox5.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox5.TextLength < 12 Then
            MessageBox.Show("enter the Valid CardNumber")
            Refresh()
        Else

            If TextBox1.Text = "" And ComboBox1.Text = "" And ComboBox2.Text = "" And DateTimePicker2.Text = "" And TextBox5.Text = "" Then
                MessageBox.Show("Enter all the Fields")
            End If

            If ComboBox1.Text = "Grocery" Then
                Dim a As New Print
                a.StringPass = TextBox3.Text
                a.Show()
                Me.Close()
                If DateTimePicker1.Text <> DateTimePicker2.Text Then

                    MessageBox.Show("enter the valid date")
                End If
            End If

            End If
    End Sub

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Check.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) Then
            MessageBox.Show("Enter OnlyNumbers")
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub



End Class