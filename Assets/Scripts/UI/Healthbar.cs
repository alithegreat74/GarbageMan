using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Healthbar : MonoBehaviour
    {
        private Stats _stats;

        [SerializeField] private Slider _slider;

        private void Start()
        {
            _stats = GetComponentInParent<Stats>();
            _stats.onHealthChanged += OnHealthChanged;

            _slider.maxValue = _stats.health.GetValue();
            _slider.value = _slider.maxValue;
        }

        private void OnHealthChanged(float health)
        {
            _slider.value = health;
        }
    }
}