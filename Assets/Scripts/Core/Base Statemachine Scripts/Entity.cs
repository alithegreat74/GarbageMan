using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody rb { get; private set; }
    public Statemachine statemachine { get; private set;}
    public Stats stats { get; private set; }
    #endregion


    public delegate void OnDeath(Entity e);
    public event OnDeath onDeath;
    protected virtual void Awake()
    {
        statemachine=new Statemachine();
    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<Stats>();
    }

    protected virtual void Update()
    {
        statemachine.currentState.Update();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        onDeath?.Invoke(this);
    }

    public virtual void Knockback(Stats stats)
    {
    }
    public void SetVelocity(Vector3 velocity) => rb.velocity = velocity;
    public void SetVelocity(float x, float y,float z) => rb.velocity = new Vector3(x,y,z);
}
