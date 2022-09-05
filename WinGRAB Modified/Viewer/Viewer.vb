Imports System.Xml
Imports System.IO
Imports WinGRAB.PNGLib
Public Class Viewer    
    Dim ActiveNodeIndex As Integer = -1 'Pointer to the index of the node in xml for which the img is displayed currenty
    Dim ActiveNode As XmlNode 'Pointer to the node in xml for which the img is displayed currenty
    Dim ActivePath As String 'The path of current XML file
    Dim objXML As New XmlDocument
    Dim xmlNodes As XmlNodeList
    Dim Img As Image
    Dim CurrentXMLFile As String 'Full path including xml file name
    Dim FullPath As String

    Public Sub OpenXML(ByVal XMLPath As String)
        'To be called by external processes by passing the generated XML file
        objXML.Load(XMLPath)
        CurrentXMLFile = XMLPath
        InitiatePic()
    End Sub


    Private Sub tsbOpenXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOpenXML.Click
        OpenFileDialog.Filter = "WinGRAB XML file (*.xml)|*.xml"
        OpenFileDialog.ShowDialog()
        If OpenFileDialog.FileName <> "" Then
            CurrentXMLFile = OpenFileDialog.FileName
            objXML.Load(CurrentXMLFile)
            InitiatePic()
        End If
    End Sub

    Private Sub InitiatePic()
        'Loads the first image from the XML file
        xmlNodes = objXML.SelectNodes("DataItem/Links/InternalLink")
        If xmlNodes.Count > 0 Then
            ActiveNodeIndex = 0
            ActiveNode = xmlNodes.Item(ActiveNodeIndex)
            ActivePath = Path.GetDirectoryName(CurrentXMLFile)
            DisplayPicture(ActiveNode)
        Else
            MessageBox.Show("XML does not contain any images", "XML", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ActiveNodeIndex = -1
        End If
    End Sub

    Private Sub DisplayPicture(ByVal FromNode As XmlNode)
        Dim ImgFile As String
        'Displays a picture associated with the XMLnode passed

        ImgFile = FromNode.SelectSingleNode("DataItem/Properties/ImageFile").InnerText
        If cboImgSet.SelectedIndex = 0 Then
            FullPath = ActivePath + "\png\" + ImgFile
        Else
            FullPath = ActivePath + "\runfiles\" + ImgFile
        End If
        Try
            Img = Image.FromFile(FullPath)
            PictureBox.Image = Img
            PictureBox.Refresh()
            ImgName.Text = ImgFile
            imgCount.Text = "Image " + (ActiveNodeIndex + 1).ToString() + " of " + xmlNodes.Count.ToString()
            StatusStrip.Refresh()
        Catch ex As Exception
            MessageBox.Show("Image file not found - " + FullPath, "Display Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeletePicture(ByVal FromNode As XmlNode)
        'Deletes a picture from the path
        Dim ImgFile As String

        ImgFile = FromNode.SelectSingleNode("DataItem/Properties/ImageFile").InnerText
        'Delete full image 
        FullPath = ActivePath + "\png\" + ImgFile
        Try
            PictureBox.Image = Nothing
            Img.Dispose()
            Kill(FullPath)
        Catch ex As Exception
            MessageBox.Show("Image file not found - " + FullPath, "Display Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Delete cropped image 
        FullPath = ActivePath + "\runfiles\" + ImgFile
        Try
            Kill(FullPath)
        Catch ex As Exception
            MessageBox.Show("Image file not found - " + FullPath, "Display Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboImgSet.SelectedIndex = 0
    End Sub


    Private Sub tsbFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFirst.Click
        If ActiveNodeIndex <> -1 Then
            ActiveNodeIndex = 0
            ActiveNode = xmlNodes.Item(ActiveNodeIndex)
            DisplayPicture(ActiveNode)
        End If
    End Sub

    Private Sub tsbLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLast.Click
        If ActiveNodeIndex <> -1 Then
            ActiveNodeIndex = xmlNodes.Count - 1
            ActiveNode = xmlNodes.Item(ActiveNodeIndex)
            DisplayPicture(ActiveNode)
        End If
    End Sub

    Private Sub tsbPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrev.Click
        If ActiveNodeIndex > 0 Then
            ActiveNodeIndex = ActiveNodeIndex - 1
            ActiveNode = xmlNodes.Item(ActiveNodeIndex)
            DisplayPicture(ActiveNode)
        End If
    End Sub

    Private Sub tsbNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNext.Click
        If ActiveNodeIndex <> -1 And ActiveNodeIndex < (xmlNodes.Count - 1) Then
            ActiveNodeIndex = ActiveNodeIndex + 1
            ActiveNode = xmlNodes.Item(ActiveNodeIndex)
            DisplayPicture(ActiveNode)
        End If
    End Sub

    Private Sub cboImgSet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboImgSet.SelectedIndexChanged
        If Not ActiveNode Is Nothing Then
            DisplayPicture(ActiveNode)
        End If
    End Sub

    Private Sub tsbImgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImgDelete.Click
        If MessageBox.Show("Are you sure you want to delete the image?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            DeletePicture(ActiveNode)
            xmlNodes(ActiveNodeIndex).ParentNode.RemoveChild(xmlNodes(ActiveNodeIndex))
            objXML.Save(CurrentXMLFile)
            PictureBox.Refresh()
            InitiatePic()
        End If
    End Sub

    Private Sub tsbCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCrop.Click
        Dim CroppedImgPath As String
        Dim TempFile As String
        If ActiveNodeIndex > -1 Then
            CropDialog.ShowDialog()
        Else
            MessageBox.Show("No images shown", "Crop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
        Dim arCropSet() As String = Split(CropDialog.cboCropSetting.Text, ",")
        Dim objPNGLib As New CropPNG

        CroppedImgPath = FullPath.Replace("\png\", "\runfiles\")
        Try
            'Create Runfiles folder if not found

            MkDir(Path.GetDirectoryName(CroppedImgPath))
        Catch ex As Exception

        End Try
        objPNGLib.LoadImage(CroppedImgPath)
        objPNGLib.SetParameters(arCropSet(0), arCropSet(1), arCropSet(2), arCropSet(3))
        objPNGLib.Crop()
        'Saving cannot overwrite an opened image. Use temporary file for saving
        TempFile = Path.GetTempFileName()
        objPNGLib.SaveFile(TempFile)
        'Release the handles
        objPNGLib.DisposeImages()
        If cboImgSet.SelectedIndex = 1 Then
            'Cropped image is currently displayed. Delete it and release the handles
            PictureBox.Image = Nothing
            Img.Dispose()
        End If
        File.Copy(TempFile, CroppedImgPath, True)
        DisplayPicture(ActiveNode)
        MessageBox.Show("Image has been cropped", "Crop", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tsmEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEdit.Click
        Shell("c:\Programme\TechSmith\SnagIt 9\SnagIt32.exe " + FullPath, AppWinStyle.MaximizedFocus)
    End Sub
End Class