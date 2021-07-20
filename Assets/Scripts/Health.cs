using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; protected set; }
    public bool IsAlive { get; private set; }

    public UnityEvent Death;

    private CharacterAnimation anim;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        IsAlive = true;

        anim = GetComponent<CharacterAnimation>();
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (CurrentHealth > 0)
        {
            IsAlive = true;

            if (anim != null)
                anim.TakeDamage();
        }
        else
        {
            CurrentHealth = 0;
            IsAlive = false;

            Death?.Invoke();

            if (anim != null)
                anim.Death();
        }
    }

}
