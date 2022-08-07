using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndDoor : MonoBehaviour
{
    // transformUp, sound
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private float timeClose;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MoveOverTime(door, endPoint.transform.position, timeClose));
    }
    private IEnumerator MoveOverTime(GameObject moveObject, Vector3 end, float seconds)
    {
        AudioSource audioSource = moveObject.GetComponent<AudioSource>();
        if (audioSource != null)
            audioSource.Play();
        float elapsedTime = 0;
        Vector3 startPos = moveObject.transform.position;
        while (elapsedTime < seconds)
        {
            moveObject.transform.position = Vector3.Lerp(startPos, end, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        moveObject.transform.position = end;
    }
}