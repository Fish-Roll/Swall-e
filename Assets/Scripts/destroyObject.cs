using UnityEngine;

public class destroyObject : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    private System.Random random = new System.Random();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            other.gameObject.transform.position = spawnPoint[random.Next(0, spawnPoint.Length)].position;
        }
    }
}
