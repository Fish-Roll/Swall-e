namespace N.Fridman.AesEncrypt.Structs
{
    [System.Serializable]
    public struct AesEncryptParametersStruct
    {
        // Aes key Field
        public byte[] key;

        // Aes initialize Vector Field
        public byte[] iv;
    }
}