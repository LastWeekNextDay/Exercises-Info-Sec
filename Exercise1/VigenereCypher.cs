using System;

namespace Exercise1
{
    public class VigenereCypher
    {
        public static string Encrypt(string plainText, string key)
        {
            // Vigenere Cypher Encryption Algoritm

            // Throw an exception if the plain text is empty or all spaces
            if (plainText == "" || plainText.Replace(" ", "") == "")
            {
                throw new System.ArgumentException("Input cannot be empty");
            }

            // Throw an exception if the key is empty or all spaces
            if (key == "" || key.Replace(" ", "") == "")
            {
                throw new System.ArgumentException("Key cannot be empty");
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
            for (int i = 0; i < plainText.Length; i++)
            {
                encryptedText += (char)((plainText[i] + key[keyIndex]) % 128);
                keyIndex = (keyIndex + 1) % key.Length;
            }

            // Return the encrypted text
            return encryptedText;
        }

        public static string Decrypt(string cipherText, string key)
        {
            // Vigenere Cypher Decryption Algorithm

            // Throw an exception if the cipher text is empty or all spaces
            if (cipherText == "" || cipherText.Replace(" ", "") == "")
            {
                throw new System.ArgumentException("Input cannot be empty");
            }

            // Throw an exception if the key is empty or all spaces
            if (key == "" || key.Replace(" ", "") == "")
            {
                throw new System.ArgumentException("Key cannot be empty");
            }

            // Throw an exception if the key is longer than the cipher text
            if (key.Length > cipherText.Length)
            {
                throw new System.ArgumentException("Key cannot be longer than the cipher text");
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
            for (int i = 0; i < cipherText.Length; i++)
            {
                decryptedText += (char)((cipherText[i] - key[keyIndex] + 128) % 128);
                keyIndex = (keyIndex + 1) % key.Length;
            }

            return decryptedText;
        }
    }
}