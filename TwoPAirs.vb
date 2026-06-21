Public Class twoPairs
    Public Text As String
    Public ID As String

    Public Overrides Function ToString() As String 'this is the heart of the mission
        Return Text
    End Function

    Sub New(ByVal Text As String, ByVal ID As String)
        Me.Text = Text
        Me.ID = ID
    End Sub
End Class

Public Class listOfTwoPairs
    Public SelectedPairs As New List(Of twoPairs)

    Public ReadOnly Property arrText As String()
        Get
            Return SelectedPairs.Select(Function(p) p.Text).ToList().ToArray
        End Get
    End Property
    Public ReadOnly Property arrID As String()
        Get
            Return SelectedPairs.Select(Function(p) p.ID).ToList().ToArray
        End Get
    End Property
End Class

Public Class myTreeNode
    Inherits TreeNode
    Public SelectedPairs As New List(Of twoPairs)

    Public ReadOnly Property arrText As String()
        Get
            Return SelectedPairs.Select(Function(p) p.Text).ToList().ToArray
        End Get
    End Property
    Public ReadOnly Property arrID As String()
        Get
            Return SelectedPairs.Select(Function(p) p.ID).ToList().ToArray
        End Get
    End Property
End Class

