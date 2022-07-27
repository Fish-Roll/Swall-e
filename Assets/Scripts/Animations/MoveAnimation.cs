using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public float rotationSpeed;
    [SerializeField] private AudioSource _moveSound;
    private Rigidbody rb;

    public void Start()
    {
        rb = gameObject.transform.parent.parent.parent.GetComponent<Rigidbody>();
        if (gameObject.transform.parent.parent.parent.parent.GetComponent<Movement>() != null)
            rotationSpeed = gameObject.transform.parent.parent.parent.parent.parent.parent.GetComponent<Movement>()
                .moveSpeed;
        else rotationSpeed = 10;
    }

    public void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            transform.Rotate(((rotationSpeed * 20000) / transform.localScale.y) * Time.deltaTime, 0, 0);
    }
}