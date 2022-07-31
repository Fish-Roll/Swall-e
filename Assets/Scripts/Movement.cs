using System;
using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallSpeed;
    [SerializeField] Transform camera;
    [SerializeField] private AudioSource _moveSound;
    public float moveSpeed;
    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;
    private float playerSize = 2;
    private float groundDrag = 1;
    public int countJump;
    public bool grounded;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 fallVector;
    private RaycastHit hit;
    
    public static bool isMoved; // flag for anim run/idle
    //public Animator playerAnimator;

    private void Start()
    {
        fallVector.y = Physics.gravity.y * fallSpeed * Time.deltaTime;
        //playerAnimator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        grounded = true;
    }
    void Update()
    {
        grounded = Physics.SphereCast(transform.position, transform.lossyScale.x/200000, -transform.up, out hit, 0.25f);
        InputMove();
        SpeedControl();
        if (grounded)
        {
            rb.drag = groundDrag;
            countJump = 0;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        rb.velocity += fallVector;
        MovePlayer(targetAngle);
    }

    private void InputMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput !=0 || verticalInput != 0)
        {
            isMoved = true;
            if(!_moveSound.isPlaying)
                _moveSound.Play();
        }
        else
        {
            isMoved = false;
            _moveSound.Stop();
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
            //playerAnimator.SetTrigger("jump");
        }
    }

    private void MovePlayer(float angle)
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (moveDirection.magnitude >= .1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            rb.velocity += moveDir.normalized * moveSpeed;
        }
    }
    public void Jump()
    {
        ++countJump;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.velocity += Vector3.up * jumpForce;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnDrawGizmos()
    {
        if (grounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + transform.right * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + transform.right * hit.distance, transform.lossyScale.x / 2);
        }
    }
}