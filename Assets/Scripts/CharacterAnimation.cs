using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Idle,
    Run,
    Attack,
    OnAir,
    TakeDamage,
    Death
}

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    public CharacterState State { get; private set; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        State = CharacterState.Idle;
    }

    public void Run()
    {
        State = CharacterState.Run;
        anim.SetBool("IsRunning", true);
    }

    public void Idle()
    {
        State = CharacterState.Idle;
        anim.SetBool("IsRunning", false);
    }

    public void Attack()
    {
        State = CharacterState.Attack;
        anim.SetBool("IsRunning", false);
        anim.SetTrigger("Attack");
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
        OnAir();
    }

    public void OnAir()
    {
        State = CharacterState.OnAir;
        anim.SetBool("OnAir", true);
    }

    public void OnGround()
    {
        Idle();
        anim.SetBool("OnAir", false);
    }

    public void Death()
    {
        State = CharacterState.Death;
        anim.SetTrigger("Death");
    }

    public void TakeDamage()
    {
        State = CharacterState.TakeDamage;
        anim.SetTrigger("TakeDamage");
    }

    public void SetVerticalVelocity(float velocity)
    {
        anim.SetFloat("VerticalVelocity", velocity);
    }
}
