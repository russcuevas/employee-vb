<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminClearance
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(AdminClearance))
        LinkDashboard = New LinkLabel()
        Button1 = New Button()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Timer1 = New Timer(components)
        LinkBlotter = New LinkLabel()
        LinkCedula = New LinkLabel()
        LinkClearance = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        LinkLabel3 = New LinkLabel()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        txtClearanceTable = New DataGridView()
        Label2 = New Label()
        addClearanceLink = New LinkLabel()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        CType(txtClearanceTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        LinkDashboard.TabIndex = 19
        LinkDashboard.TabStop = True
        LinkDashboard.Text = "Dashboard"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Green
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(21, 632)
        Button1.Name = "Button1"
        Button1.Size = New Size(209, 58)
        Button1.TabIndex = 18
        Button1.Text = "LOGOUT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.White
        PictureBox4.BackgroundImage = My.Resources.Resources.inosluban
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        PictureBox4.Location = New Point(21, 56)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(209, 186)
        PictureBox4.TabIndex = 17
        PictureBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.seal
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Location = New Point(21, 740)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(209, 187)
        PictureBox3.TabIndex = 16
        PictureBox3.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.Location = New Point(-8, -2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(261, 1500)
        PictureBox1.TabIndex = 15
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Green
        PictureBox2.Location = New Point(247, -2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(1800, 59)
        PictureBox2.TabIndex = 14
        PictureBox2.TabStop = False
        ' 
        ' LinkBlotter
        ' 
        LinkBlotter.AutoSize = True
        LinkBlotter.BackColor = Color.White
        LinkBlotter.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkBlotter.LinkBehavior = LinkBehavior.NeverUnderline
        LinkBlotter.LinkColor = Color.Green
        LinkBlotter.Location = New Point(21, 537)
        LinkBlotter.Name = "LinkBlotter"
        LinkBlotter.Size = New Size(116, 41)
        LinkBlotter.TabIndex = 23
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
        LinkCedula.Location = New Point(21, 449)
        LinkCedula.Name = "LinkCedula"
        LinkCedula.Size = New Size(115, 41)
        LinkCedula.TabIndex = 22
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
        LinkClearance.Location = New Point(21, 365)
        LinkClearance.Name = "LinkClearance"
        LinkClearance.Size = New Size(154, 41)
        LinkClearance.TabIndex = 21
        LinkClearance.TabStop = True
        LinkClearance.Text = "Clearance"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.White
        LinkLabel1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel1.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel1.LinkColor = Color.Green
        LinkLabel1.Location = New Point(21, 527)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(116, 41)
        LinkLabel1.TabIndex = 26
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
        LinkLabel2.Location = New Point(21, 449)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(115, 41)
        LinkLabel2.TabIndex = 25
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "Cedula"
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.BackColor = Color.White
        LinkLabel3.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel3.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel3.LinkColor = Color.Green
        LinkLabel3.Location = New Point(21, 365)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(154, 41)
        LinkLabel3.TabIndex = 24
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "Clearance"
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' txtClearanceTable
        ' 
        txtClearanceTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        txtClearanceTable.Location = New Point(409, 365)
        txtClearanceTable.Name = "txtClearanceTable"
        txtClearanceTable.RowHeadersWidth = 51
        txtClearanceTable.RowTemplate.Height = 29
        txtClearanceTable.Size = New Size(1401, 549)
        txtClearanceTable.TabIndex = 27
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.White
        Label2.Font = New Font("Segoe UI", 36F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.Green
        Label2.Location = New Point(409, 122)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(605, 81)
        Label2.TabIndex = 28
        Label2.Text = "Barangay Clearance"
        ' 
        ' addClearanceLink
        ' 
        addClearanceLink.AutoSize = True
        addClearanceLink.BackColor = Color.Green
        addClearanceLink.BorderStyle = BorderStyle.FixedSingle
        addClearanceLink.Font = New Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point)
        addClearanceLink.LinkBehavior = LinkBehavior.HoverUnderline
        addClearanceLink.LinkColor = Color.White
        addClearanceLink.Location = New Point(409, 261)
        addClearanceLink.Name = "addClearanceLink"
        addClearanceLink.Size = New Size(313, 64)
        addClearanceLink.TabIndex = 29
        addClearanceLink.TabStop = True
        addClearanceLink.Text = "ADD DATA +"
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' AdminClearance
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.dashboard_background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1924, 953)
        Controls.Add(addClearanceLink)
        Controls.Add(Label2)
        Controls.Add(txtClearanceTable)
        Controls.Add(LinkLabel1)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel3)
        Controls.Add(LinkDashboard)
        Controls.Add(Button1)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox2)
        Controls.Add(LinkBlotter)
        Controls.Add(LinkCedula)
        Controls.Add(LinkClearance)
        DoubleBuffered = True
        Name = "AdminClearance"
        Text = "AdminClearance"
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        CType(txtClearanceTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents LinkDashboard As LinkLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LinkBlotter As LinkLabel
    Friend WithEvents LinkCedula As LinkLabel
    Friend WithEvents LinkClearance As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents txtClearanceTable As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents addClearanceLink As LinkLabel
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
End Class
