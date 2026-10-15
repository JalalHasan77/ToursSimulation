<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddCityDialog
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
        Me.chkAllCountries = New System.Windows.Forms.CheckBox()
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
        Me.lblCountry.Size = New System.Drawing.Size(50, 15)
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
        'chkAllCountries
        '
        Me.chkAllCountries.AutoSize = True
        Me.chkAllCountries.Location = New System.Drawing.Point(170, 44)
        Me.chkAllCountries.Name = "chkAllCountries"
        Me.chkAllCountries.Size = New System.Drawing.Size(132, 19)
        Me.chkAllCountries.TabIndex = 2
        Me.chkAllCountries.Text = "Show all countries"
        Me.chkAllCountries.UseVisualStyleBackColor = True
        '
        'lblNameEn
        '
        Me.lblNameEn.AutoSize = True
        Me.lblNameEn.Location = New System.Drawing.Point(16, 79)
        Me.lblNameEn.Name = "lblNameEn"
        Me.lblNameEn.Size = New System.Drawing.Size(115, 15)
        Me.lblNameEn.TabIndex = 3
        Me.lblNameEn.Text = "City name (English)"
        '
        'txtNameEn
        '
        Me.txtNameEn.Location = New System.Drawing.Point(170, 76)
        Me.txtNameEn.Name = "txtNameEn"
        Me.txtNameEn.Size = New System.Drawing.Size(260, 23)
        Me.txtNameEn.TabIndex = 4
        '
        'lblNameAr
        '
        Me.lblNameAr.AutoSize = True
        Me.lblNameAr.Location = New System.Drawing.Point(16, 113)
        Me.lblNameAr.Name = "lblNameAr"
        Me.lblNameAr.Size = New System.Drawing.Size(111, 15)
        Me.lblNameAr.TabIndex = 5
        Me.lblNameAr.Text = "City name (Arabic)"
        '
        'txtNameAr
        '
        Me.txtNameAr.Location = New System.Drawing.Point(170, 110)
        Me.txtNameAr.Name = "txtNameAr"
        Me.txtNameAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNameAr.Size = New System.Drawing.Size(260, 23)
        Me.txtNameAr.TabIndex = 6
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 153)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 28)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(345, 153)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddCityDialog
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 197)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.chkAllCountries)
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
        Me.Name = "AddCityDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add City"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents chkAllCountries As System.Windows.Forms.CheckBox
    Friend WithEvents lblNameEn As System.Windows.Forms.Label
    Friend WithEvents txtNameEn As System.Windows.Forms.TextBox
    Friend WithEvents lblNameAr As System.Windows.Forms.Label
    Friend WithEvents txtNameAr As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
