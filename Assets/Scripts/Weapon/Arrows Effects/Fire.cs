using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float _duration;
    private int _damag;
    private WaitForSeconds _step;
    private Enemy enemy;
    private float _napalmDamageCoef = 1;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        StartCoroutine(Burning(enemy));
    }
    private void OnDisable()
    {
        StopCoroutine(Burning(enemy));
    }
    private IEnumerator Burning(Enemy enemy)
    {
        for (int i = 0; i <= _duration; i++)
        {
            IsNapalmed();
            if (enemy.Health > 0)
                enemy.TakeDamage(_damag * _napalmDamageCoef);
            else
                break;
            Debug.Log(_damag * _napalmDamageCoef);
            yield return _step;
        }
        this.enabled = false;
    }

    public bool IsNapalmed()
    {
        if (enemy.TryGetComponent(out Napalm napalm))
        {
            if (napalm.enabled == true)
            {
                _napalmDamageCoef = napalm.StuckCount * napalm.NapalmDamageCoef;
                return true;
            }
        }
        _napalmDamageCoef = 1;
        return false;
    }
    public void SetFields(float duration, int damag, float step)
    {
        _duration = duration;
        _damag = damag;
        _step = new WaitForSeconds(step);
    }
}
