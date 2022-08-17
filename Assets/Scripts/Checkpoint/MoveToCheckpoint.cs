using System;

using Assets.Scripts;
using UnityEngine;

public class MoveToCheckpoint : MonoBehaviour
{
    public static Checkpoint checkpoint;

    public static void MovePlayer(GameObject player)
    {
        player.transform.position = checkpoint.transform.position;
        player.transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer(other.gameObject);
    }
}
