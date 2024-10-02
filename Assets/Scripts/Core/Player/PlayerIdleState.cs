using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{


    public PlayerIdleState(Entity entity, Statemachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.velocity.y, 0);
    }

    public override void Update()
    {
        base.Update();
        if (InputHandling.InputHandler.move.GetValue() != Vector2.zero)
        {
            statemachine.ChangeState(player.MoveState);
            return;
        }

        if (InputHandling.InputHandler.attack.GetValue())
        {
            statemachine.ChangeState(player.AttackState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
