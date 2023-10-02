using System.Text;
using System.Security.Cryptography;

//Clase de desencriptado
namespace prodProject
{
    internal class Decryptor
    {

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función principal de desencriptado
         * La keyword debe ser "JQMX" para funcionar en complemento a la aplicación Encryptor
         * 
         * 1. Recibe texto plano para ser desencriptado (encriptedText)
         * 2. Los convierte a texto Base64
         * 3. Convierte el texto de keyword a bytes
         * 4. Genera un hash a partir de la keyword (Hash idéntico a la aplicación Encryptor.exe)
         * 5. Llama a la función Decrypt, enviando los bytes encriptados y los bytes del hash generado.
         * 6. Convierte el arreglo de bytes desencriptados a texto plano y los retorna.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public static string Desencriptado(string encryptedText)
        {
            string keyWord = "JQMX"; //NO DEBE DE SER MODIFICADA

            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText); //Bytes de keyword
            var passwordBytes = Encoding.UTF8.GetBytes(keyWord);

            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }


        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función auxiliar de desencriptado AES.
         * 1. Recibe los bytes de desencriptado y de la keyword.
         * 2. Crea una contraseña a partir de los Bytes de la keyword, bytes de "salt" y 1000 iteraciones.
         * 3. Retorna los bytes desencriptados en forma de un arreglo de bytes.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000); //Genración de contraseña unica

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
