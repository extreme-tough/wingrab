Imports System
Imports System.Runtime.InteropServices

Public Class APIWrapper
    Public Const SW_SHOW = 9
    Public Const SWP_NOACTIVATE = &H10
    Public Const SWP_SHOWWINDOW = &H40

    Public Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
    Public Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Long) As Long
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Long, ByVal hWndInsertAfter As Long, ByVal x As Long, ByVal y As Long, ByVal cx As Long, ByVal cy As Long, ByVal wFlags As Long) As Long


End Class
