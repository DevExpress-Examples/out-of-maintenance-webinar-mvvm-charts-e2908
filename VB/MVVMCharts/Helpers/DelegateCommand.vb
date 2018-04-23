Imports System
Imports System.Windows.Input

Namespace MVVMCharts
    Public Class DelegateCommand
        Implements ICommand
        Private canExecute_Renamed As Func(Of Object, Boolean)
        Private executeAction As Action(Of Object)
        Private canExecuteCache As Boolean

        Public Sub New(ByVal executeAction As Action(Of Object), ByVal canExecute As Func(Of Object, Boolean))
            Me.executeAction = executeAction
            Me.canExecute_Renamed = canExecute

        End Sub


        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Dim temp As Boolean = canExecute_Renamed(parameter)
            If canExecuteCache <> temp Then
                canExecuteCache = temp
                RaiseEvent CanExecuteChanged(Me, New EventArgs())
            End If

            Return canExecuteCache
        End Function
        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            executeAction(parameter)
        End Sub
    End Class
End Namespace
