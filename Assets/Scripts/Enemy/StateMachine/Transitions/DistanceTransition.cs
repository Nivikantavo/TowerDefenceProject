using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionsRange;
    [SerializeField] private float _rangedSpread;

    private BoxCollider2D _boxCollider2D;
    private Vector2 _transitionPoint;
    private void Start()
    {
        _transitionsRange += Random.Range(-_rangedSpread, _rangedSpread);
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _transitionPoint = new Vector2(Target.gameObject.GetComponent<BoxCollider2D>().bounds.extents.x, transform.position.y);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _transitionPoint) < _transitionsRange)
            NeedTransit = true;
    }
}
