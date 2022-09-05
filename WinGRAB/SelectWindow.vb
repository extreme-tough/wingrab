Imports System.Windows.Forms
Imports vbAccelerator.Components.Win32

Public Class SelectWindow

    Public SelectedWindow As New WindowObject

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        SelectedWindow = CType(lstWindows.SelectedItem, WindowObject)
        If SelectedWindow Is Nothing Then
            MessageBox.Show("Please select a window to record", "Select Window", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        SelectedWindow = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width



    End Sub

    Public Sub PopulateWindows()        
        Dim ew As New EnumWindows
        ew.GetWindows()
        lstWindows.Items.Clear()
        For Each item As EnumWindowsItem In ew.Items
            Dim objWin As New WindowObject
            If item.Visible Then
                objWin.Text = item.Text
                objWin.Handle = item.Handle
                objWin.ClassName = item.ClassName
                lstWindows.Items.Add(objWin)
            End If
        Next
    End Sub
End Class
