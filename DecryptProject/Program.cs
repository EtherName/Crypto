using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DecryptProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            ReadKeyFromAppConfig(key);
            byte[] chipertext = SymmetricDecrypt.EncryptingBytesFromXML(@"S:\C-16-01\Vasyl.Cherniatyn\1.xml");
            string phrase = SymmetricDecrypt.SymmetricDecryptFromBytes(chipertext, key);

            Console.WriteLine(phrase);
            Console.ReadKey();
        }

        private static void ReadKeyFromAppConfig(DESCryptoServiceProvider key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            key.IV = Convert.FromBase64String(appSettings["IV"]);
            key.Key = Convert.FromBase64String(appSettings["Key"]);
        }

    }
}
