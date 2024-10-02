using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Statemachine statemachine;
    protected Entity entity;

    protected Rigidbody rb;

    private string animBoolName;

    protected bool triggerCalled;


    public State(Entity entity, Statemachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.statemachine = stateMachine;
        this.animBoolName = animBoolName;
        this.rb = entity.rb;
    }

    public virtual void Enter()
    {
        entity.anim.SetBool(animBoolName, true);
        triggerCalled = false;
        
    }

    public virtual void Update()
    {

    }



    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    public void TriggerAnimation()
    {
        triggerCalled = true;
    }
}
