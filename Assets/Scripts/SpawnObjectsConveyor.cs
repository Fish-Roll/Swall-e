using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsConveyor : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float timeToSpawn;

    private float currentTimeToSpawn;
    [SerializeField] private sbyte direction;
    private float timeToWait;

    [SerializeField] private float distanceBetweenTrash;
    [SerializeField] private float countObjectsToSpawn;

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
        for(int i = 0; i < countObjectsToSpawn; i++)
            Instantiate(objectToSpawn, transform.position + new Vector3(0,0, objectToSpawn.transform.localScale.z * (i * distanceBetweenTrash)) * direction , transform.rotation);
    }
}
