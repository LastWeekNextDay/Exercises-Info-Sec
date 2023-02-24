using System;

namespace Exercise2
{
    public static class VigenereCypher
    {
        public static string Encrypt(string plainText, string key)
        {
            // Throw an exception if the plain text is empty or all spaces
            if (plainText == "" || plainText.Replace(" ", "") == "")
            {
                throw new ArgumentException("Input cannot be empty");
            }

            // Throw an exception if the key is empty or all spaces
            if (key == "" || key.Replace(" ", "") == "")
            {
                throw new ArgumentException("Key cannot be empty");
            }

            // Throw an exception if the plain text contains symbols that are less than 32 on the ASCII table or greater than 126
            foreach (var t in plainText)
            {
                if (t < 32 || t > 126)
                {
                    throw new ArgumentException(
                        "Input cannot contain symbols that are less than 32 on the ASCII table or greater than 126");
                }
            }
            
            // Throw an exception if the key is longer than the plain text
            if (key.Length > plainText.Length)
            {
                throw new ArgumentException("Key cannot be longer than the plain text");
            }

            // If the key is shorter than the plain text, repeat the key until it is the same length as the plain text
            while (key.Length < plainText.Length)
            {
                key += key;
            }

            // Create a string to hold the encrypted text
            string encryptedText = "";

            // Create a variable to hold the index of the key
            int keyIndex = 0;

            // For each character in the plain text, find the corresponding character in the key using ASCII
            foreach (var t in plainText)
            {
                // Create a variable to hold the encrypted character value
                int encryptedCharValue = (t + key[keyIndex]) % 95 + 32;

                // Add the encrypted character to the encrypted text
                encryptedText += (char)encryptedCharValue;

                // Increment the key index
                keyIndex++;
            }

            // Return the encrypted text
            return encryptedText;
        }

        public static string Decrypt(string cipherText, string key)
        {
            // Throw an exception if the cipher text is empty or all spaces
            if (cipherText == "" || cipherText.Replace(" ", "") == "")
            {
                throw new ArgumentException("Input cannot be empty");
            }

            // Throw an exception if the key is empty or all spaces
            if (key == "" || key.Replace(" ", "") == "")
            {
                throw new ArgumentException("Key cannot be empty");
            }

            // Throw an exception if the cipher text contains symbols that are less than 32 on the ASCII table or greater than 126
            foreach (var t in cipherText)
            {
                if (t < 32 || t > 126)
                {
                    throw new ArgumentException(
                        "Input cannot contain symbols that are less than 32 on the ASCII table or greater than 126");
                }
            }

            // Throw an exception if the key is longer than the cipher text
            if (key.Length > cipherText.Length)
            {
                throw new ArgumentException("Key cannot be longer than the cipher text");
            }

            // If the key is shorter than the cipher text, repeat the key until it is the same length as the cipher text
            while (key.Length < cipherText.Length)
            {
                key += key;
            }

            // Create a string to hold the decrypted text
            string decryptedText = "";

            // Create a variable to hold the index of the key
            int keyIndex = 0;

            // For each character in the cipher text, find the corresponding character in the key using ASCII
            foreach (var t in cipherText)
            {
                // Create a variable to hold the decrypted character value
                int decryptedCharValue = (t - key[keyIndex] + 126) % 95 + 32;

                // Add the decrypted character to the decrypted text
                decryptedText += (char)decryptedCharValue;

                // Increment the key index
                keyIndex++;
            }

            // Return the decrypted text
            return decryptedText;
        }
    }
}