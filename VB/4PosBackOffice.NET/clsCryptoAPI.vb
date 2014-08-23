Option Strict Off
Option Explicit On
Friend Class clsCryptoAPI

    Private m_blnEnhancedProvider As Boolean
    Private m_blnBlockCipher As Boolean
    Private m_blnUseDefaultPWD As Boolean
    Private m_lngCryptContext As Long
    Private m_strInputData As String
    Private m_abytOutputData() As Byte
    Private m_abytPWord() As Byte

    ' Export keys
    Private Const SIMPLEBLOB As Long = 1
    Private Const PUBLICKEYBLOB As Long = 6
    Private Const PRIVATEKEYBLOB As Long = 7
    Private Const PLAINTEXTKEYBLOB As Long = 8

    ' Algorithm classes
    Private Const ALG_CLASS_ANY As Long = 0
    Private Const ALG_CLASS_SIGNATURE As Long = 8192
    Private Const ALG_CLASS_MSG_ENCRYPT As Long = 16384
    Private Const ALG_CLASS_DATA_ENCRYPT As Long = 24576
    Private Const ALG_CLASS_HASH As Long = 32768

    ' Algorithm types
    Private Const ALG_TYPE_ANY As Long = 0
    Private Const ALG_TYPE_BLOCK As Long = 1536
    Private Const ALG_TYPE_STREAM As Long = 2048

    ' Block cipher IDs
    Private Const ALG_SID_DES As Long = 1
    Private Const ALG_SID_RC2 As Long = 2
    Private Const ALG_SID_3DES As Long = 3
    Private Const ALG_SID_3DES_112 As Long = 9

    ' Stream cipher IDs
    Private Const ALG_SID_RC4 As Long = 1

    ' Hash IDs
    Private Const ALG_SID_MD2 As Long = 1
    Private Const ALG_SID_MD4 As Long = 2
    Private Const ALG_SID_MD5 As Long = 3
    Private Const ALG_SID_SHA As Long = 4
    Private Const ALG_SID_SHA1 As Long = 4
    Private Const HP_HASHVAL As Long = 2

    ' Hash algorithms
    Private Const CALG_MD2 As Long = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD2
    Private Const CALG_MD4 As Long = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD4
    Private Const CALG_MD5 As Long = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_MD5
    Private Const CALG_SHA As Long = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_SHA
    Private Const CALG_SHA1 As Long = ALG_CLASS_HASH Or ALG_TYPE_ANY Or ALG_SID_SHA1

    ' Block ciphers
    Private Const CALG_RC2 As Long = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_RC2
    Private Const CALG_DES As Long = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_DES
    Private Const CALG_3DES As Long = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_3DES
    Private Const CALG_3DES_112 As Long = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_BLOCK Or ALG_SID_3DES_112

    ' Stream cipher
    Private Const CALG_RC4 As Long = ALG_CLASS_DATA_ENCRYPT Or ALG_TYPE_STREAM Or ALG_SID_RC4

    ' CryptSetProvParam
    Private Const PROV_RSA_FULL As Long = 1

    ' used when aquiring the provider
    Private Const CRYPT_VERIFYCONTEXT As Long = &HF0000000
    Private Const CRYPT_NEWKEYSET As Long = &H8&

    ' Microsoft provider data
    Private Const MS_DEFAULT_PROVIDER As String = _
                  "Microsoft Base Cryptographic Provider v1.0"

    Private Const MS_ENHANCED_PROVIDER As String = _
                  "Microsoft Enhanced Cryptographic Provider v1.0"

    ' ---------------------------------------------------------------------------
    ' Error codes
    ' ---------------------------------------------------------------------------
    Private Const ERR_CONTEXTOPEN As Long = 100
    Private Const ERR_LOCKED As Long = 101
    Private Const ERR_NOCONTEXT As Long = 102
    Private Const ERR_KEYNOTVALID As Long = 103

    ' ---------------------------------------------------------------------------
    ' Numbers defined by GetLastError
    ' ---------------------------------------------------------------------------
    Private Const ERROR_BUSY As Long = 170
    Private Const ERROR_INVALID_PARAMETER As Long = 87
    Private Const ERROR_NOT_ENOUGH_MEMORY As Long = 8
    Private Const ERROR_MORE_DATA As Long = 234
    Private Const NTE_BAD_DATA As Long = &H80090005

    ' ---------------------------------------------------------------------------
    ' Error messages
    ' ---------------------------------------------------------------------------
    Private Const ERROR_AQUIRING_CONTEXT As String = "Could not acquire context"
    Private Const ERROR_CREATING_HASH As String = "Could not create hash"
    Private Const ERROR_CREATING_HASH_DATA As String = "Could not create hash data"
    Private Const ERROR_DERIVING_KEY As String = "Could not derive key"
    Private Const ERROR_ENCRYPTING_DATA As String = "Could not encrypt data"
    Private Const ERROR_DECRYPTING_DATA As String = "Could not decrypt data"
    Private Const ERROR_INVALID_HEX_STRING As String = "Not a valid hex string"
    Private Const ERROR_MISSING_PARAMETER As String = "Both a string and a key are required"
    Private Const ERROR_BAD_ENCRYPTION_TYPE As String = "Invalid encryption type specified"

    ' ---------------------------------------------------------------------------
    ' Declares
    ' ---------------------------------------------------------------------------
    ' CopyMemory moves the contents of a portion of memory from one location
    ' to another. The two locations are identified by pointers to the memory
    ' addresses. After the copy, the original contents in the source are set
    ' to zeros.
    '
    ' Useful whenever you want to move a block of bytes between two memory
    ' locations.  When the source or the destination is an array of numbers
    ' (or of UDTs that contains only numeric and fixed-length strings), you
    ' must pass the first element of the array by reference.  Example below
    ' depicts zero based arrays.
    '
    ' Copy the first 1000 elements of array a() to b().  Both arrays must be
    ' of the same type, and cannot be objects or variable-length strings.
    '
    '    CopyMemory b(0), a(0), 1000 * Len(a(0))
    '
    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
            (dest As Byte, source As Byte, ByVal bytes As Long)

    ' The GetTickCount() API will capture the time in milliseconds.  The
    ' counter overflows after 1192.8 hours (49.7 days) from the last reboot.
    Private Declare Function GetTickCount Lib "kernel32" () As Long

    ' The GetLastError function returns the calling thread's last-error
    ' code value.  Most Win32 functions set their calling thread's
    ' last-error value when they fail; a few functions set it when they
    ' succeed.  You should call the GetLastError function immediately when
    ' a function's return value indicates that such a call will return
    ' useful data. That is because some functions call SetLastError(0) when
    ' they succeed, wiping out the error code set by the most recently
    ' failed function.
    Private Declare Function GetLastError Lib "kernel32" () As Long

    ' The CryptHashData function adds data to a specified hash object.
    ' This function and CryptHashSessionKey can be called multiple
    ' times to compute the hash of long or discontinuous data streams.
    Private Declare Function CryptHashData Lib "advapi32.dll" _
            (ByVal hhash As Long, ByVal pbData As String, _
            ByVal dwDataLen As Long, ByVal dwFlags As Long) As Long

    ' Alias of CryptHashData
    Private Declare Function CryptHashDataString Lib "advapi32.dll" _
            Alias "CryptHashData" (ByVal hhash As Long, _
            ByVal bData As String, ByVal dwDataLen As Long, _
            ByVal dwFlags As Long) As Long

    ' Alias of CryptHashData
    Private Declare Function CryptHashDataBytes Lib "advapi32.dll" _
            Alias "CryptHashData" (ByVal hhash As Long, _
            bData As Byte, ByVal dwDataLen As Long, _
            ByVal dwFlags As Long) As Long

    ' The CryptCreateHash function initiates the hashing of a stream of
    ' data. It creates and returns to the calling application a handle
    ' to a CSP hash object. This handle is used in subsequent calls to
    ' CryptHashData and CryptHashSessionKey to hash session keys and
    ' other streams of data.
    Private Declare Function CryptCreateHash Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal algid As Long, _
            ByVal hkey As Long, ByVal dwFlags As Long, _
            ByRef phHash As Long) As Long

    ' The CryptSignHash function signs data. Because all signature
    ' algorithms are asymmetric and thus slow, the CryptoAPI does not
    ' allow data be signed directly. Instead, data is first hashed and
    ' CryptSignHash is used to sign the hash.
    Private Declare Function CryptSignHash Lib "advapi32.dll" _
            Alias "CryptSignHashA" (ByVal hhash As Long, _
            ByVal hkey As Long, ByVal Description As Long, _
            ByVal dwFlags As Long, ByVal pData As Long, _
            dwDataLength As Long) As Long

    ' The CryptVerifySignature function verifies the signature of a
    ' hash object.  Before calling this function, CryptCreateHash must be
    ' called to create the handle of a hash object. CryptHashData or
    ' CryptHashSessionKey is then used to add data or session keys to the
    ' hash object.
    Private Declare Function CryptVerifySignature Lib "advapi32.dll" _
            Alias "CryptVerifySignatureA" (ByVal hhash As Long, _
            ByVal pData As Long, ByVal datalength As Long, _
            ByVal PublicKey As Long, ByVal Description As Long, _
            ByVal dwFlags As Long) As Long

    ' The CryptGetHashParam function retrieves data that governs the
    ' operations of a hash object. The actual hash value can be
    ' retrieved by using this function.
    Private Declare Function CryptGetHashParam Lib "advapi32.dll" _
            (ByVal hhash As Long, ByVal dwParam As Long, ByVal pbData As String, _
            pdwDataLen As Long, ByVal dwFlags As Long) As Long

    ' Alias of CryptGetHashParam
    Private Declare Function CryptGetHashParamSize Lib "advapi32.dll" _
            Alias "CryptGetHashParam" (ByVal hhash As Long, _
            ByVal dwParam As Long, pbData As Long, _
            dwDataLength As Long, ByVal dwFlags As Long) As Long

    'The CryptDestroyHash function destroys the hash object referenced
    ' by the hHash parameter. After a hash object has been destroyed,
    ' it can no longer be used.  The destruction of hash objects after
    ' their use is finished is recommended for security reasons.
    Private Declare Function CryptDestroyHash Lib "advapi32.dll" _
            (ByVal hhash As Long) As Long

    ' The CryptAcquireContext function is used to acquire a handle to a
    ' particular key container within a particular cryptographic service
    ' provider (CSP). This returned handle can then be used to make
    ' calls to the selected CSP.  This function performs two operations.
    ' It first attempts to find a CSP with the characteristics described
    ' in the dwProvType and pszProvider parameters. If the CSP is found,
    ' the function attempts to find a key container within the CSP
    ' matching the name specified by the pszContainer parameter.  With the
    ' appropriate setting of dwFlags, this function can also create and
    ' destroy key containers.
    Private Declare Function CryptAcquireContext Lib "advapi32.dll" _
            Alias "CryptAcquireContextA" (ByRef phProv As Long, _
            ByVal pszContainer As String, ByVal pszProvider As String, _
            ByVal dwProvType As Long, ByVal dwFlags As Long) As Long

    ' The CryptReleaseContext function releases the handle of a
    ' cryptographic service provider (CSP) and a key container. At each
    ' call to this function, the reference count on the CSP is reduced
    ' by one. When the reference count reaches zero, the context is fully
    ' released and it can no longer be used by any function in the application.
    ' An application calls this function after finishing the use of the CSP.
    ' After this function is called, the released CSP handle is no longer
    ' valid. This function does not destroy key containers or key pairs.
    Private Declare Function CryptReleaseContext Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal dwFlags As Long) As Long

    ' The data produced by this function is cryptographically random.  The
    ' data is far more random than the data generated by the typical random
    ' number generator such as the one shipped with your C or VB compiler.
    Private Declare Function CryptGenRandom Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal dwLen As Long, _
            ByVal pbBuffer As String) As Long

    ' The CryptGetUserKey function retrieves a handle of one of a user's two
    ' public/private key pairs. This function is used only by the owner of
    ' the public/private key pairs and only when the handle of a cryptographic
    ' service provider (CSP) and its associated key container is available.
    Private Declare Function CryptGetUserKey Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal dwKeySpec As Long, _
            phUserKey As Long) As Long

    ' The CryptGenKey function generates a random cryptographic session key or
    ' a public/private key pair. A handle to the key or key pair is returned
    ' in phKey. This handle can then be used as needed with any CryptoAPI
    ' function requiring a key handle.  The calling application must specify
    ' the algorithm when calling this function. Because this algorithm type is
    ' kept bundled with the key, the application does not need to specify the
    ' algorithm later when the actual cryptographic operations are performed.
    Private Declare Function CryptGenKey Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal algid As Long, _
            ByVal dwFlags As Long, phKey As Long) As Long

    ' The CryptDeriveKey function generates cryptographic session keys derived
    ' from a base data value. This function guarantees that when the same CSP
    ' and algorithms are used, the keys generated from the same base data are
    ' identical. The base data can be a password or any other user data.  This
    ' function is the same as CryptGenKey, except that the generated session
    ' keys are derived from base data instead of being random. CryptDeriveKey
    ' can only be used to generate session keys. It cannot generate
    ' public/private key pairs.
    Private Declare Function CryptDeriveKey Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal algid As Long, _
            ByVal hBaseData As Long, ByVal dwFlags As Long, _
            ByRef phKey As Long) As Long

    ' The CryptDestroyKey function releases the handle referenced by the hKey
    ' parameter. After a key handle has been released, it becomes invalid and
    ' cannot be used again.
    Private Declare Function CryptDestroyKey Lib "advapi32.dll" _
            (ByVal hkey As Long) As Long

    ' The CryptGetKeyParam function retrieves data that governs the operations
    ' of a key. If the Microsoft Cryptographic Service Provider is used, the
    ' base symmetric keying material is not obtainable by this function or any
    ' other function.
    Private Declare Function CryptGetKeyParam Lib "advapi32.dll" _
            (ByVal hkey As Long, ByVal dwParam As Long, _
            ByVal pbData As Long, pdwDataLen As Long, _
            ByVal dwFlags As Long) As Long

    ' The CryptSetKeyParam function customizes various aspects of a session
    ' key's operations. The values set by this function are not persisted
    ' to memory and can only be used with in a single session.
    Private Declare Function CryptSetKeyParam Lib "advapi32.dll" _
            (ByVal hkey As Long, ByVal dwParam As Long, _
            ByVal pbData As Long, ByVal dwFlags As Long) As Long

    ' The CryptExportKey function exports a cryptographic key or a key pair
    ' from a cryptographic service provider (CSP) in a secure manner.
    Private Declare Function CryptExportKey Lib "advapi32.dll" _
            (ByVal hkey As Long, ByVal hExpKey As Long, _
            ByVal dwBlobType As Long, ByVal dwFlags As Long, _
            ByVal pbData As Long, pdwDataLen As Long) As Long

    ' The CryptImportKey function transfers a cryptographic key from a key
    ' BLOB into a cryptographic service provider (CSP).This function can be
    ' used to import an Schannel session key, regular session key, public
    ' key, or public/private key pair. For all but the public key, the key
    ' or key pair is encrypted.
    Private Declare Function CryptImportKey Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal pbData As Long, _
            ByVal dwDataLength As Long, ByVal hPubKey As Long, _
            ByVal dwFlags As Long, pKeyval As Long) As Long

    ' The CryptEncrypt function encrypts data. The algorithm used to encrypt
    ' the data is designated by the key held by the CSP module and is
    ' referenced by the hKey parameter.
    Private Declare Function CryptEncrypt Lib "advapi32.dll" _
            (ByVal hkey As Long, ByVal hhash As Long, ByVal Final As Long, _
            ByVal dwFlags As Long, ByVal pbData As String, _
            ByRef pdwDataLen As Long, ByVal dwBufLen As Long) As Long

    ' The CryptDecrypt function decrypts data previously encrypted using
    ' CryptEncrypt function.
    Private Declare Function CryptDecrypt Lib "advapi32.dll" _
            (ByVal hkey As Long, ByVal hhash As Long, _
            ByVal Final As Long, ByVal dwFlags As Long, _
            ByVal pbData As String, ByRef pdwDataLen As Long) As Long

    ' The CryptGetProvParam function retrieves parameters that govern the
    ' operations of a cryptographic service provider (CSP).
    Private Declare Function CryptGetProvParam Lib "advapi32.dll" _
            (ByVal hProv As Long, ByVal dwParam As Long, _
            pbData As String, pdwDataLen As Long, _
            ByVal dwFlags As Long) As Long

    ' Alias of CryptGetProvParam
    Private Declare Function CryptGetProvParamString Lib "advapi32.dll" _
            Alias "CryptGetProvParam" (ByVal hProv As Long, _
            ByVal dwParam As Long, ByVal pbData As String, _
            pdwDataLen As Long, ByVal dwFlags As Long) As Long


    ' ***************************************************************************
    '                        Property area
    ' ***************************************************************************

    Public WriteOnly Property InputData() As Byte
        Set(value As Byte)
            m_strInputData = value
        End Set
    End Property

    Public ReadOnly Property OutputData As Byte()
        Get
            OutputData = m_abytOutputData
        End Get
    End Property

    Public Property EnhancedProvider As Boolean
        Get
            EnhancedProvider = m_blnEnhancedProvider
        End Get
        Set(value As Boolean)
            m_blnEnhancedProvider = value
        End Set
    End Property

    Public Property PassWord As Byte()
        Set(value As Byte())
            ReDim m_abytPWord(Byte.MinValue)
            If UBound(value) > 0 Then
                m_abytPWord = value
            Else
                If m_blnUseDefaultPWD Then
                    m_abytPWord = GetPassWord(True)
                End If
            End If
        End Set
        Get
            PassWord = m_abytPWord
        End Get
    End Property

    Public WriteOnly Property UseDefaultPWD As Boolean
        Set(value As Boolean)
            m_blnUseDefaultPWD = value
        End Set
    End Property

    ' ***************************************************************************
    '                    Functions and Procedures
    ' ***************************************************************************
    Public Function ByteArrayToString(arByte() As Byte) As String

        ' ---------------------------------------------------------------------------
        ' Define variables
        ' ---------------------------------------------------------------------------
        Dim lngLoop As Long
        Dim lngMax As Long
        Dim lngLength As Long
        Dim lngPaddingLen As Long
        Dim lngIndexPointer As Long
        Dim strTemp As String
        Dim strOutput As String

        Const ADD_SPACES As Long = 10000

        ' ---------------------------------------------------------------------------
        ' Determine amount of data in the byte array.
        ' ---------------------------------------------------------------------------
        strTemp = ""
        lngIndexPointer = 1                 ' index pointer for output string
        lngMax = UBound(arByte)             ' determine number of elements in array
        lngPaddingLen = (ADD_SPACES * 9)    ' 90000 blank spaces
        strOutput = Space$(lngPaddingLen)   ' preload output string

        ' ---------------------------------------------------------------------------
        ' Unload the byte array and convert each character back to its ASCII
        ' character value
        ' ---------------------------------------------------------------------------
        For lngLoop = 0 To lngMax - 1

            strTemp = Chr(arByte(lngLoop))  ' Convert each byte to an ASCII character
            lngLength = Len(strTemp)         ' save the length of the converted data

            ' see if some more padding has to be added to the output string
            If (lngIndexPointer + lngLength) >= lngPaddingLen Then
                lngPaddingLen = lngPaddingLen + ADD_SPACES ' boost blank space counter
                strOutput = strOutput & Space$(ADD_SPACES) ' append some blank spaces
            End If

            ' insert data into output string
            Mid$(strOutput, lngIndexPointer, lngLength) = strTemp

            ' increment output string pointer
            lngIndexPointer = lngIndexPointer + lngLength

        Next

        ' ---------------------------------------------------------------------------
        ' Return the string data
        ' ---------------------------------------------------------------------------
        strOutput = RTrim$(strOutput)  ' remove trailing blanks
        ByteArrayToString = strOutput  ' return data string

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)

    End Function

    Public Function ConvertByteToHex(ByRef abytData() As Byte) As String

        ' ---------------------------------------------------------------------------
        ' Define variables
        ' ---------------------------------------------------------------------------
        Dim strOutput As String
        Dim intTemp As Integer
        Dim lngLoop As Long
        Dim lngMax As Long
        Dim lngIndexPointer As Long
        Dim lngPaddingLen As Long

        Const ADD_SPACES As Long = 10000

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        lngIndexPointer = 1                 ' start in first position of output string
        lngMax = UBound(abytData)           ' number of elements in array
        lngPaddingLen = (ADD_SPACES * 9)    ' 90,000 blank spaces
        strOutput = Space(lngPaddingLen)   ' preload output string with blank spaces

        ' ---------------------------------------------------------------------------
        ' First, verify byte array has data in it.
        ' ---------------------------------------------------------------------------
        If lngMax > 0 Then

            ' Loop thru and convert the data
            For lngLoop = 0 To lngMax - 1

                ' see if some more padding has to be added to the output string
                If ((lngLoop * 2) + 2) >= lngPaddingLen Then
                    lngPaddingLen = lngPaddingLen + ADD_SPACES ' boost blank space counter
                    strOutput = strOutput & Space$(ADD_SPACES) ' append some blank spaces
                End If

                intTemp = CInt(abytData(lngLoop))              ' capture one byte

                ' replace 2 blank spaces with a hex value
                Mid(strOutput, lngIndexPointer, 2) = Right("00" & Hex(intTemp), 2)

                lngIndexPointer = lngIndexPointer + 2   ' increment position pointer
            Next

            strOutput = RTrim(strOutput)               ' remove trailing blanks
        Else
            strOutput = ""
        End If

        ' ---------------------------------------------------------------------------
        ' Return results
        ' ---------------------------------------------------------------------------
        ConvertByteToHex = strOutput

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)

    End Function

    Public Function ConvertStringFromHex(ByVal strHex As String) As String

        ' ---------------------------------------------------------------------------
        ' Define variables
        ' ---------------------------------------------------------------------------
        Dim lngMax As Long
        Dim lngLoop As Long
        Dim lngLength As Long
        Dim lngPaddingLen As Long
        Dim lngIndexPointer As Long
        Dim strTemp As String
        Dim strOutput As String

        Const ADD_SPACES As Long = 10000

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        strTemp = ""
        lngIndexPointer = 1                 ' index pointer for output string
        lngMax = Len(strHex)                ' length of input hex string
        lngPaddingLen = (ADD_SPACES * 9)    ' 90000 blank spaces
        strOutput = Space(lngPaddingLen)   ' preload output string

        ' ---------------------------------------------------------------------------
        ' See if the hex data string can be divided evenly by two.  If not, then the
        ' data is corrupted.
        ' ---------------------------------------------------------------------------
        If lngMax Mod 2 <> 0 Then
            'MsgBox "Data string is corrupted.  Cannot be Decrypted.", _
            '       vbCritical Or vbOKOnly, "Data corrupted"
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        For lngLoop = 1 To lngMax Step 2

            strTemp = Chr(Val("&H" & Mid(strHex, lngLoop, 2)))
            lngLength = Len(strTemp)        ' save the length of the converted data

            ' see if some more padding has to be added to the output string
            If (lngIndexPointer + lngLength) >= lngPaddingLen Then
                lngPaddingLen = lngPaddingLen + ADD_SPACES  ' boost blank space counter
                strOutput = strOutput & Space$(ADD_SPACES)  ' append some blank spaces
            End If

            ' insert data into output string
            Mid$(strOutput, lngIndexPointer, lngLength) = strTemp

            ' increment output string pointer
            lngIndexPointer = lngIndexPointer + lngLength

        Next

        ' ---------------------------------------------------------------------------
        ' Return the formatted data
        ' ---------------------------------------------------------------------------
        strOutput = RTrim(strOutput)     ' remove trailing blanks
        ConvertStringFromHex = strOutput  ' return data string

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)

    End Function

    Public Function ConvertStringToHex(ByVal strInput As String, _
                           Optional blnRetUppercase As Boolean = True) As String

        ' ---------------------------------------------------------------------------
        ' Define variables
        ' ---------------------------------------------------------------------------
        Dim lngMax As Long
        Dim lngLoop As Long
        Dim lngLength As Long
        Dim lngPaddingLen As Long
        Dim lngIndexPointer As Long
        Dim strTemp As String
        Dim strOutput As String

        Const ADD_SPACES As Long = 10000

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        strTemp = ""
        lngIndexPointer = 1                 ' index pointer for output string
        lngMax = Len(strInput)              ' length of input data string
        lngPaddingLen = (ADD_SPACES * 9)    ' 90000 blank spaces
        strOutput = Space(lngPaddingLen)   ' preload output string

        ' ---------------------------------------------------------------------------
        ' Convert to hex
        ' ---------------------------------------------------------------------------
        For lngLoop = 1 To lngMax

            strTemp = Right("00" & Hex(Asc(Mid(strInput, lngLoop, 1))), 2)
            lngLength = Len(strTemp)        ' save the length of the converted data

            ' see if some more padding has to be added to the output string
            If (lngIndexPointer + lngLength) >= lngPaddingLen Then
                lngPaddingLen = lngPaddingLen + ADD_SPACES  ' boost blank space counter
                strOutput = strOutput & Space(ADD_SPACES)  ' append some blank spaces
            End If

            ' insert data into output string
            Mid(strOutput, lngIndexPointer, lngLength) = strTemp

            ' increment output string pointer
            lngIndexPointer = lngIndexPointer + lngLength
        Next

        ' ---------------------------------------------------------------------------
        ' remove trailing blanks
        ' ---------------------------------------------------------------------------
        strOutput = RTrim(strOutput) ' remove trailing blanks

        ' ---------------------------------------------------------------------------
        ' Return hex string
        ' ---------------------------------------------------------------------------
        If blnRetUppercase Then
            ConvertStringToHex = StrConv(strOutput, vbUpperCase)
        Else
            ConvertStringToHex = strOutput
        End If

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)

    End Function

    Public Function CreateHash(Optional ByVal strInText As String = "", _
                    Optional ByVal intHashChoice As Integer = 1, _
                    Optional ByVal blnConvertToHex As Boolean = True, _
                    Optional ByVal blnAppendPassword As Boolean = False, _
                    Optional ByVal blnCaseSensitive As Boolean = False) As String

        ' ***************************************************************************
        ' Routine:       CreateHash
        '
        ' Description:   Generate a one-way hash string from a string of data. There
        '                are 4 algorithms available in this version:
        '                 1=MD5  2=MD4  3=MD2  4=SHA-1
        '
        '                Hashes are extremely useful for determining whether a
        '                transmission or file has been altered.  The MDn returns a
        '                16 character hash and the SHA-1 returns a 20 character hash.
        '                No two hashes are alike unless the string matches perfectly,
        '                whether binary data or a text string.  I use hashes to
        '                create crypto keys and to verify integrity of packets when
        '                using winsock (UDP especially). Be aware that if you choose
        '                to not convert the return data to hex, then hashes may not
        '                store to text correctly because of the possible existence of
        '                non printable characters in the stream.
        '
        ' Parameters:    strInText - string of data to be hashed.
        '                intHashChoice - (Optional) Numeric identifier for the type
        '                     of hash algorithm.  [Default] value = 1 (MD5)
        '                blnConvertToHex - (Optional) [Default] TRUE=Convert return
        '                     data to Hex format.
        '                     FALSE=Do not convert the return data
        '                blnAppendPassword - (Optional) [Default] FALSE=Do not append
        '                     the password to the data to be hashed.
        '                     True - Append the default password to data to be hashed.
        '                blnCaseSensitive - (Optional) Only used if blnConvertToHex=TRUE
        '                     [Default] FALSE=Convert return data to uppercase.
        '                     TRUE=Return data as it was created.
        '
        ' Returns:       ASCII string of characters

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim lngHashType As Long
        Dim lngHashHwd As Long
        Dim lngRetCode As Long
        Dim lngIndex As Long
        Dim lngOutputLength As Long
        Dim strOutput As String
        Dim strTempHash As String
        Dim strPassword As String
        Dim abytPWord() As Byte

        ' ---------------------------------------------------------------------------
        ' Aquire the provider handle
        ' ---------------------------------------------------------------------------
        If m_lngCryptContext = 0 Then
            If Not GetProvider Then
                Call Terminate()       ' Failed.  Time to leave.
                Exit Function
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' Append password to data to be hashed
        ' ---------------------------------------------------------------------------
        If blnAppendPassword Then
            ' see if we are holding a password
            If UBound(m_abytPWord) > 0 Then
                strPassword = ByteArrayToString(m_abytPWord) ' convert password to string
            Else
                ' safety net in case the array is empty
                abytPWord = GetPassword(m_blnUseDefaultPWD)    ' create a random password
                strPassword = ByteArrayToString(abytPWord)   ' convert password to string
                Erase abytPWord                              ' empty array
                ReDim abytPWord(0)                             ' resize to smallest size
            End If

            strInText = strInText & strPassword                ' append password
        End If

        ' ---------------------------------------------------------------------------
        ' Determine type of hash algorithm to use
        ' ---------------------------------------------------------------------------
        lngHashType = GetHashType(intHashChoice, lngOutputLength)

        ' ---------------------------------------------------------------------------
        ' The CryptCreateHash function initiates the hashing of a stream of data. It
        ' creates and returns to the calling application a handle to a CSP hash
        ' object. This handle is used in subsequent calls to CryptHashData to hash
        ' session keys and other streams of data.
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptCreateHash(m_lngCryptContext, lngHashType, 0&, _
                     0&, lngHashHwd)) Then
            CreateHash = ""
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' The CryptHashData function adds data to a specified hash object. This
        ' function can be called multiple times to compute the hash of long or
        ' discontinuous data streams.
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptHashData(lngHashHwd, strInText, Len(strInText), 0&)) Then
            CreateHash = ""
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Initialize variables.  Do not use String$() to create your spaces.  Some
        ' API functions read each character as a single entity versus Space$() as
        ' a whole entity.  I do not recommend using NULL values.  Some API functions
        ' look at this as a null terminated string buffer and not a preloaded buffer.
        ' ---------------------------------------------------------------------------
        strTempHash = Space$(lngOutputLength)

        ' ---------------------------------------------------------------------------
        ' The CryptGetHashParam function retrieves data that governs the operations
        ' of a hash object. The actual hash value can be retrieved by using this
        ' function.
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptGetHashParam(lngHashHwd, HP_HASHVAL, _
                     strTempHash, lngOutputLength, 0&)) Then
            CreateHash = ""
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' See if we are to return the data in Hex or Binary format
        ' ---------------------------------------------------------------------------
        If blnConvertToHex Then
            ' convert to hex format
            If blnCaseSensitive Then
                strOutput = ConvertStringToHex(strTempHash, False) ' leave as is
            Else
                strOutput = ConvertStringToHex(strTempHash, True)  ' Uppercase [Default]
            End If
        Else
            ' Return the raw data in binary format
            strOutput = strTempHash
        End If

        ' ---------------------------------------------------------------------------
        ' Return hash data
        ' ---------------------------------------------------------------------------
        CreateHash = RTrim(strOutput)

        ' ---------------------------------------------------------------------------
        ' Destroy hash object
        ' ---------------------------------------------------------------------------
        If lngHashHwd <> 0 Then
            lngRetCode = CryptDestroyHash(lngHashHwd)
        End If

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)
        strPassword = StrDup(250, 0)
        strTempHash = StrDup(250, 0)

    End Function
    Public Function CreateRandom(Optional lngDataLength As Long = 40, _
                      Optional blnRetExactLength As Boolean = True, _
                      Optional blnConvertToHex As Boolean = False) As String

        ' ***************************************************************************
        ' Routine:       CreateRandom
        '
        ' Description:   Get truly cryptographic strength random data.  Tested with
        '                DieHard and ENT tests for randomness.
        '
        ' Parameters:    lngDataLength - (Optional) Length of data to be returned
        '                                [Default] data length is 40 bytes
        '                blnRetExactLength - (Optional) [Default] TRUE=Return just
        '                      the length requested.
        '                      FALSE=Return all generated data regardless of length.
        '                blnConvertToHex - (Optional) [Default] FALSE=Do not convert
        '                      the return data to hex format.
        '                      TRUE=Convert return data to hex format.
        '
        ' Returns:       A string of random data

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim strOutput As String
        Dim strRndBuffer As String

        ' ---------------------------------------------------------------------------
        ' Initialize variables.
        ' ---------------------------------------------------------------------------
        strRndBuffer = ""
        strOutput = ""

        ' ---------------------------------------------------------------------------
        ' Aquire the provider handle
        ' ---------------------------------------------------------------------------
        If m_lngCryptContext = 0 Then
            If Not GetProvider Then
                Call Terminate()       ' Failed.  Time to leave.
                Exit Function
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' The strRndBuffer must be at least the length of Data Length requested.
        ' This buffer is also where we can add additional seed values.  Build the
        ' additional seed values for the random generator.
        ' ---------------------------------------------------------------------------
        strRndBuffer = CStr(GetTickCount() + CDbl(Now.ToOADate)) ' System time (2 ways)
        strRndBuffer = strRndBuffer & CreateSaltValue(40)  ' append 40 random chars
        strRndBuffer = CreateHash(strRndBuffer, 4, False)  ' hash using SHA-1

        ' ---------------------------------------------------------------------------
        ' Now we have an additional seed for the random number generator.  Be sure to
        ' append additional space for the return data.  Excess will be removed.
        ' ---------------------------------------------------------------------------
        strRndBuffer = strRndBuffer & Space(lngDataLength)

        ' ---------------------------------------------------------------------------
        ' Create the random data
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptGenRandom(m_lngCryptContext, lngDataLength, strRndBuffer)) Then
            CreateRandom = ""
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Remove any trailing blank spaces
        ' ---------------------------------------------------------------------------
        strRndBuffer = RTrim(strRndBuffer)

        ' ---------------------------------------------------------------------------
        ' Return the random data string
        ' ---------------------------------------------------------------------------
        If blnConvertToHex Then
            ' convert data string to hex
            strOutput = ConvertStringToHex(strRndBuffer, True)  'Uppercase [Default]
        Else
            ' do not convert to hex prior to returning the data string
            strOutput = strRndBuffer
        End If

        ' ---------------------------------------------------------------------------
        ' Return data
        ' ---------------------------------------------------------------------------
        If blnRetExactLength Then
            CreateRandom = Left(strOutput, lngDataLength)
        Else
            CreateRandom = RTrim(strOutput)
        End If

        ' ---------------------------------------------------------------------------
        ' empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)
        strRndBuffer = StrDup(250, 0)

    End Function

    Public Function CreateSaltValue(Optional lngReturnLength As Long = 20, _
             Optional blnUseLettersNumbersOnly As Boolean = True) As Object

        ' ***************************************************************************
        ' Routine:       CreateSaltValue
        '
        ' Description:   Generate random data to be used a salt value.  This will
        '                return values 0-9, A-Z, and a-z or truely random data.
        '
        ' Parameters:    lngReturnLength - Length of data to be returned
        '                blnUseLettersNumbersOnly - (Optional) [Default] TRUE=Use
        '                     letters and numbers only.
        '                     FALSE=Use truely random data
        '
        ' Returns:       A string of random data

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim intChar As Integer
        Dim lngIndex As Long
        Dim strOutput As String

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        strOutput = ""

        ' ---------------------------------------------------------------------------
        ' Create salt value string using 0-9, A-Z, a-z only
        ' ---------------------------------------------------------------------------
        If blnUseLettersNumbersOnly Then

            For lngIndex = 1 To lngReturnLength

                intChar = Int(Rnd2(48.0!, 122.0!))

                Select Case intChar
                    Case 58 To 64, 91 To 96
                        intChar = intChar + 9   ' add 9 to unwanted values
                End Select

                strOutput = strOutput & Chr(intChar)
            Next
        Else
            strOutput = CreateRandom(lngReturnLength, True)
        End If

        ' ---------------------------------------------------------------------------
        ' Return the new Salt value
        ' ---------------------------------------------------------------------------
        CreateSaltValue = strOutput

        ' ---------------------------------------------------------------------------
        ' empty variables
        ' ---------------------------------------------------------------------------
        strOutput = StrDup(250, 0)

    End Function

    Public Function Decrypt(Optional intHashType As Integer = 1, _
                            Optional intCipherType As Integer = 1) As Boolean

        ' ***************************************************************************
        ' Routine:       Decrypt
        '
        ' Description:   Call the decyption routine.
        '
        ' Parameters:    intHashType - (Optional) [Default] 1=Use MD5 hash algorithm
        '                    Selection:   1=MD5  2=MD4  3=MD2  4=SHA-1
        '                intCipherType - (Optional) [Default] 1=Use RC4 algorithm
        '                    Selection:  (Default Provider)   1=RC4  2=RC2  3=DES
        '                                (Enhanced Provider)  4=3DES 5=3DES_112
        '
        ' Returns:       TRUE/FALSE based on completion.

        ' ---------------------------------------------------------------------------
        ' Decrypt the data
        ' ---------------------------------------------------------------------------
        Decrypt = CryptoDecrypt(intHashType, intCipherType)

    End Function

    Private Function CryptoDecrypt(intHashType As Integer, _
                                   intCipherType As Integer) As Boolean

        ' ***************************************************************************
        ' Routine:       CryptoDecrypt
        '
        ' Description:   Perform the actual decryption of a string of data or a file.
        '
        ' Returns:       TRUE/FALSE based on completion

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim lngHashHwd As Long     ' Hash handle
        Dim lngHkey As Long
        Dim lngRetCode As Long     ' return value from an API call
        Dim lngHashType As Long
        Dim lngLength As Long
        Dim lngCipherType As Long
        Dim lngHExchgKey As Long
        Dim lngCryptLength As Long
        Dim lngCryptBufLen As Long
        Dim strCryptBuffer As String
        Dim strOutputData As String
        Dim strPassword As String

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        CryptoDecrypt = False        ' preset to FALSE
        Erase m_abytOutputData
        ReDim m_abytOutputData(0)
        strOutputData = ""
        strCryptBuffer = ""
        strPassword = ""

        ' ---------------------------------------------------------------------------
        ' If bad hash or cipher selection then leave
        ' ---------------------------------------------------------------------------
        lngHashType = GetHashType(intHashType, lngLength)
        If lngHashType = 0 Then
            MsgBox("This hash selection is not supported.", _
                   vbExclamation Or vbOKOnly, "Wrong Decrypt Hash Selection")
            Call Terminate()       ' Failed.  Time to leave.
            Exit Function
        End If

        lngCipherType = GetCipherType(intCipherType)
        If lngCipherType = 0 Then
            Call Terminate()       ' Failed.  Time to leave.
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Aquire the provider handle
        ' ---------------------------------------------------------------------------
        If m_lngCryptContext = 0 Then
            If Not GetProvider Then
                Call Terminate()       ' Failed.  Time to leave.
                Exit Function
            End If
        End If

        On Error GoTo CryptoDecrypt_Error
        ' ---------------------------------------------------------------------------
        ' convert password to string
        ' ---------------------------------------------------------------------------
        If UBound(m_abytPWord) > 0 Then
            strPassword = ByteArrayToString(m_abytPWord)
        Else
            If m_blnUseDefaultPWD Then
                m_abytPWord = GetPassword(True)       ' Use the default password
                strPassword = ByteArrayToString(m_abytPWord)
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' Create a hash object
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptCreateHash(m_lngCryptContext, lngHashType, 0&, _
                     0&, lngHashHwd)) Then

            MsgBox("Error: " & CStr(GetLastError) & " during CryptCreateHash!", _
                   vbExclamation Or vbOKOnly, "Decryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Hash in the password text
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptHashData(lngHashHwd, strPassword, Len(strPassword), 0&)) Then
            MsgBox("Error: " & CStr(GetLastError) & " during CryptHashData!", _
                   vbExclamation Or vbOKOnly, "Decryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Create a session key from the hash object
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptDeriveKey(m_lngCryptContext, lngCipherType, _
                     lngHashHwd, 0&, lngHkey)) Then

            MsgBox("Error: " & CStr(GetLastError) & " during CryptDeriveKey!", _
                   vbExclamation Or vbOKOnly, "Decryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy hash object
        ' ---------------------------------------------------------------------------
        If lngHashHwd <> 0 Then
            lngRetCode = CryptDestroyHash(lngHashHwd)
        End If
        lngHashHwd = 0

        ' ---------------------------------------------------------------------------
        ' Prepare data for decryption.
        ' ---------------------------------------------------------------------------
        lngCryptLength = Len(m_strInputData)
        lngCryptBufLen = lngCryptLength * 2
        strCryptBuffer = StrDup(CInt(lngCryptBufLen), vbNullChar)
        LSet(strCryptBuffer = m_strInputData, strCryptBuffer.Length)

        ' ---------------------------------------------------------------------------
        ' Decrypt the text data
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptDecrypt(lngHkey, 0&, 1&, 0&, _
               strCryptBuffer, lngCryptLength)) Then

            If GetLastError = 0 Then

            Else
                MsgBox("Error " & CStr(GetLastError) & " during CryptDecrypt!", _
                       vbExclamation Or vbOKOnly, "Decryption Errors")
                GoTo CleanUp
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' Return the decrypted data string in a byte array.
        ' ---------------------------------------------------------------------------
        strOutputData = Mid(strCryptBuffer, 1, lngCryptLength)
        m_abytOutputData = StringToByteArray(strOutputData)
        CryptoDecrypt = True        ' successful finish

CleanUp:
        ' ---------------------------------------------------------------------------
        ' Destroy session key.
        ' ---------------------------------------------------------------------------
        If lngHkey <> 0 Then
            lngRetCode = CryptDestroyKey(lngHkey)
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy key exchange key handle
        ' ---------------------------------------------------------------------------
        If lngHExchgKey <> 0 Then
            lngRetCode = CryptDestroyKey(lngHExchgKey)
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy hash object
        ' ---------------------------------------------------------------------------
        If lngHashHwd <> 0 Then
            lngRetCode = CryptDestroyHash(lngHashHwd)
        End If

        lngHashHwd = 0
        strPassword = StrDup(250, 0)
        Exit Function

CryptoDecrypt_Error:
        ' ---------------------------------------------------------------------------
        ' An error ocurred during the decryption process
        ' ---------------------------------------------------------------------------
        MsgBox("Error: " & CStr(err.Number) & "  " & err.Description & vbCrLf & _
               vbCrLf & "A critical error ocurred during the decryption process.", _
               vbCritical Or vbOKOnly, "Decryption Errors")

        Resume CleanUp

    End Function

    Public Function Encrypt(Optional intHashType As Integer = 1, _
                        Optional intCipherType As Integer = 1) As Boolean

        ' ***************************************************************************
        ' Routine:       Encrypt
        '
        ' Description:   Encrypting files with the CryptoAPI is a four-step process.
        '                First, select a CSP to handle the encryption. Second, create
        '                a hash object, and base that hash object around the password
        '                data. Third, create a key object based on this hash.
        '                Finally, use a key to encrypt the data.  Defaults to values
        '                that come with the default provider (56-bit)
        '
        ' Parameters:    intHashType - (Optional) [Default] 1=Use MD5 hash algorithm
        '                    Selection:   1=MD5  2=MD4  3=MD2  4=SHA
        '                intCipherType - (Optional) [Default] 1=Use RC4 algorithm
        '                    Selection:  (Default Provider)   1=RC4  2=RC2  3=DES
        '                                (Enhanced Provider)  4=3DES 5=3DES_112
        '
        ' Returns:       TRUE/FALSE based on completion

        ' ---------------------------------------------------------------------------
        ' Encrypt the data
        ' ---------------------------------------------------------------------------
        Encrypt = CryptoEncrypt(intHashType, intCipherType)

    End Function

    Private Function CryptoEncrypt(intHashType As Integer, _
                                   intCipherType As Integer) As Boolean

        ' ***************************************************************************
        ' Routine:       CryptoEncrypt
        '
        ' Description:   Encrypting files with the CryptoAPI is a four-step process.
        '                First, select a CSP to handle the encryption. Second, create
        '                a hash object, and base that hash object around the password
        '                data. Third, create a key object based on this hash.
        '                Finally, use a key to encrypt the data.
        '
        ' Returns:       TRUE/FALSE based on completion

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim lngHashHwd As Long     ' Hash handle
        Dim lngHkey As Long
        Dim lngRetCode As Long     ' return value from an API call
        Dim lngHashType As Long
        Dim lngLength As Long
        Dim lngCipherType As Long
        Dim lngHExchgKey As Long
        Dim lngCryptLength As Long
        Dim lngCryptBufLen As Long
        Dim strCryptBuffer As String
        Dim strOutputData As String
        Dim strPassword As String

        ' ---------------------------------------------------------------------------
        ' Initialize variables
        ' ---------------------------------------------------------------------------
        CryptoEncrypt = False        ' preset to FALSE
        Erase m_abytOutputData
        strOutputData = ""
        strCryptBuffer = ""
        strPassword = ""

        ' ---------------------------------------------------------------------------
        ' If bad hash or cipher selection then leave
        ' ---------------------------------------------------------------------------
        lngHashType = GetHashType(intHashType, lngLength)
        If lngHashType = 0 Then
            MsgBox("This hash selection is not supported.", _
                   vbExclamation Or vbOKOnly, "Wrong Encrypt Hash Selection")
            Call Terminate()       ' Failed.  Time to leave.
            Exit Function
        End If

        lngCipherType = GetCipherType(intCipherType)
        If lngCipherType = 0 Then
            Call Terminate()       ' Failed.  Time to leave.
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Aquire the provider handle
        ' ---------------------------------------------------------------------------
        If m_lngCryptContext = 0 Then
            If Not GetProvider Then
                Call Terminate()       ' Failed.  Time to leave.
                Exit Function
            End If
        End If

        On Error GoTo CryptoEncrypt_Error
        ' ---------------------------------------------------------------------------
        ' convert password to string
        ' ---------------------------------------------------------------------------
        If UBound(m_abytPWord) > 0 Then
            strPassword = ByteArrayToString(m_abytPWord)
        Else
            If m_blnUseDefaultPWD Then
                m_abytPWord = GetPassword(True)       ' Use the default password
                strPassword = ByteArrayToString(m_abytPWord)
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' Create a hash object
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptCreateHash(m_lngCryptContext, lngHashType, 0&, _
                     0&, lngHashHwd)) Then

            MsgBox("Error: " & CStr(GetLastError) & " during CryptCreateHash!", _
                   vbExclamation Or vbOKOnly, "Encryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Hash in the password text
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptHashData(lngHashHwd, strPassword, Len(strPassword), 0&)) Then
            MsgBox("Error: " & CStr(GetLastError) & " during CryptHashData!", _
                   vbExclamation Or vbOKOnly, "Encryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Create a session key from the hash object
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptDeriveKey(m_lngCryptContext, lngCipherType, _
                     lngHashHwd, 0&, lngHkey)) Then

            MsgBox("Error: " & CStr(GetLastError) & " during CryptDeriveKey!", _
                   vbExclamation Or vbOKOnly, "Encryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy hash object
        ' ---------------------------------------------------------------------------
        If lngHashHwd <> 0 Then
            lngRetCode = CryptDestroyHash(lngHashHwd)
        End If
        lngHashHwd = 0

        ' ---------------------------------------------------------------------------
        ' Prepare data for encryption.
        ' ---------------------------------------------------------------------------
        lngCryptLength = Len(m_strInputData)
        lngCryptBufLen = lngCryptLength * 2
        strCryptBuffer = StrDup(CInt(lngCryptBufLen), vbNullChar)
        LSet(strCryptBuffer = m_strInputData, strCryptBuffer.Length)

        ' ---------------------------------------------------------------------------
        ' Encrypt the text data
        ' ---------------------------------------------------------------------------
        If Not CBool(CryptEncrypt(lngHkey, 0&, 1&, 0&, _
                            strCryptBuffer, lngCryptLength, lngCryptBufLen)) Then

            MsgBox("Bytes required:" & CStr(lngCryptBufLen) & vbCrLf & vbCrLf & _
                   "Error: " & CStr(GetLastError) & " during CryptEncrypt!", _
                   vbExclamation Or vbOKOnly, "Encryption Errors")
            GoTo CleanUp
        End If

        ' ---------------------------------------------------------------------------
        ' Return the encrypted data string in a byte array
        ' ---------------------------------------------------------------------------
        strOutputData = Mid(strCryptBuffer, 1, lngCryptLength)
        m_abytOutputData = StringToByteArray(strOutputData)
        CryptoEncrypt = True     ' Successful finish

CleanUp:
        ' ---------------------------------------------------------------------------
        ' Destroy session key.
        ' ---------------------------------------------------------------------------
        If lngHkey <> 0 Then
            lngRetCode = CryptDestroyKey(lngHkey)
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy key exchange key handle
        ' ---------------------------------------------------------------------------
        If lngHExchgKey <> 0 Then
            lngRetCode = CryptDestroyKey(lngHExchgKey)
        End If

        ' ---------------------------------------------------------------------------
        ' Destroy hash object
        ' ---------------------------------------------------------------------------
        If lngHashHwd <> 0 Then
            lngRetCode = CryptDestroyHash(lngHashHwd)
        End If

        ' ---------------------------------------------------------------------------
        ' Empty variables
        ' ---------------------------------------------------------------------------
        lngHashHwd = 0
        strPassword = StrDup(250, 0)
        Exit Function

CryptoEncrypt_Error:
        ' ---------------------------------------------------------------------------
        ' An error ocurred during the encryption process
        ' ---------------------------------------------------------------------------
        MsgBox("Error: " & CStr(err.Number) & "  " & err.Description & vbCrLf & _
               vbCrLf & "A critical error ocurred during the encryption process.", _
               vbCritical Or vbOKOnly, "Encryption Error")

        Resume CleanUp

    End Function

    Private Function GetHashType(ByVal intChoice As Integer, _
                                 ByRef lngLength As Long) As Long

        ' ---------------------------------------------------------------------------
        ' Determine the type of hash algorithm to use.
        ' 1=MD5  2=MD4  3=MD2  4=SHA-1
        ' ---------------------------------------------------------------------------
        Select Case intChoice

            Case 1  ' use MD5 algorithm creates a 128-bit output
                GetHashType = CALG_MD5
                lngLength = 16

            Case 2  ' use MD4 algorithm creates a 128-bit output
                GetHashType = CALG_MD4
                lngLength = 16

            Case 3  ' use MD2 algorithm creates a 128-bit output
                GetHashType = CALG_MD2
                lngLength = 16

            Case 4  ' use SHA-1 algorithm creates a 160-bit output
                GetHashType = CALG_SHA1
                lngLength = 20

            Case Else  ' invalid hash selection
                GetHashType = 0
                lngLength = 0
        End Select

    End Function

    Private Function GetCipherType(intChoice As Integer) As Long

        ' ---------------------------------------------------------------------------
        ' Determine the type of Encyption/Decryption algorithm to use.
        '     Default Provider:   1 = RC4    2= RC2    3=DES
        '     Enhanced Provider:  4 = 3DES   5 = 3DES_112
        ' ---------------------------------------------------------------------------
        m_blnBlockCipher = True   ' preset to TRUE

        ' if using the Enhanced Provider
        If m_blnEnhancedProvider Then
            Select Case intChoice
                Case 1      ' Stream cipher
                    GetCipherType = CALG_RC4
                    m_blnBlockCipher = False

                Case 2 : GetCipherType = CALG_RC2
                Case 3 : GetCipherType = CALG_DES
                Case 4 : GetCipherType = CALG_3DES
                Case 5 : GetCipherType = CALG_3DES_112
                Case Else
                    MsgBox("Enhanced provider does not support cipher selected.", _
                           vbExclamation Or vbOKOnly, "Wrong Cipher Selection")
                    GetCipherType = 0
            End Select
        Else
            Select Case intChoice
                Case 1 ' Stream ciphers
                    GetCipherType = CALG_RC4
                    m_blnBlockCipher = False

                    ' block ciphers
                Case 2 : GetCipherType = CALG_RC2
                Case 3 : GetCipherType = CALG_DES
                Case Else
                    MsgBox("Default provider does not support Triple DES ciphers.", _
                           vbExclamation Or vbOKOnly, "Wrong Cipher Selection")
                    GetCipherType = 0
            End Select
        End If

    End Function

    Public Function StringToByteArray(varInput As Object) As Byte()

        ' ***************************************************************************
        ' Routine:       StringToByteArray
        '
        ' Description:   Converts a string of data into a byte array [Range 0, 255]
        '
        ' Parameters:    strInput - data string to be converted into a byte array
        '
        ' Returns:       Byte array
        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim lngIndex As Long
        Dim lngLength As Long
        Dim bytBuffer() As Byte
        Dim bytData() As Byte

        ' ---------------------------------------------------------------------------
        ' Store length of data string in a variable.  Speeds up the process by not
        ' having to constantly evaluate the data length.  Works great with loops
        ' and long strings of data.  Good habit to get into.
        ' ---------------------------------------------------------------------------
        lngLength = Len(varInput)
        If lngLength < 1 Then
            ReDim bytData(0)
            StringToByteArray = bytData
            Exit Function
        End If

        ' ---------------------------------------------------------------------------
        ' Resize the array based on length on input string
        ' ---------------------------------------------------------------------------
        ReDim bytBuffer(lngLength)
        ReDim bytData(lngLength)

        ' ---------------------------------------------------------------------------
        ' Convert each character in the data string to its ASCII numeric equivalent.
        ' I use the VB function CByte() because sometimes the ASC() function returns
        ' data that does not convert to a value of 0 to 255 cleanly.
        ' ---------------------------------------------------------------------------
        For lngIndex = 0 To lngLength - 1
            bytBuffer(lngIndex) = CByte(Asc(Mid(varInput, lngIndex + 1, 1)))
        Next

        ' ---------------------------------------------------------------------------
        ' Copy data from memory to variable
        ' ---------------------------------------------------------------------------
        CopyMemory(bytData(0), bytBuffer(0), lngLength)

        ' ---------------------------------------------------------------------------
        ' Return the byte array
        ' ---------------------------------------------------------------------------
        StringToByteArray = bytData

        ' ---------------------------------------------------------------------------
        ' Resize arrays to smallest size
        ' ---------------------------------------------------------------------------
        ReDim bytData(0)
        ReDim bytBuffer(0)

    End Function

    Public Function Rnd2(sngLow As Single, sngHigh As Single) As Single

        ' ***************************************************************************
        ' Routine:       Rnd2
        '
        ' Description:   Create a random value between two values.  Used for desired
        '                range values only.
        '
        ' Parameters:    sngLow  - Low end value
        '                sngHign - High end value
        '
        ' Returns:       A random generated value

        ' ---------------------------------------------------------------------------
        ' Generate a value between two given values
        ' ---------------------------------------------------------------------------
        Randomize(GetTickCount() + CDbl(Now.ToOADate)) ' Reseed with system time (2 ways)
        Rnd2 = (Rnd * (sngHigh - sngLow)) + sngLow

    End Function

    Private Function GetPassword(Optional blnUseDefaultPWD As Boolean = True) As Byte()

        ' ***************************************************************************
        ' Routine:       GetPassword
        '
        ' Description:   Determines if the default password is to be used or if one
        '                is to be created on the fly.  A random generated password is
        '                used as an additional seed value for random data only.
        '                "On the fly" passwords are usually used for additional input
        '                for hashing and then passed on as extra seeding for the random
        '                number generator.
        '
        ' NOTE:          Before compiling this module, define your own default
        '                password.  I do not think you want to use this one.
        '                ("use.default-password" with mixed case)
        '
        ' Parameters:    blnChoice - (Optional) [Default] TRUE - use the default
        '                      password as defined in this routine
        '                      FALSE - create a twenty character password using
        '                      mixed case with numbers
        '
        ' Returns:       Password inside a byte array

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim strPassword As String
        Dim abytPWord() As Byte

        ' ---------------------------------------------------------------------------
        ' If the request is to use the default password then load each character
        ' separately.  This is faster and more difficult for a hacker to read the
        ' default password.  Create your own.  This one is for demo purposes only.
        ' ---------------------------------------------------------------------------
        If blnUseDefaultPWD Then

            ' size the password array
            ReDim abytPWord(20)

            ' Load array with default password.  I use CByte() to make sure.
            ' If you are really paranoid then convert CByte(Asc()) to their
            ' decimal values.  But that makes it even more difficult for you
            ' to read, too.
            abytPWord(0) = CByte(Asc("u"))
            abytPWord(1) = CByte(Asc("s"))
            abytPWord(2) = CByte(Asc("E"))
            abytPWord(3) = CByte(Asc("."))
            abytPWord(4) = CByte(Asc("d"))
            abytPWord(5) = CByte(Asc("e"))
            abytPWord(6) = CByte(Asc("F"))
            abytPWord(7) = CByte(Asc("a"))
            abytPWord(8) = CByte(Asc("U"))
            abytPWord(9) = CByte(Asc("L"))
            abytPWord(10) = CByte(Asc("t"))
            abytPWord(11) = CByte(Asc("-"))
            abytPWord(12) = CByte(Asc("p"))
            abytPWord(13) = CByte(Asc("a"))
            abytPWord(14) = CByte(Asc("S"))
            abytPWord(15) = CByte(Asc("s"))
            abytPWord(16) = CByte(Asc("w"))
            abytPWord(17) = CByte(Asc("O"))
            abytPWord(18) = CByte(Asc("r"))
            abytPWord(19) = CByte(Asc("d"))
        Else
            ' Create a random generated password 20 characters long
            ' using printable characters
            strPassword = CreateSaltValue(20, True)

            ' Initialize byte array
            Erase abytPWord               ' make sure array is empty
            ReDim abytPWord(0)              ' resize to smallest number of elements

            ' convert password to byte array
            abytPWord = StringToByteArray(strPassword)
            strPassword = StrDup(250, 0)   ' empty variable
        End If

        ' ---------------------------------------------------------------------------
        ' Return password in byte array format
        ' ---------------------------------------------------------------------------
        GetPassword = abytPWord

        ' ---------------------------------------------------------------------------
        ' Empty byte array
        ' ---------------------------------------------------------------------------
        Erase abytPWord              ' make sure array is empty
        ReDim abytPWord(0)              ' resize to smallest number of elements

    End Function

    Private Function GetProvider() As Boolean

        ' ***************************************************************************
        ' Routine:       GetProvider
        '
        ' Description:   Get the MS Provider.  If wanting to use 128-bit cipher
        '                strength then set the property EnhancedProvider = TRUE
        '
        ' Returns:       TRUE/FALSE based on completion

        ' ---------------------------------------------------------------------------
        ' Define local variables
        ' ---------------------------------------------------------------------------
        Dim strTemp As String
        Dim strProvider1 As String
        Dim strProvider2 As String
        Dim strErrorMsg As String

        On Error Resume Next
        ' ---------------------------------------------------------------------------
        ' Prepare string buffers
        ' ---------------------------------------------------------------------------
        strTemp = vbNullChar
        strProvider1 = MS_ENHANCED_PROVIDER & vbNullChar
        strProvider2 = MS_DEFAULT_PROVIDER & vbNullChar

        ' ---------------------------------------------------------------------------
        ' Gain Access To CryptoAPI.
        ' ---------------------------------------------------------------------------
        If m_blnEnhancedProvider Then
            ' Attempt to acquire a handle to the ENHANCED (128-bit) key container.
            If CBool(CryptAcquireContext(m_lngCryptContext, strTemp, _
                     strProvider1, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT)) Then
                GetProvider = True
                Exit Function
            End If
        Else
            ' Attempt to acquire a handle to the DEFAULT (56-bit) key container.
            If CBool(CryptAcquireContext(m_lngCryptContext, strTemp, _
                     strProvider2, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT)) Then
                GetProvider = True
                Exit Function
            End If
        End If

        ' ---------------------------------------------------------------------------
        ' If no luck acquiring a provider handle then create default key container
        ' using the current user's logon ID.  Make sure this is not shared because
        ' other users will have problems.
        ' ---------------------------------------------------------------------------
        If CBool(CryptAcquireContext(m_lngCryptContext, strTemp, _
                 strTemp, PROV_RSA_FULL, CRYPT_NEWKEYSET)) Then
            GetProvider = True
        Else
            ' Failed to aquire provider handle
            strErrorMsg = "Error creating DEFAULT key container - " & CStr(Err.LastDllError)
            MsgBox(strErrorMsg, vbCritical Or vbOKOnly, "Cannot access CryptoAPI")
            GetProvider = False
        End If

    End Function

    Private Sub Initialize()

        ' ***************************************************************************
        ' Routine:       Class_Initialize
        '
        ' Description:   When class is initialized, we aquire the provider handle.

        ' ---------------------------------------------------------------------------
        ' Get the provider handle
        ' ---------------------------------------------------------------------------
        m_blnEnhancedProvider = False
        m_blnUseDefaultPWD = True
        ReDim m_abytPWord(0)

    End Sub

    Private Sub Terminate()

        ' ***************************************************************************
        ' Routine:       Class_Terminate
        '
        ' Description:   When class is terminated, release module level data.

        ' ---------------------------------------------------------------------------
        ' Define variables
        ' ---------------------------------------------------------------------------
        Dim lngRetValue As Long

        ' ---------------------------------------------------------------------------
        ' If we managed to load a Microsoft Provider ID, then release it.
        ' ---------------------------------------------------------------------------
        If m_lngCryptContext <> 0 Then
            lngRetValue = CryptReleaseContext(m_lngCryptContext, 0&)
        End If
    End Sub
End Class
