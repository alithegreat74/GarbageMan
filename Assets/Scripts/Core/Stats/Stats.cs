using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Stat moveSpeed;
    public Stat attackPower;
    public Stat health;

    [SerializeField] protected float _currentHealth;

    public delegate void OnHealthChanged(float health);
    public event OnHealthChanged onHealthChanged;


    private Entity _entity;

    private void Start()
    {
        _entity = GetComponent<Entity>();
        _currentHealth = health.GetValue();
    }

    public virtual void TakeDamage(Stats attacker)
    {
        _currentHealth -= attacker.attackPower.GetValue();
        onHealthChanged?.Invoke(_currentHealth);

        _entity.Knockback();

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        onHealthChanged?.Invoke(_currentHealth);
    }

    private void Die()
    {
        _entity.Die();
    }
}
