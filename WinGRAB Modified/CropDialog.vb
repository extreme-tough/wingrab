Imports System.Windows.Forms

Public Class CropDialog
    Dim a As New WinGrabSettingsReader
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CropDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objSettings As New ArrayList
        Dim objSetting As New WinGrabSetting
        Dim ComboText As String

        cboCropSetting.Items.Clear()

        objSettings = a.ReadSettings()
        For Each objSet As WinGrabSetting In objSettings
            If objSet.Crop <> "NO" Then
                'Format the coordinates to show x,y,width,height
                ComboText = String.Format("{0},{1},{2},{3}", objSet.CropLeft, objSet.CropTop, objSet.CropWidth, objSet.CropHeight)
                cboCropSetting.Items.Add(ComboText)
            End If
        Next
        If cboCropSetting.Items.Count > 0 Then
            cboCropSetting.SelectedIndex = 0
        End If
    End Sub
End Class
