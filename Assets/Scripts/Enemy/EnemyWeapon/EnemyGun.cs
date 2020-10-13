using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Arrow _enemeArrow;
    public void Shoot(Transform shootPoint)
    {
        Instantiate(_enemeArrow, shootPoint.position, Quaternion.identity);
    }
}
