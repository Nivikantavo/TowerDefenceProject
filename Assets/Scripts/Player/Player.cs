using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Arrow> _arrows;
    [SerializeField] private Transform _shotPoint;

    [SerializeField] private Weapon _currentWeapon;

    private Arrow _currentArrow;
    private int _currentArrowNumber;
    private Animator _animator;
    private float _timeAfterLastShoot;
    
    public int Money { get; private set; }

    public Arrow CurrentArrow => _currentArrow;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Arrow> CurrentArrowChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _currentArrowNumber = 2;
        SetBow(_currentWeapon);
        ChangeArrow(_arrows[_currentArrowNumber]);
        _timeAfterLastShoot = _currentWeapon.ShootDelay;
    }

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            if (_timeAfterLastShoot >= _currentWeapon.ShootDelay)
            {
                _currentWeapon.Shoot(_shotPoint);

                _timeAfterLastShoot = 0;
            }
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    //public void BuyWeapon(Bullet arrow)
    //{
    //    Money -= weapon.Price;
    //    MoneyChanged?.Invoke(Money);
    //    _arrows.Add(weapon);
    //}

    public void NextArrow()
    {
        if (_currentArrowNumber == _arrows.Count - 1)
            _currentArrowNumber = 0;
        else
            _currentArrowNumber++;

        ChangeArrow(_arrows[_currentArrowNumber]);
    }

    public void PreviousArrow()
    {
        if (_currentArrowNumber == 0)
            _currentArrowNumber = _arrows.Count - 1;
        else
            _currentArrowNumber--;

        ChangeArrow(_arrows[_currentArrowNumber]);
    }

    private void ChangeArrow(Arrow arrow)
    {
        _currentArrow = arrow;
        CurrentArrowChanged?.Invoke(CurrentArrow);
    }

    private void SetBow(Weapon Bow)
    {
        _currentWeapon = Bow;
    }
}
