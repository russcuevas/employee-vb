Imports MySql.Data.MySqlClient

Public Class AddBlotter

    ' Set the connection string to your MySQL database
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)

    ' Declare a reference to the parent AdminBlotter form, use Shadows to avoid naming conflict
    Private Shadows parentForm As AdminBlotter

    ' Constructor to receive the AdminBlotter form instance
    Public Sub New(parent As AdminBlotter)
        InitializeComponent()
        parentForm = parent
    End Sub

    ' This is the form's Load event
    Private Sub AddBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form to maximize when it is opened
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' Handles the Save button click event
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Check if any required field is empty
        If String.IsNullOrEmpty(txtFullname.Text) Or
       String.IsNullOrEmpty(txtAddress.Text) Or
       String.IsNullOrEmpty(txtGender.Text) Or
       txtDateOfBirth.Value = Date.Today Or
       String.IsNullOrEmpty(txtMobileNumber.Text) Or
       String.IsNullOrEmpty(txtComplaintFullname.Text) Or
       String.IsNullOrEmpty(txtComplaintGender.Text) Or
       String.IsNullOrEmpty(txtComplaintAddress.Text) Or
       String.IsNullOrEmpty(txtAddressIssue.Text) Then

            ' Show error message if any field is empty
            MessageBox.Show("Please fill in all the fields before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Exit the method to prevent saving

        End If

        ' Proceed with saving if all fields are filled
        Try
            conn.Open()

            Dim query As String = "INSERT INTO tbl_blotter 
            (fullname, address, gender, dateofbirth, contact, complaint_fullname, complaint_gender, complaint_address, address_issues, issues_status) 
            VALUES 
            (@fullname, @address, @gender, @dob, @contact, @cfullname, @cgender, @caddress, @issues, @status)"

            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@fullname", txtFullname.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@gender", txtGender.Text)
            cmd.Parameters.AddWithValue("@dob", txtDateOfBirth.Value.Date)
            cmd.Parameters.AddWithValue("@contact", txtMobileNumber.Text)
            cmd.Parameters.AddWithValue("@cfullname", txtComplaintFullname.Text)
            cmd.Parameters.AddWithValue("@cgender", txtComplaintGender.Text)
            cmd.Parameters.AddWithValue("@caddress", txtComplaintAddress.Text)
            cmd.Parameters.AddWithValue("@issues", txtAddressIssue.Text)
            cmd.Parameters.AddWithValue("@status", "To solve")

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Blotter record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the form fields
            ClearFormFields()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    ' Method to clear all fields in the form
    Private Sub ClearFormFields()
        txtFullname.Clear()
        txtAddress.Clear()
        txtGender.Clear()
        txtDateOfBirth.Value = Date.Today
        txtMobileNumber.Clear()
        txtComplaintFullname.Clear()
        txtComplaintGender.Clear()
        txtComplaintAddress.Clear()
        txtAddressIssue.Clear()
    End Sub

    ' Handles the Back button click event (closes AddBlotter and opens AdminBlotter)
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()

        parentForm.LoadBlotterData()
        parentForm.Show()
    End Sub

End Class
