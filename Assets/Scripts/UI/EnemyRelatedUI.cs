using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using Level;
namespace UI
{
    public class EnemyRelatedUI : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro enemyNumber;
        [SerializeField] private Slider slider;
        [Header("Upgrades")]
        [SerializeField] private UpgradePanelUI attackPower;
        [SerializeField] private UpgradePanelUI moveSpeed;
        private void OnEnable()
        {
            StartCoroutine(Enable_Cor());
        }

        private IEnumerator Enable_Cor()
        {
            yield return new WaitForSeconds(0.1f);
            WaveGenerator.instance.onEnemiesUpdated += OnEnemyDeath;
            WaveGenerator.instance.onNewWaveGenerated += OnWaveGenerated;

            UpgradeManager.OnUpgrade += OnUpgrade;
            enemyNumber.text = WaveGenerator.instance.currentCount.ToString();
            slider.value = 1;
        }

        private void OnEnemyDeath(int enemyCount)
        {
            enemyNumber.text = enemyCount.ToString();
        }

        private void OnWaveGenerated(int wave)
        {
            slider.value=wave;
        }
        private void OnUpgrade(UpgradeType type)
        {
            switch (type)
            {
                case UpgradeType.Speed:
                    moveSpeed.Recharge();
                    break;
                case UpgradeType.Power:
                    attackPower.Recharge();
                    break;
            }
        }
    }

}