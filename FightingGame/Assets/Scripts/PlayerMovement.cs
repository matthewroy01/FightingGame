using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(FightingGameInput.InputManager), typeof(FightingGameInput.StickManager))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FightingGameInput.InputManager inputManager;
    [SerializeField] private FightingGameInput.StickManager stickManager;

    [Header("Movement Paremeters")]
    public float movementSpeed;
    [Range(0.0f, 1.0f)]
    public float movementDeadZone;
    public float terminalVelocityX;
    public float aerialForceMultiplier;
    private FightingGameInput.InputDirection movementDirection;

    [Header("Jump Parameters")]
    public float jumpForce;
    private bool initiatedJump;

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

        leftGround.AddListener(delegate { initiatedJump = false; } );
    }

    private void Update()
    {
        CheckGround();
        //AdjustDrag();
    }

    private void FixedUpdate()
    {
        Move();
        //TerminalVelocities();
    }

    private void LeftStickChanged()
    {
        movementDirection = stickManager.GetDirection();
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
        rb.drag = 0.0f;
        initiatedJump = true;
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void Move()
    {
        if (grounded)
        {
            float velocity = 0.0f;
            float hindrance = 1.0f;

            if (!grounded)
            {
                hindrance = aerialForceMultiplier;
            }

            switch (movementDirection)
            {
                case FightingGameInput.InputDirection.l:
                case FightingGameInput.InputDirection.ul:
                    //case FightingGameInput.InputDirection.dl:
                    {
                        velocity = movementSpeed * hindrance * -1;
                        break;
                    }
                case FightingGameInput.InputDirection.r:
                case FightingGameInput.InputDirection.ur:
                    //case FightingGameInput.InputDirection.dr:
                    {
                        velocity = movementSpeed * hindrance;
                        break;
                    }
            }

            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
    }

    private void TerminalVelocities()
    {
        if (Mathf.Abs(rb.velocity.x) > terminalVelocityX)
        {
            if (rb.velocity.x > 0.0f)
            {
                rb.velocity = new Vector2(terminalVelocityX, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(terminalVelocityX * -1, rb.velocity.y);
            }
        }
    }

    private void AdjustDrag()
    {
        if (grounded && !initiatedJump &&
        (movementDirection == FightingGameInput.InputDirection.none ||
        movementDirection == FightingGameInput.InputDirection.u ||
        movementDirection == FightingGameInput.InputDirection.d ||
        movementDirection == FightingGameInput.InputDirection.dl ||
        movementDirection == FightingGameInput.InputDirection.dr))
        {
            rb.drag = Mathf.Lerp(rb.drag, 100.0f, 0.15f);
        }
        else
        {
            rb.drag = 0.0f;
        }
    }
}