using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region States
    public PlayerIdleState IdleState { get; private set;}
	public PlayerMoveState MoveState { get; private set;}
	public PlayerAttackState AttackState { get; private set;}

    #endregion
    #region Variables
    public float attackRange;
    public float attackDistance;
    #endregion
    public static Player instance;
    protected override void Awake()
    {
        base.Awake();	
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        IdleState = new PlayerIdleState(this, statemachine, "Idle", this);
        MoveState = new PlayerMoveState(this, statemachine, "Move", this);
        AttackState = new PlayerAttackState(this, statemachine, "Attack", this);
        statemachine.Initialize(IdleState);
    }
    protected override void Update()
    {
        base.Update();   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 input = InputHandling.InputHandler.move.GetValue();
        if (input == Vector2.zero)
        {
            Gizmos.DrawWireSphere(new Vector3(facingRight * attackDistance + transform.position.x, transform.position.y, transform.position.z), attackRange);
        }
        else
        {
            Gizmos.DrawWireSphere(new Vector3(attackDistance * input.x + transform.position.x, transform.position.y, transform.position.z + input.y * attackDistance), attackRange);

        }
    }

}
