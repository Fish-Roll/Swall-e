using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Infrastructure;
using Newtonsoft.Json;
using UnityEditor.SearchService;
using Assets.Scripts;
using static UnityEngine.Rendering.PostProcessing.PostProcessResources;
using Struct;

public interface ISave
{
    void Save();
    void Load();
}

public class SavesManager : MonoBehaviour, ISave
{
    public static string savePath { get; private set; }

    public Transform playerTransform;
    public GameObject player;

    [SerializeField] private AesCryptoComponent aesEncrypt;


    public class Player
    {
        public Vector3 pos, rot, scale, velocity, angularVelocity;
        //public List<Ability> abilities = new List<Ability>();
        public List<Player> playerData = new List<Player>();
    }

    public void Load()
    {
        string savePath = Application.dataPath + "/jsonWorld.json";
        if (File.Exists(savePath))
        {
            // Читаем JSON из файла
            string encryptedJson = (File.ReadAllText(savePath));

            byte[] encryptedBytes = JsonUtility.FromJson<EncryptedGameCoreStruct>(encryptedJson).data;

            string json = aesEncrypt.Decrypt(encryptedBytes);
            // Преобразуем JSON в объект
            PlayerPositionData positionData = JsonUtility.FromJson<PlayerPositionData>(json);
            //this.position = positionData.position;

            // Восстанавливаем позицию персонажа
            playerTransform.position = positionData.position;

            print("Position loaded from: " + savePath);
        }
        else
        {
            print("No saved position found.");
        }
    }

    public void Save()
    {
        PlayerPositionData positionData = new PlayerPositionData()
        { position = playerTransform.position };

        AbilityHandler ability = player.GetComponent<AbilityHandler>();

        //List<Ability> _abilities = ability.GetAbilities();

        string json = JsonUtility.ToJson(positionData);

        byte[] encryptedBytes = this.aesEncrypt.Encrypt(json);

        EncryptedGameCoreStruct encryptedGameCore = new EncryptedGameCoreStruct()
        {
            data= encryptedBytes,
        };

        string encryptedJson = JsonUtility.ToJson(encryptedGameCore);
        
        File.WriteAllText(
            SavesManager.savePath + "/jsonWorld.json",
            JsonConvert.SerializeObject(encryptedJson, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling= ReferenceLoopHandling.Ignore
                })

            );

#if UNITY_EDITOR
        print("Json Complete: " + SavesManager.savePath + "/jsonworld.json");
#endif
    }
    private void Start()
    {
        
        savePath = Application.dataPath;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Load();
        }
    }

}
[System.Serializable]
public struct PlayerPositionData
{
    public Vector3 position;
}
