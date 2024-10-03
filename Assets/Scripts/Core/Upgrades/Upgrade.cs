using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Health,
    Speed,
    Power
}
public class Upgrade:MonoBehaviour
{
    public UpgradeType type;
    public float value;

    private float timer;
    public void AddUpgrade()
    {
        if (UpgradeManager.AddUpgrade(this))
            timer = 0;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>=UpgradeManager.maxTime)
        {
            UpgradeManager.RemoveUpgrade(this);

            Destroy(gameObject);

        }
    }

}
