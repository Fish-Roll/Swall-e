using System;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trash"))
            Destroy(other.gameObject);
    }
}
