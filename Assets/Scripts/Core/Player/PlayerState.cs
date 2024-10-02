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
        //Attack If the input is done and if you're not in the atack state
        if (InputHandling.InputHandler.attack.GetValue() && statemachine.currentState.ToString() != "PlayerAttackState")
            statemachine.ChangeState(player.AttackState);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
