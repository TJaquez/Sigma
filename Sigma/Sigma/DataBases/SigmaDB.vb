Imports MySql.Data.MySqlClient
Imports Sigma.UserInfo

Public NotInheritable Class SigmaDB
    Private Shared ReadOnly handle As New Lazy(Of SigmaDB)(Function() New SigmaDB(),
                                                           System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)
    Private handler As SigmaDB
    Private Const Id As String = "Id"
    Private Const Name As String = "Name"
    Private Const LastName As String = "LastName"
    Private Const BirthDate As String = "BirthDate"
    Private Const Priviledge As String = "Priviledge"

    Private errorStr As String

    Private Function connect(ByRef SqlConn As MySqlConnection) As Boolean
        Dim result As Boolean = False
        Dim DatabaseName As String = "Sigma"
        Dim server As String = "localhost"
        Dim userName As String = "root"
        Dim password As String = ""
        If Not SqlConn Is Nothing Then SqlConn.Close()
        SqlConn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            SqlConn.Open()
            result = True
            'MsgBox("Connected")
        Catch ex As Exception
            errorStr = ex.Message
            'MsgBox(ex.Message)
        End Try
        'conn.Close()

        Return result
    End Function

    Private Sub New()

    End Sub

    Public Shared ReadOnly Property Instance() As SigmaDB
        Get
            Return handle.Value
        End Get
    End Property

    Public Function validateUser(ByVal user As String, ByVal password As String, ByRef userInfo As UserInfo)
        Dim res As Boolean = False
        Dim sqlConn As New MySqlConnection

        If (connect(sqlConn)) Then
            Dim sqlQuery As String = "SELECT * FROM user WHERE User = @user and Password = @password"

            Using sqlComm As MySqlCommand = New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.Add(New MySqlParameter("@user", user))
                    .Parameters.Add(New MySqlParameter("@password", password))
                End With

                Try
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()
                    While sqlReader.Read()
                        If (sqlReader.HasRows) Then
                            res = True
                            Dim vId As Int32 = sqlReader.GetInt32(Id)
                            Dim vName As String = sqlReader.GetString(Name)
                            Dim vLastName As String = sqlReader.GetString(LastName)
                            Dim vPriviledge As Int32 = sqlReader.GetInt32(Priviledge)

                            userInfo = New UserInfo(vId, vName, vLastName, vPriviledge)
                        Else
                            res = False
                            errorStr = "Login Failed! Please try again or contact support"
                        End If
                    End While
                Catch ex As MySqlException
                    errorStr = ex.Message
                End Try
            End Using
        End If

        Return res
    End Function

End Class
