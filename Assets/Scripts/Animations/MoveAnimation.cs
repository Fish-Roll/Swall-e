using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private float rotationSpeed;
    public void Start()
    {
        if (gameObject.transform.parent.parent.parent.parent.GetComponent<Movement>() != null)
            rotationSpeed = gameObject.transform.parent.parent.parent.parent.parent.GetComponent<Movement>().moveSpeed;
        else rotationSpeed = 10;
    }

    public void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            transform.Rotate( ((rotationSpeed * 20000) / transform.localScale.y) * Time.deltaTime, 0, 0);
    }
}
