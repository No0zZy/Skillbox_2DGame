using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D)),
    RequireComponent(typeof(CharacterAnimation))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxDelaySwitchDirection;

    private int direction;
    private bool isLookRight;

    private SpriteRenderer sr;
    private CharacterAnimation anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<CharacterAnimation>();
    }

    private void Start()
    {
        direction = 1;
        isLookRight = false;

        StartCoroutine(DelaySwitchDirection());
    }

    private void FixedUpdate()
    {
        if (anim.State == CharacterState.Run)
            Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (isLookRight && rb.velocity.x < 0)
        {
            isLookRight = false;
            sr.flipX = false;
        }
        else if (!isLookRight && rb.velocity.x > 0)
        {
            isLookRight = true;
            sr.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter " + collision.tag + collision.gameObject.name);

        if(collision.gameObject.CompareTag("EnemyFlip"))
        {
            Debug.Log(true);
            anim.Idle();
            StartCoroutine(DelaySwitchDirection());
        }
    }


    private IEnumerator DelaySwitchDirection()
    {        
        yield return new WaitForSeconds(Random.Range(0, maxDelaySwitchDirection));

        direction = -direction;

        anim.Run();
    }
}