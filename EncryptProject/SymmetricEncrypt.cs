using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace EncryptProject
{
    internal static class SymmetricEncrypt
    {
        internal static byte[] SymmetricEncryptToBytes(string plaintext, SymmetricAlgorithm key)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cs);
            sw.WriteLine(plaintext);
            sw.Close();
            cs.Close();
            byte[] buffer = ms.ToArray();
            ms.Close();
            return buffer;
        }
        internal static void EncryptingBytesToXML(byte[] chipertext, string path)
        {
            using (XmlWriter xwriter = XmlWriter.Create(path))//new FileStream(path, FileMode.OpenOrCreate))
            {
                xwriter.WriteStartDocument();
                xwriter.WriteStartElement("ChiperText");
                xwriter.WriteBase64(chipertext,0,chipertext.Count());
                xwriter.WriteEndElement();
                xwriter.WriteEndDocument();
            }
            
        }
    }
}
