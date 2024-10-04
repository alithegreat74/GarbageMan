using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static Dictionary<UpgradeType,Upgrade> _upgrades = new Dictionary<UpgradeType, Upgrade>();

    [SerializeField] private float maxTimeRef;

    public static float maxTime;


    public  delegate void UpgradeCallback(UpgradeType upgrade);
    public static event UpgradeCallback OnUpgrade;
    private void Start()
    {
        maxTime = maxTimeRef;
    }
    public static bool AddUpgrade(Upgrade name)
    {

        if (_upgrades.ContainsKey(name.type))
            return false;

        var stats=Player.instance?.GetComponent<Stats>();

        switch(name.type)
        {
            case UpgradeType.Speed:
                stats.moveSpeed.AddModifier(name.value); 
                break;
            case UpgradeType.Power:
                stats.attackPower.AddModifier(name.value);
                break;
        }

        OnUpgrade?.Invoke(name.type);

        _upgrades.Add(name.type,name);
        return true;
    }
    public static bool CanUpgrade(Upgrade name)
    {
        return !_upgrades.ContainsKey(name.type);
    }
    public static void RemoveUpgrade(Upgrade name)
    {
        if (!_upgrades.ContainsKey(name.type))
            return;

        var stats = Player.instance?.GetComponent<Stats>();

        switch (name.type)
        {
            case UpgradeType.Speed:
                stats.moveSpeed.RemoveModifier(name.value);
                break;
            case UpgradeType.Power:
                stats.attackPower.RemoveModifier(name.value);
                break;
        }

        _upgrades.Remove(name.type);
    }

}
