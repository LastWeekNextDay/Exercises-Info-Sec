namespace Exercise1
{
    public class VigenereCypher
    {
        public static string Encrypt(string plainText, string key)
        {
            // Vigenere Cypher Encryption Algorithm

            // Convert plainText to upper case
            plainText = plainText.ToUpper();
            
            // Convert key to upper case
            key = key.ToUpper();
            
            // Remove all spaces from plainText
            plainText = plainText.Replace(" ", "");

            // Throw an exception if the plain text is empty
            if (plainText == "")
            {
                throw new System.ArgumentException("Input cannot be empty");
            }
            
            // Remove all spaces from key
            key = key.Replace(" ", "");
            
            // If the key is shorter than the plain text, repeat the key until it is the same length as the plain text
            while (key.Length < plainText.Length)
            {
                key += key;
            }
            
            // Create a string to hold the encrypted text
            string encryptedText = "";
            
            // For each character in the plain text, find the corresponding character in the key using ASCII
            for (int i = 0; i < plainText.Length; i++)
            {
                // Find the character in the key
                char keyChar = key[i];
                
                // Find the character in the plain text
                char plainTextChar = plainText[i];
                
                // Find the ASCII value of the key character
                int keyCharValue = (int) keyChar;
                
                // Find the ASCII value of the plain text character
                int plainTextCharValue = (int) plainTextChar;
                
                // Find the difference between the key character and the plain text character
                int difference = keyCharValue - plainTextCharValue;
                
                // If the difference is negative, add 26 to it
                if (difference < 0)
                {
                    difference += 26;
                }
                
                // Find the ASCII value of the encrypted character
                int encryptedCharValue = plainTextCharValue + difference;
                
                // Convert the ASCII value of the encrypted character to a character
                char encryptedChar = (char) encryptedCharValue;
                
                // Add the encrypted character to the encrypted text
                encryptedText += encryptedChar;
            }

            // Return the encrypted text
            
            return encryptedText;
        }

        public static string Decrypt(string cipherText, string key)
        {
            // Vigenere Cypher Decryption Algorithm
            
            // Convert cipherText to upper case
            cipherText = cipherText.ToUpper();
            
            // Convert key to upper case
            key = key.ToUpper();
            
            // Remove all spaces from cipherText
            cipherText = cipherText.Replace(" ", "");
            
            // Throw an exception if the cipher text is empty
            if (cipherText == "")
            {
                throw new System.ArgumentException("Input cannot be empty");
            }
            
            // Remove all spaces from key
            key = key.Replace(" ", "");
            
            // Throw an exception if the key is empty
            if (key == "")
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
            
            // For each character in the cipher text, find the corresponding character in the key using ASCII
            for (int i = 0; i < cipherText.Length; i++)
            {
                // Find the character in the key
                char keyChar = key[i];
                
                // Find the character in the cipher text
                char cipherTextChar = cipherText[i];
                
                // Find the ASCII value of the key character
                int keyCharValue = (int) keyChar;
                
                // Find the ASCII value of the cipher text character
                int cipherTextCharValue = (int) cipherTextChar;
                
                // Find the difference between the key character and the cipher text character
                int difference = keyCharValue - cipherTextCharValue;
                
                // If the difference is negative, add 26 to it
                if (difference < 0)
                {
                    difference += 26;
                }
                
                // Find the ASCII value of the decrypted character
                int decryptedCharValue = cipherTextCharValue + difference;
                
                // Convert the ASCII value of the decrypted character to a character
                char decryptedChar = (char) decryptedCharValue;
                
                // Add the decrypted character to the decrypted text
                decryptedText += decryptedChar;
            }

            return decryptedText;
        }
    }
}