using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private float rotationSpeed;
    public void Start()
    {
        rotationSpeed = gameObject.transform.parent.parent.GetComponent<Movement>().moveSpeed;
    }

    public void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            transform.Rotate( ((rotationSpeed * 20000) / transform.localScale.y) * Time.deltaTime, 0, 0);
    }
}
