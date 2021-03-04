Imports System.Data.SqlClient

Public Class Form1

    'load table from database, in this case item table
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTable("")
    End Sub

    'set up connection function
    Private Function connectToDb() As SqlConnection

        'connection String
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fernando\Documents\GitHub\2021_agile_inventory\Inventory\Inventory.mdf;Integrated Security=True"


        'create connection object
        Dim dbConnection As New SqlConnection(connectionString)

        Return dbConnection
    End Function

    Public Sub LoadTable(ByVal tableR As String)
        Dim dbConnection As SqlConnection = connectToDb()
        dbConnection.Open()

        'select query to find the item that was looked for
        Dim adapter As New SqlDataAdapter("select t1.description as Item, t2.description as Cat from item as t1 left join category as t2 on t1.CategoryId = t2.CategoryiD   where t1.description like '%" & srchItem1.Text & "%'", dbConnection)

        'Fill the colum with the data from the database
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table


        dbConnection.Close()
    End Sub

    'basic search option
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles srchItem1.TextChanged
        LoadTable(srchItem1.Text)
    End Sub
End Class
