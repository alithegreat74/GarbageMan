using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemyIdleState:GarbageEnemyState
{

    public GarbageEnemyIdleState(Entity entity, Statemachine stateMachine, string animBoolName, Enemy enemyBase, GarbageEnemy enemy) : base(entity, stateMachine, animBoolName, enemyBase, enemy)
    {
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
        if (enemy.PlayerDistance() <= enemy.detectionRange)
            statemachine.ChangeState(enemy.MoveState);
    }

}