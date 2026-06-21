Imports System.Data
Public Class Countries
    Public SelectedPairs As listOfTwoPairs
    Public TableName As String
    Public ID As String
    Public lcText As String
    Public whereStt As String = ""

    Private Sub Countries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectedPairs = Nothing
        SelectedPairs = New listOfTwoPairs

        CheckedListBox1.ClearSelected()


        If whereStt <> "" AndAlso Not whereStt.ToUpper.Contains(" WHERE") Then
            whereStt = " where " & whereStt
        End If

        Dim DT As New Data.DataTable
        DT = GetDataTable("Select " & ID & "," & lcText & " from " & TableName & " " & whereStt)

        For Each DR As DataRow In DT.Rows
            CheckedListBox1.Items.Add(New twoPairs(Text:=DR(lcText).ToString, ID:=DR(ID).ToString))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each item As Object In CheckedListBox1.CheckedItems
            SelectedPairs.SelectedPairs.Add(CType(item, twoPairs))
        Next

        DialogResult = DialogResult.OK

    End Sub

End Class


