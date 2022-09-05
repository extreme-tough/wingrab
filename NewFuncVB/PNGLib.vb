Imports System.Drawing.Drawing2D
Imports System.Drawing

Public Class CropPNG

    Dim tempCnt As Boolean         'check weather the roller is used or not

    Dim bm_dest As Bitmap
    Dim bm_source As Bitmap
    Dim i As Int16 = 0.5


    Dim btMap As Bitmap


#Region "Image Cropping"
    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim oCropX As Integer
    Dim oCropY As Integer
    Dim cropBitmap As Bitmap

    Public cropPen As Pen
    Public cropPenSize As Integer = 1 '2
    Public cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public cropPenColor As Color = Color.Yellow
    Dim PreviewPictureBox As New System.Windows.Forms.PictureBox
    Dim crobPictureBox As New System.Windows.Forms.PictureBox
    Sub SetParameters(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        cropX = x
        cropY = y

        cropWidth = width
        cropHeight = height

        cropPen = New Pen(cropPenColor, cropPenSize)
        cropPen.DashStyle = DashStyle.DashDotDot
    End Sub

    Dim tmppoint As Point


    Public Sub Crop()
        Try
            Try

                If cropWidth < 1 Then
                    Exit Sub
                End If

                Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)
                Dim bit As Bitmap = New Bitmap(crobPictureBox.Image, crobPictureBox.Width, crobPictureBox.Height)

                cropBitmap = New Bitmap(cropWidth, cropHeight)
                Dim g As Graphics = Graphics.FromImage(cropBitmap)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
                PreviewPictureBox.Image = cropBitmap

            Catch exc As Exception
            End Try
        Catch exc As Exception
        End Try
    End Sub
#End Region

    Sub LoadImage(ByVal Str As String)
        btMap = Bitmap.FromFile(Str)
        'PreviewPictureBox.Image = System.Drawing.Bitmap.FromFile(Str)
        PreviewPictureBox.Image = btMap
        'crobPictureBox.Image = System.Drawing.Bitmap.FromFile(Str)
        crobPictureBox.Image = btMap
        crobPictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.AutoSize
        PreviewPictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.AutoSize
    End Sub


    Public Sub SaveFile(ByVal sPath As String)
        Dim tempFileName As String

        tempFileName = sPath
        Try
            Dim img As Image = PreviewPictureBox.Image

            SavePhoto1(img, tempFileName)
        Catch exc As Exception
            MsgBox("Error on Saving: " & exc.Message)
        End Try
    End Sub
    Public Function SavePhoto1(ByVal src As Image, ByVal dest As String) As Boolean
        src.Save(dest, System.Drawing.Imaging.ImageFormat.Png)
    End Function

    'This function clears all handles so that the picture file will be unlocked for other  operations
    ' Call this function if you have to delete the loaded image files or rename it 
    Public Function DisposeImages()
        PreviewPictureBox.Image = Nothing
        crobPictureBox.Image = Nothing
        btMap.Dispose()
    End Function

End Class
