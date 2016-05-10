using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class KeyGenerator
    {
        private DESCryptoServiceProvider _key;
        public KeyGenerator()
        {
            _key = new DESCryptoServiceProvider();
        }
    }
}
