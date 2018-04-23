Imports System
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Namespace MVVMCharts

    Public Class Team
        Inherits ObservableCollection(Of TeamMember)

        Public Sub New()
            MyBase.New()
            Add(New TeamMember("Bob", 98.0))
            Add(New TeamMember("John", 95.0))
            Add(New TeamMember("Mike", 98.0))
            Add(New TeamMember("Julie", 95.0))
        End Sub

        Public Function GetMember(ByVal name As String) As TeamMember
            Dim returnResult As TeamMember = Nothing

            For Each member As TeamMember In Me
                If member.Name = name Then
                    returnResult = member
                End If
            Next member

            Return returnResult
        End Function

        Public Sub GenerateNewNumbers()

            Dim r As New Random()

            For Each member As TeamMember In Me
                member.CustomerSatScore = r.NextDouble() * 100
            Next member

            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End Sub

        Public Function GetCustomerSatScore(ByVal name As String) As Double
            Dim returnResult As Double = Double.MinValue

            Dim member As TeamMember = GetMember(name)

            If member IsNot Nothing Then
                returnResult = member.CustomerSatScore
            End If

            Return returnResult
        End Function

        Public Sub SetCustomerSatScore(ByVal name As String, ByVal newCustomerSatScore As Double)
            Dim member As TeamMember = GetMember(name)

            If member IsNot Nothing Then
                member.CustomerSatScore = newCustomerSatScore
            End If
        End Sub

        Public ReadOnly Property TeamMembers() As String()
            Get
                Dim returnResult(Me.Count - 1) As String

                For index As Integer = 0 To Me.Count - 1
                    returnResult(index) = Me.Items(index).Name
                Next index

                Return returnResult
            End Get
        End Property
    End Class
End Namespace
