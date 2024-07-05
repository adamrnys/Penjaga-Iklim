using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //Horizontal wall jump force
    [SerializeField] private float wallJumpY; //Vertical wall jump force

    [Header("UI Buttons")]
    public Button jumpButton;
    public EventTrigger leftButton;
    public EventTrigger rightButton;

    private bool isLeftPressed;
    private bool isRightPressed;

    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Add listeners for jump button press
        jumpButton.onClick.AddListener(OnJumpButtonPressed);

        // Add event triggers for button presses and releases
        AddEventTriggerListener(leftButton, EventTriggerType.PointerDown, OnLeftButtonPressed);
        AddEventTriggerListener(leftButton, EventTriggerType.PointerUp, OnLeftButtonReleased);
        AddEventTriggerListener(rightButton, EventTriggerType.PointerDown, OnRightButtonPressed);
        AddEventTriggerListener(rightButton, EventTriggerType.PointerUp, OnRightButtonReleased);
    }

    private void Update()
    {
        // Calculate horizontal input based on button presses
        horizontalInput = 0;
        if (isLeftPressed) horizontalInput = -1;
        if (isRightPressed) horizontalInput = 1;

        // Flip player left-right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        // Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }

            // Move jump logic to a separate method to ensure it's only called when needed
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
            Debug.Log("Jump Triggered");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCooldown = 0;
            anim.SetTrigger("jump");
            Debug.Log("Wall Jump Triggered");
        }
    }

    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        wallJumpCooldown = 0;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    public void Move(float direction)
    {
        body.velocity = new Vector2(direction * speed, body.velocity.y);
    }

    // Button Press Handlers
    public void OnLeftButtonPressed(BaseEventData data)
    {
        isLeftPressed = true;
    }

    public void OnRightButtonPressed(BaseEventData data)
    {
        isRightPressed = true;
    }

    public void OnJumpButtonPressed()
    {
        Jump();
        SoundManager.instance.PlaySound(jumpSound);
    }

    // Button Release Handlers
    public void OnLeftButtonReleased(BaseEventData data)
    {
        isLeftPressed = false;
    }

    public void OnRightButtonReleased(BaseEventData data)
    {
        isRightPressed = false;
    }

    // Helper function to add event triggers
    private void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction<BaseEventData> callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
    }
}
