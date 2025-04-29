Imports MySql.Data.MySqlClient

Public Class AdminLogin
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)

    Private Sub AdminLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        ' Get the entered email and password
        Dim enteredEmail As String = txtEmail.Text
        Dim enteredPassword As String = txtPassword.Text

        ' Check if the fields are not empty
        If String.IsNullOrEmpty(enteredEmail) Or String.IsNullOrEmpty(enteredPassword) Then
            MessageBox.Show("Please enter both email and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Prepare query to check for the email and password
            Dim query As String = "SELECT * FROM tbl_admin WHERE email = @email AND password = @password"
            Dim cmd As New MySqlCommand(query, conn)

            ' Add parameters to prevent SQL injection
            cmd.Parameters.AddWithValue("@email", enteredEmail)
            cmd.Parameters.AddWithValue("@password", enteredPassword)

            ' Execute query and check if the user exists
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                ' Login success
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Open the Admin Dashboard form or another form
                Dim adminDashboard As New AdminDashboard() ' Assuming you have this form
                adminDashboard.Show()
                Me.Hide() ' Hide the login form
            Else
                ' Login failed
                MessageBox.Show("Invalid email or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Optional: You can implement some validation for password visibility
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        ' Optional password validation or visibility logic
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        ' Optional email validation logic
    End Sub
End Class
