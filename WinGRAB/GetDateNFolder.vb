﻿Imports System.IO
Public Class GetDateNFolder

    Private Sub GetDateNFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Left = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        FolderName.Text = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory).ToString() + "\Screenshots"
    End Sub

    Private Sub PickFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PickFolder.Click
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FolderName.Text = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If FolderName.Text = "" Then
            MessageBox.Show("Folder name has to be given", "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If New DirectoryInfo(FolderName.Text).Exists() = False Then
            If MessageBox.Show("Given folder does not exist. Do you want to create it?", "Select Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                MkDir(FolderName.Text)
            Else
                Exit Sub
            End If
        End If
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub OKButton_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OKButton.Validating

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
End Class