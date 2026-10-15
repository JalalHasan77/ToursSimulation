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
        LoadExtendedServicesIntoTab("NotIncluding", "pnlNotIncluding") ' editable rows, left
        LoadServicesIntoTab("NotIncluding")                           ' old rows, right, disabled
        LoadVendors()                                                 ' Vendor tab
        '____________________________________________________________
    End Sub

    ''' <summary>
    ''' Fills a panel on the given tab with one PricingWithCheckBox row per
    ''' service (+ 6 blank rows). Including uses Panel2, Not Including uses
    ''' pnlNotIncluding.
    ''' </summary>
    Private Sub LoadExtendedServicesIntoTab(tabName As String, Optional panelName As String = "Panel2")
        Dim count As Integer = 0
        Dim iconBasePath As String = "D:\VB Projects\ToursSimulatorNestedClass\ToursSimulatorNestedClass\Icon\"
        Dim ServicesDT As DataTable = GetDataTable("Select * from Services")

        Dim tabPage As TabPage = TabControl1.TabPages(tabName) ' or TabControl1.TabPages("TabPage1")
        Dim found As Control() = tabPage.Controls.Find(panelName, True) ' True = search nested controls too
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

            ' Right-aligned and read-only: the editable rows are the
            ' PricingWithCheckBox list on the left of the tab.
            Dim page As TabPage = TabControl1.TabPages(tabName)
            uc.Location = New Point(page.ClientSize.Width - uc.Width - 10, 45 + 26 * count) ' below the Save button
            uc.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            uc.Enabled = False

            page.Controls.Add(uc)
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

    ''' <summary>
    ''' Right-click on a node: trips and versions get Open / Delete; the
    ''' older "offers" nodes keep their Countries / Cities / Stay menu.
    ''' </summary>
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button <> MouseButtons.Right Then Exit Sub
        TreeView1.SelectedNode = e.Node   ' select the node first
        If TypeOf e.Node Is TravelOffers Then
            ContextMenuStrip1.Show(TreeView1, e.Location)
        ElseIf TypeOf e.Node Is TripRootNode OrElse TypeOf e.Node Is TravelFormData Then
            mnuDuplicateNode.Visible = TypeOf e.Node Is TravelFormData   ' versions only
            ' Compare: shown when this version is one of 2+ Ctrl+clicked versions.
            Dim marked As Integer = _compareSet.Where(Function(v) IsOpen(v)).Count()
            mnuCompareText.Visible = marked >= 2 AndAlso _compareSet.Contains(TryCast(e.Node, TravelFormData))
            mnuCompareText.Text = "Compare and Show in Text (" & marked & " versions)"
            cmsTrip.Show(TreeView1, e.Location)
        End If
    End Sub

    Private Sub mnuOpenNode_Click(sender As Object, e As EventArgs) Handles mnuOpenNode.Click
        If TreeView1.SelectedNode IsNot Nothing Then OpenNode(TreeView1.SelectedNode)
    End Sub

    ''' <summary>
    ''' "Duplicate" (right-click a version): adds an independent copy of that
    ''' version under the same trip, with the next version number. It copies
    ''' what is saved in the version; the tabs on screen are not touched.
    ''' </summary>
    Private Sub mnuDuplicateNode_Click(sender As Object, e As EventArgs) Handles mnuDuplicateNode.Click
        Dim source As TravelFormData = TryCast(TreeView1.SelectedNode, TravelFormData)
        If source Is Nothing OrElse source.Parent Is Nothing Then Exit Sub
        Dim root As TreeNode = source.Parent

        ' Deep copy: the same XML round trip the tree file uses, so the copy
        ' shares no lists or items with the original.
        Dim serializer As New XmlSerializer(GetType(VersionDto))
        Dim xml As New StringWriter()
        serializer.Serialize(xml, VersionToDto(source))
        Dim copy As TravelFormData = DtoToVersion(CType(serializer.Deserialize(New StringReader(xml.ToString())), VersionDto))

        Dim version As Integer = root.Nodes.Count + 1
        For Each child As TreeNode In root.Nodes
            Dim n As Integer = GetVersionNumber(child)
            If n >= version Then version = n + 1
        Next
        copy.Text = BuildVersionText(copy, version)

        root.Nodes.Add(copy)
        root.Expand()
        TreeView1.SelectedNode = copy
        HighlightOpenNodes()
        If source Is _currentVersion Then
            SetStatus("Duplicated """ & source.Text & """ as """ & copy.Text & """ (its last saved state; unsaved changes on screen are not in the copy). Double-click it to open.")
        Else
            SetStatus("Duplicated """ & source.Text & """ as """ & copy.Text & """. Double-click it to open.")
        End If
    End Sub

    ' =========================================================================
    '  "Show in Text": the saved trip / version as readable text in Notepad
    ' =========================================================================

    ''' <summary>
    ''' "Show in Text" (right-click a trip or version): writes the saved data
    ''' as plain text to a .txt file in the Temp folder and opens it.
    ''' A trip shows all its versions. Only ticked / active items are listed.
    ''' </summary>
    Private Sub mnuShowAsText_Click(sender As Object, e As EventArgs) Handles mnuShowAsText.Click
        Dim node As TreeNode = TreeView1.SelectedNode
        Dim sb As New System.Text.StringBuilder()
        Dim fileTitle As String

        Dim trip As TripRootNode = TryCast(node, TripRootNode)
        Dim version As TravelFormData = TryCast(node, TravelFormData)
        If trip IsNot Nothing Then
            AppendTripHeader(sb, trip)
            If trip.Nodes.Count = 0 Then sb.AppendLine("(This trip has no versions yet.)")
            For Each child As TreeNode In trip.Nodes
                Dim v As TravelFormData = TryCast(child, TravelFormData)
                If v IsNot Nothing Then AppendVersionText(sb, v)
            Next
            fileTitle = trip.Text
        ElseIf version IsNot Nothing Then
            Dim root As TripRootNode = TryCast(GetRootNode(version), TripRootNode)
            If root IsNot Nothing Then AppendTripHeader(sb, root)
            AppendVersionText(sb, version)
            fileTitle = If(root Is Nothing, "", root.Text & " - ") & version.Text
        Else
            Exit Sub
        End If

        If version IsNot Nothing AndAlso version Is _currentVersion Then
            sb.AppendLine()
            sb.AppendLine("(This is the last saved state. Changes on screen that were not saved are not included.)")
        End If

        ' File name: the title without characters Windows does not allow.
        For Each ch As Char In Path.GetInvalidFileNameChars()
            fileTitle = fileTitle.Replace(ch, "_"c)
        Next
        Dim filePath As String = Path.Combine(Path.GetTempPath(), fileTitle & ".txt")
        Try
            File.WriteAllText(filePath, sb.ToString(), System.Text.Encoding.UTF8)
            Process.Start(filePath)   ' opens in the default text editor (Notepad)
            SetStatus("Opened """ & filePath & """.")
        Catch ex As Exception
            MessageBox.Show("Could not create or open the text file:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub AppendTripHeader(sb As System.Text.StringBuilder, trip As TripRootNode)
        sb.AppendLine("Trip: " & trip.Title.Text)
        If trip.SubTitle IsNot Nothing AndAlso trip.SubTitle.Text.Trim() <> "" Then sb.AppendLine("Sub Title: " & trip.SubTitle.Text)
        sb.AppendLine("Only ticked / active items are listed.")
    End Sub

    ''' <summary>One version, section by section. Empty sections are left out.</summary>
    Private Sub AppendVersionText(sb As System.Text.StringBuilder, v As TravelFormData)
        sb.AppendLine()
        sb.AppendLine(New String("="c, 60))
        sb.AppendLine("Version: " & v.Text)
        sb.AppendLine(New String("="c, 60))

        ' ---- Destinations -------------------------------------------------------
        Line(sb, "Countries", v.Countries.Select(Function(c) c.Name))
        Line(sb, "Cities", v.Cities.Where(Function(c) c.State = TriState.Checked).Select(Function(c) c.Name))
        Line(sb, "Cities (grey tick)", v.Cities.Where(Function(c) c.State = TriState.Indeterminate).Select(Function(c) c.Name))
        Line(sb, "Stay", v.Stays.Select(Function(s) s.Name))
        Line(sb, "Attractions", v.Attractions.Select(Function(a) a.Name))

        Dim x As VersionExtras = TryCast(v.Tag, VersionExtras)
        If x Is Nothing Then Exit Sub

        ' ---- Departure & Arrival ----------------------------------------------------
        Dim da As DepartureArrivalInfo = x.DepartureArrival
        If da IsNot Nothing Then
            Section(sb, "Departure & Arrival")
            If da.Mode = DuringFilterMode.SpecificDates Then
                DateRange(sb, "Registration", da.RegFromEnabled, da.RegFrom, da.RegToEnabled, da.RegTo)
                DateRange(sb, "Travel", da.TravFromEnabled, da.TravFrom, da.TravToEnabled, da.TravTo)
            Else
                If da.RegMonthsEnabled AndAlso da.RegMonths.Trim() <> "" Then sb.AppendLine("Registration months: " & da.RegMonths)
                If da.TravMonthsEnabled AndAlso da.TravMonths.Trim() <> "" Then sb.AppendLine("Travel months: " & da.TravMonths)
            End If
            If da.Days > 0 OrElse da.Nights > 0 Then sb.AppendLine("Duration: " & da.Days & " days / " & da.Nights & " nights")
        End If

        ' ---- Travel and layovers --------------------------------------------------------
        If x.Legs IsNot Nothing AndAlso x.Legs.Count > 0 Then
            Section(sb, "Travel And Layover")
            Dim n As Integer = 0
            For Each leg As Object In x.Legs
                n += 1
                Dim f As Flight = TryCast(leg, Flight)
                Dim l As LayOver = TryCast(leg, LayOver)
                If f IsNot Nothing Then
                    sb.AppendLine(n & ". " & If(f.Title <> "", f.Title, "Move") & If(f.TransferMean <> "", " (" & f.TransferMean & ")", ""))
                    Dim fromParts As New List(Of String)
                    If f.DepartureFromActive AndAlso f.DepartureFrom IsNot Nothing Then fromParts.Add(f.DepartureFrom.Text)
                    If f.DepartureCityActive AndAlso f.DepartureCity IsNot Nothing Then fromParts.Add(f.DepartureCity.Text)
                    If f.DeparturePointActive AndAlso f.DeparturePoint IsNot Nothing Then fromParts.Add(f.DeparturePoint.Text)
                    Dim toParts As New List(Of String)
                    If f.ArrivingToActive AndAlso f.ArrivingTo IsNot Nothing Then toParts.Add(f.ArrivingTo.Text)
                    If f.ArrivalCityActive AndAlso f.ArrivalCity IsNot Nothing Then toParts.Add(f.ArrivalCity.Text)
                    If f.ArrivalPointActive AndAlso f.ArrivalPoint IsNot Nothing Then toParts.Add(f.ArrivalPoint.Text)
                    If fromParts.Count > 0 Then sb.AppendLine("   From: " & String.Join(", ", fromParts) & WhenText(f.DepartureDateActive, f.DepartureDate, f.DepartureTimeActive, f.DepartureTime))
                    If toParts.Count > 0 Then sb.AppendLine("   To:   " & String.Join(", ", toParts) & WhenText(f.ArrivalDateActive, f.ArrivalDate, f.ArrivalTimeActive, f.ArrivalTime))
                    If f.AirLineActive AndAlso f.AirLine IsNot Nothing Then sb.AppendLine("   Operator: " & f.AirLine.Text)
                    If f.Duration <> "" Then sb.AppendLine("   Duration: " & f.Duration)
                ElseIf l IsNot Nothing Then
                    sb.AppendLine(n & ". " & If(l.Title <> "", l.Title, "Layover") & " (layover)")
                    sb.AppendLine("   From " & l.DepartureDate.ToString("yyyy-MM-dd") & " " & l.DepartureTime.ToString("hh\:mm") &
                                  " to " & l.ArrivalDate.ToString("yyyy-MM-dd") & " " & l.ArrivalTime.ToString("hh\:mm"))
                    If l.Duration <> "" Then sb.AppendLine("   Duration: " & l.Duration)
                End If
            Next
        End If

        ' ---- Day by day ----------------------------------------------------------------
        If x.Days IsNot Nothing Then
            Dim daysWithLines = x.Days.Where(Function(d) d.Lines.Any(Function(ln) ln.Enabled AndAlso ln.Text.Trim() <> "")).ToList()
            If daysWithLines.Count > 0 Then
                Section(sb, "Day By Day")
                For Each d As DayPlan In daysWithLines
                    sb.AppendLine(d.Title & ":")
                    For Each ln As DayLine In d.Lines.Where(Function(l2) l2.Enabled AndAlso l2.Text.Trim() <> "")
                        sb.AppendLine("   - " & ln.Text)
                    Next
                Next
            End If
        End If

        ' ---- Service lists ------------------------------------------------------------------
        PricingSection(sb, "Including", x.Including)
        PricingSection(sb, "Not Including", x.NotIncluding)
        PricingSection(sb, "Pricing Policy", x.PricingPolicy)
        PricingSection(sb, "Additions", x.Additions)

        ' ---- Transfer ways ---------------------------------------------------------------
        If x.TransferWays IsNot Nothing Then
            Dim used = x.TransferWays.Where(Function(kv) kv.Value.Any(Function(ln) ln.Enabled AndAlso ln.Text.Trim() <> "")).ToList()
            If used.Count > 0 Then
                Section(sb, "Transfer Ways")
                For Each kv In used
                    sb.AppendLine(TransferWayName(kv.Key) & ":")
                    For Each ln As DayLine In kv.Value.Where(Function(l2) l2.Enabled AndAlso l2.Text.Trim() <> "")
                        sb.AppendLine("   - " & ln.Text)
                    Next
                Next
            End If
        End If

        ' ---- Laces, stamps, comments -----------------------------------------------------
        If x.Laces IsNot Nothing Then
            Dim rows = x.Laces.Where(Function(t) t.Enabled AndAlso t.Text.Trim() <> "").ToList()
            If rows.Count > 0 Then
                Section(sb, "Laces, Stamps, and Comments")
                For Each t As TypedLine In rows
                    sb.AppendLine("- " & If(t.TypeText.Trim() <> "", "[" & t.TypeText.Trim() & "] ", "") & t.Text)
                Next
            End If
        End If

        ' ---- Vendor --------------------------------------------------------------------------
        If x.Vendor IsNot Nothing Then
            Section(sb, "Vendor")
            For Each ln As String In VendorLines(x.Vendor)
                sb.AppendLine(ln)
            Next
        End If

        ' ---- Prices --------------------------------------------------------------------------
        If x.Prices IsNot Nothing AndAlso x.Prices.Count > 0 Then
            Section(sb, "Prices")
            For Each p As PriceEntry In x.Prices
                sb.AppendLine("- " & p.Amount.ToString("#,##0.##") & " " & p.Currency)
            Next
        End If
    End Sub

    ''' <summary>"Label: a, b, c" — left out when there is nothing to list.</summary>
    Private Sub Line(sb As System.Text.StringBuilder, label As String, items As IEnumerable(Of String))
        Dim list = items.Where(Function(s) s IsNot Nothing AndAlso s.Trim() <> "").ToList()
        If list.Count > 0 Then sb.AppendLine(label & ": " & String.Join(", ", list))
    End Sub

    Private Sub Section(sb As System.Text.StringBuilder, title As String)
        sb.AppendLine()
        sb.AppendLine(title)
        sb.AppendLine(New String("-"c, title.Length))
    End Sub

    Private Sub DateRange(sb As System.Text.StringBuilder, label As String,
                          fromOn As Boolean, fromDate As Date, toOn As Boolean, toDate As Date)
        If Not fromOn AndAlso Not toOn Then Exit Sub
        sb.AppendLine(label & ": " & If(fromOn, "from " & fromDate.ToString("yyyy-MM-dd") & " ", "") &
                      If(toOn, "to " & toDate.ToString("yyyy-MM-dd"), "").TrimEnd())
    End Sub

    Private Function WhenText(dateOn As Boolean, d As Date, timeOn As Boolean, t As TimeSpan) As String
        Dim parts As New List(Of String)
        If dateOn Then parts.Add(d.ToString("yyyy-MM-dd"))
        If timeOn Then parts.Add(t.ToString("hh\:mm"))
        Return If(parts.Count = 0, "", "  (" & String.Join(" ", parts) & ")")
    End Function

    ''' <summary>Ticked rows of a pricing list: "- Title (Sub title): prices".</summary>
    Private Sub PricingSection(sb As System.Text.StringBuilder, title As String, rows As PricingItem.PricingCollection)
        If rows Is Nothing Then Exit Sub
        Dim ticked = rows.Where(Function(r) r IsNot Nothing AndAlso r.Enabled AndAlso Not String.IsNullOrWhiteSpace(r.Title)).ToList()
        If ticked.Count = 0 Then Exit Sub
        Section(sb, title)
        For Each r As PricingItem.PricingItem In ticked
            Dim text As String = "- " & r.Title.Trim()
            If r.IsSubTitleActive AndAlso Not String.IsNullOrWhiteSpace(r.SubTitle) Then text &= " (" & r.SubTitle.Trim() & ")"
            Dim prices = If(r.Prices, New List(Of String)).Where(Function(p) Not String.IsNullOrWhiteSpace(p)).ToList()
            If prices.Count > 0 Then text &= ": " & String.Join(", ", prices)
            sb.AppendLine(text)
        Next
    End Sub

    ''' <summary>
    ''' Readable name of a Transfer Ways tab: its Text if set in the designer,
    ''' otherwise its icon file name (e.g. "Train.jpg" -> "Train").
    ''' </summary>
    Private Function TransferWayName(tabName As String) As String
        Dim page As TabPage = TabControl4.TabPages.Cast(Of TabPage)().FirstOrDefault(Function(p) p.Name = tabName)
        If page Is Nothing Then Return tabName
        If page.Text.Trim() <> "" Then Return page.Text.Trim()
        If TabControl4.ImageList IsNot Nothing AndAlso page.ImageIndex >= 0 AndAlso page.ImageIndex < TabControl4.ImageList.Images.Count Then
            Dim key As String = Path.GetFileNameWithoutExtension(TabControl4.ImageList.Images.Keys(page.ImageIndex)).Replace("_", " ")
            Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(key.ToLower())
        End If
        Return tabName
    End Function

    ' =========================================================================
    '  Compare: Ctrl+click versions in the tree, then right-click one of them
    '  -> "Compare and Show in Text"
    ' =========================================================================

    ''' <summary>Versions marked with Ctrl+click for comparing, in the order they were marked.</summary>
    Private ReadOnly _compareSet As New List(Of TravelFormData)

    ''' <summary>Ctrl+click toggles a version in the compare set; a plain click clears the set.</summary>
    Private Sub TreeView1_CompareClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button <> MouseButtons.Left Then Exit Sub
        Dim v As TravelFormData = TryCast(e.Node, TravelFormData)

        If (Control.ModifierKeys And Keys.Control) = Keys.Control AndAlso v IsNot Nothing Then
            If _compareSet.Contains(v) Then _compareSet.Remove(v) Else _compareSet.Add(v)
            If _compareSet.Count = 0 Then
                SetStatus("No versions marked for comparing.")
            Else
                SetStatus(_compareSet.Count & " version(s) marked for comparing. Ctrl+click more, then right-click one of them and choose ""Compare and Show in Text"". A click without Ctrl clears the marks.")
            End If
            HighlightOpenNodes()
        ElseIf _compareSet.Count > 0 Then
            _compareSet.Clear()
            HighlightOpenNodes()
        End If
    End Sub

    ''' <summary>
    ''' "Compare and Show in Text": for each section, what is the same in all
    ''' marked versions and what each version has that is not in all of them.
    ''' Only ticked / active items are compared, as in "Show in Text".
    ''' </summary>
    Private Sub mnuCompareText_Click(sender As Object, e As EventArgs) Handles mnuCompareText.Click
        Dim versions As List(Of TravelFormData) = _compareSet.Where(Function(v) IsOpen(v)).ToList()
        If versions.Count < 2 Then
            MessageBox.Show("Ctrl+click at least two versions in the tree first.")
            Exit Sub
        End If

        Dim fileTitle As String = "Compare - " & String.Join(" vs ", versions.Select(Function(v) v.Text))
        If fileTitle.Length > 120 Then fileTitle = fileTitle.Substring(0, 120)
        OpenTextFile(fileTitle, BuildCompareText(versions))
    End Sub

    ''' <summary>The comparison text for 2+ versions (see "Compare and Show in Text").</summary>
    Private Function BuildCompareText(versions As List(Of TravelFormData)) As String
        Dim names As List(Of String) = versions.Select(Function(v) VersionLabel(v)).ToList()
        Dim data As List(Of List(Of KeyValuePair(Of String, List(Of String)))) = versions.Select(Function(v) CompareSections(v)).ToList()

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("Comparison of " & versions.Count & " versions:")
        For Each n As String In names
            sb.AppendLine("  - " & n)
        Next
        sb.AppendLine("Only ticked / active items are compared.")

        ' Section titles in the order they first appear.
        Dim sectionTitles As New List(Of String)
        For Each d In data
            For Each kv In d
                If Not sectionTitles.Contains(kv.Key) Then sectionTitles.Add(kv.Key)
            Next
        Next

        Dim differentSections As New List(Of String)
        For Each title As String In sectionTitles
            ' Items of this section in each version (empty when the version has none).
            Dim itemsPerVersion As New List(Of List(Of String))
            For Each d In data
                Dim found = d.FirstOrDefault(Function(kv) kv.Key = title)
                itemsPerVersion.Add(If(found.Value, New List(Of String)))
            Next
            If itemsPerVersion.All(Function(l) l.Count = 0) Then Continue For

            Dim common As List(Of String) = itemsPerVersion(0).
                Where(Function(item) itemsPerVersion.All(Function(l) l.Contains(item))).Distinct().ToList()

            Section(sb, title)
            If common.Count > 0 Then
                sb.AppendLine("Same in all:")
                For Each item As String In common
                    sb.AppendLine("   " & item)
                Next
            End If

            Dim anyDifference As Boolean = itemsPerVersion.Any(Function(l) l.Any(Function(item) Not common.Contains(item)))
            If Not anyDifference Then
                sb.AppendLine("No differences.")
            Else
                differentSections.Add(title)
                sb.AppendLine("Different:")
                For i As Integer = 0 To versions.Count - 1
                    Dim own = itemsPerVersion(i).Where(Function(item) Not common.Contains(item)).Distinct().ToList()
                    sb.AppendLine("   " & names(i) & ":")
                    If own.Count = 0 Then
                        sb.AppendLine("      (nothing that the others lack)")
                    Else
                        For Each item As String In own
                            sb.AppendLine("      + " & item)
                        Next
                    End If
                Next
            End If
        Next

        sb.AppendLine()
        sb.AppendLine(New String("="c, 60))
        sb.AppendLine(If(differentSections.Count = 0,
                         "Summary: the versions are the same in every section.",
                         "Summary: differences in " & String.Join(", ", differentSections) & "."))
        Return sb.ToString()
    End Function

    ''' <summary>"Trip › Version", so versions of different trips can be told apart.</summary>
    Private Function VersionLabel(v As TravelFormData) As String
        Dim root As TripRootNode = TryCast(GetRootNode(v), TripRootNode)
        Return If(root Is Nothing, "", root.Text & " " & ChrW(8250) & " ") & v.Text
    End Function

    ''' <summary>
    ''' A version as sections of one-line items, ready to compare. Things that
    ''' always differ between versions (day dates, the order of legs) are left
    ''' out of the items so they don't show up as differences.
    ''' </summary>
    Private Function CompareSections(v As TravelFormData) As List(Of KeyValuePair(Of String, List(Of String)))
        Dim result As New List(Of KeyValuePair(Of String, List(Of String)))
        Dim add = Sub(title As String, items As IEnumerable(Of String))
                      result.Add(New KeyValuePair(Of String, List(Of String))(title,
                          items.Where(Function(s) Not String.IsNullOrWhiteSpace(s)).Select(Function(s) s.Trim()).ToList()))
                  End Sub

        add("Countries", v.Countries.Select(Function(c) c.Name))
        add("Cities", v.Cities.Where(Function(c) c.State <> TriState.Unchecked).
                Select(Function(c) c.Name & If(c.State = TriState.Indeterminate, " (grey tick)", "")))
        add("Stay", v.Stays.Select(Function(s) s.Name))
        add("Attractions", v.Attractions.Select(Function(a) a.Name))

        Dim x As VersionExtras = TryCast(v.Tag, VersionExtras)
        If x Is Nothing Then Return result

        Dim da As DepartureArrivalInfo = x.DepartureArrival
        If da IsNot Nothing Then
            Dim items As New List(Of String)
            If da.Mode = DuringFilterMode.SpecificDates Then
                If da.RegFromEnabled OrElse da.RegToEnabled Then items.Add("Registration: " & If(da.RegFromEnabled, "from " & da.RegFrom.ToString("yyyy-MM-dd") & " ", "") & If(da.RegToEnabled, "to " & da.RegTo.ToString("yyyy-MM-dd"), ""))
                If da.TravFromEnabled OrElse da.TravToEnabled Then items.Add("Travel: " & If(da.TravFromEnabled, "from " & da.TravFrom.ToString("yyyy-MM-dd") & " ", "") & If(da.TravToEnabled, "to " & da.TravTo.ToString("yyyy-MM-dd"), ""))
            Else
                If da.RegMonthsEnabled Then items.Add("Registration months: " & da.RegMonths)
                If da.TravMonthsEnabled Then items.Add("Travel months: " & da.TravMonths)
            End If
            If da.Days > 0 OrElse da.Nights > 0 Then items.Add("Duration: " & da.Days & " days / " & da.Nights & " nights")
            add("Departure & Arrival", items)
        End If

        If x.Legs IsNot Nothing Then add("Travel And Layover", x.Legs.Select(Function(l) LegSummary(l)))

        If x.Days IsNot Nothing Then
            ' "Day 3 (2026-05-01)" -> "Day 3", so a date shift alone isn't a difference.
            add("Day By Day", x.Days.SelectMany(Function(d) d.Lines.
                Where(Function(ln) ln.Enabled AndAlso ln.Text.Trim() <> "").
                Select(Function(ln) d.Title.Split("("c)(0).Trim() & ": " & ln.Text)))
        End If

        add("Including", PricingItems(x.Including))
        add("Not Including", PricingItems(x.NotIncluding))
        add("Pricing Policy", PricingItems(x.PricingPolicy))
        add("Additions", PricingItems(x.Additions))

        If x.TransferWays IsNot Nothing Then
            add("Transfer Ways", x.TransferWays.SelectMany(Function(kv) kv.Value.
                Where(Function(ln) ln.Enabled AndAlso ln.Text.Trim() <> "").
                Select(Function(ln) TransferWayName(kv.Key) & ": " & ln.Text)))
        End If

        If x.Laces IsNot Nothing Then
            add("Laces, Stamps, and Comments", x.Laces.Where(Function(t) t.Enabled AndAlso t.Text.Trim() <> "").
                Select(Function(t) If(t.TypeText.Trim() <> "", "[" & t.TypeText.Trim() & "] ", "") & t.Text))
        End If

        If x.Prices IsNot Nothing Then add("Prices", x.Prices.Select(Function(p) p.Amount.ToString("#,##0.##") & " " & p.Currency))
        add("Vendor", VendorLines(x.Vendor))
        Return result
    End Function

    ''' <summary>One travel leg on one line, using only its active fields.</summary>
    Private Function LegSummary(leg As Object) As String
        Dim f As Flight = TryCast(leg, Flight)
        If f IsNot Nothing Then
            Dim fromParts As New List(Of String), toParts As New List(Of String)
            If f.DepartureFromActive AndAlso f.DepartureFrom IsNot Nothing Then fromParts.Add(f.DepartureFrom.Text)
            If f.DepartureCityActive AndAlso f.DepartureCity IsNot Nothing Then fromParts.Add(f.DepartureCity.Text)
            If f.DeparturePointActive AndAlso f.DeparturePoint IsNot Nothing Then fromParts.Add(f.DeparturePoint.Text)
            If f.ArrivingToActive AndAlso f.ArrivingTo IsNot Nothing Then toParts.Add(f.ArrivingTo.Text)
            If f.ArrivalCityActive AndAlso f.ArrivalCity IsNot Nothing Then toParts.Add(f.ArrivalCity.Text)
            If f.ArrivalPointActive AndAlso f.ArrivalPoint IsNot Nothing Then toParts.Add(f.ArrivalPoint.Text)
            Dim s As String = If(f.Title <> "", f.Title, "Move") & If(f.TransferMean <> "", " (" & f.TransferMean & ")", "")
            If fromParts.Count > 0 OrElse toParts.Count > 0 Then s &= ": " & String.Join(", ", fromParts) & " -> " & String.Join(", ", toParts)
            s &= WhenText(f.DepartureDateActive, f.DepartureDate, f.DepartureTimeActive, f.DepartureTime)
            If f.AirLineActive AndAlso f.AirLine IsNot Nothing Then s &= ", operator " & f.AirLine.Text
            If f.Duration <> "" Then s &= ", duration " & f.Duration
            Return s
        End If
        Dim l As LayOver = TryCast(leg, LayOver)
        If l IsNot Nothing Then
            Return If(l.Title <> "", l.Title, "Layover") & " (layover): " &
                   l.DepartureDate.ToString("yyyy-MM-dd") & " " & l.DepartureTime.ToString("hh\:mm") & " to " &
                   l.ArrivalDate.ToString("yyyy-MM-dd") & " " & l.ArrivalTime.ToString("hh\:mm") &
                   If(l.Duration <> "", ", duration " & l.Duration, "")
        End If
        Return ""
    End Function

    ''' <summary>Ticked rows of a pricing list as "Title (Sub title): prices".</summary>
    Private Function PricingItems(rows As PricingItem.PricingCollection) As IEnumerable(Of String)
        If rows Is Nothing Then Return New List(Of String)
        Return rows.Where(Function(r) r IsNot Nothing AndAlso r.Enabled AndAlso Not String.IsNullOrWhiteSpace(r.Title)).
            Select(Function(r)
                       Dim text As String = r.Title.Trim()
                       If r.IsSubTitleActive AndAlso Not String.IsNullOrWhiteSpace(r.SubTitle) Then text &= " (" & r.SubTitle.Trim() & ")"
                       Dim prices = If(r.Prices, New List(Of String)).Where(Function(p) Not String.IsNullOrWhiteSpace(p)).ToList()
                       If prices.Count > 0 Then text &= ": " & String.Join(", ", prices)
                       Return text
                   End Function).ToList()
    End Function

    ''' <summary>Writes text to a .txt in the Temp folder and opens it in the default editor.</summary>
    Private Sub OpenTextFile(fileTitle As String, text As String)
        For Each ch As Char In Path.GetInvalidFileNameChars()
            fileTitle = fileTitle.Replace(ch, "_"c)
        Next
        Dim filePath As String = Path.Combine(Path.GetTempPath(), fileTitle & ".txt")
        Try
            File.WriteAllText(filePath, text, System.Text.Encoding.UTF8)
            Process.Start(filePath)
            SetStatus("Opened """ & filePath & """.")
        Catch ex As Exception
            MessageBox.Show("Could not create or open the text file:" & vbCrLf & ex.Message)
        End Try
    End Sub

    ' =========================================================================
    '  Vendor tab: radio-button list of the Vendors table, search, details
    ' =========================================================================

    ''' <summary>All vendors read from the Vendors table (sorted by name).</summary>
    Private _vendors As New List(Of VendorInfo)
    ''' <summary>The vendor chosen on the Vendor tab (Nothing = none).</summary>
    Private _selectedVendor As VendorInfo

    ''' <summary>Reads the Vendors table and builds the radio-button list.</summary>
    Private Sub LoadVendors()
        Try
            Dim dt As DataTable = GetDataTable("SELECT * FROM Vendors")
            _vendors = dt.Rows.Cast(Of DataRow)().Select(Function(r) VendorInfo.FromRow(r)).
                OrderBy(Function(v) v.DisplayName, StringComparer.CurrentCultureIgnoreCase).ToList()
        Catch ex As Exception
            _vendors = New List(Of VendorInfo)
            lblVendorCount.Text = "Could not read the Vendors table: " & ex.Message
            Exit Sub
        End Try
        FillVendorList()
    End Sub

    Private Sub FillVendorList()
        pnlVendorList.SuspendLayout()
        pnlVendorList.Controls.Clear()
        For Each v As VendorInfo In _vendors
            Dim rb As New RadioButton With {
                .AutoSize = True, .Text = v.DisplayName, .Tag = v,
                .Font = New Font("Segoe UI", 9.75!), .Margin = New Padding(3, 2, 3, 2)}
            AddHandler rb.CheckedChanged, AddressOf VendorRadio_CheckedChanged
            pnlVendorList.Controls.Add(rb)
        Next
        pnlVendorList.ResumeLayout()
        ApplyVendorFilter()
        MarkSelectedVendorRadio()
    End Sub

    Private Sub txtVendorSearch_TextChanged(sender As Object, e As EventArgs) Handles txtVendorSearch.TextChanged
        ApplyVendorFilter()
    End Sub

    ''' <summary>Shows only the vendors whose English or Arabic name (or ID) contains the search text.</summary>
    Private Sub ApplyVendorFilter()
        Dim q As String = txtVendorSearch.Text.Trim()
        Dim shown As Integer = 0
        pnlVendorList.SuspendLayout()
        For Each rb As RadioButton In pnlVendorList.Controls.OfType(Of RadioButton)()
            Dim v As VendorInfo = DirectCast(rb.Tag, VendorInfo)
            Dim match As Boolean = q = "" OrElse
                v.TitleEn.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) >= 0 OrElse
                v.TitleAr.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) >= 0 OrElse
                v.Id = q
            rb.Visible = match OrElse rb.Checked   ' keep the chosen one visible
            If rb.Visible Then shown += 1
        Next
        pnlVendorList.ResumeLayout()
        lblVendorCount.Text = If(q = "", _vendors.Count & " vendor(s)", shown & " of " & _vendors.Count & " vendor(s) match")
    End Sub

    Private Sub VendorRadio_CheckedChanged(sender As Object, e As EventArgs)
        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        If Not rb.Checked Then Exit Sub
        _selectedVendor = DirectCast(rb.Tag, VendorInfo).Clone()
        ShowVendorFields(_selectedVendor)
    End Sub

    ''' <summary>Chooses a vendor (Nothing = none): ticks its radio button and shows its fields.</summary>
    Private Sub SelectVendor(v As VendorInfo)
        _selectedVendor = If(v Is Nothing, Nothing, v.Clone())
        MarkSelectedVendorRadio()
        ShowVendorFields(_selectedVendor)
    End Sub

    Private Sub MarkSelectedVendorRadio()
        For Each rb As RadioButton In pnlVendorList.Controls.OfType(Of RadioButton)()
            Dim isIt As Boolean = _selectedVendor IsNot Nothing AndAlso DirectCast(rb.Tag, VendorInfo).Id = _selectedVendor.Id
            If rb.Checked <> isIt Then rb.Checked = isIt
            If isIt Then rb.Visible = True : pnlVendorList.ScrollControlIntoView(rb)
        Next
    End Sub

    Private Sub ShowVendorFields(v As VendorInfo)
        If v Is Nothing Then v = New VendorInfo()
        txtVendorID.Text = v.Id
        txtVendorTitleAr.Text = v.TitleAr
        txtVendorTitleEn.Text = v.TitleEn
        txtVendorNationality.Text = v.Nationality
        txtVendorarNationality.Text = v.ArNationality
        txtVendorInstegram.Text = v.Instagram
        txtVendorWebSite.Text = v.WebSite
        txtVendorContact1.Text = v.Contact1
        txtVendorContact2.Text = v.Contact2
        txtVendorContact3.Text = v.Contact3
        txtVendorWhatsapp1.Text = v.Whatsapp1
        txtVendorWhatsapp2.Text = v.Whatsapp2
        txtVendorWhatsapp3.Text = v.Whatsapp3
    End Sub

    ''' <summary>"Save" on the Vendor tab: stores the chosen vendor in the open version only.</summary>
    Private Sub btnSaveVendor_Click(sender As Object, e As EventArgs) Handles btnSaveVendor.Click
        If Not IsOpen(_currentVersion) Then
            MessageBox.Show("No version is open. Double-click a version in the tree first" &
                            If(IsOpen(_currentTrip), ", or press ""Save as New Version"".", "."))
            Exit Sub
        End If
        GetExtras(_currentVersion).Vendor = If(_selectedVendor Is Nothing, Nothing, _selectedVendor.Clone())
        SetStatus(If(_selectedVendor Is Nothing,
                     "Vendor removed from """ & _currentVersion.Text & """.",
                     "Vendor """ & _selectedVendor.DisplayName & """ saved to """ & _currentVersion.Text & """."))
    End Sub

    Private Sub btnClearVendor_Click(sender As Object, e As EventArgs) Handles btnClearVendor.Click
        SelectVendor(Nothing)
        SetStatus("No vendor selected. Press Save to remove the vendor from the open version.")
    End Sub

    ''' <summary>The vendor as text lines, for "Show in Text" and "Compare".</summary>
    Private Function VendorLines(v As VendorInfo) As List(Of String)
        Dim lines As New List(Of String)
        If v Is Nothing Then Return lines
        lines.Add("Vendor: " & v.DisplayName & If(v.Id <> "", " (ID " & v.Id & ")", ""))
        Dim add = Sub(label As String, value As String)
                      If Not String.IsNullOrWhiteSpace(value) Then lines.Add(label & ": " & value.Trim())
                  End Sub
        add("Nationality", v.Nationality)
        add("Nationality (Arabic)", v.ArNationality)
        add("Instagram", v.Instagram)
        add("Website", v.WebSite)
        add("Contact 1", v.Contact1) : add("Contact 2", v.Contact2) : add("Contact 3", v.Contact3)
        add("WhatsApp 1", v.Whatsapp1) : add("WhatsApp 2", v.Whatsapp2) : add("WhatsApp 3", v.Whatsapp3)
        Return lines
    End Function

    Private Sub mnuDeleteNode_Click(sender As Object, e As EventArgs) Handles mnuDeleteNode.Click
        DeleteNode(TreeView1.SelectedNode)
    End Sub

    ''' <summary>Keyboard in the tree: Enter opens, Delete deletes.</summary>
    Private Sub TreeView1_KeyDown(sender As Object, e As KeyEventArgs) Handles TreeView1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If TreeView1.SelectedNode IsNot Nothing Then OpenNode(TreeView1.SelectedNode)
                e.Handled = True
            Case Keys.Delete
                DeleteNode(TreeView1.SelectedNode)
                e.Handled = True
        End Select
    End Sub

    ''' <summary>Deletes a trip (with all its versions) or one version, after asking.</summary>
    Private Sub DeleteNode(node As TreeNode)
        If node Is Nothing Then Exit Sub
        Dim isTrip As Boolean = TypeOf node Is TripRootNode
        If Not isTrip AndAlso Not TypeOf node Is TravelFormData Then Exit Sub

        Dim what As String = If(isTrip,
            "the trip """ & node.Text & """ and all its versions",
            "the version """ & node.Text & """")
        If MessageBox.Show("Delete " & what & "?", "Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Exit Sub

        node.Remove()
        UpdateEditingHeader()   ' closes the trip / version if it was the one open
        SetStatus("Deleted " & what & ".")
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

        SetLoadedLeg(ListBox1.SelectedItem)   ' "Update Selected Item" now targets this item

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
    ''' "Update Selected Item": writes what is on the Move / LayOver tab back
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
        BuildDayByDayList()
    End Sub

    ''' <summary>
    ''' (Re)builds ListBox2 with one DayPlan per day of the trip. Clears the
    ''' list first (it used to keep appending), and keeps the lines already
    ''' typed for Day 1, Day 2, ... so changing the dates only renames days.
    ''' </summary>
    Private Sub BuildDayByDayList()
        Dim days As Integer
        If Not Integer.TryParse(txtDays.Text, days) OrElse days < 0 Then Exit Sub

        CommitDayBoxes()   ' keep what is typed for the day on screen
        Dim old As List(Of DayPlan) = ListBox2.Items.OfType(Of DayPlan)().ToList()
        Dim showDates As Boolean = (TabControl5.SelectedTab Is tabSpecificDates)
        Dim d As Date = chkTravFrom.lcDateTimePicker.Value.Date

        ListBox2.BeginUpdate()
        ListBox2.Items.Clear()
        For i As Integer = 1 To days
            Dim title As String = "Day " & i
            If showDates Then title &= " (" & d.ToString("yyyy-MM-dd") & ")"

            Dim plan As DayPlan = If(i <= old.Count, old(i - 1), New DayPlan())
            plan.Title = title
            ListBox2.Items.Add(plan)
            d = d.AddDays(1)
        Next
        ListBox2.EndUpdate()
    End Sub

    ''' <summary>The 13 line boxes on the Day By Day tab, top to bottom.</summary>
    Private Function DayLineBoxes() As TextBoxWithCheckBox.TextBoxWithCheckBox()
        Return {TextBoxWithCheckBox27, TextBoxWithCheckBox26, TextBoxWithCheckBox25,
                TextBoxWithCheckBox24, TextBoxWithCheckBox23, TextBoxWithCheckBox22,
                TextBoxWithCheckBox21, TextBoxWithCheckBox20, TextBoxWithCheckBox19,
                TextBoxWithCheckBox18, TextBoxWithCheckBox17, TextBoxWithCheckBox16,
                TextBoxWithCheckBox15}
    End Function

    ''' <summary>The day whose lines are in the 13 boxes right now.</summary>
    Private _shownDay As DayPlan

    ''' <summary>
    ''' Clicking a day first keeps the lines of the day shown before, then
    ''' shows this day's lines and ticks in the 13 boxes.
    ''' </summary>
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        CommitDayBoxes()
        Dim plan As DayPlan = TryCast(ListBox2.SelectedItem, DayPlan)
        btnSaveDay.Enabled = (plan IsNot Nothing)
        ShowDayLines(plan)
    End Sub

    Private Sub ShowDayLines(plan As DayPlan)
        _shownDay = plan
        Dim boxes = DayLineBoxes()
        For i As Integer = 0 To boxes.Length - 1
            If plan IsNot Nothing AndAlso i < plan.Lines.Count Then
                boxes(i).CheckBox1.Checked = plan.Lines(i).Enabled
                boxes(i).TextBox1.Text = plan.Lines(i).Text
            Else
                boxes(i).CheckBox1.Checked = False
                boxes(i).TextBox1.Text = ""
            End If
        Next
    End Sub

    ''' <summary>Writes the 13 boxes into the day they belong to (if it is still in the list).</summary>
    Private Sub CommitDayBoxes()
        If _shownDay Is Nothing OrElse Not ListBox2.Items.Contains(_shownDay) Then Exit Sub
        _shownDay.Lines = DayLineBoxes().Select(Function(b) New DayLine With {.Enabled = b.CheckBox1.Checked, .Text = b.TextBox1.Text}).ToList()
    End Sub

    ''' <summary>"Save Day": writes the 13 boxes into the day selected in ListBox2.</summary>
    Private Sub btnSaveDay_Click(sender As Object, e As EventArgs) Handles btnSaveDay.Click
        Dim plan As DayPlan = TryCast(ListBox2.SelectedItem, DayPlan)
        If plan Is Nothing Then
            MessageBox.Show("Select a day in the list first.")
            Exit Sub
        End If
        _shownDay = plan
        CommitDayBoxes()
        SetStatus("Lines saved for " & plan.Title & ". Press ""Save"" at the top to store them in the version.")
    End Sub

    ''' <summary>
    ''' Puts saved days back into ListBox2 (copies, so editing doesn't change
    ''' the version until it is saved again). Nothing = never saved: leave as is.
    ''' </summary>
    Private Sub LoadDays(days As List(Of DayPlan))
        If days Is Nothing Then Exit Sub
        _shownDay = Nothing          ' the boxes belong to the old list: don't keep them
        ListBox2.Items.Clear()
        For Each p As DayPlan In days
            ListBox2.Items.Add(p.Clone())
        Next
        ShowDayLines(Nothing)
        btnSaveDay.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PriceDialog.TextBox1.Text = ""   ' start empty, not with the last edited price
        If PriceDialog.ShowDialog = DialogResult.OK Then
            Dim entry As PriceEntry = PriceEntryFromDialog()
            If entry IsNot Nothing Then ListBox3.Items.Add(entry)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ListBox3.SelectedIndex < 0 Then Exit Sub
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
    ''' "Create Trip" on the Trip Title tab: adds a new trip (root node) to
    ''' the tree with this title and opens it. Its first version is made
    ''' with "Save as New Version" in the header bar.
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

        ' New trip: no version yet, and the destination lists start empty.
        SetCurrentVersion(Nothing)
        ResetCitiesStayAttraction()
        SetCurrentTrip(root)
        TreeView1.SelectedNode = root
        SetStatus("Trip """ & title & """ created. Fill in the tabs, then press ""Save as New Version"".")
    End Sub

    ''' <summary>"New Trip" on the tree toolbar: clears the title and goes to the Trip Title tab.</summary>
    Private Sub tsbNewTrip_Click(sender As Object, e As EventArgs) Handles tsbNewTrip.Click
        SetCurrentVersion(Nothing)
        SetCurrentTrip(Nothing)
        txbxTripTitle.TextBox1.Text = ""
        txbxTripSubTitle.TextBox1.Text = ""
        ResetCitiesStayAttraction()
        TabControl1.SelectedTab = TitleAndSubTitle
        txbxTripTitle.TextBox1.Focus()
        SetStatus("Type the trip title, then press ""Create Trip"".")
    End Sub

    ' =========================================================================
    '  Header bar: what is open + the two common Save buttons
    ' =========================================================================

    ''' <summary>
    ''' "Save": writes every tab into the open version, replacing what it had.
    ''' The trip title (Trip Title tab) is saved into the trip as well. If only
    ''' a trip is open (no version yet), just the title is saved.
    ''' </summary>
    Private Sub btnSaveVersion_Click(sender As Object, e As EventArgs) Handles btnSaveVersion.Click
        If Not IsOpen(_currentTrip) Then
            MessageBox.Show("No trip is open. Create a trip, or double-click one in the tree.")
            Exit Sub
        End If

        If Not IsOpen(_currentVersion) Then
            SaveTripTitle(_currentTrip)
            UpdateEditingHeader()
            SetStatus("Trip title saved. This trip has no open version yet: press ""Save as New Version"" to save the tabs.")
            Exit Sub
        End If

        Dim warning As String = ""
        Dim data As TravelFormData = CaptureEditor(warning)
        If data Is Nothing Then Exit Sub
        SaveTripTitle(_currentTrip)

        ' Swap the old node for the new one at the same position, same version number.
        Dim old As TravelFormData = _currentVersion
        Dim parent As TreeNode = old.Parent
        Dim index As Integer = old.Index
        data.Text = BuildVersionText(data, GetVersionNumber(old))
        parent.Nodes.Insert(index, data)
        old.Remove()

        SetCurrentVersion(data)
        SetStatus("Saved all tabs to """ & data.Text & """." & warning)
    End Sub

    ''' <summary>
    ''' "Save as New Version": saves every tab as a new version under the open
    ''' trip and opens it. The version that was open stays exactly as it was.
    ''' </summary>
    Private Sub btnSaveAsNewVersion_Click(sender As Object, e As EventArgs) Handles btnSaveAsNewVersion.Click
        If Not IsOpen(_currentTrip) Then
            MessageBox.Show("No trip is open. Create a trip, or double-click one in the tree.")
            Exit Sub
        End If

        Dim warning As String = ""
        Dim data As TravelFormData = CaptureEditor(warning)
        If data Is Nothing Then Exit Sub
        SaveTripTitle(_currentTrip)

        ' Next version number = one more than the highest under this trip.
        Dim root As TripRootNode = _currentTrip
        Dim version As Integer = root.Nodes.Count + 1
        For Each child As TreeNode In root.Nodes
            Dim n As Integer = GetVersionNumber(child)
            If n >= version Then version = n + 1
        Next
        data.Text = BuildVersionText(data, version)

        root.Nodes.Add(data)
        root.Expand()
        SetCurrentVersion(data)
        SetStatus("Saved all tabs as the new version """ & data.Text & """." & warning)
    End Sub

    ''' <summary>
    ''' Reads every tab into one version node: Destinations (Title, Countries,
    ''' Cities, Stay, Attraction) plus Departure &amp; Arrival, the travel legs,
    ''' Including / Not Including, Day By Day, Pricing Policy, Additions,
    ''' Transfer Ways, Laces / Stamps / Comments and Prices.
    ''' Returns Nothing (after a message) if it can't be saved.
    ''' </summary>
    Private Function CaptureEditor(ByRef warning As String) As TravelFormData
        warning = ""
        Dim data As TravelFormData = SaveTabPage1Data()
        If data.Countries.Count = 0 Then
            TabControl1.SelectedTab = TabPage1
            MessageBox.Show("Check at least one country on the Destinations tab first.")
            Return Nothing
        End If

        ' Keep edits still sitting in the boxes of the Day By Day / Transfer Ways tabs.
        CommitDayBoxes()
        If TabControl4.SelectedTab IsNot Nothing Then CommitTransferBoxes(TabControl4.SelectedTab.Name)

        data.Tag = New VersionExtras With {
            .DepartureArrival = CaptureDepartureArrival(warning),
            .Legs = ListBox1.Items.Cast(Of Object)().Where(Function(i) TypeOf i Is Flight OrElse TypeOf i Is LayOver).ToList(),
            .Including = CollectPricingRows(Panel2),
            .NotIncluding = CollectPricingRows(pnlNotIncluding),
            .Days = ListBox2.Items.OfType(Of DayPlan)().Select(Function(p) p.Clone()).ToList(),
            .PricingPolicy = CollectPricingRows(tabPricingpolicy),
            .Additions = CollectPricingRows(Additions),
            .TransferWays = CopyTransferWays(_transferWayLines),
            .Laces = TypedLineControls().Select(Function(c) TypedLine.FromControl(c)).ToList(),
            .Prices = ListBox3.Items.OfType(Of PriceEntry)().Select(Function(p) p.Clone()).ToList(),
            .Vendor = If(_selectedVendor Is Nothing, Nothing, _selectedVendor.Clone())}
        Return data
    End Function

    ''' <summary>
    ''' Reads the Departure &amp; Arrival tab. Never blocks saving: empty
    ''' Nights / Days count as 0, and a date problem comes back as a warning
    ''' that is shown in the status bar.
    ''' </summary>
    Private Function CaptureDepartureArrival(ByRef warning As String) As DepartureArrivalInfo
        Dim nights, days As Integer
        Integer.TryParse(txtNights.Text, nights)
        Integer.TryParse(txtDays.Text, days)

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

        Dim errMsg As String = CheckDates(info)
        If errMsg <> "" Then warning = "   Note (Departure & Arrival): " & errMsg
        Return info
    End Function

    ''' <summary>Runs the BookingSearchFilter checks; returns "" when the dates are fine.</summary>
    Private Function CheckDates(info As DepartureArrivalInfo) As String
        Try
            Dim filter = BookingSearchFilter.FromForm(
                info.Mode,
                info.RegFromEnabled, info.RegFrom, info.RegToEnabled, info.RegTo,
                info.TravFromEnabled, info.TravFrom, info.TravToEnabled, info.TravTo,
                info.RegMonthsEnabled, info.RegMonths, info.TravMonthsEnabled, info.TravMonths,
                info.Nights, info.Days)
            Dim errMsg As String = ""
            If filter.IsValid(errMsg) Then Return ""
            Return errMsg
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    ''' <summary>Copies the Trip Title tab into the trip node (its text in the tree).</summary>
    Private Sub SaveTripTitle(root As TripRootNode)
        Dim title As String = txbxTripTitle.TextBox1.Text.Trim()
        If title = "" Then Exit Sub   ' keep the old title rather than blank it
        root.Title = New TitleField(txbxTripTitle.CheckBox1.Checked, title)
        root.SubTitle = New TitleField(txbxTripSubTitle.CheckBox1.Checked, txbxTripSubTitle.TextBox1.Text)
        root.Text = title
    End Sub

    Private Sub ShowTripTitle(root As TripRootNode)
        txbxTripTitle.CheckBox1.Checked = root.Title.IsEnabled
        txbxTripTitle.TextBox1.Text = root.Title.Text
        txbxTripSubTitle.CheckBox1.Checked = root.SubTitle.IsEnabled
        txbxTripSubTitle.TextBox1.Text = root.SubTitle.Text
    End Sub

    ' ---- what is open --------------------------------------------------------

    ''' <summary>The trip open in the editor (Nothing = none).</summary>
    Private _currentTrip As TripRootNode
    ''' <summary>The version open in the editor (Nothing = none, e.g. a brand-new trip).</summary>
    Private _currentVersion As TravelFormData

    Private Sub SetCurrentTrip(root As TripRootNode)
        _currentTrip = root
        UpdateEditingHeader()
    End Sub

    ''' <summary>Opens a version (its trip becomes the open trip too); Nothing closes it.</summary>
    Private Sub SetCurrentVersion(node As TravelFormData)
        _currentVersion = node
        If node IsNot Nothing Then
            _currentTrip = TryCast(GetRootNode(node), TripRootNode)
            TreeView1.SelectedNode = node
        End If
        UpdateEditingHeader()
    End Sub

    ''' <summary>True if the node is still in the tree (not deleted or cleared).</summary>
    Private Function IsOpen(node As TreeNode) As Boolean
        Return node IsNot Nothing AndAlso node.TreeView IsNot Nothing
    End Function

    ''' <summary>
    ''' Shows what is open in the header bar, enables the Save buttons and
    ''' highlights the open trip / version in the tree.
    ''' </summary>
    Private Sub UpdateEditingHeader()
        If Not IsOpen(_currentTrip) Then _currentTrip = Nothing
        If Not IsOpen(_currentVersion) Then _currentVersion = Nothing
        _compareSet.RemoveAll(Function(v) Not IsOpen(v))   ' deleted / cleared versions

        If _currentTrip Is Nothing Then
            lblEditing.Text = "No trip open"
            lblEditingDetail.Text = "Create a trip on the Trip Title tab, or double-click a trip or version in the tree to open it."
        ElseIf _currentVersion Is Nothing Then
            lblEditing.Text = "Trip: " & _currentTrip.Text
            lblEditingDetail.Text = "No version open yet. Fill in the tabs, then press ""Save as New Version""."
        Else
            lblEditing.Text = "Trip: " & _currentTrip.Text & "   " & ChrW(8250) & "   " & _currentVersion.Text
            lblEditingDetail.Text = """Save"" writes all tabs into this version.   ""Save as New Version"" keeps it and adds a copy."
        End If

        btnSaveVersion.Enabled = (_currentTrip IsNot Nothing)
        btnSaveAsNewVersion.Enabled = (_currentTrip IsNot Nothing)
        btnSaveVersion.BackColor = If(btnSaveVersion.Enabled, Color.FromArgb(0, 120, 215), Color.FromArgb(160, 170, 185))
        HighlightOpenNodes()
    End Sub

    ''' <summary>Soft amber background on the open trip / version, blue text on the open trip.</summary>
    Private Sub HighlightOpenNodes()
        Dim openBack As Color = Color.FromArgb(255, 236, 179)
        For Each root As TreeNode In TreeView1.Nodes
            root.BackColor = If(root Is _currentTrip AndAlso _currentVersion Is Nothing, openBack, Color.Empty)
            root.ForeColor = If(root Is _currentTrip, Color.FromArgb(0, 84, 166), Color.Empty)
            For Each child As TreeNode In root.Nodes
                Dim v As TravelFormData = TryCast(child, TravelFormData)
                If v IsNot Nothing AndAlso _compareSet.Contains(v) Then
                    child.BackColor = Color.FromArgb(204, 228, 255)   ' marked for comparing (light blue)
                Else
                    child.BackColor = If(child Is _currentVersion, openBack, Color.Empty)
                End If
            Next
        Next
    End Sub

    ''' <summary>Shows a short message in the status bar at the bottom of the window.</summary>
    Private Sub SetStatus(text As String)
        lblStatus.Text = text
    End Sub

    ' ---- version helpers ----------------------------------------------------

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
    ''' Opens a tree node in the editor: a trip shows its title, a version
    ''' fills every tab. The older TravelOffers nodes hold no trip data and
    ''' are ignored.
    ''' </summary>
    Private Sub OpenNode(node As TreeNode)
        Dim root As TripRootNode = TryCast(node, TripRootNode)
        If root IsNot Nothing Then
            ShowTripTitle(root)
            SetCurrentVersion(Nothing)
            SetCurrentTrip(root)
            TreeView1.SelectedNode = root
            TabControl1.SelectedTab = TitleAndSubTitle
            SetStatus("Opened the trip """ & root.Text & """.")
            Exit Sub
        End If

        Dim data As TravelFormData = TryCast(node, TravelFormData)
        If data Is Nothing Then Exit Sub

        LoadTabPage1Data(data)
        Dim extras As VersionExtras = TryCast(data.Tag, VersionExtras)
        If extras IsNot Nothing Then
            LoadDepartureArrival(extras.DepartureArrival)
            LoadTravelLegs(extras.Legs)
            LoadPricingRows(Panel2, extras.Including)
            LoadPricingRows(pnlNotIncluding, extras.NotIncluding)
            LoadDays(extras.Days)   ' after LoadDepartureArrival, which rebuilds the day list
            LoadPricingRows(tabPricingpolicy, extras.PricingPolicy)
            LoadPricingRows(Additions, extras.Additions)
            LoadTransferWays(extras.TransferWays)
            LoadLaces(extras.Laces)
            LoadPrices(extras.Prices)
        End If
        SelectVendor(If(extras Is Nothing, Nothing, extras.Vendor))   ' no vendor saved = none selected

        ' The trip's own title wins over the copy stored inside the version.
        Dim trip As TripRootNode = TryCast(GetRootNode(data), TripRootNode)
        If trip IsNot Nothing Then ShowTripTitle(trip)

        SetCurrentVersion(data)   ' stays on the current tab, so versions are easy to compare
        SetStatus("Opened """ & data.Text & """.")
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        TreeView1.SelectedNode = e.Node
        OpenNode(e.Node)
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
    ''' The PricingWithCheckBox rows directly inside a container (a panel or
    ''' a tab page), top to bottom, so save and load always match the same
    ''' row to the same position on screen.
    ''' </summary>
    Private Function PricingRowsOf(container As Control) As List(Of PricingWithCheckBox.PricingWithCheckBox)
        Return container.Controls.OfType(Of PricingWithCheckBox.PricingWithCheckBox)().
            OrderBy(Function(r) r.Top).ToList()
    End Function

    ''' <summary>
    ''' Reads every PricingWithCheckBox row in a container, top to bottom,
    ''' using the same ToPricingItem() as "SAVE V1".
    ''' </summary>
    Private Function CollectPricingRows(container As Control) As PricingItem.PricingCollection
        Dim rows As New PricingItem.PricingCollection()
        For Each row In PricingRowsOf(container)
            rows.Add(row.ToPricingItem())
        Next
        Return rows
    End Function

    ''' <summary>
    ''' Puts saved rows back into a container, top to bottom (same matching
    ''' as "Load V1"). Does nothing if rows is Nothing.
    ''' </summary>
    Private Sub LoadPricingRows(container As Control, rows As PricingItem.PricingCollection)
        If rows Is Nothing Then Exit Sub

        Dim target = PricingRowsOf(container)
        For i As Integer = 0 To Math.Min(rows.Count, target.Count) - 1
            target(i).FromPricingItem(rows(i))
        Next
    End Sub

    ' =========================================================================
    '  TransferWays tab: 12 lines per transfer type (TabControl4 icon tab)
    ' =========================================================================

    ''' <summary>Lines saved per TabControl4 page name (e.g. "TabPage3").</summary>
    Private _transferWayLines As New Dictionary(Of String, List(Of DayLine))

    ''' <summary>The line boxes on the TransferWays tab, top to bottom.</summary>
    Private Function TransferWayBoxes() As List(Of TextBoxWithCheckBox.TextBoxWithCheckBox)
        Return TransferWays.Controls.OfType(Of TextBoxWithCheckBox.TextBoxWithCheckBox)().
            OrderBy(Function(b) b.Top).ToList()
    End Function

    ''' <summary>"Save Lines": stores the line boxes for the transfer type selected in TabControl4.</summary>
    Private Sub btnSaveTransferWay_Click(sender As Object, e As EventArgs) Handles btnSaveTransferWay.Click
        If TabControl4.SelectedTab Is Nothing Then Exit Sub
        _transferWayLines(TabControl4.SelectedTab.Name) = ReadTransferBoxes()
        SetStatus("Lines saved for this transfer type. Press ""Save"" at the top to store them in the version.")
    End Sub

    ''' <summary>Leaving a transfer type keeps what was typed for it.</summary>
    Private Sub TabControl4_Deselecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl4.Deselecting
        If e.TabPage IsNot Nothing Then CommitTransferBoxes(e.TabPage.Name)
    End Sub

    ''' <summary>Switching transfer type shows that type's saved lines.</summary>
    Private Sub TabControl4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl4.SelectedIndexChanged
        ShowTransferWayLines()
    End Sub

    Private Function ReadTransferBoxes() As List(Of DayLine)
        Return TransferWayBoxes().Select(Function(b) New DayLine With {.Enabled = b.CheckBox1.Checked, .Text = b.TextBox1.Text}).ToList()
    End Function

    ''' <summary>
    ''' Keeps the boxes for the given transfer type. Empty boxes are not stored
    ''' for a type that had nothing, so just looking at a type adds nothing.
    ''' </summary>
    Private Sub CommitTransferBoxes(tabName As String)
        Dim lines = ReadTransferBoxes()
        If _transferWayLines.ContainsKey(tabName) OrElse lines.Any(Function(l) l.Enabled OrElse l.Text <> "") Then
            _transferWayLines(tabName) = lines
        End If
    End Sub

    Private Sub ShowTransferWayLines()
        Dim lines As List(Of DayLine) = Nothing
        If TabControl4.SelectedTab IsNot Nothing Then
            _transferWayLines.TryGetValue(TabControl4.SelectedTab.Name, lines)
        End If

        Dim boxes = TransferWayBoxes()
        For i As Integer = 0 To boxes.Count - 1
            If lines IsNot Nothing AndAlso i < lines.Count Then
                boxes(i).CheckBox1.Checked = lines(i).Enabled
                boxes(i).TextBox1.Text = lines(i).Text
            Else
                boxes(i).CheckBox1.Checked = False
                boxes(i).TextBox1.Text = ""
            End If
        Next
    End Sub

    ''' <summary>Puts saved transfer lines back. Nothing = never saved: leave as is.</summary>
    Private Sub LoadTransferWays(data As Dictionary(Of String, List(Of DayLine)))
        If data Is Nothing Then Exit Sub
        _transferWayLines = CopyTransferWays(data)
        ShowTransferWayLines()
    End Sub

    Friend Shared Function CopyTransferWays(src As Dictionary(Of String, List(Of DayLine))) As Dictionary(Of String, List(Of DayLine))
        If src Is Nothing Then Return Nothing
        Dim copy As New Dictionary(Of String, List(Of DayLine))
        For Each kv In src
            copy(kv.Key) = kv.Value.Select(Function(l) New DayLine With {.Enabled = l.Enabled, .Text = l.Text}).ToList()
        Next
        Return copy
    End Function

    ' =========================================================================
    '  Laces, Stamps, and Comments tab (TabPage15)
    ' =========================================================================

    ''' <summary>The TextBoxWithTypeAndCheckbox rows on TabPage15, top to bottom.</summary>
    Private Function TypedLineControls() As List(Of TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox)
        Return TabPage15.Controls.OfType(Of TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox)().
            OrderBy(Function(c) c.Top).ToList()
    End Function

    Private Sub LoadLaces(rows As List(Of TypedLine))
        If rows Is Nothing Then Exit Sub
        Dim target = TypedLineControls()
        For i As Integer = 0 To Math.Min(rows.Count, target.Count) - 1
            rows(i).ApplyTo(target(i))
        Next
    End Sub

    ' =========================================================================
    '  Prices tab (ListBox3)
    ' =========================================================================

    ''' <summary>Double-click a price: edit it in PriceDialog.</summary>
    Private Sub ListBox3_DoubleClick(sender As Object, e As EventArgs) Handles ListBox3.DoubleClick
        Dim index As Integer = ListBox3.SelectedIndex
        Dim entry As PriceEntry = TryCast(ListBox3.SelectedItem, PriceEntry)
        If entry Is Nothing Then Exit Sub

        PriceDialog.TextBox1.Text = entry.Amount.ToString()
        SelectComboByText(PriceDialog.ComboBox1, entry.Currency)

        If PriceDialog.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim updated As PriceEntry = PriceEntryFromDialog()
        If updated Is Nothing Then Exit Sub
        ListBox3.Items(index) = updated
        ListBox3.SelectedIndex = index
    End Sub

    ''' <summary>Reads PriceDialog into a PriceEntry; Nothing (with a message) if invalid.</summary>
    Private Function PriceEntryFromDialog() As PriceEntry
        Dim amount As Double
        If Not Double.TryParse(PriceDialog.TextBox1.Text, amount) Then
            MessageBox.Show("The amount must be a number.")
            Return Nothing
        End If
        If PriceDialog.ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Choose a currency / type.")
            Return Nothing
        End If
        Return New PriceEntry With {.Amount = amount, .Currency = PriceDialog.ComboBox1.SelectedItem.ToString()}
    End Function

    Private Sub SelectComboByText(cmb As ComboBox, text As String)
        For i As Integer = 0 To cmb.Items.Count - 1
            If cmb.Items(i).ToString() = text Then
                cmb.SelectedIndex = i
                Exit Sub
            End If
        Next
        cmb.SelectedIndex = -1
    End Sub

    Private Sub LoadPrices(prices As List(Of PriceEntry))
        If prices Is Nothing Then Exit Sub
        ListBox3.Items.Clear()
        For Each p As PriceEntry In prices
            ListBox3.Items.Add(p.Clone())
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
                SetStatus("Tree saved to " & dlg.FileName & " (" & treeFile.Trips.Count & " trip(s)).")
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
            SetStatus("Loaded " & treeFile.Trips.Count & " trip(s) from " & dlg.FileName & ". Double-click a version to open it.")
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
        SetCurrentTrip(Nothing)
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
            d.NotIncluding = extras.NotIncluding
            d.Days = extras.Days
            d.PricingPolicy = extras.PricingPolicy
            d.Additions = extras.Additions
            If extras.TransferWays IsNot Nothing Then
                d.TransferWays = extras.TransferWays.Select(Function(kv) New TransferWayDto With {
                    .TabName = kv.Key, .Lines = kv.Value}).ToList()
            End If
            d.Laces = extras.Laces
            d.Prices = extras.Prices
            d.Vendor = extras.Vendor
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

        If d.DepartureArrival IsNot Nothing OrElse d.LegsSaved OrElse d.Including IsNot Nothing OrElse d.NotIncluding IsNot Nothing OrElse d.Days IsNot Nothing _
           OrElse d.PricingPolicy IsNot Nothing OrElse d.Additions IsNot Nothing _
           OrElse d.TransferWays IsNot Nothing OrElse d.Laces IsNot Nothing OrElse d.Prices IsNot Nothing OrElse d.Vendor IsNot Nothing Then
            Dim extras As New VersionExtras()
            If d.DepartureArrival IsNot Nothing Then extras.DepartureArrival = d.DepartureArrival.ToInfo()
            If d.LegsSaved Then extras.Legs = d.Legs.Select(Function(l) l.ToLeg()).ToList()
            extras.Including = d.Including
            extras.NotIncluding = d.NotIncluding
            extras.Days = d.Days
            extras.PricingPolicy = d.PricingPolicy
            extras.Additions = d.Additions
            If d.TransferWays IsNot Nothing Then
                extras.TransferWays = d.TransferWays.ToDictionary(Function(t) t.TabName, Function(t) t.Lines)
            End If
            extras.Laces = d.Laces
            extras.Prices = d.Prices
            extras.Vendor = d.Vendor
            v.Tag = extras
        End If
        v.Text = d.Text
        Return v
    End Function

    ''' <summary>"Check Dates": runs the date checks and reports the result.</summary>
    Private Sub BtnSaveDepartureAndArrival_Click(sender As Object, e As EventArgs) Handles btnSaveDepartureAndArrival.Click
        Dim warning As String = ""
        CaptureDepartureArrival(warning)
        If warning = "" Then
            SetStatus("The dates look fine.")
        Else
            MessageBox.Show(warning.Trim(), "Check Dates", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Public Property NotIncluding As PricingItem.PricingCollection
    Public Property Days As List(Of DayPlan)   ' Nothing = not saved
    Public Property PricingPolicy As PricingItem.PricingCollection
    Public Property Additions As PricingItem.PricingCollection
    Public Property TransferWays As List(Of TransferWayDto)   ' Nothing = not saved
    Public Property Laces As List(Of TypedLine)
    Public Property Prices As List(Of PriceEntry)
    Public Property Vendor As VendorInfo
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
''' One row of the Vendors table, as kept in a version (a copy, so the trip
''' still shows the vendor details it was saved with).
''' </summary>
Public Class VendorInfo
    Public Property Id As String = ""
    Public Property TitleAr As String = ""
    Public Property TitleEn As String = ""
    Public Property Nationality As String = ""
    Public Property ArNationality As String = ""
    Public Property Instagram As String = ""
    Public Property WebSite As String = ""
    Public Property Contact1 As String = ""
    Public Property Contact2 As String = ""
    Public Property Contact3 As String = ""
    Public Property Whatsapp1 As String = ""
    Public Property Whatsapp2 As String = ""
    Public Property Whatsapp3 As String = ""

    ''' <summary>"English name (Arabic name)", or whichever exists.</summary>
    Public ReadOnly Property DisplayName As String
        Get
            If TitleEn.Trim() <> "" AndAlso TitleAr.Trim() <> "" Then Return TitleEn.Trim() & "  (" & TitleAr.Trim() & ")"
            If TitleEn.Trim() <> "" Then Return TitleEn.Trim()
            If TitleAr.Trim() <> "" Then Return TitleAr.Trim()
            Return "Vendor " & Id
        End Get
    End Property

    Friend Shared Function FromRow(r As DataRow) As VendorInfo
        Return New VendorInfo With {
            .Id = Col(r, "ID"), .TitleAr = Col(r, "TitleAr"), .TitleEn = Col(r, "TitleEn"),
            .Nationality = Col(r, "Nationality"), .ArNationality = Col(r, "arNationality"),
            .Instagram = Col(r, "Instegram"), .WebSite = Col(r, "WebSite"),
            .Contact1 = Col(r, "Contact1"), .Contact2 = Col(r, "Contact2"), .Contact3 = Col(r, "Contact3"),
            .Whatsapp1 = Col(r, "Whatsapp1"), .Whatsapp2 = Col(r, "Whatsapp2"), .Whatsapp3 = Col(r, "Whatsapp3")}
    End Function

    ''' <summary>Column value as text; "" when the column is missing or empty.</summary>
    Private Shared Function Col(r As DataRow, name As String) As String
        If Not r.Table.Columns.Contains(name) OrElse IsDBNull(r(name)) Then Return ""
        Return r(name).ToString().Trim()
    End Function

    Public Function Clone() As VendorInfo
        Return DirectCast(Me.MemberwiseClone(), VendorInfo)
    End Function

    Public Overrides Function ToString() As String
        Return DisplayName
    End Function
End Class

''' <summary>One row of the Prices tab (ListBox3).</summary>
Public Class PriceEntry
    Public Property Amount As Double
    Public Property Currency As String = ""

    Public Function Clone() As PriceEntry
        Return New PriceEntry With {.Amount = Amount, .Currency = Currency}
    End Function

    ''' <summary>Same layout ListBox3 always used: amount padded to 32, then currency.</summary>
    Public Overrides Function ToString() As String
        Return Amount.ToString("#,##0").PadRight(32).Substring(0, 32) & Currency
    End Function
End Class

''' <summary>
''' One TextBoxWithTypeAndCheckbox row (Laces, Stamps, and Comments tab).
''' Read through the control's own CheckBox / TextBox / ComboBox children,
''' so it doesn't depend on their names inside the control.
''' </summary>
Public Class TypedLine
    Public Property Enabled As Boolean
    Public Property Text As String = ""
    Public Property TypeText As String = ""
    Public Property TypeIndex As Integer = -1

    Friend Shared Function FromControl(c As Control) As TypedLine
        Dim t As New TypedLine()
        Dim chk = FindChild(Of CheckBox)(c)
        Dim txt = FindChild(Of TextBox)(c)
        Dim cmb = FindChild(Of ComboBox)(c)
        If chk IsNot Nothing Then t.Enabled = chk.Checked
        If txt IsNot Nothing Then t.Text = txt.Text
        If cmb IsNot Nothing Then
            t.TypeIndex = cmb.SelectedIndex
            t.TypeText = cmb.Text
        End If
        Return t
    End Function

    Friend Sub ApplyTo(c As Control)
        Dim chk = FindChild(Of CheckBox)(c)
        Dim txt = FindChild(Of TextBox)(c)
        Dim cmb = FindChild(Of ComboBox)(c)
        If chk IsNot Nothing Then chk.Checked = Enabled
        If txt IsNot Nothing Then txt.Text = Text
        If cmb IsNot Nothing Then
            If TypeIndex >= 0 AndAlso TypeIndex < cmb.Items.Count Then
                cmb.SelectedIndex = TypeIndex
            ElseIf cmb.DropDownStyle <> ComboBoxStyle.DropDownList Then
                cmb.Text = TypeText
            End If
        End If
    End Sub

    Private Shared Function FindChild(Of T As Control)(parent As Control) As T
        For Each child As Control In parent.Controls
            If TypeOf child Is T Then Return DirectCast(child, T)
            Dim inner As T = FindChild(Of T)(child)
            If inner IsNot Nothing Then Return inner
        Next
        Return Nothing
    End Function
End Class

''' <summary>Tree file: one transfer type's lines.</summary>
Public Class TransferWayDto
    Public Property TabName As String = ""
    Public Property Lines As New List(Of DayLine)
End Class

''' <summary>One day in the Day By Day tab: its title and 13 lines.</summary>
Public Class DayPlan
    Public Property Title As String = ""
    Public Property Lines As New List(Of DayLine)

    Public Function Clone() As DayPlan
        Return New DayPlan With {
            .Title = Title,
            .Lines = Lines.Select(Function(l) New DayLine With {.Enabled = l.Enabled, .Text = l.Text}).ToList()}
    End Function

    Public Overrides Function ToString() As String
        Return Title   ' what ListBox2 shows
    End Function
End Class

''' <summary>One line of a day: its text and whether it is ticked / active.</summary>
Public Class DayLine
    Public Property Enabled As Boolean
    Public Property Text As String = ""
End Class

''' <summary>
''' Extra data kept on a version node (node.Tag), next to its TabPage1 lists.
''' Nothing in a property = that part was never saved for this version.
''' </summary>
Class VersionExtras
    Public Property DepartureArrival As DepartureArrivalInfo
    Public Property Legs As List(Of Object)   ' Flight / LayOver items from ListBox1
    Public Property Including As PricingItem.PricingCollection   ' Including tab rows (Panel2)
    Public Property NotIncluding As PricingItem.PricingCollection   ' Not Including rows (pnlNotIncluding)
    Public Property Days As List(Of DayPlan)   ' Day By Day tab (ListBox2)
    Public Property PricingPolicy As PricingItem.PricingCollection   ' Pricing Policy tab rows
    Public Property Additions As PricingItem.PricingCollection       ' Additions tab rows
    Public Property TransferWays As Dictionary(Of String, List(Of DayLine))   ' per TabControl4 page
    Public Property Laces As List(Of TypedLine)   ' Laces, Stamps, and Comments rows
    Public Property Prices As List(Of PriceEntry)   ' Prices tab (ListBox3)
    Public Property Vendor As VendorInfo   ' Vendor tab (Nothing = no vendor)

    Public Function Clone() As VersionExtras
        Return New VersionExtras With {
            .DepartureArrival = If(DepartureArrival Is Nothing, Nothing, DepartureArrival.Clone()),
            .Legs = If(Legs Is Nothing, Nothing, New List(Of Object)(Legs)),
            .Including = CopyPricing(Including),
            .NotIncluding = CopyPricing(NotIncluding),
            .Days = If(Days Is Nothing, Nothing, Days.Select(Function(p) p.Clone()).ToList()),
            .PricingPolicy = CopyPricing(PricingPolicy),
            .Additions = CopyPricing(Additions),
            .TransferWays = Form1.CopyTransferWays(TransferWays),
            .Laces = If(Laces Is Nothing, Nothing, Laces.Select(Function(l) New TypedLine With {
                .Enabled = l.Enabled, .Text = l.Text, .TypeText = l.TypeText, .TypeIndex = l.TypeIndex}).ToList()),
            .Prices = If(Prices Is Nothing, Nothing, Prices.Select(Function(p) p.Clone()).ToList()),
            .Vendor = If(Vendor Is Nothing, Nothing, Vendor.Clone())}
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
''' "Trip Title" tab ("Create Trip"). Its children are TravelFormData versions.
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