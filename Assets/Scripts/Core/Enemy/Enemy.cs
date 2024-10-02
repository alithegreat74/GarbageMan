using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for developing logic that is the same for all the enemies
public class Enemy : Entity
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public Vector3 PlayerDirection() => Vector3.Normalize(Player.instance.transform.position - transform.position);
    public float PlayerDistance()=>Vector3.Distance(transform.position, Player.instance.transform.position);
}
