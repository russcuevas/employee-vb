Imports MySql.Data.MySqlClient

Public Class AdminBlotter
    ' Connection string to MySQL
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)

    ' Form Load event
    Private Sub AdminBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form to maximize when it is opened
        Me.WindowState = FormWindowState.Maximized

        LoadBlotterData()
    End Sub

    ' Load data from the database
    Public Sub LoadBlotterData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT id, fullname, address, gender, dateofbirth, contact, complaint_fullname, complaint_gender, complaint_address, address_issues, issues_status FROM tbl_blotter"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            blotterTableData.Columns.Clear()
            blotterTableData.AllowUserToAddRows = False
            blotterTableData.AllowUserToDeleteRows = False
            blotterTableData.ReadOnly = True
            blotterTableData.DataSource = table

            If table.Rows.Count = 0 Then
                ' Show "No data available"
                blotterTableData.DataSource = Nothing
                blotterTableData.Enabled = False
                blotterTableData.ColumnHeadersVisible = False
                blotterTableData.RowHeadersVisible = False

                Dim emptyTable As New DataTable()
                emptyTable.Columns.Add("Message", GetType(String))
                emptyTable.Rows.Add("No data available")
                blotterTableData.DataSource = emptyTable

                blotterTableData.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                blotterTableData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                blotterTableData.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                blotterTableData.Rows(0).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Italic)

            Else
                ' Show data normally
                blotterTableData.Enabled = True
                blotterTableData.ColumnHeadersVisible = True
                blotterTableData.RowHeadersVisible = True
                blotterTableData.DataSource = table

                AdjustDataGridView()
                AddButtonsToDataGrid()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Adjust table appearance
    Private Sub AdjustDataGridView()
        blotterTableData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        blotterTableData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        For Each column As DataGridViewColumn In blotterTableData.Columns
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next

        blotterTableData.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        blotterTableData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        blotterTableData.RowTemplate.Height = 30
        blotterTableData.ColumnHeadersHeight = 40
    End Sub

    ' Add Update and Delete buttons to DataGridView
    Private Sub AddButtonsToDataGrid()
        If Not blotterTableData.Columns.Contains("UpdateButton") Then
            Dim updateButtonColumn As New DataGridViewButtonColumn()
            updateButtonColumn.Name = "UpdateButton"
            updateButtonColumn.HeaderText = "Update"
            updateButtonColumn.Text = "Already Solved"
            updateButtonColumn.UseColumnTextForButtonValue = True
            blotterTableData.Columns.Add(updateButtonColumn)
        End If

        If Not blotterTableData.Columns.Contains("DeleteButton") Then
            Dim deleteButtonColumn As New DataGridViewButtonColumn()
            deleteButtonColumn.Name = "DeleteButton"
            deleteButtonColumn.HeaderText = "Delete"
            deleteButtonColumn.Text = "Delete"
            deleteButtonColumn.UseColumnTextForButtonValue = True
            blotterTableData.Columns.Add(deleteButtonColumn)
        End If

        ' Loop through each row and handle button visibility and text based on issues_status
        For Each row As DataGridViewRow In blotterTableData.Rows
            If row.Cells("issues_status").Value IsNot Nothing Then
                Dim issuesStatus As String = row.Cells("issues_status").Value.ToString()

                ' If issues_status is "To solve", show "Already Solved" button
                If issuesStatus = "To solve" Then
                    row.Cells("UpdateButton").Value = "Already Solved"
                    row.Cells("UpdateButton").Style.BackColor = Color.LightGreen
                    row.Cells("UpdateButton").Style.ForeColor = Color.Black
                    row.Cells("UpdateButton").ReadOnly = False
                ElseIf issuesStatus = "Completed" Then
                    ' Disable the button if status is "Completed"
                    row.Cells("UpdateButton").Value = "Completed"
                    row.Cells("UpdateButton").Style.BackColor = Color.Gray
                    row.Cells("UpdateButton").Style.ForeColor = Color.White
                    row.Cells("UpdateButton").ReadOnly = True
                Else
                    ' Handle other possible statuses
                    row.Cells("UpdateButton").Value = "Already Resolved"
                    row.Cells("UpdateButton").Style.BackColor = Color.LightBlue
                    row.Cells("UpdateButton").Style.ForeColor = Color.Black
                    row.Cells("UpdateButton").ReadOnly = False
                End If
            End If
        Next
    End Sub

    ' Handle clicks for update/delete buttons
    Private Sub blotterTableData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles blotterTableData.CellContentClick
        If e.RowIndex < 0 OrElse blotterTableData.Rows(e.RowIndex).Cells("id").Value Is DBNull.Value Then Return

        Dim blotterId As Integer = Convert.ToInt32(blotterTableData.Rows(e.RowIndex).Cells("id").Value)

        If e.ColumnIndex = blotterTableData.Columns("UpdateButton").Index Then
            UpdateIssuesStatus(blotterId)
        ElseIf e.ColumnIndex = blotterTableData.Columns("DeleteButton").Index Then
            DeleteBlotter(blotterId)
        End If
    End Sub

    ' Update issue status
    Private Sub UpdateIssuesStatus(blotterId As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Update status to "Completed" in the database
            Dim query As String = "UPDATE tbl_blotter SET issues_status = 'Completed' WHERE id = @id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", blotterId)
            cmd.ExecuteNonQuery()

            LoadBlotterData()
            MessageBox.Show("Issues status updated to 'Completed'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Delete record
    Private Sub DeleteBlotter(blotterId As Integer)
        Try
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim query As String = "DELETE FROM tbl_blotter WHERE id = @id"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", blotterId)
                cmd.ExecuteNonQuery()

                LoadBlotterData()
                MessageBox.Show("Blotter record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub addBlotterLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles addBlotterLink.LinkClicked
        Dim addBlotterForm As New AddBlotter(Me)
        addBlotterForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm As New AdminLogin()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub LinkDashboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkDashboard.LinkClicked
        ' If AdminDashboard is already open, just bring it to the front
        Dim adminDashboard As New AdminDashboard()
        adminDashboard.Show()
        Me.Hide()
    End Sub

    ' Link to navigate to AdminClearance form
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim clearanceForm As New AdminClearance()
        clearanceForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub

    ' Link to navigate to AdminCedula form
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim cedulaForm As New AdminCedula()
        cedulaForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub



    ' Link to navigate to AdminBlotter form
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim blotterForm As New AdminBlotter()
        blotterForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub
End Class
