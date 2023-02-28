using System;
using System.Security.Cryptography;

namespace Exercise2
{
    public static class AesUtil
    {
        public static byte[] StringToAesKey(string key)
        {
            // Create SHA256
            var hash = SHA256.Create();
            
            // Create input bytes
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(key);
            
            // Create hashed bytes
            byte[] hashedBytes = hash.ComputeHash(inputBytes);

            // Create byte array for key
            byte[] keyBytes = new byte[32];

            // Copy the hashed bytes to the key
            Array.Copy(hashedBytes, 0, keyBytes, 0, 32);
            
            // Return the key bytes
            return keyBytes;
        }
        
        public static string StringToSize(string str, int size)
        {
            // Check if string is too long
            if (str.Length > size)
            {
                // Return the string with the correct size
                return str.Substring(0, size);
            }

            // Check if string is too short
            if (str.Length < size)
            {
                // Return the string with the correct size
                return str.PadRight(size);
            }

            // Return the string
            return str;
        }
        
        public static string EncryptString(string str, byte[] key, byte[] iv, CipherMode mode)
        {
            // Create AES
            var aes = Aes.Create();
            
            // Assign key, IV and mode
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = mode;
            
            // Set padding mode
            aes.Padding = PaddingMode.PKCS7;
            
            // Create encryptor
            var encryptor = aes.CreateEncryptor();
            
            // Create input bytes
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
            
            // Create encrypted bytes
            byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            
            // Return the converted string
            return Convert.ToBase64String(encryptedBytes);
        }
        
        public static string DecryptString(string str, byte[] key, byte[] iv, CipherMode mode)
        {
            // Create AES
            var aes = Aes.Create();
            
            // Assign key, IV and mode
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = mode;
            
            // Set padding mode
            aes.Padding = PaddingMode.PKCS7;
            
            // Create decryptor
            var decryptor = aes.CreateDecryptor();
            
            // Create input bytes
            byte[] inputBytes = Convert.FromBase64String(str);
            
            // Create decrypted bytes
            byte[] decryptedBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            
            // Return the converted string
            return System.Text.Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}