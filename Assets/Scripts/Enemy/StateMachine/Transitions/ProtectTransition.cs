using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectTransition : Transition
{
    [SerializeField] private float _transitionsRange;
    [SerializeField] private Shield _shield;

    private Vector2 _transitionPoint;

    private void Start()
    {
        _transitionPoint = new Vector2(Target.gameObject.GetComponent<BoxCollider2D>().bounds.extents.x, transform.position.y);
    }

    private void Update()
    {
        if ((Vector2.Distance(transform.position, _transitionPoint) < _transitionsRange) && (_shield.Strenght > 0))
            NeedTransit = true;
        Debug.Log("Расстояние = " + (Vector2.Distance(transform.position, _transitionPoint) < _transitionsRange));
        Debug.Log(NeedTransit);
    }
}
