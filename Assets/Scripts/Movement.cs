using System.Timers;
using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallSpeed;
    [SerializeField] Transform camera;
    public float moveSpeed = 7;
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        grounded = true;
    }
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerSize * 0.5f + 0.2f);
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
        rb.AddForce(Physics.gravity * fallSpeed, ForceMode.Force);
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        MovePlayer(angle);
    }

    private void InputMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();
    }

    private void MovePlayer(float angle)
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (moveDirection.magnitude >= .1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            transform.Translate(moveDir * moveSpeed * Time.fixedDeltaTime, Space.World);
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
        // float friction = 10;
        // if (rb.velocity.magnitude > 0)
        // {
        //     rb.AddForce(-rb.velocity.normalized * friction);
        // }
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}