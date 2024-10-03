using UnityEngine;
using CameraRelated;


public class Stats : MonoBehaviour
{
    public Stat moveSpeed;
    public Stat attackPower;
    public Stat health;
    public Stat knockback;

    [SerializeField] protected float _currentHealth;

    [SerializeField] private float _cameraShakeIntensity;
    [SerializeField] private float _cameraShakeTime;

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

        _entity.Knockback(attacker);

        if (_currentHealth <= 0)
            Die();
        
        CameraShakeManager.ShakeWithoutProfile(_cameraShakeIntensity, _cameraShakeTime);
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
