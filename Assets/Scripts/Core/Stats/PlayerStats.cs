using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    [SerializeField] private float invincibilityTime;
    private bool _invincible;

    public override void TakeDamage(Stats attacker)
    {
        if (_invincible)
            return;

        StartCoroutine(SetInvincibility());
        base.TakeDamage(attacker);
    }

    private IEnumerator SetInvincibility()
    {
        _invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        _invincible = false;
    }
}
