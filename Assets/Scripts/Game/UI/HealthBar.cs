using System;
using Enemies.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private EntityHealth trackedHealth;

        private void OnEnable()
        {
            trackedHealth.OnHealthChanged += ChangeHealth;
        }

        private void ChangeHealth()
        {
            float newValue = trackedHealth.CurrentHealth / trackedHealth.MaxHealth;
            healthSlider.value = newValue;
        }
    }
}
