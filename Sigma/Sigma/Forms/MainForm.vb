Public Class MainForm
    Private userInfo As UserInfo

    Public Sub New(ByVal pUserInfo As UserInfo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        userInfo = pUserInfo

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class