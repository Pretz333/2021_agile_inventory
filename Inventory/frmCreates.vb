Imports System.Data.SqlClient

Public Class frmCreates


    Private Sub cmbList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbList.SelectedIndexChanged
        btnCreate.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        If crtBox.Text.Length > 0 Then

            'If category was selected from the combo box than add a catagory based on the description
            'Given
            If cmbList.SelectedItem.ToString = "Category" Then

                Dim dbConnection As SqlConnection = ConnectToDb()
                dbConnection.Open()
                Dim sqlString As String = "INSERT INTO Category (Description) VALUES(@crtBox)"

                'select query to find the item that was looked for

                'Dim adapter As New SqlDataAdapter("Select t1.description As Item, t2.description As Cat from item As t1 left join category As t2 On t1.CategoryId = t2.CategoryiD   where t1.description Like '%" & searchTerm & "%'", dbConnection)
                Dim saveCommand As New SqlCommand(sqlString, dbConnection)
                saveCommand.Parameters.AddWithValue("@crtBox", crtBox.Text.ToString())


                Try
                    If saveCommand.ExecuteNonQuery > 0 Then
                        MessageBox.Show("Category was successfully saved.")
                    Else
                        MessageBox.Show("Category was not saved.")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Ooops, there was a problem connecting to the database" + ex.Message)
                End Try

                MsgBox("Category has been added")
                Me.Dispose(True)
                frmDashboard.Show()


            End If
        End If


    End Sub

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


End Class