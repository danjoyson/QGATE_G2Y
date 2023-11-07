using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace prodProject
{
    internal class Encryptor
    {

        

        //Método para la creación del texto encriptado
        public static string Encriptado(string password)
        {

            string keyWord = "JQMX"; //Palabra clave para la generación de la llave


            if (password == null)
            {
                return null;
            }

            // Convertir textos a bytes
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(password);
            var keyBytes = Encoding.UTF8.GetBytes(keyWord);

            // Aplicar Hash único a los bytes de key
            keyBytes = SHA512.Create().ComputeHash(keyBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, keyBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        // Función de encriptado AES
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            MemoryStream ms = new();
            RijndaelManaged AES = new();

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                cs.Close();
            }

            encryptedBytes = ms.ToArray();
            return encryptedBytes;
        }
    }
}
