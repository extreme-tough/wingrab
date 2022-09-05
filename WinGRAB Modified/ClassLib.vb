'Custom classes are created here
Public Class WindowObject
    'Class to represent a Window
    Public Handle As Integer
    Public Text As String
    Public ClassName As String
    Public Overrides Function ToString() As String
        Return Text.ToString() + "[" + ClassName.ToString + "]"
    End Function
End Class
