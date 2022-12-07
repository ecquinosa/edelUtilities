using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace EdelUtilities
{
    public partial class ubpDAO_EncryptDecrypt : UserControl
    {
        public ubpDAO_EncryptDecrypt()
        {
            InitializeComponent();
        }

        private void ubpDAO_EncryptDecrypt_Load(object sender, EventArgs e)
        {

        }

        //dev dc3cdfb50cf19cbab0906d03e4c22d66, prod 1ae292629c4214440508cd472ff0fdd4
        public string Cipher_Key_SIT = "dc3cdfb50cf19cbab0906d03e4c22d66";
        public string Cipher_Key_PROD = "1ae292629c4214440508cd472ff0fdd4";
        public string Cipher_Key = "";

        private string DAO_Encrypt(string plainText)
        {
            try
            {
                var KY = Encoding.UTF8.GetBytes(Cipher_Key);
                var aes = Aes.Create();

                aes.Key = KY;
                aes.GenerateIV();
                aes.Mode = CipherMode.CBC;

                var cipher = aes.CreateEncryptor(aes.Key, aes.IV);
                var Word1 = "";
                var Word2 = "";

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    var cipherData = ms.ToArray();

                    Word1 = Convert.ToBase64String(aes.IV);
                    Word2 = Convert.ToBase64String(cipherData);
                }

                return string.Format("{0}:{1}", Word1, Word2);
            }
            catch (Exception ex)
            {
                return "encryption failed";
            }
        }

        private string DAO_Decrypt(string Value, int Length)
        {
            try
            {
                var plainText = "";

                var Arr = Value.Split(':');
                var IV = Convert.FromBase64String(Arr[0]);
                var TX = Convert.FromBase64String(Arr[1]);
                var KY = Encoding.UTF8.GetBytes(Cipher_Key);
                var aes = Aes.Create();

                aes.Key = KY;
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.Zeros;

                var decipher = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(TX))
                {
                    using (var cs = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            plainText = sr.ReadToEnd();
                        }
                    }
                }

                return plainText.Substring(0, Length);
            }
            catch (Exception ex)
            {
                return "decryption failed";
            }
        }

        private string ToEncrypt(string Word)
        {
            try
            {
                if (Word == "") return "";
                var Mask = new Encoders();
                var ReWord = Mask.EnMask(Word);
                if (ReWord == "") return "";
                var NewWord = Mask.Encrypt(ReWord);
                if (NewWord == "") return "";
                return NewWord;
            }
            catch
            {
                return "";
            }
        }

        private string ToDecrypt(string Word)
        {
            try
            {
                var Mask = new Encoders();
                if (Word == "") return "";
                var ReWord = Mask.Decrypt(Word);
                if (ReWord == "") return "";
                var OrWord = Mask.DeMask(ReWord);
                if (OrWord == "") return "";
                return OrWord;
            }
            catch
            {
                return "";
            }
        }

        private static string encryptionKey = "ragMANOK2kx2014";
        public static string WSEncrypt(string clearText)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = System.Security.Cryptography.Aes.Create())
            {
                var pdb = new System.Security.Cryptography.Rfc2898DeriveBytes(encryptionKey, new byte[] { (byte)0x49, (byte)0x76, (byte)0x61, (byte)0x6E, (byte)0x20, (byte)0x4D, (byte)0x65, (byte)0x64, (byte)0x76, (byte)0x65, (byte)0x64, (byte)0x65, (byte)0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new System.Security.Cryptography.CryptoStream(ms, encryptor.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string WSDecrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var decryptor = System.Security.Cryptography.Aes.Create())
            {
                var pdb = new System.Security.Cryptography.Rfc2898DeriveBytes(encryptionKey, new byte[] { (byte)0x49, (byte)0x76, (byte)0x61, (byte)0x6E, (byte)0x20, (byte)0x4D, (byte)0x65, (byte)0x64, (byte)0x76, (byte)0x65, (byte)0x64, (byte)0x65, (byte)0x76 });
                decryptor.Key = pdb.GetBytes(32);
                decryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new System.Security.Cryptography.CryptoStream(ms, decryptor.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            //txtResult.Text = DAO_Encrypt(txtValue.Text);
            Cipher_Key = Cipher_Key_SIT;
            txtResult.Text = DAO_Decrypt(txtValue.Text, 12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            Cipher_Key = Cipher_Key_PROD;
            txtResult.Text = DAO_Decrypt(txtValue.Text,12);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = ToEncrypt(txtValue.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = ToDecrypt(txtValue.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string sourceFile = @"D:\WORK\Projects\PagIbig_LocalDB\bin\Debug\users2.txt";
            ////string encrypted = ToEncrypt(System.IO.File.ReadAllText(sourceFile));
            //string encrypted = Convert.ToBase64String(System.IO.File.ReadAllText(sourceFile));
            //System.IO.File.WriteAllText(sourceFile.Replace("2.txt", ".txt"), encrypted);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = WSEncrypt(txtValue.Text);
        }

        private void btnWSDecrypt_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = WSDecrypt(txtValue.Text);
        }       

        #region kyc encrypt/decrypt

        private static string encryptionKeyKyc = "@cCP@g1bIgPH3*";

        public static string EncryptDataKyc(string data)
        {
            AllcardEncryptDecrypt.EncryptDecrypt enc = new AllcardEncryptDecrypt.EncryptDecrypt(encryptionKeyKyc);
            string encryptedData = enc.TripleDesEncryptText(data);
            enc = null/* TODO Change to default(_) if this is not a reference type */;
            return encryptedData;
        }

        public static string DecryptDataKyc(string data)
        {
            AllcardEncryptDecrypt.EncryptDecrypt dec = new AllcardEncryptDecrypt.EncryptDecrypt(encryptionKeyKyc);
            string decryptedData = dec.TripleDesDecryptText(data);
            dec = null/* TODO Change to default(_) if this is not a reference type */;
            return decryptedData;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = EncryptDataKyc(txtValue.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "") return;
            txtResult.Text = DecryptDataKyc(txtValue.Text);
        }

        #endregion


    }
}
