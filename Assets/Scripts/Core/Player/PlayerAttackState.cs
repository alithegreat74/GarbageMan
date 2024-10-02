using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{


    public PlayerAttackState(Entity entity, Statemachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //CameraShakeManager.instance.ShakeWithoutProfile(1f, 0.2f);
    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            if (InputHandling.InputHandler.move.GetValue() != Vector2.zero)
                statemachine.ChangeState(player.MoveState);
            else
                statemachine.ChangeState(player.IdleState);

            return;
        }   
    }

    public override void Exit()
    {
        base.Exit();
    }

}
