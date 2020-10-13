using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectState : State
{
    [SerializeField] private GameObject _shield;

    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _animator.Play("Shield");
        _shield.SetActive(true);
    }

    private void OnEnable()
    {
        _shield.SetActive(true);
        Debug.Log("on");
    }

    private void OnDisable()
    {
        _shield.SetActive(false);
    }
}
