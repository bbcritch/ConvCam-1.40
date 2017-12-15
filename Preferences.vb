Module Preferences

    ''Public PROCINPUTMODE As Integer
    ''Public Const STEPBYSTEP = 1
    ''Public Const TABLEINPUT = 2

    Public INPUTRESPONSE As Boolean

    Public DISPUNITS As Integer
    Public Const ENGLISH = 0
    Public Const METRIC = 1

    Public TRAINING As Boolean = True

    'Public TOOLASSIGNMENT As Integer
    'Public Const AUTO = 0
    'Public Const FIXED = 1

    Public STATIONFILE As String

    Public Sub readPreferences()
        Dim f As New fileManager
        Dim x As New myXmlUtils
        Dim p As String

        p = f.fileRead(gPath.addSlash(gPath.Configs) & "Preferences.txt")

        ''Select Case x.extract(p, "INPUTMODE")
        ''    Case "Conversational"
        ''        PROCINPUTMODE = STEPBYSTEP
        ''    Case "Data Sets"
        ''        PROCINPUTMODE = TABLEINPUT
        ''End Select
        '' This ensures any old preferences will be forced to table input.
        '' PROCINPUTMODE should actually be unnecessary, since it is always table mode, now.
        ''PROCINPUTMODE = TABLEINPUT

        Select Case x.extract(p, "DISPUNITS")
            Case "English"
                DISPUNITS = ENGLISH
            Case "Metric"
                DISPUNITS = METRIC
        End Select


        Select Case x.extract(p, "TRAINING")
            Case "Off"
                TRAINING = False
            Case "On"
                TRAINING = True
        End Select

        Select Case x.extract(p, "RESPONSE")
            Case "On"
                INPUTRESPONSE = True
            Case "Off"
                INPUTRESPONSE = False
        End Select

        STATIONFILE = x.extract(p, "STATIONFILE")
        stateVars.setVar("TOUCHOFFMETHOD", x.extract(p, "TOUCHOFFMETHOD"))

    End Sub
    Public Sub writePreferences()

        Dim f As New fileManager
        Dim x As New myXmlUtils
        Dim t As String

        t = ""

        ''Select Case PROCINPUTMODE
        ''    Case STEPBYSTEP
        ''        t = appendString(t, x.add("Conversational", "INPUTMODE"), vbCrLf)
        ''    Case TABLEINPUT
        ''        t = appendString(t, x.add("Data Sets", "INPUTMODE"), vbCrLf)
        ''End Select

        Select Case DISPUNITS
            Case ENGLISH
                t = appendString(t, x.add("English", "DISPUNITS"), vbCrLf)
            Case METRIC
                t = appendString(t, x.add("Metric", "DISPUNITS"), vbCrLf)
        End Select

        Select Case TRAINING
            Case True
                t = appendString(t, x.add("On", "TRAINING"), vbCrLf)
            Case False
                t = appendString(t, x.add("Off", "TRAINING"), vbCrLf)
        End Select

        Select Case INPUTRESPONSE
            Case True
                t = appendString(t, x.add("On", "RESPONSE"), vbCrLf)
            Case False
                t = appendString(t, x.add("Off", "RESPONSE"), vbCrLf)
        End Select

        t = appendString(t, x.add(STATIONFILE, "STATIONFILE"), vbCrLf)
        t = appendString(t, x.add(stateVars.getVar("TOUCHOFFMETHOD"), "TOUCHOFFMETHOD"), vbCrLf)

        f.fileWrite(gPath.addSlash(gPath.Configs) & "Preferences.txt", t)

    End Sub


End Module
