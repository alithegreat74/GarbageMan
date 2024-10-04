using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float reachTime;
    [SerializeField] private float maxDistance;
    [SerializeField] private float lifeTime;
    [SerializeField] private float waitTime;

    private Collider collider;

    public Upgrade upgrade;
    private void OnEnable()
    {
        collider = GetComponent<Collider>();
        StartCoroutine(FollowPlayer());        
    }

    private IEnumerator FollowPlayer()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(waitTime);
        collider.enabled = true;
        float timer = 0;
        while (timer <= reachTime)
        {
            timer += Time.deltaTime;
            Vector3 lerp = Vector3.Lerp(transform.position, Player.instance.transform.position, timer / reachTime);
            transform.position = lerp;
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        if (upgrade.type == UpgradeType.Health)
            Player.instance.GetComponent<Stats>().Heal(upgrade.value);
        else
            upgrade.AddUpgrade();

        StopAllCoroutines();
        transform.position = new Vector3(1000000000, 1000000000, 100000000);
    }
}
