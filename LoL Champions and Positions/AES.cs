using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace LoL_Champions_and_Positions
{
    class AES
    {
        public static byte[] EncryptStringToByte(string sourceText,ref byte[] key,ref byte[] IV)
        {

            if (sourceText == null || sourceText == Constants.STRING_EMPTY)
            {
                return null;
            }

            byte[] result;
            AesManaged aesAlg = new AesManaged();

            if (key == null || key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();

                key = aesAlg.Key;
                IV = aesAlg.IV;
            }
            else
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;
            }

            ICryptoTransform encryptor = aesAlg.CreateEncryptor();

            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt,encryptor, CryptoStreamMode.Write);
            StreamWriter swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(sourceText);
            swEncrypt.Close();
            csEncrypt.Close();
            result = msEncrypt.ToArray();

            return result;
        }

        public static string DecryptStringFromByte(byte[] sourceLine, byte[] key, byte[] IV)
        {
            if (sourceLine == null || sourceLine.Length == 0)
            {
                return null;
            }

            if (key == null || key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                return null;
            }

            AesManaged aesAlg = new AesManaged();
            aesAlg.Key = key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor();

            MemoryStream msDecrypt = new MemoryStream(sourceLine);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            StreamReader srDecrypt = new StreamReader(csDecrypt);

            string result = srDecrypt.ReadToEnd();

            return result;
        }
    }

}
