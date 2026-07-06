Imports System

Namespace BookingFilters

    ''' <summary>
    ''' Which tab of the form is active: "Specific Dates" (From/To date pickers)
    ''' or "Months Names" (free-text months entry).
    ''' </summary>
    Public Enum DuringFilterMode
        SpecificDates = 0
        MonthsNames = 1
    End Enum

    ''' <summary>
    ''' A single togglable date boundary, e.g. the "From" or "To" row
    ''' under Registration/Travel on the Specific Dates tab.
    ''' </summary>
    Public Class DateBoundary

        Public Property Enabled As Boolean
        Public Property Value As Date?

        Public Sub New()
        End Sub

        Public Sub New(enabled As Boolean, value As Date?)
            Me.Enabled = enabled
            Me.Value = value
        End Sub

        Public Overrides Function ToString() As String
            If Enabled AndAlso Value.HasValue Then
                Return Value.Value.ToString("yyyy-MM-dd")
            End If
            Return String.Empty
        End Function

    End Class

    ''' <summary>
    ''' Represents one "During" block (Registration During / Travel During).
    ''' Depending on Mode, either the From/To dates are meaningful (Specific Dates tab)
    ''' or MonthsText is meaningful (Months Names tab).
    ''' </summary>
    Public Class DuringFilter

        Public Property Mode As DuringFilterMode = DuringFilterMode.SpecificDates

        ' --- Specific Dates tab controls ---
        Public Property FromDate As DateBoundary = New DateBoundary()
        Public Property ToDate As DateBoundary = New DateBoundary()

        ' --- Months Names tab controls ---
        Public Property MonthsEnabled As Boolean
        Public Property MonthsText As String

        ''' <summary>
        ''' True if the filter, under its current mode, has an actual value entered.
        ''' </summary>
        Public ReadOnly Property HasValue As Boolean
            Get
                Select Case Mode
                    Case DuringFilterMode.SpecificDates
                        Return (FromDate.Enabled AndAlso FromDate.Value.HasValue) OrElse
                               (ToDate.Enabled AndAlso ToDate.Value.HasValue)
                    Case DuringFilterMode.MonthsNames
                        Return MonthsEnabled AndAlso Not String.IsNullOrWhiteSpace(MonthsText)
                    Case Else
                        Return False
                End Select
            End Get
        End Property

        ''' <summary>
        ''' Basic validation: if both From and To dates are enabled, From must not be after To.
        ''' </summary>
        Public Function IsValid(ByRef errorMessage As String) As Boolean
            errorMessage = String.Empty

            If Mode = DuringFilterMode.SpecificDates Then
                If FromDate.Enabled AndAlso ToDate.Enabled AndAlso
                   FromDate.Value.HasValue AndAlso ToDate.Value.HasValue Then

                    If FromDate.Value.Value > ToDate.Value.Value Then
                        errorMessage = "'From' date cannot be later than 'To' date."
                        Return False
                    End If
                End If
            End If

            Return True
        End Function

        Public Overrides Function ToString() As String
            Select Case Mode
                Case DuringFilterMode.SpecificDates
                    Return $"From: {FromDate}  To: {ToDate}"
                Case DuringFilterMode.MonthsNames
                    Return If(MonthsEnabled, MonthsText, String.Empty)
                Case Else
                    Return String.Empty
            End Select
        End Function

    End Class

    ''' <summary>
    ''' Holds all data captured on the search form:
    ''' Registration During, Travel During, and Duration (Nights/Days).
    ''' </summary>
    Public Class BookingSearchFilter

        Public Property Registration As DuringFilter = New DuringFilter()
        Public Property Travel As DuringFilter = New DuringFilter()

        Public Property DurationNights As Integer
        Public Property DurationDays As Integer

        Public Sub New()
        End Sub

        ''' <summary>
        ''' Validates the whole filter (both During blocks).
        ''' </summary>
        Public Function IsValid(ByRef errorMessage As String) As Boolean
            If Not Registration.IsValid(errorMessage) Then Return False
            If Not Travel.IsValid(errorMessage) Then Return False

            If DurationNights < 0 OrElse DurationDays < 0 Then
                errorMessage = "Duration cannot be negative."
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Convenience factory that maps the form's controls directly onto a
        ''' BookingSearchFilter instance. Call this from the form's "Search"/"OK" button.
        ''' </summary>
        ''' <param name="mode">Which tab was active (Specific Dates or Months Names).</param>
        Public Shared Function FromForm(
            mode As DuringFilterMode,
            regFromEnabled As Boolean, regFromDate As Date?,
            regToEnabled As Boolean, regToDate As Date?,
            travFromEnabled As Boolean, travFromDate As Date?,
            travToEnabled As Boolean, travToDate As Date?,
            regMonthsEnabled As Boolean, regMonthsText As String,
            travMonthsEnabled As Boolean, travMonthsText As String,
            nights As Integer, days As Integer) As BookingSearchFilter

            Dim result As New BookingSearchFilter()

            result.Registration.Mode = mode
            result.Registration.FromDate = New DateBoundary(regFromEnabled, regFromDate)
            result.Registration.ToDate = New DateBoundary(regToEnabled, regToDate)
            result.Registration.MonthsEnabled = regMonthsEnabled
            result.Registration.MonthsText = regMonthsText

            result.Travel.Mode = mode
            result.Travel.FromDate = New DateBoundary(travFromEnabled, travFromDate)
            result.Travel.ToDate = New DateBoundary(travToEnabled, travToDate)
            result.Travel.MonthsEnabled = travMonthsEnabled
            result.Travel.MonthsText = travMonthsText

            result.DurationNights = nights
            result.DurationDays = days

            Return result
        End Function

    End Class

End Namespace

' -----------------------------------------------------------------------
' Example usage from the form (assuming standard control names):
'
'   Dim mode As DuringFilterMode = If(tabControl.SelectedTab Is tabSpecificDates,
'                                      DuringFilterMode.SpecificDates,
'                                      DuringFilterMode.MonthsNames)
'
'   Dim filter = BookingSearchFilter.FromForm(
'       mode,
'       chkRegFrom.Checked, dtpRegFrom.Value,
'       chkRegTo.Checked, dtpRegTo.Value,
'       chkTravFrom.Checked, dtpTravFrom.Value,
'       chkTravTo.Checked, dtpTravTo.Value,
'       chkRegMonths.Checked, txtRegMonths.Text,
'       chkTravMonths.Checked, txtTravMonths.Text,
'       CInt(txtNights.Text), CInt(txtDays.Text))
'
'   Dim errMsg As String = ""
'   If Not filter.IsValid(errMsg) Then
'       MessageBox.Show(errMsg)
'   End If
' -----------------------------------------------------------------------
