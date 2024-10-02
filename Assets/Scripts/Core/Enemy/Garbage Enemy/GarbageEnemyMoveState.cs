using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemyMoveState:GarbageEnemyState
{

    public GarbageEnemyMoveState(Entity entity, Statemachine stateMachine, string animBoolName, Enemy enemyBase, GarbageEnemy enemy) : base(entity, stateMachine, animBoolName, enemyBase, enemy)
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
        Vector3 playerDirection = enemy.PlayerDirection();
        enemy.Move(playerDirection);
        if(enemy.PlayerDistance()<=enemy.minDistance)
        {
            Player.instance.GetComponent<Stats>().TakeDamage(enemy.stats);
            return;
        }    
        
    }

}