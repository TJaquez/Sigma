Public Class UserInfo
    Enum eUserPriviledge As Integer
        Admin = 1
        Gerente = 2
        Cajero = 3
    End Enum

    Private userId As Int32
    Private userName As String
    Private userLastName As String
    Private userPriviledge As eUserPriviledge
    Private UserOpenBoxMoney As UInt32

    Public Property Id As Integer
        Get
            Return userId
        End Get
        Private Set(value As Integer)
            userId = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return userName
        End Get
        Private Set(value As String)
            userName = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return userLastName
        End Get
        Private Set(value As String)
            userLastName = value
        End Set
    End Property

    Public Property Priviledge As eUserPriviledge
        Get
            Return userPriviledge
        End Get
        Private Set(value As eUserPriviledge)
            userPriviledge = value
        End Set
    End Property

    Public Property OpenBoxMoney As UInteger
        Get
            Return UserOpenBoxMoney
        End Get
        Set(value As UInteger)
            UserOpenBoxMoney = value
        End Set
    End Property

    Public Sub New(ByVal pId As Integer, ByVal pName As String, ByVal pLastName As String, ByVal pPriviledge As eUserPriviledge)
        Id = pId
        Name = pName
        LastName = pLastName
        Priviledge = pPriviledge
    End Sub

End Class
