using Codice.Utils;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageEnemy : Enemy
{
    

    #region States
    public GarbageEnemyIdleState IdleState { get; private set;}
	public GarbageEnemyMoveState MoveState { get; private set;}

    #endregion

    #region Variables
    public float detectionRange;
    public float minDistance;
    [Header("Movement")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDuration;

    [Header("Knockback")]
    [SerializeField] private float knockbackJumpPower;
    [SerializeField] private float knockbackJumpDuration;
    private bool _isJumping;

    private bool _isKnockingBack;
    #endregion


    protected override void Awake()
    {
        base.Awake();	
    }

    protected override void Start()
    {
        base.Start();
        //GarbageEnemy starts in the set state if you want to change the first state, change the argument
        IdleState = new GarbageEnemyIdleState(this,statemachine,"Idle",this,this);
		MoveState = new GarbageEnemyMoveState(this,statemachine,"Move",this,this);
        statemachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        statemachine.currentState.Update();
    }
    public void Move(Vector3 direction)
    {
        if (_isJumping || _isKnockingBack)
            return;

        _isJumping = true;
        transform.DOJump(transform.position + direction * stats.moveSpeed.GetValue(), jumpPower, 1, jumpDuration).OnComplete(() => _isJumping = false);
    }

    public override void Knockback(Stats stats)
    {
        Vector3 direction = Vector3.Normalize(transform.position - stats.transform.position);
        rb.velocity = direction * stats.knockback.GetValue();
        StartCoroutine(Knockback_Cor());
    }

    private IEnumerator Knockback_Cor()
    {
        _isKnockingBack = true;
        yield return new WaitForSeconds(0.5f);
        _isKnockingBack = false;
    }
}



