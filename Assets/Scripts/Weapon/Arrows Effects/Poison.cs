using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    private float _duration;
    private int _damag;
    private WaitForSeconds _step;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        
        StartCoroutine(Poisoned(enemy));
    }
    private void OnDisable()
    {
        StopCoroutine(Poisoned(enemy));
    }
    private IEnumerator Poisoned(Enemy enemy)
    {
        for (int i = 0; i <= _duration; i++)
        {
            if (enemy.Health > 0)
                enemy.TakeDamage(_damag);
            else
                break;
            yield return _step;
        }
        this.enabled = false;
    }

    public void SetFields(float duration, int damag, int step)
    {
        _duration = duration;
        _damag = damag;
        _step = new WaitForSeconds(step);
    }
}
