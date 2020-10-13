using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napalm : MonoBehaviour
{
    private int _stuckCount = 1;
    private int _maxStuckCount;
    private float _duration;
    private float _timer = 0;
    private float _speedSlowPerStuck;
    private float _AttackSlowPerStuck;
    private float _napalmDamageCoef = 1;
    private Enemy _enemy;

    public int StuckCount => _stuckCount;
    public float NapalmDamageCoef => _napalmDamageCoef;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        
        TrySlowDown();
    }

    private void OnDisable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _duration)
        {
            _enemy.Deceleration(-_speedSlowPerStuck * _stuckCount, -_AttackSlowPerStuck * _stuckCount);
            _stuckCount = 0;
            this.enabled = false;
        }
    }

    private void TrySlowDown()
    {
        if (_stuckCount < _maxStuckCount)
        {
            _enemy.Deceleration(_speedSlowPerStuck, _AttackSlowPerStuck);
            _stuckCount++;
            _timer = 0;
        }
        else
            _timer = 0;
    }

    public void SetFields(float duration, float speedSlow, float attackSlow, int maxStuckCount)
    {
        _duration = duration;
        _speedSlowPerStuck = speedSlow;
        _AttackSlowPerStuck = attackSlow;
        _maxStuckCount = maxStuckCount;
    }
}
