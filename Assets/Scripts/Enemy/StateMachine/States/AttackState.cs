using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private bool _miliAttackType;
    [SerializeField] private EnemyGun _weapon;
    [SerializeField] private Transform _shootPoint;

    private int _damage;
    private float _attackDelay;
    private float _lastAttackTime;
    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _damage = GetComponent<Enemy>().Damag;
        _attackDelay = GetComponent<Enemy>().AttackDelay;
        _animator = GetComponent<Animator>();
        _animator.speed = 1 / _attackDelay;
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _attackDelay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Castle target)
    {
        _animator.speed = 1 / _attackDelay;
        _animator.Play("Attack");
        
        if (_miliAttackType)
            target.TakeDamage(_damage);
        else
        {
            _weapon.Shoot(_shootPoint);
        }
    }
    private void OnEnable()
    {
        _enemy.AttackDelayChanged += OnAttackDelayChanged;
    }

    private void OnDisable()
    {
        _enemy.AttackDelayChanged -= OnAttackDelayChanged;
    }

    private void OnAttackDelayChanged(float newAttackDelay)
    {
        _attackDelay = newAttackDelay;
    }
}
