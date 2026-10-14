<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.cmsTrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpenNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbNewTrip = New System.Windows.Forms.ToolStripButton()
        Me.lblLegsHint = New System.Windows.Forms.Label()
        Me.lblPricesHint = New System.Windows.Forms.Label()
        Me.lblTransferHint = New System.Windows.Forms.Label()
        Me.lblDayLines = New System.Windows.Forms.Label()
        Me.lblDaysList = New System.Windows.Forms.Label()
        Me.lblTitleHint = New System.Windows.Forms.Label()
        Me.lblCountries = New System.Windows.Forms.Label()
        Me.tabDeveloper = New System.Windows.Forms.TabPage()
        Me.lblDeveloper = New System.Windows.Forms.Label()
        Me.lblPricingTest = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TitleAndSubTitle = New System.Windows.Forms.TabPage()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txbxTripSubTitle = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.txbxTripTitle = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.InludesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotIncludeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateTimeDurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox4 = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.btnSaveDepartureAndArrival = New System.Windows.Forms.Button()
        Me.TabControl5 = New System.Windows.Forms.TabControl()
        Me.tabSpecificDates = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkTravTo = New DateWithCheckBox.DateWithCheckBox()
        Me.chkTravFrom = New DateWithCheckBox.DateWithCheckBox()
        Me.chkRegTo = New DateWithCheckBox.DateWithCheckBox()
        Me.chkRegFrom = New DateWithCheckBox.DateWithCheckBox()
        Me.TabPage17 = New System.Windows.Forms.TabPage()
        Me.chkTravMonths = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.chkRegMonths = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.txtNights = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbxArrivalTime = New TimeWithCheckBox.TimeWithCheckBox()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.ArrivalDate = New DateWithCheckBox.DateWithCheckBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.cmbxArrivingLocation = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.cmbxArrivingCity = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.cmbxArrivingTo = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.cmbxAirLine = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.cmbxDepartureTime = New TimeWithCheckBox.TimeWithCheckBox()
        Me.cmbxDepartureDate = New DateWithCheckBox.DateWithCheckBox()
        Me.cmbxDepartureLocation = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.cmbxDepartureCity = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.cmbxDepartureFrom = New ComboBoxWithCheckBox.ComboBoxWithCheckBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txbxDuration = New System.Windows.Forms.MaskedTextBox()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btnUpdateLeg = New System.Windows.Forms.Button()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Including = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.NotIncluding = New System.Windows.Forms.TabPage()
        Me.pnlNotIncluding = New System.Windows.Forms.Panel()
        Me.DayByDay = New System.Windows.Forms.TabPage()
        Me.TextBoxWithCheckBox15 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox16 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox17 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox18 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox19 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox20 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox21 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox22 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox23 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox24 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox25 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox26 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox27 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.btnSaveDay = New System.Windows.Forms.Button()
        Me.tabPricingpolicy = New System.Windows.Forms.TabPage()
        Me.PricingWithCheckBox10 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox9 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox8 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox7 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox6 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox5 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox4 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox3 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox2 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox1 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.UserControl11 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.Additions = New System.Windows.Forms.TabPage()
        Me.PricingWithCheckBox11 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox12 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox13 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox14 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox15 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox16 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox17 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox18 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox19 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox20 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.PricingWithCheckBox21 = New PricingWithCheckBox.PricingWithCheckBox()
        Me.TransferWays = New System.Windows.Forms.TabPage()
        Me.TextBoxWithCheckBox14 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox13 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox12 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox11 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox10 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox9 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox8 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox7 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox6 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox4 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox3 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox2 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox1 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.TabPage14 = New System.Windows.Forms.TabPage()
        Me.btnSaveTransferWay = New System.Windows.Forms.Button()
        Me.TabPage15 = New System.Windows.Forms.TabPage()
        Me.TextBoxWithTypeAndCheckbox12 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox11 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox10 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox9 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox8 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox7 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox6 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox5 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox4 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox3 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox2 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.TextBoxWithTypeAndCheckbox1 = New TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox()
        Me.Prices = New System.Windows.Forms.TabPage()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlHeaderText = New System.Windows.Forms.Panel()
        Me.lblEditingDetail = New System.Windows.Forms.Label()
        Me.lblEditing = New System.Windows.Forms.Label()
        Me.flpCommands = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSaveVersion = New System.Windows.Forms.Button()
        Me.btnSaveAsNewVersion = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CountriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleAndSubtitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartureDateAndTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrivalDateAndTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeparturePortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrivalPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbSaveTree = New System.Windows.Forms.ToolStripButton()
        Me.tsbLoadTree = New System.Windows.Forms.ToolStripButton()
        Me.tsbClearTree = New System.Windows.Forms.ToolStripButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmsTrip.SuspendLayout()
        Me.tabDeveloper.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TitleAndSubTitle.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabControl5.SuspendLayout()
        Me.tabSpecificDates.SuspendLayout()
        Me.TabPage17.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.Including.SuspendLayout()
        Me.NotIncluding.SuspendLayout()
        Me.DayByDay.SuspendLayout()
        Me.tabPricingpolicy.SuspendLayout()
        Me.Additions.SuspendLayout()
        Me.TransferWays.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage15.SuspendLayout()
        Me.Prices.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlHeaderText.SuspendLayout()
        Me.flpCommands.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsTrip
        '
        Me.cmsTrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsTrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenNode, Me.mnuDeleteNode})
        Me.cmsTrip.Name = "cmsTrip"
        Me.cmsTrip.Size = New System.Drawing.Size(123, 52)
        '
        'mnuOpenNode
        '
        Me.mnuOpenNode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOpenNode.Name = "mnuOpenNode"
        Me.mnuOpenNode.Size = New System.Drawing.Size(122, 24)
        Me.mnuOpenNode.Text = "Open"
        '
        'mnuDeleteNode
        '
        Me.mnuDeleteNode.Name = "mnuDeleteNode"
        Me.mnuDeleteNode.Size = New System.Drawing.Size(122, 24)
        Me.mnuDeleteNode.Text = "Delete"
        '
        'tsbNewTrip
        '
        Me.tsbNewTrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNewTrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbNewTrip.Name = "tsbNewTrip"
        Me.tsbNewTrip.Size = New System.Drawing.Size(76, 24)
        Me.tsbNewTrip.Text = "New Trip"
        Me.tsbNewTrip.ToolTipText = "Start a new trip"
        '
        'lblLegsHint
        '
        Me.lblLegsHint.AutoSize = True
        Me.lblLegsHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblLegsHint.Location = New System.Drawing.Point(887, 625)
        Me.lblLegsHint.Name = "lblLegsHint"
        Me.lblLegsHint.Size = New System.Drawing.Size(158, 20)
        Me.lblLegsHint.TabIndex = 90
        Me.lblLegsHint.Text = "Click an item to edit it."
        '
        'lblPricesHint
        '
        Me.lblPricesHint.AutoSize = True
        Me.lblPricesHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPricesHint.Location = New System.Drawing.Point(20, 726)
        Me.lblPricesHint.Name = "lblPricesHint"
        Me.lblPricesHint.Size = New System.Drawing.Size(206, 20)
        Me.lblPricesHint.TabIndex = 90
        Me.lblPricesHint.Text = "Double-click a price to edit it."
        '
        'lblTransferHint
        '
        Me.lblTransferHint.AutoSize = True
        Me.lblTransferHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTransferHint.Location = New System.Drawing.Point(16, 98)
        Me.lblTransferHint.Name = "lblTransferHint"
        Me.lblTransferHint.Size = New System.Drawing.Size(608, 20)
        Me.lblTransferHint.TabIndex = 90
        Me.lblTransferHint.Text = "Pick a transfer type above and fill in its lines. Changes are kept when you pick " &
    "another type."
        '
        'lblDayLines
        '
        Me.lblDayLines.AutoSize = True
        Me.lblDayLines.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDayLines.Location = New System.Drawing.Point(409, 34)
        Me.lblDayLines.Name = "lblDayLines"
        Me.lblDayLines.Size = New System.Drawing.Size(585, 20)
        Me.lblDayLines.TabIndex = 90
        Me.lblDayLines.Text = "Lines for the selected day (tick = include). Changes are kept when you pick anoth" &
    "er day."
        '
        'lblDaysList
        '
        Me.lblDaysList.AutoSize = True
        Me.lblDaysList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDaysList.Location = New System.Drawing.Point(7, 34)
        Me.lblDaysList.Name = "lblDaysList"
        Me.lblDaysList.Size = New System.Drawing.Size(111, 20)
        Me.lblDaysList.TabIndex = 90
        Me.lblDaysList.Text = "Days of the trip"
        '
        'lblTitleHint
        '
        Me.lblTitleHint.AutoSize = True
        Me.lblTitleHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTitleHint.Location = New System.Drawing.Point(28, 103)
        Me.lblTitleHint.Name = "lblTitleHint"
        Me.lblTitleHint.Size = New System.Drawing.Size(723, 20)
        Me.lblTitleHint.TabIndex = 90
        Me.lblTitleHint.Text = "Type the trip title, then press ""Create Trip"". To change an existing trip, open i" &
    "t from the tree and press ""Save""."
        '
        'lblCountries
        '
        Me.lblCountries.AutoSize = True
        Me.lblCountries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCountries.Location = New System.Drawing.Point(24, 23)
        Me.lblCountries.Name = "lblCountries"
        Me.lblCountries.Size = New System.Drawing.Size(71, 20)
        Me.lblCountries.TabIndex = 90
        Me.lblCountries.Text = "Countries"
        '
        'tabDeveloper
        '
        Me.tabDeveloper.Controls.Add(Me.lblDeveloper)
        Me.tabDeveloper.Controls.Add(Me.lblPricingTest)
        Me.tabDeveloper.Controls.Add(Me.Button1)
        Me.tabDeveloper.Controls.Add(Me.TextBox1)
        Me.tabDeveloper.Controls.Add(Me.Button6)
        Me.tabDeveloper.Controls.Add(Me.CheckBox1)
        Me.tabDeveloper.Controls.Add(Me.Button9)
        Me.tabDeveloper.Controls.Add(Me.Button10)
        Me.tabDeveloper.Controls.Add(Me.Button11)
        Me.tabDeveloper.Controls.Add(Me.Button12)
        Me.tabDeveloper.Location = New System.Drawing.Point(4, 58)
        Me.tabDeveloper.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabDeveloper.Name = "tabDeveloper"
        Me.tabDeveloper.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabDeveloper.Size = New System.Drawing.Size(1115, 774)
        Me.tabDeveloper.TabIndex = 12
        Me.tabDeveloper.Text = "Developer"
        Me.tabDeveloper.UseVisualStyleBackColor = True
        '
        'lblDeveloper
        '
        Me.lblDeveloper.AutoSize = True
        Me.lblDeveloper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDeveloper.Location = New System.Drawing.Point(19, 17)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(428, 20)
        Me.lblDeveloper.TabIndex = 0
        Me.lblDeveloper.Text = "Developer tools. These are for testing and are not part of a trip."
        '
        'lblPricingTest
        '
        Me.lblPricingTest.AutoSize = True
        Me.lblPricingTest.Location = New System.Drawing.Point(19, 357)
        Me.lblPricingTest.Name = "lblPricingTest"
        Me.lblPricingTest.Size = New System.Drawing.Size(348, 20)
        Me.lblPricingTest.TabIndex = 8
        Me.lblPricingTest.Text = "Including tab rows <-> Pricing.txt (next to the .exe):"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 49)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 32)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Run SQL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(19, 89)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(653, 184)
        Me.TextBox1.TabIndex = 3
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(19, 290)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(175, 32)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Item Properties..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(210, 297)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(113, 24)
        Me.CheckBox1.TabIndex = 71
        Me.CheckBox1.Text = "Tri-state test"
        Me.CheckBox1.ThreeState = True
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(19, 384)
        Me.Button9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(140, 32)
        Me.Button9.TabIndex = 1
        Me.Button9.Text = "Save (V1)"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(166, 384)
        Me.Button10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(140, 32)
        Me.Button10.TabIndex = 2
        Me.Button10.Text = "Load (V1)"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(19, 423)
        Me.Button11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(140, 32)
        Me.Button11.TabIndex = 3
        Me.Button11.Text = "Save (V2)"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(166, 423)
        Me.Button12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(140, 32)
        Me.Button12.TabIndex = 4
        Me.Button12.Text = "Load (V2)"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 960)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1528, 25)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1511, 20)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Ready."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(385, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(6, 960)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TabControl1)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(391, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(7, 7, 7, 7)
        Me.pnlMain.Size = New System.Drawing.Size(1137, 960)
        Me.pnlMain.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TitleAndSubTitle)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.Including)
        Me.TabControl1.Controls.Add(Me.NotIncluding)
        Me.TabControl1.Controls.Add(Me.DayByDay)
        Me.TabControl1.Controls.Add(Me.tabPricingpolicy)
        Me.TabControl1.Controls.Add(Me.Additions)
        Me.TabControl1.Controls.Add(Me.TransferWays)
        Me.TabControl1.Controls.Add(Me.TabPage15)
        Me.TabControl1.Controls.Add(Me.Prices)
        Me.TabControl1.Controls.Add(Me.tabDeveloper)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 73)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(10, 4)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1123, 880)
        Me.TabControl1.TabIndex = 16
        '
        'TitleAndSubTitle
        '
        Me.TitleAndSubTitle.Controls.Add(Me.Button8)
        Me.TitleAndSubTitle.Controls.Add(Me.txbxTripSubTitle)
        Me.TitleAndSubTitle.Controls.Add(Me.txbxTripTitle)
        Me.TitleAndSubTitle.Controls.Add(Me.lblTitleHint)
        Me.TitleAndSubTitle.Location = New System.Drawing.Point(4, 58)
        Me.TitleAndSubTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TitleAndSubTitle.Name = "TitleAndSubTitle"
        Me.TitleAndSubTitle.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TitleAndSubTitle.Size = New System.Drawing.Size(1115, 818)
        Me.TitleAndSubTitle.TabIndex = 11
        Me.TitleAndSubTitle.Text = "Trip Title"
        Me.TitleAndSubTitle.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(717, 22)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(140, 32)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Create Trip"
        Me.ToolTip1.SetToolTip(Me.Button8, "Add a new trip to the tree with this title.")
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txbxTripSubTitle
        '
        Me.txbxTripSubTitle.BackColor = System.Drawing.Color.Transparent
        Me.txbxTripSubTitle.lcTitle = "Subtitle"
        Me.txbxTripSubTitle.length = 400
        Me.txbxTripSubTitle.Location = New System.Drawing.Point(28, 60)
        Me.txbxTripSubTitle.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txbxTripSubTitle.Name = "txbxTripSubTitle"
        Me.txbxTripSubTitle.Size = New System.Drawing.Size(556, 28)
        Me.txbxTripSubTitle.TabIndex = 1
        '
        'txbxTripTitle
        '
        Me.txbxTripTitle.BackColor = System.Drawing.Color.Transparent
        Me.txbxTripTitle.lcTitle = "Title"
        Me.txbxTripTitle.length = 500
        Me.txbxTripTitle.Location = New System.Drawing.Point(28, 25)
        Me.txbxTripTitle.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txbxTripTitle.Name = "txbxTripTitle"
        Me.txbxTripTitle.Size = New System.Drawing.Size(673, 28)
        Me.txbxTripTitle.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckedListBox1)
        Me.TabPage1.Controls.Add(Me.CheckedListBox2)
        Me.TabPage1.Controls.Add(Me.CheckedListBox3)
        Me.TabPage1.Controls.Add(Me.CheckedListBox4)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.lblCountries)
        Me.TabPage1.Location = New System.Drawing.Point(4, 58)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1115, 818)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Destinations"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(24, 44)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(661, 180)
        Me.CheckedListBox1.TabIndex = 8
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InludesToolStripMenuItem, Me.NotIncludeToolStripMenuItem, Me.DateTimeDurationToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(216, 76)
        '
        'InludesToolStripMenuItem
        '
        Me.InludesToolStripMenuItem.Name = "InludesToolStripMenuItem"
        Me.InludesToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.InludesToolStripMenuItem.Text = "Inludes"
        '
        'NotIncludeToolStripMenuItem
        '
        Me.NotIncludeToolStripMenuItem.Name = "NotIncludeToolStripMenuItem"
        Me.NotIncludeToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.NotIncludeToolStripMenuItem.Text = "not include"
        '
        'DateTimeDurationToolStripMenuItem
        '
        Me.DateTimeDurationToolStripMenuItem.Name = "DateTimeDurationToolStripMenuItem"
        Me.DateTimeDurationToolStripMenuItem.Size = New System.Drawing.Size(215, 24)
        Me.DateTimeDurationToolStripMenuItem.Text = "Date, Time, Duration"
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(28, 284)
        Me.CheckedListBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(216, 356)
        Me.CheckedListBox2.TabIndex = 9
        Me.CheckedListBox2.ThreeDCheckBoxes = True
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Location = New System.Drawing.Point(248, 284)
        Me.CheckedListBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(216, 356)
        Me.CheckedListBox3.TabIndex = 10
        '
        'CheckedListBox4
        '
        Me.CheckedListBox4.CheckOnClick = True
        Me.CheckedListBox4.FormattingEnabled = True
        Me.CheckedListBox4.Location = New System.Drawing.Point(469, 284)
        Me.CheckedListBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CheckedListBox4.Name = "CheckedListBox4"
        Me.CheckedListBox4.Size = New System.Drawing.Size(216, 356)
        Me.CheckedListBox4.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(24, 265)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cities"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(248, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Stay"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(469, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Attraction"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.btnSaveDepartureAndArrival)
        Me.TabPage6.Controls.Add(Me.TabControl5)
        Me.TabPage6.Controls.Add(Me.Label21)
        Me.TabPage6.Controls.Add(Me.Label19)
        Me.TabPage6.Controls.Add(Me.txtDays)
        Me.TabPage6.Controls.Add(Me.txtNights)
        Me.TabPage6.Controls.Add(Me.Label20)
        Me.TabPage6.Location = New System.Drawing.Point(4, 58)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage6.Size = New System.Drawing.Size(1115, 818)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Departure && Arrival"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'btnSaveDepartureAndArrival
        '
        Me.btnSaveDepartureAndArrival.Location = New System.Drawing.Point(28, 393)
        Me.btnSaveDepartureAndArrival.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveDepartureAndArrival.Name = "btnSaveDepartureAndArrival"
        Me.btnSaveDepartureAndArrival.Size = New System.Drawing.Size(324, 28)
        Me.btnSaveDepartureAndArrival.TabIndex = 72
        Me.btnSaveDepartureAndArrival.Text = "Check Dates"
        Me.ToolTip1.SetToolTip(Me.btnSaveDepartureAndArrival, "Check that the dates and duration make sense.")
        Me.btnSaveDepartureAndArrival.UseVisualStyleBackColor = True
        '
        'TabControl5
        '
        Me.TabControl5.Controls.Add(Me.tabSpecificDates)
        Me.TabControl5.Controls.Add(Me.TabPage17)
        Me.TabControl5.Location = New System.Drawing.Point(20, 11)
        Me.TabControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl5.Name = "TabControl5"
        Me.TabControl5.SelectedIndex = 0
        Me.TabControl5.Size = New System.Drawing.Size(332, 281)
        Me.TabControl5.TabIndex = 20
        '
        'tabSpecificDates
        '
        Me.tabSpecificDates.Controls.Add(Me.Label3)
        Me.tabSpecificDates.Controls.Add(Me.Label7)
        Me.tabSpecificDates.Controls.Add(Me.chkTravTo)
        Me.tabSpecificDates.Controls.Add(Me.chkTravFrom)
        Me.tabSpecificDates.Controls.Add(Me.chkRegTo)
        Me.tabSpecificDates.Controls.Add(Me.chkRegFrom)
        Me.tabSpecificDates.Location = New System.Drawing.Point(4, 29)
        Me.tabSpecificDates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabSpecificDates.Name = "tabSpecificDates"
        Me.tabSpecificDates.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabSpecificDates.Size = New System.Drawing.Size(324, 248)
        Me.tabSpecificDates.TabIndex = 0
        Me.tabSpecificDates.Text = "Specific Dates"
        Me.tabSpecificDates.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(15, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Registeration During"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(15, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Travel During"
        '
        'chkTravTo
        '
        Me.chkTravTo.BackColor = System.Drawing.SystemColors.Control
        Me.chkTravTo.lcTitle = "To"
        Me.chkTravTo.Location = New System.Drawing.Point(19, 185)
        Me.chkTravTo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkTravTo.Name = "chkTravTo"
        Me.chkTravTo.Size = New System.Drawing.Size(232, 28)
        Me.chkTravTo.TabIndex = 3
        '
        'chkTravFrom
        '
        Me.chkTravFrom.BackColor = System.Drawing.SystemColors.Control
        Me.chkTravFrom.lcTitle = "From"
        Me.chkTravFrom.Location = New System.Drawing.Point(19, 149)
        Me.chkTravFrom.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkTravFrom.Name = "chkTravFrom"
        Me.chkTravFrom.Size = New System.Drawing.Size(232, 28)
        Me.chkTravFrom.TabIndex = 2
        '
        'chkRegTo
        '
        Me.chkRegTo.BackColor = System.Drawing.SystemColors.Control
        Me.chkRegTo.lcTitle = "To"
        Me.chkRegTo.Location = New System.Drawing.Point(19, 79)
        Me.chkRegTo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkRegTo.Name = "chkRegTo"
        Me.chkRegTo.Size = New System.Drawing.Size(232, 28)
        Me.chkRegTo.TabIndex = 1
        '
        'chkRegFrom
        '
        Me.chkRegFrom.BackColor = System.Drawing.SystemColors.Control
        Me.chkRegFrom.lcTitle = "From"
        Me.chkRegFrom.Location = New System.Drawing.Point(19, 43)
        Me.chkRegFrom.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkRegFrom.Name = "chkRegFrom"
        Me.chkRegFrom.Size = New System.Drawing.Size(232, 28)
        Me.chkRegFrom.TabIndex = 0
        '
        'TabPage17
        '
        Me.TabPage17.Controls.Add(Me.chkTravMonths)
        Me.TabPage17.Controls.Add(Me.chkRegMonths)
        Me.TabPage17.Controls.Add(Me.Label22)
        Me.TabPage17.Controls.Add(Me.Label23)
        Me.TabPage17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.TabPage17.Location = New System.Drawing.Point(4, 29)
        Me.TabPage17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage17.Name = "TabPage17"
        Me.TabPage17.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage17.Size = New System.Drawing.Size(324, 248)
        Me.TabPage17.TabIndex = 1
        Me.TabPage17.Text = "Months Names"
        Me.TabPage17.UseVisualStyleBackColor = True
        '
        'chkTravMonths
        '
        Me.chkTravMonths.BackColor = System.Drawing.Color.Transparent
        Me.chkTravMonths.lcTitle = Nothing
        Me.chkTravMonths.length = 150
        Me.chkTravMonths.Location = New System.Drawing.Point(19, 122)
        Me.chkTravMonths.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkTravMonths.Name = "chkTravMonths"
        Me.chkTravMonths.Size = New System.Drawing.Size(297, 28)
        Me.chkTravMonths.TabIndex = 14
        '
        'chkRegMonths
        '
        Me.chkRegMonths.BackColor = System.Drawing.Color.Transparent
        Me.chkRegMonths.lcTitle = Nothing
        Me.chkRegMonths.length = 150
        Me.chkRegMonths.Location = New System.Drawing.Point(19, 57)
        Me.chkRegMonths.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkRegMonths.Name = "chkRegMonths"
        Me.chkRegMonths.Size = New System.Drawing.Size(297, 28)
        Me.chkRegMonths.TabIndex = 13
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(15, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(150, 17)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Registeration During"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(15, 102)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 17)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Travel During"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(234, 346)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 20)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Days"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(234, 314)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 20)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Nights"
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(108, 342)
        Me.txtDays.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(47, 27)
        Me.txtDays.TabIndex = 16
        '
        'txtNights
        '
        Me.txtNights.Location = New System.Drawing.Point(108, 310)
        Me.txtNights.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNights.Name = "txtNights"
        Me.txtNights.Size = New System.Drawing.Size(47, 27)
        Me.txtNights.TabIndex = 14
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(24, 314)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 20)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Duration"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.TabControl3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.ListBox1)
        Me.TabPage2.Controls.Add(Me.btnUpdateLeg)
        Me.TabPage2.Controls.Add(Me.txtTitle)
        Me.TabPage2.Controls.Add(Me.lblLegsHint)
        Me.TabPage2.Location = New System.Drawing.Point(4, 58)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1115, 774)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Travel And Layover"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(31, 49)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 17)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "Title"
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage8)
        Me.TabControl3.Controls.Add(Me.TabPage9)
        Me.TabControl3.Location = New System.Drawing.Point(12, 78)
        Me.TabControl3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(820, 681)
        Me.TabControl3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl3.TabIndex = 71
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.RadioButton8)
        Me.TabPage8.Controls.Add(Me.cmbxArrivalTime)
        Me.TabPage8.Controls.Add(Me.RadioButton7)
        Me.TabPage8.Controls.Add(Me.ArrivalDate)
        Me.TabPage8.Controls.Add(Me.RadioButton6)
        Me.TabPage8.Controls.Add(Me.cmbxArrivingLocation)
        Me.TabPage8.Controls.Add(Me.RadioButton5)
        Me.TabPage8.Controls.Add(Me.cmbxArrivingCity)
        Me.TabPage8.Controls.Add(Me.RadioButton4)
        Me.TabPage8.Controls.Add(Me.RadioButton3)
        Me.TabPage8.Controls.Add(Me.cmbxArrivingTo)
        Me.TabPage8.Controls.Add(Me.RadioButton2)
        Me.TabPage8.Controls.Add(Me.cmbxAirLine)
        Me.TabPage8.Controls.Add(Me.RadioButton1)
        Me.TabPage8.Controls.Add(Me.cmbxDepartureTime)
        Me.TabPage8.Controls.Add(Me.cmbxDepartureDate)
        Me.TabPage8.Controls.Add(Me.cmbxDepartureLocation)
        Me.TabPage8.Controls.Add(Me.cmbxDepartureCity)
        Me.TabPage8.Controls.Add(Me.cmbxDepartureFrom)
        Me.TabPage8.Controls.Add(Me.LinkLabel2)
        Me.TabPage8.Controls.Add(Me.LinkLabel1)
        Me.TabPage8.Controls.Add(Me.Label13)
        Me.TabPage8.Controls.Add(Me.txbxDuration)
        Me.TabPage8.Location = New System.Drawing.Point(4, 29)
        Me.TabPage8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage8.Size = New System.Drawing.Size(812, 648)
        Me.TabPage8.TabIndex = 0
        Me.TabPage8.Text = "Move"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton8.ImageIndex = 7
        Me.RadioButton8.ImageList = Me.ImageList1
        Me.RadioButton8.Location = New System.Drawing.Point(464, 15)
        Me.RadioButton8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton8.TabIndex = 79
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Tag = "Cruise"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Airline.png")
        Me.ImageList1.Images.SetKeyName(1, "CARAVAN.png")
        Me.ImageList1.Images.SetKeyName(2, "denali (1).png")
        Me.ImageList1.Images.SetKeyName(3, "denali.png")
        Me.ImageList1.Images.SetKeyName(4, "Hiking.png")
        Me.ImageList1.Images.SetKeyName(5, "Train.jpg")
        Me.ImageList1.Images.SetKeyName(6, "VIP_VAN.png")
        Me.ImageList1.Images.SetKeyName(7, "Cruise.png")
        Me.ImageList1.Images.SetKeyName(8, "denali (1).png")
        '
        'cmbxArrivalTime
        '
        Me.cmbxArrivalTime.lcTitle = Nothing
        Me.cmbxArrivalTime.length = 0
        Me.cmbxArrivalTime.Location = New System.Drawing.Point(21, 522)
        Me.cmbxArrivalTime.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxArrivalTime.Name = "cmbxArrivalTime"
        Me.cmbxArrivalTime.Size = New System.Drawing.Size(182, 30)
        Me.cmbxArrivalTime.TabIndex = 81
        '
        'RadioButton7
        '
        Me.RadioButton7.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton7.ImageIndex = 6
        Me.RadioButton7.ImageList = Me.ImageList1
        Me.RadioButton7.Location = New System.Drawing.Point(400, 15)
        Me.RadioButton7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton7.TabIndex = 78
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Tag = "VIP Bus"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'ArrivalDate
        '
        Me.ArrivalDate.BackColor = System.Drawing.Color.Transparent
        Me.ArrivalDate.lcTitle = "Date"
        Me.ArrivalDate.Location = New System.Drawing.Point(21, 494)
        Me.ArrivalDate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ArrivalDate.Name = "ArrivalDate"
        Me.ArrivalDate.Size = New System.Drawing.Size(204, 28)
        Me.ArrivalDate.TabIndex = 80
        '
        'RadioButton6
        '
        Me.RadioButton6.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton6.ImageIndex = 5
        Me.RadioButton6.ImageList = Me.ImageList1
        Me.RadioButton6.Location = New System.Drawing.Point(336, 15)
        Me.RadioButton6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton6.TabIndex = 77
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Tag = "Train"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'cmbxArrivingLocation
        '
        Me.cmbxArrivingLocation.BackColor = System.Drawing.Color.Transparent
        Me.cmbxArrivingLocation.lcTitle = "Arrival Location"
        Me.cmbxArrivingLocation.Length = 450
        Me.cmbxArrivingLocation.Location = New System.Drawing.Point(29, 459)
        Me.cmbxArrivingLocation.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxArrivingLocation.Name = "cmbxArrivingLocation"
        Me.cmbxArrivingLocation.Order = ComboBoxWithCheckBox.ControlOrder.Horizontal
        Me.cmbxArrivingLocation.Size = New System.Drawing.Size(528, 37)
        Me.cmbxArrivingLocation.TabIndex = 79
        '
        'RadioButton5
        '
        Me.RadioButton5.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton5.ImageIndex = 4
        Me.RadioButton5.ImageList = Me.ImageList1
        Me.RadioButton5.Location = New System.Drawing.Point(272, 15)
        Me.RadioButton5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton5.TabIndex = 76
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Tag = "Hike"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'cmbxArrivingCity
        '
        Me.cmbxArrivingCity.BackColor = System.Drawing.Color.Transparent
        Me.cmbxArrivingCity.lcTitle = "City"
        Me.cmbxArrivingCity.Length = 0
        Me.cmbxArrivingCity.Location = New System.Drawing.Point(197, 389)
        Me.cmbxArrivingCity.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxArrivingCity.Name = "cmbxArrivingCity"
        Me.cmbxArrivingCity.Order = ComboBoxWithCheckBox.ControlOrder.Vertical
        Me.cmbxArrivingCity.Size = New System.Drawing.Size(167, 69)
        Me.cmbxArrivingCity.TabIndex = 78
        '
        'RadioButton4
        '
        Me.RadioButton4.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton4.ImageIndex = 3
        Me.RadioButton4.ImageList = Me.ImageList1
        Me.RadioButton4.Location = New System.Drawing.Point(208, 15)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton4.TabIndex = 75
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Tag = "Bus"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton3.ImageIndex = 2
        Me.RadioButton3.ImageList = Me.ImageList1
        Me.RadioButton3.Location = New System.Drawing.Point(143, 15)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton3.TabIndex = 74
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Tag = "GMC"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'cmbxArrivingTo
        '
        Me.cmbxArrivingTo.BackColor = System.Drawing.Color.Transparent
        Me.cmbxArrivingTo.lcTitle = "Arriving To"
        Me.cmbxArrivingTo.Length = 0
        Me.cmbxArrivingTo.Location = New System.Drawing.Point(29, 389)
        Me.cmbxArrivingTo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxArrivingTo.Name = "cmbxArrivingTo"
        Me.cmbxArrivingTo.Order = ComboBoxWithCheckBox.ControlOrder.Vertical
        Me.cmbxArrivingTo.Size = New System.Drawing.Size(167, 69)
        Me.cmbxArrivingTo.TabIndex = 77
        '
        'RadioButton2
        '
        Me.RadioButton2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton2.ImageIndex = 1
        Me.RadioButton2.ImageList = Me.ImageList1
        Me.RadioButton2.Location = New System.Drawing.Point(79, 15)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton2.TabIndex = 73
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "Caravan"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'cmbxAirLine
        '
        Me.cmbxAirLine.BackColor = System.Drawing.Color.Transparent
        Me.cmbxAirLine.lcTitle = "Operator"
        Me.cmbxAirLine.Length = 450
        Me.cmbxAirLine.Location = New System.Drawing.Point(29, 288)
        Me.cmbxAirLine.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxAirLine.Name = "cmbxAirLine"
        Me.cmbxAirLine.Order = ComboBoxWithCheckBox.ControlOrder.Vertical
        Me.cmbxAirLine.Size = New System.Drawing.Size(528, 69)
        Me.cmbxAirLine.TabIndex = 76
        '
        'RadioButton1
        '
        Me.RadioButton1.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton1.ImageIndex = 0
        Me.RadioButton1.ImageList = Me.ImageList1
        Me.RadioButton1.Location = New System.Drawing.Point(15, 15)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(64, 68)
        Me.RadioButton1.TabIndex = 72
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "Airplane"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'cmbxDepartureTime
        '
        Me.cmbxDepartureTime.lcTitle = Nothing
        Me.cmbxDepartureTime.length = 0
        Me.cmbxDepartureTime.Location = New System.Drawing.Point(21, 230)
        Me.cmbxDepartureTime.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxDepartureTime.Name = "cmbxDepartureTime"
        Me.cmbxDepartureTime.Size = New System.Drawing.Size(182, 30)
        Me.cmbxDepartureTime.TabIndex = 75
        '
        'cmbxDepartureDate
        '
        Me.cmbxDepartureDate.BackColor = System.Drawing.Color.Transparent
        Me.cmbxDepartureDate.lcTitle = "Date"
        Me.cmbxDepartureDate.Location = New System.Drawing.Point(21, 204)
        Me.cmbxDepartureDate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxDepartureDate.Name = "cmbxDepartureDate"
        Me.cmbxDepartureDate.Size = New System.Drawing.Size(204, 28)
        Me.cmbxDepartureDate.TabIndex = 74
        '
        'cmbxDepartureLocation
        '
        Me.cmbxDepartureLocation.BackColor = System.Drawing.Color.Transparent
        Me.cmbxDepartureLocation.lcTitle = "Departure From"
        Me.cmbxDepartureLocation.Length = 450
        Me.cmbxDepartureLocation.Location = New System.Drawing.Point(29, 176)
        Me.cmbxDepartureLocation.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxDepartureLocation.Name = "cmbxDepartureLocation"
        Me.cmbxDepartureLocation.Order = ComboBoxWithCheckBox.ControlOrder.Horizontal
        Me.cmbxDepartureLocation.Size = New System.Drawing.Size(528, 37)
        Me.cmbxDepartureLocation.TabIndex = 73
        '
        'cmbxDepartureCity
        '
        Me.cmbxDepartureCity.BackColor = System.Drawing.Color.Transparent
        Me.cmbxDepartureCity.lcTitle = "City"
        Me.cmbxDepartureCity.Length = 0
        Me.cmbxDepartureCity.Location = New System.Drawing.Point(181, 108)
        Me.cmbxDepartureCity.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxDepartureCity.Name = "cmbxDepartureCity"
        Me.cmbxDepartureCity.Order = ComboBoxWithCheckBox.ControlOrder.Vertical
        Me.cmbxDepartureCity.Size = New System.Drawing.Size(167, 69)
        Me.cmbxDepartureCity.TabIndex = 72
        '
        'cmbxDepartureFrom
        '
        Me.cmbxDepartureFrom.BackColor = System.Drawing.Color.Transparent
        Me.cmbxDepartureFrom.lcTitle = "Departure From"
        Me.cmbxDepartureFrom.Length = 0
        Me.cmbxDepartureFrom.Location = New System.Drawing.Point(29, 108)
        Me.cmbxDepartureFrom.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbxDepartureFrom.Name = "cmbxDepartureFrom"
        Me.cmbxDepartureFrom.Order = ComboBoxWithCheckBox.ControlOrder.Vertical
        Me.cmbxDepartureFrom.Size = New System.Drawing.Size(167, 69)
        Me.cmbxDepartureFrom.TabIndex = 71
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.LinkLabel2.Location = New System.Drawing.Point(521, 438)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(29, 14)
        Me.LinkLabel2.TabIndex = 70
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Add"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.LinkLabel1.Location = New System.Drawing.Point(528, 160)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(29, 14)
        Me.LinkLabel1.TabIndex = 69
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Add"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(62, 617)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 20)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Duration"
        '
        'txbxDuration
        '
        Me.txbxDuration.Location = New System.Drawing.Point(125, 613)
        Me.txbxDuration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txbxDuration.Mask = "0d 0h 0m"
        Me.txbxDuration.Name = "txbxDuration"
        Me.txbxDuration.Size = New System.Drawing.Size(300, 27)
        Me.txbxDuration.TabIndex = 63
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.MaskedTextBox1)
        Me.TabPage9.Controls.Add(Me.DateTimePicker1)
        Me.TabPage9.Controls.Add(Me.Label27)
        Me.TabPage9.Controls.Add(Me.Label14)
        Me.TabPage9.Controls.Add(Me.DateTimePicker3)
        Me.TabPage9.Controls.Add(Me.DateTimePicker2)
        Me.TabPage9.Controls.Add(Me.DateTimePicker4)
        Me.TabPage9.Controls.Add(Me.Label26)
        Me.TabPage9.Location = New System.Drawing.Point(4, 29)
        Me.TabPage9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage9.Size = New System.Drawing.Size(812, 648)
        Me.TabPage9.TabIndex = 1
        Me.TabPage9.Text = "LayOver"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(103, 106)
        Me.MaskedTextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaskedTextBox1.Mask = "0d 0h 0m"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(125, 27)
        Me.MaskedTextBox1.TabIndex = 68
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(105, 27)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(97, 27)
        Me.DateTimePicker1.TabIndex = 63
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(40, 110)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 20)
        Me.Label27.TabIndex = 67
        Me.Label27.Text = "Duration"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Date / Time"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(103, 59)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(97, 27)
        Me.DateTimePicker3.TabIndex = 66
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "HH:mm"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(210, 27)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowUpDown = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(62, 27)
        Me.DateTimePicker2.TabIndex = 62
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.CustomFormat = "HH:mm"
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(208, 59)
        Me.DateTimePicker4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.ShowUpDown = True
        Me.DateTimePicker4.Size = New System.Drawing.Size(65, 27)
        Me.DateTimePicker4.TabIndex = 65
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(24, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 20)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "Date / Time"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(76, 9)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 30)
        Me.Button4.TabIndex = 69
        Me.Button4.Text = "Last Values to First"
        Me.ToolTip1.SetToolTip(Me.Button4, "Start the next leg where the last one ended.")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(17, 9)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 30)
        Me.Button3.TabIndex = 68
        Me.Button3.Text = "Reset"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(843, 46)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 532)
        Me.Button2.TabIndex = 52
        Me.Button2.Text = "Add >>"
        Me.ToolTip1.SetToolTip(Me.Button2, "Add the form on the left to the list as a new item.")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(887, 46)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(193, 524)
        Me.ListBox1.TabIndex = 18
        '
        'btnUpdateLeg
        '
        Me.btnUpdateLeg.Enabled = False
        Me.btnUpdateLeg.Location = New System.Drawing.Point(887, 586)
        Me.btnUpdateLeg.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdateLeg.Name = "btnUpdateLeg"
        Me.btnUpdateLeg.Size = New System.Drawing.Size(194, 32)
        Me.btnUpdateLeg.TabIndex = 73
        Me.btnUpdateLeg.Text = "Update Selected Item"
        Me.ToolTip1.SetToolTip(Me.btnUpdateLeg, "Write the form on the left back into the item you clicked in the list.")
        Me.btnUpdateLeg.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(76, 46)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(751, 27)
        Me.txtTitle.TabIndex = 55
        '
        'Including
        '
        Me.Including.Controls.Add(Me.Panel2)
        Me.Including.Location = New System.Drawing.Point(4, 58)
        Me.Including.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Including.Name = "Including"
        Me.Including.Size = New System.Drawing.Size(1115, 774)
        Me.Including.TabIndex = 3
        Me.Including.Text = "Including"
        Me.Including.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(684, 794)
        Me.Panel2.TabIndex = 0
        '
        'NotIncluding
        '
        Me.NotIncluding.Controls.Add(Me.pnlNotIncluding)
        Me.NotIncluding.Location = New System.Drawing.Point(4, 58)
        Me.NotIncluding.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NotIncluding.Name = "NotIncluding"
        Me.NotIncluding.Size = New System.Drawing.Size(1115, 774)
        Me.NotIncluding.TabIndex = 4
        Me.NotIncluding.Text = "Not Including"
        Me.NotIncluding.UseVisualStyleBackColor = True
        '
        'pnlNotIncluding
        '
        Me.pnlNotIncluding.AutoScroll = True
        Me.pnlNotIncluding.Location = New System.Drawing.Point(0, 0)
        Me.pnlNotIncluding.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlNotIncluding.Name = "pnlNotIncluding"
        Me.pnlNotIncluding.Size = New System.Drawing.Size(684, 794)
        Me.pnlNotIncluding.TabIndex = 0
        '
        'DayByDay
        '
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox15)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox16)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox17)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox18)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox19)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox20)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox21)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox22)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox23)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox24)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox25)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox26)
        Me.DayByDay.Controls.Add(Me.TextBoxWithCheckBox27)
        Me.DayByDay.Controls.Add(Me.ListBox2)
        Me.DayByDay.Controls.Add(Me.btnSaveDay)
        Me.DayByDay.Controls.Add(Me.lblDaysList)
        Me.DayByDay.Controls.Add(Me.lblDayLines)
        Me.DayByDay.Location = New System.Drawing.Point(4, 58)
        Me.DayByDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DayByDay.Name = "DayByDay"
        Me.DayByDay.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DayByDay.Size = New System.Drawing.Size(1115, 774)
        Me.DayByDay.TabIndex = 5
        Me.DayByDay.Text = "Day By Day"
        Me.DayByDay.UseVisualStyleBackColor = True
        '
        'TextBoxWithCheckBox15
        '
        Me.TextBoxWithCheckBox15.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox15.lcTitle = Nothing
        Me.TextBoxWithCheckBox15.length = 400
        Me.TextBoxWithCheckBox15.Location = New System.Drawing.Point(409, 485)
        Me.TextBoxWithCheckBox15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox15.Name = "TextBoxWithCheckBox15"
        Me.TextBoxWithCheckBox15.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox15.TabIndex = 57
        '
        'TextBoxWithCheckBox16
        '
        Me.TextBoxWithCheckBox16.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox16.lcTitle = Nothing
        Me.TextBoxWithCheckBox16.length = 400
        Me.TextBoxWithCheckBox16.Location = New System.Drawing.Point(409, 449)
        Me.TextBoxWithCheckBox16.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox16.Name = "TextBoxWithCheckBox16"
        Me.TextBoxWithCheckBox16.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox16.TabIndex = 56
        '
        'TextBoxWithCheckBox17
        '
        Me.TextBoxWithCheckBox17.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox17.lcTitle = Nothing
        Me.TextBoxWithCheckBox17.length = 400
        Me.TextBoxWithCheckBox17.Location = New System.Drawing.Point(409, 414)
        Me.TextBoxWithCheckBox17.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox17.Name = "TextBoxWithCheckBox17"
        Me.TextBoxWithCheckBox17.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox17.TabIndex = 55
        '
        'TextBoxWithCheckBox18
        '
        Me.TextBoxWithCheckBox18.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox18.lcTitle = Nothing
        Me.TextBoxWithCheckBox18.length = 400
        Me.TextBoxWithCheckBox18.Location = New System.Drawing.Point(409, 378)
        Me.TextBoxWithCheckBox18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox18.Name = "TextBoxWithCheckBox18"
        Me.TextBoxWithCheckBox18.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox18.TabIndex = 54
        '
        'TextBoxWithCheckBox19
        '
        Me.TextBoxWithCheckBox19.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox19.lcTitle = Nothing
        Me.TextBoxWithCheckBox19.length = 400
        Me.TextBoxWithCheckBox19.Location = New System.Drawing.Point(409, 342)
        Me.TextBoxWithCheckBox19.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox19.Name = "TextBoxWithCheckBox19"
        Me.TextBoxWithCheckBox19.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox19.TabIndex = 53
        '
        'TextBoxWithCheckBox20
        '
        Me.TextBoxWithCheckBox20.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox20.lcTitle = Nothing
        Me.TextBoxWithCheckBox20.length = 400
        Me.TextBoxWithCheckBox20.Location = New System.Drawing.Point(409, 306)
        Me.TextBoxWithCheckBox20.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox20.Name = "TextBoxWithCheckBox20"
        Me.TextBoxWithCheckBox20.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox20.TabIndex = 52
        '
        'TextBoxWithCheckBox21
        '
        Me.TextBoxWithCheckBox21.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox21.lcTitle = Nothing
        Me.TextBoxWithCheckBox21.length = 400
        Me.TextBoxWithCheckBox21.Location = New System.Drawing.Point(409, 271)
        Me.TextBoxWithCheckBox21.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox21.Name = "TextBoxWithCheckBox21"
        Me.TextBoxWithCheckBox21.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox21.TabIndex = 51
        '
        'TextBoxWithCheckBox22
        '
        Me.TextBoxWithCheckBox22.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox22.lcTitle = Nothing
        Me.TextBoxWithCheckBox22.length = 400
        Me.TextBoxWithCheckBox22.Location = New System.Drawing.Point(409, 235)
        Me.TextBoxWithCheckBox22.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox22.Name = "TextBoxWithCheckBox22"
        Me.TextBoxWithCheckBox22.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox22.TabIndex = 50
        '
        'TextBoxWithCheckBox23
        '
        Me.TextBoxWithCheckBox23.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox23.lcTitle = Nothing
        Me.TextBoxWithCheckBox23.length = 400
        Me.TextBoxWithCheckBox23.Location = New System.Drawing.Point(409, 199)
        Me.TextBoxWithCheckBox23.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox23.Name = "TextBoxWithCheckBox23"
        Me.TextBoxWithCheckBox23.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox23.TabIndex = 49
        '
        'TextBoxWithCheckBox24
        '
        Me.TextBoxWithCheckBox24.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox24.lcTitle = Nothing
        Me.TextBoxWithCheckBox24.length = 400
        Me.TextBoxWithCheckBox24.Location = New System.Drawing.Point(409, 164)
        Me.TextBoxWithCheckBox24.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox24.Name = "TextBoxWithCheckBox24"
        Me.TextBoxWithCheckBox24.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox24.TabIndex = 48
        '
        'TextBoxWithCheckBox25
        '
        Me.TextBoxWithCheckBox25.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox25.lcTitle = Nothing
        Me.TextBoxWithCheckBox25.length = 400
        Me.TextBoxWithCheckBox25.Location = New System.Drawing.Point(409, 128)
        Me.TextBoxWithCheckBox25.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox25.Name = "TextBoxWithCheckBox25"
        Me.TextBoxWithCheckBox25.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox25.TabIndex = 47
        '
        'TextBoxWithCheckBox26
        '
        Me.TextBoxWithCheckBox26.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox26.lcTitle = Nothing
        Me.TextBoxWithCheckBox26.length = 400
        Me.TextBoxWithCheckBox26.Location = New System.Drawing.Point(409, 92)
        Me.TextBoxWithCheckBox26.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox26.Name = "TextBoxWithCheckBox26"
        Me.TextBoxWithCheckBox26.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox26.TabIndex = 46
        '
        'TextBoxWithCheckBox27
        '
        Me.TextBoxWithCheckBox27.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox27.lcTitle = Nothing
        Me.TextBoxWithCheckBox27.length = 400
        Me.TextBoxWithCheckBox27.Location = New System.Drawing.Point(409, 57)
        Me.TextBoxWithCheckBox27.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox27.Name = "TextBoxWithCheckBox27"
        Me.TextBoxWithCheckBox27.Size = New System.Drawing.Size(556, 28)
        Me.TextBoxWithCheckBox27.TabIndex = 45
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 20
        Me.ListBox2.Location = New System.Drawing.Point(7, 59)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(380, 724)
        Me.ListBox2.TabIndex = 0
        '
        'btnSaveDay
        '
        Me.btnSaveDay.Enabled = False
        Me.btnSaveDay.Location = New System.Drawing.Point(409, 529)
        Me.btnSaveDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveDay.Name = "btnSaveDay"
        Me.btnSaveDay.Size = New System.Drawing.Size(117, 28)
        Me.btnSaveDay.TabIndex = 58
        Me.btnSaveDay.Text = "Save Day"
        Me.ToolTip1.SetToolTip(Me.btnSaveDay, "Store the lines on the right into the selected day.")
        Me.btnSaveDay.UseVisualStyleBackColor = True
        '
        'tabPricingpolicy
        '
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox10)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox9)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox8)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox7)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox6)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox5)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox4)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox3)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox2)
        Me.tabPricingpolicy.Controls.Add(Me.PricingWithCheckBox1)
        Me.tabPricingpolicy.Controls.Add(Me.UserControl11)
        Me.tabPricingpolicy.Location = New System.Drawing.Point(4, 58)
        Me.tabPricingpolicy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabPricingpolicy.Name = "tabPricingpolicy"
        Me.tabPricingpolicy.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabPricingpolicy.Size = New System.Drawing.Size(1115, 774)
        Me.tabPricingpolicy.TabIndex = 6
        Me.tabPricingpolicy.Text = "Pricing Policy"
        Me.tabPricingpolicy.UseVisualStyleBackColor = True
        '
        'PricingWithCheckBox10
        '
        Me.PricingWithCheckBox10.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox10.IconPath = Nothing
        Me.PricingWithCheckBox10.lcTitle = ""
        Me.PricingWithCheckBox10.Location = New System.Drawing.Point(7, 686)
        Me.PricingWithCheckBox10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox10.Name = "PricingWithCheckBox10"
        Me.PricingWithCheckBox10.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox10.SubTitle = ""
        Me.PricingWithCheckBox10.TabIndex = 10
        '
        'PricingWithCheckBox9
        '
        Me.PricingWithCheckBox9.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox9.IconPath = Nothing
        Me.PricingWithCheckBox9.lcTitle = ""
        Me.PricingWithCheckBox9.Location = New System.Drawing.Point(7, 618)
        Me.PricingWithCheckBox9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox9.Name = "PricingWithCheckBox9"
        Me.PricingWithCheckBox9.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox9.SubTitle = ""
        Me.PricingWithCheckBox9.TabIndex = 9
        '
        'PricingWithCheckBox8
        '
        Me.PricingWithCheckBox8.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox8.IconPath = Nothing
        Me.PricingWithCheckBox8.lcTitle = ""
        Me.PricingWithCheckBox8.Location = New System.Drawing.Point(7, 550)
        Me.PricingWithCheckBox8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox8.Name = "PricingWithCheckBox8"
        Me.PricingWithCheckBox8.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox8.SubTitle = ""
        Me.PricingWithCheckBox8.TabIndex = 8
        '
        'PricingWithCheckBox7
        '
        Me.PricingWithCheckBox7.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox7.IconPath = Nothing
        Me.PricingWithCheckBox7.lcTitle = ""
        Me.PricingWithCheckBox7.Location = New System.Drawing.Point(7, 482)
        Me.PricingWithCheckBox7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox7.Name = "PricingWithCheckBox7"
        Me.PricingWithCheckBox7.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox7.SubTitle = ""
        Me.PricingWithCheckBox7.TabIndex = 7
        '
        'PricingWithCheckBox6
        '
        Me.PricingWithCheckBox6.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox6.IconPath = Nothing
        Me.PricingWithCheckBox6.lcTitle = ""
        Me.PricingWithCheckBox6.Location = New System.Drawing.Point(7, 415)
        Me.PricingWithCheckBox6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox6.Name = "PricingWithCheckBox6"
        Me.PricingWithCheckBox6.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox6.SubTitle = ""
        Me.PricingWithCheckBox6.TabIndex = 6
        '
        'PricingWithCheckBox5
        '
        Me.PricingWithCheckBox5.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox5.IconPath = Nothing
        Me.PricingWithCheckBox5.lcTitle = ""
        Me.PricingWithCheckBox5.Location = New System.Drawing.Point(7, 347)
        Me.PricingWithCheckBox5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox5.Name = "PricingWithCheckBox5"
        Me.PricingWithCheckBox5.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox5.SubTitle = ""
        Me.PricingWithCheckBox5.TabIndex = 5
        '
        'PricingWithCheckBox4
        '
        Me.PricingWithCheckBox4.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox4.IconPath = Nothing
        Me.PricingWithCheckBox4.lcTitle = ""
        Me.PricingWithCheckBox4.Location = New System.Drawing.Point(7, 279)
        Me.PricingWithCheckBox4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox4.Name = "PricingWithCheckBox4"
        Me.PricingWithCheckBox4.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox4.SubTitle = ""
        Me.PricingWithCheckBox4.TabIndex = 4
        '
        'PricingWithCheckBox3
        '
        Me.PricingWithCheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox3.IconPath = Nothing
        Me.PricingWithCheckBox3.lcTitle = ""
        Me.PricingWithCheckBox3.Location = New System.Drawing.Point(7, 212)
        Me.PricingWithCheckBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox3.Name = "PricingWithCheckBox3"
        Me.PricingWithCheckBox3.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox3.SubTitle = ""
        Me.PricingWithCheckBox3.TabIndex = 3
        '
        'PricingWithCheckBox2
        '
        Me.PricingWithCheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox2.IconPath = Nothing
        Me.PricingWithCheckBox2.lcTitle = ""
        Me.PricingWithCheckBox2.Location = New System.Drawing.Point(7, 144)
        Me.PricingWithCheckBox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox2.Name = "PricingWithCheckBox2"
        Me.PricingWithCheckBox2.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox2.SubTitle = ""
        Me.PricingWithCheckBox2.TabIndex = 2
        '
        'PricingWithCheckBox1
        '
        Me.PricingWithCheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox1.IconPath = Nothing
        Me.PricingWithCheckBox1.lcTitle = ""
        Me.PricingWithCheckBox1.Location = New System.Drawing.Point(7, 76)
        Me.PricingWithCheckBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox1.Name = "PricingWithCheckBox1"
        Me.PricingWithCheckBox1.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox1.SubTitle = ""
        Me.PricingWithCheckBox1.TabIndex = 1
        '
        'UserControl11
        '
        Me.UserControl11.BackColor = System.Drawing.Color.Transparent
        Me.UserControl11.IconPath = Nothing
        Me.UserControl11.lcTitle = ""
        Me.UserControl11.Location = New System.Drawing.Point(7, 9)
        Me.UserControl11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Size = New System.Drawing.Size(484, 60)
        Me.UserControl11.SubTitle = ""
        Me.UserControl11.TabIndex = 0
        '
        'Additions
        '
        Me.Additions.Controls.Add(Me.PricingWithCheckBox11)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox12)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox13)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox14)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox15)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox16)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox17)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox18)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox19)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox20)
        Me.Additions.Controls.Add(Me.PricingWithCheckBox21)
        Me.Additions.Location = New System.Drawing.Point(4, 58)
        Me.Additions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Additions.Name = "Additions"
        Me.Additions.Size = New System.Drawing.Size(1115, 774)
        Me.Additions.TabIndex = 7
        Me.Additions.Text = "Additions"
        Me.Additions.UseVisualStyleBackColor = True
        '
        'PricingWithCheckBox11
        '
        Me.PricingWithCheckBox11.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox11.IconPath = Nothing
        Me.PricingWithCheckBox11.lcTitle = ""
        Me.PricingWithCheckBox11.Location = New System.Drawing.Point(7, 686)
        Me.PricingWithCheckBox11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox11.Name = "PricingWithCheckBox11"
        Me.PricingWithCheckBox11.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox11.SubTitle = ""
        Me.PricingWithCheckBox11.TabIndex = 21
        '
        'PricingWithCheckBox12
        '
        Me.PricingWithCheckBox12.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox12.IconPath = Nothing
        Me.PricingWithCheckBox12.lcTitle = ""
        Me.PricingWithCheckBox12.Location = New System.Drawing.Point(7, 618)
        Me.PricingWithCheckBox12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox12.Name = "PricingWithCheckBox12"
        Me.PricingWithCheckBox12.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox12.SubTitle = ""
        Me.PricingWithCheckBox12.TabIndex = 20
        '
        'PricingWithCheckBox13
        '
        Me.PricingWithCheckBox13.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox13.IconPath = Nothing
        Me.PricingWithCheckBox13.lcTitle = ""
        Me.PricingWithCheckBox13.Location = New System.Drawing.Point(7, 550)
        Me.PricingWithCheckBox13.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox13.Name = "PricingWithCheckBox13"
        Me.PricingWithCheckBox13.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox13.SubTitle = ""
        Me.PricingWithCheckBox13.TabIndex = 19
        '
        'PricingWithCheckBox14
        '
        Me.PricingWithCheckBox14.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox14.IconPath = Nothing
        Me.PricingWithCheckBox14.lcTitle = ""
        Me.PricingWithCheckBox14.Location = New System.Drawing.Point(7, 482)
        Me.PricingWithCheckBox14.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox14.Name = "PricingWithCheckBox14"
        Me.PricingWithCheckBox14.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox14.SubTitle = ""
        Me.PricingWithCheckBox14.TabIndex = 18
        '
        'PricingWithCheckBox15
        '
        Me.PricingWithCheckBox15.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox15.IconPath = Nothing
        Me.PricingWithCheckBox15.lcTitle = ""
        Me.PricingWithCheckBox15.Location = New System.Drawing.Point(7, 415)
        Me.PricingWithCheckBox15.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox15.Name = "PricingWithCheckBox15"
        Me.PricingWithCheckBox15.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox15.SubTitle = ""
        Me.PricingWithCheckBox15.TabIndex = 17
        '
        'PricingWithCheckBox16
        '
        Me.PricingWithCheckBox16.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox16.IconPath = Nothing
        Me.PricingWithCheckBox16.lcTitle = ""
        Me.PricingWithCheckBox16.Location = New System.Drawing.Point(7, 347)
        Me.PricingWithCheckBox16.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox16.Name = "PricingWithCheckBox16"
        Me.PricingWithCheckBox16.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox16.SubTitle = ""
        Me.PricingWithCheckBox16.TabIndex = 16
        '
        'PricingWithCheckBox17
        '
        Me.PricingWithCheckBox17.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox17.IconPath = Nothing
        Me.PricingWithCheckBox17.lcTitle = ""
        Me.PricingWithCheckBox17.Location = New System.Drawing.Point(7, 279)
        Me.PricingWithCheckBox17.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox17.Name = "PricingWithCheckBox17"
        Me.PricingWithCheckBox17.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox17.SubTitle = ""
        Me.PricingWithCheckBox17.TabIndex = 15
        '
        'PricingWithCheckBox18
        '
        Me.PricingWithCheckBox18.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox18.IconPath = Nothing
        Me.PricingWithCheckBox18.lcTitle = ""
        Me.PricingWithCheckBox18.Location = New System.Drawing.Point(7, 212)
        Me.PricingWithCheckBox18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox18.Name = "PricingWithCheckBox18"
        Me.PricingWithCheckBox18.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox18.SubTitle = ""
        Me.PricingWithCheckBox18.TabIndex = 14
        '
        'PricingWithCheckBox19
        '
        Me.PricingWithCheckBox19.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox19.IconPath = Nothing
        Me.PricingWithCheckBox19.lcTitle = ""
        Me.PricingWithCheckBox19.Location = New System.Drawing.Point(7, 144)
        Me.PricingWithCheckBox19.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox19.Name = "PricingWithCheckBox19"
        Me.PricingWithCheckBox19.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox19.SubTitle = ""
        Me.PricingWithCheckBox19.TabIndex = 13
        '
        'PricingWithCheckBox20
        '
        Me.PricingWithCheckBox20.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox20.IconPath = Nothing
        Me.PricingWithCheckBox20.lcTitle = ""
        Me.PricingWithCheckBox20.Location = New System.Drawing.Point(7, 76)
        Me.PricingWithCheckBox20.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox20.Name = "PricingWithCheckBox20"
        Me.PricingWithCheckBox20.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox20.SubTitle = ""
        Me.PricingWithCheckBox20.TabIndex = 12
        '
        'PricingWithCheckBox21
        '
        Me.PricingWithCheckBox21.BackColor = System.Drawing.Color.Transparent
        Me.PricingWithCheckBox21.IconPath = Nothing
        Me.PricingWithCheckBox21.lcTitle = ""
        Me.PricingWithCheckBox21.Location = New System.Drawing.Point(7, 9)
        Me.PricingWithCheckBox21.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PricingWithCheckBox21.Name = "PricingWithCheckBox21"
        Me.PricingWithCheckBox21.Size = New System.Drawing.Size(484, 60)
        Me.PricingWithCheckBox21.SubTitle = ""
        Me.PricingWithCheckBox21.TabIndex = 11
        '
        'TransferWays
        '
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox14)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox13)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox12)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox11)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox10)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox9)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox8)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox7)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox6)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox4)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox3)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox2)
        Me.TransferWays.Controls.Add(Me.TextBoxWithCheckBox1)
        Me.TransferWays.Controls.Add(Me.TabControl4)
        Me.TransferWays.Controls.Add(Me.btnSaveTransferWay)
        Me.TransferWays.Controls.Add(Me.lblTransferHint)
        Me.TransferWays.Location = New System.Drawing.Point(4, 58)
        Me.TransferWays.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TransferWays.Name = "TransferWays"
        Me.TransferWays.Size = New System.Drawing.Size(1115, 774)
        Me.TransferWays.TabIndex = 8
        Me.TransferWays.Text = "Transfer Ways"
        Me.TransferWays.UseVisualStyleBackColor = True
        '
        'TextBoxWithCheckBox14
        '
        Me.TextBoxWithCheckBox14.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox14.lcTitle = Nothing
        Me.TextBoxWithCheckBox14.length = 450
        Me.TextBoxWithCheckBox14.Location = New System.Drawing.Point(16, 549)
        Me.TextBoxWithCheckBox14.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox14.Name = "TextBoxWithCheckBox14"
        Me.TextBoxWithCheckBox14.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox14.TabIndex = 44
        '
        'TextBoxWithCheckBox13
        '
        Me.TextBoxWithCheckBox13.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox13.lcTitle = Nothing
        Me.TextBoxWithCheckBox13.length = 450
        Me.TextBoxWithCheckBox13.Location = New System.Drawing.Point(16, 513)
        Me.TextBoxWithCheckBox13.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox13.Name = "TextBoxWithCheckBox13"
        Me.TextBoxWithCheckBox13.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox13.TabIndex = 43
        '
        'TextBoxWithCheckBox12
        '
        Me.TextBoxWithCheckBox12.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox12.lcTitle = Nothing
        Me.TextBoxWithCheckBox12.length = 450
        Me.TextBoxWithCheckBox12.Location = New System.Drawing.Point(16, 478)
        Me.TextBoxWithCheckBox12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox12.Name = "TextBoxWithCheckBox12"
        Me.TextBoxWithCheckBox12.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox12.TabIndex = 42
        '
        'TextBoxWithCheckBox11
        '
        Me.TextBoxWithCheckBox11.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox11.lcTitle = Nothing
        Me.TextBoxWithCheckBox11.length = 450
        Me.TextBoxWithCheckBox11.Location = New System.Drawing.Point(16, 442)
        Me.TextBoxWithCheckBox11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox11.Name = "TextBoxWithCheckBox11"
        Me.TextBoxWithCheckBox11.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox11.TabIndex = 41
        '
        'TextBoxWithCheckBox10
        '
        Me.TextBoxWithCheckBox10.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox10.lcTitle = Nothing
        Me.TextBoxWithCheckBox10.length = 450
        Me.TextBoxWithCheckBox10.Location = New System.Drawing.Point(16, 406)
        Me.TextBoxWithCheckBox10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox10.Name = "TextBoxWithCheckBox10"
        Me.TextBoxWithCheckBox10.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox10.TabIndex = 40
        '
        'TextBoxWithCheckBox9
        '
        Me.TextBoxWithCheckBox9.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox9.lcTitle = Nothing
        Me.TextBoxWithCheckBox9.length = 450
        Me.TextBoxWithCheckBox9.Location = New System.Drawing.Point(16, 370)
        Me.TextBoxWithCheckBox9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox9.Name = "TextBoxWithCheckBox9"
        Me.TextBoxWithCheckBox9.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox9.TabIndex = 39
        '
        'TextBoxWithCheckBox8
        '
        Me.TextBoxWithCheckBox8.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox8.lcTitle = Nothing
        Me.TextBoxWithCheckBox8.length = 450
        Me.TextBoxWithCheckBox8.Location = New System.Drawing.Point(16, 335)
        Me.TextBoxWithCheckBox8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox8.Name = "TextBoxWithCheckBox8"
        Me.TextBoxWithCheckBox8.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox8.TabIndex = 38
        '
        'TextBoxWithCheckBox7
        '
        Me.TextBoxWithCheckBox7.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox7.lcTitle = Nothing
        Me.TextBoxWithCheckBox7.length = 450
        Me.TextBoxWithCheckBox7.Location = New System.Drawing.Point(16, 299)
        Me.TextBoxWithCheckBox7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox7.Name = "TextBoxWithCheckBox7"
        Me.TextBoxWithCheckBox7.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox7.TabIndex = 37
        '
        'TextBoxWithCheckBox6
        '
        Me.TextBoxWithCheckBox6.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox6.lcTitle = Nothing
        Me.TextBoxWithCheckBox6.length = 450
        Me.TextBoxWithCheckBox6.Location = New System.Drawing.Point(16, 263)
        Me.TextBoxWithCheckBox6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox6.Name = "TextBoxWithCheckBox6"
        Me.TextBoxWithCheckBox6.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox6.TabIndex = 36
        '
        'TextBoxWithCheckBox4
        '
        Me.TextBoxWithCheckBox4.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox4.lcTitle = Nothing
        Me.TextBoxWithCheckBox4.length = 450
        Me.TextBoxWithCheckBox4.Location = New System.Drawing.Point(16, 228)
        Me.TextBoxWithCheckBox4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox4.Name = "TextBoxWithCheckBox4"
        Me.TextBoxWithCheckBox4.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox4.TabIndex = 35
        '
        'TextBoxWithCheckBox3
        '
        Me.TextBoxWithCheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox3.lcTitle = Nothing
        Me.TextBoxWithCheckBox3.length = 450
        Me.TextBoxWithCheckBox3.Location = New System.Drawing.Point(16, 192)
        Me.TextBoxWithCheckBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox3.Name = "TextBoxWithCheckBox3"
        Me.TextBoxWithCheckBox3.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox3.TabIndex = 34
        '
        'TextBoxWithCheckBox2
        '
        Me.TextBoxWithCheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox2.lcTitle = Nothing
        Me.TextBoxWithCheckBox2.length = 450
        Me.TextBoxWithCheckBox2.Location = New System.Drawing.Point(16, 156)
        Me.TextBoxWithCheckBox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox2.Name = "TextBoxWithCheckBox2"
        Me.TextBoxWithCheckBox2.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox2.TabIndex = 33
        '
        'TextBoxWithCheckBox1
        '
        Me.TextBoxWithCheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.TextBoxWithCheckBox1.lcTitle = Nothing
        Me.TextBoxWithCheckBox1.length = 450
        Me.TextBoxWithCheckBox1.Location = New System.Drawing.Point(16, 121)
        Me.TextBoxWithCheckBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox1.Name = "TextBoxWithCheckBox1"
        Me.TextBoxWithCheckBox1.Size = New System.Drawing.Size(615, 28)
        Me.TextBoxWithCheckBox1.TabIndex = 32
        '
        'TabControl4
        '
        Me.TabControl4.Controls.Add(Me.TabPage3)
        Me.TabControl4.Controls.Add(Me.TabPage4)
        Me.TabControl4.Controls.Add(Me.TabPage5)
        Me.TabControl4.Controls.Add(Me.TabPage7)
        Me.TabControl4.Controls.Add(Me.TabPage10)
        Me.TabControl4.Controls.Add(Me.TabPage11)
        Me.TabControl4.Controls.Add(Me.TabPage12)
        Me.TabControl4.Controls.Add(Me.TabPage13)
        Me.TabControl4.Controls.Add(Me.TabPage14)
        Me.TabControl4.ImageList = Me.ImageList1
        Me.TabControl4.Location = New System.Drawing.Point(12, 14)
        Me.TabControl4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(850, 81)
        Me.TabControl4.TabIndex = 31
        '
        'TabPage3
        '
        Me.TabPage3.ImageIndex = 0
        Me.TabPage3.Location = New System.Drawing.Point(4, 57)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Size = New System.Drawing.Size(842, 20)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.ImageIndex = 1
        Me.TabPage4.Location = New System.Drawing.Point(4, 57)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage4.Size = New System.Drawing.Size(842, 20)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.ImageIndex = 2
        Me.TabPage5.Location = New System.Drawing.Point(4, 57)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(842, 20)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.ImageIndex = 3
        Me.TabPage7.Location = New System.Drawing.Point(4, 57)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(842, 20)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'TabPage10
        '
        Me.TabPage10.ImageIndex = 4
        Me.TabPage10.Location = New System.Drawing.Point(4, 57)
        Me.TabPage10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(842, 20)
        Me.TabPage10.TabIndex = 4
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'TabPage11
        '
        Me.TabPage11.ImageIndex = 5
        Me.TabPage11.Location = New System.Drawing.Point(4, 57)
        Me.TabPage11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(842, 20)
        Me.TabPage11.TabIndex = 5
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'TabPage12
        '
        Me.TabPage12.ImageIndex = 6
        Me.TabPage12.Location = New System.Drawing.Point(4, 57)
        Me.TabPage12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(842, 20)
        Me.TabPage12.TabIndex = 6
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'TabPage13
        '
        Me.TabPage13.ImageIndex = 7
        Me.TabPage13.Location = New System.Drawing.Point(4, 57)
        Me.TabPage13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage13.Size = New System.Drawing.Size(842, 20)
        Me.TabPage13.TabIndex = 7
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'TabPage14
        '
        Me.TabPage14.ImageIndex = 8
        Me.TabPage14.Location = New System.Drawing.Point(4, 57)
        Me.TabPage14.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage14.Size = New System.Drawing.Size(842, 20)
        Me.TabPage14.TabIndex = 8
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'btnSaveTransferWay
        '
        Me.btnSaveTransferWay.Location = New System.Drawing.Point(16, 591)
        Me.btnSaveTransferWay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveTransferWay.Name = "btnSaveTransferWay"
        Me.btnSaveTransferWay.Size = New System.Drawing.Size(140, 28)
        Me.btnSaveTransferWay.TabIndex = 20
        Me.btnSaveTransferWay.Text = "Save Lines"
        Me.ToolTip1.SetToolTip(Me.btnSaveTransferWay, "Store these lines for the selected transfer type.")
        Me.btnSaveTransferWay.UseVisualStyleBackColor = True
        '
        'TabPage15
        '
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox12)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox11)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox10)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox9)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox8)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox7)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox6)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox5)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox4)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox3)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox2)
        Me.TabPage15.Controls.Add(Me.TextBoxWithTypeAndCheckbox1)
        Me.TabPage15.Location = New System.Drawing.Point(4, 58)
        Me.TabPage15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage15.Name = "TabPage15"
        Me.TabPage15.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage15.Size = New System.Drawing.Size(1115, 774)
        Me.TabPage15.TabIndex = 9
        Me.TabPage15.Text = "Laces, Stamps, and Comments"
        Me.TabPage15.UseVisualStyleBackColor = True
        '
        'TextBoxWithTypeAndCheckbox12
        '
        Me.TextBoxWithTypeAndCheckbox12.length = 400
        Me.TextBoxWithTypeAndCheckbox12.Location = New System.Drawing.Point(28, 460)
        Me.TextBoxWithTypeAndCheckbox12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox12.Name = "TextBoxWithTypeAndCheckbox12"
        Me.TextBoxWithTypeAndCheckbox12.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox12.TabIndex = 11
        '
        'TextBoxWithTypeAndCheckbox11
        '
        Me.TextBoxWithTypeAndCheckbox11.length = 400
        Me.TextBoxWithTypeAndCheckbox11.Location = New System.Drawing.Point(28, 421)
        Me.TextBoxWithTypeAndCheckbox11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox11.Name = "TextBoxWithTypeAndCheckbox11"
        Me.TextBoxWithTypeAndCheckbox11.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox11.TabIndex = 10
        '
        'TextBoxWithTypeAndCheckbox10
        '
        Me.TextBoxWithTypeAndCheckbox10.length = 400
        Me.TextBoxWithTypeAndCheckbox10.Location = New System.Drawing.Point(28, 382)
        Me.TextBoxWithTypeAndCheckbox10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox10.Name = "TextBoxWithTypeAndCheckbox10"
        Me.TextBoxWithTypeAndCheckbox10.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox10.TabIndex = 9
        '
        'TextBoxWithTypeAndCheckbox9
        '
        Me.TextBoxWithTypeAndCheckbox9.length = 400
        Me.TextBoxWithTypeAndCheckbox9.Location = New System.Drawing.Point(28, 342)
        Me.TextBoxWithTypeAndCheckbox9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox9.Name = "TextBoxWithTypeAndCheckbox9"
        Me.TextBoxWithTypeAndCheckbox9.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox9.TabIndex = 8
        '
        'TextBoxWithTypeAndCheckbox8
        '
        Me.TextBoxWithTypeAndCheckbox8.length = 400
        Me.TextBoxWithTypeAndCheckbox8.Location = New System.Drawing.Point(28, 303)
        Me.TextBoxWithTypeAndCheckbox8.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox8.Name = "TextBoxWithTypeAndCheckbox8"
        Me.TextBoxWithTypeAndCheckbox8.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox8.TabIndex = 7
        '
        'TextBoxWithTypeAndCheckbox7
        '
        Me.TextBoxWithTypeAndCheckbox7.length = 400
        Me.TextBoxWithTypeAndCheckbox7.Location = New System.Drawing.Point(28, 263)
        Me.TextBoxWithTypeAndCheckbox7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox7.Name = "TextBoxWithTypeAndCheckbox7"
        Me.TextBoxWithTypeAndCheckbox7.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox7.TabIndex = 6
        '
        'TextBoxWithTypeAndCheckbox6
        '
        Me.TextBoxWithTypeAndCheckbox6.length = 400
        Me.TextBoxWithTypeAndCheckbox6.Location = New System.Drawing.Point(28, 224)
        Me.TextBoxWithTypeAndCheckbox6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox6.Name = "TextBoxWithTypeAndCheckbox6"
        Me.TextBoxWithTypeAndCheckbox6.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox6.TabIndex = 5
        '
        'TextBoxWithTypeAndCheckbox5
        '
        Me.TextBoxWithTypeAndCheckbox5.length = 400
        Me.TextBoxWithTypeAndCheckbox5.Location = New System.Drawing.Point(28, 185)
        Me.TextBoxWithTypeAndCheckbox5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox5.Name = "TextBoxWithTypeAndCheckbox5"
        Me.TextBoxWithTypeAndCheckbox5.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox5.TabIndex = 4
        '
        'TextBoxWithTypeAndCheckbox4
        '
        Me.TextBoxWithTypeAndCheckbox4.length = 400
        Me.TextBoxWithTypeAndCheckbox4.Location = New System.Drawing.Point(28, 150)
        Me.TextBoxWithTypeAndCheckbox4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox4.Name = "TextBoxWithTypeAndCheckbox4"
        Me.TextBoxWithTypeAndCheckbox4.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox4.TabIndex = 3
        '
        'TextBoxWithTypeAndCheckbox3
        '
        Me.TextBoxWithTypeAndCheckbox3.length = 400
        Me.TextBoxWithTypeAndCheckbox3.Location = New System.Drawing.Point(28, 111)
        Me.TextBoxWithTypeAndCheckbox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox3.Name = "TextBoxWithTypeAndCheckbox3"
        Me.TextBoxWithTypeAndCheckbox3.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox3.TabIndex = 2
        '
        'TextBoxWithTypeAndCheckbox2
        '
        Me.TextBoxWithTypeAndCheckbox2.length = 400
        Me.TextBoxWithTypeAndCheckbox2.Location = New System.Drawing.Point(28, 71)
        Me.TextBoxWithTypeAndCheckbox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox2.Name = "TextBoxWithTypeAndCheckbox2"
        Me.TextBoxWithTypeAndCheckbox2.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox2.TabIndex = 1
        '
        'TextBoxWithTypeAndCheckbox1
        '
        Me.TextBoxWithTypeAndCheckbox1.length = 400
        Me.TextBoxWithTypeAndCheckbox1.Location = New System.Drawing.Point(28, 32)
        Me.TextBoxWithTypeAndCheckbox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithTypeAndCheckbox1.Name = "TextBoxWithTypeAndCheckbox1"
        Me.TextBoxWithTypeAndCheckbox1.Size = New System.Drawing.Size(584, 32)
        Me.TextBoxWithTypeAndCheckbox1.TabIndex = 0
        '
        'Prices
        '
        Me.Prices.Controls.Add(Me.Button7)
        Me.Prices.Controls.Add(Me.Button5)
        Me.Prices.Controls.Add(Me.ListBox3)
        Me.Prices.Controls.Add(Me.lblPricesHint)
        Me.Prices.Location = New System.Drawing.Point(4, 58)
        Me.Prices.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Prices.Name = "Prices"
        Me.Prices.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Prices.Size = New System.Drawing.Size(1115, 774)
        Me.Prices.TabIndex = 10
        Me.Prices.Text = "Prices"
        Me.Prices.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(114, 9)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(87, 28)
        Me.Button7.TabIndex = 2
        Me.Button7.Tag = ""
        Me.Button7.Text = "Remove"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(20, 9)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 28)
        Me.Button5.TabIndex = 1
        Me.Button5.Tag = ""
        Me.Button5.Text = "Add"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ListBox3
        '
        Me.ListBox3.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 16
        Me.ListBox3.Location = New System.Drawing.Point(20, 42)
        Me.ListBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(293, 676)
        Me.ListBox3.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.pnlHeaderText)
        Me.pnlHeader.Controls.Add(Me.flpCommands)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(7, 7)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1123, 66)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlHeaderText
        '
        Me.pnlHeaderText.Controls.Add(Me.lblEditingDetail)
        Me.pnlHeaderText.Controls.Add(Me.lblEditing)
        Me.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeaderText.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHeaderText.Name = "pnlHeaderText"
        Me.pnlHeaderText.Padding = New System.Windows.Forms.Padding(12, 5, 0, 0)
        Me.pnlHeaderText.Size = New System.Drawing.Size(754, 66)
        Me.pnlHeaderText.TabIndex = 0
        '
        'lblEditingDetail
        '
        Me.lblEditingDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEditingDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditingDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblEditingDetail.Location = New System.Drawing.Point(12, 35)
        Me.lblEditingDetail.Name = "lblEditingDetail"
        Me.lblEditingDetail.Size = New System.Drawing.Size(742, 31)
        Me.lblEditingDetail.TabIndex = 1
        Me.lblEditingDetail.Text = "Create a trip on the Trip Title tab, or double-click a trip or version in the tre" &
    "e to open it."
        '
        'lblEditing
        '
        Me.lblEditing.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEditing.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEditing.Location = New System.Drawing.Point(12, 5)
        Me.lblEditing.Name = "lblEditing"
        Me.lblEditing.Size = New System.Drawing.Size(742, 30)
        Me.lblEditing.TabIndex = 0
        Me.lblEditing.Text = "No trip open"
        '
        'flpCommands
        '
        Me.flpCommands.Controls.Add(Me.btnSaveVersion)
        Me.flpCommands.Controls.Add(Me.btnSaveAsNewVersion)
        Me.flpCommands.Dock = System.Windows.Forms.DockStyle.Right
        Me.flpCommands.Location = New System.Drawing.Point(754, 0)
        Me.flpCommands.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.flpCommands.Name = "flpCommands"
        Me.flpCommands.Padding = New System.Windows.Forms.Padding(0, 0, 7, 0)
        Me.flpCommands.Size = New System.Drawing.Size(369, 66)
        Me.flpCommands.TabIndex = 1
        Me.flpCommands.WrapContents = False
        '
        'btnSaveVersion
        '
        Me.btnSaveVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSaveVersion.Enabled = False
        Me.btnSaveVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveVersion.ForeColor = System.Drawing.Color.White
        Me.btnSaveVersion.Location = New System.Drawing.Point(3, 11)
        Me.btnSaveVersion.Margin = New System.Windows.Forms.Padding(3, 11, 3, 4)
        Me.btnSaveVersion.Name = "btnSaveVersion"
        Me.btnSaveVersion.Size = New System.Drawing.Size(136, 44)
        Me.btnSaveVersion.TabIndex = 0
        Me.btnSaveVersion.Text = "Save"
        Me.ToolTip1.SetToolTip(Me.btnSaveVersion, "Save every tab into the open version (or the title into the open trip).")
        Me.btnSaveVersion.UseVisualStyleBackColor = False
        '
        'btnSaveAsNewVersion
        '
        Me.btnSaveAsNewVersion.Enabled = False
        Me.btnSaveAsNewVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAsNewVersion.Location = New System.Drawing.Point(145, 11)
        Me.btnSaveAsNewVersion.Margin = New System.Windows.Forms.Padding(3, 11, 3, 4)
        Me.btnSaveAsNewVersion.Name = "btnSaveAsNewVersion"
        Me.btnSaveAsNewVersion.Size = New System.Drawing.Size(205, 44)
        Me.btnSaveAsNewVersion.TabIndex = 1
        Me.btnSaveAsNewVersion.Text = "Save as New Version"
        Me.ToolTip1.SetToolTip(Me.btnSaveAsNewVersion, "Keep the open version unchanged and save every tab as a new version of this trip." &
        "")
        Me.btnSaveAsNewVersion.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 8000
        Me.ToolTip1.InitialDelay = 400
        Me.ToolTip1.ReshowDelay = 100
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.HideSelection = False
        Me.TreeView1.ItemHeight = 22
        Me.TreeView1.Location = New System.Drawing.Point(0, 27)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(385, 933)
        Me.TreeView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.ToolStripSeparator1, Me.CountriesToolStripMenuItem, Me.CitiesToolStripMenuItem, Me.StayToolStripMenuItem, Me.TitleAndSubtitleToolStripMenuItem, Me.TransferToolStripMenuItem, Me.ToolStripMenuItem1, Me.ServicesToolStripMenuItem, Me.DepartureDateAndTimeToolStripMenuItem, Me.ArrivalDateAndTimeToolStripMenuItem, Me.DeparturePortToolStripMenuItem, Me.ArrivalPortToolStripMenuItem, Me.PriceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(250, 322)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(246, 6)
        '
        'CountriesToolStripMenuItem
        '
        Me.CountriesToolStripMenuItem.Name = "CountriesToolStripMenuItem"
        Me.CountriesToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.CountriesToolStripMenuItem.Text = "Countries"
        '
        'CitiesToolStripMenuItem
        '
        Me.CitiesToolStripMenuItem.Name = "CitiesToolStripMenuItem"
        Me.CitiesToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.CitiesToolStripMenuItem.Text = "Cities"
        '
        'StayToolStripMenuItem
        '
        Me.StayToolStripMenuItem.Name = "StayToolStripMenuItem"
        Me.StayToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.StayToolStripMenuItem.Text = "Stay"
        '
        'TitleAndSubtitleToolStripMenuItem
        '
        Me.TitleAndSubtitleToolStripMenuItem.Name = "TitleAndSubtitleToolStripMenuItem"
        Me.TitleAndSubtitleToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.TitleAndSubtitleToolStripMenuItem.Text = "Title and Subtitle"
        '
        'TransferToolStripMenuItem
        '
        Me.TransferToolStripMenuItem.Name = "TransferToolStripMenuItem"
        Me.TransferToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.TransferToolStripMenuItem.Text = "Transfer Way"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(249, 24)
        Me.ToolStripMenuItem1.Text = "Attraction"
        '
        'ServicesToolStripMenuItem
        '
        Me.ServicesToolStripMenuItem.Name = "ServicesToolStripMenuItem"
        Me.ServicesToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.ServicesToolStripMenuItem.Text = "Services"
        '
        'DepartureDateAndTimeToolStripMenuItem
        '
        Me.DepartureDateAndTimeToolStripMenuItem.Name = "DepartureDateAndTimeToolStripMenuItem"
        Me.DepartureDateAndTimeToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.DepartureDateAndTimeToolStripMenuItem.Text = "Departure Date And Time"
        '
        'ArrivalDateAndTimeToolStripMenuItem
        '
        Me.ArrivalDateAndTimeToolStripMenuItem.Name = "ArrivalDateAndTimeToolStripMenuItem"
        Me.ArrivalDateAndTimeToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.ArrivalDateAndTimeToolStripMenuItem.Text = "Arrival Date And time"
        '
        'DeparturePortToolStripMenuItem
        '
        Me.DeparturePortToolStripMenuItem.Name = "DeparturePortToolStripMenuItem"
        Me.DeparturePortToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.DeparturePortToolStripMenuItem.Text = "Departure Port"
        '
        'ArrivalPortToolStripMenuItem
        '
        Me.ArrivalPortToolStripMenuItem.Name = "ArrivalPortToolStripMenuItem"
        Me.ArrivalPortToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.ArrivalPortToolStripMenuItem.Text = "Arrival Port"
        '
        'PriceToolStripMenuItem
        '
        Me.PriceToolStripMenuItem.Name = "PriceToolStripMenuItem"
        Me.PriceToolStripMenuItem.Size = New System.Drawing.Size(249, 24)
        Me.PriceToolStripMenuItem.Text = "Price"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(385, 960)
        Me.Panel1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewTrip, Me.ToolStripButton1, Me.tsbSaveTree, Me.tsbLoadTree, Me.tsbClearTree})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(385, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Add countries (offers)"
        '
        'tsbSaveTree
        '
        Me.tsbSaveTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbSaveTree.Name = "tsbSaveTree"
        Me.tsbSaveTree.Size = New System.Drawing.Size(76, 24)
        Me.tsbSaveTree.Text = "Save Tree"
        Me.tsbSaveTree.ToolTipText = "Save the tree to a file"
        '
        'tsbLoadTree
        '
        Me.tsbLoadTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbLoadTree.Name = "tsbLoadTree"
        Me.tsbLoadTree.Size = New System.Drawing.Size(78, 24)
        Me.tsbLoadTree.Text = "Load Tree"
        Me.tsbLoadTree.ToolTipText = "Load a tree from a file"
        '
        'tsbClearTree
        '
        Me.tsbClearTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClearTree.Name = "tsbClearTree"
        Me.tsbClearTree.Size = New System.Drawing.Size(79, 24)
        Me.tsbClearTree.Text = "Clear Tree"
        Me.tsbClearTree.ToolTipText = "Delete the whole tree and start anew"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Solo", "Tour"})
        Me.ComboBox1.Location = New System.Drawing.Point(91, 64)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 25)
        Me.ComboBox1.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Travel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Registration"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Admin.png")
        Me.ImageList2.Images.SetKeyName(1, "aircraft.png")
        Me.ImageList2.Images.SetKeyName(2, "backpack.png")
        Me.ImageList2.Images.SetKeyName(3, "Breakfast.png")
        Me.ImageList2.Images.SetKeyName(4, "CoffeeTeaX24.png")
        Me.ImageList2.Images.SetKeyName(5, "cruise.png")
        Me.ImageList2.Images.SetKeyName(6, "Dinner.png")
        Me.ImageList2.Images.SetKeyName(7, "KG30.png")
        Me.ImageList2.Images.SetKeyName(8, "Lunch and Dinner.png")
        Me.ImageList2.Images.SetKeyName(9, "Lunch.png")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1528, 985)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(1280, 851)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tours Simulator"
        Me.cmsTrip.ResumeLayout(False)
        Me.tabDeveloper.ResumeLayout(False)
        Me.tabDeveloper.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TitleAndSubTitle.ResumeLayout(False)
        Me.TitleAndSubTitle.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabControl5.ResumeLayout(False)
        Me.tabSpecificDates.ResumeLayout(False)
        Me.tabSpecificDates.PerformLayout()
        Me.TabPage17.ResumeLayout(False)
        Me.TabPage17.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        Me.Including.ResumeLayout(False)
        Me.NotIncluding.ResumeLayout(False)
        Me.DayByDay.ResumeLayout(False)
        Me.DayByDay.PerformLayout()
        Me.tabPricingpolicy.ResumeLayout(False)
        Me.Additions.ResumeLayout(False)
        Me.TransferWays.ResumeLayout(False)
        Me.TransferWays.PerformLayout()
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage15.ResumeLayout(False)
        Me.Prices.ResumeLayout(False)
        Me.Prices.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeaderText.ResumeLayout(False)
        Me.flpCommands.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents tsbSaveTree As ToolStripButton
    Friend WithEvents tsbLoadTree As ToolStripButton
    Friend WithEvents tsbClearTree As ToolStripButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CountriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CitiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TitleAndSubtitleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TransferToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ServicesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartureDateAndTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArrivalDateAndTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeparturePortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArrivalPortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents CheckedListBox3 As CheckedListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckedListBox4 As CheckedListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btnUpdateLeg As Button
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDays As TextBox
    Friend WithEvents txtNights As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Including As TabPage
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents DateTimePicker4 As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents txbxDuration As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents NotIncluding As TabPage
    Friend WithEvents DayByDay As TabPage
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents btnSaveDay As Button
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents tabPricingpolicy As TabPage
    Friend WithEvents TextBoxWithCheckBox5 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents InludesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotIncludeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DateTimeDurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Additions As TabPage
    Friend WithEvents TransferWays As TabPage
    Friend WithEvents TabControl4 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents TabPage13 As TabPage
    Friend WithEvents TabPage14 As TabPage
    Friend WithEvents Button6 As Button
    Friend WithEvents TabPage15 As TabPage
    Friend WithEvents Prices As TabPage
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txbxSubTitle As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents txbxTitle As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TabControl5 As TabControl
    Friend WithEvents tabSpecificDates As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateWithCheckBox3 As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents DateWithCheckBox4 As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents DateWithCheckBox2 As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents DateWithCheckBox1 As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents TabPage17 As TabPage
    Friend WithEvents txbxTripSubTitle As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents txbxTripTitle As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents chkRegTo As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents chkRegFrom As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents chkTravTo As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents chkTravFrom As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents UserControl11 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox8 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox7 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox6 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox5 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox4 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox3 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox2 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox1 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox10 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox9 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox11 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox12 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox13 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox14 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox15 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox16 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox17 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox18 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox19 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox20 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents PricingWithCheckBox21 As PricingWithCheckBox.PricingWithCheckBox
    Friend WithEvents TextBoxWithCheckBox3 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox2 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox1 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox14 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox13 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox12 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox11 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox10 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox9 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox8 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox7 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox6 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox4 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox15 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox16 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox17 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox18 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox19 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox20 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox21 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox22 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox23 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox24 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox25 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox26 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox27 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents TextBoxWithTypeAndCheckbox12 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox11 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox10 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox9 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox8 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox7 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox6 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox5 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox4 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox3 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox2 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents TextBoxWithTypeAndCheckbox1 As TextBoxWithTypeAndCheckbox.TextBoxWithTypeAndCheckbox
    Friend WithEvents cmbxDepartureFrom As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxDepartureCity As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxDepartureLocation As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxAirLine As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxDepartureTime As TimeWithCheckBox.TimeWithCheckBox
    Friend WithEvents cmbxDepartureDate As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents cmbxArrivingTo As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxArrivingCity As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents cmbxArrivingLocation As ComboBoxWithCheckBox.ComboBoxWithCheckBox
    Friend WithEvents ArrivalDate As DateWithCheckBox.DateWithCheckBox
    Friend WithEvents cmbxArrivalTime As TimeWithCheckBox.TimeWithCheckBox
    Friend WithEvents chkTravMonths As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents chkRegMonths As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton8 As RadioButton
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents TitleAndSubTitle As TabPage
    Friend WithEvents btnSaveDepartureAndArrival As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlNotIncluding As Panel
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents btnSaveTransferWay As Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSaveAsNewVersion As System.Windows.Forms.Button
    Friend WithEvents btnSaveVersion As System.Windows.Forms.Button
    Friend WithEvents flpCommands As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblEditingDetail As System.Windows.Forms.Label
    Friend WithEvents lblEditing As System.Windows.Forms.Label
    Friend WithEvents pnlHeaderText As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblDeveloper As System.Windows.Forms.Label
    Friend WithEvents lblPricingTest As System.Windows.Forms.Label
    Friend WithEvents tabDeveloper As System.Windows.Forms.TabPage
    Friend WithEvents lblCountries As System.Windows.Forms.Label
    Friend WithEvents lblTitleHint As System.Windows.Forms.Label
    Friend WithEvents lblDaysList As System.Windows.Forms.Label
    Friend WithEvents lblDayLines As System.Windows.Forms.Label
    Friend WithEvents lblTransferHint As System.Windows.Forms.Label
    Friend WithEvents lblPricesHint As System.Windows.Forms.Label
    Friend WithEvents lblLegsHint As System.Windows.Forms.Label
    Friend WithEvents tsbNewTrip As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDeleteNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTrip As System.Windows.Forms.ContextMenuStrip
End Class
