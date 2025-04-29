Imports MySql.Data.MySqlClient

Public Class AddCedula
    ' Constructor to accept reference to AdminCedula
    Dim adminCedulaForm As AdminCedula

    ' Constructor to pass reference of AdminCedula
    Public Sub New(adminForm As AdminCedula)
        InitializeComponent() ' Initialize the form components
        adminCedulaForm = adminForm ' Store the reference of AdminCedula form
    End Sub

    ' Form Load event
    Private Sub AddCedula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Generate random Cedula number
        GenerateRandomCedulaNumber()

        ' Set the form to maximize when it is opened
        Me.WindowState = FormWindowState.Maximized

        ' Make tax fields readonly
        txtBasicTax.Text = "5.00"
        txtBasicTax.ReadOnly = True
        txtTotalBox.ReadOnly = True
        txtInterestBox.ReadOnly = True
    End Sub

    ' Function to generate and set a new random Cedula number
    Private Sub GenerateRandomCedulaNumber()
        Dim rng As New Random()
        Dim randomNumber As String = rng.Next(100000000, 999999999).ToString()
        txtCedulaNumber.Text = randomNumber
        txtCedulaNumber.ReadOnly = True
    End Sub

    ' Automatically calculate total tax and interest
    Private Sub CalculateTax()
        Dim gross As Decimal = 0D
        Dim salary As Decimal = 0D
        Dim real As Decimal = 0D
        Dim basic As Decimal = 5D

        ' Validate each textbox and default to 0 if empty or invalid
        If Not Decimal.TryParse(txtGrossReceipt.Text, gross) Then
            gross = 0D
        End If

        If Not Decimal.TryParse(txtSalaries.Text, salary) Then
            salary = 0D
        End If

        If Not Decimal.TryParse(txtRealProperty.Text, real) Then
            real = 0D
        End If

        ' Calculate taxes
        Dim additionalTax As Decimal = gross + salary + real
        Dim interest As Decimal = additionalTax * 0.02D
        Dim total As Decimal = basic + additionalTax + interest

        ' Update UI
        txtBasicTax.Text = basic.ToString("F2")
        txtInterestBox.Text = interest.ToString("F2")
        txtTotalBox.Text = total.ToString("F2")
    End Sub

    ' Trigger calculation when user types income
    Private Sub txtGrossReceipt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossReceipt.TextChanged
        CalculateTax()
    End Sub

    Private Sub txtSalaries_TextChanged(sender As Object, e As EventArgs) Handles txtSalaries.TextChanged
        CalculateTax()
    End Sub

    Private Sub txtRealProperty_TextChanged(sender As Object, e As EventArgs) Handles txtRealProperty.TextChanged
        CalculateTax()
    End Sub

    ' Save to database
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"

        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()

                Dim sql As String = "INSERT INTO tbl_cedula (
                    fullname, age, gender, dateofbirth, address, civil_status, 
                    citizenship, place_issue, weight, height, tin, issued_date, 
                    cedula_number, gross_receipt, salaries, real_property, 
                    basic_tax, total_tax, interest
                ) VALUES (
                    @fullname, @age, @gender, @dob, @address, @civilstatus,
                    @citizenship, @placeissue, @weight, @height, @tin, @issueddate,
                    @cedulanumber, @gross, @salaries, @real, 
                    @basic, @total, @interest
                )"

                Using cmd As New MySqlCommand(sql, conn)
                    ' Parameters from TextBoxes
                    cmd.Parameters.AddWithValue("@fullname", txtFullname.Text)
                    cmd.Parameters.AddWithValue("@age", Val(txtAge.Text))
                    cmd.Parameters.AddWithValue("@gender", txtGender.Text)
                    cmd.Parameters.AddWithValue("@dob", Date.Parse(txtDateOfBirth.Text))
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@civilstatus", txtCivilStatus.Text)
                    cmd.Parameters.AddWithValue("@citizenship", txtNationality.Text)
                    cmd.Parameters.AddWithValue("@placeissue", txtPlaceIssue.Text)
                    cmd.Parameters.AddWithValue("@weight", Val(txtWeight.Text))
                    cmd.Parameters.AddWithValue("@height", Val(txtHeight.Text))
                    cmd.Parameters.AddWithValue("@tin", txtTin.Text)
                    cmd.Parameters.AddWithValue("@issueddate", Date.Now.Date)
                    cmd.Parameters.AddWithValue("@cedulanumber", txtCedulaNumber.Text)
                    cmd.Parameters.AddWithValue("@gross", Val(txtGrossReceipt.Text))
                    cmd.Parameters.AddWithValue("@salaries", Val(txtSalaries.Text))
                    cmd.Parameters.AddWithValue("@real", Val(txtRealProperty.Text))
                    cmd.Parameters.AddWithValue("@basic", Val(txtBasicTax.Text))
                    cmd.Parameters.AddWithValue("@total", Val(txtTotalBox.Text))
                    cmd.Parameters.AddWithValue("@interest", Val(txtInterestBox.Text))

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Cedula record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Clear the form after successful save
                    ClearForm()

                    ' Generate new random Cedula number for the next entry
                    GenerateRandomCedulaNumber()

                End Using

            Catch ex As Exception
                MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Function to clear the form
    Private Sub ClearForm()
        txtFullname.Clear()
        txtAge.Clear()
        txtGender.Clear()
        txtDateOfBirth.Value = Date.Today
        txtAddress.Clear()
        txtCivilStatus.Clear()
        txtNationality.Clear()
        txtPlaceIssue.Clear()
        txtWeight.Clear()
        txtHeight.Clear()
        txtTin.Clear()
        txtGrossReceipt.Clear()
        txtSalaries.Clear()
        txtRealProperty.Clear()
        txtInterestBox.Clear()
        txtTotalBox.Clear()

        ' Reset tax fields
        txtBasicTax.Text = "5.00"
        txtInterestBox.Text = "0.00"
        txtTotalBox.Text = "0.00"
    End Sub

    ' Go back to AdminCedula form
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        adminCedulaForm.LoadCedulaData() ' Refresh the data in AdminCedula
        adminCedulaForm.Show()           ' Show the AdminCedula form
        Me.Close()                       ' Close the AddCedula form
    End Sub
End Class
