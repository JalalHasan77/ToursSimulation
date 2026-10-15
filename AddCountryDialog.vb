''' <summary>
''' Dialog for "Add" above the Countries list: English name, Arabic name and
''' region (from DesRegion, first item "[Not Specified]"). It only collects
''' and checks the values; Form1 inserts the record into DesCountry.
''' </summary>
Public Class AddCountryDialog

    ''' <summary>The English name typed in the dialog (trimmed).</summary>
    Public ReadOnly Property NameEn As String
        Get
            Return txtNameEn.Text.Trim()
        End Get
    End Property

    ''' <summary>The Arabic name typed in the dialog (trimmed).</summary>
    Public ReadOnly Property NameAr As String
        Get
            Return txtNameAr.Text.Trim()
        End Get
    End Property

    ''' <summary>The chosen region's ID, or Nothing for [Not Specified].</summary>
    Public ReadOnly Property RegionID As Object
        Get
            Dim item As TextValueParent = TryCast(cmbRegion.SelectedItem, TextValueParent)
            If item Is Nothing OrElse item.ID = "" Then Return Nothing
            Return item.ID
        End Get
    End Property

    ''' <summary>English names already in DesCountry, to warn about duplicates (set by Form1).</summary>
    Public ExistingNames As New HashSet(Of String)(StringComparer.CurrentCultureIgnoreCase)

    Private Sub AddCountryDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRegion.Items.Clear()
        cmbRegion.Items.Add(New TextValueParent(Text:="[Not Specified]", ID:=""))
        Try
            ' Column names are looked up, so this works whatever DesRegion calls them.
            Dim dt As DataTable = GetDataTable("SELECT * FROM DesRegion")
            Dim idCol As String = PickColumn(dt, {"RegionID", "ID"}, 0)
            Dim nameCol As String = PickColumn(dt, {"RegionNameEn", "RegionName", "NameEn", "Name", "Region"}, 1)
            For Each r As DataRow In dt.Rows.Cast(Of DataRow)().OrderBy(Function(x) x(nameCol).ToString())
                cmbRegion.Items.Add(New TextValueParent(Text:=r(nameCol).ToString().Trim(), ID:=r(idCol).ToString()))
            Next
        Catch ex As Exception
            MessageBox.Show("Could not read the regions (DesRegion):" & vbCrLf & ex.Message &
                            vbCrLf & "The country can still be added without a region.", "Add Country")
        End Try
        cmbRegion.SelectedIndex = 0
    End Sub

    ''' <summary>The first of the preferred column names that exists, else the column at fallbackIndex.</summary>
    Private Shared Function PickColumn(dt As DataTable, preferred As String(), fallbackIndex As Integer) As String
        For Each name As String In preferred
            If dt.Columns.Contains(name) Then Return name
        Next
        Return dt.Columns(Math.Min(fallbackIndex, dt.Columns.Count - 1)).ColumnName
    End Function

    ''' <summary>Both names are required; a name that already exists asks first.</summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If NameEn = "" Then
            MessageBox.Show("Please enter the country name in English.", "Add Country")
            txtNameEn.Focus()
            Exit Sub
        End If
        If NameAr = "" Then
            MessageBox.Show("Please enter the country name in Arabic.", "Add Country")
            txtNameAr.Focus()
            Exit Sub
        End If
        If ExistingNames.Contains(NameEn) AndAlso
           MessageBox.Show("""" & NameEn & """ is already in the list. Add it again anyway?", "Add Country",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If
        DialogResult = DialogResult.OK
    End Sub
End Class
