Public Class ItemProperties
    Private Sub ItemProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBoxWithCheckBox1.Settings(Length:=450, lcTitle:="Title")
        'TextBoxWithCheckBox1.Settings(Length:=350, lcTitle:="Sub Title")

        TextBoxWithCheckBox1.length = 450
        TextBoxWithCheckBox1.lcTitle = "Title"

        TextBoxWithCheckBox2.length = 350
        TextBoxWithCheckBox2.lcTitle = "Sub Title"

        DateTimeDuration1.DateWithCheckBox1.lcTitle = "Date From"
        DateTimeDuration1.TimeWithCheckBox1.lcTitle = "Time From"

        DateTimeDuration1.DateWithCheckBox2.lcTitle = "Date To"
        DateTimeDuration1.TimeWithCheckBox2.lcTitle = "Time From"

        DateTimeDuration1.NumaricWCheckBox1.lcTitle = "Days"
        DateTimeDuration1.NumaricWCheckBox2.lcTitle = "Night"

    End Sub
End Class