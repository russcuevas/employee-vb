Imports MySql.Data.MySqlClient

Public Class AddClearance
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)
    ' Store reference to AdminClearance
    Dim adminForm As AdminClearance

    ' Constructor that accepts AdminClearance as a parameter
    Public Sub New(adminForm As AdminClearance)
        InitializeComponent() ' Initialize the form components
        Me.adminForm = adminForm ' Store the reference of AdminClearance form
        Me.WindowState = FormWindowState.Maximized ' Set the window state to Maximized
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "INSERT INTO tbl_clearance (fullname, gender, dateofbirth, civil_status, nationality, house_number, purok, municipality, province, contact_number, email)
                                   VALUES (@fullname, @gender, @dateofbirth, @civil_status, @nationality, @house_number, @purok, @municipality, @province, @contact_number, @email)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@fullname", txtFullname.Text)
            cmd.Parameters.AddWithValue("@gender", txtGender.Text)
            cmd.Parameters.AddWithValue("@dateofbirth", txtDateOfBirth.Value.Date)
            cmd.Parameters.AddWithValue("@civil_status", txtCivilStatus.Text)
            cmd.Parameters.AddWithValue("@nationality", txtNationality.Text)
            cmd.Parameters.AddWithValue("@house_number", txtHouseNumber.Text)
            cmd.Parameters.AddWithValue("@purok", txtPurok.Text)
            cmd.Parameters.AddWithValue("@municipality", txtMunicipality.Text)
            cmd.Parameters.AddWithValue("@province", txtProvince.Text)
            cmd.Parameters.AddWithValue("@contact_number", txtMobileNumber.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)

            Dim result As Integer = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Clearance information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearFields()
            Else
                MessageBox.Show("Failed to save the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtFullname.Clear()
        txtGender.Clear()
        txtDateOfBirth.Value = Date.Today
        txtCivilStatus.Clear()
        txtNationality.Clear()
        txtHouseNumber.Clear()
        txtPurok.Clear()
        txtMunicipality.Clear()
        txtProvince.Clear()
        txtMobileNumber.Clear()
        txtEmail.Clear()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        adminForm.LoadClearanceData() ' Refresh the data in AdminCedula
        adminForm.Show()           ' Show the AdminCedula form
        Me.Close()
    End Sub
End Class
