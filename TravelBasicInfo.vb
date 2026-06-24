Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace TravelForm.Models

    ''' <summary>
    ''' Tri-state value for controls that support Unchecked / Checked / Indeterminate.
    ''' This is the "third state" used by the Cities list, shown in the UI as a
    ''' grayed-out checkmark for cities that are implied/inherited rather than
    ''' explicitly chosen by the user (e.g. Córdoba, Barcelona in the screenshot),
    ''' as opposed to a normal checked item (e.g. Seville).
    ''' </summary>
    Public Enum TriState
        Unchecked = 0
        Checked = 1
        Indeterminate = 2
    End Enum

    ''' <summary>
    ''' Title / Sub Title block: an on/off checkbox paired with its text value.
    ''' </summary>
    Public Class TitleField
        Public Property IsEnabled As Boolean
        Public Property Text As String = String.Empty

        Public Sub New()
        End Sub

        Public Sub New(isEnabled As Boolean, text As String)
            Me.IsEnabled = isEnabled
            Me.Text = text
        End Sub
    End Class

    ''' <summary>
    ''' A normal two-state checklist row, used by the Countries, Stay and
    ''' Attraction lists. IsHeader marks the non-checkable "----Spain----"
    ''' style separator rows that group items underneath them.
    ''' </summary>
    Public Class CheckListItem
        Public Property Name As String
        Public Property IsChecked As Boolean
        Public Property IsHeader As Boolean

        Public Sub New()
        End Sub

        Public Sub New(name As String, Optional isChecked As Boolean = False, Optional isHeader As Boolean = False)
            Me.Name = name
            Me.IsChecked = isChecked
            Me.IsHeader = isHeader
        End Sub

        Public Overrides Function ToString() As String
            If IsHeader Then
                Return $"--{Name}--"
            Else
                Return $"{Name} [{If(IsChecked, "x", " ")}]"
            End If
        End Function
    End Class

    ''' <summary>
    ''' A row in the Cities checklist. Same idea as CheckListItem, but holds a
    ''' TriState instead of a Boolean, since this list supports the third
    ''' (indeterminate / grayed) state.
    ''' </summary>
    Public Class CityListItem
        Public Property Name As String
        Public Property State As TriState = TriState.Unchecked
        Public Property IsHeader As Boolean

        Public Sub New()
        End Sub

        Public Sub New(name As String, Optional state As TriState = TriState.Unchecked, Optional isHeader As Boolean = False)
            Me.Name = name
            Me.State = state
            Me.IsHeader = isHeader
        End Sub

        Public Overrides Function ToString() As String
            If IsHeader Then
                Return $"--{Name}--"
            Else
                Return $"{Name} [{State}]"
            End If
        End Function
    End Class

    ''' <summary>
    ''' Full snapshot of everything entered/selected on the form:
    ''' Title, Sub Title, Countries, Cities (tri-state), Stay and Attraction.
    ''' </summary>
    Public Class TravelFormData
        Public Property Title As New TitleField()
        Public Property SubTitle As New TitleField()

        Public Property Countries As New List(Of CheckListItem)()
        Public Property Cities As New List(Of CityListItem)()
        Public Property Stays As New List(Of CheckListItem)()
        Public Property Attractions As New List(Of CheckListItem)()

        ' ---------- Convenience accessors ----------

        Public ReadOnly Property CheckedCountries As IEnumerable(Of String)
            Get
                Return Countries.Where(Function(c) Not c.IsHeader AndAlso c.IsChecked).Select(Function(c) c.Name)
            End Get
        End Property

        Public ReadOnly Property CheckedCities As IEnumerable(Of String)
            Get
                Return Cities.Where(Function(c) Not c.IsHeader AndAlso c.State = TriState.Checked).Select(Function(c) c.Name)
            End Get
        End Property

        Public ReadOnly Property IndeterminateCities As IEnumerable(Of String)
            Get
                Return Cities.Where(Function(c) Not c.IsHeader AndAlso c.State = TriState.Indeterminate).Select(Function(c) c.Name)
            End Get
        End Property

        Public ReadOnly Property CheckedStays As IEnumerable(Of String)
            Get
                Return Stays.Where(Function(s) Not s.IsHeader AndAlso s.IsChecked).Select(Function(s) s.Name)
            End Get
        End Property

        Public ReadOnly Property CheckedAttractions As IEnumerable(Of String)
            Get
                Return Attractions.Where(Function(a) Not a.IsHeader AndAlso a.IsChecked).Select(Function(a) a.Name)
            End Get
        End Property

        ''' <summary>Sets the tri-state value for a named (non-header) city row.</summary>
        Public Sub SetCityState(cityName As String, state As TriState)
            Dim city = Cities.FirstOrDefault(Function(c) Not c.IsHeader AndAlso String.Equals(c.Name, cityName, StringComparison.OrdinalIgnoreCase))
            If city IsNot Nothing Then
                city.State = state
            End If
        End Sub

        ''' <summary>Gets the tri-state value for a named city, defaulting to Unchecked.</summary>
        Public Function GetCityState(cityName As String) As TriState
            Dim city = Cities.FirstOrDefault(Function(c) Not c.IsHeader AndAlso String.Equals(c.Name, cityName, StringComparison.OrdinalIgnoreCase))
            If city Is Nothing Then
                Return TriState.Unchecked
            Else
                Return city.State
            End If
        End Function

        Public Overrides Function ToString() As String
            Return $"Title=""{Title.Text}"" (enabled={Title.IsEnabled}), " &
                   $"SubTitle=""{SubTitle.Text}"" (enabled={SubTitle.IsEnabled}), " &
                   $"Countries=[{String.Join(", ", CheckedCountries)}], " &
                   $"Cities(checked)=[{String.Join(", ", CheckedCities)}], " &
                   $"Cities(indeterminate)=[{String.Join(", ", IndeterminateCities)}], " &
                   $"Stays=[{String.Join(", ", CheckedStays)}], " &
                   $"Attractions=[{String.Join(", ", CheckedAttractions)}]"
        End Function
    End Class

End Namespace