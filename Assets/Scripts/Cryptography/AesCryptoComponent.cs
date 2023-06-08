using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using Structs;
using System;

public class AesCryptoComponent : MonoBehaviour
{
    public byte[] Encrypt(string str)
    {
        byte[] encryptedBytes;

        using (Aes aes = Aes.Create()) 
        {
            aes.GenerateKey();

            aes.GenerateIV();

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms,encryptor, CryptoStreamMode.Write)) 
                {
                    using (StreamWriter sw = new StreamWriter(cs)) 
                    {
                        sw.Write(str);

                        encryptedBytes= ms.ToArray();
                    }
                }
            }
            using (SHA256 sha= SHA256.Create()) 
            {
                byte[] bytes = sha.ComputeHash(encryptedBytes);

                string hash = BitConverter.ToString(bytes).Replace("-", "");

                AesCryptoParametersStruct c = new AesCryptoParametersStruct
                {
                    key = aes.Key, 
                    iv = aes.IV
                };

                SaveEncryptParameters(c, hash);
            }

            return encryptedBytes;
        }
    }

    public string Decrypt(byte[] encryptedBytes)
    {
        AesCryptoParametersStruct c = LoadEncryptParameters(encryptedBytes);

        string decryptedString;

        using (Aes aes = Aes.Create()) 
        {
            aes.Key = c.key;
            aes.IV = c.iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream()) 
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

    private void SaveEncryptParameters(AesCryptoParametersStruct c, string key)
    {
        string json = JsonUtility.ToJson(c);

        PlayerPrefs.SetString(key, json);
    }

    private AesCryptoParametersStruct LoadEncryptParameters(byte[] encryptedBytes)
    {
        string key;
        using (SHA256 sha = SHA256.Create())
        {
            byte[] hash = sha.ComputeHash(encryptedBytes);
            key = BitConverter.ToString(hash).Replace("-", "");
        }

        if (!PlayerPrefs.HasKey(key)) 
        {
            throw new PlayerPrefsException("Ключа не существует");
        }

        string json = PlayerPrefs.GetString(key);

        PlayerPrefs.DeleteKey(key);

        return JsonUtility.FromJson<AesCryptoParametersStruct>(json);
    }
}
