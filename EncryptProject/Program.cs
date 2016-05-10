using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "Hello world";

            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            var output = SymmetricEncrypt.SymmetricEncryptToBytes(phrase, key);
            SymmetricEncrypt.EncryptingBytesToXML(output, @"S:\C-16-01\Vasyl.Cherniatyn\1.xml");
            AddKeyToAppConfig(key);
            Console.ReadKey();
        }

        private static void AddKeyToAppConfig(DESCryptoServiceProvider key)
        {
            //var appSettings = ConfigurationManager.AppSettings;
            Console.WriteLine("Key " + Convert.ToBase64String(key.Key).ToString());
            Console.WriteLine("IV " +  Convert.ToBase64String(key.IV).ToString());
            
        }
    }
}
