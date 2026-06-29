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


        Public Sub New()
        End Sub

        Public Sub New(name As String, Optional isChecked As Boolean = False)
            Me.Name = name
            Me.IsChecked = isChecked

        End Sub

        Public Overrides Function ToString() As String
            Return $"{Name} [{If(IsChecked, "x", " ")}]"
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

        Public Sub New()
        End Sub

        Public Sub New(name As String, Optional state As TriState = TriState.Unchecked)
            Me.Name = name
            Me.State = state
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Name} [{State}]"
        End Function
    End Class

    ''' <summary>
    ''' Full snapshot of everything entered/selected on the form:
    ''' Title, Sub Title, Countries, Cities (tri-state), Stay and Attraction.
    ''' </summary>
    Public Class TravelFormData
        Inherits TreeNode

        Public Property Title As New TitleField()
        Public Property SubTitle As New TitleField()

        Public Property Countries As New List(Of CheckListItem)()
        Public Property Cities As New List(Of CityListItem)()
        Public Property Stays As New List(Of CheckListItem)()
        Public Property Attractions As New List(Of CheckListItem)()

        ' ---------- Convenience accessors ----------

        Public Overrides Function ToString() As String
            Return $"Title={Title.Text}"
        End Function


    End Class

End Namespace