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
using System.Text;
using System.IO;
namespace _4PosBackOffice.NET
{
	public class clsRC4
	{
		[DllImport("kernel32", EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern void CopyMemory(long Destination, long Source, long Length);

		private string m_Key;
		private int[] m_sBox = new int[256];
		private byte[] m_bytIndex = new byte[64];
		private byte[] m_bytReverseIndex = new byte[256];
		private const byte k_bytEqualSign = 61;
		private const byte k_bytMask1 = 3;
		private const byte k_bytMask2 = 15;
		private const byte k_bytMask3 = 63;
		private const byte k_bytMask4 = 192;
		private const byte k_bytMask5 = 240;
		private const byte k_bytMask6 = 252;
		private const byte k_bytShift2 = 4;
		private const byte k_bytShift4 = 16;
		private const byte k_bytShift6 = 64;

		private const long k_lMaxBytesPerLine = 152;
		private void Initialize64()
		{
			int x = 0;
			int y = 0;
			for (x = 0; x <= 51; x++) {
				m_bytIndex[x] = x + 65;
			}
			for (x = 52; x <= 61; x++) {
				m_bytIndex[x] = x - 4;
				m_bytReverseIndex[x - 4] = x;
			}
			m_bytIndex[62] = 43;
			//Asc("+")
			m_bytIndex[63] = 47;
			//Asc("/")
			y = 0;
			for (x = 65; x <= 122; x++) {
				m_bytReverseIndex[x] = y;
				y = y + 1;
			}
			m_bytReverseIndex[43] = 62;
			//Asc("+")
			m_bytReverseIndex[47] = 63;
			//Asc("/")
		}

		public string Decode64(string sInput)
		{
			string functionReturnValue = null;
			if (string.IsNullOrEmpty(sInput))
				return functionReturnValue;
			functionReturnValue = Encoding.ASCII.GetString(DecodeArray64(sInput));
			return functionReturnValue;
		}

		public byte[] DecodeArray64(string sInput)
		{
			if (m_bytReverseIndex[47] != 63)
				Initialize64();
			byte[] bytInput = null;
			byte[] bytWorkspace = null;
			byte[] bytResult = null;
			long lInputCounter = 0;
			long lWorkspaceCounter = 0;

			string innerString = Strings.Replace(sInput, Constants.vbCrLf, "");
			string outerString = Strings.Replace(innerString, "=", "");
			bytInput = UTF8Encoding.UTF8.GetBytes(outerString);
			bytWorkspace = new byte[(Information.UBound(bytInput) * 2) + 1];
			lWorkspaceCounter = Information.LBound(bytWorkspace);
			for (lInputCounter = Information.LBound(bytInput); lInputCounter <= Information.UBound(bytInput); lInputCounter++) {
				bytInput[lInputCounter] = m_bytReverseIndex[bytInput[lInputCounter]];
			}

			for (lInputCounter = Information.LBound(bytInput); lInputCounter <= (Information.UBound(bytInput) - ((Information.UBound(bytInput) % 8) + 8)); lInputCounter += 8) {
				bytWorkspace[lWorkspaceCounter] = (bytInput[lInputCounter] * k_bytShift2) + (bytInput[lInputCounter + 2] / k_bytShift4);
				bytWorkspace[lWorkspaceCounter + 1] = ((bytInput[lInputCounter + 2] & k_bytMask2) * k_bytShift4) + (bytInput[lInputCounter + 4] / k_bytShift2);
				bytWorkspace[lWorkspaceCounter + 2] = ((bytInput[lInputCounter + 4] & k_bytMask1) * k_bytShift6) + bytInput[lInputCounter + 6];
				lWorkspaceCounter = lWorkspaceCounter + 3;
			}

			switch ((Information.UBound(bytInput) % 8)) {
				case 3:
					bytWorkspace[lWorkspaceCounter] = (bytInput[lInputCounter] * k_bytShift2) + (bytInput[lInputCounter + 2] / k_bytShift4);
					break;
				case 5:
					bytWorkspace[lWorkspaceCounter] = (bytInput[lInputCounter] * k_bytShift2) + (bytInput[lInputCounter + 2] / k_bytShift4);
					bytWorkspace[lWorkspaceCounter + 1] = ((bytInput[lInputCounter + 2] & k_bytMask2) * k_bytShift4) + (bytInput[lInputCounter + 4] / k_bytShift2);
					lWorkspaceCounter = lWorkspaceCounter + 1;
					break;
				case 7:
					bytWorkspace[lWorkspaceCounter] = (bytInput[lInputCounter] * k_bytShift2) + (bytInput[lInputCounter + 2] / k_bytShift4);
					bytWorkspace[lWorkspaceCounter + 1] = ((bytInput[lInputCounter + 2] & k_bytMask2) * k_bytShift4) + (bytInput[lInputCounter + 4] / k_bytShift2);
					bytWorkspace[lWorkspaceCounter + 2] = ((bytInput[lInputCounter + 4] & k_bytMask1) * k_bytShift6) + bytInput[lInputCounter + 6];
					lWorkspaceCounter = lWorkspaceCounter + 2;
					break;
			}

			bytResult = new byte[lWorkspaceCounter + 1];
			if (Information.LBound(bytWorkspace) == 0)
				lWorkspaceCounter = lWorkspaceCounter + 1;
			CopyMemory(VarPtr.VarPtr(bytResult[Information.LBound(bytResult)]), VarPtr.VarPtr(bytWorkspace[Information.LBound(bytWorkspace)]), lWorkspaceCounter);
			return bytResult;
		}

		public string Encode64(ref string sInput)
		{
			string functionReturnValue = null;
			if (string.IsNullOrEmpty(sInput))
				return functionReturnValue;
			byte[] bytTemp = null;
			bytTemp = Encoding.ASCII.GetBytes(sInput);
			functionReturnValue = EncodeArray64(ref bytTemp);
			return functionReturnValue;
		}

		public string EncodeArray64(ref byte[] bytInput)
		{
			string functionReturnValue = null;
			 // ERROR: Not supported in C#: OnErrorStatement


			if (m_bytReverseIndex[47] != 63)
				Initialize64();
			byte[] bytWorkspace = null;
			byte[] bytResult = null;
			byte[] bytCrLf = new byte[4];
			long lCounter = 0;
			long lWorkspaceCounter = 0;
			long lLineCounter = 0;
			long lCompleteLines = 0;
			long lBytesRemaining = 0;
			long lpWorkSpace = 0;
			long lpResult = 0;
			long lpCrLf = 0;

			if (Information.UBound(bytInput) < 1024) {
				bytWorkspace = new byte[(Information.LBound(bytInput) + 4096) + 1];
			} else {
				bytWorkspace = new byte[(Information.UBound(bytInput) * 4) + 1];
			}

			lWorkspaceCounter = Information.LBound(bytWorkspace);

			for (lCounter = Information.LBound(bytInput); lCounter <= (Information.UBound(bytInput) - ((Information.UBound(bytInput) % 3) + 3)); lCounter += 3) {
				bytWorkspace[lWorkspaceCounter] = m_bytIndex[(bytInput[lCounter] / k_bytShift2)];
				bytWorkspace[lWorkspaceCounter + 2] = m_bytIndex[((bytInput[lCounter] & k_bytMask1) * k_bytShift4) + ((bytInput[lCounter + 1]) / k_bytShift4)];
				bytWorkspace[lWorkspaceCounter + 4] = m_bytIndex[((bytInput[lCounter + 1] & k_bytMask2) * k_bytShift2) + (bytInput[lCounter + 2] / k_bytShift6)];
				bytWorkspace[lWorkspaceCounter + 6] = m_bytIndex[bytInput[lCounter + 2] & k_bytMask3];
				lWorkspaceCounter = lWorkspaceCounter + 8;
			}

			switch ((Information.UBound(bytInput) % 3)) {
				case 0:
					bytWorkspace[lWorkspaceCounter] = m_bytIndex[(bytInput[lCounter] / k_bytShift2)];
					bytWorkspace[lWorkspaceCounter + 2] = m_bytIndex[(bytInput[lCounter] & k_bytMask1) * k_bytShift4];
					bytWorkspace[lWorkspaceCounter + 4] = k_bytEqualSign;
					bytWorkspace[lWorkspaceCounter + 6] = k_bytEqualSign;
					break;
				case 1:
					bytWorkspace[lWorkspaceCounter] = m_bytIndex[(bytInput[lCounter] / k_bytShift2)];
					bytWorkspace[lWorkspaceCounter + 2] = m_bytIndex[((bytInput[lCounter] & k_bytMask1) * k_bytShift4) + ((bytInput[lCounter + 1]) / k_bytShift4)];
					bytWorkspace[lWorkspaceCounter + 4] = m_bytIndex[(bytInput[lCounter + 1] & k_bytMask2) * k_bytShift2];
					bytWorkspace[lWorkspaceCounter + 6] = k_bytEqualSign;
					break;
				case 2:
					bytWorkspace[lWorkspaceCounter] = m_bytIndex[(bytInput[lCounter] / k_bytShift2)];
					bytWorkspace[lWorkspaceCounter + 2] = m_bytIndex[((bytInput[lCounter] & k_bytMask1) * k_bytShift4) + ((bytInput[lCounter + 1]) / k_bytShift4)];
					bytWorkspace[lWorkspaceCounter + 4] = m_bytIndex[((bytInput[lCounter + 1] & k_bytMask2) * k_bytShift2) + ((bytInput[lCounter + 2]) / k_bytShift6)];
					bytWorkspace[lWorkspaceCounter + 6] = m_bytIndex[bytInput[lCounter + 2] & k_bytMask3];
					break;
			}

			lWorkspaceCounter = lWorkspaceCounter + 8;

			if (lWorkspaceCounter <= k_lMaxBytesPerLine) {
				functionReturnValue = Strings.Left(bytWorkspace.ToString(), Strings.InStr(1, bytWorkspace.ToString(), "") - 1);
			} else {
				bytCrLf[0] = 13;
				bytCrLf[1] = 0;
				bytCrLf[2] = 10;
				bytCrLf[3] = 0;
				bytResult = new byte[Information.UBound(bytWorkspace) + 1];
				lpWorkSpace = VarPtr.VarPtr(bytWorkspace[Information.LBound(bytWorkspace)]);
				lpResult = VarPtr.VarPtr(bytResult[Information.LBound(bytResult)]);
				lpCrLf = VarPtr.VarPtr(bytCrLf[Information.LBound(bytCrLf)]);
				lCompleteLines = Conversion.Fix(lWorkspaceCounter / k_lMaxBytesPerLine);

				for (lLineCounter = 0; lLineCounter <= lCompleteLines; lLineCounter++) {
					CopyMemory(lpResult, lpWorkSpace, k_lMaxBytesPerLine);
					lpWorkSpace = lpWorkSpace + k_lMaxBytesPerLine;
					lpResult = lpResult + k_lMaxBytesPerLine;
					CopyMemory(lpResult, lpCrLf, 4L);
					lpResult = lpResult + 4L;
				}

				lBytesRemaining = lWorkspaceCounter - (lCompleteLines * k_lMaxBytesPerLine);
				if (lBytesRemaining > 0)
					CopyMemory(lpResult, lpWorkSpace, lBytesRemaining);
				functionReturnValue = Strings.Left(bytResult.ToString(), Strings.InStr(1, bytResult.ToString(), "") - 1);
			}
			return functionReturnValue;
			ErrorHandler:

			bytResult = null;
			functionReturnValue = bytResult.ToString();
			return functionReturnValue;
		}

		public bool EncryptFile(string InFile, string OutFile, bool Overwrite, string Key = "", bool OutputIn64 = false)
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (FileExist(InFile) == false) {
				functionReturnValue = false;
				return functionReturnValue;
			}
			if (FileExist(OutFile) == true & Overwrite == false) {
				functionReturnValue = false;
				return functionReturnValue;
			}
			int FileO = 0;
			byte[] Buffer = null;
			FileO = FileSystem.FreeFile();
			FileStream inStream = new FileStream(FileO.ToString(), FileMode.Open);
			BinaryReader binRead = new BinaryReader(inStream);

			Buffer = new byte[FileSystem.FileLen(FileO.ToString() - 1) + 1];
			Buffer = binRead.ReadBytes(FileSystem.FileLen(FileO.ToString() - 1));
			binRead.Close();
			inStream.Close();
			EncryptByte(Buffer, Key);
			if (FileExist(OutFile) == true)
				FileSystem.Kill(OutFile);
			FileO = FileSystem.FreeFile();

			FileStream outStream = new FileStream(FileO.ToString(), FileMode.Create);
			BinaryWriter binWrite = new BinaryWriter(outStream);
			if (OutputIn64 == true) {
				binWrite.Write(EncodeArray64(ref Buffer));
			} else {
				binWrite.Write(Buffer);
			}
			binWrite.Close();
			outStream.Close();
			functionReturnValue = true;
			return functionReturnValue;
			ErrorHandler:

			functionReturnValue = false;
			return functionReturnValue;
		}
		public bool DecryptFile(string InFile, string OutFile, bool Overwrite, string Key = "", bool IsFileIn64 = false)
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			if (FileExist(InFile) == false) {
				functionReturnValue = false;
				return functionReturnValue;
			}
			if (FileExist(OutFile) == true & Overwrite == false) {
				functionReturnValue = false;
				return functionReturnValue;
			}
			int FileO = 0;
			byte[] Buffer = null;
			FileO = FileSystem.FreeFile();
			FileStream inStream = new FileStream(FileO.ToString(), FileMode.Open);
			BinaryReader binRead = new BinaryReader(inStream);

			Buffer = new byte[FileSystem.FileLen(FileO.ToString())];
			Buffer = binRead.ReadBytes(FileSystem.FileLen(FileO.ToString()) - 1);
			binRead.Close();
			inStream.Close();

			if (IsFileIn64 == true)
				Buffer = DecodeArray64(Encoding.ASCII.GetString(Buffer));
			DecryptByte(Buffer, Key);
			if (FileExist(OutFile) == true)
				FileSystem.Kill(OutFile);
			FileO = FileSystem.FreeFile();
			FileStream outStream = new FileStream(FileO.ToString(), FileMode.Create);
			BinaryWriter binWrite = new BinaryWriter(outStream);
			binWrite.Write(Buffer);
			binWrite.Close();
			outStream.Close();

			functionReturnValue = true;
			return functionReturnValue;
			ErrorHandler:

			functionReturnValue = false;
			return functionReturnValue;
		}

		public void DecryptByte(byte[] byteArray, string Key = "")
		{
			EncryptByte(byteArray, Key);
		}
		public string EncryptString(string Text, string Key = "", bool OutputIn64 = false)
		{
			string functionReturnValue = null;
			byte[] byteArray = null;
			byteArray = Encoding.ASCII.GetBytes(Text);
			EncryptByte(byteArray, Key);
			functionReturnValue = Encoding.ASCII.GetString(byteArray);
			if (OutputIn64 == true)
				functionReturnValue = Encode64(ref EncryptString());
			return functionReturnValue;
		}
		public string DecryptString(string Text, string Key = "", bool IsTextIn64 = false)
		{
			byte[] byteArray = null;
			if (IsTextIn64 == true)
				Text = Decode64(Text);
			byteArray = Encoding.ASCII.GetBytes(Text);
			DecryptByte(byteArray, Key);
			return Encoding.ASCII.GetString(byteArray);
		}

		public void EncryptByte(byte[] byteArray, string Key = "")
		{
			long i = 0;
			long j = 0;
			byte Temp = 0;
			long Offset = 0;
			long OrigLen = 0;
			long CipherLen = 0;
			long CurrPercent = 0;
			long NextPercent = 0;
			int[] sBox = new int[256];

			if ((Strings.Len(Key) > 0))
				this.Key = Key;
			CopyMemory(sBox[0], m_sBox[0], 512);
			OrigLen = Information.UBound(byteArray) + 1;
			CipherLen = OrigLen;

			for (Offset = 0; Offset <= (OrigLen - 1); Offset++) {
				i = (i + 1) % 256;
				j = (j + sBox[i]) % 256;
				Temp = sBox[i];
				sBox[i] = sBox[j];
				sBox[j] = Temp;
				byteArray[Offset] = byteArray[Offset] ^ (sBox[(sBox[i] + sBox[j]) % 256]);
				if ((Offset >= NextPercent)) {
					CurrPercent = Conversion.Int((Offset / CipherLen) * 100);
					NextPercent = (CipherLen * ((CurrPercent + 1) / 100)) + 1;
					//RaiseEvent Progress(CurrPercent)
				}
			}
			//If (CurrPercent <> 100) Then RaiseEvent Progress(100)
		}
		private bool FileExist(string Filename)
		{
			bool functionReturnValue = false;
			 // ERROR: Not supported in C#: OnErrorStatement

			FileSystem.FileLen(Filename);
			functionReturnValue = true;
			return functionReturnValue;
			ErrorHandler:

			functionReturnValue = false;
			return functionReturnValue;
		}


		public string Key {
			set {
				long a = 0;
				long b = 0;
				byte Temp = 0;
				byte[] myKey = null;
				long KeyLen = 0;
				if ((m_Key == value))
					return;
				m_Key = value;
				//myKey = StrConv(m_Key, vbFromUnicode)
				myKey = Encoding.ASCII.GetBytes(m_Key);
				KeyLen = Strings.Len(m_Key);
				for (a = 0; a <= 255; a++) {
					m_sBox[a] = a;
				}
				for (a = 0; a <= 255; a++) {
					b = (b + m_sBox[a] + myKey[a % KeyLen]) % 256;
					Temp = m_sBox[a];
					m_sBox[a] = m_sBox[b];
					m_sBox[b] = Temp;
				}
			}
		}
	}
}
