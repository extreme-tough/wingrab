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
        Me.ctxMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmRecord = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPause = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmResetSize = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmCrop = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmShowViewer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.KeyboardHook1 = New WindowsHookLib.KeyboardHook
        Me.MouseHook1 = New WindowsHookLib.MouseHook
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.nicoStop = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.nicoStart = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.nicoPause = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ctxMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ctxMenuStrip
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "WinGRAB"
        Me.NotifyIcon1.Visible = True
        '
        'ctxMenuStrip
        '
        Me.ctxMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRecord, Me.tsmPause, Me.tsmResetSize, Me.ToolStripMenuItem1, Me.tsmCrop, Me.tsmShowViewer, Me.ToolStripMenuItem2, Me.tsmExit})
        Me.ctxMenuStrip.Name = "ContextMenuStrip1"
        Me.ctxMenuStrip.Size = New System.Drawing.Size(194, 148)
        '
        'tsmRecord
        '
        Me.tsmRecord.Name = "tsmRecord"
        Me.tsmRecord.Size = New System.Drawing.Size(193, 22)
        Me.tsmRecord.Text = "Start Record"
        '
        'tsmPause
        '
        Me.tsmPause.Enabled = False
        Me.tsmPause.Image = CType(resources.GetObject("tsmPause.Image"), System.Drawing.Image)
        Me.tsmPause.Name = "tsmPause"
        Me.tsmPause.Size = New System.Drawing.Size(193, 22)
        Me.tsmPause.Text = "Pause Recording"
        '
        'tsmResetSize
        '
        Me.tsmResetSize.Name = "tsmResetSize"
        Me.tsmResetSize.Size = New System.Drawing.Size(193, 22)
        Me.tsmResetSize.Text = "Reset Window Size"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(190, 6)
        '
        'tsmCrop
        '
        Me.tsmCrop.Enabled = False
        Me.tsmCrop.Name = "tsmCrop"
        Me.tsmCrop.Size = New System.Drawing.Size(193, 22)
        Me.tsmCrop.Text = "Crop Captured Images"
        '
        'tsmShowViewer
        '
        Me.tsmShowViewer.Name = "tsmShowViewer"
        Me.tsmShowViewer.Size = New System.Drawing.Size(193, 22)
        Me.tsmShowViewer.Text = "Show Image Viewer"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(190, 6)
        '
        'tsmExit
        '
        Me.tsmExit.Name = "tsmExit"
        Me.tsmExit.Size = New System.Drawing.Size(193, 22)
        Me.tsmExit.Text = "Exit"
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
        Me.Timer.Interval = 1000
        '
        'nicoStop
        '
        Me.nicoStop.ContextMenuStrip = Me.ctxMenuStrip
        Me.nicoStop.Icon = CType(resources.GetObject("nicoStop.Icon"), System.Drawing.Icon)
        Me.nicoStop.Text = "WinGRAB"
        '
        'nicoStart
        '
        Me.nicoStart.ContextMenuStrip = Me.ctxMenuStrip
        Me.nicoStart.Icon = CType(resources.GetObject("nicoStart.Icon"), System.Drawing.Icon)
        Me.nicoStart.Text = "WinGRAB"
        '
        'nicoPause
        '
        Me.nicoPause.ContextMenuStrip = Me.ctxMenuStrip
        Me.nicoPause.Icon = CType(resources.GetObject("nicoPause.Icon"), System.Drawing.Icon)
        Me.nicoPause.Text = "WinGRAB"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 326)
        Me.Name = "MainForm"
        Me.Text = "WinGRAB"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ctxMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ctxMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents KeyboardHook1 As WindowsHookLib.KeyboardHook
    Friend WithEvents MouseHook1 As WindowsHookLib.MouseHook
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents nicoStop As System.Windows.Forms.NotifyIcon
    Friend WithEvents tsmResetSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCrop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmShowViewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nicoStart As System.Windows.Forms.NotifyIcon
    Friend WithEvents nicoPause As System.Windows.Forms.NotifyIcon

End Class
