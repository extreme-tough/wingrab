Imports System.Xml
Public Class WinGrabSettingsReader


    Public Function ReadSettings() As ArrayList
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
Public Class WinGrabSetting
    'This class acts as a wrapper for for configuration setting in the setting.xml
    Private p_Name As String
    Private p_OutputFolder As String

    Public WindowLeft As Integer = 0
    Public WindowTop As Integer = 0
    Public WindowWidth As Integer = 0
    Public WindowHeight As Integer = 0

    Public CropLeft As Integer = 0
    Public CropTop As Integer = 0
    Public CropWidth As Integer = 0
    Public CropHeight As Integer = 0

    Public Resize As String
    Public Crop As String

    Public Property Name() As String
        Get
            Return p_Name
        End Get
        Set(ByVal value As String)
            'Name in the configuration file cannot be empty
            If value.Trim() = "" Then
                Throw New Exception("Settings cannot have empty names")
            Else
                p_Name = value
            End If

        End Set
    End Property

    Public Sub SetWinSize(ByVal sValue As String)
        Dim arCoord() As String
        'MAX is a predefined entry to indicate the maximized state of winfow. It is a valid entry
        If sValue.ToUpper() = "MAX" Then
            Resize = "MAX"
        Else
            'Size setting should contain 4 parameters seperated by commad
            arCoord = sValue.Split(",")
            If arCoord.Length <> 4 Then
                'If not, throw an error
                Throw New Exception("Invalid Resize paramter in settings.xml")
            Else
                'If there are 4 parameters make sure they all are numeric. If not raise error
                Try
                    WindowLeft = Int32.Parse(arCoord(0))
                    WindowTop = Int32.Parse(arCoord(1))
                    WindowWidth = Int32.Parse(arCoord(2))
                    WindowHeight = Int32.Parse(arCoord(3))
                Catch ex As Exception
                    Throw New Exception("One or more resize value is not valid in settings.xml")
                End Try
            End If
        End If
    End Sub

    Public Sub SetCropSize(ByVal sValue As String)
        Dim arCoord() As String
        'NO is a predefined entry to indicate that no cropping need to be done
        If sValue.ToUpper() = "NO" Then
            Crop = "NO"
        Else
            'Size setting should contain 4 parameters seperated by comma to crop the image
            arCoord = sValue.Split(",")
            If arCoord.Length <> 4 Then
                'If not, throw an error
                Throw New Exception("Invalid crop paramter in settings.xml")
            Else
                'If there are 4 parameters make sure they all are numeric. If not raise error
                Try
                    CropLeft = Int32.Parse(arCoord(0))
                    CropTop = Int32.Parse(arCoord(1))
                    CropWidth = Int32.Parse(arCoord(2))
                    CropHeight = Int32.Parse(arCoord(3))
                Catch ex As Exception
                    Throw New Exception("One or more crop value is not valid in settings.xml")
                End Try
            End If
        End If
    End Sub
    Public Property OutputFolder()
        Get
            Return p_OutputFolder
        End Get
        Set(ByVal value)
            If (value.Contains("%DESKTOP%")) Then
                value = value.Replace("%DESKTOP%", Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory).ToString())
            End If
            p_OutputFolder = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return p_Name
    End Function
End Class