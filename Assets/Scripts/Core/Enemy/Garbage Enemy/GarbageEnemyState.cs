using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemyState : EnemyState
{
    protected GarbageEnemy enemy;

    public GarbageEnemyState(Entity entity, Statemachine stateMachine, string animBoolName, Enemy enemyBase, GarbageEnemy enemy) : base(entity, stateMachine, animBoolName, enemyBase)
    {
        this.enemy=enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void Update()
    {
        base.Update();
    }
}
