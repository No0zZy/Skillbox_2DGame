using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform groundedTransform;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;

    private Rigidbody2D rb;
    private CharacterAnimation playerAnim;
    private SpriteRenderer sr;

    private bool isLookRight = true;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<CharacterAnimation>();
    }

    private void FixedUpdate()
    {
        Vector2 overlapCirclePosition = groundedTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, groundCheckRadius, groundMask);
    }

    private void Update()
    {
        if (playerAnim.State == CharacterState.OnAir && isGrounded)
            playerAnim.OnGround();

        if (playerAnim.State != CharacterState.OnAir && !isGrounded)
            playerAnim.OnAir();

        playerAnim.SetVerticalVelocity(rb.velocity.y);
    }

    public void Move(float direction, bool isJump)
    {
        if (playerAnim.State == CharacterState.Attack || playerAnim.State == CharacterState.Death)
            return;

        if (isJump)
            Jump();

        if (direction != 0)
        {
            if(playerAnim.State == CharacterState.Idle)
                playerAnim.Run();
            HorizontalMove(direction);
        }
        else if(playerAnim.State == CharacterState.Run)
            playerAnim.Idle();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAnim.Jump();
        }
    }

    public void Attack()
    {
        Debug.Log("attack pressed");
        if (playerAnim.State != CharacterState.Idle && playerAnim.State != CharacterState.Run)
            return;

        playerAnim.Attack();
    }

    private void HorizontalMove(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) * speed ,rb.velocity.y);

        if (isLookRight && rb.velocity.x < 0)
        {
            isLookRight = false;
            sr.flipX = true;
        }
        else if(!isLookRight && rb.velocity.x > 0)
        {
            isLookRight = true;
            sr.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundedTransform.position, groundCheckRadius);
    }
}
