using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private float damagePerCollision;
    [SerializeField] private Cutscene reloadLevel;
    [SerializeField] private float delayReloadLevel;
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            health.TakeDamage(damagePerCollision);

        CheckReloadScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            health.TakeDamage(damagePerCollision);

        if (collision.gameObject.CompareTag("Cutscene"))
        {
            cutsceneManager.LoadCutscene(collision.GetComponent<Cutscene>());
        }

        if (collision.gameObject.CompareTag("Death"))
            health.TakeDamage(health.MaxHealth);

        CheckReloadScene();
    }

    private void CheckReloadScene()
    {
        if (!health.IsAlive)
            StartCoroutine(DelayReload());
    }

    private IEnumerator DelayReload()
    {
        yield return new WaitForSeconds(delayReloadLevel);
        cutsceneManager.LoadCutscene(reloadLevel);
    }
}
