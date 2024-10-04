using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemyMoveState:GarbageEnemyState
{
    private float _speed;
    public GarbageEnemyMoveState(Entity entity, Statemachine stateMachine, string animBoolName, Enemy enemyBase, GarbageEnemy enemy) : base(entity, stateMachine, animBoolName, enemyBase, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _speed = UnityEngine.Random.Range(enemy.stats.moveSpeed.GetValue() - 0.25f, enemy.stats.moveSpeed.GetValue() + 0.5f);
    }

    public override void Exit()
    {
        base.Exit();
        

    }

    public override void Update()
    {
        base.Update();
        Vector3 playerDirection = enemy.PlayerDirection();
        enemy.Move(playerDirection, _speed);
        if(enemy.PlayerDistance()<=enemy.minDistance)
        {
            Player.instance.GetComponent<Stats>().TakeDamage(enemy.stats);
            return;
        }    
        
    }

}