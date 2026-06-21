Imports System.IO

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
    cmbxDepartureFrom,
    "SELECT DISTINCT c.CountryID, c.CountryNameen " &
    "FROM DesCountry c " &
    "INNER JOIN AirPorts a ON a.CountryCode = c.CountryID " &
    "ORDER BY c.CountryNameen",
    "CountryID", "CountryNameen")

        ' Countries with airports (Arrival)
        LoadComboBox(
    cmbxArrivingTo,
    "SELECT DISTINCT c.CountryID, c.CountryNameen " &
    "FROM DesCountry c " &
    "INNER JOIN AirPorts a ON a.CountryCode = c.CountryID " &
    "ORDER BY c.CountryNameen",
    "CountryID", "CountryNameen")

        ' Airlines
        LoadComboBox(
    cmbxAirLine,
    "SELECT AirlineID, AirLineName FROM Airlines ORDER BY AirLineName",
    "AirlineID", "AirLineName")


        LoadServicesIntoTab("Including")
        LoadServicesIntoTab("NotIncluding")
        '____________________________________________________________
        ListView1.Columns.Add("ID", 60)
        ListView1.Columns.Add("Name", 60 * 2)
        ListView1.Columns.Add("Age", 60)
        ListView1.Columns.Add("Email", 60 * 3)

        Dim J As New myListViewItem
        With J
            .Text = "2271"
            .SubItems.Add("Jaljool")
            .SubItems.Add(50)
            .SubItems.Add("Gmail")
            .ExtraNames = "Fatima AlHaddad|Fatima Mohammed|Roqaya|Elmeera"
            ListView1.Items.Add(J)

        End With

        Dim K As New myListViewItem
        With K
            .Text = "2323"
            .SubItems.Add("Nawalooh")
            .SubItems.Add(50)
            .SubItems.Add("Hotmail")
            .ExtraNames = "Nothing"
            ListView1.Items.Add(K)

        End With



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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Countries with airports (Arrival)
        LoadComboBox(
        cmbxDepartureLocation,
            "SELECT AirPortID,AirPortName " &
            " FROM AirPorts " &
            " where CountryCode = " & CType(cmbxDepartureFrom.SelectedItem, TextValueParent).ID,
            "AirPortID", "AirPortName")


    End Sub


    Private Sub ResetAllFields()
        ' Reset all fields
        txtTitle.Text = ""

        txbxDuration.Text = ""

        DepartureDate.Value = Now
        DepartureTime.Value = Now
        ArrivalDate.Value = Now
        ArrivalTime.Value = Now

        cmbxDepartureFrom.SelectedIndex = 0
        cmbxDepartureLocation.SelectedIndex = 0
        cmbxAirLine.SelectedIndex = 0
        cmbxArrivingTo.SelectedIndex = 0
        cmbxArrivingLocation.SelectedIndex = 0
    End Sub

    Private Sub CmbxArrivingTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxArrivingTo.SelectedIndexChanged
        If cmbxArrivingTo.SelectedItem Is Nothing Then Exit Sub
        Dim countryID As String = CType(cmbxArrivingTo.SelectedItem, TextValueParent).ID

        LoadComboBox(
        cmbxArrivingCity,
        "SELECT DISTINCT c.CityID, c.CityNameEn " &
        "FROM DesCities c " &
        "INNER JOIN CityAirports ca ON ca.CityID = c.CityID " &
        "WHERE c.CountryID = " & countryID &
        " ORDER BY c.CityNameEn",
        "CityID", "CityNameEn")
    End Sub

    Private Sub CmbxDepartureFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDepartureFrom.SelectedIndexChanged
        If cmbxDepartureFrom.SelectedItem Is Nothing Then Exit Sub
        Dim countryID As String = CType(cmbxDepartureFrom.SelectedItem, TextValueParent).ID

        LoadComboBox(
        cmbxDepartureCity,
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
            Panel2.Visible = False

            ' Switch to Flight tab in TabControl2
            TabControl2.SelectedTab = TabControl2.TabPages("tab" & F.TransferMean)

            ' Text fields
            txtTitle.Text = F.Title
            DepartureDate.Value = F.DepartureDate
            DepartureTime.Value = DepartureDate.Value.Add(F.DepartureTime)
            ArrivalDate.Value = F.ArrivalDate
            ArrivalTime.Value = ArrivalDate.Value.Add(F.ArrivalTime)
            txbxDuration.Text = F.Duration

            ' --- DEPARTURE ---
            ' Step 1: Set Country → triggers CmbxDepartureFrom_SelectedIndexChanged
            '         which reloads cmbxDepartureCity
            SetComboByID(cmbxDepartureFrom, F.DepartureFrom)

            ' Step 2: Set City → triggers CmbxDepartureCity_SelectedIndexChanged
            '         which reloads cmbxDepartureAirPort
            SetComboByID(cmbxDepartureCity, F.DepartureCity)

            ' Step 3: Set Airport (list is now populated by step 2)
            SetComboByID(cmbxDepartureLocation, F.DeparturePoint)

            ' --- AIRLINE ---
            SetComboByID(cmbxAirLine, F.AirLine)

            ' --- ARRIVING ---
            ' Step 1: Set Country → triggers CmbxArrivingTo_SelectedIndexChanged
            '         which reloads cmbxArrivingCity
            SetComboByID(cmbxArrivingTo, F.ArrivingTo)

            ' Step 2: Set City → triggers CmbxArrivingCity_SelectedIndexChanged
            '         which reloads cmbxArrivingPort
            SetComboByID(cmbxArrivingCity, F.ArrivalCity)

            ' Step 3: Set Airport (list is now populated by step 2)
            SetComboByID(cmbxArrivingLocation, F.ArrivalPoint)

        ElseIf L IsNot Nothing Then
            Panel2.Visible = True

            ' Switch to LayOver tab in TabControl2
            TabControl2.SelectedTab = TabControl2.TabPages("tabLayOver")

            txtTitle.Text = L.Title
            DateTimePicker1.Value = L.DepartureDate
            DateTimePicker2.Value = L.DepartureDate.Add(L.DepartureTime)
            DateTimePicker3.Value = L.ArrivalDate
            DateTimePicker4.Value = L.ArrivalDate.Add(L.ArrivalTime)
            txbxDuration.Text = L.Duration
        End If
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

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles tabAirCraft.Click

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If Panel2.Visible = False Then

            If TabControl2.SelectedTab.Name = "tabLayOver" Then
                Panel2.Visible = True
            Else
                Panel2.Visible = False
            End If

            Dim F As New Flight
            F.TransferMean = getChosedTransfer()
            F.Title = txtTitle.Text
            F.DepartureFrom = CType(cmbxDepartureFrom.SelectedItem, TextValueParent)
            F.DepartureCity = CType(cmbxDepartureCity.SelectedItem, TextValueParent)
            F.DeparturePoint = CType(cmbxDepartureLocation.SelectedItem, TextValueParent)
            F.DepartureDate = DepartureDate.Value.Date
            F.DepartureTime = TimeSpan.Parse(DepartureTime.Text)

            F.ArrivingTo = CType(cmbxArrivingTo.SelectedItem, TextValueParent)
            F.ArrivalCity = CType(cmbxArrivingCity.SelectedItem, TextValueParent)
            F.ArrivalPoint = CType(cmbxArrivingLocation.SelectedItem, TextValueParent)
            F.ArrivalDate = ArrivalDate.Value.Date
            F.ArrivalTime = TimeSpan.Parse(ArrivalTime.Text)

            If TabControl2.SelectedTab.Name = "tabAirCraft" Then
                F.AirLine = CType(cmbxAirLine.SelectedItem, TextValueParent)
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
        Dim TransferMean As String = TabControl2.SelectedTab.Name
        TransferMean = TransferMean.Replace("tab", "")
        getChosedTransfer = TransferMean
    End Function

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

        Try
            Panel2.Visible = False
            cmbxAirLine.Visible = False
            Label9.Visible = False
            Select Case TabControl2.SelectedTab.Name
                Case "tabLayOver"
                    Panel2.Visible = True
                Case "tabAirCraft"
                    cmbxAirLine.Visible = True
                    Label9.Visible = True
                Case Else

            End Select

            LoadLocationComboBox(cmbxDepartureCity, cmbxDepartureLocation)
            LoadLocationComboBox(cmbxArrivingCity, cmbxArrivingLocation)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try

            If TabControl1.SelectedTab.Name = "DayByDay" And ListBox2.Items.Count = 0 Then
                Dim S As Date = DateWithCheckBox4.lcDateTimePicker.Value

                For I As Integer = 1 To CInt(TextBox12.Text)
                    Dim day As String = String.Format("Day {0}", I)
                    If TabControl5.SelectedTab.Name = "TabPage16" Then
                        day = day & String.Format(" (" & S.ToString("yyyy-MM-dd") & ")")
                    End If
                    ListBox2.Items.Add(day)
                    S = S.AddDays(1)
                Next

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DateTimePicker6_Leave(sender As Object, e As EventArgs)
    End Sub

    Private Sub CmbxDepartureCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDepartureCity.SelectedIndexChanged
        LoadLocationComboBox(cmbxDepartureCity, cmbxDepartureLocation)
    End Sub

    Private Sub CmbxArrivingCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxArrivingCity.SelectedIndexChanged
        LoadLocationComboBox(cmbxArrivingCity, cmbxArrivingLocation)

    End Sub

    Private Sub LoadLocationComboBox(cmbxCity As ComboBox, cmbxLocation As ComboBox)

        If cmbxCity.SelectedItem Is Nothing Then Exit Sub

        Dim cityID As String = CType(cmbxCity.SelectedItem, TextValueParent).ID

        Dim categoryFilter As String = ""
        Select Case TabControl2.SelectedTab.Name
            Case "tabAirCraft" : categoryFilter = " AND Category = 'AirPort'"
            Case "tabTrain" : categoryFilter = " AND Category = 'Train'"
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

        If Panel2.Visible = False Then
            If F IsNot Nothing Then
                'Flight is Found
                DepartureDate.Value = F.ArrivalDate
                DepartureTime.Value = F.ArrivalDate.Add(F.ArrivalTime)
            Else
                DepartureDate.Value = L.ArrivalDate
                DepartureTime.Value = L.ArrivalDate.Add(L.ArrivalTime)

                lastItem = ListBox1.Items(ListBox1.Items.Count - 2)
                F = TryCast(lastItem, Flight)
            End If

            SetComboByID(cmbxDepartureFrom, F.ArrivingTo)
            SetComboByID(cmbxDepartureCity, F.ArrivalCity)
            SetComboByID(cmbxDepartureLocation, F.ArrivalPoint)
        Else
            DateTimePicker1.Value = F.ArrivalDate
            DateTimePicker2.Value = F.ArrivalDate.Add(F.ArrivalTime)
        End If

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        OpenAddLocations(cmbxArrivingTo, cmbxArrivingCity, cmbxArrivingLocation)
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        ' For Departure
        OpenAddLocations(cmbxDepartureFrom, cmbxDepartureCity, cmbxDepartureLocation)
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
            Select Case TabControl2.SelectedTab.Name
                Case "tabFlight" : categoryFilter = " AND Category = 'AirPort'"
                Case "tabTrain" : categoryFilter = " AND Category = 'Train'"
                Case "tabBus" : categoryFilter = " AND Category = 'Bus'"
            End Select

            Dim SQL As String =
                "SELECT a.ID, a.LocationName " &
                "FROM Locations a " &
                "WHERE CityCode = " & F.CityID &
                categoryFilter

            LoadComboBox(cmbxLocation, SQL, "ID", "LocationName")

        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Dim A As ListViewItem = ListView1.SelectedItems(0)
            MsgBox(CType(A, myListViewItem).ExtraNames)
        Catch ex As Exception

        End Try

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
        Catch ex As Exception

        End Try
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
            Case Categories.Cities
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


Public Class myListViewItem
    Inherits ListViewItem

    Public Property ExtraNames As String

End Class

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