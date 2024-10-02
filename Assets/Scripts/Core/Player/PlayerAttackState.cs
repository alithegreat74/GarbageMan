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


        player.jarooSlash1.Play();

        //CameraShakeManager.instance.ShakeWithoutProfile(1f, 0.2f);
    }

    public override void Update()
    {
        base.Update();

        Vector2 input = InputHandling.InputHandler.move.GetValue();

        if (input == Vector2.zero)
        {
            player.jarooSlash1.gameObject.transform.position = new Vector3(player.facingRight * player.attackDistance/2 + player.transform.position.x, player.transform.position.y, player.transform.position.z);
            var targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            player.jarooSlash1.gameObject.transform.rotation = Quaternion.Euler(82.5f, targetAngle + 90, 0f);
        }
        else
        {
            player.jarooSlash1.gameObject.transform.position = new Vector3(player.attackDistance/2 * input.x + player.transform.position.x, player.transform.position.y, player.transform.position.z + input.y * player.attackDistance);
            var targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            player.jarooSlash1.gameObject.transform.rotation = Quaternion.Euler(82.5f, targetAngle + 90, 0f);
        }

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
