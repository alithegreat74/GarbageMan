using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        StartCoroutine(Start_Cor());
    }
    private IEnumerator Start_Cor()
    {
        yield return new WaitForSeconds(0.1f);
        slider.maxValue = UpgradeManager.maxTime;
        slider.value = 0;
    }
    private void Update()
    {
        if (slider == null || slider.value <= 0)
            return;

        slider.value-=Time.deltaTime;
    }

    public void Recharge()
    {
        slider.value=slider.maxValue;
    }
}
