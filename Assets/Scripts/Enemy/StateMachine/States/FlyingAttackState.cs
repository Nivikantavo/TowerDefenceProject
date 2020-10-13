using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAttackState : State
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _circuleRadius;
    [SerializeField] private int _speed;

    private float _angelRotation;
    private float _lastAttackTime;
    private Animator _animator;
    private Vector2 _centerOfMovment;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _centerOfMovment = transform.position;
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _attackDelay;
        }
        _lastAttackTime -= Time.deltaTime;

        CircularMotion();
    }

    private void Attack()
    {
        _animator.Play("Attack");

        _weapon.Shoot(_shootPoint);
    }

    private void CircularMotion()
    {
        _angelRotation += Time.deltaTime;
        transform.position = new Vector2(Mathf.Cos(_angelRotation * _speed) * _circuleRadius, Mathf.Sin(_angelRotation * _speed) * _circuleRadius) + _centerOfMovment;
    }
}
