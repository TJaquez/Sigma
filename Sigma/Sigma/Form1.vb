Imports MySql.Data

Public Class Form1
    Private db As SigmaDB = SigmaDB.Instance

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'connect to database
        'If Not db.isConnected Then
        '    MsgBox("Can not connect to Database")
        'End If
        Me.KeyPreview = True
    End Sub

    Private Sub Form1_EscButtonPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim userInfo As UserInfo
        Dim result As Boolean = db.validateUser(userTextBox.Text, passTextBox.Text, userInfo)
        If (result = False) Then
            MsgBox("User or Password incorrect")
        Else
            Dim OpenBox = New OpenBoxForm(userInfo)
            OpenBox.Show()
            Me.Close()
        End If
    End Sub
End Class


