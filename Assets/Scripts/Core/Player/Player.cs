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
        IdleState = new PlayerIdleState(this,statemachine,"Idle",this);
		MoveState = new PlayerMoveState(this,statemachine,"Move",this);
		AttackState = new PlayerAttackState(this,statemachine,"Attack",this);
		
    }
    protected override void Start()
    {
        base.Start();
        statemachine.Initialize(IdleState);
    }
    protected override void Update()
    {
        base.Update();

    }
}
