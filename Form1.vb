Imports MySql.Data.MySqlClient
Imports module1

Public Class Form1
    Dim sqlQuery As String
    Dim da As mysqldataadapter
    Dim dt As DataTable
    Dim conn As New MySqlConnection
    Private Sub dataRecord_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataRecord.CellContentClick
        DbConnect()
    End Sub

    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnload.Click

        Try
            conn.Open()
            sqlQuery = "Select * from employee"
            da = New MySqlDataAdapter(sqlQuery, conn)
            dt = New DataTable
            da.Fill(dt)
            dataRecord.DataSource = dt
        Catch ex As Exception

        End Try
        conn.Close()


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DbConnect()

    End Sub
    Public Sub DbConnect()
        Dim conn As New MySqlConnection
        Dim dbname As String = "IT2A"
        Dim username As String = "root"
        Dim password As String = "password" 'mysql server pwd
        Dim server As String = "127.0.0.1" 'pc ipadd'

        'check if connection is open
        If Not conn Is Nothing Then
            conn.Close()
            'establish new connection
            conn.ConnectionString = "server" & server & ";user id =" & username & ";password =" & password & ";database=" & dbname & ""
            Try
                conn.Open() 'open connection
                MsgBox("connected")

            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub
End Class


