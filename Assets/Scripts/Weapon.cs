using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform attackZonePointRight;
    [SerializeField] private Transform attackZonePointLeft;
    [SerializeField] private GameObject attackZoneGo;

    [SerializeField] private bool flipXOffToRight;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SpawnAttackZone()
    {
        if (flipXOffToRight)
        {
            if (!sr.flipX)
                Instantiate(attackZoneGo, attackZonePointRight.position, Quaternion.identity);
            else
                Instantiate(attackZoneGo, attackZonePointLeft.position, Quaternion.identity);
        }
        else
        {
            if (sr.flipX)
                Instantiate(attackZoneGo, attackZonePointRight.position, Quaternion.identity);
            else
                Instantiate(attackZoneGo, attackZonePointLeft.position, Quaternion.identity);
        }

    }
}