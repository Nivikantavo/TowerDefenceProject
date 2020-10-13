using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmArrow : Arrow
{
    [SerializeField] private float _duration;
    [SerializeField] private float _speedSlow;
    [SerializeField] private float _AttackSlow;
    [SerializeField] private int _maxStuckCount;

    public override void SpecialEffect(Enemy enemy)
    {
        if (!enemy.TryGetComponent(out Napalm napalm))
        {
            napalm = enemy.gameObject.AddComponent<Napalm>();
            napalm.SetFields(_duration, _speedSlow, _AttackSlow, _maxStuckCount);
            napalm.enabled = true;
        }
        else
        {
            if (napalm.enabled == true)
            {
                napalm.enabled = false;
                napalm.enabled = true;
            }
            else
            {
                napalm.enabled = true;
            }
        }
    }

}
