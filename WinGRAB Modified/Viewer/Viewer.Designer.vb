<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Viewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Viewer))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbOpenXML = New System.Windows.Forms.ToolStripButton
        Me.tsbFirst = New System.Windows.Forms.ToolStripButton
        Me.tsbPrev = New System.Windows.Forms.ToolStripButton
        Me.tsbNext = New System.Windows.Forms.ToolStripButton
        Me.tsbLast = New System.Windows.Forms.ToolStripButton
        Me.tsbImgDelete = New System.Windows.Forms.ToolStripButton
        Me.cboImgSet = New System.Windows.Forms.ToolStripComboBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.imgCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ImgName = New System.Windows.Forms.ToolStripStatusLabel
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.tsbCrop = New System.Windows.Forms.ToolStripButton
        Me.tsmEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOpenXML, Me.tsbFirst, Me.tsbPrev, Me.tsbNext, Me.tsbLast, Me.tsbImgDelete, Me.cboImgSet, Me.tsbCrop, Me.tsmEdit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(918, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbOpenXML
        '
        Me.tsbOpenXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOpenXML.Image = CType(resources.GetObject("tsbOpenXML.Image"), System.Drawing.Image)
        Me.tsbOpenXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpenXML.Name = "tsbOpenXML"
        Me.tsbOpenXML.Size = New System.Drawing.Size(36, 36)
        Me.tsbOpenXML.Text = "Open WinGRAB XML File"
        '
        'tsbFirst
        '
        Me.tsbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFirst.Image = CType(resources.GetObject("tsbFirst.Image"), System.Drawing.Image)
        Me.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFirst.Name = "tsbFirst"
        Me.tsbFirst.Size = New System.Drawing.Size(36, 36)
        Me.tsbFirst.Text = "Go to First Image"
        '
        'tsbPrev
        '
        Me.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrev.Image = CType(resources.GetObject("tsbPrev.Image"), System.Drawing.Image)
        Me.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrev.Name = "tsbPrev"
        Me.tsbPrev.Size = New System.Drawing.Size(36, 36)
        Me.tsbPrev.Text = "Go to Previous Image"
        '
        'tsbNext
        '
        Me.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNext.Image = CType(resources.GetObject("tsbNext.Image"), System.Drawing.Image)
        Me.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNext.Name = "tsbNext"
        Me.tsbNext.Size = New System.Drawing.Size(36, 36)
        Me.tsbNext.Text = "Go to Next Image"
        '
        'tsbLast
        '
        Me.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLast.Image = CType(resources.GetObject("tsbLast.Image"), System.Drawing.Image)
        Me.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLast.Name = "tsbLast"
        Me.tsbLast.Size = New System.Drawing.Size(36, 36)
        Me.tsbLast.Text = "Go to Last Image"
        '
        'tsbImgDelete
        '
        Me.tsbImgDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbImgDelete.Image = CType(resources.GetObject("tsbImgDelete.Image"), System.Drawing.Image)
        Me.tsbImgDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImgDelete.Name = "tsbImgDelete"
        Me.tsbImgDelete.Size = New System.Drawing.Size(36, 36)
        Me.tsbImgDelete.Text = "Delete Image"
        '
        'cboImgSet
        '
        Me.cboImgSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImgSet.Items.AddRange(New Object() {"Full Size", "Cropped"})
        Me.cboImgSet.Name = "cboImgSet"
        Me.cboImgSet.Size = New System.Drawing.Size(175, 39)
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.imgCount, Me.ImgName})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 521)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(918, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'imgCount
        '
        Me.imgCount.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.imgCount.Name = "imgCount"
        Me.imgCount.Size = New System.Drawing.Size(0, 17)
        '
        'ImgName
        '
        Me.ImgName.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.ImgName.Name = "ImgName"
        Me.ImgName.Size = New System.Drawing.Size(0, 17)
        '
        'PictureBox
        '
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox.Location = New System.Drawing.Point(0, 39)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(918, 482)
        Me.PictureBox.TabIndex = 2
        Me.PictureBox.TabStop = False
        '
        'tsbCrop
        '
        Me.tsbCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCrop.Image = CType(resources.GetObject("tsbCrop.Image"), System.Drawing.Image)
        Me.tsbCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCrop.Name = "tsbCrop"
        Me.tsbCrop.Size = New System.Drawing.Size(36, 36)
        Me.tsbCrop.Text = "Crop Image"
        '
        'tsmEdit
        '
        Me.tsmEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsmEdit.Image = CType(resources.GetObject("tsmEdit.Image"), System.Drawing.Image)
        Me.tsmEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsmEdit.Name = "tsmEdit"
        Me.tsmEdit.Size = New System.Drawing.Size(36, 36)
        Me.tsmEdit.Text = "Edit with Snag It"
        '
        'Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 543)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Viewer"
        Me.Text = "WinGRAB Image Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbOpenXML As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImgDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboImgSet As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents imgCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImgName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbCrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmEdit As System.Windows.Forms.ToolStripButton
End Class
