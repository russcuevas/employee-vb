<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        Button1 = New Button()
        LinkDashboard = New LinkLabel()
        PictureBox5 = New PictureBox()
        Timer1 = New Timer(components)
        LinkClearance = New LinkLabel()
        LinkCedula = New LinkLabel()
        LinkBlotter = New LinkLabel()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Green
        PictureBox2.Location = New Point(247, -1)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(1800, 59)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(-8, -1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(261, 1500)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.seal
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Location = New Point(21, 741)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(209, 187)
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.White
        PictureBox4.BackgroundImage = My.Resources.Resources.inosluban
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox4.Location = New Point(21, 57)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(209, 186)
        PictureBox4.TabIndex = 4
        PictureBox4.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Green
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(21, 633)
        Button1.Name = "Button1"
        Button1.Size = New Size(209, 58)
        Button1.TabIndex = 8
        Button1.Text = "LOGOUT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' LinkDashboard
        ' 
        LinkDashboard.AutoSize = True
        LinkDashboard.BackColor = Color.White
        LinkDashboard.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkDashboard.LinkBehavior = LinkBehavior.NeverUnderline
        LinkDashboard.LinkColor = Color.Green
        LinkDashboard.Location = New Point(21, 282)
        LinkDashboard.Name = "LinkDashboard"
        LinkDashboard.Size = New Size(171, 41)
        LinkDashboard.TabIndex = 9
        LinkDashboard.TabStop = True
        LinkDashboard.Text = "Dashboard"
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackgroundImage = My.Resources.Resources.login_background
        PictureBox5.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox5.Location = New Point(487, 225)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(1101, 581)
        PictureBox5.TabIndex = 10
        PictureBox5.TabStop = False
        ' 
        ' LinkClearance
        ' 
        LinkClearance.AutoSize = True
        LinkClearance.BackColor = Color.White
        LinkClearance.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkClearance.LinkBehavior = LinkBehavior.NeverUnderline
        LinkClearance.LinkColor = Color.Green
        LinkClearance.Location = New Point(21, 366)
        LinkClearance.Name = "LinkClearance"
        LinkClearance.Size = New Size(154, 41)
        LinkClearance.TabIndex = 11
        LinkClearance.TabStop = True
        LinkClearance.Text = "Clearance"
        ' 
        ' LinkCedula
        ' 
        LinkCedula.AutoSize = True
        LinkCedula.BackColor = Color.White
        LinkCedula.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkCedula.LinkBehavior = LinkBehavior.NeverUnderline
        LinkCedula.LinkColor = Color.Green
        LinkCedula.Location = New Point(21, 450)
        LinkCedula.Name = "LinkCedula"
        LinkCedula.Size = New Size(115, 41)
        LinkCedula.TabIndex = 12
        LinkCedula.TabStop = True
        LinkCedula.Text = "Cedula"
        ' 
        ' LinkBlotter
        ' 
        LinkBlotter.AutoSize = True
        LinkBlotter.BackColor = Color.White
        LinkBlotter.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkBlotter.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBlotter.LinkColor = Color.Green
        LinkBlotter.Location = New Point(21, 538)
        LinkBlotter.Name = "LinkBlotter"
        LinkBlotter.Size = New Size(116, 41)
        LinkBlotter.TabIndex = 13
        LinkBlotter.TabStop = True
        LinkBlotter.Text = "Blotter"
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.dashboard_background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1924, 953)
        Controls.Add(LinkBlotter)
        Controls.Add(LinkCedula)
        Controls.Add(LinkClearance)
        Controls.Add(PictureBox5)
        Controls.Add(LinkDashboard)
        Controls.Add(Button1)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        DoubleBuffered = True
        Name = "AdminDashboard"
        Text = "Admin Dashboard"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents LinkDashboard As LinkLabel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LinkClearance As LinkLabel
    Friend WithEvents LinkCedula As LinkLabel
    Friend WithEvents LinkBlotter As LinkLabel
End Class
