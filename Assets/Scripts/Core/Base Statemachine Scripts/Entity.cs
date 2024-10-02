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

    protected virtual void Flip()
    {

    }
    protected virtual void FlipController()
    {

    }
    public void SetVelocity(Vector3 velocity) => rb.velocity = velocity;
    public void SetVelocity(float x, float y,float z) => rb.velocity = new Vector3(x,y,z);

}
