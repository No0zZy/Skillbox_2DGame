using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    [SerializeField] private Health health;

    private void Awake()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        healthBar.fillAmount = health.CurrentHealth / health.MaxHealth;
    }

}
