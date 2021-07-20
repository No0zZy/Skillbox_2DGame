using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObject : MonoBehaviour
{
    [SerializeField] private GameObject explosionPref;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        if (collision.gameObject.CompareTag("Fire"))
        {
            var exp = Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
