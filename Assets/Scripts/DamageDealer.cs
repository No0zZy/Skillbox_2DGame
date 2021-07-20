using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private enum Owner
    {
        Player,
        Enemy
    }

    [SerializeField] private Owner owner;
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(owner)
        {
            case Owner.Player:
                if (collision.CompareTag("Enemy"))
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                }
                break;
            case Owner.Enemy:
                if (collision.CompareTag("Player"))
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                }
                break;

        }

        Destroy(gameObject);
    }
}
