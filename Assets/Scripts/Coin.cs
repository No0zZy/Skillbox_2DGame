using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scorePoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin triggered " + collision.gameObject.name);

        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scorePoints);
            Destroy(gameObject);
        }
    }
}