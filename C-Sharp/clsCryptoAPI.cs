using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DpSdkEngLib;
using DPSDKOPSLib;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.InteropServices;
 // ERROR: Not supported in C#: OptionDeclaration
namespace _4PosBackOffice.NET
{
	internal class clsCryptoAPI
	{

		private bool m_blnEnhancedProvider;
		private bool m_blnBlockCipher;
		private bool m_blnUseDefaultPWD;
		private long m_lngCryptContext;
		private string m_strInputData;
		private byte[] m_abytOutputData;

		private byte[] m_abytPWord;
		// Export keys
		private const long SIMPLEBLOB = 1;
		private const long PUBLICKEYBLOB = 6;
		private const long PRIVATEKEYBLOB = 7;

		private const long PLAINTEXTKEYBLOB = 8;
		// Algorithm classes
		private const long ALG_CLASS_ANY = 0;
		private const long ALG_CLASS_SIGNATURE = 8192;
		private const long ALG_CLASS_MSG_ENCRYPT = 16384;
		private const long ALG_CLASS_DATA_ENCRYPT = 24576;

		private const long ALG_CLASS_HASH = 32768;
		// Algorithm types
		private const long ALG_TYPE_ANY = 0;
		private const long ALG_TYPE_BLOCK = 1536;

		private const long ALG_TYPE_STREAM = 2048;
		// Block cipher IDs
		private const long ALG_SID_DES = 1;
		private const long ALG_SID_RC2 = 2;
		private const long ALG_SID_3DES = 3;

		private const long ALG_SID_3DES_112 = 9;
		// Stream cipher IDs

		private const long ALG_SID_RC4 = 1;
		// Hash IDs
		private const long ALG_SID_MD2 = 1;
		private const long ALG_SID_MD4 = 2;
		private const long ALG_SID_MD5 = 3;
		private const long ALG_SID_SHA = 4;
		private const long ALG_SID_SHA1 = 4;

		private const long HP_HASHVAL = 2;
		// Hash algorithms
		private const long CALG_MD2 = ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_MD2;
		private const long CALG_MD4 = ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_MD4;
		private const long CALG_MD5 = ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_MD5;
		private const long CALG_SHA = ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_SHA;

		private const long CALG_SHA1 = ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_SHA1;
		// Block ciphers
		private const long CALG_RC2 = ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_RC2;
		private const long CALG_DES = ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_DES;
		private const long CALG_3DES = ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_3DES;

		private const long CALG_3DES_112 = ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_3DES_112;
		// Stream cipher

		private const long CALG_RC4 = ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_STREAM | ALG_SID_RC4;
		// CryptSetProvParam

		private const long PROV_RSA_FULL = 1;
		// used when aquiring the provider
		private const long CRYPT_VERIFYCONTEXT = 0xf0000000;

		private const long CRYPT_NEWKEYSET = 0x8L;
		// Microsoft provider data

		private const string MS_DEFAULT_PROVIDER = "Microsoft Base Cryptographic Provider v1.0";

		private const string MS_ENHANCED_PROVIDER = "Microsoft Enhanced Cryptographic Provider v1.0";
		// ---------------------------------------------------------------------------
		// Error codes
		// ---------------------------------------------------------------------------
		private const long ERR_CONTEXTOPEN = 100;
		private const long ERR_LOCKED = 101;
		private const long ERR_NOCONTEXT = 102;

		private const long ERR_KEYNOTVALID = 103;
		// ---------------------------------------------------------------------------
		// Numbers defined by GetLastError
		// ---------------------------------------------------------------------------
		private const long ERROR_BUSY = 170;
		private const long ERROR_INVALID_PARAMETER = 87;
		private const long ERROR_NOT_ENOUGH_MEMORY = 8;
		private const long ERROR_MORE_DATA = 234;

		private const long NTE_BAD_DATA = 0x80090005;
		// ---------------------------------------------------------------------------
		// Error messages
		// ---------------------------------------------------------------------------
		private const string ERROR_AQUIRING_CONTEXT = "Could not acquire context";
		private const string ERROR_CREATING_HASH = "Could not create hash";
		private const string ERROR_CREATING_HASH_DATA = "Could not create hash data";
		private const string ERROR_DERIVING_KEY = "Could not derive key";
		private const string ERROR_ENCRYPTING_DATA = "Could not encrypt data";
		private const string ERROR_DECRYPTING_DATA = "Could not decrypt data";
		private const string ERROR_INVALID_HEX_STRING = "Not a valid hex string";
		private const string ERROR_MISSING_PARAMETER = "Both a string and a key are required";

		private const string ERROR_BAD_ENCRYPTION_TYPE = "Invalid encryption type specified";
		[DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		// ---------------------------------------------------------------------------
		// Declares
		// ---------------------------------------------------------------------------
		// CopyMemory moves the contents of a portion of memory from one location
		// to another. The two locations are identified by pointers to the memory
		// addresses. After the copy, the original contents in the source are set
		// to zeros.
		//
		// Useful whenever you want to move a block of bytes between two memory
		// locations.  When the source or the destination is an array of numbers
		// (or of UDTs that contains only numeric and fixed-length strings), you
		// must pass the first element of the array by reference.  Example below
		// depicts zero based arrays.
		//
		// Copy the first 1000 elements of array a() to b().  Both arrays must be
		// of the same type, and cannot be objects or variable-length strings.
		//
		//    CopyMemory b(0), a(0), 1000 * Len(a(0))
		//
		private static extern void CopyMemory(byte dest, byte source, long bytes);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The GetTickCount() API will capture the time in milliseconds.  The
		// counter overflows after 1192.8 hours (49.7 days) from the last reboot.
		private static extern long GetTickCount();
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The GetLastError function returns the calling thread's last-error
		// code value.  Most Win32 functions set their calling thread's
		// last-error value when they fail; a few functions set it when they
		// succeed.  You should call the GetLastError function immediately when
		// a function's return value indicates that such a call will return
		// useful data. That is because some functions call SetLastError(0) when
		// they succeed, wiping out the error code set by the most recently
		// failed function.
		private static extern long GetLastError();
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptHashData function adds data to a specified hash object.
		// This function and CryptHashSessionKey can be called multiple
		// times to compute the hash of long or discontinuous data streams.
		private static extern long CryptHashData(long hhash, string pbData, long dwDataLen, long dwFlags);
		[DllImport("advapi32.dll", EntryPoint = "CryptHashData", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// Alias of CryptHashData
		private static extern long CryptHashDataString(long hhash, string bData, long dwDataLen, long dwFlags);
		[DllImport("advapi32.dll", EntryPoint = "CryptHashData", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// Alias of CryptHashData
		private static extern long CryptHashDataBytes(long hhash, byte bData, long dwDataLen, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptCreateHash function initiates the hashing of a stream of
		// data. It creates and returns to the calling application a handle
		// to a CSP hash object. This handle is used in subsequent calls to
		// CryptHashData and CryptHashSessionKey to hash session keys and
		// other streams of data.
		private static extern long CryptCreateHash(long hProv, long algid, long hkey, long dwFlags, ref long phHash);
		[DllImport("advapi32.dll", EntryPoint = "CryptSignHashA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptSignHash function signs data. Because all signature
		// algorithms are asymmetric and thus slow, the CryptoAPI does not
		// allow data be signed directly. Instead, data is first hashed and
		// CryptSignHash is used to sign the hash.
		private static extern long CryptSignHash(long hhash, long hkey, long Description, long dwFlags, long pData, long dwDataLength);
		[DllImport("advapi32.dll", EntryPoint = "CryptVerifySignatureA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptVerifySignature function verifies the signature of a
		// hash object.  Before calling this function, CryptCreateHash must be
		// called to create the handle of a hash object. CryptHashData or
		// CryptHashSessionKey is then used to add data or session keys to the
		// hash object.
		private static extern long CryptVerifySignature(long hhash, long pData, long datalength, long PublicKey, long Description, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptGetHashParam function retrieves data that governs the
		// operations of a hash object. The actual hash value can be
		// retrieved by using this function.
		private static extern long CryptGetHashParam(long hhash, long dwParam, string pbData, long pdwDataLen, long dwFlags);
		[DllImport("advapi32.dll", EntryPoint = "CryptGetHashParam", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// Alias of CryptGetHashParam
		private static extern long CryptGetHashParamSize(long hhash, long dwParam, long pbData, long dwDataLength, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		//The CryptDestroyHash function destroys the hash object referenced
		// by the hHash parameter. After a hash object has been destroyed,
		// it can no longer be used.  The destruction of hash objects after
		// their use is finished is recommended for security reasons.
		private static extern long CryptDestroyHash(long hhash);
		[DllImport("advapi32.dll", EntryPoint = "CryptAcquireContextA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptAcquireContext function is used to acquire a handle to a
		// particular key container within a particular cryptographic service
		// provider (CSP). This returned handle can then be used to make
		// calls to the selected CSP.  This function performs two operations.
		// It first attempts to find a CSP with the characteristics described
		// in the dwProvType and pszProvider parameters. If the CSP is found,
		// the function attempts to find a key container within the CSP
		// matching the name specified by the pszContainer parameter.  With the
		// appropriate setting of dwFlags, this function can also create and
		// destroy key containers.
		private static extern long CryptAcquireContext(ref long phProv, string pszContainer, string pszProvider, long dwProvType, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptReleaseContext function releases the handle of a
		// cryptographic service provider (CSP) and a key container. At each
		// call to this function, the reference count on the CSP is reduced
		// by one. When the reference count reaches zero, the context is fully
		// released and it can no longer be used by any function in the application.
		// An application calls this function after finishing the use of the CSP.
		// After this function is called, the released CSP handle is no longer
		// valid. This function does not destroy key containers or key pairs.
		private static extern long CryptReleaseContext(long hProv, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The data produced by this function is cryptographically random.  The
		// data is far more random than the data generated by the typical random
		// number generator such as the one shipped with your C or VB compiler.
		private static extern long CryptGenRandom(long hProv, long dwLen, string pbBuffer);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptGetUserKey function retrieves a handle of one of a user's two
		// public/private key pairs. This function is used only by the owner of
		// the public/private key pairs and only when the handle of a cryptographic
		// service provider (CSP) and its associated key container is available.
		private static extern long CryptGetUserKey(long hProv, long dwKeySpec, long phUserKey);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptGenKey function generates a random cryptographic session key or
		// a public/private key pair. A handle to the key or key pair is returned
		// in phKey. This handle can then be used as needed with any CryptoAPI
		// function requiring a key handle.  The calling application must specify
		// the algorithm when calling this function. Because this algorithm type is
		// kept bundled with the key, the application does not need to specify the
		// algorithm later when the actual cryptographic operations are performed.
		private static extern long CryptGenKey(long hProv, long algid, long dwFlags, long phKey);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptDeriveKey function generates cryptographic session keys derived
		// from a base data value. This function guarantees that when the same CSP
		// and algorithms are used, the keys generated from the same base data are
		// identical. The base data can be a password or any other user data.  This
		// function is the same as CryptGenKey, except that the generated session
		// keys are derived from base data instead of being random. CryptDeriveKey
		// can only be used to generate session keys. It cannot generate
		// public/private key pairs.
		private static extern long CryptDeriveKey(long hProv, long algid, long hBaseData, long dwFlags, ref long phKey);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptDestroyKey function releases the handle referenced by the hKey
		// parameter. After a key handle has been released, it becomes invalid and
		// cannot be used again.
		private static extern long CryptDestroyKey(long hkey);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptGetKeyParam function retrieves data that governs the operations
		// of a key. If the Microsoft Cryptographic Service Provider is used, the
		// base symmetric keying material is not obtainable by this function or any
		// other function.
		private static extern long CryptGetKeyParam(long hkey, long dwParam, long pbData, long pdwDataLen, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptSetKeyParam function customizes various aspects of a session
		// key's operations. The values set by this function are not persisted
		// to memory and can only be used with in a single session.
		private static extern long CryptSetKeyParam(long hkey, long dwParam, long pbData, long dwFlags);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptExportKey function exports a cryptographic key or a key pair
		// from a cryptographic service provider (CSP) in a secure manner.
		private static extern long CryptExportKey(long hkey, long hExpKey, long dwBlobType, long dwFlags, long pbData, long pdwDataLen);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptImportKey function transfers a cryptographic key from a key
		// BLOB into a cryptographic service provider (CSP).This function can be
		// used to import an Schannel session key, regular session key, public
		// key, or public/private key pair. For all but the public key, the key
		// or key pair is encrypted.
		private static extern long CryptImportKey(long hProv, long pbData, long dwDataLength, long hPubKey, long dwFlags, long pKeyval);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptEncrypt function encrypts data. The algorithm used to encrypt
		// the data is designated by the key held by the CSP module and is
		// referenced by the hKey parameter.
		private static extern long CryptEncrypt(long hkey, long hhash, long Final, long dwFlags, string pbData, ref long pdwDataLen, long dwBufLen);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptDecrypt function decrypts data previously encrypted using
		// CryptEncrypt function.
		private static extern long CryptDecrypt(long hkey, long hhash, long Final, long dwFlags, string pbData, ref long pdwDataLen);
		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// The CryptGetProvParam function retrieves parameters that govern the
		// operations of a cryptographic service provider (CSP).
		private static extern long CryptGetProvParam(long hProv, long dwParam, string pbData, long pdwDataLen, long dwFlags);
		[DllImport("advapi32.dll", EntryPoint = "CryptGetProvParam", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		// Alias of CryptGetProvParam
		private static extern long CryptGetProvParamString(long hProv, long dwParam, string pbData, long pdwDataLen, long dwFlags);


		// ***************************************************************************
		//                        Property area
		// ***************************************************************************

		public byte InputData {
			set { m_strInputData = value; }
		}

		public byte[] OutputData {
			get { return m_abytOutputData; }
		}

		public bool EnhancedProvider {
			get { return m_blnEnhancedProvider; }
			set { m_blnEnhancedProvider = value; }
		}

		public byte[] PassWord {
			get { return m_abytPWord; }
			set {
				m_abytPWord = new byte[byte.MinValue + 1];
				if (Information.UBound(value) > 0) {
					m_abytPWord = value;
				} else {
					if (m_blnUseDefaultPWD) {
						m_abytPWord = GetPassword(true);
					}
				}
			}
		}

		public bool UseDefaultPWD {
			set { m_blnUseDefaultPWD = value; }
		}

		// ***************************************************************************
		//                    Functions and Procedures
		// ***************************************************************************
		public string ByteArrayToString(byte[] arByte)
		{
			string functionReturnValue = null;

			// ---------------------------------------------------------------------------
			// Define variables
			// ---------------------------------------------------------------------------
			long lngLoop = 0;
			long lngMax = 0;
			long lngLength = 0;
			long lngPaddingLen = 0;
			long lngIndexPointer = 0;
			string strTemp = null;
			string strOutput = null;

			const long ADD_SPACES = 10000;

			// ---------------------------------------------------------------------------
			// Determine amount of data in the byte array.
			// ---------------------------------------------------------------------------
			strTemp = "";
			lngIndexPointer = 1;
			// index pointer for output string
			lngMax = Information.UBound(arByte);
			// determine number of elements in array
			lngPaddingLen = (ADD_SPACES * 9);
			// 90000 blank spaces
			strOutput = Strings.Space(lngPaddingLen);
			// preload output string

			// ---------------------------------------------------------------------------
			// Unload the byte array and convert each character back to its ASCII
			// character value
			// ---------------------------------------------------------------------------

			for (lngLoop = 0; lngLoop <= lngMax - 1; lngLoop++) {
				strTemp = Strings.Chr(arByte[lngLoop]);
				// Convert each byte to an ASCII character
				lngLength = Strings.Len(strTemp);
				// save the length of the converted data

				// see if some more padding has to be added to the output string
				if ((lngIndexPointer + lngLength) >= lngPaddingLen) {
					lngPaddingLen = lngPaddingLen + ADD_SPACES;
					// boost blank space counter
					strOutput = strOutput + Strings.Space(ADD_SPACES);
					// append some blank spaces
				}

				// insert data into output string
				Strings.Mid(strOutput, lngIndexPointer, lngLength) = strTemp;

				// increment output string pointer
				lngIndexPointer = lngIndexPointer + lngLength;

			}

			// ---------------------------------------------------------------------------
			// Return the string data
			// ---------------------------------------------------------------------------
			strOutput = Strings.RTrim(strOutput);
			// remove trailing blanks
			functionReturnValue = strOutput;
			// return data string

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public string ConvertByteToHex(ref byte[] abytData)
		{
			string functionReturnValue = null;

			// ---------------------------------------------------------------------------
			// Define variables
			// ---------------------------------------------------------------------------
			string strOutput = null;
			int intTemp = 0;
			long lngLoop = 0;
			long lngMax = 0;
			long lngIndexPointer = 0;
			long lngPaddingLen = 0;

			const long ADD_SPACES = 10000;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			lngIndexPointer = 1;
			// start in first position of output string
			lngMax = Information.UBound(abytData);
			// number of elements in array
			lngPaddingLen = (ADD_SPACES * 9);
			// 90,000 blank spaces
			strOutput = Strings.Space(lngPaddingLen);
			// preload output string with blank spaces

			// ---------------------------------------------------------------------------
			// First, verify byte array has data in it.
			// ---------------------------------------------------------------------------

			if (lngMax > 0) {
				// Loop thru and convert the data

				for (lngLoop = 0; lngLoop <= lngMax - 1; lngLoop++) {
					// see if some more padding has to be added to the output string
					if (((lngLoop * 2) + 2) >= lngPaddingLen) {
						lngPaddingLen = lngPaddingLen + ADD_SPACES;
						// boost blank space counter
						strOutput = strOutput + Strings.Space(ADD_SPACES);
						// append some blank spaces
					}

					intTemp = Convert.ToInt32(abytData[lngLoop]);
					// capture one byte

					// replace 2 blank spaces with a hex value
					Strings.Mid(strOutput, lngIndexPointer, 2) = Strings.Right("00" + Conversion.Hex(intTemp), 2);

					lngIndexPointer = lngIndexPointer + 2;
					// increment position pointer
				}

				strOutput = Strings.RTrim(strOutput);
				// remove trailing blanks
			} else {
				strOutput = "";
			}

			// ---------------------------------------------------------------------------
			// Return results
			// ---------------------------------------------------------------------------
			functionReturnValue = strOutput;

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public string ConvertStringFromHex(string strHex)
		{
			string functionReturnValue = null;

			// ---------------------------------------------------------------------------
			// Define variables
			// ---------------------------------------------------------------------------
			long lngMax = 0;
			long lngLoop = 0;
			long lngLength = 0;
			long lngPaddingLen = 0;
			long lngIndexPointer = 0;
			string strTemp = null;
			string strOutput = null;

			const long ADD_SPACES = 10000;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			strTemp = "";
			lngIndexPointer = 1;
			// index pointer for output string
			lngMax = Strings.Len(strHex);
			// length of input hex string
			lngPaddingLen = (ADD_SPACES * 9);
			// 90000 blank spaces
			strOutput = Strings.Space(lngPaddingLen);
			// preload output string

			// ---------------------------------------------------------------------------
			// See if the hex data string can be divided evenly by two.  If not, then the
			// data is corrupted.
			// ---------------------------------------------------------------------------
			if (lngMax % 2 != 0) {
				return functionReturnValue;
				//MsgBox "Data string is corrupted.  Cannot be Decrypted.", _
				//       vbCritical Or vbOKOnly, "Data corrupted"
			}

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------

			for (lngLoop = 1; lngLoop <= lngMax; lngLoop += 2) {
				strTemp = Strings.Chr(Conversion.Val("&H" + Strings.Mid(strHex, lngLoop, 2)));
				lngLength = Strings.Len(strTemp);
				// save the length of the converted data

				// see if some more padding has to be added to the output string
				if ((lngIndexPointer + lngLength) >= lngPaddingLen) {
					lngPaddingLen = lngPaddingLen + ADD_SPACES;
					// boost blank space counter
					strOutput = strOutput + Strings.Space(ADD_SPACES);
					// append some blank spaces
				}

				// insert data into output string
				Strings.Mid(strOutput, lngIndexPointer, lngLength) = strTemp;

				// increment output string pointer
				lngIndexPointer = lngIndexPointer + lngLength;

			}

			// ---------------------------------------------------------------------------
			// Return the formatted data
			// ---------------------------------------------------------------------------
			strOutput = Strings.RTrim(strOutput);
			// remove trailing blanks
			functionReturnValue = strOutput;
			// return data string

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public string ConvertStringToHex(string strInput, bool blnRetUppercase = true)
		{
			string functionReturnValue = null;

			// ---------------------------------------------------------------------------
			// Define variables
			// ---------------------------------------------------------------------------
			long lngMax = 0;
			long lngLoop = 0;
			long lngLength = 0;
			long lngPaddingLen = 0;
			long lngIndexPointer = 0;
			string strTemp = null;
			string strOutput = null;

			const long ADD_SPACES = 10000;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			strTemp = "";
			lngIndexPointer = 1;
			// index pointer for output string
			lngMax = Strings.Len(strInput);
			// length of input data string
			lngPaddingLen = (ADD_SPACES * 9);
			// 90000 blank spaces
			strOutput = Strings.Space(lngPaddingLen);
			// preload output string

			// ---------------------------------------------------------------------------
			// Convert to hex
			// ---------------------------------------------------------------------------

			for (lngLoop = 1; lngLoop <= lngMax; lngLoop++) {
				strTemp = Strings.Right("00" + Conversion.Hex(Strings.Asc(Strings.Mid(strInput, lngLoop, 1))), 2);
				lngLength = Strings.Len(strTemp);
				// save the length of the converted data

				// see if some more padding has to be added to the output string
				if ((lngIndexPointer + lngLength) >= lngPaddingLen) {
					lngPaddingLen = lngPaddingLen + ADD_SPACES;
					// boost blank space counter
					strOutput = strOutput + Strings.Space(ADD_SPACES);
					// append some blank spaces
				}

				// insert data into output string
				Strings.Mid(strOutput, lngIndexPointer, lngLength) = strTemp;

				// increment output string pointer
				lngIndexPointer = lngIndexPointer + lngLength;
			}

			// ---------------------------------------------------------------------------
			// remove trailing blanks
			// ---------------------------------------------------------------------------
			strOutput = Strings.RTrim(strOutput);
			// remove trailing blanks

			// ---------------------------------------------------------------------------
			// Return hex string
			// ---------------------------------------------------------------------------
			if (blnRetUppercase) {
				functionReturnValue = Strings.StrConv(strOutput, Constants.vbUpperCase);
			} else {
				functionReturnValue = strOutput;
			}

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public string CreateHash(string strInText = "", int intHashChoice = 1, bool blnConvertToHex = true, bool blnAppendPassword = false, bool blnCaseSensitive = false)
		{
			string functionReturnValue = null;

			// ***************************************************************************
			// Routine:       CreateHash
			//
			// Description:   Generate a one-way hash string from a string of data. There
			//                are 4 algorithms available in this version:
			//                 1=MD5  2=MD4  3=MD2  4=SHA-1
			//
			//                Hashes are extremely useful for determining whether a
			//                transmission or file has been altered.  The MDn returns a
			//                16 character hash and the SHA-1 returns a 20 character hash.
			//                No two hashes are alike unless the string matches perfectly,
			//                whether binary data or a text string.  I use hashes to
			//                create crypto keys and to verify integrity of packets when
			//                using winsock (UDP especially). Be aware that if you choose
			//                to not convert the return data to hex, then hashes may not
			//                store to text correctly because of the possible existence of
			//                non printable characters in the stream.
			//
			// Parameters:    strInText - string of data to be hashed.
			//                intHashChoice - (Optional) Numeric identifier for the type
			//                     of hash algorithm.  [Default] value = 1 (MD5)
			//                blnConvertToHex - (Optional) [Default] TRUE=Convert return
			//                     data to Hex format.
			//                     FALSE=Do not convert the return data
			//                blnAppendPassword - (Optional) [Default] FALSE=Do not append
			//                     the password to the data to be hashed.
			//                     True - Append the default password to data to be hashed.
			//                blnCaseSensitive - (Optional) Only used if blnConvertToHex=TRUE
			//                     [Default] FALSE=Convert return data to uppercase.
			//                     TRUE=Return data as it was created.
			//
			// Returns:       ASCII string of characters

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			long lngHashType = 0;
			long lngHashHwd = 0;
			long lngRetCode = 0;
			long lngIndex = 0;
			long lngOutputLength = 0;
			string strOutput = null;
			string strTempHash = null;
			string strPassword = null;
			byte[] abytPWord = null;

			// ---------------------------------------------------------------------------
			// Aquire the provider handle
			// ---------------------------------------------------------------------------
			if (m_lngCryptContext == 0) {
				if (!GetProvider()) {
					Terminate();
					return functionReturnValue;
					// Failed.  Time to leave.
				}
			}

			// ---------------------------------------------------------------------------
			// Append password to data to be hashed
			// ---------------------------------------------------------------------------
			if (blnAppendPassword) {
				// see if we are holding a password
				if (Information.UBound(m_abytPWord) > 0) {
					strPassword = ByteArrayToString(m_abytPWord);
					// convert password to string
				} else {
					// safety net in case the array is empty
					abytPWord = GetPassword(m_blnUseDefaultPWD);
					// create a random password
					strPassword = ByteArrayToString(abytPWord);
					// convert password to string
					abytPWord = null;
					// empty array
					abytPWord = new byte[1];
					// resize to smallest size
				}

				strInText = strInText + strPassword;
				// append password
			}

			// ---------------------------------------------------------------------------
			// Determine type of hash algorithm to use
			// ---------------------------------------------------------------------------
			lngHashType = GetHashType(intHashChoice, ref lngOutputLength);

			// ---------------------------------------------------------------------------
			// The CryptCreateHash function initiates the hashing of a stream of data. It
			// creates and returns to the calling application a handle to a CSP hash
			// object. This handle is used in subsequent calls to CryptHashData to hash
			// session keys and other streams of data.
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptCreateHash(m_lngCryptContext, lngHashType, 0L, 0L, ref lngHashHwd))) {
				functionReturnValue = "";
				return functionReturnValue;
			}

			// ---------------------------------------------------------------------------
			// The CryptHashData function adds data to a specified hash object. This
			// function can be called multiple times to compute the hash of long or
			// discontinuous data streams.
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptHashData(lngHashHwd, strInText, Strings.Len(strInText), 0L))) {
				functionReturnValue = "";
				return functionReturnValue;
			}

			// ---------------------------------------------------------------------------
			// Initialize variables.  Do not use String$() to create your spaces.  Some
			// API functions read each character as a single entity versus Space$() as
			// a whole entity.  I do not recommend using NULL values.  Some API functions
			// look at this as a null terminated string buffer and not a preloaded buffer.
			// ---------------------------------------------------------------------------
			strTempHash = Strings.Space(lngOutputLength);

			// ---------------------------------------------------------------------------
			// The CryptGetHashParam function retrieves data that governs the operations
			// of a hash object. The actual hash value can be retrieved by using this
			// function.
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptGetHashParam(lngHashHwd, HP_HASHVAL, strTempHash, lngOutputLength, 0L))) {
				functionReturnValue = "";
				return functionReturnValue;
			}

			// ---------------------------------------------------------------------------
			// See if we are to return the data in Hex or Binary format
			// ---------------------------------------------------------------------------
			if (blnConvertToHex) {
				// convert to hex format
				if (blnCaseSensitive) {
					strOutput = ConvertStringToHex(strTempHash, false);
					// leave as is
				} else {
					strOutput = ConvertStringToHex(strTempHash, true);
					// Uppercase [Default]
				}
			} else {
				// Return the raw data in binary format
				strOutput = strTempHash;
			}

			// ---------------------------------------------------------------------------
			// Return hash data
			// ---------------------------------------------------------------------------
			functionReturnValue = Strings.RTrim(strOutput);

			// ---------------------------------------------------------------------------
			// Destroy hash object
			// ---------------------------------------------------------------------------
			if (lngHashHwd != 0) {
				lngRetCode = CryptDestroyHash(lngHashHwd);
			}

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			strPassword = Strings.StrDup(250, 0);
			strTempHash = Strings.StrDup(250, 0);
			return functionReturnValue;

		}
		public string CreateRandom(long lngDataLength = 40, bool blnRetExactLength = true, bool blnConvertToHex = false)
		{
			string functionReturnValue = null;

			// ***************************************************************************
			// Routine:       CreateRandom
			//
			// Description:   Get truly cryptographic strength random data.  Tested with
			//                DieHard and ENT tests for randomness.
			//
			// Parameters:    lngDataLength - (Optional) Length of data to be returned
			//                                [Default] data length is 40 bytes
			//                blnRetExactLength - (Optional) [Default] TRUE=Return just
			//                      the length requested.
			//                      FALSE=Return all generated data regardless of length.
			//                blnConvertToHex - (Optional) [Default] FALSE=Do not convert
			//                      the return data to hex format.
			//                      TRUE=Convert return data to hex format.
			//
			// Returns:       A string of random data

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			string strOutput = null;
			string strRndBuffer = null;

			// ---------------------------------------------------------------------------
			// Initialize variables.
			// ---------------------------------------------------------------------------
			strRndBuffer = "";
			strOutput = "";

			// ---------------------------------------------------------------------------
			// Aquire the provider handle
			// ---------------------------------------------------------------------------
			if (m_lngCryptContext == 0) {
				if (!GetProvider()) {
					Terminate();
					return functionReturnValue;
					// Failed.  Time to leave.
				}
			}

			// ---------------------------------------------------------------------------
			// The strRndBuffer must be at least the length of Data Length requested.
			// This buffer is also where we can add additional seed values.  Build the
			// additional seed values for the random generator.
			// ---------------------------------------------------------------------------
			strRndBuffer = Convert.ToString(GetTickCount() + Convert.ToDouble(DateAndTime.Now.ToOADate()));
			// System time (2 ways)
			strRndBuffer = strRndBuffer + CreateSaltValue(40);
			// append 40 random chars
			strRndBuffer = CreateHash(strRndBuffer, 4, false);
			// hash using SHA-1

			// ---------------------------------------------------------------------------
			// Now we have an additional seed for the random number generator.  Be sure to
			// append additional space for the return data.  Excess will be removed.
			// ---------------------------------------------------------------------------
			strRndBuffer = strRndBuffer + Strings.Space(lngDataLength);

			// ---------------------------------------------------------------------------
			// Create the random data
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptGenRandom(m_lngCryptContext, lngDataLength, strRndBuffer))) {
				functionReturnValue = "";
				return functionReturnValue;
			}

			// ---------------------------------------------------------------------------
			// Remove any trailing blank spaces
			// ---------------------------------------------------------------------------
			strRndBuffer = Strings.RTrim(strRndBuffer);

			// ---------------------------------------------------------------------------
			// Return the random data string
			// ---------------------------------------------------------------------------
			if (blnConvertToHex) {
				// convert data string to hex
				strOutput = ConvertStringToHex(strRndBuffer, true);
				//Uppercase [Default]
			} else {
				// do not convert to hex prior to returning the data string
				strOutput = strRndBuffer;
			}

			// ---------------------------------------------------------------------------
			// Return data
			// ---------------------------------------------------------------------------
			if (blnRetExactLength) {
				functionReturnValue = Strings.Left(strOutput, lngDataLength);
			} else {
				functionReturnValue = Strings.RTrim(strOutput);
			}

			// ---------------------------------------------------------------------------
			// empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			strRndBuffer = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public object CreateSaltValue(long lngReturnLength = 20, bool blnUseLettersNumbersOnly = true)
		{
			object functionReturnValue = null;

			// ***************************************************************************
			// Routine:       CreateSaltValue
			//
			// Description:   Generate random data to be used a salt value.  This will
			//                return values 0-9, A-Z, and a-z or truely random data.
			//
			// Parameters:    lngReturnLength - Length of data to be returned
			//                blnUseLettersNumbersOnly - (Optional) [Default] TRUE=Use
			//                     letters and numbers only.
			//                     FALSE=Use truely random data
			//
			// Returns:       A string of random data

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			int intChar = 0;
			long lngIndex = 0;
			string strOutput = null;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			strOutput = "";

			// ---------------------------------------------------------------------------
			// Create salt value string using 0-9, A-Z, a-z only
			// ---------------------------------------------------------------------------

			if (blnUseLettersNumbersOnly) {

				for (lngIndex = 1; lngIndex <= lngReturnLength; lngIndex++) {
					intChar = Conversion.Int(Rnd2(48f, 122f));

					switch (intChar) {
						case 58:
						case 59:
						case 60:
						case 61:
						case 62:
						case 63:
						case 64:
						case 91:
						case 92:
						case 93:
						case 94:
						case 95:
						case 96:
							intChar = intChar + 9;
							// add 9 to unwanted values
							break;
					}

					strOutput = strOutput + Strings.Chr(intChar);
				}
			} else {
				strOutput = CreateRandom(lngReturnLength, true);
			}

			// ---------------------------------------------------------------------------
			// Return the new Salt value
			// ---------------------------------------------------------------------------
			functionReturnValue = strOutput;

			// ---------------------------------------------------------------------------
			// empty variables
			// ---------------------------------------------------------------------------
			strOutput = Strings.StrDup(250, 0);
			return functionReturnValue;

		}

		public bool Decrypt(int intHashType = 1, int intCipherType = 1)
		{

			// ***************************************************************************
			// Routine:       Decrypt
			//
			// Description:   Call the decyption routine.
			//
			// Parameters:    intHashType - (Optional) [Default] 1=Use MD5 hash algorithm
			//                    Selection:   1=MD5  2=MD4  3=MD2  4=SHA-1
			//                intCipherType - (Optional) [Default] 1=Use RC4 algorithm
			//                    Selection:  (Default Provider)   1=RC4  2=RC2  3=DES
			//                                (Enhanced Provider)  4=3DES 5=3DES_112
			//
			// Returns:       TRUE/FALSE based on completion.

			// ---------------------------------------------------------------------------
			// Decrypt the data
			// ---------------------------------------------------------------------------
			return CryptoDecrypt(intHashType, intCipherType);

		}

		private bool CryptoDecrypt(int intHashType, int intCipherType)
		{
			bool functionReturnValue = false;

			// ***************************************************************************
			// Routine:       CryptoDecrypt
			//
			// Description:   Perform the actual decryption of a string of data or a file.
			//
			// Returns:       TRUE/FALSE based on completion

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			long lngHashHwd = 0;
			// Hash handle
			long lngHkey = 0;
			long lngRetCode = 0;
			// return value from an API call
			long lngHashType = 0;
			long lngLength = 0;
			long lngCipherType = 0;
			long lngHExchgKey = 0;
			long lngCryptLength = 0;
			long lngCryptBufLen = 0;
			string strCryptBuffer = null;
			string strOutputData = null;
			string strPassword = null;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			functionReturnValue = false;
			// preset to FALSE
			m_abytOutputData = null;
			m_abytOutputData = new byte[1];
			strOutputData = "";
			strCryptBuffer = "";
			strPassword = "";

			// ---------------------------------------------------------------------------
			// If bad hash or cipher selection then leave
			// ---------------------------------------------------------------------------
			lngHashType = GetHashType(intHashType, ref lngLength);
			if (lngHashType == 0) {
				Interaction.MsgBox("This hash selection is not supported.", Constants.vbExclamation | Constants.vbOKOnly, "Wrong Decrypt Hash Selection");
				Terminate();
				return functionReturnValue;
				// Failed.  Time to leave.
			}

			lngCipherType = GetCipherType(intCipherType);
			if (lngCipherType == 0) {
				Terminate();
				return functionReturnValue;
				// Failed.  Time to leave.
			}

			// ---------------------------------------------------------------------------
			// Aquire the provider handle
			// ---------------------------------------------------------------------------
			if (m_lngCryptContext == 0) {
				if (!GetProvider()) {
					Terminate();
					return functionReturnValue;
					// Failed.  Time to leave.
				}
			}

			 // ERROR: Not supported in C#: OnErrorStatement

			// ---------------------------------------------------------------------------
			// convert password to string
			// ---------------------------------------------------------------------------
			if (Information.UBound(m_abytPWord) > 0) {
				strPassword = ByteArrayToString(m_abytPWord);
			} else {
				if (m_blnUseDefaultPWD) {
					m_abytPWord = GetPassword(true);
					// Use the default password
					strPassword = ByteArrayToString(m_abytPWord);
				}
			}

			// ---------------------------------------------------------------------------
			// Create a hash object
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptCreateHash(m_lngCryptContext, lngHashType, 0L, 0L, ref lngHashHwd))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptCreateHash!", Constants.vbExclamation | Constants.vbOKOnly, "Decryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Hash in the password text
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptHashData(lngHashHwd, strPassword, Strings.Len(strPassword), 0L))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptHashData!", Constants.vbExclamation | Constants.vbOKOnly, "Decryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Create a session key from the hash object
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptDeriveKey(m_lngCryptContext, lngCipherType, lngHashHwd, 0L, ref lngHkey))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptDeriveKey!", Constants.vbExclamation | Constants.vbOKOnly, "Decryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Destroy hash object
			// ---------------------------------------------------------------------------
			if (lngHashHwd != 0) {
				lngRetCode = CryptDestroyHash(lngHashHwd);
			}
			lngHashHwd = 0;

			// ---------------------------------------------------------------------------
			// Prepare data for decryption.
			// ---------------------------------------------------------------------------
			lngCryptLength = Strings.Len(m_strInputData);
			lngCryptBufLen = lngCryptLength * 2;
			strCryptBuffer = Strings.StrDup(Convert.ToInt32(lngCryptBufLen), Constants.vbNullChar);
			Strings.LSet(strCryptBuffer == m_strInputData, strCryptBuffer.Length);

			// ---------------------------------------------------------------------------
			// Decrypt the text data
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptDecrypt(lngHkey, 0L, 1L, 0L, strCryptBuffer, ref lngCryptLength))) {

				if (GetLastError() == 0) {
				} else {
					Interaction.MsgBox("Error " + Convert.ToString(GetLastError()) + " during CryptDecrypt!", Constants.vbExclamation | Constants.vbOKOnly, "Decryption Errors");
					goto CleanUp;
				}
			}

			// ---------------------------------------------------------------------------
			// Return the decrypted data string in a byte array.
			// ---------------------------------------------------------------------------
			strOutputData = Strings.Mid(strCryptBuffer, 1, lngCryptLength);
			m_abytOutputData = StringToByteArray(strOutputData);
			functionReturnValue = true;
			CleanUp:
			// successful finish

			// ---------------------------------------------------------------------------
			// Destroy session key.
			// ---------------------------------------------------------------------------
			if (lngHkey != 0) {
				lngRetCode = CryptDestroyKey(lngHkey);
			}

			// ---------------------------------------------------------------------------
			// Destroy key exchange key handle
			// ---------------------------------------------------------------------------
			if (lngHExchgKey != 0) {
				lngRetCode = CryptDestroyKey(lngHExchgKey);
			}

			// ---------------------------------------------------------------------------
			// Destroy hash object
			// ---------------------------------------------------------------------------
			if (lngHashHwd != 0) {
				lngRetCode = CryptDestroyHash(lngHashHwd);
			}

			lngHashHwd = 0;
			strPassword = Strings.StrDup(250, 0);
			return functionReturnValue;
			CryptoDecrypt_Error:

			// ---------------------------------------------------------------------------
			// An error ocurred during the decryption process
			// ---------------------------------------------------------------------------
			Interaction.MsgBox("Error: " + Convert.ToString(err().Number) + "  " + err().Description + Constants.vbCrLf + Constants.vbCrLf + "A critical error ocurred during the decryption process.", Constants.vbCritical | Constants.vbOKOnly, "Decryption Errors");

			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;

		}

		public bool Encrypt(int intHashType = 1, int intCipherType = 1)
		{

			// ***************************************************************************
			// Routine:       Encrypt
			//
			// Description:   Encrypting files with the CryptoAPI is a four-step process.
			//                First, select a CSP to handle the encryption. Second, create
			//                a hash object, and base that hash object around the password
			//                data. Third, create a key object based on this hash.
			//                Finally, use a key to encrypt the data.  Defaults to values
			//                that come with the default provider (56-bit)
			//
			// Parameters:    intHashType - (Optional) [Default] 1=Use MD5 hash algorithm
			//                    Selection:   1=MD5  2=MD4  3=MD2  4=SHA
			//                intCipherType - (Optional) [Default] 1=Use RC4 algorithm
			//                    Selection:  (Default Provider)   1=RC4  2=RC2  3=DES
			//                                (Enhanced Provider)  4=3DES 5=3DES_112
			//
			// Returns:       TRUE/FALSE based on completion

			// ---------------------------------------------------------------------------
			// Encrypt the data
			// ---------------------------------------------------------------------------
			return CryptoEncrypt(intHashType, intCipherType);

		}

		private bool CryptoEncrypt(int intHashType, int intCipherType)
		{
			bool functionReturnValue = false;

			// ***************************************************************************
			// Routine:       CryptoEncrypt
			//
			// Description:   Encrypting files with the CryptoAPI is a four-step process.
			//                First, select a CSP to handle the encryption. Second, create
			//                a hash object, and base that hash object around the password
			//                data. Third, create a key object based on this hash.
			//                Finally, use a key to encrypt the data.
			//
			// Returns:       TRUE/FALSE based on completion

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			long lngHashHwd = 0;
			// Hash handle
			long lngHkey = 0;
			long lngRetCode = 0;
			// return value from an API call
			long lngHashType = 0;
			long lngLength = 0;
			long lngCipherType = 0;
			long lngHExchgKey = 0;
			long lngCryptLength = 0;
			long lngCryptBufLen = 0;
			string strCryptBuffer = null;
			string strOutputData = null;
			string strPassword = null;

			// ---------------------------------------------------------------------------
			// Initialize variables
			// ---------------------------------------------------------------------------
			functionReturnValue = false;
			// preset to FALSE
			m_abytOutputData = null;
			strOutputData = "";
			strCryptBuffer = "";
			strPassword = "";

			// ---------------------------------------------------------------------------
			// If bad hash or cipher selection then leave
			// ---------------------------------------------------------------------------
			lngHashType = GetHashType(intHashType, ref lngLength);
			if (lngHashType == 0) {
				Interaction.MsgBox("This hash selection is not supported.", Constants.vbExclamation | Constants.vbOKOnly, "Wrong Encrypt Hash Selection");
				Terminate();
				return functionReturnValue;
				// Failed.  Time to leave.
			}

			lngCipherType = GetCipherType(intCipherType);
			if (lngCipherType == 0) {
				Terminate();
				return functionReturnValue;
				// Failed.  Time to leave.
			}

			// ---------------------------------------------------------------------------
			// Aquire the provider handle
			// ---------------------------------------------------------------------------
			if (m_lngCryptContext == 0) {
				if (!GetProvider()) {
					Terminate();
					return functionReturnValue;
					// Failed.  Time to leave.
				}
			}

			 // ERROR: Not supported in C#: OnErrorStatement

			// ---------------------------------------------------------------------------
			// convert password to string
			// ---------------------------------------------------------------------------
			if (Information.UBound(m_abytPWord) > 0) {
				strPassword = ByteArrayToString(m_abytPWord);
			} else {
				if (m_blnUseDefaultPWD) {
					m_abytPWord = GetPassword(true);
					// Use the default password
					strPassword = ByteArrayToString(m_abytPWord);
				}
			}

			// ---------------------------------------------------------------------------
			// Create a hash object
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptCreateHash(m_lngCryptContext, lngHashType, 0L, 0L, ref lngHashHwd))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptCreateHash!", Constants.vbExclamation | Constants.vbOKOnly, "Encryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Hash in the password text
			// ---------------------------------------------------------------------------
			if (!Convert.ToBoolean(CryptHashData(lngHashHwd, strPassword, Strings.Len(strPassword), 0L))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptHashData!", Constants.vbExclamation | Constants.vbOKOnly, "Encryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Create a session key from the hash object
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptDeriveKey(m_lngCryptContext, lngCipherType, lngHashHwd, 0L, ref lngHkey))) {
				Interaction.MsgBox("Error: " + Convert.ToString(GetLastError()) + " during CryptDeriveKey!", Constants.vbExclamation | Constants.vbOKOnly, "Encryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Destroy hash object
			// ---------------------------------------------------------------------------
			if (lngHashHwd != 0) {
				lngRetCode = CryptDestroyHash(lngHashHwd);
			}
			lngHashHwd = 0;

			// ---------------------------------------------------------------------------
			// Prepare data for encryption.
			// ---------------------------------------------------------------------------
			lngCryptLength = Strings.Len(m_strInputData);
			lngCryptBufLen = lngCryptLength * 2;
			strCryptBuffer = Strings.StrDup(Convert.ToInt32(lngCryptBufLen), Constants.vbNullChar);
			Strings.LSet(strCryptBuffer == m_strInputData, strCryptBuffer.Length);

			// ---------------------------------------------------------------------------
			// Encrypt the text data
			// ---------------------------------------------------------------------------

			if (!Convert.ToBoolean(CryptEncrypt(lngHkey, 0L, 1L, 0L, strCryptBuffer, ref lngCryptLength, lngCryptBufLen))) {
				Interaction.MsgBox("Bytes required:" + Convert.ToString(lngCryptBufLen) + Constants.vbCrLf + Constants.vbCrLf + "Error: " + Convert.ToString(GetLastError()) + " during CryptEncrypt!", Constants.vbExclamation | Constants.vbOKOnly, "Encryption Errors");
				goto CleanUp;
			}

			// ---------------------------------------------------------------------------
			// Return the encrypted data string in a byte array
			// ---------------------------------------------------------------------------
			strOutputData = Strings.Mid(strCryptBuffer, 1, lngCryptLength);
			m_abytOutputData = StringToByteArray(strOutputData);
			functionReturnValue = true;
			CleanUp:
			// Successful finish

			// ---------------------------------------------------------------------------
			// Destroy session key.
			// ---------------------------------------------------------------------------
			if (lngHkey != 0) {
				lngRetCode = CryptDestroyKey(lngHkey);
			}

			// ---------------------------------------------------------------------------
			// Destroy key exchange key handle
			// ---------------------------------------------------------------------------
			if (lngHExchgKey != 0) {
				lngRetCode = CryptDestroyKey(lngHExchgKey);
			}

			// ---------------------------------------------------------------------------
			// Destroy hash object
			// ---------------------------------------------------------------------------
			if (lngHashHwd != 0) {
				lngRetCode = CryptDestroyHash(lngHashHwd);
			}

			// ---------------------------------------------------------------------------
			// Empty variables
			// ---------------------------------------------------------------------------
			lngHashHwd = 0;
			strPassword = Strings.StrDup(250, 0);
			return functionReturnValue;
			CryptoEncrypt_Error:

			// ---------------------------------------------------------------------------
			// An error ocurred during the encryption process
			// ---------------------------------------------------------------------------
			Interaction.MsgBox("Error: " + Convert.ToString(err().Number) + "  " + err().Description + Constants.vbCrLf + Constants.vbCrLf + "A critical error ocurred during the encryption process.", Constants.vbCritical | Constants.vbOKOnly, "Encryption Error");

			 // ERROR: Not supported in C#: ResumeStatement

			return functionReturnValue;

		}

		private long GetHashType(int intChoice, ref long lngLength)
		{
			long functionReturnValue = 0;

			// ---------------------------------------------------------------------------
			// Determine the type of hash algorithm to use.
			// 1=MD5  2=MD4  3=MD2  4=SHA-1
			// ---------------------------------------------------------------------------
			switch (intChoice) {

				case 1:
					// use MD5 algorithm creates a 128-bit output
					functionReturnValue = CALG_MD5;
					lngLength = 16;

					break;
				case 2:
					// use MD4 algorithm creates a 128-bit output
					functionReturnValue = CALG_MD4;
					lngLength = 16;

					break;
				case 3:
					// use MD2 algorithm creates a 128-bit output
					functionReturnValue = CALG_MD2;
					lngLength = 16;

					break;
				case 4:
					// use SHA-1 algorithm creates a 160-bit output
					functionReturnValue = CALG_SHA1;
					lngLength = 20;

					break;
				default:
					// invalid hash selection
					functionReturnValue = 0;
					lngLength = 0;
					break;
			}
			return functionReturnValue;

		}

		private long GetCipherType(int intChoice)
		{
			long functionReturnValue = 0;

			// ---------------------------------------------------------------------------
			// Determine the type of Encyption/Decryption algorithm to use.
			//     Default Provider:   1 = RC4    2= RC2    3=DES
			//     Enhanced Provider:  4 = 3DES   5 = 3DES_112
			// ---------------------------------------------------------------------------
			m_blnBlockCipher = true;
			// preset to TRUE

			// if using the Enhanced Provider
			if (m_blnEnhancedProvider) {
				switch (intChoice) {
					case 1:
						// Stream cipher
						functionReturnValue = CALG_RC4;
						m_blnBlockCipher = false;

						break;
					case 2:
						functionReturnValue = CALG_RC2;
						break;
					case 3:
						functionReturnValue = CALG_DES;
						break;
					case 4:
						functionReturnValue = CALG_3DES;
						break;
					case 5:
						functionReturnValue = CALG_3DES_112;
						break;
					default:
						Interaction.MsgBox("Enhanced provider does not support cipher selected.", Constants.vbExclamation | Constants.vbOKOnly, "Wrong Cipher Selection");
						functionReturnValue = 0;
						break;
				}
			} else {
				switch (intChoice) {
					case 1:
						// Stream ciphers
						functionReturnValue = CALG_RC4;
						m_blnBlockCipher = false;

						break;
					// block ciphers
					case 2:
						functionReturnValue = CALG_RC2;
						break;
					case 3:
						functionReturnValue = CALG_DES;
						break;
					default:
						Interaction.MsgBox("Default provider does not support Triple DES ciphers.", Constants.vbExclamation | Constants.vbOKOnly, "Wrong Cipher Selection");
						functionReturnValue = 0;
						break;
				}
			}
			return functionReturnValue;

		}

		public byte[] StringToByteArray(object varInput)
		{
			byte[] functionReturnValue = null;

			// ***************************************************************************
			// Routine:       StringToByteArray
			//
			// Description:   Converts a string of data into a byte array [Range 0, 255]
			//
			// Parameters:    strInput - data string to be converted into a byte array
			//
			// Returns:       Byte array
			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			long lngIndex = 0;
			long lngLength = 0;
			byte[] bytBuffer = null;
			byte[] bytData = null;

			// ---------------------------------------------------------------------------
			// Store length of data string in a variable.  Speeds up the process by not
			// having to constantly evaluate the data length.  Works great with loops
			// and long strings of data.  Good habit to get into.
			// ---------------------------------------------------------------------------
			lngLength = Strings.Len(varInput);
			if (lngLength < 1) {
				bytData = new byte[1];
				functionReturnValue = bytData;
				return functionReturnValue;
			}

			// ---------------------------------------------------------------------------
			// Resize the array based on length on input string
			// ---------------------------------------------------------------------------
			bytBuffer = new byte[lngLength + 1];
			bytData = new byte[lngLength + 1];

			// ---------------------------------------------------------------------------
			// Convert each character in the data string to its ASCII numeric equivalent.
			// I use the VB function CByte() because sometimes the ASC() function returns
			// data that does not convert to a value of 0 to 255 cleanly.
			// ---------------------------------------------------------------------------
			for (lngIndex = 0; lngIndex <= lngLength - 1; lngIndex++) {
				bytBuffer[lngIndex] = Convert.ToByte(Strings.Asc(Strings.Mid(varInput, lngIndex + 1, 1)));
			}

			// ---------------------------------------------------------------------------
			// Copy data from memory to variable
			// ---------------------------------------------------------------------------
			CopyMemory(bytData[0], bytBuffer[0], lngLength);

			// ---------------------------------------------------------------------------
			// Return the byte array
			// ---------------------------------------------------------------------------
			functionReturnValue = bytData;

			// ---------------------------------------------------------------------------
			// Resize arrays to smallest size
			// ---------------------------------------------------------------------------
			bytData = new byte[1];
			bytBuffer = new byte[1];
			return functionReturnValue;

		}

		public float Rnd2(float sngLow, float sngHigh)
		{

			// ***************************************************************************
			// Routine:       Rnd2
			//
			// Description:   Create a random value between two values.  Used for desired
			//                range values only.
			//
			// Parameters:    sngLow  - Low end value
			//                sngHign - High end value
			//
			// Returns:       A random generated value

			// ---------------------------------------------------------------------------
			// Generate a value between two given values
			// ---------------------------------------------------------------------------
			VBMath.Randomize(GetTickCount() + Convert.ToDouble(DateAndTime.Now.ToOADate()));
			// Reseed with system time (2 ways)
			return (Rnd() * (sngHigh - sngLow)) + sngLow;

		}

		private byte[] GetPassword(bool blnUseDefaultPWD = true)
		{
			byte[] functionReturnValue = null;

			// ***************************************************************************
			// Routine:       GetPassword
			//
			// Description:   Determines if the default password is to be used or if one
			//                is to be created on the fly.  A random generated password is
			//                used as an additional seed value for random data only.
			//                "On the fly" passwords are usually used for additional input
			//                for hashing and then passed on as extra seeding for the random
			//                number generator.
			//
			// NOTE:          Before compiling this module, define your own default
			//                password.  I do not think you want to use this one.
			//                ("use.default-password" with mixed case)
			//
			// Parameters:    blnChoice - (Optional) [Default] TRUE - use the default
			//                      password as defined in this routine
			//                      FALSE - create a twenty character password using
			//                      mixed case with numbers
			//
			// Returns:       Password inside a byte array

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			string strPassword = null;
			byte[] abytPWord = null;

			// ---------------------------------------------------------------------------
			// If the request is to use the default password then load each character
			// separately.  This is faster and more difficult for a hacker to read the
			// default password.  Create your own.  This one is for demo purposes only.
			// ---------------------------------------------------------------------------

			if (blnUseDefaultPWD) {
				// size the password array
				abytPWord = new byte[21];

				// Load array with default password.  I use CByte() to make sure.
				// If you are really paranoid then convert CByte(Asc()) to their
				// decimal values.  But that makes it even more difficult for you
				// to read, too.
				abytPWord[0] = Convert.ToByte(Strings.Asc("u"));
				abytPWord[1] = Convert.ToByte(Strings.Asc("s"));
				abytPWord[2] = Convert.ToByte(Strings.Asc("E"));
				abytPWord[3] = Convert.ToByte(Strings.Asc("."));
				abytPWord[4] = Convert.ToByte(Strings.Asc("d"));
				abytPWord[5] = Convert.ToByte(Strings.Asc("e"));
				abytPWord[6] = Convert.ToByte(Strings.Asc("F"));
				abytPWord[7] = Convert.ToByte(Strings.Asc("a"));
				abytPWord[8] = Convert.ToByte(Strings.Asc("U"));
				abytPWord[9] = Convert.ToByte(Strings.Asc("L"));
				abytPWord[10] = Convert.ToByte(Strings.Asc("t"));
				abytPWord[11] = Convert.ToByte(Strings.Asc("-"));
				abytPWord[12] = Convert.ToByte(Strings.Asc("p"));
				abytPWord[13] = Convert.ToByte(Strings.Asc("a"));
				abytPWord[14] = Convert.ToByte(Strings.Asc("S"));
				abytPWord[15] = Convert.ToByte(Strings.Asc("s"));
				abytPWord[16] = Convert.ToByte(Strings.Asc("w"));
				abytPWord[17] = Convert.ToByte(Strings.Asc("O"));
				abytPWord[18] = Convert.ToByte(Strings.Asc("r"));
				abytPWord[19] = Convert.ToByte(Strings.Asc("d"));
			} else {
				// Create a random generated password 20 characters long
				// using printable characters
				strPassword = CreateSaltValue(20, true);

				// Initialize byte array
				abytPWord = null;
				// make sure array is empty
				abytPWord = new byte[1];
				// resize to smallest number of elements

				// convert password to byte array
				abytPWord = StringToByteArray(strPassword);
				strPassword = Strings.StrDup(250, 0);
				// empty variable
			}

			// ---------------------------------------------------------------------------
			// Return password in byte array format
			// ---------------------------------------------------------------------------
			functionReturnValue = abytPWord;

			// ---------------------------------------------------------------------------
			// Empty byte array
			// ---------------------------------------------------------------------------
			abytPWord = null;
			// make sure array is empty
			abytPWord = new byte[1];
			return functionReturnValue;
			// resize to smallest number of elements

		}

		private bool GetProvider()
		{
			bool functionReturnValue = false;

			// ***************************************************************************
			// Routine:       GetProvider
			//
			// Description:   Get the MS Provider.  If wanting to use 128-bit cipher
			//                strength then set the property EnhancedProvider = TRUE
			//
			// Returns:       TRUE/FALSE based on completion

			// ---------------------------------------------------------------------------
			// Define local variables
			// ---------------------------------------------------------------------------
			string strTemp = null;
			string strProvider1 = null;
			string strProvider2 = null;
			string strErrorMsg = null;

			 // ERROR: Not supported in C#: OnErrorStatement

			// ---------------------------------------------------------------------------
			// Prepare string buffers
			// ---------------------------------------------------------------------------
			strTemp = Constants.vbNullChar;
			strProvider1 = MS_ENHANCED_PROVIDER + Constants.vbNullChar;
			strProvider2 = MS_DEFAULT_PROVIDER + Constants.vbNullChar;

			// ---------------------------------------------------------------------------
			// Gain Access To CryptoAPI.
			// ---------------------------------------------------------------------------
			if (m_blnEnhancedProvider) {
				// Attempt to acquire a handle to the ENHANCED (128-bit) key container.
				if (Convert.ToBoolean(CryptAcquireContext(ref m_lngCryptContext, strTemp, strProvider1, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT))) {
					functionReturnValue = true;
					return functionReturnValue;
				}
			} else {
				// Attempt to acquire a handle to the DEFAULT (56-bit) key container.
				if (Convert.ToBoolean(CryptAcquireContext(ref m_lngCryptContext, strTemp, strProvider2, PROV_RSA_FULL, CRYPT_VERIFYCONTEXT))) {
					functionReturnValue = true;
					return functionReturnValue;
				}
			}

			// ---------------------------------------------------------------------------
			// If no luck acquiring a provider handle then create default key container
			// using the current user's logon ID.  Make sure this is not shared because
			// other users will have problems.
			// ---------------------------------------------------------------------------
			if (Convert.ToBoolean(CryptAcquireContext(ref m_lngCryptContext, strTemp, strTemp, PROV_RSA_FULL, CRYPT_NEWKEYSET))) {
				functionReturnValue = true;
			} else {
				// Failed to aquire provider handle
				strErrorMsg = "Error creating DEFAULT key container - " + Convert.ToString(Err().LastDllError);
				Interaction.MsgBox(strErrorMsg, Constants.vbCritical | Constants.vbOKOnly, "Cannot access CryptoAPI");
				functionReturnValue = false;
			}
			return functionReturnValue;

		}


		private void Initialize()
		{
			// ***************************************************************************
			// Routine:       Class_Initialize
			//
			// Description:   When class is initialized, we aquire the provider handle.

			// ---------------------------------------------------------------------------
			// Get the provider handle
			// ---------------------------------------------------------------------------
			m_blnEnhancedProvider = false;
			m_blnUseDefaultPWD = true;
			m_abytPWord = new byte[1];

		}


		private void Terminate()
		{
			// ***************************************************************************
			// Routine:       Class_Terminate
			//
			// Description:   When class is terminated, release module level data.

			// ---------------------------------------------------------------------------
			// Define variables
			// ---------------------------------------------------------------------------
			long lngRetValue = 0;

			// ---------------------------------------------------------------------------
			// If we managed to load a Microsoft Provider ID, then release it.
			// ---------------------------------------------------------------------------
			if (m_lngCryptContext != 0) {
				lngRetValue = CryptReleaseContext(m_lngCryptContext, 0L);
			}
		}
	}
}
