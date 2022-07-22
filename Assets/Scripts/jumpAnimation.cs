using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAnimation : MonoBehaviour
{
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.isMoved == true)
        {
            playerAnimator.SetTrigger("run");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetTrigger("jump");

            }
            
        }
        else
        {
            playerAnimator.SetTrigger("stay");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetTrigger("jump");

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("jump");

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimator.SetTrigger("dash");

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerAnimator.SetTrigger("die");

        }

    }
    
}
