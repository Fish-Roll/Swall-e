using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Convayor : MonoBehaviour
{
    public Transform endpoint;
    public float speed;
    private void OnTriggerStay(Collider other)
    {
        if(other.attachedRigidbody != null)
            other.attachedRigidbody.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset += Vector2.left * speed * Time.deltaTime;
    }
}
