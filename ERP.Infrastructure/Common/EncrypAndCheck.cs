using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Common
{
    /// <summary>
    /// 加解密
    /// </summary>
    public static class EncrypAndCheck
    {
        static string CryptKey = "0t3q4fHJnyAVndj66+gBmmj6FkemW3xt/7uOgMHoKLg=";
        static string CryptIV = "DZVKpnvwxRhErICEoMTTOw==";

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="cryptString">原文</param>
        /// <returns>密文</returns>
        public static string EncryptToBase64(this string cryptString)
        {
            byte[] cryptKey = System.Convert.FromBase64String(CryptKey);
            byte[] cryptIV = System.Convert.FromBase64String(CryptIV);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(cryptString);
            System.Security.Cryptography.RijndaelManaged rijndaelManaged = new System.Security.Cryptography.RijndaelManaged();
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(cryptKey, cryptIV), System.Security.Cryptography.CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            return System.Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cryptString">密文</param>
        /// <returns>原文</returns>
        public static string DecryptToString(this string cryptString)
        {
            //if (cryptString.Length != 24)
            //    return cryptString;

            byte[] cryptKey = System.Convert.FromBase64String(CryptKey);
            byte[] cryptIV = System.Convert.FromBase64String(CryptIV);
            byte[] array = System.Convert.FromBase64String(cryptString);
            //if (array.Length != 16)
            //    return cryptString;

            System.Security.Cryptography.RijndaelManaged rijndaelManaged = new System.Security.Cryptography.RijndaelManaged();
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(cryptKey, cryptIV), System.Security.Cryptography.CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}
