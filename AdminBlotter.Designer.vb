<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminBlotter
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
        addBlotterLink = New LinkLabel()
        blotterTableData = New DataGridView()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        Label2 = New Label()
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        LinkDashboard = New LinkLabel()
        Timer1 = New Timer(components)
        btnLogout = New Button()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        LinkBlotter = New LinkLabel()
        LinkCedula = New LinkLabel()
        LinkClearance = New LinkLabel()
        LinkLabel3 = New LinkLabel()
        CType(blotterTableData, ComponentModel.ISupportInitialize).BeginInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' addBlotterLink
        ' 
        addBlotterLink.AutoSize = True
        addBlotterLink.BackColor = Color.Green
        addBlotterLink.BorderStyle = BorderStyle.FixedSingle
        addBlotterLink.Font = New Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point)
        addBlotterLink.LinkBehavior = LinkBehavior.HoverUnderline
        addBlotterLink.LinkColor = Color.White
        addBlotterLink.Location = New Point(412, 263)
        addBlotterLink.Name = "addBlotterLink"
        addBlotterLink.Size = New Size(313, 64)
        addBlotterLink.TabIndex = 44
        addBlotterLink.TabStop = True
        addBlotterLink.Text = "ADD DATA +"
        ' 
        ' blotterTableData
        ' 
        blotterTableData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        blotterTableData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        blotterTableData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        blotterTableData.Location = New Point(412, 367)
        blotterTableData.Name = "blotterTableData"
        blotterTableData.RowHeadersWidth = 51
        blotterTableData.RowTemplate.Height = 29
        blotterTableData.Size = New Size(1401, 549)
        blotterTableData.TabIndex = 42
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.White
        Label2.Font = New Font("Segoe UI", 36F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.Green
        Label2.Location = New Point(412, 124)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(520, 81)
        Label2.TabIndex = 43
        Label2.Text = "Barangay Blotter"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.White
        LinkLabel1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel1.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel1.LinkColor = Color.Green
        LinkLabel1.Location = New Point(24, 529)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(116, 41)
        LinkLabel1.TabIndex = 41
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Blotter"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.BackColor = Color.White
        LinkLabel2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel2.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel2.LinkColor = Color.Green
        LinkLabel2.Location = New Point(24, 451)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(115, 41)
        LinkLabel2.TabIndex = 40
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "Cedula"
        ' 
        ' LinkDashboard
        ' 
        LinkDashboard.AutoSize = True
        LinkDashboard.BackColor = Color.White
        LinkDashboard.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkDashboard.LinkBehavior = LinkBehavior.NeverUnderline
        LinkDashboard.LinkColor = Color.Green
        LinkDashboard.Location = New Point(24, 284)
        LinkDashboard.Name = "LinkDashboard"
        LinkDashboard.Size = New Size(171, 41)
        LinkDashboard.TabIndex = 35
        LinkDashboard.TabStop = True
        LinkDashboard.Text = "Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Green
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(24, 634)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(209, 58)
        btnLogout.TabIndex = 34
        btnLogout.Text = "LOGOUT"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.White
        PictureBox4.BackgroundImage = My.Resources.Resources.inosluban
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox4.Location = New Point(24, 58)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(209, 186)
        PictureBox4.TabIndex = 33
        PictureBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.seal
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Location = New Point(24, 742)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(209, 187)
        PictureBox3.TabIndex = 32
        PictureBox3.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(-5, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(261, 1500)
        PictureBox1.TabIndex = 31
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Green
        PictureBox2.Location = New Point(250, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(1800, 59)
        PictureBox2.TabIndex = 30
        PictureBox2.TabStop = False
        ' 
        ' LinkBlotter
        ' 
        LinkBlotter.AutoSize = True
        LinkBlotter.BackColor = Color.White
        LinkBlotter.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkBlotter.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBlotter.LinkColor = Color.Green
        LinkBlotter.Location = New Point(24, 539)
        LinkBlotter.Name = "LinkBlotter"
        LinkBlotter.Size = New Size(116, 41)
        LinkBlotter.TabIndex = 38
        LinkBlotter.TabStop = True
        LinkBlotter.Text = "Blotter"
        ' 
        ' LinkCedula
        ' 
        LinkCedula.AutoSize = True
        LinkCedula.BackColor = Color.White
        LinkCedula.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkCedula.LinkBehavior = LinkBehavior.NeverUnderline
        LinkCedula.LinkColor = Color.Green
        LinkCedula.Location = New Point(24, 451)
        LinkCedula.Name = "LinkCedula"
        LinkCedula.Size = New Size(115, 41)
        LinkCedula.TabIndex = 37
        LinkCedula.TabStop = True
        LinkCedula.Text = "Cedula"
        ' 
        ' LinkClearance
        ' 
        LinkClearance.AutoSize = True
        LinkClearance.BackColor = Color.White
        LinkClearance.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkClearance.LinkBehavior = LinkBehavior.NeverUnderline
        LinkClearance.LinkColor = Color.Green
        LinkClearance.Location = New Point(24, 367)
        LinkClearance.Name = "LinkClearance"
        LinkClearance.Size = New Size(154, 41)
        LinkClearance.TabIndex = 36
        LinkClearance.TabStop = True
        LinkClearance.Text = "Clearance"
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.BackColor = Color.White
        LinkLabel3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel3.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel3.LinkColor = Color.Green
        LinkLabel3.Location = New Point(24, 367)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(154, 41)
        LinkLabel3.TabIndex = 39
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "Clearance"
        ' 
        ' AdminBlotter
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.dashboard_background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1924, 953)
        Controls.Add(addBlotterLink)
        Controls.Add(blotterTableData)
        Controls.Add(Label2)
        Controls.Add(LinkLabel1)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel3)
        Controls.Add(LinkDashboard)
        Controls.Add(btnLogout)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Controls.Add(LinkBlotter)
        Controls.Add(LinkCedula)
        Controls.Add(LinkClearance)
        DoubleBuffered = True
        Name = "AdminBlotter"
        Text = "AdminBlotter"
        CType(blotterTableData, ComponentModel.ISupportInitialize).EndInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents addBlotterLink As LinkLabel
    Friend WithEvents blotterTableData As DataGridView
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkDashboard As LinkLabel
    Friend WithEvents btnLogout As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LinkBlotter As LinkLabel
    Friend WithEvents LinkCedula As LinkLabel
    Friend WithEvents LinkClearance As LinkLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LinkLabel3 As LinkLabel
End Class
