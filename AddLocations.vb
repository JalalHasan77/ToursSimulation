Public Class AddLocations
    Public lcParent As New Form


    Public CountryID As Integer
    Public CityID As Integer

    Private Sub AddLocations_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim SQL As String
        SQL = "insert into Locations (CountryCode,CityCode,LocationName,Category,Longtude,Latitude) Values "
        SQL = SQL & " (" & CountryID & "," & CityID & ",'" & txbxName.Text & "','" & cmbxCategory.SelectedItem.ToString & "','','')"

        GetDataTable(SQL)


        DialogResult = DialogResult.OK
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim F As New AddLocations
        F.lcParent = Me
        F.ShowDialog()

    End Sub
End Class