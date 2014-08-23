Option Explicit On
Module sizeConvertors

    Declare Function GetDC Lib "user32" (ByVal hwnd As Long) As Long
    Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Long, _
      ByVal hdc As Long) As Long
    Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Long, _
      ByVal nIndex As Long) As Long

    Const WU_LOGPIXELSX = 88
    Const WU_LOGPIXELSY = 90

    Function twipsPerPixel(lngDirection As Boolean) As Long
        'Dim lngDC As Long
        'Dim lngPPI As Long
        'Const nTwipsPerInch = 1440
        'lngDC = GetDC(0)
        'If (lngDirection) Then
        ' lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
        ' Else
        ' lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
        ' End If
        ' lngDC = ReleaseDC(0, lngDC)
        ' twipsPerPixel = (1 / nTwipsPerInch) * lngPPI
    End Function

    Function twipsToPixels(lngTwips As Long, lngDirection As Boolean) As Long
        'Dim lngDC As Long
        'Dim lngPixelsPerInch As Long
        'Const nTwipsPerInch = 1440
        'lngDC = GetDC(0)

        'If (lngDirection) Then       'Horizontal
        ' lngPixelsPerInch = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
        ' Else                            'Vertical
        ' lngPixelsPerInch = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
        ' End If
        ' lngDC = ReleaseDC(0, lngDC)
        ' twipsToPixels = (lngTwips / nTwipsPerInch) * lngPixelsPerInch
    End Function

    Function pixelToTwips(lngPixels As Long, lngDirection As Boolean) As Long
        'Dim lngDC As Long
        'Dim lngPPI As Long
        'Const TPI = 1440
        'lngDC = GetDC(0)
        'If (lngDirection) Then
        'lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSX)
        'Else
        'lngPPI = GetDeviceCaps(lngDC, WU_LOGPIXELSY)
        'End If
        'lngDC = ReleaseDC(0, lngDC)
        'pixelToTwips = (lngPixels * TPI) / lngPPI
    End Function
End Module
