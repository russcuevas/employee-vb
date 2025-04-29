<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtEmail = New TextBox()
        Label1 = New Label()
        txtPassword = New TextBox()
        Label2 = New Label()
        loginButton = New Button()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmail.Location = New Point(833, 459)
        txtEmail.Margin = New Padding(4)
        txtEmail.Multiline = True
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(498, 62)
        txtEmail.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(606, 467)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(125, 54)
        Label1.TabIndex = 2
        Label1.Text = "Email"
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        txtPassword.Location = New Point(833, 567)
        txtPassword.Margin = New Padding(4)
        txtPassword.Multiline = True
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(498, 62)
        txtPassword.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 36F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(833, 301)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(192, 81)
        Label2.TabIndex = 6
        Label2.Text = "Login"
        ' 
        ' loginButton
        ' 
        loginButton.BackColor = Color.Green
        loginButton.FlatStyle = FlatStyle.Flat
        loginButton.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        loginButton.ForeColor = Color.White
        loginButton.Location = New Point(1045, 679)
        loginButton.Margin = New Padding(4)
        loginButton.Name = "loginButton"
        loginButton.Size = New Size(287, 81)
        loginButton.TabIndex = 9
        loginButton.Text = "LOGIN"
        loginButton.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(606, 575)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(202, 54)
        Label3.TabIndex = 10
        Label3.Text = "Password"
        ' 
        ' AdminLogin
        ' 
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.login_background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1924, 1055)
        Controls.Add(Label3)
        Controls.Add(loginButton)
        Controls.Add(Label2)
        Controls.Add(txtPassword)
        Controls.Add(Label1)
        Controls.Add(txtEmail)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Margin = New Padding(4)
        Name = "AdminLogin"
        Text = "Admin Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents loginButton As Button
    Friend WithEvents Label3 As Label
End Class
