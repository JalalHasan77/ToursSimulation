<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddStayDialog
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
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.cmbCountry = New System.Windows.Forms.ComboBox()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.cmbCity = New System.Windows.Forms.ComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.chkStars = New System.Windows.Forms.CheckBox()
        Me.numStars = New System.Windows.Forms.NumericUpDown()
        Me.lblStarsHint = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numStars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(16, 20)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(100, 15)
        Me.lblCountry.TabIndex = 0
        Me.lblCountry.Text = "Country"
        '
        'cmbCountry
        '
        Me.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Location = New System.Drawing.Point(170, 17)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(260, 23)
        Me.cmbCountry.TabIndex = 1
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(170, 44)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(180, 19)
        Me.chkShowAll.TabIndex = 2
        Me.chkShowAll.Text = "Show all countries and cities"
        Me.chkShowAll.UseVisualStyleBackColor = True
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(16, 76)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(100, 15)
        Me.lblCity.TabIndex = 3
        Me.lblCity.Text = "City"
        '
        'cmbCity
        '
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.Location = New System.Drawing.Point(170, 73)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Size = New System.Drawing.Size(260, 23)
        Me.cmbCity.TabIndex = 4
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(16, 113)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(100, 15)
        Me.lblName.TabIndex = 5
        Me.lblName.Text = "Stay name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(170, 110)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(260, 23)
        Me.txtName.TabIndex = 6
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(16, 147)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(100, 15)
        Me.lblCategory.TabIndex = 7
        Me.lblCategory.Text = "Category"
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(170, 144)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(260, 23)
        Me.cmbCategory.TabIndex = 8
        '
        'chkStars
        '
        Me.chkStars.AutoSize = True
        Me.chkStars.Location = New System.Drawing.Point(16, 180)
        Me.chkStars.Name = "chkStars"
        Me.chkStars.Size = New System.Drawing.Size(87, 19)
        Me.chkStars.TabIndex = 9
        Me.chkStars.Text = "Star rating"
        Me.chkStars.UseVisualStyleBackColor = True
        '
        'numStars
        '
        Me.numStars.Enabled = False
        Me.numStars.Location = New System.Drawing.Point(170, 178)
        Me.numStars.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.numStars.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStars.Name = "numStars"
        Me.numStars.Size = New System.Drawing.Size(60, 23)
        Me.numStars.TabIndex = 10
        Me.numStars.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblStarsHint
        '
        Me.lblStarsHint.AutoSize = True
        Me.lblStarsHint.ForeColor = System.Drawing.Color.FromArgb(70, 85, 105)
        Me.lblStarsHint.Location = New System.Drawing.Point(238, 181)
        Me.lblStarsHint.Name = "lblStarsHint"
        Me.lblStarsHint.Size = New System.Drawing.Size(180, 15)
        Me.lblStarsHint.TabIndex = 11
        Me.lblStarsHint.Text = "1 to 8 (untick = not specified)"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 222)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 28)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(345, 222)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddStayDialog
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 266)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.chkShowAll)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.cmbCity)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.chkStars)
        Me.Controls.Add(Me.numStars)
        Me.Controls.Add(Me.lblStarsHint)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddStayDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Stay"
        CType(Me.numStars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents chkStars As System.Windows.Forms.CheckBox
    Friend WithEvents numStars As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStarsHint As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
