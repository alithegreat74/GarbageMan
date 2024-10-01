using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemy : Enemy
{
    

    #region States
    public GarbageEnemyIdleState IdleState { get; private set;}
	public GarbageEnemyMoveState MoveState { get; private set;}
	
    #endregion


    protected override void Awake()
    {
        base.Awake();
        IdleState = new GarbageEnemyIdleState(this,statemachine,"Idle",this,this);
		MoveState = new GarbageEnemyMoveState(this,statemachine,"Move",this,this);
		
    }

    protected override void Start()
    {
        base.Start();
        //GarbageEnemy starts in the set state if you want to change the first state, change the argument
        statemachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        statemachine.currentState.Update();
    }

}



