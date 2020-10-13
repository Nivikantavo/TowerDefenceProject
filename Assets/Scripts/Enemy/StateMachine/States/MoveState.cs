using UnityEngine;

public class MoveState : State
{
    private float _speed;
    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _speed = GetComponent<Enemy>().Speed;
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animator.Play("Move");
    }
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.World);
    }
    private void OnEnable()
    {
        _enemy.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        _enemy.SpeedChanged -= OnSpeedChanged;
    }

    private void OnSpeedChanged(float newSpeed)
    {
        _speed = newSpeed;
    }
}
