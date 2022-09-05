<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetDateNFolder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.FolderName = New System.Windows.Forms.TextBox
        Me.PickFolder = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboConfig = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'DateTimePicker
        '
        Me.DateTimePicker.CustomFormat = "MMMM dd, yyyy hh:mm"
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker.Location = New System.Drawing.Point(113, 252)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(245, 20)
        Me.DateTimePicker.TabIndex = 0
        Me.DateTimePicker.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 257)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date && Time"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folder"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.Visible = False
        '
        'FolderName
        '
        Me.FolderName.Location = New System.Drawing.Point(15, 300)
        Me.FolderName.Name = "FolderName"
        Me.FolderName.Size = New System.Drawing.Size(307, 20)
        Me.FolderName.TabIndex = 3
        Me.FolderName.Visible = False
        '
        'PickFolder
        '
        Me.PickFolder.Location = New System.Drawing.Point(329, 300)
        Me.PickFolder.Name = "PickFolder"
        Me.PickFolder.Size = New System.Drawing.Size(28, 20)
        Me.PickFolder.TabIndex = 4
        Me.PickFolder.Text = "..."
        Me.PickFolder.UseVisualStyleBackColor = True
        Me.PickFolder.Visible = False
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(183, 350)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 5
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(279, 350)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "This tool creates screenshots of your desktop."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(315, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Check if mouse effects have been disabled in your control panel. "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(297, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Check that the application you want to record is opened now."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Right click on your desktop, choose "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(258, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = """Properties"" - ""Performance"" - ""Adjust Visual Effects"""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(42, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(222, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "or ""Eigenschaften"" - ""Darstellung"" - ""Effekte"""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(317, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "This tool might capture private data if displayed in the record area."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(307, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Check your screenshots after recording and delete private data."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 236)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(252, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Confirm and start with right click on system tray icon."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 283)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Select Configuration Set"
        '
        'cboConfig
        '
        Me.cboConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConfig.FormattingEnabled = True
        Me.cboConfig.Location = New System.Drawing.Point(15, 301)
        Me.cboConfig.Name = "cboConfig"
        Me.cboConfig.Size = New System.Drawing.Size(339, 21)
        Me.cboConfig.TabIndex = 11
        '
        'GetDateNFolder
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(377, 387)
        Me.Controls.Add(Me.cboConfig)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.PickFolder)
        Me.Controls.Add(Me.FolderName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "GetDateNFolder"
        Me.Text = "Screenshot-Recoder 1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderName As System.Windows.Forms.TextBox
    Friend WithEvents PickFolder As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboConfig As System.Windows.Forms.ComboBox
End Class
