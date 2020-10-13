using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Arrow
{
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Castle castle))
        {
            castle.TakeDamage(Damage);

            Destroy(gameObject);
        }
    }

    public override void SpecialEffect(Enemy enemy) {}
}
