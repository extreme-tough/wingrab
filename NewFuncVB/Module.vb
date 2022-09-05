Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Xml
Class MainClass
    Public SelectedWindow As New WindowObject
    Dim img As Image
    Dim objPNGLib As New CropPNG
    Dim objSettings As New ArrayList
    Dim objSetting As New WinGrabSetting
    Public Sub Initialize()
        Dim NameFound As Boolean = False

        objSettings = ReadSettings()
        SelectWindow.PopulateWindows()
        If SelectWindow.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SelectedWindow = SelectWindow.SelectedWindow
            If SelectedWindow Is Nothing Then
                'Do nothing


            Else

                For Each objSetting In objSettings
                    If (objSetting.Name.ToLower().Equals(SelectWindow.SettingsName.ToLower())) Then
                        NameFound = True
                        Exit For
                    End If
                Next

                If Not NameFound Then
                    Throw New Exception("Setting name not found in settings.xml")
                    Return
                End If
                If objSetting.Resize = "MAX" Then
                    FormHelper.ShowWindowMAX(SelectedWindow.Handle)
                Else
                    FormHelper.Resize(SelectedWindow.Handle, objSetting.WindowLeft, objSetting.WindowTop, objSetting.WindowWidth, objSetting.WindowHeight) '1903136
                End If
                FormHelper.MakeTopMost(SelectedWindow.Handle)
                'FormHelper.MakeTop(SelectedWindow.Handle)
                'img = ICapture.FullScreen
            End If
        End If
    End Sub

    Public Sub Crop(ByVal PNGfile As String)
        Dim TempFile As String
        img = ICapture.Window(SelectedWindow.Handle)
        TempFile = System.Environment.GetFolderPath(Environment.SpecialFolder.System) + "\temp.png"
        Try
            Kill(TempFile)
        Catch ex As Exception

        End Try
        img.Save(TempFile, Imaging.ImageFormat.Png)
        objPNGLib.LoadImage(TempFile)
        objPNGLib.SetParameters(objSetting.CropLeft, objSetting.CropTop, objSetting.CropWidth, objSetting.CropHeight)
        objPNGLib.Crop()
        objPNGLib.SaveFile(PNGfile)
        FormHelper.MakeNormal(SelectedWindow.Handle)
        Try
            Kill(TempFile)
        Catch ex As Exception

        End Try
    End Sub

    Private Function ReadSettings() As ArrayList
        Dim objXML As New XmlTextReader("settings.xml")
        Dim objSetting As New WinGrabSetting
        Dim objSettingStore As New ArrayList

        ' Read node by node till the end of the XML 
        While (objXML.Read())
            If objXML.NodeType = XmlNodeType.Element Then
                Select Case objXML.Name.ToUpper()
                    Case "NAME"
                        objXML.Read()
                        objSetting.Name = objXML.Value
                    Case "RESIZE"
                        objXML.Read()
                        objSetting.SetWinSize(objXML.Value)
                    Case "CROP"
                        objXML.Read()
                        objSetting.SetCropSize(objXML.Value)
                    Case "OUTPUT"
                        objXML.Read()
                        objSetting.OutputFolder = objXML.Value
                End Select
            End If
            'Once ther reading reaches the end of the configset item, store it in arraylist
            If objXML.NodeType = XmlNodeType.EndElement And objXML.Name.ToUpper() = "CONFIGSET" Then
                objSettingStore.Add(objSetting)
                objSetting = New WinGrabSetting
            End If
        End While
        Return objSettingStore
    End Function
End Class


Public Class FormHelper
    <DllImport("user32.dll")> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, _
    ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInt32) As Boolean
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As UInt32) As Long
    End Function


    Private Shared ReadOnly HWND_NOTOPMOST As IntPtr = New IntPtr(-2)
    Private Shared ReadOnly HWND_TOP As IntPtr = New IntPtr(0)
    Private Shared ReadOnly HWND_TOPMOST As IntPtr = New IntPtr(-1)

    Private Const SWP_NOSIZE As UInt32 = &H1
    Private Const SWP_NOMOVE As UInt32 = &H2
    Private Const SWP_NOZORDER As UInt32 = &H4
    Private Const SWP_NOREDRAW As UInt32 = &H8
    Private Const SWP_NOACTIVATE As UInt32 = &H10
    Private Const SWP_FRAMECHANGED As UInt32 = &H20  ' The frame changed: send WM_NCCALCSIZE
    Private Const SWP_SHOWWINDOW As UInt32 = &H40
    Private Const SWP_HIDEWINDOW As UInt32 = &H80
    Private Const SWP_NOCOPYBITS As UInt32 = &H100
    Private Const SWP_NOOWNERZORDER As UInt32 = &H200  ' Don't do owner Z ordering
    Private Const SWP_NOSENDCHANGING As UInt32 = &H400  ' Don't send WM_WINDOWPOSCHANGING

    Private Const TOPMOST_FLAGS As UInt32 = SWP_NOMOVE Or SWP_NOSIZE

    Public Shared Sub MakeTop(ByVal hWnd As IntPtr)
        FormHelper.SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0, 3)
    End Sub
    Public Shared Sub MakeTopMost(ByVal hWnd As IntPtr)
        FormHelper.SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 3)
    End Sub
    Public Shared Sub MakeNormal(ByVal hWnd As IntPtr)
        FormHelper.SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, 3)
    End Sub
    Public Shared Sub Resize(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        'FormHelper.SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 1000, 645, 0)
        FormHelper.SetWindowPos(hWnd, HWND_NOTOPMOST, x, y, width, height, 0)
    End Sub
    Public Shared Sub ShowWindowMAX(ByVal hWnd As IntPtr)
        FormHelper.ShowWindow(hWnd, 3)
    End Sub
End Class

