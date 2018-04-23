Imports System
Imports System.ComponentModel

Namespace MVVMCharts

    Public Class TeamMember
        Implements INotifyPropertyChanged
        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
                OnPropertyChanged("Name")
            End Set
        End Property

        Private _CustomerSatScore As Double
        Public Property CustomerSatScore() As Double
            Get
                Return _CustomerSatScore
            End Get
            Set(ByVal value As Double)
                _CustomerSatScore = value
                OnPropertyChanged("CustomerSatScore")
            End Set
        End Property

        Public Sub New(ByVal name As String, ByVal customerSatScore As Double)
            _Name = name
            _CustomerSatScore = customerSatScore
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub OnPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

    End Class
End Namespace
