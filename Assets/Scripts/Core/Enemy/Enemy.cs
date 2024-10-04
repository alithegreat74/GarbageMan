using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for developing logic that is the same for all the enemies
public class Enemy : Entity
{
    public float detectionRange;
    public float minDistance;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    [SerializeField] protected GameObject hitAudio;
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
    protected void LateUpdate()
    {
        if (transform.position.y < -4)
            Die();
    }

    public Vector3 PlayerDirection()
    {

        if(Player.instance != null)   
            return Vector3.Normalize(Player.instance.transform.position - transform.position);

        return Vector3.zero;
    }
    public float PlayerDistance()
    {
        if(Player.instance != null)
            return Vector3.Distance(transform.position, Player.instance.transform.position);

        return 0;
    }
    public override void Die()
    {
        base.Die();
        foreach(var item in items)
        {
            if (!UpgradeManager.CanUpgrade(item.GetComponent<Upgrade>()))
                continue;


            Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    public override void Knockback(Stats stats)
    {
        base.Knockback(stats);
        
    }
}
