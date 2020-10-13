using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculingFlying : MonoBehaviour
{
    
    [SerializeField] private float _circuleRadius;
    [SerializeField] private int _speed;

    private float _angelRotation;
    private Vector2 _centerOfMovment;
    private void Start()
    {
        _centerOfMovment = transform.position;
    }

    private void Update()
    {
        CircularMotion();
    }
    private void CircularMotion()
    {
        _angelRotation += Time.deltaTime;

        transform.position = new Vector2(Mathf.Cos(_angelRotation * _speed) * _circuleRadius, Mathf.Sin(_angelRotation * _speed) * _circuleRadius) + _centerOfMovment;
    }
}
