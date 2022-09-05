Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Text
Public Class MainForm
    Dim TargetFolder As String
    Dim nCount As Integer
    Dim FolderName As String
    Dim writer As XmlTextWriter
    Dim SelectedWindow As New WindowObject
    Private Sub MainForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tsmRecord.Image = ImageList.Images("RecStop")
        tsmRecord.Tag = "START"
        Me.Hide()
        Dim notepadID As Integer
        ' Activate a running Notepad process.
        ' AppActivate("Untitled - Notepad")
        ' AppActivate can also use the return value of the Shell function.
        ' Shell runs a new instance of Notepad.
        'notepadID = Shell("c:\WINDOWS\system32\notepad.exe", AppWinStyle.NormalFocus)
        ' Activate the new instance of Notepad.  
        'AppActivate(notepadID)


    End Sub
    Sub SwapIcons()
        Dim icnSysTray As Icon
        icnSysTray = NotifyIcon1.Icon
        NotifyIcon1.Icon = NotifyIcon2.Icon
        NotifyIcon2.Icon = icnSysTray
    End Sub
    Private Sub tsmRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRecord.Click


        If tsmRecord.Tag = "START" Then
            'Start Record Clicked

            If GetDateNFolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SelectWindow.PopulateWindows()
                If SelectWindow.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SelectedWindow = SelectWindow.SelectedWindow
                    If SelectedWindow Is Nothing Then
                        'Do nothing


                    Else
                        TargetFolder = GetDateNFolder.FolderName.Text
                        FolderName = GetDateNFolder.DateTimePicker.Value.ToString("yyyyddMM-HHmmss")

                        Try
                            MkDir(TargetFolder + "\" + FolderName)
                        Catch ex As Exception

                        End Try

                        writer = New XmlTextWriter(TargetFolder + "\" + FolderName + "\" + FolderName + ".xml", Encoding.ASCII)
                        writer.WriteStartDocument()
                        writer.WriteStartElement("sshots")

                        SwapIcons()

                        tsmRecord.Image = ImageList.Images("RecStart")
                        tsmRecord.Tag = "STOP"
                        tsmRecord.Text = "Stop Record"

                        FormHelper.MakeTop(SelectedWindow.Handle)
                        FormHelper.Resize(SelectedWindow.Handle) '1903136

                        Me.KeyboardHook1.InstallHook()
                        Me.MouseHook1.InstallHook()

                        Exit Sub
                    End If
                    'Start Recording

                End If
            End If
        Else
            'Stop Record Clicked            
            Me.KeyboardHook1.RemoveHook()
            Me.MouseHook1.RemoveHook()
            writer.WriteEndElement()
            writer.Close()

            SwapIcons()

            tsmRecord.Image = ImageList.Images("RecStop")
            tsmRecord.Tag = "START"
            tsmRecord.Text = "Start Record"
            SelectedWindow = Nothing
            MessageBox.Show("Recording stopped", "Recording", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub KeyboardHook1_KeyDown(ByVal sender As System.Object, ByVal e As WindowsHookLib.KeyBoardEventArgs) Handles KeyboardHook1.KeyDown
        Dim capture As ICapture
        Dim img As Image
        Dim sFileName As String

        'img = ICapture.ActiveWindow
        Try
            img = ICapture.Window(SelectedWindow.Handle)
        Catch ex As Exception
            Exit Sub
        End Try

        sFileName = nCount.ToString("000") + ".png"
        img.Save(TargetFolder + "\" + FolderName + "\" + FolderName + "-" + sFileName, Imaging.ImageFormat.Png)

        WriteXML(FolderName + "-" + sFileName, "Key Down", MousePosition.X, MousePosition.Y)


        nCount = nCount + 1

    End Sub


    Private Sub tsmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExit.Click
        Application.Exit()
    End Sub

    Private Sub WriteXML(ByVal sFile As String, ByVal sEvent As String, ByVal x As Integer, ByVal y As String)
        writer.WriteStartElement("screenshot")
        writer.WriteStartElement("file")
        writer.WriteString(sFile)
        writer.WriteEndElement()
        writer.WriteStartElement("posX")
        writer.WriteString(x.ToString())
        writer.WriteEndElement()
        writer.WriteStartElement("posY")
        writer.WriteString(y.ToString())
        writer.WriteEndElement()
        writer.WriteStartElement("event")
        writer.WriteString(sEvent)
        writer.WriteEndElement()
        writer.WriteStartElement("comment")
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

    Private Sub MouseHook1_MouseUp(ByVal sender As System.Object, ByVal e As WindowsHookLib.MouseEventArgs) Handles MouseHook1.MouseUp
        Dim capture As ICapture
        Dim img As Image
        Dim sFileName As String

        Try
            img = ICapture.Window(SelectedWindow.Handle)
        Catch ex As Exception
            Exit Sub
        End Try

        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            Timer.Enabled = True
            Exit Sub
        End If

        sFileName = nCount.ToString("000") + ".png"
        img.Save(TargetFolder + "\" + FolderName + "\" + FolderName + "-" + sFileName, Imaging.ImageFormat.Png)

        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            WriteXML(FolderName + "-" + sFileName, "Left Click", e.X, e.Y)
        ElseIf (e.Button = Windows.Forms.MouseButtons.Right) Then
            WriteXML(FolderName + "-" + sFileName, "Right Click", e.X, e.Y)
        End If

        nCount = nCount + 1
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Dim capture As ICapture
        Dim img As Image
        Dim sFileName As String
        Try
            img = ICapture.Window(SelectedWindow.Handle)
        Catch ex As Exception
            Exit Sub
        End Try


        sFileName = nCount.ToString("000") + ".png"
        img.Save(TargetFolder + "\" + FolderName + "\" + FolderName + "-" + sFileName, Imaging.ImageFormat.Png)

        WriteXML(FolderName + "-" + sFileName, "Right Click", MousePosition.X, MousePosition.Y)

        nCount = nCount + 1
        Timer.Enabled = False
    End Sub

    Private Sub tsmResetSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmResetSize.Click
        FormHelper.MakeTop(SelectedWindow.Handle)
        FormHelper.Resize(SelectedWindow.Handle) '1903136
    End Sub
End Class


Public Class FormHelper
    <DllImport("user32.dll")> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, _
    ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInt32) As Boolean
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
    Public Shared Sub MakeTopMost(ByVal form As Form)
        FormHelper.SetWindowPos(form.Handle, HWND_TOPMOST, 0, 0, 0, 0, 3)
    End Sub
    Public Shared Sub MakeNormal(ByVal hWnd As IntPtr)
        FormHelper.SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, 3)
    End Sub
    Public Shared Sub Resize(ByVal hWnd As IntPtr)
        FormHelper.SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 1000, 645, 0)
    End Sub
End Class

