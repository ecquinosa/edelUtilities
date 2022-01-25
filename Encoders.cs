using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EdelUtilities
{
    public sealed class Encoders
    {

        #region " Encrypt - Decrypt "

        public string Encrypt(string Word)
        {
            if (Word == "") return "";
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(Word));
        }

        public string Decrypt(string Word)
        {
            try
            {
                if (Word == "") return "";
                return Encoding.ASCII.GetString(Convert.FromBase64String(Word));
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region " Masker "  

        private readonly string Token = "87W3bN@sTeR@ACC.PH=>2021(^,')";

        public string EnMask(string Word)
        {
            try
            {

                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                var des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(Word);
                var ms = new MemoryStream();

                byKey = Encoding.UTF8.GetBytes(Token.Substring(0, 8));

                var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                var Result = Convert.ToBase64String(ms.ToArray());

                return Result;
            }
            catch
            {
                return "";
            }
        }

        public string DeMask(string Word)
        {
            try
            {
                Word = Word.Replace(" ", "+");

                var encoding = Encoding.UTF8;
                var pstrDecrKey = Token;
                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                var des = new DESCryptoServiceProvider();
                var ms = new MemoryStream();
                byte[] inputByteArray = new byte[Word.Length];

                byKey = Encoding.UTF8.GetBytes(pstrDecrKey.Substring(0, 8));
                inputByteArray = Convert.FromBase64String(Word);

                var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }

        }

        #endregion

    }
}
