using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private InputManager.InputManager inputManager;
    [SerializeField] private InputManager.StickManager stickManager;

    [Header("Movement Paremeters")]
    public float movementSpeed;
    public float movementDeadZone;
    private float movementValue;

    [Header("Jump Parameters")]
    public float jumpForce;

    [Header("Ground Parameters")]
    public float groundCheckDistance;
    public List<Transform> groundChecks = new List<Transform>();
    public LayerMask groundLayer;
    private bool grounded;

    [HideInInspector] public UnityEvent landedOnGround = new UnityEvent();
    [HideInInspector] public UnityEvent leftGround = new UnityEvent();


    private void Awake()
    {
        inputManager.performedLeftStick.AddListener(LeftStickChanged);
        stickManager.performedLeftStick.AddListener(LeftStickChangedEight);
    }

    private void Update()
    {
        CheckGround();
        Move();
    }

    private void LeftStickChanged()
    {
        movementValue = inputManager.axisLeftStick.GetValue().x;
    }

    private void LeftStickChangedEight()
    {
        if (stickManager.GetJumpInput() && grounded)
        {
            Jump();
        }
    }

    private void CheckGround()
    {
        bool toGround = false;

        for (int i = 0; i < groundChecks.Count; ++i)
        {
            if (Physics2D.Raycast(groundChecks[i].position, Vector2.down, groundCheckDistance, groundLayer))
            {
                toGround = true;
            }
        }

        if (toGround)
        {
            if (!grounded)
            {
                landedOnGround.Invoke();
            }

            grounded = true;
        }
        else
        {
            if (grounded)
            {
                leftGround.Invoke();
            }

            grounded = false;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void Move()
    {
        float velocity = 0.0f;

        if (movementValue > movementDeadZone)
        {
            velocity = movementSpeed;
        }
        else if (movementValue < movementDeadZone * -1)
        {
            velocity = movementSpeed * -1;
        }

        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }
}