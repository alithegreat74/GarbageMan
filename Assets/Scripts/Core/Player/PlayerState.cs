using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{

    protected Player player;

    public PlayerState(Entity entity, Statemachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName)
    {
        this.player=player;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Vector2 input = InputHandling.InputHandler.move.GetValue();
        if(input!=Vector2.zero)
            player.faceOrientation = input;
        if (InputHandling.InputHandler.attack.GetValue() && statemachine.currentState.ToString() != "PlayerAttackState")
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
