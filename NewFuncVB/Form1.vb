
Public Class Form1
    Dim oMain As New MainClass()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Hide()

        Me.KeyboardHook1.InstallHook()
        oMain.Initialize()

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        KeyboardHook1.RemoveHook()
    End Sub

    Private Sub KeyboardHook1_KeyDown(ByVal sender As System.Object, ByVal e As WindowsHookLib.KeyBoardEventArgs) Handles KeyboardHook1.KeyDown
        If e.KeyCode.ToString() = "Q" And e.Control = True And e.Shift = True Then
            oMain.Crop("c:\1.png")
        End If
    End Sub
End Class
