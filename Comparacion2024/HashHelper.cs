using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Scrypt;

namespace Comparacion2024
{
    class HashHelper
    {

        public static bool VerificarHash(string contraseña, string hashAlmacenado)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            return encoder.Compare(contraseña, hashAlmacenado);

        }

    }
}
