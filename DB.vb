Module DB
    Public DBPath As String = "D:\Web Site Projects\ToursV3\App_Data\toursMe.mdb"
    Public DBConnection As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBPath & ";"

    Dim Dcom As New Data.OleDb.OleDbCommand
    Dim Dcon As New Data.OleDb.OleDbConnection
    Dim DA As New Data.OleDb.OleDbDataAdapter
    Sub New()
        Dcon.ConnectionString = DBConnection
        Dcom.Connection = Dcon

        DA.SelectCommand = Dcom
    End Sub

    Function GetDataTable(ByVal SQL As String) As Data.DataTable
        Dim DT As New Data.DataTable

        Dcom.CommandText = SQL
        DA.SelectCommand = Dcom

        DA.Fill(DT)

        GetDataTable = DT
    End Function

End Module
