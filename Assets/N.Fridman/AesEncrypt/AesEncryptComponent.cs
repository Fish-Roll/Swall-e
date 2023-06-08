using System;
using System.IO;
using System.Security.Cryptography;
using N.Fridman.AesEncrypt.Structs;
using UnityEngine;

namespace Assets.N.Fridman.AesEncrypt
{
    public class AesEncryptComponent : MonoBehaviour
    {
        /// <summary>
        ///     Encrypt String
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Encrypted Bytes</returns>
        public byte[] Encrypt(string str)
        {
            // Encrypted Byte Array
            byte[] encryptedBytes;

            using (Aes aes = Aes.Create())
            {
                // Create Aes Key
                aes.GenerateKey();
            
                // Create Initialize Vector
                aes.GenerateIV();

                // Create Encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            
                // Create Streams
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Write Stream To Thread
                            sw.Write(str);
                        }
                    }
                
                    // Read Byte Array From Stream
                    encryptedBytes = ms.ToArray();
                }

                // Create SHA256 Class
                using (SHA256 sha = SHA256.Create())
                {
                    // Compute Hash
                    byte[] bytes = sha.ComputeHash(encryptedBytes);
                
                    // Convert Bytes To String
                    string hash = BitConverter.ToString(bytes).Replace("-", "");
                
                    // Create Struct
                    AesEncryptParametersStruct c = new AesEncryptParametersStruct
                    {
                        key = aes.Key,
                        iv = aes.IV
                    };
                
                    // Save Key And Iv To Player Prefs
                    SaveEncryptParameters(c, hash);
                }
            
            }
        
            return encryptedBytes;
        }
        
        /// <summary>
        ///     Decrypt String
        /// </summary>
        /// <param name="encryptedBytes">Encrypted Bytes</param>
        /// <returns>Decrypted String</returns>
        public string Decrypt(byte[] encryptedBytes)
        {
            // Load Parameters From Player Prefs
            AesEncryptParametersStruct c = LoadEncryptParameters(encryptedBytes);
        
            // Decrypted String
            string decryptedString;
        
            // Create Aes
            using (Aes aes = Aes.Create())
            {
                // Set Key From Loaded Structure
                aes.Key = c.key;
            
                // Set initialize Vector From Loaded Structure
                aes.IV = c.iv;

                // Create Decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            
                // Create Streams
                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            decryptedString = sr.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedString;
        }
    
        private void SaveEncryptParameters(AesEncryptParametersStruct c, string key)
        {
            // Transform Object To Json
            string json = JsonUtility.ToJson(c);
        
            // Save Json String To Player Prefs
            PlayerPrefs.SetString(key, json);
        }

        private AesEncryptParametersStruct LoadEncryptParameters(byte[] encryptedBytes)
        {
            string key;
        
            // Create SHA256 Class
            using (SHA256 sha = SHA256.Create())
            {
                // Compute Hash
                byte[] hash = sha.ComputeHash(encryptedBytes);
            
                // Set Player Prefs Key
                key = BitConverter.ToString(hash).Replace("-", "");
            }
        
            // Check Key
            if (!PlayerPrefs.HasKey(key))
            {
                throw new PlayerPrefsException("Key Not Exist");
            }
        
            // Load Json From Player Prefs
            string json = PlayerPrefs.GetString(key);
        
            // Delete Key
            PlayerPrefs.DeleteKey(key);
        
            return JsonUtility.FromJson<AesEncryptParametersStruct>(json);
        }

    





















    }
}
