<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmRecord = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmExit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmResetSize = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.KeyboardHook1 = New WindowsHookLib.KeyboardHook
        Me.MouseHook1 = New WindowsHookLib.MouseHook
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon2 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "WinGRAB"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRecord, Me.tsmResetSize, Me.ToolStripMenuItem1, Me.tsmExit})
        Me.ContextMenuStrip.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(173, 76)
        '
        'tsmRecord
        '
        Me.tsmRecord.Name = "tsmRecord"
        Me.tsmRecord.Size = New System.Drawing.Size(172, 22)
        Me.tsmRecord.Text = "Start Record"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 6)
        '
        'tsmExit
        '
        Me.tsmExit.Name = "tsmExit"
        Me.tsmExit.Size = New System.Drawing.Size(172, 22)
        Me.tsmExit.Text = "Exit"
        '
        'tsmResetSize
        '
        Me.tsmResetSize.Name = "tsmResetSize"
        Me.tsmResetSize.Size = New System.Drawing.Size(172, 22)
        Me.tsmResetSize.Text = "Reset Window Size"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "RecStart")
        Me.ImageList.Images.SetKeyName(1, "RecStop")
        '
        'KeyboardHook1
        '
        '
        'MouseHook1
        '
        '
        'Timer
        '
        Me.Timer.Interval = 500
        '
        'NotifyIcon2
        '
        Me.NotifyIcon2.ContextMenuStrip = Me.ContextMenuStrip
        Me.NotifyIcon2.Icon = CType(resources.GetObject("NotifyIcon2.Icon"), System.Drawing.Icon)
        Me.NotifyIcon2.Text = "WinGRAB"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 326)
        Me.Name = "MainForm"
        Me.Text = "WinGRAB"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents KeyboardHook1 As WindowsHookLib.KeyboardHook
    Friend WithEvents MouseHook1 As WindowsHookLib.MouseHook
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon2 As System.Windows.Forms.NotifyIcon
    Friend WithEvents tsmResetSize As System.Windows.Forms.ToolStripMenuItem

End Class
