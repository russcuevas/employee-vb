Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class AdminClearance
    ' Connection string to MySQL
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)

    ' Declare printRowData at the class level
    Dim printRowData As DataGridViewRow ' This holds the selected row for printing

    ' Form Load event
    Private Sub AdminClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LoadClearanceData()
    End Sub

    ' Load data from the database
    Public Sub LoadClearanceData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT id, fullname, gender, dateofbirth, civil_status, nationality, house_number, purok, municipality, province, contact_number, email FROM tbl_clearance"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            txtClearanceTable.Columns.Clear()
            txtClearanceTable.AllowUserToAddRows = False
            txtClearanceTable.AllowUserToDeleteRows = False
            txtClearanceTable.ReadOnly = True

            If table.Rows.Count = 0 Then
                ' Show "No data available" message
                txtClearanceTable.DataSource = Nothing
                txtClearanceTable.Enabled = False
                txtClearanceTable.ColumnHeadersVisible = False
                txtClearanceTable.RowHeadersVisible = False

                Dim emptyTable As New DataTable()
                emptyTable.Columns.Add("Message", GetType(String))
                emptyTable.Rows.Add("No data available")
                txtClearanceTable.DataSource = emptyTable

                txtClearanceTable.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                txtClearanceTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                txtClearanceTable.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                txtClearanceTable.Rows(0).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Italic)

            Else
                ' Load actual data
                txtClearanceTable.DataSource = table
                txtClearanceTable.Enabled = True
                txtClearanceTable.ColumnHeadersVisible = True
                txtClearanceTable.RowHeadersVisible = True

                ' Add Delete Button Column
                If Not txtClearanceTable.Columns.Contains("DeleteButton") Then
                    Dim deleteButtonColumn As New DataGridViewButtonColumn()
                    deleteButtonColumn.Name = "DeleteButton"
                    deleteButtonColumn.HeaderText = "Delete"
                    deleteButtonColumn.Text = "Delete"
                    deleteButtonColumn.UseColumnTextForButtonValue = True
                    txtClearanceTable.Columns.Add(deleteButtonColumn)
                End If

                ' Add Print Button Column
                If Not txtClearanceTable.Columns.Contains("PrintButton") Then
                    Dim printButtonColumn As New DataGridViewButtonColumn()
                    printButtonColumn.Name = "PrintButton"
                    printButtonColumn.HeaderText = "Print"
                    printButtonColumn.Text = "Print Clearance"
                    printButtonColumn.UseColumnTextForButtonValue = True
                    txtClearanceTable.Columns.Add(printButtonColumn)
                End If

                AdjustDataGridView()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    ' Adjust table appearance
    Private Sub AdjustDataGridView()
        txtClearanceTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        txtClearanceTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        For Each column As DataGridViewColumn In txtClearanceTable.Columns
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next

        txtClearanceTable.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        txtClearanceTable.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txtClearanceTable.RowTemplate.Height = 30
        txtClearanceTable.ColumnHeadersHeight = 40
    End Sub

    ' Handle cell content clicks (optional for future functionality)
    Private Sub txtClearanceTable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles txtClearanceTable.CellContentClick
        If e.RowIndex < 0 Then Return ' Ignore header clicks

        ' Get the selected row
        Dim selectedRow As DataGridViewRow = txtClearanceTable.Rows(e.RowIndex)

        ' Check if the clicked cell is the "Delete" button
        If txtClearanceTable.Columns(e.ColumnIndex).Name = "DeleteButton" Then
            Dim clearanceId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)
            DeleteClearanceRecord(clearanceId)
        End If

        ' Check if the clicked cell is the "Print" button
        If txtClearanceTable.Columns(e.ColumnIndex).Name = "PrintButton" Then
            printRowData = selectedRow
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    ' Delete record function
    Private Sub DeleteClearanceRecord(clearanceId As Integer)
        Try
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim query As String = "DELETE FROM tbl_clearance WHERE id = @id"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", clearanceId)
                cmd.ExecuteNonQuery()

                ' Reload the data after deletion
                LoadClearanceData()

                MessageBox.Show("Clearance record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Handle the printing of the selected row data
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If printRowData Is Nothing Then Return ' No data to print

        ' Basic setup
        Dim g As Graphics = e.Graphics
        Dim pageWidth As Integer = e.PageBounds.Width
        Dim pageHeight As Integer = e.PageBounds.Height
        Dim marginLeft As Integer = 50
        Dim marginTop As Integer = 50
        Dim contentWidth As Integer = pageWidth - (marginLeft * 2)

        ' Fonts
        Dim headerFont As New Font("Cambria", 16, FontStyle.Bold)
        Dim titleFont As New Font("Cambria", 26, FontStyle.Bold)
        Dim subtitleFont As New Font("Cambria", 20, FontStyle.Bold)
        Dim contentFont As New Font("Calibri", 12)
        Dim footerFont As New Font("Calibri", 10)

        ' Colors
        Dim primaryColor As Color = Color.FromArgb(0, 63, 114)
        Dim accentColor As Color = Color.FromArgb(192, 0, 0)
        Dim borderColor As Color = Color.FromArgb(218, 165, 32)

        ' Page Border
        Dim borderPen As New Pen(borderColor, 2)
        Dim borderRect As New Rectangle(marginLeft - 20, marginTop - 20, pageWidth - (marginLeft * 2) + 40, pageHeight - (marginLeft * 2) - 50)
        g.DrawRectangle(borderPen, borderRect)

        ' Inner Gradient
        Using borderBrush As New LinearGradientBrush(New Point(marginLeft - 10, marginTop - 10),
                                                 New Point(pageWidth - marginLeft + 10, pageHeight - marginLeft + 10),
                                                 Color.FromArgb(245, 245, 220), Color.White)
            g.FillRectangle(borderBrush, New Rectangle(marginLeft - 10, marginTop - 10, pageWidth - (marginLeft * 2) + 20, pageHeight - (marginLeft * 2) - 60))
        End Using

        ' Logo from resources
        Try
            Dim logo As Image = My.Resources.inosluban ' Access image from Resources
            g.DrawImage(logo, marginLeft, marginTop, 100, 100)
        Catch ex As Exception
            ' Handle error or missing logo gracefully
            Using placeholderBrush As New SolidBrush(Color.LightGray)
                g.FillEllipse(placeholderBrush, marginLeft, marginTop, 100, 100)
                g.DrawString("Logo", New Font("Arial", 12), Brushes.Gray, marginLeft + 30, marginTop + 40)
            End Using
        End Try

        marginTop += 10
        Dim centerX As Integer = pageWidth / 2

        ' Header Titles
        Using headerBrush As New SolidBrush(primaryColor)
            Dim textSize As SizeF
            textSize = g.MeasureString("Republic of the Philippines", headerFont)
            g.DrawString("Republic of the Philippines", headerFont, headerBrush, centerX - (textSize.Width / 2), marginTop)
            marginTop += 30

            textSize = g.MeasureString("Province of Batangas", headerFont)
            g.DrawString("Province of Batangas", headerFont, headerBrush, centerX - (textSize.Width / 2), marginTop)
            marginTop += 30

            textSize = g.MeasureString("Municipality of Lipa City", headerFont)
            g.DrawString("Municipality of Lipa City", headerFont, headerBrush, centerX - (textSize.Width / 2), marginTop)
            marginTop += 30

            textSize = g.MeasureString("Barangay Inosluban", titleFont)
            g.DrawString("Barangay Inosluban", titleFont, New SolidBrush(Color.FromArgb(60, 0, 0, 0)), centerX - (textSize.Width / 2) + 2, marginTop + 2)
            g.DrawString("Barangay Inosluban", titleFont, New SolidBrush(accentColor), centerX - (textSize.Width / 2), marginTop)
        End Using

        marginTop += 40

        ' Decorative line
        Dim linePen As New Pen(New LinearGradientBrush(New Point(marginLeft, marginTop),
                                                New Point(pageWidth - marginLeft, marginTop),
                                                Color.White, borderColor), 3)
        g.DrawLine(linePen, marginLeft, marginTop, pageWidth - marginLeft, marginTop)
        marginTop += 40

        ' Office and Clearance Title
        Using titleBrush As New SolidBrush(primaryColor)
            Dim textSize As SizeF = g.MeasureString("OFFICE OF THE BARANGAY CAPTAIN", subtitleFont)
            g.DrawString("OFFICE OF THE BARANGAY CAPTAIN", subtitleFont, titleBrush, centerX - (textSize.Width / 2), marginTop)
            marginTop += 40

            textSize = g.MeasureString("BARANGAY CLEARANCE", titleFont)
            g.DrawString("BARANGAY CLEARANCE", titleFont, titleBrush, centerX - (textSize.Width / 2), marginTop)
        End Using

        marginTop += 60

        ' TO WHOM IT MAY CONCERN
        Using brush As New SolidBrush(primaryColor)
            g.DrawString("TO WHOM IT MAY CONCERN:", headerFont, brush, marginLeft, marginTop)
            g.DrawLine(New Pen(primaryColor, 1), marginLeft, marginTop + headerFont.Height + 2,
               marginLeft + g.MeasureString("TO WHOM IT MAY CONCERN:", headerFont).Width, marginTop + headerFont.Height + 2)
        End Using

        marginTop += 40

        ' Extract values from printRowData
        Dim issueDate As String = DateTime.Now.ToString("MMMM dd, yyyy")
        Dim fullName = If(printRowData.Cells("fullname").Value?.ToString(), "_______________________________")
        Dim gender = If(printRowData.Cells("gender").Value?.ToString(), "_________")
        Dim dob = If(printRowData.Cells("dateofbirth").Value?.ToString(), "")
        Dim civilStatus = If(printRowData.Cells("civil_status").Value?.ToString(), "_________")
        Dim nationality = If(printRowData.Cells("nationality").Value?.ToString(), "_________")
        Dim houseNumber = If(printRowData.Cells("house_number").Value?.ToString(), "")
        Dim purok = If(printRowData.Cells("purok").Value?.ToString(), "")
        Dim municipality = If(printRowData.Cells("municipality").Value?.ToString(), "")
        Dim province = If(printRowData.Cells("province").Value?.ToString(), "")

        ' Compute Age
        Dim age As String = "_________"
        If Date.TryParse(dob, Nothing) Then
            Dim birthDate As Date = Date.Parse(dob)
            age = (Date.Today.Year - birthDate.Year).ToString()
            If birthDate > Date.Today.AddYears(-Integer.Parse(age)) Then age = (Integer.Parse(age) - 1).ToString()
        End If

        ' Body Text
        Dim bodyText As String =
            $"This is to certify that {fullName}, {gender}, and a resident of Barangay Inosluban, Lipa City,{vbCrLf}" &
            $"Batangas, is known to be of good moral character and a law-abiding citizen{vbCrLf}" &
            $"in the community. To certify further, that he/she has no derogatory and/or criminal records{vbCrLf}" &
            $"filed in this barangay."


        marginTop = DrawJustifiedText(e.Graphics, bodyText, contentFont, Brushes.Black, marginLeft, marginTop, contentWidth - 40)


        marginTop += 80
        marginTop += 80

        ' Signature and Seal
        DrawWatermark(g, "Official Seal", centerX - 170, marginTop - 40)

        Using signatureBrush As New SolidBrush(primaryColor)
            g.DrawLine(New Pen(Color.Black, 1), centerX + 30, marginTop + 20, centerX + 230, marginTop + 20)
            g.DrawString("JUAN DELA CRUZ", New Font("Cambria", 12, FontStyle.Bold), signatureBrush, centerX + 70, marginTop + 25)
            g.DrawString("Barangay Captain", contentFont, signatureBrush, centerX + 70, marginTop + 45)
        End Using

        ' Validity Note
        marginTop += 90
        Using noticeBrush As New SolidBrush(Color.FromArgb(120, 0, 0, 0))
            Dim noticeText As String = "This clearance is valid for three (3) months from the date of issuance."
            Dim noticeSize As SizeF = g.MeasureString(noticeText, footerFont)
            g.DrawString(noticeText, footerFont, noticeBrush, centerX - (noticeSize.Width / 2), marginTop)
        End Using

        ' QR Code Placeholder
        DrawQRCodePlaceholder(g, marginLeft + 20, marginTop - 30)

        ' Document Control Number
        marginTop += 20
        Using controlBrush As New SolidBrush(Color.FromArgb(80, 0, 0, 0))
            Dim controlText As String = "Document Control No.: " & DateTime.Now.ToString("yyyyMMdd") & "-" & New Random().Next(1000, 9999)
            Dim controlSize As SizeF = g.MeasureString(controlText, New Font("Calibri", 8))
            g.DrawString(controlText, New Font("Calibri", 8), controlBrush, centerX - (controlSize.Width / 2), marginTop)
        End Using

        e.HasMorePages = False
    End Sub


    ' Function to draw justified text in a page with improved spacing
    Private Function DrawJustifiedText(g As Graphics, text As String, font As Font, brush As Brush, x As Integer, y As Integer, width As Integer) As Integer
        Dim words() As String = text.Split(" "c)
        Dim line As String = ""
        Dim lineHeight As Integer = font.Height + 8 ' Increased line spacing for better readability
        Dim spaceWidth As Integer = CInt(g.MeasureString(" ", font).Width)

        For Each word As String In words
            Dim testLine As String = If(line = "", word, line & " " & word)
            Dim testLineWidth As Integer = CInt(g.MeasureString(testLine, font).Width)

            If testLineWidth > width Then
                Dim extraSpace As Integer = width - CInt(g.MeasureString(line, font).Width)
                Dim gaps As Integer = line.Split(" "c).Length - 1
                Dim extraSpacePerGap As Integer = If(gaps > 0, extraSpace \ gaps, 0)
                Dim currentX As Integer = x

                For Each segment As String In line.Split(" "c)
                    g.DrawString(segment, font, brush, currentX, y)
                    currentX += CInt(g.MeasureString(segment, font).Width) + spaceWidth + extraSpacePerGap
                Next

                line = word
                y += lineHeight
            Else
                line = testLine
            End If
        Next

        ' Draw the last line left-aligned
        g.DrawString(line, font, brush, x, y)
        Return y + lineHeight
    End Function

    ' Helper function to draw watermark/seal placeholder
    Private Sub DrawWatermark(g As Graphics, text As String, x As Integer, y As Integer)
        Using watermarkBrush As New SolidBrush(Color.FromArgb(30, 0, 0, 150))
            Using watermarkPen As New Pen(Color.FromArgb(50, 0, 0, 150), 2)
                ' Draw circles for seal effect
                g.DrawEllipse(watermarkPen, x, y, 100, 100)
                g.DrawEllipse(watermarkPen, x + 10, y + 10, 80, 80)

                ' Draw placeholder text
                Using font As New Font("Arial", 10, FontStyle.Italic)
                    Dim textSize As SizeF = g.MeasureString(text, font)
                    g.DrawString(text, font, watermarkBrush, x + 50 - (textSize.Width / 2), y + 50 - (textSize.Height / 2))
                End Using
            End Using
        End Using
    End Sub

    ' Helper function to draw QR code placeholder
    Private Sub DrawQRCodePlaceholder(g As Graphics, x As Integer, y As Integer)
        Dim qrSize As Integer = 60
        Using qrBrush As New SolidBrush(Color.FromArgb(40, 0, 0, 0))
            g.FillRectangle(qrBrush, x, y, qrSize, qrSize)

            ' Draw pattern to suggest QR code
            Using whiteBrush As New SolidBrush(Color.FromArgb(40, 255, 255, 255))
                Dim cellSize As Integer = qrSize / 5
                For i As Integer = 0 To 4
                    For j As Integer = 0 To 4
                        If (i + j) Mod 2 = 0 Then
                            g.FillRectangle(whiteBrush, x + (i * cellSize), y + (j * cellSize), cellSize, cellSize)
                        End If
                    Next
                Next
            End Using

            ' Add label
            Using font As New Font("Arial", 7)
                g.DrawString("Scan to verify", font, qrBrush, x, y + qrSize + 5)
            End Using
        End Using
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load
        ' Set the dialog title
        PrintPreviewDialog1.Text = "Barangay Clearance Preview"

        ' Set the dialog icon if available
        ' PrintPreviewDialog1.Icon = My.Resources.PrintIcon

        ' Maximize the preview dialog
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub addClearanceLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles addClearanceLink.LinkClicked
        Dim addClearanceForm As New AddClearance(Me) ' Pass reference to AdminClearance
        addClearanceForm.Show()
        Me.Hide() ' Hide the AdminClearance form
    End Sub

End Class
