using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsConveyor : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float timeToSpawn;

    [SerializeField] private sbyte direction;
    private bool _spawned = false;

    [SerializeField] private int countSpawn;

    private int _currentSpawned;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObjects");

    }
    // private void SpawnObjects()
    // {
    //     while (currentSpawned > countSpawn)
    //     {
    //         if(Instantiate(objectToSpawn, transform.position, transform.rotation) != null)
    //             currentSpawned++;
    //     }
    // }

    private IEnumerator SpawnObjects()
    {
        while (_currentSpawned < countSpawn)
        {
            if(Instantiate(objectToSpawn, transform.position, transform.rotation) != null)
                _currentSpawned++;
            yield return new WaitForSecondsRealtime(timeToSpawn);
        }
        StopCoroutine("SpawnObjects");
    }
}
