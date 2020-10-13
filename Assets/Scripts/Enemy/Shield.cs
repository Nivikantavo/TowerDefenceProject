using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int _strength;

    public int Strenght => _strength;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Arrow>(out Arrow arrow))
        {
            _strength--;
        }

        if (_strength <= 0)
            this.gameObject.SetActive(false);
    }
}
