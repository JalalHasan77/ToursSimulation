Imports System.IO
Imports ToursSimulatorNestedClass.TravelForm.Models

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


        LoadServicesIntoTab("Including")
        LoadServicesIntoTab("NotIncluding")
        '____________________________________________________________
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

        If SourceList.GetItemChecked(SourceList.SelectedIndex) Then

            ' BUGFIX: SelectedIndexChanged can fire more than once for the
            ' same already-checked item (e.g. CheckOnClick selecting AND
            ' checking the row in the same click, or simply re-selecting a
            ' city that is already checked). Without this guard, the title
            ' + rows below get appended again on every extra firing, which
            ' is exactly what produced the duplicated Stay / Attraction
            ' entries. Clearing out anything already loaded for this parent
            ' first makes the load idempotent no matter how many times this
            ' runs for the same checked item.
            RemoveItemsByParentID(TargetList, CurrentSelectedItem.ID)

            ' Add fake title
            Dim i As New TextValueParent(
                Text:="----" & CurrentSelectedItem.Text & "----",
                ID:="",
                ParentID:=CurrentSelectedItem.ID)

            TargetList.Items.Add(i)

            Dim SQL As String =
                String.Format(SqlTemplate, CurrentSelectedItem.ID)

            Dim DT As DataTable = GetDataTable(SQL)

            For Each DR As DataRow In DT.Rows
                i = New TextValueParent(
                    Text:=DR(TextField).ToString(),
                    ID:=DR(IDField).ToString(),
                    ParentID:=CurrentSelectedItem.ID)

                TargetList.Items.Add(i)
            Next
        Else
            If SourceList Is CheckedListBox1 Then
                RemoveCountryChildren(CurrentSelectedItem.ID)
            Else
                RemoveItemsByParentID(TargetList, CurrentSelectedItem.ID)
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
    ''' Cities/Stay/Attraction have no such pre-loaded master list, so their
    ''' rows are rebuilt from scratch using the saved Name/state.
    ''' TravelFormData's CheckListItem/CityListItem only expose Name and
    ''' IsChecked/State (TravelBasicInfo.vb) — there is no ID, ParentID or
    ''' IsHeader on those models, so matching/rebuilding below is done by
    ''' Name only, and the rebuilt TextValueParent rows get an empty ID.
    ''' SaveTabPage1Data only stores checked rows, so there's nothing to
    ''' restore for unchecked/header rows.
    ''' </remarks>
    Public Sub LoadTabPage1Data(data As TravelFormData)

        If data Is Nothing Then Exit Sub

        ' ---- Title / Sub Title ---------------------------------------------
        txbxTripTitle.CheckBox1.Checked = data.Title.IsEnabled
        txbxTripTitle.TextBox1.Text = data.Title.Text

        txbxTripSubTitle.CheckBox1.Checked = data.SubTitle.IsEnabled
        txbxTripSubTitle.TextBox1.Text = data.SubTitle.Text

        ' ---- Countries (CheckedListBox1) — flip checkmarks only -------------
        Dim checkedCountryNames As New HashSet(Of String)(
            data.Countries.Where(Function(c) c.IsChecked).Select(Function(c) c.Name))

        For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
            Dim tvp As TextValueParent = CType(CheckedListBox1.Items(idx), TextValueParent)
            CheckedListBox1.SetItemChecked(idx, checkedCountryNames.Contains(tvp.Text))
            CheckedListBox1.SelectedIndex = idx
            CheckedListBox1_SelectedIndexChanged(CheckedListBox1.Items(idx), EventArgs.Empty)
        Next

        ' ---- Cities (CheckedListBox2) — rebuilt, tri-state -------------------
        'CheckedListBox2.Items.Clear()

        For Each city In data.Cities
            For idx As Integer = 0 To CheckedListBox2.Items.Count - 1
                Dim tvp As TextValueParent = CType(CheckedListBox2.Items(idx), TextValueParent)
                If city.Name = CheckedListBox2.Items(idx).ToString Then
                    CheckedListBox2.SetItemChecked(idx, True)
                    CheckedListBox2.SelectedIndex = idx
                End If
            Next
        Next

        ' ---- Stay (CheckedListBox3) — rebuilt --------------------------------
        'CheckedListBox3.Items.Clear()
        'For Each stay In data.Stays
        '    Dim tvp As New TextValueParent(Text:=stay.Name, ID:="")
        '    Dim newIndex As Integer = CheckedListBox3.Items.Add(tvp)
        '    CheckedListBox3.SetItemChecked(newIndex, stay.IsChecked)
        'Next
        For Each stay In data.Stays
            For idx As Integer = 0 To CheckedListBox3.Items.Count - 1
                Dim tvp As TextValueParent = CType(CheckedListBox3.Items(idx), TextValueParent)
                If stay.Name = CheckedListBox3.Items(idx).ToString Then
                    CheckedListBox3.SetItemChecked(idx, True)
                    CheckedListBox3.SelectedIndex = idx
                End If
            Next
        Next


        ' ---- Attraction (CheckedListBox4) — rebuilt ---------------------------
        'CheckedListBox4.Items.Clear()
        'For Each attraction In data.Attractions
        '    Dim tvp As New TextValueParent(Text:=attraction.Name, ID:="")
        '    'Dim newIndex As Integer = CheckedListBox4.Items.Add(tvp)
        '    CheckedListBox4.SetItemChecked(newIndex, attraction.IsChecked)
        'Next
        For Each attraction In data.Attractions
            For idx As Integer = 0 To CheckedListBox4.Items.Count - 1
                Dim tvp As TextValueParent = CType(CheckedListBox4.Items(idx), TextValueParent)
                If attraction.Name = CheckedListBox4.Items(idx).ToString Then
                    CheckedListBox4.SetItemChecked(idx, True)
                    CheckedListBox4.SelectedIndex = idx
                End If
            Next
        Next


        CheckedListBox1.ClearSelected()
        CheckedListBox2.ClearSelected()
        CheckedListBox3.ClearSelected()
        CheckedListBox4.ClearSelected()

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



    Private Sub CmbxDepartureFrom_SelectedIndexChanged(sender As Object, e As EventArgs)
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
        If ListBox1.SelectedItem Is Nothing Then Exit Sub

        Dim selectedItem = ListBox1.SelectedItem
        Dim F As Flight = TryCast(selectedItem, Flight)
        Dim L As LayOver = TryCast(selectedItem, LayOver)

        If F IsNot Nothing Then
            ' Switch to Flight tab in TabControl2
            TabControl3.SelectedTab = TabControl3.TabPages("TabPage8")
            SelectRadioButtonByTag("Airplane")

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

        ElseIf L IsNot Nothing Then


            ' Switch to LayOver tab in TabControl2
            TabControl3.SelectedTab = TabControl3.TabPages("TabPage9")

            txtTitle.Text = L.Title
            DateTimePicker1.Value = L.DepartureDate
            DateTimePicker2.Value = L.DepartureDate.Add(L.DepartureTime)
            DateTimePicker3.Value = L.ArrivalDate
            DateTimePicker4.Value = L.ArrivalDate.Add(L.ArrivalTime)
            txbxDuration.Text = L.Duration
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

            Dim F As New Flight
            F.TransferMean = getChosedTransfer()
            SelectRadioButtonByTag(F.TransferMean)
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

            ' ── Calculate Duration ────────────────────────────────
            Dim DepartureDateTime As DateTime = F.DepartureDate.Add(F.DepartureTime)
            Dim ArrivalDateTime As DateTime = F.ArrivalDate.Add(F.ArrivalTime)
            Dim FlightDuration As TimeSpan = ArrivalDateTime - DepartureDateTime

            ' Display in MaskedTextBox1 as dd:HH:mm:ss
            txbxDuration.Text = String.Format("{0:0}:{1:0}:{2:0}:{3:0}",
                                    FlightDuration.Days,
                                    FlightDuration.Hours,
                                    FlightDuration.Minutes,
                                    FlightDuration.Seconds)
            ' ──────────────────────────────────────────────────────
            F.Duration = txbxDuration.Text
            ListBox1.Items.Add(F)

        Else
            Dim F As New LayOver
            F.Title = txtTitle.Text

            F.DepartureDate = DateTimePicker1.Value.Date
            F.DepartureTime = TimeSpan.Parse(DateTimePicker2.Text)

            F.ArrivalDate = DateTimePicker3.Value.Date
            F.ArrivalTime = TimeSpan.Parse(DateTimePicker4.Text)

            ' ── Calculate Duration ────────────────────────────────
            Dim DepartureDateTime As DateTime = F.DepartureDate.Add(F.DepartureTime)
            Dim ArrivalDateTime As DateTime = F.ArrivalDate.Add(F.ArrivalTime)
            Dim FlightDuration As TimeSpan = ArrivalDateTime - DepartureDateTime

            ' Display in MaskedTextBox1 as dd:HH:mm:ss
            MaskedTextBox1.Text = String.Format("{0:0}:{1:0}:{2:0}:{3:0}",
                                        FlightDuration.Days,
                                        FlightDuration.Hours,
                                        FlightDuration.Minutes,
                                        FlightDuration.Seconds)
            ' ──────────────────────────────────────────────────────

            F.Duration = txbxDuration.Text
            ListBox1.Items.Add(F)

        End If

        ResetAllFields()
    End Sub

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

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged



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
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ResetAllFields()

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

    Private Sub DateWithCheckBox8_ControlLeft(sender As Object, e As EventArgs) Handles DateWithCheckBox8.ControlLeft, DateWithCheckBox7.ControlLeft
        Try
            ' ── Calculate Duration ────────────────────────────────
            Dim EndDateTime As DateTime = DateWithCheckBox7.lcDateTimePicker.Value
            Dim StartDateTime As DateTime = DateWithCheckBox8.lcDateTimePicker.Value
            Dim FlightDuration As TimeSpan = EndDateTime - StartDateTime

            TextBox12.Text = EndDateTime.Subtract(StartDateTime).Days + 1
            TextBox13.Text = EndDateTime.Subtract(StartDateTime).Days
            ' ──────────────────────────────────────────────────────
            TextBox12_TextChanged(TextBox12, EventArgs.Empty)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        Try


            Dim S As Date = DateWithCheckBox8.lcDateTimePicker.Value

            For I As Integer = 1 To CInt(TextBox13.Text)
                Dim day As String = String.Format("Day {0}", I)
                If TabControl5.SelectedTab.Name = "TabPage16" Then
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

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim A As New TravelFormData
        A = SaveTabPage1Data()


        TreeView1.Nodes.Add(A)

        ResetCitiesStayAttraction()


    End Sub

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
        Dim data As TravelFormData = TryCast(node, TravelFormData)
        If data Is Nothing Then Exit Sub ' not a saved-trip node (e.g. a TravelOffers node) — nothing to load

        LoadTabPage1Data(data)
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        TreeView1.SelectedNode = e.Node
        LoadTabPage1DataFromTreeNode(e.Node)
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