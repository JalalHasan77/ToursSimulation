Imports System.IO

Public Class Service
    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim count As Integer = 0
        Dim iconBasePath As String = "D:\VB Projects\ToursSimulatorNestedClass\ToursSimulatorNestedClass\Icon\"
        Dim ServicesDT As DataTable = GetDataTable("Select * from Services")

        For Each row As DataRow In ServicesDT.Rows
            Dim uc As New CheckBoxWIconAndComment.UserControl1
            Dim imagePath As String = iconBasePath & row("Icon").ToString().Trim()

            If File.Exists(imagePath) Then
                uc.lcImgList.Images.Add(Image.FromFile(imagePath))
            End If

            uc.Title = row("Service").ToString().Trim()
            uc.Location = New Point(10, 10 + 26 * count)

            Me.Controls.Add(uc)
            count += 1
        Next
    End Sub
End Class