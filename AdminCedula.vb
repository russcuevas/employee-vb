Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class AdminCedula
    Dim connStr As String = "server=localhost;userid=root;password=;database=barangaysystem"
    Dim conn As New MySqlConnection(connStr)
    Dim printRowData As DataGridViewRow ' For printing

    Private Sub AdminCedula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LoadCedulaData()
    End Sub

    Public Sub LoadCedulaData()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT id, cedula_number, fullname, address, gender, dateofbirth, gross_receipt, salaries, real_property, basic_tax, total_tax, interest FROM tbl_cedula"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            txtCedulaTable.Columns.Clear()
            txtCedulaTable.AllowUserToAddRows = False
            txtCedulaTable.ReadOnly = True
            txtCedulaTable.DataSource = table

            ' Set custom column headers
            With txtCedulaTable
                .Columns("cedula_number").HeaderText = "Cedula Number"
                .Columns("fullname").HeaderText = "Fullname"
                .Columns("address").HeaderText = "Address"
                .Columns("gender").HeaderText = "Gender"
                .Columns("dateofbirth").HeaderText = "Date of Birth"
                .Columns("gross_receipt").HeaderText = "Gross Receipt"
                .Columns("salaries").HeaderText = "Salaries"
                .Columns("real_property").HeaderText = "Real Property"
                .Columns("basic_tax").HeaderText = "Basic Tax"
                .Columns("total_tax").HeaderText = "Total Tax"
                .Columns("interest").HeaderText = "Interest"
            End With


            If table.Rows.Count = 0 Then
                ' Show "No data available" message
                txtCedulaTable.DataSource = Nothing
                txtCedulaTable.Enabled = False
                txtCedulaTable.ColumnHeadersVisible = False
                txtCedulaTable.RowHeadersVisible = False

                Dim emptyTable As New DataTable()
                emptyTable.Columns.Add("Message", GetType(String))
                emptyTable.Rows.Add("No data available")
                txtCedulaTable.DataSource = emptyTable

                txtCedulaTable.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                txtCedulaTable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                txtCedulaTable.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                txtCedulaTable.Rows(0).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Italic)

            Else
                ' Load actual data
                txtCedulaTable.DataSource = table
                txtCedulaTable.Enabled = True
                txtCedulaTable.ColumnHeadersVisible = True
                txtCedulaTable.RowHeadersVisible = True

                ' Add print button
                Dim printButton As New DataGridViewButtonColumn()
                printButton.Name = "PrintButton"
                printButton.HeaderText = "Print"
                printButton.Text = "Print Cedula"
                printButton.UseColumnTextForButtonValue = True
                txtCedulaTable.Columns.Add(printButton)

                ' Add delete button
                Dim deleteButton As New DataGridViewButtonColumn()
                deleteButton.Name = "DeleteButton"
                deleteButton.HeaderText = "Delete"
                deleteButton.Text = "Delete"
                deleteButton.UseColumnTextForButtonValue = True
                txtCedulaTable.Columns.Add(deleteButton)

                AdjustDataGridView()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub AdjustDataGridView()
        txtCedulaTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        txtCedulaTable.RowTemplate.Height = 30
        txtCedulaTable.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
    End Sub

    Private Sub txtCedulaTable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles txtCedulaTable.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim selectedRow = txtCedulaTable.Rows(e.RowIndex)
        Dim cedulaId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

        If txtCedulaTable.Columns(e.ColumnIndex).Name = "DeleteButton" Then
            DeleteCedula(cedulaId)
        ElseIf txtCedulaTable.Columns(e.ColumnIndex).Name = "PrintButton" Then
            printRowData = selectedRow
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub DeleteCedula(cedulaId As Integer)
        Try
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim query As String = "DELETE FROM tbl_cedula WHERE id = @id"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", cedulaId)
                cmd.ExecuteNonQuery()

                LoadCedulaData()
                MessageBox.Show("Cedula record deleted successfully.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub addCedulaLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles addCedulaLink.LinkClicked
        Dim addCedulaForm As New AddCedula(Me)
        addCedulaForm.Show()
        Me.Hide()
    End Sub

    ' PrintDocument PrintPage event
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If printRowData Is Nothing Then Return

        Dim g As Graphics = e.Graphics
        Dim pageWidth As Integer = e.PageBounds.Width
        Dim pageHeight As Integer = e.PageBounds.Height
        Dim marginLeft As Integer = 50
        Dim marginRight As Integer = pageWidth - 50
        Dim width As Integer = marginRight - marginLeft

        ' Get current date for issue date
        Dim currentDate As DateTime = DateTime.Now
        Dim expirationDate As DateTime = New DateTime(currentDate.Year, 12, 31)

        ' Draw the background with border
        DrawCedulaBackground(g, marginLeft, 50, width, pageHeight - 100)

        ' Draw header
        Dim y As Integer = 80


        ' Draw title and subtitles
        DrawCedulaHeader(g, marginLeft, y, width)
        y += 140

        ' Draw Serial Number with border
        DrawSerialNumber(g, printRowData.Cells("cedula_number").Value.ToString(), marginLeft + 20, y, width - 40)
        y += 50

        ' Draw personal information section
        DrawPersonalInfo(g, printRowData, marginLeft + 20, y, width - 40)
        y += 220

        ' Draw financial information in a table format
        DrawFinancialInfo(g, printRowData, marginLeft + 20, y, width - 40)
        y += 180

        ' Draw validation elements (QR code, stamps, signatures, etc.)
        DrawValidationElements(g, printRowData, marginLeft + 20, y, width - 40, currentDate, expirationDate)
    End Sub

    Private Sub DrawCedulaBackground(g As Graphics, x As Integer, y As Integer, width As Integer, height As Integer)
        ' Draw a pale yellow background for the entire document
        Using bgBrush As New SolidBrush(Color.FromArgb(255, 252, 242, 204))
            g.FillRectangle(bgBrush, x, y, width, height)
        End Using

        ' Draw border with double line
        Using borderPen As New Pen(Color.FromArgb(255, 169, 106, 10), 2)
            g.DrawRectangle(borderPen, x, y, width, height)
        End Using

        Using innerBorderPen As New Pen(Color.FromArgb(255, 169, 106, 10), 1)
            g.DrawRectangle(innerBorderPen, x + 5, y + 5, width - 10, height - 10)
        End Using

        ' Draw watermark in the center
        DrawWatermark(g, x, y, width, height)
    End Sub

    Private Sub DrawWatermark(g As Graphics, x As Integer, y As Integer, width As Integer, height As Integer)
        ' Draw a faded Philippine coat of arms as watermark
        Using watermarkFont As New Font("Arial", 100, FontStyle.Bold)
            Using watermarkBrush As New SolidBrush(Color.FromArgb(20, 169, 106, 10))
                g.TranslateTransform(x + width / 2, y + height / 2)
                g.RotateTransform(-30)
                Dim stringSize As SizeF = g.MeasureString("RP", watermarkFont)
                g.DrawString("RP", watermarkFont, watermarkBrush, -stringSize.Width / 2, -stringSize.Height / 2)
                g.ResetTransform()
            End Using
        End Using

        ' Draw security patterns
        DrawSecurityPattern(g, x + 10, y + 10, width - 20, height - 20)
    End Sub

    Private Sub DrawSecurityPattern(g As Graphics, x As Integer, y As Integer, width As Integer, height As Integer)
        ' Draw security guilloche pattern
        Using securityPen As New Pen(Color.FromArgb(15, 10, 60, 120), 0.5F)
            Dim centerX As Integer = x + width / 2
            Dim centerY As Integer = y + height / 2

            For i As Integer = 0 To 360 Step 5
                For r As Integer = 50 To 250 Step 10
                    Dim angle As Double = i * Math.PI / 180
                    Dim x1 As Single = centerX + r * Math.Cos(angle)
                    Dim y1 As Single = centerY + r * Math.Sin(angle)
                    Dim x2 As Single = centerX + r * Math.Cos(angle + Math.PI)
                    Dim y2 As Single = centerY + r * Math.Sin(angle + Math.PI)

                    If x1 >= x AndAlso x1 <= x + width AndAlso y1 >= y AndAlso y1 <= y + height AndAlso
                       x2 >= x AndAlso x2 <= x + width AndAlso y2 >= y AndAlso y2 <= y + height Then
                        g.DrawLine(securityPen, x1, y1, x2, y2)
                    End If
                Next
            Next
        End Using
    End Sub

    Private Sub DrawCedulaHeader(g As Graphics, x As Integer, y As Integer, width As Integer)
        ' Draw main title
        Using titleFont As New Font("Times New Roman", 20, FontStyle.Bold)
            Using titleBrush As New SolidBrush(Color.FromArgb(255, 128, 0, 0))
                Dim title As String = "COMMUNITY TAX CERTIFICATE"
                Dim titleSize As SizeF = g.MeasureString(title, titleFont)
                g.DrawString(title, titleFont, titleBrush, x + (width / 2) - (titleSize.Width / 2), y + 10)
            End Using
        End Using

        ' Draw subtitle
        Using subtitleFont As New Font("Arial", 14, FontStyle.Bold)
            Using subtitleBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 128))
                Dim subtitle As String = "CEDULA"
                Dim subtitleSize As SizeF = g.MeasureString(subtitle, subtitleFont)
                g.DrawString(subtitle, subtitleFont, subtitleBrush, x + (width / 2) - (subtitleSize.Width / 2), y + 40)
            End Using
        End Using

        ' Draw Republic of the Philippines header
        Using headerFont As New Font("Arial", 12, FontStyle.Bold)
            Using headerBrush As New SolidBrush(Color.Black)
                Dim header As String = "Republic of the Philippines"
                Dim headerSize As SizeF = g.MeasureString(header, headerFont)
                g.DrawString(header, headerFont, headerBrush, x + (width / 2) - (headerSize.Width / 2), y + 70)
            End Using
        End Using

        ' Draw location information
        Using locationFont As New Font("Arial", 11)
            Using locationBrush As New SolidBrush(Color.Black)
                Dim province As String = "Province of Batangas"
                Dim provinceSize As SizeF = g.MeasureString(province, locationFont)
                g.DrawString(province, locationFont, locationBrush, x + (width / 2) - (provinceSize.Width / 2), y + 90)

                Dim municipality As String = "Municipality of Lipa City"
                Dim municipalitySize As SizeF = g.MeasureString(municipality, locationFont)
                g.DrawString(municipality, locationFont, locationBrush, x + (width / 2) - (municipalitySize.Width / 2), y + 110)

                Dim barangay As String = "Barangay Inosluban"
                Dim barangaySize As SizeF = g.MeasureString(barangay, locationFont)
                g.DrawString(barangay, locationFont, locationBrush, x + (width / 2) - (barangaySize.Width / 2), y + 130)
            End Using
        End Using
    End Sub

    Private Sub DrawSerialNumber(g As Graphics, serialNumber As String, x As Integer, y As Integer, width As Integer)
        ' Draw a decorative border around the serial number
        Using borderPen As New Pen(Color.FromArgb(255, 169, 106, 10), 1)
            g.DrawRectangle(borderPen, x, y, width, 40)

            ' Add decorative corner elements
            DrawDecorativeCorner(g, x, y, 10, 10, borderPen)
            DrawDecorativeCorner(g, x + width - 10, y, 10, 10, borderPen, True, False)
            DrawDecorativeCorner(g, x, y + 40 - 10, 10, 10, borderPen, False, True)
            DrawDecorativeCorner(g, x + width - 10, y + 40 - 10, 10, 10, borderPen, True, True)
        End Using

        ' Draw serial number label and value
        Using serialFont As New Font("Arial", 12, FontStyle.Bold)
            Using serialBrush As New SolidBrush(Color.FromArgb(255, 128, 0, 0))
                Dim label As String = "CERTIFICATE NO.: "
                Dim labelSize As SizeF = g.MeasureString(label, serialFont)
                g.DrawString(label, serialFont, serialBrush, x + 20, y + 10)

                ' Draw the actual serial number
                Using valueFont As New Font("Arial", 14, FontStyle.Bold)
                    g.DrawString(serialNumber, valueFont, serialBrush, x + 20 + labelSize.Width, y + 8)
                End Using
            End Using
        End Using
    End Sub

    Private Sub DrawDecorativeCorner(g As Graphics, x As Integer, y As Integer, width As Integer, height As Integer, pen As Pen, Optional flipX As Boolean = False, Optional flipY As Boolean = False)
        ' Draw decorative corner element
        Dim x1, y1, x2, y2, x3, y3 As Integer

        If Not flipX And Not flipY Then
            ' Top-left corner
            x1 = x
            y1 = y + height
            x2 = x
            y2 = y
            x3 = x + width
            y3 = y
        ElseIf flipX And Not flipY Then
            ' Top-right corner
            x1 = x + width
            y1 = y + height
            x2 = x + width
            y2 = y
            x3 = x
            y3 = y
        ElseIf Not flipX And flipY Then
            ' Bottom-left corner
            x1 = x
            y1 = y - height
            x2 = x
            y2 = y
            x3 = x + width
            y3 = y
        Else
            ' Bottom-right corner
            x1 = x + width
            y1 = y - height
            x2 = x + width
            y2 = y
            x3 = x
            y3 = y
        End If

        g.DrawLine(pen, x1, y1, x2, y2)
        g.DrawLine(pen, x2, y2, x3, y3)
    End Sub

    Private Sub DrawPersonalInfo(g As Graphics, rowData As DataGridViewRow, x As Integer, y As Integer, width As Integer)
        ' Draw personal information section with header
        Using sectionBorder As New Pen(Color.FromArgb(255, 169, 106, 10), 1)
            g.DrawRectangle(sectionBorder, x, y, width, 200)

            ' Add section title background
            Using titleBgBrush As New SolidBrush(Color.FromArgb(255, 240, 209, 150))
                g.FillRectangle(titleBgBrush, x, y, width, 25)
            End Using

            ' Add section title
            Using sectionTitleFont As New Font("Arial", 12, FontStyle.Bold)
                Using sectionTitleBrush As New SolidBrush(Color.FromArgb(255, 128, 64, 0))
                    g.DrawString("PERSONAL INFORMATION", sectionTitleFont, sectionTitleBrush, x + 10, y + 3)
                End Using
            End Using
        End Using

        ' Start drawing personal info content
        Dim infoY As Integer = y + 35
        Dim leftColumnX As Integer = x + 10
        Dim rowHeight As Integer = 30

        ' Drawing font settings
        Using labelFont As New Font("Arial", 10, FontStyle.Bold)
            Using valueFont As New Font("Arial", 11)
                Using labelBrush As New SolidBrush(Color.FromArgb(255, 64, 64, 64))
                    Using valueBrush As New SolidBrush(Color.Black)
                        ' Personal info - now using the full width without the ID photo
                        g.DrawString("Full Name:", labelFont, labelBrush, leftColumnX, infoY)
                        g.DrawString(rowData.Cells("fullname").Value.ToString(), valueFont, valueBrush, leftColumnX + 100, infoY)
                        infoY += rowHeight

                        g.DrawString("Address:", labelFont, labelBrush, leftColumnX, infoY)
                        g.DrawString(rowData.Cells("address").Value.ToString(), valueFont, valueBrush, leftColumnX + 100, infoY)
                        infoY += rowHeight

                        g.DrawString("Gender:", labelFont, labelBrush, leftColumnX, infoY)
                        g.DrawString(rowData.Cells("gender").Value.ToString(), valueFont, valueBrush, leftColumnX + 100, infoY)
                        infoY += rowHeight

                        g.DrawString("Date of Birth:", labelFont, labelBrush, leftColumnX, infoY)
                        g.DrawString(Convert.ToDateTime(rowData.Cells("dateofbirth").Value).ToString("MMMM dd, yyyy"), valueFont, valueBrush, leftColumnX + 100, infoY)
                        infoY += rowHeight


                        ' Add citizenship field
                        g.DrawString("Citizenship:", labelFont, labelBrush, leftColumnX, infoY)
                        g.DrawString("Filipino", valueFont, valueBrush, leftColumnX + 100, infoY)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DrawFinancialInfo(g As Graphics, rowData As DataGridViewRow, x As Integer, y As Integer, width As Integer)
        ' Draw financial information section with header
        Using sectionBorder As New Pen(Color.FromArgb(255, 169, 106, 10), 1)
            g.DrawRectangle(sectionBorder, x, y, width, 160)

            ' Add section title background
            Using titleBgBrush As New SolidBrush(Color.FromArgb(255, 240, 209, 150))
                g.FillRectangle(titleBgBrush, x, y, width, 25)
            End Using

            ' Add section title
            Using sectionTitleFont As New Font("Arial", 12, FontStyle.Bold)
                Using sectionTitleBrush As New SolidBrush(Color.FromArgb(255, 128, 64, 0))
                    g.DrawString("TAX ASSESSMENT", sectionTitleFont, sectionTitleBrush, x + 10, y + 3)
                End Using
            End Using
        End Using

        ' Create a table for financial information
        Dim tableY As Integer = y + 35
        Dim column1X As Integer = x + 10
        Dim column2X As Integer = x + width - 150
        Dim rowHeight As Integer = 25
        Dim altRow As Boolean = False

        ' Draw table headers
        Using headerFont As New Font("Arial", 10, FontStyle.Bold)
            Using headerBrush As New SolidBrush(Color.FromArgb(255, 64, 64, 64))
                g.DrawString("Income / Property", headerFont, headerBrush, column1X, tableY)
                g.DrawString("Amount (₱)", headerFont, headerBrush, column2X, tableY)

                ' Draw header underline
                Using headerLine As New Pen(Color.FromArgb(255, 128, 64, 0), 1)
                    g.DrawLine(headerLine, column1X, tableY + 20, x + width - 10, tableY + 20)
                End Using
            End Using
        End Using

        tableY += 25

        ' Draw table rows
        Using rowFont As New Font("Arial", 10)
            Using rowBrush As New SolidBrush(Color.Black)
                Using altRowBrush As New SolidBrush(Color.FromArgb(255, 245, 245, 245))
                    ' Gross receipts
                    If altRow Then g.FillRectangle(altRowBrush, column1X, tableY, width - 20, rowHeight)
                    g.DrawString("Gross Receipts / Earnings", rowFont, rowBrush, column1X, tableY)
                    g.DrawString(FormatNumber(rowData.Cells("gross_receipt").Value, 2), rowFont, rowBrush, column2X, tableY)
                    tableY += rowHeight
                    altRow = Not altRow

                    ' Salaries
                    If altRow Then g.FillRectangle(altRowBrush, column1X, tableY, width - 20, rowHeight)
                    g.DrawString("Salaries / Income", rowFont, rowBrush, column1X, tableY)
                    g.DrawString(FormatNumber(rowData.Cells("salaries").Value, 2), rowFont, rowBrush, column2X, tableY)
                    tableY += rowHeight
                    altRow = Not altRow

                    ' Real property
                    If altRow Then g.FillRectangle(altRowBrush, column1X, tableY, width - 20, rowHeight)
                    g.DrawString("Real Property", rowFont, rowBrush, column1X, tableY)
                    g.DrawString(FormatNumber(rowData.Cells("real_property").Value, 2), rowFont, rowBrush, column2X, tableY)
                    tableY += rowHeight
                    altRow = Not altRow

                    ' Basic tax and interest with bold line
                    Using totalLine As New Pen(Color.FromArgb(255, 128, 64, 0), 1)
                        g.DrawLine(totalLine, column1X, tableY, x + width - 10, tableY)
                    End Using
                    tableY += 5

                    g.DrawString("Basic Community Tax", rowFont, rowBrush, column1X, tableY)
                    g.DrawString(FormatNumber(rowData.Cells("basic_tax").Value, 2), rowFont, rowBrush, column2X, tableY)
                    tableY += rowHeight

                    g.DrawString("Interest", rowFont, rowBrush, column1X, tableY)
                    g.DrawString(FormatNumber(rowData.Cells("interest").Value, 2), rowFont, rowBrush, column2X, tableY)
                    tableY += rowHeight

                    ' Total with bold styling
                    Using totalLine As New Pen(Color.FromArgb(255, 128, 64, 0), 2)
                        g.DrawLine(totalLine, column1X, tableY - 5, x + width - 10, tableY - 5)
                    End Using

                    Using totalFont As New Font("Arial", 11, FontStyle.Bold)
                        Using totalBrush As New SolidBrush(Color.FromArgb(255, 128, 0, 0))
                            g.DrawString("TOTAL AMOUNT", totalFont, totalBrush, column1X, tableY)
                            g.DrawString(FormatNumber(rowData.Cells("total_tax").Value, 2), totalFont, totalBrush, column2X, tableY)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DrawValidationElements(g As Graphics, rowData As DataGridViewRow, x As Integer, y As Integer, width As Integer, issueDate As DateTime, expirationDate As DateTime)
        ' Draw validation elements section
        Using sectionBorder As New Pen(Color.FromArgb(255, 169, 106, 10), 1)
            g.DrawRectangle(sectionBorder, x, y, width, 180)
        End Using

        ' Create two columns
        Dim leftColumnX As Integer = x + 10
        Dim rightColumnX As Integer = x + width / 2 + 10


        ' Draw signature lines and other validation elements on the left
        Using validationFont As New Font("Arial", 10)
            ' Draw issue date
            g.DrawString("Date Issued: " & issueDate.ToString("MMMM dd, yyyy"), validationFont, Brushes.Black, leftColumnX, y + 20)

            ' Draw expiration date in bold
            Using expFont As New Font("Arial", 10, FontStyle.Bold)
                g.DrawString("Valid Until: " & expirationDate.ToString("MMMM dd, yyyy"), expFont, Brushes.Black, leftColumnX, y + 40)
            End Using

            ' Set a common signature line width
            Dim signatureLineWidth As Integer = 200
            Dim signatureLineX As Integer = leftColumnX + (width / 2 - signatureLineWidth) / 2 ' Center within the left column
            Dim thumbmarkBoxSize As Integer = 60
            Dim thumbmarkX As Integer = x + width - thumbmarkBoxSize - 10 ' 10px padding from the right
            Dim thumbmarkY As Integer = y + 100

            ' Draw taxpayer's signature line
            g.DrawLine(Pens.Black, signatureLineX, y + 100, signatureLineX + signatureLineWidth, y + 100)
            g.DrawString("Signature of Taxpayer", validationFont, Brushes.Black,
                         signatureLineX + (signatureLineWidth - g.MeasureString("Signature of Taxpayer", validationFont).Width) / 2, y + 105)


            g.DrawRectangle(Pens.Black, thumbmarkX, thumbmarkY, thumbmarkBoxSize, thumbmarkBoxSize)
            g.DrawString("Right Thumb", validationFont, Brushes.Black, thumbmarkX + 5, thumbmarkY + 20)
            g.DrawString("Mark", validationFont, Brushes.Black, thumbmarkX + 15, thumbmarkY + 35)

            ' Draw Barangay Treasurer signature line aligned with taxpayer signature
            g.DrawLine(Pens.Black, signatureLineX, y + 160, signatureLineX + signatureLineWidth, y + 160)
            Using officialFont As New Font("Arial", 9, FontStyle.Italic)
                g.DrawString("Barangay Treasurer", officialFont, Brushes.Black,
                             signatureLineX + (signatureLineWidth - g.MeasureString("Barangay Treasurer", officialFont).Width) / 2, y + 165)
            End Using

        End Using

        ' Draw official seal/stamp placeholder
        Using stampBrush As New SolidBrush(Color.FromArgb(30, 0, 0, 255))
            g.TranslateTransform(rightColumnX + 70, y + 150)
            g.RotateTransform(-15)

            ' Draw circular stamp
            Using stampPen As New Pen(Color.FromArgb(60, 0, 0, 255), 2)
                g.DrawEllipse(stampPen, -40, -40, 80, 80)
                g.DrawEllipse(stampPen, -30, -30, 60, 60)
            End Using

            ' Draw text "OFFICIAL" in the stamp
            Using stampFont As New Font("Arial", 10, FontStyle.Bold)
                Dim stampText As String = "OFFICIAL"
                Dim stampSize As SizeF = g.MeasureString(stampText, stampFont)
                g.DrawString(stampText, stampFont, stampBrush, -stampSize.Width / 2, -stampSize.Height / 2)
            End Using

            g.ResetTransform()
        End Using
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
