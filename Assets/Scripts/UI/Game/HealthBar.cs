using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Castle _castle;

    private void OnEnable()
    {
        _castle.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _castle.HealthChanged -= OnValueChanged;
    }
}
