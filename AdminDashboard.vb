Public Class AdminDashboard
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    ' Logout button click event
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim loginForm As New AdminLogin()
        loginForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub

    ' Link to navigate to AdminDashboard (or reload it if it's already open)
    Private Sub LinkDashboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkDashboard.LinkClicked
        ' If AdminDashboard is already open, just bring it to the front
        Dim adminDashboard As New AdminDashboard()
        adminDashboard.Show()
        Me.Hide()
    End Sub

    ' Link to navigate to AdminClearance form
    Private Sub LinkClearance_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkClearance.LinkClicked
        Dim clearanceForm As New AdminClearance()
        clearanceForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub

    ' Link to navigate to AdminCedula form
    Private Sub LinkCedula_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCedula.LinkClicked
        Dim cedulaForm As New AdminCedula()
        cedulaForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub

    ' Link to navigate to AdminBlotter form
    Private Sub LinkBlotter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkBlotter.LinkClicked
        Dim blotterForm As New AdminBlotter()
        blotterForm.Show()
        Me.Hide() ' Hide the current AdminDashboard form
    End Sub
End Class
