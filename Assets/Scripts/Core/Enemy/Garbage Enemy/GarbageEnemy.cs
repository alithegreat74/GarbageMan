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

    [Header("Particles")]
    [SerializeField] private GameObject knockbackParticle;
    [SerializeField] private GameObject deathParticle;
    private bool _isKnockingBack;

    Sequence _currentSequence;
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
        _currentSequence = transform.DOJump(transform.position + direction * stats.moveSpeed.GetValue(), jumpPower, 1, jumpDuration).OnComplete(() => _isJumping = false);
    }

    public override void Knockback(Stats stats)
    {
        Vector3 direction = transform.position - stats.transform.position;

        GameObject obj = Instantiate(knockbackParticle, transform.position, Quaternion.identity);
        obj.GetComponent<ParticleSystem>().Play();

        if (_currentSequence != null && _currentSequence.IsActive())
        {
            _currentSequence.Kill();
            _isJumping = false;
        }

        if (direction.x >= 0)
            direction.x = 1;
        else
            direction.x = -1;

        if (direction.z >= 0)
            direction.z = 1;
        else
            direction.z = -1;

        direction.y = 0;

        rb.velocity = direction * stats.knockback.GetValue();

        StartCoroutine(Knockback_Cor());
    }

    private IEnumerator Knockback_Cor()
    {
        _isKnockingBack = true;
        yield return new WaitForSeconds(0.5f);
        _isKnockingBack = false;
    }

    public override void Die()
    {
        base.Die();
        GameObject obj=Instantiate(deathParticle, transform.position, Quaternion.identity);
        obj.GetComponent<ParticleSystem>().Play();
    }
}



