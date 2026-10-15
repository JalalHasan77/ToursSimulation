''' <summary>
''' Dialog for "Add" above the Cities list: the country (from the countries
''' ticked on the Destinations tab, or all countries), English and Arabic
''' city names. It only collects and checks the values; Form1 inserts the
''' record into DesCities.
''' </summary>
Public Class AddCityDialog

    Private _ticked As New List(Of TextValueParent)
    Private _all As New List(Of TextValueParent)
    Private _preselectId As String = ""

    ''' <summary>
    ''' Countries for the dropdown: the ticked ones (shown first) and all of
    ''' them (shown with "Show all countries", or when none is ticked).
    ''' </summary>
    Public Sub SetCountries(ticked As IEnumerable(Of TextValueParent), all As IEnumerable(Of TextValueParent), preselectId As String)
        _ticked = ticked.ToList()
        _all = all.ToList()
        _preselectId = If(preselectId, "")
    End Sub

    ''' <summary>The chosen country (Nothing if none).</summary>
    Public ReadOnly Property Country As TextValueParent
        Get
            Return TryCast(cmbCountry.SelectedItem, TextValueParent)
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

    Private Sub AddCityDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Nothing ticked on Destinations: offer all countries straight away.
        If _ticked.Count = 0 Then
            chkAllCountries.Checked = True
            chkAllCountries.Enabled = False
        End If
        FillCountries()
    End Sub

    Private Sub chkAllCountries_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllCountries.CheckedChanged
        FillCountries()
    End Sub

    Private Sub FillCountries()
        Dim keepId As String = If(Country Is Nothing, _preselectId, Country.ID)
        cmbCountry.Items.Clear()
        For Each c As TextValueParent In If(chkAllCountries.Checked, _all, _ticked)
            cmbCountry.Items.Add(c)
        Next
        For i As Integer = 0 To cmbCountry.Items.Count - 1
            If DirectCast(cmbCountry.Items(i), TextValueParent).ID = keepId Then cmbCountry.SelectedIndex = i : Exit For
        Next
        If cmbCountry.SelectedIndex < 0 AndAlso cmbCountry.Items.Count > 0 Then cmbCountry.SelectedIndex = 0
    End Sub

    ''' <summary>Country and both names are required; a city that already exists in that country asks first.</summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Country Is Nothing Then
            MessageBox.Show("Please choose the country.", "Add City")
            cmbCountry.Focus()
            Exit Sub
        End If
        If NameEn = "" Then
            MessageBox.Show("Please enter the city name in English.", "Add City")
            txtNameEn.Focus()
            Exit Sub
        End If
        If NameAr = "" Then
            MessageBox.Show("Please enter the city name in Arabic.", "Add City")
            txtNameAr.Focus()
            Exit Sub
        End If

        Dim exists As Boolean = False
        Try
            Dim id As Integer
            If Integer.TryParse(Country.ID, id) Then
                Dim dt As DataTable = GetDataTable("SELECT CityNameEn FROM DesCities WHERE CountryID = " & id)
                exists = dt.Rows.Cast(Of DataRow)().Any(Function(r) String.Equals(r(0).ToString().Trim(), NameEn, StringComparison.CurrentCultureIgnoreCase))
            End If
        Catch
            ' If the check itself fails, let the insert go ahead (and report its own error).
        End Try
        If exists AndAlso
           MessageBox.Show("""" & NameEn & """ is already a city of " & Country.Text & ". Add it again anyway?", "Add City",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If
        DialogResult = DialogResult.OK
    End Sub
End Class
