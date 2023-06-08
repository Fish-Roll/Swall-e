using System;
using UnityEngine;
using Assets.N.Fridman.AesEncrypt;

public class AesEncryptDemo : MonoBehaviour
{
    private AesEncryptComponent aesEncrypt;
    
    [SerializeField] private string str = "Hello World!!!";

    private void Awake()
    {
        // Добавляем компонент во время загрузки игры.
        //
        // Не обязательно делать именно так, можно просто повесить его на GameObject чререз инспектор
        // И перетащить в поле
        this.aesEncrypt = gameObject.AddComponent<AesEncryptComponent>();
    }
    
    private void Start()
    {
        // Вывод в консоль
        Debug.Log("Entry String -> " + this.str);

        // Шифруем строку и кладем её в массив байт
        byte[] encryptedBytes = this.aesEncrypt.Encrypt(this.str);
        
        // Вывод в консоль
        Debug.Log("Ecnrypted Bytes -> " + BitConverter.ToString(encryptedBytes));
        
        /*
         *
         * Действия с зашифрованной строкой. 
         * 
         */
        
        // Получем исходную строку назад из массива зашифрованных байт
        string decryptedString = this.aesEncrypt.Decrypt(encryptedBytes);
        
        // Вывод в консоль
        Debug.Log("Decrypted String -> " + decryptedString);
    }


}
