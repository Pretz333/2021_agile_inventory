﻿Imports System.Data.SqlClient

Public Class frmLocations
    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTableData(String.Empty)
    End Sub

    'Set up connection to database
    Private Function ConnectToDb() As SqlConnection
        'This gives the full path into the bin/debug folder
        Dim strPath As String = Application.StartupPath
        Dim intPathLength As Integer = strPath.Length

        'This strips off the bin/debug folder to point into your project folder.
        strPath = strPath.Substring(0, intPathLength - 25)

        Dim strconnection As String = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + strPath + "Inventory.mdf"
        Dim dbConnection As New SqlConnection(strconnection)

        Return dbConnection
    End Function

    Public Sub LoadTableData(ByVal searchTerm As String)
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Dim selectStatement As String = "SELECT * FROM Location"
        If searchTerm IsNot String.Empty Then
            Command.Append(" WHERE Description LIKE '%" + searchTerm + "%'")
        End If
        Dim cmd As New SqlCommand(selectStatement, dbConnection)
        cmd.CommandType = CommandType.Text
        Dim dataAdapter As New SqlDataAdapter(cmd)
        Dim dataTable As New DataTable()
        dataAdapter.Fill(dataTable)
        dvgLocations.DataSource = dataTable
        dbConnection.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadTableData(txtSearch.Text)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim name As String = InputBox("Please enter the Location name below.", "Create New Location")
        Dim dbConnection As SqlConnection = ConnectToDb()
        dbConnection.Open()
        Dim sqlString As String = "INSERT INTO Location (Description) VALUES(@name)"
        Dim saveCommand As New SqlCommand(sqlString, dbConnection)
        saveCommand.Parameters.AddWithValue("@name", name)

        Try
            If saveCommand.ExecuteNonQuery > 0 Then
                MessageBox.Show("Category was successfully saved.")
            Else
                MessageBox.Show("Category was not saved.")
            End If
        Catch ex As Exception
            MessageBox.Show("There was a problem connecting to the database: " + ex.Message)
        End Try

        Me.Dispose(True)
        frmDashboard.Show()
    End Sub

    Private Sub dvgLocations_Click(sender As Object, e As EventArgs) Handles dvgLocations.Click
        dvgLocations.DefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        Me.Close()
        frmDashboard.Show()
    End Sub

    Private Sub btnNavItems_Click(sender As Object, e As EventArgs) Handles btnNavItems.Click
        Me.Close()
        frmItems.Show()
    End Sub

    Private Sub btnNavCategories_Click(sender As Object, e As EventArgs) Handles btnNavCategories.Click
        Me.Close()
        frmCategories.Show()
    End Sub

    Private Sub btnNavLocations_Click(sender As Object, e As EventArgs) Handles btnNavLocations.Click
        'Already on this page
    End Sub

    Private Sub btnNavExport_Click(sender As Object, e As EventArgs) Handles btnNavExport.Click
        Me.Close()
        frmExport.Show()
    End Sub
End Class