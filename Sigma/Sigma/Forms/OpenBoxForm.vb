Public Class OpenBoxForm
    Private userInfo As UserInfo

    Public Sub New(ByVal pUserInfo As UserInfo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        userInfo = pUserInfo

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub OpenBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "") Then
            Label2.Text = "Escriba la cantidad con la que empieza la caja"
        Else
            If (IsNumeric(TextBox1.Text)) Then
                Dim value As Int32 = Convert.ToInt32(TextBox1.Text)
                If (value < 0) Then
                    Label2.Text = "El Valor no puede ser negativo"
                Else
                    userInfo.OpenBoxMoney = value
                    Dim Main = New MainForm(userInfo)
                    Main.Show()
                    Me.Close()
                End If
            Else
                Label2.Text = "Valor Incorrecto solo valores numericos y positvos"
            End If
        End If
    End Sub
End Class