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

    [HideInInspector] public int facingRight = 1;


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
    }

    public virtual void Knockback()
    {
    }

    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight *= -1;
    }
    public virtual void FlipController()
    {
        if (rb.velocity.x > 0 && facingRight < 0)
            Flip();
        else if(rb.velocity.x<0 && facingRight > 0)
            Flip();
            
    }
    public void SetVelocity(Vector3 velocity) => rb.velocity = velocity;
    public void SetVelocity(float x, float y,float z) => rb.velocity = new Vector3(x,y,z);
}
