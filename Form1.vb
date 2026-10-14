Imports System.IO
Imports ToursSimulatorNestedClass.BookingFilters
Imports ToursSimulatorNestedClass.TravelForm.Models
Imports System.Xml.Serialization


Public Class Form1
    Dim CHKSTT As Integer = CheckState.Unchecked
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txbxTripTitle.Settings(lcTitle:="Title", Length:=450)
        txbxTripSubTitle.Settings(lcTitle:="Sub Title", Length:=350)





        Dim SQL As String = "Select CountryID,CountryNameen from DesCountry order by CountryNameen"
        Dim DT As Data.DataTable
        DT = GetDataTable(SQL)

        For Each DR As Data.DataRow In DT.Rows
            Dim i As New TextValueParent(Text:=DR("CountryNameen").ToString, ID:=DR("CountryID").ToString)
            CheckedListBox1.Items.Add(i)
        Next

        ' Countries with airports (Departure)
        LoadComboBox(
        cmbxDepartureFrom.ComboBox1,
            "SELECT DISTINCT c.CountryID, c.CountryNameen " &
    "FROM DesCountry c " &
    "INNER JOIN AirPorts a ON a.CountryCode = c.CountryID " &
    "ORDER BY c.CountryNameen",
    "CountryID", "CountryNameen")

        ' Countries with airports (Arrival)
        LoadComboBox(
    cmbxArrivingTo.ComboBox1,
    "SELECT DISTINCT c.CountryID, c.CountryNameen " &
    "FROM DesCountry c " &
    "INNER JOIN AirPorts a ON a.CountryCode = c.CountryID " &
    "ORDER BY c.CountryNameen",
    "CountryID", "CountryNameen")

        ' Airlines
        LoadComboBox(
    cmbxAirLine.ComboBox1,
    "SELECT AirlineID, AirLineName FROM Airlines ORDER BY AirLineName",
    "AirlineID", "AirLineName")


        'LoadServicesIntoTab("Including")
        LoadExtendedServicesIntoTab("Including")
        LoadServicesIntoTab("NotIncluding")
        '____________________________________________________________
    End Sub

    Private Sub LoadExtendedServicesIntoTab(tabName As String)
        Dim count As Integer = 0
        Dim iconBasePath As String = "D:\VB Projects\ToursSimulatorNestedClass\ToursSimulatorNestedClass\Icon\"
        Dim ServicesDT As DataTable = GetDataTable("Select * from Services")

        Dim tabPage As TabPage = TabControl1.TabPages(tabName) ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find("Panel2", True) ' True = search nested controls too
        Dim pnl As Panel = CType(found(0), Panel)

        pnl.AutoScroll = True

        For Each row As DataRow In ServicesDT.Rows
            Dim uc As New PricingWithCheckBox.PricingWithCheckBox

            Dim imagePath As String = iconBasePath & row("Icon").ToString().Trim()

            If File.Exists(imagePath) Then
                uc.Button1.BackgroundImage = Image.FromFile(imagePath)
                uc.Button1.BackgroundImageLayout = ImageLayout.Zoom
            End If

            uc.TextBox1.Text = row("Service").ToString().Trim()
            uc.Location = New Point(10, 0 + uc.Height * count)

            pnl.Controls.Add(uc)
            count += 1
        Next

        For I As Integer = 0 To 5
            Dim uc As New PricingWithCheckBox.PricingWithCheckBox
            uc.Location = New Point(10, 0 + uc.Height * count)
            pnl.Controls.Add(uc)
            count += 1
        Next

    End Sub

    Private Sub LoadServicesIntoTab(tabName As String)
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

            TabControl1.TabPages(tabName).Controls.Add(uc)
            count += 1
        Next
    End Sub

    Private Sub LoadComboBox(
    TargetCombo As ComboBox,
    SQL As String,
    IDField As String,
    TextField As String)
        IDField = IDField.Trim
        TextField = TextField.Trim

        Dim DT As Data.DataTable = GetDataTable(SQL)
        TargetCombo.Items.Clear()
        For Each DR As Data.DataRow In DT.Rows
            Dim item As New TextValueParent(
            Text:=DR(TextField).ToString(),
            ID:=DR(IDField).ToString())
            TargetCombo.Items.Add(item)
        Next
        Try
            TargetCombo.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim lcCountries As New Countries
        With lcCountries
            .TableName = "DesCountry"
            .ID = "CountryID"
            .Text = "CountryNameen"
        End With

        If lcCountries.ShowDialog = DialogResult.OK Then
            Dim i As Integer
            i = TreeView1.Nodes.Add(New TravelOffers(lcList:=lcCountries.SelectedPairs, lcCategory:=Categories.Countries))

            For J As Integer = 0 To lcCountries.SelectedPairs.arrText.Count - 1
                Dim K As New listOfTwoPairs
                K.SelectedPairs.Add(lcCountries.SelectedPairs.SelectedPairs(J))
                TreeView1.Nodes(i).Nodes.Add(New TravelOffers(lcList:=K, lcCategory:=Categories.Countries))
            Next
        End If
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node   ' select the node first
            ContextMenuStrip1.Show(TreeView1, e.Location)
        End If
    End Sub

    Private Sub CitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CitiesToolStripMenuItem.Click
        Dim S As TravelOffers
        S = CType(TreeView1.SelectedNode, TravelOffers)

        Dim lcCountries As New Countries
        With lcCountries
            .TableName = "DesCities"
            .ID = "CityID"
            .Text = "CityNameEn"
            .whereStt = "CountryID = " & S.Countries.arrID(0)
        End With

        If lcCountries.ShowDialog = DialogResult.OK Then
            Dim NewTreeNode As TravelOffers
            NewTreeNode = New TravelOffers(lcList:=lcCountries.SelectedPairs, lcCategory:=Categories.Cities)
            TreeView1.SelectedNode.Nodes.Add(NewTreeNode)
            TreeView1.SelectedNode = NewTreeNode

            For J As Integer = 0 To lcCountries.SelectedPairs.arrText.Count - 1
                Dim K As New listOfTwoPairs
                K.SelectedPairs.Add(lcCountries.SelectedPairs.SelectedPairs(J))
                TreeView1.SelectedNode.Nodes.Add(New TravelOffers(lcList:=K, lcCategory:=Categories.Cities))
            Next
        End If
    End Sub

    Private Sub StayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StayToolStripMenuItem.Click
        Dim S As TravelOffers
        S = CType(TreeView1.SelectedNode, TravelOffers)

        Dim P As TravelOffers
        P = CType(TreeView1.SelectedNode, TravelOffers)

        Dim lcCountries As New Countries
        With lcCountries
            .TableName = "Stay"
            .ID = "StayID"
            .Text = "StayName"
            .whereStt = "CityID = " & S.Cities.arrID(0)
        End With

        If lcCountries.ShowDialog = DialogResult.OK Then
            Dim NewTreeNode As TravelOffers
            NewTreeNode = New TravelOffers(lcList:=lcCountries.SelectedPairs, lcCategory:=Categories.Stay)
            TreeView1.SelectedNode.Nodes.Add(NewTreeNode)
            TreeView1.SelectedNode = NewTreeNode

            For J As Integer = 0 To lcCountries.SelectedPairs.arrText.Count - 1
                Dim K As New listOfTwoPairs
                K.SelectedPairs.Add(lcCountries.SelectedPairs.SelectedPairs(J))
                TreeView1.SelectedNode.Nodes.Add(New TravelOffers(lcList:=K, lcCategory:=Categories.Stay))
            Next
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim allSQL As String = TextBox1.Text
        Dim L As New List(Of String)
        L.AddRange(Split(allSQL, ";"))
        L = L.Where(Function(s) Not String.IsNullOrWhiteSpace(s)).ToList()

        For Each SQL As String In L
            Try
                ExecuteNonQuery(DBConnection, SQL)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next
        TextBox1.Text = ""
    End Sub

    Sub ExecuteNonQuery(ByVal DBConnection As String, ByVal SQL As String)
        Dim Dcom As New Data.OleDb.OleDbCommand
        Dim Dcon As New Data.OleDb.OleDbConnection

        Dcon.ConnectionString = DBConnection
        Dcom.Connection = Dcon
        Dcom.CommandText = SQL

        'MsgBox(System.AppDomain.CurrentDomain.BaseDirectory)

        Try
            Dcom.Connection.Open()
        Catch ex As Exception

        End Try

        Try
            Dcom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dcom.Connection.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click
        Dim lcCategories As Categories
        lcCategories = Categories.TravelWays
        Dim S As TravelOffers
        S = CType(TreeView1.SelectedNode, TravelOffers)

        Dim P As TravelOffers
        P = CType(TreeView1.SelectedNode, TravelOffers)

        Dim lcCountries As New Countries
        With lcCountries
            .TableName = "TravelWay"
            .ID = "TravelWayID"
            .Text = "TravelWayName"
            .whereStt = "IsActive = " & True
        End With

        If lcCountries.ShowDialog = DialogResult.OK Then
            Dim NewTreeNode As TravelOffers
            NewTreeNode = New TravelOffers(lcList:=lcCountries.SelectedPairs, lcCategory:=lcCategories)
            TreeView1.SelectedNode.Nodes.Add(NewTreeNode)
            TreeView1.SelectedNode = NewTreeNode

            For J As Integer = 0 To lcCountries.SelectedPairs.arrText.Count - 1
                Dim K As New listOfTwoPairs
                K.SelectedPairs.Add(lcCountries.SelectedPairs.SelectedPairs(J))
                TreeView1.SelectedNode.Nodes.Add(New TravelOffers(lcList:=K, lcCategory:=lcCategories))
            Next
        End If
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        HandleCheckedListBox(
                CheckedListBox1,
                CheckedListBox2,
                "SELECT CityID, CityNameEn FROM DesCities WHERE CountryID = {0}",
                "CityID",
                "CityNameEn")

    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged

        HandleCheckedListBox(
    CheckedListBox2,
    CheckedListBox3,
    "SELECT StayID, StayName FROM Stay WHERE CityID = {0}",
    "StayID",
    "StayName")

        HandleCheckedListBox(
                CheckedListBox2,
                CheckedListBox4,
                "SELECT AttractionID, AttractionNameEn FROM DesAttractions WHERE CityID = {0}",
                "AttractionID",
                "AttractionNameEn")

    End Sub

    Private Sub HandleCheckedListBox(
    SourceList As CheckedListBox,
    TargetList As CheckedListBox,
    SqlTemplate As String,
    IDField As String,
    TextField As String)

        If SourceList.SelectedItem Is Nothing Then Exit Sub

        Dim CurrentSelectedItem As TextValueParent =
            CType(SourceList.SelectedItem, TextValueParent)

        CascadeCheckedItem(
            SourceList,
            CurrentSelectedItem,
            SourceList.GetItemChecked(SourceList.SelectedIndex),
            TargetList,
            SqlTemplate,
            IDField,
            TextField)

    End Sub

    ''' <summary>
    ''' Core Country→City / City→Stay/Attraction cascade: if Item is
    ''' checked, (re)loads its children from the DB into TargetList; if
    ''' unchecked, removes its existing children. Takes the item and its
    ''' checked state explicitly rather than reading SourceList.SelectedItem
    ''' /.SelectedIndex, so it can be driven either by a real row click
    ''' (via HandleCheckedListBox, below) or programmatically — e.g. by
    ''' LoadTabPage1Data — without needing to fake a UI selection change.
    ''' </summary>
    Private Sub CascadeCheckedItem(
    SourceList As CheckedListBox,
    Item As TextValueParent,
    isChecked As Boolean,
    TargetList As CheckedListBox,
    SqlTemplate As String,
    IDField As String,
    TextField As String)

        If isChecked Then

            ' BUGFIX: this can run more than once for the same already-
            ' checked item (e.g. CheckOnClick selecting AND checking the
            ' row in the same click, or re-selecting a city that is already
            ' checked). Without this guard, the title + rows below get
            ' appended again on every extra firing, which is exactly what
            ' produced the duplicated Stay / Attraction entries. Clearing
            ' out anything already loaded for this parent first makes the
            ' load idempotent no matter how many times this runs for the
            ' same checked item.
            RemoveItemsByParentID(TargetList, Item.ID)

            ' Add fake title
            TargetList.Items.Add(New TextValueParent(
                Text:="----" & Item.Text & "----",
                ID:="",
                ParentID:=Item.ID))

            Dim SQL As String = String.Format(SqlTemplate, Item.ID)
            Dim DT As DataTable = GetDataTable(SQL)

            For Each DR As DataRow In DT.Rows
                TargetList.Items.Add(New TextValueParent(
                    Text:=DR(TextField).ToString(),
                    ID:=DR(IDField).ToString(),
                    ParentID:=Item.ID))
            Next
        Else
            If SourceList Is CheckedListBox1 Then
                RemoveCountryChildren(Item.ID)
            Else
                RemoveItemsByParentID(TargetList, Item.ID)
            End If
        End If

    End Sub

    Private Sub RemoveItemsByParentID(
    ListBox As CheckedListBox,
    ParentID As String)

        For i As Integer = ListBox.Items.Count - 1 To 0 Step -1

            Dim Item As TextValueParent =
            CType(ListBox.Items(i), TextValueParent)

            If Item.parentID = ParentID Then
                ListBox.Items.RemoveAt(i)
            End If

        Next

    End Sub

    Private Sub RemoveCountryChildren(CountryID As String)

        Dim CityIDs As New List(Of String)

        'Remove Cities from CheckedListBox2
        For i As Integer = CheckedListBox2.Items.Count - 1 To 0 Step -1

            Dim Item As TextValueParent =
            CType(CheckedListBox2.Items(i), TextValueParent)

            If Item.parentID = CountryID Then

                'Ignore fake title rows
                If Item.ID <> "" Then
                    CityIDs.Add(Item.ID)
                End If

                CheckedListBox2.Items.RemoveAt(i)

            End If

        Next

        'Remove related items from CheckedListBox3 and CheckedListBox4
        For Each CityID As String In CityIDs

            RemoveItemsByParentID(CheckedListBox3, CityID)
            RemoveItemsByParentID(CheckedListBox4, CityID)

        Next

        CheckedListBox2.ClearSelected()
        CheckedListBox3.ClearSelected()
        CheckedListBox4.ClearSelected()

    End Sub

    ''' <summary>
    ''' Reads TabPage1 — Title, Sub Title, Countries (CheckedListBox1),
    ''' Cities (CheckedListBox2, tri-state), Stay (CheckedListBox3) and
    ''' Attraction (CheckedListBox4) — and packs ONLY the checked items
    ''' from each list into a TravelFormData instance (TravelFormData.vb).
    ''' Unchecked rows and the "----Header----" separator rows are skipped.
    ''' </summary>
    ''' <remarks>
    ''' txbxTripTitle / txbxTripSubTitle are TextBoxWithCheckBox.TextBoxWithCheckBox
    ''' controls. This assumes they expose public .Checked (the leading
    ''' checkbox) and .Text (the textbox value) properties — rename those
    ''' two property accesses below if the control's real members differ.
    ''' </remarks>
    Public Function SaveTabPage1Data() As TravelFormData

        Dim data As New TravelFormData()

        ' ---- Title / Sub Title ---------------------------------------------
        data.Title = New TitleField(txbxTripTitle.CheckBox1.Checked, txbxTripTitle.TextBox1.Text)
        data.SubTitle = New TitleField(txbxTripSubTitle.CheckBox1.Checked, txbxTripSubTitle.TextBox1.Text)

        ' ---- Countries (CheckedListBox1) — checked rows only ---------------
        For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
            If Not CheckedListBox1.GetItemChecked(idx) Then Continue For

            Dim tvp As TextValueParent = CType(CheckedListBox1.Items(idx), TextValueParent)
            If tvp.ID = "" Then Continue For ' skip header rows, just in case

            data.Countries.Add(New CheckListItem(name:=tvp.Text, isChecked:=True))
        Next

        ' ---- Cities (CheckedListBox2) — tri-state, skip Unchecked only -----
        For idx As Integer = 0 To CheckedListBox2.Items.Count - 1
            ' CheckState.Unchecked/Checked/Indeterminate share the same
            ' underlying values (0/1/2) as our TriState enum, so this cast
            ' carries the third (grayed) state across correctly.
            Dim state As TriState = CType(CheckedListBox2.GetItemCheckState(idx), TriState)
            If state = TriState.Unchecked Then Continue For

            Dim tvp As TextValueParent = CType(CheckedListBox2.Items(idx), TextValueParent)
            If tvp.ID = "" Then Continue For ' skip header rows, just in case

            data.Cities.Add(New CityListItem(name:=tvp.Text, state:=state))
        Next

        ' ---- Stay (CheckedListBox3) — checked rows only ---------------------
        For idx As Integer = 0 To CheckedListBox3.Items.Count - 1
            If Not CheckedListBox3.GetItemChecked(idx) Then Continue For

            Dim tvp As TextValueParent = CType(CheckedListBox3.Items(idx), TextValueParent)
            If tvp.ID = "" Then Continue For ' skip header rows, just in case

            data.Stays.Add(New CheckListItem(name:=tvp.Text, isChecked:=True))
        Next

        ' ---- Attraction (CheckedListBox4) — checked rows only ---------------
        For idx As Integer = 0 To CheckedListBox4.Items.Count - 1
            If Not CheckedListBox4.GetItemChecked(idx) Then Continue For

            Dim tvp As TextValueParent = CType(CheckedListBox4.Items(idx), TextValueParent)
            If tvp.ID = "" Then Continue For ' skip header rows, just in case

            data.Attractions.Add(New CheckListItem(name:=tvp.Text, isChecked:=True))
        Next
        data.Text = data.Title.Text
        Return data

    End Function

    Private Sub ResetCitiesStayAttraction()

        ' Empty out Cities / Stay / Attraction completely
        CheckedListBox2.Items.Clear()
        CheckedListBox3.Items.Clear()
        CheckedListBox4.Items.Clear()

        ' Uncheck every country, but keep the countries themselves listed
        For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(idx, False)
        Next

        CheckedListBox1.ClearSelected()
        CheckedListBox2.ClearSelected()
        CheckedListBox3.ClearSelected()
        CheckedListBox4.ClearSelected()

    End Sub

    ''' <summary>
    ''' Fills TabPage1 (Title, Sub Title, CheckedListBox1-4) from a previously
    ''' saved TravelFormData instance — the reverse of SaveTabPage1Data().
    ''' </summary>
    ''' <remarks>
    ''' Countries (CheckedListBox1) is assumed to already hold the full master
    ''' list of countries (as loaded in Form1_Load) — this only flips the
    ''' checkmarks to match the saved data, it doesn't add/remove rows.
    ''' Cities/Stay/Attraction have no such pre-loaded master list: Cities is
    ''' (re)populated by CascadeCheckedItem from the DB, exactly as a real
    ''' click on a checked country would do via CheckedListBox1_SelectedIndexChanged,
    ''' so each city keeps its real DB ID/ParentID. Stay/Attraction are
    ''' populated the same way once a city is checked. TravelFormData's
    ''' CheckListItem/CityListItem only expose Name and IsChecked/State
    ''' (TravelBasicInfo.vb) — there is no ID/ParentID on those models — so
    ''' matching a saved row back to a freshly-loaded list row is done by
    ''' Name. SaveTabPage1Data only stores checked rows, so there's nothing
    ''' to restore for unchecked/header rows.
    ''' </remarks>
    Public Sub LoadTabPage1Data(data As TravelFormData)

        If data Is Nothing Then Exit Sub

        ' ---- Title / Sub Title ---------------------------------------------
        txbxTripTitle.CheckBox1.Checked = data.Title.IsEnabled
        txbxTripTitle.TextBox1.Text = data.Title.Text

        txbxTripSubTitle.CheckBox1.Checked = data.SubTitle.IsEnabled
        txbxTripSubTitle.TextBox1.Text = data.SubTitle.Text

        ' ---- Countries (CheckedListBox1) -------------------------------------
        ' Flip every row's checkmark to match the saved data, and replay the
        ' same Country -> City cascade HandleCheckedListBox runs on a real
        ' click: newly-checked countries get their cities (re)loaded from
        ' the DB, newly-unchecked ones get their cities/stay/attraction
        ' cleaned up. Driving CascadeCheckedItem directly (instead of
        ' bouncing SelectedIndex to fake a click) means this never double-
        ' fires and never needs a UI selection at all.
        Dim checkedCountryNames As New HashSet(Of String)(
            data.Countries.Where(Function(c) c.IsChecked).Select(Function(c) c.Name))

        For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
            Dim country As TextValueParent = CType(CheckedListBox1.Items(idx), TextValueParent)
            Dim isChecked As Boolean = checkedCountryNames.Contains(country.Text)

            CheckedListBox1.SetItemChecked(idx, isChecked)
            CascadeCheckedItem(
                CheckedListBox1, country, isChecked, CheckedListBox2,
                "SELECT CityID, CityNameEn FROM DesCities WHERE CountryID = {0}",
                "CityID", "CityNameEn")
        Next

        ' ---- Cities (CheckedListBox2) -----------------------------------------
        ' CheckedListBox2 now holds exactly the cities for the countries just
        ' checked above. Check the ones that were saved, and cascade each
        ' into Stay/Attraction exactly like CheckedListBox2_SelectedIndexChanged does.
        Dim savedCityStates As New Dictionary(Of String, TriState)()
        For Each c In data.Cities
            savedCityStates(c.Name) = c.State
        Next

        For idx As Integer = 0 To CheckedListBox2.Items.Count - 1
            Dim city As TextValueParent = CType(CheckedListBox2.Items(idx), TextValueParent)
            If city.ID = "" Then Continue For ' skip "----Country----" header rows

            Dim state As TriState
            If Not savedCityStates.TryGetValue(city.Text, state) Then Continue For

            ' CheckedListBox2_ItemCheck always cycles Unchecked -> Checked ->
            ' Indeterminate -> Unchecked, regardless of what value is asked
            ' for. Every row here is freshly added (Unchecked), so one call
            ' lands on Checked; Indeterminate needs the check toggled twice.
            CheckedListBox2.SetItemChecked(idx, True) ' Unchecked -> Checked
            If state = TriState.Indeterminate Then
                CheckedListBox2.SetItemChecked(idx, True) ' Checked -> Indeterminate
            End If

            ' Both Checked and Indeterminate count as "checked" for cascading
            ' purposes — GetItemChecked returns True for either, same as it
            ' would for a real click, so Stay/Attraction load either way.
            CascadeCheckedItem(
                CheckedListBox2, city, True, CheckedListBox3,
                "SELECT StayID, StayName FROM Stay WHERE CityID = {0}",
                "StayID", "StayName")
            CascadeCheckedItem(
                CheckedListBox2, city, True, CheckedListBox4,
                "SELECT AttractionID, AttractionNameEn FROM DesAttractions WHERE CityID = {0}",
                "AttractionID", "AttractionNameEn")
        Next

        ' ---- Stay / Attraction (CheckedListBox3 / 4) ---------------------------
        ' Leaf lists — nothing further to cascade into, just check the saved rows.
        CheckByName(CheckedListBox3, data.Stays.Select(Function(s) s.Name))
        CheckByName(CheckedListBox4, data.Attractions.Select(Function(a) a.Name))

        CheckedListBox1.ClearSelected()
        CheckedListBox2.ClearSelected()
        CheckedListBox3.ClearSelected()
        CheckedListBox4.ClearSelected()

    End Sub

    ''' <summary>
    ''' Checks every row in list whose Text matches one of names. Used for
    ''' the leaf-level lists (Stay, Attraction) that have nothing further to
    ''' cascade into. Assumes list was just freshly (re)populated by
    ''' CascadeCheckedItem — i.e. every row starts Unchecked — so there's no
    ''' need to also uncheck non-matches.
    ''' </summary>
    Private Sub CheckByName(list As CheckedListBox, names As IEnumerable(Of String))
        Dim nameSet As New HashSet(Of String)(names)
        For idx As Integer = 0 To list.Items.Count - 1
            Dim tvp As TextValueParent = CType(list.Items(idx), TextValueParent)
            If nameSet.Contains(tvp.Text) Then
                list.SetItemChecked(idx, True)
            End If
        Next
    End Sub

    Private Sub ResetAllFields()
        ' Reset all fields
        txtTitle.Text = ""

        txbxDuration.Text = ""

        cmbxDepartureDate.lcDateTimePicker.Value = Now
        cmbxDepartureTime.lcTime.Value = Now

        ArrivalDate.lcDateTimePicker.Value = Now
        cmbxArrivalTime.lcTime.Value = Now

        cmbxDepartureFrom.ComboBox1.SelectedIndex = 0
        cmbxDepartureCity.ComboBox1.SelectedIndex = 0
        cmbxDepartureLocation.ComboBox1.SelectedIndex = 0

        cmbxAirLine.ComboBox1.SelectedIndex = 0

        cmbxArrivingTo.ComboBox1.SelectedIndex = 0
        cmbxDepartureCity.ComboBox1.SelectedIndex = 0
        cmbxArrivingLocation.ComboBox1.SelectedIndex = 0
    End Sub



    Private Sub CmbxDepartureFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDepartureFrom.SelectedIndexChanged
        If cmbxDepartureFrom.ComboBox1.SelectedItem Is Nothing Then Exit Sub
        Dim countryID As String = CType(cmbxDepartureFrom.ComboBox1.SelectedItem, TextValueParent).ID

        LoadComboBox(
        cmbxDepartureCity.ComboBox1,
        "SELECT DISTINCT c.CityID, c.CityNameEn " &
        "FROM DesCities c " &
        "INNER JOIN CityAirports ca ON ca.CityID = c.CityID " &
        "WHERE c.CountryID = " & countryID &
        " ORDER BY c.CityNameEn",
        "CityID", "CityNameEn")
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If _suppressLegLoad Then Exit Sub
        If ListBox1.SelectedItem Is Nothing Then Exit Sub

        SetLoadedLeg(ListBox1.SelectedItem)   ' "Save Changes to Item" now targets this item

        Dim selectedItem = ListBox1.SelectedItem
        Dim F As Flight = TryCast(selectedItem, Flight)
        Dim L As LayOver = TryCast(selectedItem, LayOver)

        If F IsNot Nothing Then
            ' Switch to Flight tab in TabControl2
            TabControl3.SelectedTab = TabControl3.TabPages("TabPage8")
            SelectRadioButtonByTag(If(String.IsNullOrEmpty(F.TransferMean), "Airplane", F.TransferMean))

            ' Text fields
            txtTitle.Text = F.Title
            cmbxDepartureDate.lcDateTimePicker.Value = F.DepartureDate
            cmbxDepartureTime.lcTime.Value = cmbxDepartureDate.lcDateTimePicker.Value.Add(F.DepartureTime)
            ArrivalDate.lcDateTimePicker.Value = F.ArrivalDate
            cmbxArrivalTime.lcTime.Value = ArrivalDate.lcDateTimePicker.Value.Add(F.ArrivalTime)
            txbxDuration.Text = F.Duration

            ' --- DEPARTURE ---
            ' Step 1: Set Country → triggers CmbxDepartureFrom_SelectedIndexChanged
            '         which reloads cmbxDepartureCity
            SetComboByID(cmbxDepartureFrom.ComboBox1, F.DepartureFrom)

            ' Step 2: Set City → triggers CmbxDepartureCity_SelectedIndexChanged
            '         which reloads cmbxDepartureAirPort
            SetComboByID(cmbxDepartureCity.ComboBox1, F.DepartureCity)

            ' Step 3: Set Airport (list is now populated by step 2)
            SetComboByID(cmbxDepartureLocation.ComboBox1, F.DeparturePoint)

            ' --- AIRLINE ---
            SetComboByID(cmbxAirLine.ComboBox1, F.AirLine)

            ' --- ARRIVING ---
            ' Step 1: Set Country → triggers CmbxArrivingTo_SelectedIndexChanged
            '         which reloads cmbxArrivingCity
            SetComboByID(cmbxArrivingTo.ComboBox1, F.ArrivingTo)

            ' Step 2: Set City → triggers CmbxArrivingCity_SelectedIndexChanged
            '         which reloads cmbxArrivingPort
            SetComboByID(cmbxArrivingCity.ComboBox1, F.ArrivalCity)

            ' Step 3: Set Airport (list is now populated by step 2)
            SetComboByID(cmbxArrivingLocation.ComboBox1, F.ArrivalPoint)

            ' --- which controls are active (their checkboxes) ---
            cmbxDepartureFrom.CheckBox1.Checked = F.DepartureFromActive
            cmbxDepartureCity.CheckBox1.Checked = F.DepartureCityActive
            cmbxDepartureLocation.CheckBox1.Checked = F.DeparturePointActive
            cmbxDepartureDate.CheckBox1.Checked = F.DepartureDateActive
            cmbxDepartureTime.CheckBox1.Checked = F.DepartureTimeActive
            cmbxAirLine.CheckBox1.Checked = F.AirLineActive
            cmbxArrivingTo.CheckBox1.Checked = F.ArrivingToActive
            cmbxArrivingCity.CheckBox1.Checked = F.ArrivalCityActive
            cmbxArrivingLocation.CheckBox1.Checked = F.ArrivalPointActive
            ArrivalDate.CheckBox1.Checked = F.ArrivalDateActive
            cmbxArrivalTime.CheckBox1.Checked = F.ArrivalTimeActive

        ElseIf L IsNot Nothing Then


            ' Switch to LayOver tab in TabControl2
            TabControl3.SelectedTab = TabControl3.TabPages("TabPage9")

            txtTitle.Text = L.Title
            DateTimePicker1.Value = L.DepartureDate
            DateTimePicker2.Value = L.DepartureDate.Add(L.DepartureTime)
            DateTimePicker3.Value = L.ArrivalDate
            DateTimePicker4.Value = L.ArrivalDate.Add(L.ArrivalTime)
            MaskedTextBox1.Text = L.Duration   ' the LayOver tab's duration box
        End If
    End Sub

    Private Sub SelectRadioButtonByTag(tagValue As Object)
        Dim buttons As RadioButton() = {RadioButton1, RadioButton2, RadioButton3, RadioButton4,
                                     RadioButton5, RadioButton6, RadioButton7, RadioButton8}

        For Each rb As RadioButton In buttons
            If Object.Equals(rb.Tag, tagValue) Then
                rb.Checked = True
                Exit Sub
            End If
        Next
    End Sub


    Private Sub SetComboByID(TargetCombo As ComboBox, Item As TextValueParent)
        If Item Is Nothing Then Exit Sub
        For i As Integer = 0 To TargetCombo.Items.Count - 1
            Dim Existing As TextValueParent = CType(TargetCombo.Items(i), TextValueParent)
            If Existing.ID = Item.ID Then
                TargetCombo.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TabControl3.SelectedIndex = 0 Then
            ListBox1.Items.Add(BuildFlightFromForm())
        Else
            ListBox1.Items.Add(BuildLayOverFromForm())
        End If

        SetLoadedLeg(Nothing)   ' fields are about to be cleared: nothing is "loaded" any more
        ResetAllFields()
    End Sub

    ''' <summary>
    ''' "Save Changes to Item": writes what is on the Move / LayOver tab back
    ''' into the ListBox1 item that was loaded by clicking it. The item keeps
    ''' its position and its type (a Flight stays a Flight, a LayOver stays a
    ''' LayOver, whichever inner tab is showing).
    ''' </summary>
    Private Sub btnUpdateLeg_Click(sender As Object, e As EventArgs) Handles btnUpdateLeg.Click
        Dim index As Integer = If(_loadedLeg Is Nothing, -1, ListBox1.Items.IndexOf(_loadedLeg))
        If index < 0 Then
            SetLoadedLeg(Nothing)
            MessageBox.Show("No item is loaded. Click an item in the list first.")
            Exit Sub
        End If

        Dim updated As Object
        If TypeOf _loadedLeg Is Flight Then
            updated = BuildFlightFromForm()
        Else
            updated = BuildLayOverFromForm()
        End If

        ' Replace in place without re-running the click handler's reload.
        _suppressLegLoad = True
        Try
            ListBox1.Items(index) = updated
            ListBox1.SelectedIndex = index
        Finally
            _suppressLegLoad = False
        End Try

        SetLoadedLeg(updated)
    End Sub

    ' ---- ListBox1 item helpers ------------------------------------------------

    ''' <summary>The ListBox1 item currently loaded into the fields (Nothing = none).</summary>
    Private _loadedLeg As Object
    Private _suppressLegLoad As Boolean

    Private Sub SetLoadedLeg(leg As Object)
        _loadedLeg = leg
        btnUpdateLeg.Enabled = (leg IsNot Nothing)
    End Sub

    ''' <summary>Builds a Flight from the Move tab (as the ">>" button always did).</summary>
    Private Function BuildFlightFromForm() As Flight
        Dim F As New Flight
        F.TransferMean = getChosedTransfer()
        F.Title = txtTitle.Text
        F.DepartureFrom = CType(cmbxDepartureFrom.ComboBox1.SelectedItem, TextValueParent)
        F.DepartureCity = CType(cmbxDepartureCity.ComboBox1.SelectedItem, TextValueParent)
        F.DeparturePoint = CType(cmbxDepartureLocation.ComboBox1.SelectedItem, TextValueParent)
        F.DepartureDate = cmbxDepartureDate.lcDateTimePicker.Value.Date
        F.DepartureTime = TimeSpan.Parse(cmbxDepartureTime.lcTime.Value.ToString("HH:mm"))

        F.ArrivingTo = CType(cmbxArrivingTo.ComboBox1.SelectedItem, TextValueParent)
        F.ArrivalCity = CType(cmbxArrivingCity.ComboBox1.SelectedItem, TextValueParent)
        F.ArrivalPoint = CType(cmbxArrivingLocation.ComboBox1.SelectedItem, TextValueParent)
        F.ArrivalDate = ArrivalDate.lcDateTimePicker.Value.Date
        F.ArrivalTime = TimeSpan.Parse(cmbxArrivalTime.lcTime.Value.ToString("HH:mm"))

        If F.TransferMean = "Airplane" Then
            F.AirLine = CType(cmbxAirLine.ComboBox1.SelectedItem, TextValueParent)
        Else
            F.AirLine = Nothing
        End If

        ' ── Duration (shown in txbxDuration as d:h:m:s) ──────────────────
        txbxDuration.Text = FormatDuration(F.DepartureDate.Add(F.DepartureTime),
                                           F.ArrivalDate.Add(F.ArrivalTime))
        F.Duration = txbxDuration.Text

        ' ── which controls are active (their checkboxes) ─────────────────
        F.DepartureFromActive = cmbxDepartureFrom.CheckBox1.Checked
        F.DepartureCityActive = cmbxDepartureCity.CheckBox1.Checked
        F.DeparturePointActive = cmbxDepartureLocation.CheckBox1.Checked
        F.DepartureDateActive = cmbxDepartureDate.CheckBox1.Checked
        F.DepartureTimeActive = cmbxDepartureTime.CheckBox1.Checked
        F.AirLineActive = cmbxAirLine.CheckBox1.Checked
        F.ArrivingToActive = cmbxArrivingTo.CheckBox1.Checked
        F.ArrivalCityActive = cmbxArrivingCity.CheckBox1.Checked
        F.ArrivalPointActive = cmbxArrivingLocation.CheckBox1.Checked
        F.ArrivalDateActive = ArrivalDate.CheckBox1.Checked
        F.ArrivalTimeActive = cmbxArrivalTime.CheckBox1.Checked

        Return F
    End Function

    ''' <summary>Builds a LayOver from the LayOver tab.</summary>
    Private Function BuildLayOverFromForm() As LayOver
        Dim L As New LayOver
        L.Title = txtTitle.Text

        L.DepartureDate = DateTimePicker1.Value.Date
        L.DepartureTime = TimeSpan.Parse(DateTimePicker2.Text)

        L.ArrivalDate = DateTimePicker3.Value.Date
        L.ArrivalTime = TimeSpan.Parse(DateTimePicker4.Text)

        ' ── Duration (shown in MaskedTextBox1 as d:h:m:s) ────────────────
        MaskedTextBox1.Text = FormatDuration(L.DepartureDate.Add(L.DepartureTime),
                                             L.ArrivalDate.Add(L.ArrivalTime))
        L.Duration = MaskedTextBox1.Text

        Return L
    End Function

    Private Function FormatDuration(fromTime As DateTime, toTime As DateTime) As String
        Dim d As TimeSpan = toTime - fromTime
        Return String.Format("{0:0}:{1:0}:{2:0}:{3:0}", d.Days, d.Hours, d.Minutes, d.Seconds)
    End Function

    Private Function getChosedTransfer() As String
        'Dim TransferMean As String = TabControl2.SelectedTab.Name
        'TransferMean = TransferMean.Replace("tab", "")
        'getChosedTransfer = TransferMean

        Return GetSelectedRadioButtonTag(TabPage8)
    End Function

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try
            'Panel2.Visible = False
            'cmbxAirLine.Visible = False
            'Label9.Visible = False
            'Select Case TabControl2.SelectedTab.Name
            '    Case "tabLayOver"
            '        Panel2.Visible = True
            '    Case "tabAirCraft"
            '        cmbxAirLine.Visible = True
            '        Label9.Visible = True
            '    Case Else

            'End Select

            LoadLocationComboBox(cmbxDepartureCity.ComboBox1, cmbxDepartureLocation.ComboBox1)
            LoadLocationComboBox(cmbxArrivingCity.ComboBox1, cmbxArrivingLocation.ComboBox1)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub DateTimePicker6_Leave(sender As Object, e As EventArgs)
    End Sub

    Private Sub CmbxDepartureCity_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadLocationComboBox(cmbxDepartureCity.ComboBox1, cmbxDepartureLocation.ComboBox1)
    End Sub

    Private Sub ComboBoxWithCheckBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDepartureCity.SelectedIndexChanged
        LoadLocationComboBox(cmbxDepartureCity.ComboBox1, cmbxDepartureLocation.ComboBox1)
    End Sub


    Private Sub CmbxArrivingCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxArrivingCity.SelectedIndexChanged
        LoadLocationComboBox(cmbxArrivingCity.ComboBox1, cmbxArrivingLocation.ComboBox1)
    End Sub

    Private Sub LoadLocationComboBox(cmbxCity As ComboBox, cmbxLocation As ComboBox)

        If cmbxCity.SelectedItem Is Nothing Then Exit Sub

        Dim cityID As String = CType(cmbxCity.SelectedItem, TextValueParent).ID

        Dim categoryFilter As String = ""
        Select Case GetSelectedRadioButtonTag(TabPage8)
            Case "Airplane" : categoryFilter = " AND Category = 'AirPort'"
            Case "Train" : categoryFilter = " AND Category = 'Train'"
        End Select

        Dim SQL As String =
        "SELECT a.ID, a.LocationName " &
        "FROM Locations a " &
        "WHERE CityCode = " & cityID &
        categoryFilter

        LoadComboBox(cmbxLocation, SQL, "ID", "LocationName")

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ResetAllFields()
        SetLoadedLeg(Nothing)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ResetAllFields()
        SetLoadedLeg(Nothing)   ' preparing a new item, not editing a loaded one

        Dim lastItem = ListBox1.Items(ListBox1.Items.Count - 1)
        Dim F As Flight = TryCast(lastItem, Flight)
        Dim L As LayOver = TryCast(lastItem, LayOver)

        If TabControl3.SelectedIndex = 0 Then
            If F IsNot Nothing Then
                'Flight is Found
                cmbxDepartureDate.lcDateTimePicker.Value = F.ArrivalDate
                cmbxDepartureTime.lcTime.Value = F.ArrivalDate.Add(F.ArrivalTime)
            Else
                cmbxDepartureDate.lcDateTimePicker.Value = L.ArrivalDate
                cmbxDepartureTime.lcTime.Value = L.ArrivalDate.Add(L.ArrivalTime)

                lastItem = ListBox1.Items(ListBox1.Items.Count - 2)
                F = TryCast(lastItem, Flight)
            End If

            SetComboByID(cmbxDepartureFrom.ComboBox1, F.ArrivingTo)
            SetComboByID(cmbxDepartureCity.ComboBox1, F.ArrivalCity)
            SetComboByID(cmbxDepartureLocation.ComboBox1, F.ArrivalPoint)
        Else
            DateTimePicker1.Value = F.ArrivalDate
            DateTimePicker2.Value = F.ArrivalDate.Add(F.ArrivalTime)
        End If

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        OpenAddLocations(cmbxArrivingTo.ComboBox1, cmbxArrivingCity.ComboBox1, cmbxArrivingLocation.ComboBox1)
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        ' For Departure
        OpenAddLocations(cmbxDepartureFrom.ComboBox1, cmbxDepartureCity.ComboBox1, cmbxDepartureLocation.ComboBox1)
    End Sub

    Private Sub OpenAddLocations(
    cmbxCountry As ComboBox,
    cmbxCity As ComboBox,
    cmbxLocation As ComboBox)

        If cmbxCountry.SelectedItem Is Nothing OrElse cmbxCity.SelectedItem Is Nothing Then Exit Sub

        Dim F As New AddLocations
        F.CountryID = CType(cmbxCountry.SelectedItem, TextValueParent).ID
        F.CityID = CType(cmbxCity.SelectedItem, TextValueParent).ID
        F.txbxCountry.Text = CType(cmbxCountry.SelectedItem, TextValueParent).Text
        F.txbxCity.Text = CType(cmbxCity.SelectedItem, TextValueParent).Text

        If F.ShowDialog() = DialogResult.OK Then

            Dim categoryFilter As String = ""
            Select Case GetSelectedRadioButtonTag(TabPage8)
                Case "Airplane" : categoryFilter = " AND Category = 'AirPort'"
                Case "Train" : categoryFilter = " AND Category = 'Train'"
                Case "Bus" : categoryFilter = " AND Category = 'Bus'"
            End Select

            Dim SQL As String =
                "SELECT a.ID, a.LocationName " &
                "FROM Locations a " &
                "WHERE CityCode = " & F.CityID &
                categoryFilter

            LoadComboBox(cmbxLocation, SQL, "ID", "LocationName")

        End If

    End Sub
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub



    Private Sub CheckedListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListBox1.MouseClick
        If e.Button = MouseButtons.Right Then
            ' Get the index of the item under the mouse cursor
            Dim index As Integer = CheckedListBox1.IndexFromPoint(e.Location)

            If index <> ListBox.NoMatches Then
                ' Select the right-clicked item
                CheckedListBox1.SelectedIndex = index

                ' Show the context menu at the mouse position
                ContextMenuStrip2.Show(CheckedListBox1, e.Location)
            End If
        End If
    End Sub

    Private Sub InludesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InludesToolStripMenuItem.Click
        Dim S As New Service
        S.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Dim F As New AddLocations
        'F.Parent = Me
        'F.ShowDialog()

        Dim F As New ItemProperties
        F.ShowDialog()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'MsgBox(CheckBox1.CheckState.ToString)
        ''If CHKSTT = CheckState.Un Then
        ''CycleCheckState(CheckBox1, CHKSTT)
        ''CHKSTT = CheckBox1.CheckState

        'Select Case CHKSTT
        '    Case CheckState.Unchecked
        '        CheckBox1.CheckState = CheckState.Indeterminate   ' shows as a square
        '    Case CheckState.Indeterminate
        '        CheckBox1.CheckState = CheckState.Checked          ' shows as a tick
        '    Case CheckState.Checked
        '        CheckBox1.CheckState = CheckState.Unchecked         ' back to empty
        'End Select
        'CHKSTT = CheckBox1.CheckState


    End Sub

    Private Sub DateWithCheckBox8_ControlLeft(sender As Object, e As EventArgs) Handles chkTravFrom.ControlLeft, chkTravTo.ControlLeft
        Try
            ' ── Calculate Duration ────────────────────────────────
            Dim EndDateTime As DateTime = chkTravTo.lcDateTimePicker.Value
            Dim StartDateTime As DateTime = chkTravFrom.lcDateTimePicker.Value
            Dim FlightDuration As TimeSpan = EndDateTime - StartDateTime

            txtDays.Text = EndDateTime.Subtract(StartDateTime).Days + 1
            txtNights.Text = EndDateTime.Subtract(StartDateTime).Days
            ' ──────────────────────────────────────────────────────
            TextBox12_TextChanged(txtDays, EventArgs.Empty)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles txtNights.TextChanged

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles txtDays.TextChanged
        Try


            Dim S As Date = chkTravFrom.lcDateTimePicker.Value

            For I As Integer = 1 To CInt(txtNights.Text)
                Dim day As String = String.Format("Day {0}", I)
                If TabControl5.SelectedTab.Name = "tabSpecificDates" Then
                    day = day & String.Format(" (" & S.ToString("yyyy-MM-dd") & ")")
                End If
                ListBox2.Items.Add(day)
                S = S.AddDays(1)
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If PriceDialog.ShowDialog = DialogResult.OK Then

            Dim Amount As String = CDbl(PriceDialog.TextBox1.Text).ToString("#,##0") & "                               "
            Amount = Amount.Substring(0, 32)


            ListBox3.Items.Add(Amount & PriceDialog.ComboBox1.SelectedItem.ToString)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ListBox3.Items.RemoveAt(ListBox3.SelectedIndex)
    End Sub

    Private Sub ComboBoxWithCheckBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDepartureFrom.SelectedIndexChanged
        If cmbxDepartureFrom.ComboBox1.SelectedItem Is Nothing Then Exit Sub
        Dim countryID As String = CType(cmbxDepartureFrom.ComboBox1.SelectedItem, TextValueParent).ID

        LoadComboBox(
        cmbxDepartureCity.ComboBox1,
        "SELECT DISTINCT c.CityID, c.CityNameEn " &
        "FROM DesCities c " &
        "INNER JOIN CityAirports ca ON ca.CityID = c.CityID " &
        "WHERE c.CountryID = " & countryID &
        " ORDER BY c.CityNameEn",
        "CityID", "CityNameEn")
    End Sub

    Private Sub CmbxArrivingTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxArrivingTo.SelectedIndexChanged
        If cmbxArrivingTo.ComboBox1.SelectedItem Is Nothing Then Exit Sub
        Dim countryID As String = CType(cmbxArrivingTo.ComboBox1.SelectedItem, TextValueParent).ID

        LoadComboBox(
        cmbxArrivingCity.ComboBox1,
        "SELECT DISTINCT c.CityID, c.CityNameEn " &
        "FROM DesCities c " &
        "INNER JOIN CityAirports ca ON ca.CityID = c.CityID " &
        "WHERE c.CountryID = " & countryID &
        " ORDER BY c.CityNameEn",
        "CityID", "CityNameEn")
    End Sub

    Private Sub CheckedListBox2_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox2.ItemCheck
        Select Case e.CurrentValue
            Case CheckState.Unchecked
                e.NewValue = CheckState.Checked
            Case CheckState.Checked
                e.NewValue = CheckState.Indeterminate
            Case Else ' Indeterminate
                e.NewValue = CheckState.Unchecked
        End Select
    End Sub

    Private Function GetSelectedRadioButtonTag(container As Control) As Object
        For Each ctrl As Control In container.Controls
            Dim rb As RadioButton = TryCast(ctrl, RadioButton)
            If rb IsNot Nothing AndAlso rb.Checked Then
                Return rb.Tag
            End If
        Next
        Return Nothing
    End Function

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        MsgBox(GetSelectedRadioButtonTag(TabPage8))
    End Sub

    ''' <summary>
    ''' SAVE on the "Title And Sub Title" tab: adds a new ROOT node to
    ''' TreeView1 whose text is the trip title. Destination versions are
    ''' later added under it by btnSaveDestinations (TabPage1).
    ''' </summary>
    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim title As String = txbxTripTitle.TextBox1.Text.Trim()
        If title = "" Then
            MessageBox.Show("Please enter a trip title first.")
            txbxTripTitle.TextBox1.Focus()
            Exit Sub
        End If

        Dim root As New TripRootNode(
            New TitleField(txbxTripTitle.CheckBox1.Checked, title),
            New TitleField(txbxTripSubTitle.CheckBox1.Checked, txbxTripSubTitle.TextBox1.Text))

        TreeView1.Nodes.Add(root)

        ' New trip: nothing loaded yet, lists start empty, and the first
        ' SAVE VERSION goes under this root.
        SetCurrentVersion(Nothing)
        ResetCitiesStayAttraction()
        TreeView1.SelectedNode = root
    End Sub

    ''' <summary>
    ''' SAVE VERSION on TabPage1: saves CheckedListBox1-4 as a NEW copy
    ''' (a new version node) under the same trip root as the currently
    ''' loaded version. If no version is loaded yet (the first one for a
    ''' trip), it goes under the root of whatever node is selected.
    ''' Node text = checked countries joined by ", " + " V<n>", where n is
    ''' one more than the highest version already under that root.
    ''' The new copy becomes the currently loaded version, so further edits
    ''' + "Save Changes" go into it, not into the one it was copied from.
    ''' </summary>
    Private Sub btnSaveDestinations_Click(sender As Object, e As EventArgs) Handles btnSaveDestinations.Click
        ' ---- which trip root? ---------------------------------------------------
        Dim startNode As TreeNode
        If _currentVersion IsNot Nothing AndAlso _currentVersion.TreeView IsNot Nothing Then
            startNode = _currentVersion          ' copy of the loaded version
        Else
            startNode = TreeView1.SelectedNode   ' first version of a trip
        End If

        If startNode Is Nothing Then
            MessageBox.Show("Select a trip (root node) in the tree first.")
            Exit Sub
        End If

        Dim root As TripRootNode = TryCast(GetRootNode(startNode), TripRootNode)
        If root Is Nothing Then
            MessageBox.Show("The selected node is not a trip. Create one on the ""Title And Sub Title"" tab first.")
            Exit Sub
        End If

        ' ---- save the four lists ------------------------------------------------
        Dim data As TravelFormData = SaveTabPage1Data()
        If data.Countries.Count = 0 Then
            MessageBox.Show("Check at least one country first.")
            Exit Sub
        End If

        ' ---- next version number under this root -------------------------------
        Dim version As Integer = root.Nodes.Count + 1
        For Each child As TreeNode In root.Nodes
            Dim n As Integer = GetVersionNumber(child)
            If n >= version Then version = n + 1
        Next

        data.Text = BuildVersionText(data, version)

        ' A copy of the loaded version also copies its Departure & Arrival
        ' info and its Travel And Layover legs.
        If _currentVersion IsNot Nothing AndAlso TypeOf _currentVersion.Tag Is VersionExtras Then
            data.Tag = DirectCast(_currentVersion.Tag, VersionExtras).Clone()
        End If

        root.Nodes.Add(data)
        root.Expand()
        SetCurrentVersion(data)   ' the new copy is now the one being edited
    End Sub

    ''' <summary>
    ''' Save Changes on TabPage1: overwrites the currently loaded version
    ''' node with what is in CheckedListBox1-4 now. Keeps its place in the
    ''' tree and its version number; only the countries part of the text
    ''' is refreshed.
    ''' </summary>
    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        If _currentVersion Is Nothing OrElse _currentVersion.TreeView Is Nothing Then
            SetCurrentVersion(Nothing)
            MessageBox.Show("No version is loaded. Double-click a version in the tree first, or use SAVE VERSION.")
            Exit Sub
        End If

        Dim data As TravelFormData = SaveTabPage1Data()
        If data.Countries.Count = 0 Then
            MessageBox.Show("Check at least one country first.")
            Exit Sub
        End If

        Dim old As TravelFormData = _currentVersion
        Dim parent As TreeNode = old.Parent
        Dim index As Integer = old.Index

        data.Text = BuildVersionText(data, GetVersionNumber(old))
        data.Tag = old.Tag   ' keep its Departure & Arrival info and travel legs

        ' Swap the old node for the new one at the same position.
        parent.Nodes.Insert(index, data)
        old.Remove()

        SetCurrentVersion(data)
    End Sub

    ' ---- version helpers ----------------------------------------------------

    ''' <summary>The version node currently loaded into TabPage1 (Nothing = none).</summary>
    Private _currentVersion As TravelFormData

    Private Sub SetCurrentVersion(node As TravelFormData)
        _currentVersion = node
        btnSaveChanges.Enabled = (node IsNot Nothing)
        If node IsNot Nothing Then TreeView1.SelectedNode = node
    End Sub

    Private Function GetRootNode(node As TreeNode) As TreeNode
        While node.Parent IsNot Nothing
            node = node.Parent
        End While
        Return node
    End Function

    ''' <summary>Reads n from a node text ending in " V&lt;n&gt;"; 0 if none.</summary>
    Private Function GetVersionNumber(node As TreeNode) As Integer
        Dim vPos As Integer = node.Text.LastIndexOf(" V")
        Dim n As Integer
        If vPos >= 0 AndAlso Integer.TryParse(node.Text.Substring(vPos + 2), n) Then Return n
        Return 0
    End Function

    Private Function BuildVersionText(data As TravelFormData, version As Integer) As String
        Return String.Join(", ", data.Countries.Select(Function(c) c.Name)) & " V" & version
    End Function

    ''' <summary>
    ''' Loads a previously saved trip back into TabPage1 — the reverse of
    ''' Button8_Click_1, which calls SaveTabPage1Data() and adds the result
    ''' to TreeView1 as a TravelFormData node.
    ''' </summary>
    ''' <param name="node">
    ''' A TreeView1 node, e.g. TreeView1.SelectedNode. TreeView1 also holds
    ''' TravelOffers nodes (added by ToolStripButton1_Click and the
    ''' CitiesToolStripMenuItem/StayToolStripMenuItem/TransferToolStripMenuItem
    ''' handlers), which are a different node type — those are simply
    ''' ignored here since they hold no TabPage1 data to load.
    ''' </param>
    Private Sub LoadTabPage1DataFromTreeNode(node As TreeNode)
        ' A trip root node: put its title / sub title back.
        Dim root As TripRootNode = TryCast(node, TripRootNode)
        If root IsNot Nothing Then
            txbxTripTitle.CheckBox1.Checked = root.Title.IsEnabled
            txbxTripTitle.TextBox1.Text = root.Title.Text
            txbxTripSubTitle.CheckBox1.Checked = root.SubTitle.IsEnabled
            txbxTripSubTitle.TextBox1.Text = root.SubTitle.Text
            TabControl1.SelectedTab = TitleAndSubTitle
            ' Working on this trip now: next SAVE VERSION goes under it.
            SetCurrentVersion(Nothing)
            TreeView1.SelectedNode = root
            Exit Sub
        End If

        Dim data As TravelFormData = TryCast(node, TravelFormData)
        If data Is Nothing Then Exit Sub ' not a saved-trip node (e.g. a TravelOffers node) — nothing to load

        LoadTabPage1Data(data)
        Dim extras As VersionExtras = TryCast(data.Tag, VersionExtras)
        If extras IsNot Nothing Then
            LoadDepartureArrival(extras.DepartureArrival)
            LoadTravelLegs(extras.Legs)
            LoadIncluding(extras.Including)
        End If
        SetCurrentVersion(data)   ' Save Changes now writes back into this node
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        TreeView1.SelectedNode = e.Node
        LoadTabPage1DataFromTreeNode(e.Node)
    End Sub

    ''' <summary>
    ''' "Save to Selected Version" on the Departure &amp; Arrival tab: stores
    ''' TabControl5 (Specific Dates or Months Names, with all 6 fields),
    ''' txtNights and txtDays on the version sub-node selected in TreeView1.
    ''' The info is kept in the node's Tag as a DepartureArrivalInfo.
    ''' </summary>
    Private Sub btnSaveDatesToNode_Click(sender As Object, e As EventArgs) Handles btnSaveDatesToNode.Click
        ' ---- target: a version sub-node -----------------------------------------
        Dim node As TravelFormData = TryCast(TreeView1.SelectedNode, TravelFormData)
        If node Is Nothing OrElse node.Parent Is Nothing Then
            MessageBox.Show("Select a version (a sub-node under a trip) in the tree first.")
            Exit Sub
        End If

        ' ---- read + check the numbers ---------------------------------------------
        Dim nights, days As Integer
        If Not Integer.TryParse(txtNights.Text, nights) OrElse Not Integer.TryParse(txtDays.Text, days) Then
            MessageBox.Show("Nights and Days must be whole numbers.")
            Exit Sub
        End If

        Dim info As New DepartureArrivalInfo With {
            .Mode = If(TabControl5.SelectedTab Is tabSpecificDates,
                       DuringFilterMode.SpecificDates, DuringFilterMode.MonthsNames),
            .RegFromEnabled = chkRegFrom.CheckBox1.Checked, .RegFrom = chkRegFrom.lcDateTimePicker.Value,
            .RegToEnabled = chkRegTo.CheckBox1.Checked, .RegTo = chkRegTo.lcDateTimePicker.Value,
            .TravFromEnabled = chkTravFrom.CheckBox1.Checked, .TravFrom = chkTravFrom.lcDateTimePicker.Value,
            .TravToEnabled = chkTravTo.CheckBox1.Checked, .TravTo = chkTravTo.lcDateTimePicker.Value,
            .RegMonthsEnabled = chkRegMonths.CheckBox1.Checked, .RegMonths = chkRegMonths.TextBox1.Text,
            .TravMonthsEnabled = chkTravMonths.CheckBox1.Checked, .TravMonths = chkTravMonths.TextBox1.Text,
            .Nights = nights,
            .Days = days}

        ' ---- same validation the existing SAVE button runs ------------------------
        Dim filter = BookingSearchFilter.FromForm(
            info.Mode,
            info.RegFromEnabled, info.RegFrom, info.RegToEnabled, info.RegTo,
            info.TravFromEnabled, info.TravFrom, info.TravToEnabled, info.TravTo,
            info.RegMonthsEnabled, info.RegMonths, info.TravMonthsEnabled, info.TravMonths,
            info.Nights, info.Days)

        Dim errMsg As String = ""
        If Not filter.IsValid(errMsg) Then
            MessageBox.Show(errMsg)
            Exit Sub
        End If

        GetExtras(node).DepartureArrival = info
        MessageBox.Show("Departure & Arrival saved to """ & node.Text & """.")
    End Sub

    ''' <summary>
    ''' "Save to Selected Version" on the Travel And Layover tab: stores every
    ''' Flight / LayOver currently in ListBox1, in order, on the version
    ''' sub-node selected in TreeView1. Replaces whatever legs were saved there.
    ''' </summary>
    Private Sub btnSaveLegsToNode_Click(sender As Object, e As EventArgs) Handles btnSaveLegsToNode.Click
        Dim node As TravelFormData = TryCast(TreeView1.SelectedNode, TravelFormData)
        If node Is Nothing OrElse node.Parent Is Nothing Then
            MessageBox.Show("Select a version (a sub-node under a trip) in the tree first.")
            Exit Sub
        End If

        If ListBox1.Items.Count = 0 AndAlso
           MessageBox.Show("The list is empty. Save it anyway (this removes any legs saved on """ &
                           node.Text & """)?", "Save Travel And Layover",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim legs As New List(Of Object)
        For Each item As Object In ListBox1.Items
            If TypeOf item Is Flight OrElse TypeOf item Is LayOver Then legs.Add(item)
        Next

        GetExtras(node).Legs = legs
        MessageBox.Show(legs.Count & " leg(s) saved to """ & node.Text & """.")
    End Sub

    ''' <summary>
    ''' Puts saved legs back into ListBox1. Does nothing if legs is Nothing
    ''' (this version never had legs saved).
    ''' </summary>
    Private Sub LoadTravelLegs(legs As List(Of Object))
        If legs Is Nothing Then Exit Sub
        ListBox1.Items.Clear()
        SetLoadedLeg(Nothing)
        For Each leg As Object In legs
            ListBox1.Items.Add(leg)
        Next
    End Sub

    ''' <summary>
    ''' "Save to Selected Version" on the Including tab: stores every
    ''' PricingWithCheckBox row in Panel2 (text, prices, icon and its
    ''' ticked / active state) on the version sub-node selected in TreeView1.
    ''' Uses the same ToPricingItem() as "SAVE V1".
    ''' </summary>
    Private Sub btnSaveIncludingToNode_Click(sender As Object, e As EventArgs) Handles btnSaveIncludingToNode.Click
        Dim node As TravelFormData = TryCast(TreeView1.SelectedNode, TravelFormData)
        If node Is Nothing OrElse node.Parent Is Nothing Then
            MessageBox.Show("Select a version (a sub-node under a trip) in the tree first.")
            Exit Sub
        End If

        Dim rows As New PricingItem.PricingCollection()
        For Each ctl As Control In Panel2.Controls
            Dim row As PricingWithCheckBox.PricingWithCheckBox = TryCast(ctl, PricingWithCheckBox.PricingWithCheckBox)
            If row IsNot Nothing Then rows.Add(row.ToPricingItem())
        Next

        GetExtras(node).Including = rows
        MessageBox.Show(rows.Count & " Including row(s) saved to """ & node.Text & """.")
    End Sub

    ''' <summary>
    ''' Puts saved Including rows back into Panel2, row by row in order
    ''' (same matching as "Load V1"). Does nothing if rows is Nothing.
    ''' </summary>
    Private Sub LoadIncluding(rows As PricingItem.PricingCollection)
        If rows Is Nothing Then Exit Sub

        Dim index As Integer = 0
        For Each ctl As Control In Panel2.Controls
            Dim row As PricingWithCheckBox.PricingWithCheckBox = TryCast(ctl, PricingWithCheckBox.PricingWithCheckBox)
            If row Is Nothing Then Continue For
            If index >= rows.Count Then Exit For
            row.FromPricingItem(rows(index))
            index += 1
        Next
    End Sub

    ''' <summary>Returns the node's VersionExtras, creating it if needed.</summary>
    Private Function GetExtras(node As TreeNode) As VersionExtras
        Dim extras As VersionExtras = TryCast(node.Tag, VersionExtras)
        If extras Is Nothing Then
            extras = New VersionExtras()
            node.Tag = extras
        End If
        Return extras
    End Function

    ''' <summary>
    ''' Puts a saved DepartureArrivalInfo back into the Departure &amp; Arrival
    ''' tab. Does nothing if info is Nothing (version has none saved yet).
    ''' </summary>
    Private Sub LoadDepartureArrival(info As DepartureArrivalInfo)
        If info Is Nothing Then Exit Sub

        TabControl5.SelectedTab = If(info.Mode = DuringFilterMode.SpecificDates, tabSpecificDates, TabPage17)

        chkRegFrom.CheckBox1.Checked = info.RegFromEnabled : chkRegFrom.lcDateTimePicker.Value = info.RegFrom
        chkRegTo.CheckBox1.Checked = info.RegToEnabled : chkRegTo.lcDateTimePicker.Value = info.RegTo
        chkTravFrom.CheckBox1.Checked = info.TravFromEnabled : chkTravFrom.lcDateTimePicker.Value = info.TravFrom
        chkTravTo.CheckBox1.Checked = info.TravToEnabled : chkTravTo.lcDateTimePicker.Value = info.TravTo

        chkRegMonths.CheckBox1.Checked = info.RegMonthsEnabled : chkRegMonths.TextBox1.Text = info.RegMonths
        chkTravMonths.CheckBox1.Checked = info.TravMonthsEnabled : chkTravMonths.TextBox1.Text = info.TravMonths

        ' Nights before Days: setting txtDays rebuilds the Day By Day list,
        ' which reads txtNights.
        txtNights.Text = info.Nights.ToString()
        txtDays.Text = info.Days.ToString()
    End Sub

    ' =========================================================================
    '  ToolStrip1: Save Tree / Load Tree / Clear Tree
    '  Only trips (TripRootNode) and their versions (TravelFormData) are saved.
    '  Older TravelOffers nodes from the first toolstrip button are skipped.
    ' =========================================================================

    Private Sub tsbSaveTree_Click(sender As Object, e As EventArgs) Handles tsbSaveTree.Click
        Dim treeFile As New TreeFileDto()

        For Each n As TreeNode In TreeView1.Nodes
            Dim root As TripRootNode = TryCast(n, TripRootNode)
            If root Is Nothing Then Continue For

            Dim trip As New TripDto With {
                .TitleEnabled = root.Title.IsEnabled, .Title = root.Title.Text,
                .SubTitleEnabled = root.SubTitle.IsEnabled, .SubTitle = root.SubTitle.Text}

            For Each child As TreeNode In root.Nodes
                Dim v As TravelFormData = TryCast(child, TravelFormData)
                If v IsNot Nothing Then trip.Versions.Add(VersionToDto(v))
            Next
            treeFile.Trips.Add(trip)
        Next

        If treeFile.Trips.Count = 0 Then
            MessageBox.Show("There are no trips in the tree to save.")
            Exit Sub
        End If

        Using dlg As New SaveFileDialog With {
                .Filter = "Trip tree (*.xml)|*.xml|All files (*.*)|*.*",
                .FileName = "Trips.xml"}
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            Try
                Dim serializer As New XmlSerializer(GetType(TreeFileDto))
                Using writer As New StreamWriter(dlg.FileName)
                    serializer.Serialize(writer, treeFile)
                End Using
                MessageBox.Show("Tree saved (" & treeFile.Trips.Count & " trip(s)).")
            Catch ex As Exception
                MessageBox.Show("Could not save the tree:" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub tsbLoadTree_Click(sender As Object, e As EventArgs) Handles tsbLoadTree.Click
        If TreeView1.Nodes.Count > 0 AndAlso
           MessageBox.Show("Loading will replace the current tree. Continue?", "Load Tree",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Using dlg As New OpenFileDialog With {
                .Filter = "Trip tree (*.xml)|*.xml|All files (*.*)|*.*"}
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            Dim treeFile As TreeFileDto
            Try
                Dim serializer As New XmlSerializer(GetType(TreeFileDto))
                Using reader As New StreamReader(dlg.FileName)
                    treeFile = CType(serializer.Deserialize(reader), TreeFileDto)
                End Using
            Catch ex As Exception
                MessageBox.Show("Could not read the tree treeFile:" & vbCrLf & ex.Message)
                Exit Sub
            End Try

            ClearTreeAndForm()

            TreeView1.BeginUpdate()
            For Each trip As TripDto In treeFile.Trips
                Dim root As New TripRootNode(
                    New TitleField(trip.TitleEnabled, trip.Title),
                    New TitleField(trip.SubTitleEnabled, trip.SubTitle))
                For Each v As VersionDto In trip.Versions
                    root.Nodes.Add(DtoToVersion(v))
                Next
                TreeView1.Nodes.Add(root)
            Next
            TreeView1.ExpandAll()
            TreeView1.EndUpdate()
        End Using
    End Sub

    Private Sub tsbClearTree_Click(sender As Object, e As EventArgs) Handles tsbClearTree.Click
        If TreeView1.Nodes.Count = 0 Then Exit Sub
        If MessageBox.Show("Delete the whole tree and start anew?" & vbCrLf &
                           "Anything not saved with ""Save Tree"" will be lost.", "Clear Tree",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If
        ClearTreeAndForm()
    End Sub

    ''' <summary>Empties the tree and the Title / TabPage1 fields.</summary>
    Private Sub ClearTreeAndForm()
        TreeView1.Nodes.Clear()
        SetCurrentVersion(Nothing)
        ResetCitiesStayAttraction()
        txbxTripTitle.TextBox1.Text = ""
        txbxTripSubTitle.TextBox1.Text = ""
    End Sub

    Private Function VersionToDto(v As TravelFormData) As VersionDto
        Dim d As New VersionDto With {
            .Text = v.Text,
            .TitleEnabled = v.Title.IsEnabled, .Title = v.Title.Text,
            .SubTitleEnabled = v.SubTitle.IsEnabled, .SubTitle = v.SubTitle.Text}

        d.Countries.AddRange(v.Countries.Select(Function(c) c.Name))
        For Each c In v.Cities
            d.Cities.Add(New CityDto With {.Name = c.Name, .State = CInt(c.State)})
        Next
        d.Stays.AddRange(v.Stays.Select(Function(s) s.Name))
        d.Attractions.AddRange(v.Attractions.Select(Function(a) a.Name))

        Dim extras As VersionExtras = TryCast(v.Tag, VersionExtras)
        If extras IsNot Nothing Then
            If extras.DepartureArrival IsNot Nothing Then
                d.DepartureArrival = DepartureArrivalDto.FromInfo(extras.DepartureArrival)
            End If
            If extras.Legs IsNot Nothing Then
                d.LegsSaved = True
                For Each leg As Object In extras.Legs
                    d.Legs.Add(LegDto.FromLeg(leg))
                Next
            End If
            d.Including = extras.Including
        End If
        Return d
    End Function

    Private Function DtoToVersion(d As VersionDto) As TravelFormData
        Dim v As New TravelFormData()
        v.Title = New TitleField(d.TitleEnabled, d.Title)
        v.SubTitle = New TitleField(d.SubTitleEnabled, d.SubTitle)

        For Each name As String In d.Countries
            v.Countries.Add(New CheckListItem(name:=name, isChecked:=True))
        Next
        For Each c As CityDto In d.Cities
            v.Cities.Add(New CityListItem(name:=c.Name, state:=CType(c.State, TriState)))
        Next
        For Each name As String In d.Stays
            v.Stays.Add(New CheckListItem(name:=name, isChecked:=True))
        Next
        For Each name As String In d.Attractions
            v.Attractions.Add(New CheckListItem(name:=name, isChecked:=True))
        Next

        If d.DepartureArrival IsNot Nothing OrElse d.LegsSaved OrElse d.Including IsNot Nothing Then
            Dim extras As New VersionExtras()
            If d.DepartureArrival IsNot Nothing Then extras.DepartureArrival = d.DepartureArrival.ToInfo()
            If d.LegsSaved Then extras.Legs = d.Legs.Select(Function(l) l.ToLeg()).ToList()
            extras.Including = d.Including
            v.Tag = extras
        End If
        v.Text = d.Text
        Return v
    End Function

    Private Sub BtnSaveDepartureAndArrival_Click(sender As Object, e As EventArgs) Handles btnSaveDepartureAndArrival.Click
        Dim mode As DuringFilterMode = If(TabControl5.SelectedTab Is tabSpecificDates,
                                           DuringFilterMode.SpecificDates,
                                           DuringFilterMode.MonthsNames)

        Dim filter = BookingSearchFilter.FromForm(
            mode,
            chkRegFrom.CheckBox1.Checked, chkRegFrom.lcDateTimePicker.Value,
            chkRegTo.CheckBox1.Checked, chkRegTo.lcDateTimePicker.Value,
            chkTravFrom.CheckBox1.Checked, chkTravFrom.lcDateTimePicker.Value,
            chkTravTo.CheckBox1.Checked, chkTravTo.lcDateTimePicker.Value,
            chkRegMonths.CheckBox1.Checked, chkRegMonths.TextBox1.Text,
            chkTravMonths.CheckBox1.Checked, chkTravMonths.TextBox1.Text,
            CInt(txtNights.Text), CInt(txtDays.Text))

        Dim errMsg As String = ""
        If Not filter.IsValid(errMsg) Then
            MessageBox.Show(errMsg)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim data As New PricingItem.PricingCollection

        Dim tabPage As TabPage = TabControl1.TabPages("Including") ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find("Panel2", True) ' True = search nested controls too
        Dim pnl As Panel = CType(found(0), Panel)


        For Each ctl As Control In pnl.Controls

            If TypeOf ctl Is PricingWithCheckBox.PricingWithCheckBox Then
                data.Add(DirectCast(ctl, PricingWithCheckBox.PricingWithCheckBox).ToPricingItem())
            End If

        Next

        SavePricing("Pricing.txt", data)
    End Sub



    Public Sub SavePricing(fileName As String, pricing As PricingItem.PricingCollection)

        Dim serializer As New XmlSerializer(GetType(PricingItem.PricingCollection))

        Using writer As New StreamWriter(fileName)
            serializer.Serialize(writer, pricing)
        End Using

    End Sub

    Public Function LoadPricing(fileName As String) As PricingItem.PricingCollection

        If Not File.Exists(fileName) Then
            Return New PricingItem.PricingCollection()
        End If

        Dim serializer As New XmlSerializer(GetType(PricingItem.PricingCollection))

        Using reader As New StreamReader(fileName)
            Return CType(serializer.Deserialize(reader), PricingItem.PricingCollection)
        End Using

    End Function

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim pricing = LoadPricing("Pricing.txt")

        Dim index As Integer = 0

        Dim tabPage As TabPage = TabControl1.TabPages("Including") ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find("Panel2", True) ' True = search nested controls too
        Dim pnl As Panel = CType(found(0), Panel)


        For Each ctl As Control In pnl.Controls

            If TypeOf ctl Is PricingWithCheckBox.PricingWithCheckBox Then

                If index < pricing.Count Then
                    DirectCast(ctl, PricingWithCheckBox.PricingWithCheckBox).FromPricingItem(pricing(index))
                    index += 1
                End If

            End If

        Next
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim pricing As New PricingItem.PricingCollection
        Dim tabPage As TabPage = TabControl1.TabPages("Including") ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find("Panel2", True) ' True = search nested controls too
        Dim pnl As Panel = CType(found(0), Panel)

        For Each c As Control In pnl.Controls
            If TypeOf c Is PricingWithCheckBox.PricingWithCheckBox Then
                pricing.Add(DirectCast(c, PricingWithCheckBox.PricingWithCheckBox).Pricing)
            End If
        Next

        SavePricing("Pricing.txt", pricing)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim i As Integer = 0
        Dim pricing = LoadPricing("Pricing.txt")

        Dim tabPage As TabPage = TabControl1.TabPages("Including") ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find("Panel2", True) ' True = search nested controls too
        Dim pnl As Panel = CType(found(0), Panel)

        For Each c As Control In pnl.Controls
            If TypeOf c Is PricingWithCheckBox.PricingWithCheckBox AndAlso i < pricing.Count Then
                DirectCast(c, PricingWithCheckBox.PricingWithCheckBox).Pricing = pricing(i)
                i += 1
            End If
        Next

    End Sub
End Class

Public Class Flight
    Public Property TransferMean As String = String.Empty
    Public Property Title As String = String.Empty
    Public Property DepartureFrom As TextValueParent   ' Country
    Public Property DepartureCity As TextValueParent   ' City    ← NEW
    Public Property DeparturePoint As TextValueParent   ' Airport
    Public Property DepartureDate As Date
    Public Property DepartureTime As TimeSpan
    Public Property AirLine As TextValueParent
    Public Property ArrivingTo As TextValueParent   ' Country
    Public Property ArrivalCity As TextValueParent   ' City    ← NEW
    Public Property ArrivalPoint As TextValueParent   ' Airport
    Public Property ArrivalDate As Date
    Public Property ArrivalTime As TimeSpan
    Public Property Duration As String = String.Empty

    ' Checkbox of each control on the Move tab: True = active / included.
    ' Default True so items made before these existed count as active.
    Public Property DepartureFromActive As Boolean = True
    Public Property DepartureCityActive As Boolean = True
    Public Property DeparturePointActive As Boolean = True
    Public Property DepartureDateActive As Boolean = True
    Public Property DepartureTimeActive As Boolean = True
    Public Property AirLineActive As Boolean = True
    Public Property ArrivingToActive As Boolean = True
    Public Property ArrivalCityActive As Boolean = True
    Public Property ArrivalPointActive As Boolean = True
    Public Property ArrivalDateActive As Boolean = True
    Public Property ArrivalTimeActive As Boolean = True

    Public Sub New()
    End Sub

    Public Sub New(
        TransferMean As String,
        Title As String,
        departureFrom As TextValueParent,
        departureCity As TextValueParent,
        departureAirport As TextValueParent,
        DepartureDate As DateTime,
        DepartureTime As TimeSpan,
        AirLine As TextValueParent,
        arrivingTo As TextValueParent,
        arrivalCity As TextValueParent,
        ArrivalAirport As TextValueParent,
        ArrivalDate As DateTime,
        arrivalTime As TimeSpan,
        Duration As String
    )
        Me.TransferMean = TransferMean
        Me.Title = Title
        Me.DepartureFrom = departureFrom
        Me.DepartureCity = departureCity
        Me.DeparturePoint = departureAirport
        Me.DepartureDate = DepartureDate
        Me.DepartureTime = DepartureTime
        Me.AirLine = AirLine
        Me.ArrivingTo = arrivingTo
        Me.ArrivalCity = arrivalCity
        Me.ArrivalPoint = ArrivalAirport
        Me.ArrivalDate = ArrivalDate
        Me.ArrivalTime = arrivalTime
        Me.Duration = Duration
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}", Title)
    End Function

End Class

Public Class LayOver

    Public Property Title As String = String.Empty
    Public Property DepartureDate As Date
    Public Property DepartureTime As TimeSpan

    Public Property ArrivalDate As Date
    Public Property ArrivalTime As TimeSpan

    Public Property Duration As String = String.Empty


    Public Sub New()
    End Sub

    Public Sub New(
        title As String,
        DepartureDate As DateTime,
        DepartureTime As TimeSpan,
        ArrivalDate As DateTime,
        arrivalTime As TimeSpan,
        Duration As String
    )
        Me.Title = title
        Me.DepartureDate = DepartureDate
        Me.DepartureTime = DepartureTime
        Me.ArrivalDate = ArrivalDate
        Me.ArrivalTime = arrivalTime
        Me.Duration = Duration

    End Sub

    Public Overrides Function ToString() As String
        Return String.Format(
            "{0}",
            Title
        )
    End Function

End Class

Public Class TextValueParent
    Private _DateAndDaration As DatesAndDuration = Nothing
    Public Text As String
    Public ID As String
    Public parentID As String

    Public Overrides Function ToString() As String 'this is the heart of the mission
        Return Text
    End Function

    Sub New(ByVal Text As String,
            ByVal ID As String,
            Optional ParentID As String = "")
        Me.Text = Text
        Me.ID = ID
        If ParentID <> "" Then
            Me.parentID = ParentID
        End If
    End Sub

    Public DateAndDaration As DatesAndDuration

    'Public Overrides Function ToString() As String 'this is the heart of the mission
    '    Return _Title
    'End Function
End Class




' =============================================================================
'  Save Tree file format (XML). Plain public classes so XmlSerializer can
'  write them; converted to/from the tree nodes in Form1.
' =============================================================================

Public Class TreeFileDto
    Public Property Trips As New List(Of TripDto)
End Class

Public Class TripDto
    Public Property TitleEnabled As Boolean
    Public Property Title As String = ""
    Public Property SubTitleEnabled As Boolean
    Public Property SubTitle As String = ""
    Public Property Versions As New List(Of VersionDto)
End Class

Public Class VersionDto
    Public Property Text As String = ""
    Public Property TitleEnabled As Boolean
    Public Property Title As String = ""
    Public Property SubTitleEnabled As Boolean
    Public Property SubTitle As String = ""
    Public Property Countries As New List(Of String)
    Public Property Cities As New List(Of CityDto)
    Public Property Stays As New List(Of String)
    Public Property Attractions As New List(Of String)
    Public Property DepartureArrival As DepartureArrivalDto   ' Nothing = not saved
    Public Property LegsSaved As Boolean                      ' False = legs never saved
    Public Property Legs As New List(Of LegDto)
    ' Including tab rows, same XML format as Pricing.txt (Nothing = not saved)
    Public Property Including As PricingItem.PricingCollection
End Class

''' <summary>One Flight or LayOver from ListBox1 (Kind tells which).</summary>
Public Class LegDto
    Public Property Kind As String = "Flight"   ' "Flight" or "LayOver"
    Public Property TransferMean As String = ""
    Public Property Title As String = ""
    Public Property DepartureFrom As TvpDto
    Public Property DepartureCity As TvpDto
    Public Property DeparturePoint As TvpDto
    Public Property DepartureDate As Date
    Public Property DepartureTimeTicks As Long   ' TimeSpan isn't XML-serializable
    Public Property AirLine As TvpDto
    Public Property ArrivingTo As TvpDto
    Public Property ArrivalCity As TvpDto
    Public Property ArrivalPoint As TvpDto
    Public Property ArrivalDate As Date
    Public Property ArrivalTimeTicks As Long
    Public Property Duration As String = ""

    ' Flight only: checkbox of each Move-tab control. Default True so
    ' files saved before these existed load as all-active.
    Public Property DepartureFromActive As Boolean = True
    Public Property DepartureCityActive As Boolean = True
    Public Property DeparturePointActive As Boolean = True
    Public Property DepartureDateActive As Boolean = True
    Public Property DepartureTimeActive As Boolean = True
    Public Property AirLineActive As Boolean = True
    Public Property ArrivingToActive As Boolean = True
    Public Property ArrivalCityActive As Boolean = True
    Public Property ArrivalPointActive As Boolean = True
    Public Property ArrivalDateActive As Boolean = True
    Public Property ArrivalTimeActive As Boolean = True

    Public Shared Function FromLeg(leg As Object) As LegDto
        Dim f As Flight = TryCast(leg, Flight)
        If f IsNot Nothing Then
            Return New LegDto With {
                .Kind = "Flight", .TransferMean = If(f.TransferMean, ""), .Title = f.Title,
                .DepartureFrom = TvpDto.From(f.DepartureFrom), .DepartureCity = TvpDto.From(f.DepartureCity),
                .DeparturePoint = TvpDto.From(f.DeparturePoint),
                .DepartureDate = f.DepartureDate, .DepartureTimeTicks = f.DepartureTime.Ticks,
                .AirLine = TvpDto.From(f.AirLine),
                .ArrivingTo = TvpDto.From(f.ArrivingTo), .ArrivalCity = TvpDto.From(f.ArrivalCity),
                .ArrivalPoint = TvpDto.From(f.ArrivalPoint),
                .ArrivalDate = f.ArrivalDate, .ArrivalTimeTicks = f.ArrivalTime.Ticks,
                .Duration = f.Duration,
                .DepartureFromActive = f.DepartureFromActive,
                .DepartureCityActive = f.DepartureCityActive,
                .DeparturePointActive = f.DeparturePointActive,
                .DepartureDateActive = f.DepartureDateActive,
                .DepartureTimeActive = f.DepartureTimeActive,
                .AirLineActive = f.AirLineActive,
                .ArrivingToActive = f.ArrivingToActive,
                .ArrivalCityActive = f.ArrivalCityActive,
                .ArrivalPointActive = f.ArrivalPointActive,
                .ArrivalDateActive = f.ArrivalDateActive,
                .ArrivalTimeActive = f.ArrivalTimeActive}
        End If

        Dim l As LayOver = DirectCast(leg, LayOver)
        Return New LegDto With {
            .Kind = "LayOver", .Title = l.Title,
            .DepartureDate = l.DepartureDate, .DepartureTimeTicks = l.DepartureTime.Ticks,
            .ArrivalDate = l.ArrivalDate, .ArrivalTimeTicks = l.ArrivalTime.Ticks,
            .Duration = l.Duration}
    End Function

    Public Function ToLeg() As Object
        If Kind = "LayOver" Then
            Return New LayOver(Title, DepartureDate, New TimeSpan(DepartureTimeTicks),
                               ArrivalDate, New TimeSpan(ArrivalTimeTicks), Duration)
        End If
        Dim fl As New Flight(TransferMean, Title,
                          TvpDto.ToTvp(DepartureFrom), TvpDto.ToTvp(DepartureCity), TvpDto.ToTvp(DeparturePoint),
                          DepartureDate, New TimeSpan(DepartureTimeTicks),
                          TvpDto.ToTvp(AirLine),
                          TvpDto.ToTvp(ArrivingTo), TvpDto.ToTvp(ArrivalCity), TvpDto.ToTvp(ArrivalPoint),
                          ArrivalDate, New TimeSpan(ArrivalTimeTicks),
                          Duration)
        fl.DepartureFromActive = DepartureFromActive
        fl.DepartureCityActive = DepartureCityActive
        fl.DeparturePointActive = DeparturePointActive
        fl.DepartureDateActive = DepartureDateActive
        fl.DepartureTimeActive = DepartureTimeActive
        fl.AirLineActive = AirLineActive
        fl.ArrivingToActive = ArrivingToActive
        fl.ArrivalCityActive = ArrivalCityActive
        fl.ArrivalPointActive = ArrivalPointActive
        fl.ArrivalDateActive = ArrivalDateActive
        fl.ArrivalTimeActive = ArrivalTimeActive
        Return fl
    End Function
End Class

''' <summary>A TextValueParent (combo item) in the file.</summary>
Public Class TvpDto
    Public Property Text As String = ""
    Public Property ID As String = ""
    Public Property ParentID As String = ""

    Public Shared Function From(t As TextValueParent) As TvpDto
        If t Is Nothing Then Return Nothing
        Return New TvpDto With {.Text = If(t.Text, ""), .ID = If(t.ID, ""), .ParentID = If(t.parentID, "")}
    End Function

    Public Shared Function ToTvp(d As TvpDto) As TextValueParent
        If d Is Nothing Then Return Nothing
        Return New TextValueParent(Text:=d.Text, ID:=d.ID, ParentID:=d.ParentID)
    End Function
End Class

Public Class CityDto
    Public Property Name As String = ""
    Public Property State As Integer   ' 0 Unchecked, 1 Checked, 2 Indeterminate
End Class

Public Class DepartureArrivalDto
    Public Property SpecificDates As Boolean   ' False = Months Names
    Public Property RegFromEnabled As Boolean
    Public Property RegFrom As Date
    Public Property RegToEnabled As Boolean
    Public Property RegTo As Date
    Public Property TravFromEnabled As Boolean
    Public Property TravFrom As Date
    Public Property TravToEnabled As Boolean
    Public Property TravTo As Date
    Public Property RegMonthsEnabled As Boolean
    Public Property RegMonths As String = ""
    Public Property TravMonthsEnabled As Boolean
    Public Property TravMonths As String = ""
    Public Property Nights As Integer
    Public Property Days As Integer

    Friend Shared Function FromInfo(i As DepartureArrivalInfo) As DepartureArrivalDto
        Return New DepartureArrivalDto With {
            .SpecificDates = (i.Mode = DuringFilterMode.SpecificDates),
            .RegFromEnabled = i.RegFromEnabled, .RegFrom = i.RegFrom,
            .RegToEnabled = i.RegToEnabled, .RegTo = i.RegTo,
            .TravFromEnabled = i.TravFromEnabled, .TravFrom = i.TravFrom,
            .TravToEnabled = i.TravToEnabled, .TravTo = i.TravTo,
            .RegMonthsEnabled = i.RegMonthsEnabled, .RegMonths = i.RegMonths,
            .TravMonthsEnabled = i.TravMonthsEnabled, .TravMonths = i.TravMonths,
            .Nights = i.Nights, .Days = i.Days}
    End Function

    Friend Function ToInfo() As DepartureArrivalInfo
        Return New DepartureArrivalInfo With {
            .Mode = If(SpecificDates, DuringFilterMode.SpecificDates, DuringFilterMode.MonthsNames),
            .RegFromEnabled = RegFromEnabled, .RegFrom = RegFrom,
            .RegToEnabled = RegToEnabled, .RegTo = RegTo,
            .TravFromEnabled = TravFromEnabled, .TravFrom = TravFrom,
            .TravToEnabled = TravToEnabled, .TravTo = TravTo,
            .RegMonthsEnabled = RegMonthsEnabled, .RegMonths = RegMonths,
            .TravMonthsEnabled = TravMonthsEnabled, .TravMonths = TravMonths,
            .Nights = Nights, .Days = Days}
    End Function
End Class

''' <summary>
''' Extra data kept on a version node (node.Tag), next to its TabPage1 lists.
''' Nothing in a property = that part was never saved for this version.
''' </summary>
Class VersionExtras
    Public Property DepartureArrival As DepartureArrivalInfo
    Public Property Legs As List(Of Object)   ' Flight / LayOver items from ListBox1
    Public Property Including As PricingItem.PricingCollection   ' Including tab rows (Panel2)

    Public Function Clone() As VersionExtras
        Return New VersionExtras With {
            .DepartureArrival = If(DepartureArrival Is Nothing, Nothing, DepartureArrival.Clone()),
            .Legs = If(Legs Is Nothing, Nothing, New List(Of Object)(Legs)),
            .Including = CopyPricing(Including)}
    End Function

    Private Shared Function CopyPricing(src As PricingItem.PricingCollection) As PricingItem.PricingCollection
        If src Is Nothing Then Return Nothing
        Dim copy As New PricingItem.PricingCollection()
        For Each item As PricingItem.PricingItem In src
            copy.Add(item)
        Next
        Return copy
    End Function
End Class

''' <summary>
''' Departure &amp; Arrival tab values saved on a version node:
''' TabControl5 mode + its date / month fields, nights and days.
''' </summary>
Class DepartureArrivalInfo
    Public Property Mode As DuringFilterMode

    ' Specific Dates tab
    Public Property RegFromEnabled As Boolean
    Public Property RegFrom As Date
    Public Property RegToEnabled As Boolean
    Public Property RegTo As Date
    Public Property TravFromEnabled As Boolean
    Public Property TravFrom As Date
    Public Property TravToEnabled As Boolean
    Public Property TravTo As Date

    ' Months Names tab
    Public Property RegMonthsEnabled As Boolean
    Public Property RegMonths As String = ""
    Public Property TravMonthsEnabled As Boolean
    Public Property TravMonths As String = ""

    ' Duration
    Public Property Nights As Integer
    Public Property Days As Integer

    Public Function Clone() As DepartureArrivalInfo
        Return DirectCast(Me.MemberwiseClone(), DepartureArrivalInfo)
    End Function
End Class

''' <summary>
''' Root node of a trip in TreeView1, created by Button8 on the
''' "Title And Sub Title" tab. Its children are TravelFormData versions.
''' </summary>
Class TripRootNode
    Inherits TreeNode

    Public Property Title As TitleField
    Public Property SubTitle As TitleField

    Public Sub New(title As TitleField, subTitle As TitleField)
        Me.Title = title
        Me.SubTitle = subTitle
        Me.Text = title.Text
    End Sub
End Class

Class TravelOffers
    Inherits TreeNode

    Public CategoryName As Categories

    Public Countries As New listOfTwoPairs
    Public Cities As New listOfTwoPairs
    Public Stay As New listOfTwoPairs
    Public TravelWays As New listOfTwoPairs

    Sub New(ByVal lcList As listOfTwoPairs, ByVal lcCategory As Categories)
        CategoryName = lcCategory

        Select Case lcCategory
            Case Categories.Countries
                Me.Countries = lcList
            Case Categories.Cities
                Me.Cities = lcList
            Case Categories.Stay
                Me.Stay = lcList
            Case Categories.TravelWays
        End Select

        Me.Text = lcCategory.ToString & "-[" & Join(lcList.arrText, ", ") & "]"
    End Sub

End Class

Public Enum Categories
    Countries
    Cities
    Stay
    TravelWays
End Enum



Public Class DatesAndDuration
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property NoOFDays As Integer
    Public Property NoOFNights As Integer

    Sub New()

    End Sub

    Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByVal NoOFDays As Integer, ByVal NoOFNights As Integer)
        Me.StartDate = StartDate
        Me.EndDate = EndDate
        Me.NoOFDays = NoOFDays
        Me.NoOFNights = NoOFNights
    End Sub
End Class