<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemProperties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxWithCheckBox2 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.TextBoxWithCheckBox1 = New TextBoxWithCheckBox.TextBoxWithCheckBox()
        Me.DateTimeDuration1 = New DateTimeDuration.DateTimeDuration()
        Me.SuspendLayout()
        '
        'TextBoxWithCheckBox2
        '
        Me.TextBoxWithCheckBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxWithCheckBox2.lcTitle = Nothing
        Me.TextBoxWithCheckBox2.length = 0
        Me.TextBoxWithCheckBox2.Location = New System.Drawing.Point(14, 50)
        Me.TextBoxWithCheckBox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox2.Name = "TextBoxWithCheckBox2"
        Me.TextBoxWithCheckBox2.Size = New System.Drawing.Size(206, 28)
        Me.TextBoxWithCheckBox2.TabIndex = 1
        '
        'TextBoxWithCheckBox1
        '
        Me.TextBoxWithCheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxWithCheckBox1.lcTitle = Nothing
        Me.TextBoxWithCheckBox1.length = 0
        Me.TextBoxWithCheckBox1.Location = New System.Drawing.Point(14, 15)
        Me.TextBoxWithCheckBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TextBoxWithCheckBox1.Name = "TextBoxWithCheckBox1"
        Me.TextBoxWithCheckBox1.Size = New System.Drawing.Size(206, 28)
        Me.TextBoxWithCheckBox1.TabIndex = 0
        '
        'DateTimeDuration1
        '
        Me.DateTimeDuration1.Location = New System.Drawing.Point(14, 123)
        Me.DateTimeDuration1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DateTimeDuration1.Name = "DateTimeDuration1"
        Me.DateTimeDuration1.Size = New System.Drawing.Size(233, 240)
        Me.DateTimeDuration1.TabIndex = 3
        '
        'ItemProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 554)
        Me.Controls.Add(Me.DateTimeDuration1)
        Me.Controls.Add(Me.TextBoxWithCheckBox2)
        Me.Controls.Add(Me.TextBoxWithCheckBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ItemProperties"
        Me.Text = "ItemProperties"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBoxWithCheckBox1 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Friend WithEvents TextBoxWithCheckBox2 As TextBoxWithCheckBox.TextBoxWithCheckBox
    Public WithEvents DateTimeDuration1 As DateTimeDuration.DateTimeDuration
End Class
