Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class ICapture

#Region " CLASS METHODS "

    ''' <summary>
    ''' Captures the image of the entire screen (all monitors).
    ''' Returns a bitmap if the function succeeded, 
    ''' otherwise returns nothing/exception.
    ''' </summary>
    <DebuggerHidden()> _
    Public Shared Function FullScreen() As Bitmap
        Return ICapture.ScreenRectangle(SystemInformation.VirtualScreen)
    End Function

    ''' <summary>
    ''' Captures the image of the specified display device.
    ''' Returns a bitmap if the function succeeded, 
    ''' otherwise returns nothing/exception.
    ''' </summary>
    ''' <param name="monitor">A diplay device.</param>
    <DebuggerHidden()> _
    Public Shared Function DisplayMonitor(ByVal monitor As System.Windows.Forms.Screen) As Bitmap
        Dim rect As Rectangle
        Try
            rect = monitor.Bounds
            Return ICapture.ScreenRectangle(rect)
        Catch ex As Exception
            Throw New ArgumentException("Invalid parameter.", "monitor", ex)
        End Try
    End Function

    ''' <summary>
    ''' Captures the image of an active window from the screen. Returns 
    ''' a bitmap if the function succeeded, otherwise returns nothing/exception.
    ''' </summary>
    <DebuggerHidden()> _
    Public Shared Function ActiveWindow() As Bitmap
        Dim hwnd As IntPtr
        Dim wRect As ICapture.Win32.Rect
        'Get the handle of the selected (active) window.
        hwnd = Win32.GetForegroundWindow()
        'Get the window rectangle.
        If hwnd <> IntPtr.Zero Then
            If Win32.GetWindowRect(hwnd, wRect) Then
                Return ICapture.ScreenRectangle(wRect.ToRectangle)
            Else
                'Throw a Win32Exception
                Throw New System.ComponentModel.Win32Exception()
            End If
        Else
            'Throw an exception
            Throw New Exception("Could not find any active window.")
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Captures the image of a window from the screen specified by a handle. 
    ''' Returns a bitmap if the function succeeded, otherwise returns nothing/exception.
    ''' </summary>
    ''' <param name="hwnd">The handle to the window whose 
    ''' image should be captured.</param>
    <DebuggerHidden()> _
    Public Shared Function Window(ByVal hwnd As IntPtr) As Bitmap
        Dim wRect As ICapture.Win32.Rect
        'Get the window rectangle.
        If hwnd <> IntPtr.Zero Then
            If Win32.GetWindowRect(hwnd, wRect) Then
                Return ICapture.ScreenRectangle(wRect.ToRectangle)
            Else
                'Throw a Win32Exception
                Throw New System.ComponentModel.Win32Exception()
            End If
        Else
            'Throw an exception
            Throw New ArgumentException("Invalid window handle.", "hwnd")
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Captures an image of a control. 
    ''' Returns a bitmap if the function succeeded, 
    ''' otherwise returns nothing/exception.
    ''' </summary>
    ''' <param name="p">A point within the control in the screen coordinates.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Control(ByVal p As Point) As Bitmap
        Dim hwnd As IntPtr
        Dim wRect As ICapture.Win32.Rect
        'Get the handle of a window from a point.
        hwnd = Win32.WindowFromPoint(p)
        'Get the window area.
        If hwnd <> IntPtr.Zero Then
            If Win32.GetWindowRect(hwnd, wRect) Then
                Return ICapture.ScreenRectangle(wRect.ToRectangle)
            Else
                'Throw a Win32Exception
                Throw New System.ComponentModel.Win32Exception()
            End If
        Else
            'Throw an exception
            Throw New Exception("Could not find any window at the specified point.")
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Captures an image of a control.
    ''' Returns a bitmap if the function succeeded, 
    ''' otherwise returns nothing/exception.
    ''' </summary>
    ''' <param name="hwnd">The handle of the control.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Control(ByVal hwnd As IntPtr) As Bitmap
        Dim wRect As ICapture.Win32.Rect
        'Get the window area.
        If hwnd <> IntPtr.Zero Then
            If Win32.GetWindowRect(hwnd, wRect) Then
                Return ICapture.ScreenRectangle(wRect.ToRectangle)
            Else
                'Throw a Win32Exception
                Throw New System.ComponentModel.Win32Exception()
            End If
        Else
            'Throw an exception
            Throw New ArgumentException("Invalid control handle.", "hwnd")
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Captures a rectangle image from the screen. 
    ''' Returns a bitmap if the function succeeded, 
    ''' otherwise returns nothing/exception.
    ''' </summary>
    ''' <param name="rect">A rectangle within the screen 
    ''' coordinates whose image should be captured.</param>
    <DebuggerHidden()> _
    Public Shared Function ScreenRectangle(ByVal rect As Rectangle) As Bitmap
        If Not rect.IsEmpty AndAlso rect.Width <> 0 AndAlso rect.Height <> 0 Then
            Dim win32Ex As System.ComponentModel.Win32Exception = Nothing
            'Get the handle device context for the entire screen.
            Dim wHdc As IntPtr = Win32.GetDC(IntPtr.Zero)
            If wHdc = IntPtr.Zero Then
                'Throw a Win32Exception
                Throw New System.ComponentModel.Win32Exception()
            End If
            'Create graphics object from bitmap.
            Dim g As Graphics
            Dim img As New Bitmap(rect.Width, rect.Height)
            img.MakeTransparent()
            g = Graphics.FromImage(img)
            'Get handle device context from the graphics object.
            Dim gHdc As IntPtr = g.GetHdc()
            'Copy the screen to the bitmap.
            If Not Win32.BitBlt(gHdc, 0, 0, rect.Width, rect.Height, _
            wHdc, rect.X, rect.Y, Win32.SRCCOPY Or Win32.CAPTUREBLT) Then
                'Set the Win32Exception
                win32Ex = New System.ComponentModel.Win32Exception()
            End If
            'Release handles to device contexts.
            g.ReleaseHdc(gHdc)
            g.Dispose()
            Win32.ReleaseDC(IntPtr.Zero, wHdc)
            If Not win32Ex Is Nothing Then
                Throw win32Ex
            Else
                Return img
            End If
        Else
            'Throw an exception
            Throw New ArgumentException("Invalid parameter.", "rect")
        End If
        Return Nothing
    End Function

#End Region

#Region " WIN32 "

    ''' <summary>
    ''' Represents win32 Api shared methods, structures, and constants.
    ''' </summary>
    Public Class Win32

#Region " CONSTANTS "

        '============== GDI32 CONSTANTS ===============
        Public Const CAPTUREBLT As Integer = &H40000000
        Public Const BLACKNESS As Integer = &H42
        Public Const DSTINVERT As Integer = &H550009
        Public Const MERGECOPY As Integer = &HC000CA
        Public Const MERGEPAINT As Integer = &HBB0226
        Public Const NOTSRCCOPY As Integer = &H330008
        Public Const NOTSRCERASE As Integer = &H1100A6
        Public Const PATCOPY As Integer = &HF00021
        Public Const PATINVERT As Integer = &H5A0049
        Public Const PATPAINT As Integer = &HFB0A09
        Public Const SRCAND As Integer = &H8800C6
        Public Const SRCCOPY As Integer = &HCC0020
        Public Const SRCERASE As Integer = &H440328
        Public Const SRCINVERT As Integer = &H660046
        Public Const SRCPAINT As Integer = &HEE0086
        Public Const WHITENESS As Integer = &HFF0062

        Public Const HORZRES As Integer = 8
        Public Const VERTRES As Integer = 10
        '===========================================

#End Region

#Region " STRUCTURES "

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure Rect
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer

            ''' <summary>
            ''' Gets a value indicating whether this ICapture.Rect is empty.
            ''' </summary>
            Public ReadOnly Property IsEmpty() As Boolean
                <DebuggerHidden()> _
                Get
                    Return (Me.Right - Me.Left) < 1 Or (Me.Bottom - Me.Top) < 1
                End Get
            End Property

            ''' <summary>
            ''' Converts the ICapture.Rect object to System.Drawing.Rectangle object.
            ''' </summary>
            <DebuggerHidden()> _
            Public Function ToRectangle() As Rectangle
                Return New Rectangle(Me.Left, Me.Top, Me.Right - Me.Left, Me.Bottom - Me.Top)
            End Function

            ''' <summary>
            ''' Inflates this ICapture.Rect by the specified amount.
            ''' </summary>
            ''' <param name="width">The amount to inflate this ICapture.Rect horizontally.</param>
            ''' <param name="height">The amount to inflate this ICapture.Rect vertically.</param>
            <DebuggerHidden()> _
            Public Sub Inflate(ByVal width As Integer, ByVal height As Integer)
                If Not Me.IsEmpty Then
                    Me.Left -= width
                    Me.Right += width
                    Me.Top -= height
                    Me.Bottom += height
                End If
            End Sub

            ''' <summary>
            ''' Copies the values of the specified ICapture.Rect to this ICapture.Rect.
            ''' </summary>
            ''' <param name="rect">An ICapture.Rect to be copied from.</param>
            Public Sub Copy(ByVal rect As ICapture.Win32.Rect)
                Me.Left = rect.Left
                Me.Right = rect.Right
                Me.Top = rect.Top
                Me.Bottom = rect.Bottom
            End Sub
        End Structure

#End Region

#Region " API USER32 METHODS "

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetWindowRect( _
        ByVal hWnd As IntPtr, _
        ByRef lpRect As Rect) As Boolean
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function ReleaseDC( _
        ByVal hWnd As IntPtr, _
        ByVal hdc As IntPtr) As Integer
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function WindowFromPoint( _
        ByVal pt As Point) As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetDC( _
        ByVal hwnd As IntPtr) As IntPtr
        End Function

#End Region

#Region " API GDI32 METHODS "

        <DllImport("gdi32", SetLastError:=True)> _
        Public Shared Function GetDeviceCaps( _
        ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer
        End Function

        <DllImport("gdi32", SetLastError:=True)> _
        Public Shared Function BitBlt( _
        ByVal hdcDest As IntPtr, _
        ByVal nXDest As Integer, _
        ByVal nYDest As Integer, _
        ByVal nWidth As Integer, _
        ByVal nHeight As Integer, _
        ByVal hdcSrc As IntPtr, _
        ByVal nXSrc As Integer, _
        ByVal nYSrc As Integer, _
        ByVal dwRop As UInteger) As Boolean
        End Function

#End Region

    End Class

#End Region

End Class
