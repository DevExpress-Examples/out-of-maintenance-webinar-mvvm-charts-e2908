Imports Microsoft.VisualBasic
Imports System.Windows.Input

Namespace MVVMCharts

	Public Class MainPageViewModel
		Public Sub New()
			RandomizeTeamCommand = New DelegateCommand(AddressOf RandomizeTeam, AddressOf CanRandomizeTeam)
		End Sub

		Private Sub RandomizeTeam(ByVal param As Object)
			_CurrentTeam.GenerateNewNumbers()
		End Sub

		Private Function CanRandomizeTeam(ByVal param As Object) As Boolean
			Return True
		End Function

		Private _CurrentTeam As New Team()
		Public ReadOnly Property CurrentTeam() As Team
			Get
				Return _CurrentTeam
			End Get
		End Property
		Private privateRandomizeTeamCommand As ICommand
		Public Property RandomizeTeamCommand() As ICommand
			Get
				Return privateRandomizeTeamCommand
			End Get
			Set(ByVal value As ICommand)
				privateRandomizeTeamCommand = value
			End Set
		End Property
	End Class
End Namespace
