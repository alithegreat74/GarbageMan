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

        if (input == Vector2.zero)
            player.slashParticle.gameObject.transform.position = 
                new Vector3(player.facingRight * player.attackDistance/2 + player.transform.position.x, player.transform.position.y, player.transform.position.z);
        else
            player.slashParticle.gameObject.transform.position = 
                new Vector3(player.attackDistance/2 * input.x + player.transform.position.x, player.transform.position.y, player.transform.position.z + input.y * player.attackDistance);
        
        var targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
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
