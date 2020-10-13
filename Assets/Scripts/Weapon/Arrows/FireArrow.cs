using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : Arrow
{
    [SerializeField] private int _burningDamag;
    [SerializeField] private int _burningDuration;
    [SerializeField] private float _burningStep;
    public override void SpecialEffect(Enemy enemy)
    {
        if (!enemy.TryGetComponent(out Fire fire))
        {
            fire = enemy.gameObject.AddComponent<Fire>();
            fire.SetFields(_burningDuration, _burningDamag, _burningStep);
            fire.enabled = true;
        }
        else
        {
            if (fire.enabled == true)
            {
                fire.enabled = false;
                fire.enabled = true;
            }
            else
            {
                fire.enabled = true;
            }
        }
    }
}
