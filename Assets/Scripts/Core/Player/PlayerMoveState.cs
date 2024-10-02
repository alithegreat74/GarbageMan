using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{


    public PlayerMoveState(Entity entity, Statemachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();


        entity.FlipController();
        Vector2 input = InputHandling.InputHandler.move.GetValue();
        player.SetVelocity(player.stats.moveSpeed.GetValue() * input.x, rb.velocity.y, player.stats.moveSpeed.GetValue()* input.y);
        if (input == Vector2.zero)
        {
            statemachine.ChangeState(player.IdleState);
            return;
        }
        if (InputHandling.InputHandler.attack.GetValue())
        {
            statemachine.ChangeState(player.AttackState);
            return;
        }

        player.faceOrientation = input;
    }

    public override void Exit()
    {
        base.Exit();
    }

}
