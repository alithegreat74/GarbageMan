using log4net.Util;
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
        player.slashParticle.Play();
    }

    public override void Update()
    {
        base.Update();

        Vector2 input = InputHandling.InputHandler.move.GetValue();
        Vector3 playerPos = player.transform.position;

        player.SetVelocity(player.stats.moveSpeed.GetValue() * input.x, rb.velocity.y, player.stats.moveSpeed.GetValue() * input.y);

        float targetAngle = 0;
        if (input == Vector2.zero)
        {
            player.slashParticle.gameObject.transform.position = 
                new Vector3(player.faceOrientation.x * player.attackDistance/2 + playerPos.x, playerPos.y, player.faceOrientation.y * player.attackDistance / 2 + playerPos.z);

            targetAngle = Mathf.Atan2(player.faceOrientation.x, player.faceOrientation.y) * Mathf.Rad2Deg;
        }
        else
        {
            player.slashParticle.gameObject.transform.position = 
                new Vector3(player.attackDistance/2 * input.x + playerPos.x, playerPos.y, playerPos.z + input.y * player.attackDistance);

            targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        }
        
        player.slashParticle.gameObject.transform.rotation = Quaternion.Euler(82.5f, targetAngle + 90, 0f);

        if (triggerCalled)
        {
            if (InputHandling.InputHandler.move.GetValue() != Vector2.zero)
                statemachine.ChangeState(player.MoveState);
            else
                statemachine.ChangeState(player.IdleState);
        }   
    }

    public override void Exit()
    {
        base.Exit();
    }

}
