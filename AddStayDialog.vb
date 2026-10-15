''' <summary>
''' Dialog for "Add" above the Stay list: country and city (from what is
''' ticked on the Destinations tab, or all of them), stay name, category
''' (from StayCategories) and an optional star rating 1-8. It only collects
''' and checks the values; Form1 inserts the record into Stay.
''' </summary>
Public Class AddStayDialog

    Private _tickedCountries As New List(Of TextValueParent)
    Private _allCountries As New List(Of TextValueParent)
    Private _tickedCities As New List(Of TextValueParent)   ' ParentID = CountryID
    Private _preselectCountry As String = ""
    Private _preselectCity As String = ""
    Private _loading As Boolean

    ''' <summary>
    ''' What to offer: ticked countries / cities (shown first) and all countries.
    ''' Cities that are not ticked are read from DesCities when needed.
    ''' </summary>
    Public Sub SetChoices(tickedCountries As IEnumerable(Of TextValueParent), allCountries As IEnumerable(Of TextValueParent),
                          tickedCities As IEnumerable(Of TextValueParent), preselectCountry As String, preselectCity As String)
        _tickedCountries = tickedCountries.ToList()
        _allCountries = allCountries.ToList()
        _tickedCities = tickedCities.ToList()
        _preselectCountry = If(preselectCountry, "")
        _preselectCity = If(preselectCity, "")
    End Sub

    Public ReadOnly Property Country As TextValueParent
        Get
            Return TryCast(cmbCountry.SelectedItem, TextValueParent)
        End Get
    End Property

    Public ReadOnly Property City As TextValueParent
        Get
            Return TryCast(cmbCity.SelectedItem, TextValueParent)
        End Get
    End Property

    Public ReadOnly Property StayName As String
        Get
            Return txtName.Text.Trim()
        End Get
    End Property

    ''' <summary>The chosen category (ID and name), or Nothing for [Not Specified].</summary>
    Public ReadOnly Property Category As TextValueParent
        Get
            Dim c As TextValueParent = TryCast(cmbCategory.SelectedItem, TextValueParent)
            If c Is Nothing OrElse c.ID = "" Then Return Nothing
            Return c
        End Get
    End Property

    ''' <summary>1 to 8, or Nothing when the star rating is not specified.</summary>
    Public ReadOnly Property StarRating As Integer?
        Get
            If Not chkStars.Checked Then Return Nothing
            Return CInt(numStars.Value)
        End Get
    End Property

    Private Sub AddStayDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tickedCountries.Count = 0 Then
            chkShowAll.Checked = True
            chkShowAll.Enabled = False
        End If
        FillCountries()
        LoadCategories()
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        FillCountries()
    End Sub

    Private Sub chkStars_CheckedChanged(sender As Object, e As EventArgs) Handles chkStars.CheckedChanged
        numStars.Enabled = chkStars.Checked
    End Sub

    Private Sub FillCountries()
        _loading = True
        Dim keepId As String = If(Country Is Nothing, _preselectCountry, Country.ID)
        cmbCountry.Items.Clear()
        For Each c As TextValueParent In If(chkShowAll.Checked, _allCountries, _tickedCountries)
            cmbCountry.Items.Add(c)
        Next
        SelectById(cmbCountry, keepId)
        _loading = False
        FillCities()
    End Sub

    Private Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        If Not _loading Then FillCities()
    End Sub

    ''' <summary>
    ''' Cities of the chosen country: the ticked ones, or - with "Show all",
    ''' or when none of its cities is ticked - every city of it in DesCities.
    ''' </summary>
    Private Sub FillCities()
        Dim keepId As String = If(City Is Nothing, _preselectCity, City.ID)
        cmbCity.Items.Clear()
        If Country Is Nothing Then Exit Sub

        Dim cities As List(Of TextValueParent) = _tickedCities.Where(Function(c) c.parentID = Country.ID).ToList()
        If chkShowAll.Checked OrElse cities.Count = 0 Then cities = CitiesFromDatabase(Country.ID)
        For Each c As TextValueParent In cities
            cmbCity.Items.Add(c)
        Next
        SelectById(cmbCity, keepId)
    End Sub

    Private Function CitiesFromDatabase(countryId As String) As List(Of TextValueParent)
        Dim result As New List(Of TextValueParent)
        Dim id As Integer
        If Not Integer.TryParse(countryId, id) Then Return result
        Try
            Dim dt As DataTable = GetDataTable("SELECT CityID, CityNameEn FROM DesCities WHERE CountryID = " & id & " ORDER BY CityNameEn")
            For Each r As DataRow In dt.Rows
                result.Add(New TextValueParent(Text:=r("CityNameEn").ToString().Trim(), ID:=r("CityID").ToString(), ParentID:=countryId))
            Next
        Catch ex As Exception
            MessageBox.Show("Could not read the cities:" & vbCrLf & ex.Message, "Add Stay")
        End Try
        Return result
    End Function

    ''' <summary>StayCategories into the Category list, "[Not Specified]" first.</summary>
    Private Sub LoadCategories()
        cmbCategory.Items.Clear()
        cmbCategory.Items.Add(New TextValueParent(Text:="[Not Specified]", ID:=""))
        Try
            Dim dt As DataTable = GetDataTable("SELECT * FROM StayCategories")
            Dim idCol As String = PickColumn(dt, {"CategoryID", "StayCategoryID", "ID"}, 0)
            Dim nameCol As String = PickColumn(dt, {"CategoryName", "CategoryNameEn", "Category", "Name", "NameEn"}, If(dt.Columns.Count > 1, 1, 0))
            For Each r As DataRow In dt.Rows.Cast(Of DataRow)().OrderBy(Function(x) x(nameCol).ToString())
                cmbCategory.Items.Add(New TextValueParent(Text:=r(nameCol).ToString().Trim(), ID:=r(idCol).ToString()))
            Next
        Catch ex As Exception
            MessageBox.Show("Could not read the categories (StayCategories):" & vbCrLf & ex.Message &
                            vbCrLf & "The stay can still be added without a category.", "Add Stay")
        End Try
        cmbCategory.SelectedIndex = 0
    End Sub

    Private Shared Function PickColumn(dt As DataTable, preferred As String(), fallbackIndex As Integer) As String
        For Each name As String In preferred
            If dt.Columns.Contains(name) Then Return name
        Next
        Return dt.Columns(Math.Min(fallbackIndex, dt.Columns.Count - 1)).ColumnName
    End Function

    Private Shared Sub SelectById(cmb As ComboBox, id As String)
        For i As Integer = 0 To cmb.Items.Count - 1
            If DirectCast(cmb.Items(i), TextValueParent).ID = id Then cmb.SelectedIndex = i : Exit Sub
        Next
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    ''' <summary>Country, city and name are required; a stay already in that city asks first.</summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Country Is Nothing Then
            MessageBox.Show("Please choose the country.", "Add Stay") : cmbCountry.Focus() : Exit Sub
        End If
        If City Is Nothing Then
            MessageBox.Show("Please choose the city.", "Add Stay") : cmbCity.Focus() : Exit Sub
        End If
        If StayName = "" Then
            MessageBox.Show("Please enter the name of the stay.", "Add Stay") : txtName.Focus() : Exit Sub
        End If

        Dim exists As Boolean = False
        Try
            Dim id As Integer
            If Integer.TryParse(City.ID, id) Then
                Dim dt As DataTable = GetDataTable("SELECT StayName FROM Stay WHERE CityID = " & id)
                exists = dt.Rows.Cast(Of DataRow)().Any(Function(r) String.Equals(r(0).ToString().Trim(), StayName, StringComparison.CurrentCultureIgnoreCase))
            End If
        Catch
            ' If the check itself fails, let the insert go ahead (and report its own error).
        End Try
        If exists AndAlso
           MessageBox.Show("""" & StayName & """ is already a stay in " & City.Text & ". Add it again anyway?", "Add Stay",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If
        DialogResult = DialogResult.OK
    End Sub
End Class
