Imports System.Windows.Forms
Imports vbAccelerator.Components.Win32

Public Class SelectWindow

    Public SelectedWindow As New WindowObject
    Public SettingsName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        SaveSetting("WinGrab", "UserPref", "Window", lstWindows.Text)
        SaveSetting("WinGrab", "UserPref", "ConfigSet", cboConfig.Text)
        SelectedWindow = CType(lstWindows.SelectedItem, WindowObject)
        If SelectedWindow Is Nothing Then
            MessageBox.Show("Please select a window to record", "Select Window", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        SettingsName = cboConfig.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()        
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        SelectedWindow = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WindowTitle As String
        Dim ConfigSet As String
        Dim nPos As Int32



        Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width

        Dim a As New WinGrabSettingsReader
        Dim objSettings As New ArrayList
        Dim objSetting As New WinGrabSetting

        objSettings = a.ReadSettings()
        cboConfig.DataSource = objSettings

        WindowTitle = GetSetting("WinGrab", "UserPref", "Window", "")
        ConfigSet = GetSetting("WinGrab", "UserPref", "ConfigSet", "")
        nPos = lstWindows.FindString(WindowTitle)
        If nPos >= 0 Then
            lstWindows.SelectedIndex = nPos
        End If
        nPos = cboConfig.FindString(ConfigSet)
        If nPos >= 0 Then
            cboConfig.SelectedIndex = nPos
        End If

    End Sub

    Public Sub PopulateWindows()
        'Get list of all windows and show in the list
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
