using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Transform _skySpawnPoint;
    [SerializeField] private Castle _target;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private Transform _currentSpawnPoint;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastWave;
    private int _spawned;
    private int _totalEnemyCount;
    private int _totalEnemySpawned = 0;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int,int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);

        for (int i = 0; i < _waves.Count; i++)
        {
            _totalEnemyCount += _waves[i].Count;
        }
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        if (_spawned == 0)
            StartCoroutine(EnemyInstantiator());

        if(_currentWave.Count == _spawned)
        {
            StopCoroutine(EnemyInstantiator());
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();

                _timeAfterLastWave += Time.deltaTime;
                if (_timeAfterLastWave >= _currentWave.DelayAfterWave)
                    NextWave();
            }
            else
                _currentWave = null;
        }
        EnemyCountChanged?.Invoke(_totalEnemySpawned, _totalEnemyCount);
    }

    private void InstantiateEnemy()
    {
        if (_currentWave.Template.GetComponent<Enemy>().IsFlying)
            _currentSpawnPoint = _skySpawnPoint;
        else
            _currentSpawnPoint = _spawnPoint[Random.Range(0, _spawnPoint.Length)];

        Enemy enemy = Instantiate(_currentWave.Template, _currentSpawnPoint.position, _currentSpawnPoint.rotation, _currentSpawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _player.AddMoney(enemy.Reward);
        enemy.Dying -= OnEnemyDying;
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
        _timeAfterLastWave = 0;
    }

    private IEnumerator EnemyInstantiator()
    {
        WaitForSeconds Delay = new WaitForSeconds(_currentWave.DelayBetweenEnemy);

        for (int i = 0; i < _currentWave.Count; i++)
        {
            InstantiateEnemy();
            _spawned++;
            _totalEnemySpawned++;

            yield return Delay;
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float DelayBetweenEnemy;
    public float DelayAfterWave;
    public int Count;
}