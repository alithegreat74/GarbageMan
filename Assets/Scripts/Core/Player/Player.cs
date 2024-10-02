using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerIdleState IdleState { get; private set;}
	public PlayerMoveState MoveState { get; private set;}
	public PlayerAttackState AttackState { get; private set;}
	
    #endregion
    
    protected override void Awake()
    {
        base.Awake();
        
		
    }
    protected override void Start()
    {
        base.Start();
        IdleState = new PlayerIdleState(this, statemachine, "Idle", this);
        MoveState = new PlayerMoveState(this, statemachine, "Move", this);
        AttackState = new PlayerAttackState(this, statemachine, "Attack", this);
        statemachine.Initialize(IdleState);
    }
    protected override void Update()
    {
        base.Update();
        Debug.Log(statemachine.currentState);
    }
    public void SetVelocity(Vector3 velocity)=>rb.velocity = velocity;
}
