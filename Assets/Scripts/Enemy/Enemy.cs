using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damag;
    [SerializeField] private int _reward;
    [SerializeField] private bool _isFlying;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDelay;

    protected Castle _Target;

    private Animator _animator;

    public float Health => _health;
    public int Reward => _reward;
    public int Damag => _damag;
    public float Speed => _speed;
    public float AttackDelay => _attackDelay;
    public bool IsFlying => _isFlying;
    public Castle Target => _Target;

    public event UnityAction<Enemy> Dying;
    public event UnityAction<float> SpeedChanged;
    public event UnityAction<float> AttackDelayChanged;

    public void Init(Castle target)
    {
        _Target = target;
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying?.Invoke(this);
        }
    }

    public void Deceleration(float speedSlow, float attackDelaySlow)
    {
        _speed -= speedSlow;
        SpeedChanged?.Invoke(_speed);
        _attackDelay += attackDelaySlow;
        if (_attackDelay < 1)
            _attackDelay = 1;
        AttackDelayChanged?.Invoke(_attackDelay);
    }
    
}
