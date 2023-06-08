using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Infrastructure;
using Newtonsoft.Json;
using UnityEditor.SearchService;
using Assets.Scripts;
using static UnityEngine.Rendering.PostProcessing.PostProcessResources;

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
            string json = (File.ReadAllText(savePath));

            // Преобразуем JSON в объект
            PlayerPositionData positionData = JsonUtility.FromJson<PlayerPositionData>(json);

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
        PlayerPositionData positionData = new PlayerPositionData();
        positionData.position = playerTransform.position;

        AbilityHandler ability = player.GetComponent<AbilityHandler>();

        //List<Ability> _abilities = ability.GetAbilities();

        string json = JsonUtility.ToJson(positionData);

        
        File.WriteAllText(
            SavesManager.savePath + "/jsonWorld.json",
            JsonConvert.SerializeObject(json, Formatting.Indented, new JsonSerializerSettings()
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
public class PlayerPositionData
{
    public Vector3 position;
}
