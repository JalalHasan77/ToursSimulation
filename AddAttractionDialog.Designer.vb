<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddAttractionDialog
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
        Me.lblNameEn = New System.Windows.Forms.Label()
        Me.txtNameEn = New System.Windows.Forms.TextBox()
        Me.lblNameAr = New System.Windows.Forms.Label()
        Me.txtNameAr = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        'lblNameEn
        '
        Me.lblNameEn.AutoSize = True
        Me.lblNameEn.Location = New System.Drawing.Point(16, 113)
        Me.lblNameEn.Name = "lblNameEn"
        Me.lblNameEn.Size = New System.Drawing.Size(100, 15)
        Me.lblNameEn.TabIndex = 5
        Me.lblNameEn.Text = "Attraction name (English)"
        '
        'txtNameEn
        '
        Me.txtNameEn.Location = New System.Drawing.Point(170, 110)
        Me.txtNameEn.Name = "txtNameEn"
        Me.txtNameEn.Size = New System.Drawing.Size(260, 23)
        Me.txtNameEn.TabIndex = 6
        '
        'lblNameAr
        '
        Me.lblNameAr.AutoSize = True
        Me.lblNameAr.Location = New System.Drawing.Point(16, 147)
        Me.lblNameAr.Name = "lblNameAr"
        Me.lblNameAr.Size = New System.Drawing.Size(100, 15)
        Me.lblNameAr.TabIndex = 7
        Me.lblNameAr.Text = "Attraction name (Arabic)"
        '
        'txtNameAr
        '
        Me.txtNameAr.Location = New System.Drawing.Point(170, 144)
        Me.txtNameAr.Name = "txtNameAr"
        Me.txtNameAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNameAr.Size = New System.Drawing.Size(260, 23)
        Me.txtNameAr.TabIndex = 8
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 188)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 28)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(345, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddAttractionDialog
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 232)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.chkShowAll)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.cmbCity)
        Me.Controls.Add(Me.lblNameEn)
        Me.Controls.Add(Me.txtNameEn)
        Me.Controls.Add(Me.lblNameAr)
        Me.Controls.Add(Me.txtNameAr)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddAttractionDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Attraction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents lblNameEn As System.Windows.Forms.Label
    Friend WithEvents txtNameEn As System.Windows.Forms.TextBox
    Friend WithEvents lblNameAr As System.Windows.Forms.Label
    Friend WithEvents txtNameAr As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
