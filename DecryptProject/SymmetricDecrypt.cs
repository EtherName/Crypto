using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DecryptProject
{
    internal static class SymmetricDecrypt
    {
        internal static string SymmetricDecryptFromBytes(byte[] chipertext, SymmetricAlgorithm key)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cs);
            string dafaultstring = sr.ReadLine();
            sr.Close();
            cs.Close();
            byte[] buffer = ms.ToArray();
            ms.Close();
            return dafaultstring;
        }
        internal static byte[] EncryptingBytesFromXML(string path)
        {
            using (XmlReader xreader = XmlReader.Create(path))//new FileStream(path, FileMode.OpenOrCreate))
            {
                xreader.ReadToFollowing("ChiperText");
                return Convert.FromBase64String(xreader.ReadElementContentAsString());
                
            }

        }
    }
}
