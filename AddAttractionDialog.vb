''' <summary>
''' Dialog for "Add" above the Attraction list: country and city (from what
''' is ticked on the Destinations tab, or all of them) and the English and
''' Arabic attraction names. It only collects and checks the values; Form1
''' inserts the record into DesAttractions.
''' </summary>
Public Class AddAttractionDialog

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

    Public ReadOnly Property NameEn As String
        Get
            Return txtNameEn.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property NameAr As String
        Get
            Return txtNameAr.Text.Trim()
        End Get
    End Property

    Private Sub AddAttractionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _tickedCountries.Count = 0 Then
            chkShowAll.Checked = True
            chkShowAll.Enabled = False
        End If
        FillCountries()
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        FillCountries()
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
            MessageBox.Show("Could not read the cities:" & vbCrLf & ex.Message, "Add Attraction")
        End Try
        Return result
    End Function

    Private Shared Sub SelectById(cmb As ComboBox, id As String)
        For i As Integer = 0 To cmb.Items.Count - 1
            If DirectCast(cmb.Items(i), TextValueParent).ID = id Then cmb.SelectedIndex = i : Exit Sub
        Next
        If cmb.Items.Count > 0 Then cmb.SelectedIndex = 0
    End Sub

    ''' <summary>Country, city and both names are required; an attraction already in that city asks first.</summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Country Is Nothing Then
            MessageBox.Show("Please choose the country.", "Add Attraction") : cmbCountry.Focus() : Exit Sub
        End If
        If City Is Nothing Then
            MessageBox.Show("Please choose the city.", "Add Attraction") : cmbCity.Focus() : Exit Sub
        End If
        If NameEn = "" Then
            MessageBox.Show("Please enter the attraction name in English.", "Add Attraction") : txtNameEn.Focus() : Exit Sub
        End If
        If NameAr = "" Then
            MessageBox.Show("Please enter the attraction name in Arabic.", "Add Attraction") : txtNameAr.Focus() : Exit Sub
        End If

        Dim exists As Boolean = False
        Try
            Dim id As Integer
            If Integer.TryParse(City.ID, id) Then
                Dim dt As DataTable = GetDataTable("SELECT AttractionNameEn FROM DesAttractions WHERE CityID = " & id)
                exists = dt.Rows.Cast(Of DataRow)().Any(Function(r) String.Equals(r(0).ToString().Trim(), NameEn, StringComparison.CurrentCultureIgnoreCase))
            End If
        Catch
            ' If the check itself fails, let the insert go ahead (and report its own error).
        End Try
        If exists AndAlso
           MessageBox.Show("""" & NameEn & """ is already an attraction in " & City.Text & ". Add it again anyway?", "Add Attraction",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If
        DialogResult = DialogResult.OK
    End Sub
End Class
