<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddCountryDialog
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
        Me.lblNameEn = New System.Windows.Forms.Label()
        Me.txtNameEn = New System.Windows.Forms.TextBox()
        Me.lblNameAr = New System.Windows.Forms.Label()
        Me.txtNameAr = New System.Windows.Forms.TextBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cmbRegion = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNameEn
        '
        Me.lblNameEn.AutoSize = True
        Me.lblNameEn.Location = New System.Drawing.Point(16, 20)
        Me.lblNameEn.Name = "lblNameEn"
        Me.lblNameEn.Size = New System.Drawing.Size(130, 15)
        Me.lblNameEn.TabIndex = 0
        Me.lblNameEn.Text = "Country name (English)"
        '
        'txtNameEn
        '
        Me.txtNameEn.Location = New System.Drawing.Point(170, 17)
        Me.txtNameEn.Name = "txtNameEn"
        Me.txtNameEn.Size = New System.Drawing.Size(260, 23)
        Me.txtNameEn.TabIndex = 1
        '
        'lblNameAr
        '
        Me.lblNameAr.AutoSize = True
        Me.lblNameAr.Location = New System.Drawing.Point(16, 54)
        Me.lblNameAr.Name = "lblNameAr"
        Me.lblNameAr.Size = New System.Drawing.Size(126, 15)
        Me.lblNameAr.TabIndex = 2
        Me.lblNameAr.Text = "Country name (Arabic)"
        '
        'txtNameAr
        '
        Me.txtNameAr.Location = New System.Drawing.Point(170, 51)
        Me.txtNameAr.Name = "txtNameAr"
        Me.txtNameAr.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNameAr.Size = New System.Drawing.Size(260, 23)
        Me.txtNameAr.TabIndex = 3
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(16, 88)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(44, 15)
        Me.lblRegion.TabIndex = 4
        Me.lblRegion.Text = "Region"
        '
        'cmbRegion
        '
        Me.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(170, 85)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(260, 23)
        Me.cmbRegion.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(254, 128)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 28)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(345, 128)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'AddCountryDialog
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 172)
        Me.Controls.Add(Me.lblNameEn)
        Me.Controls.Add(Me.txtNameEn)
        Me.Controls.Add(Me.lblNameAr)
        Me.Controls.Add(Me.txtNameAr)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.cmbRegion)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddCountryDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Country"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNameEn As System.Windows.Forms.Label
    Friend WithEvents txtNameEn As System.Windows.Forms.TextBox
    Friend WithEvents lblNameAr As System.Windows.Forms.Label
    Friend WithEvents txtNameAr As System.Windows.Forms.TextBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
