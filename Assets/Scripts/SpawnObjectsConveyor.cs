using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsConveyor : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float timeToSpawn;

    private float currentTimeToSpawn;
    [SerializeField] private sbyte direction;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToSpawn > 0)
            currentTimeToSpawn -= Time.deltaTime;
        else
        {
            SpawnObjects();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    private void SpawnObjects()
    {
        Instantiate(objectToSpawn,
            transform.position
            , transform.rotation);
    }
}
