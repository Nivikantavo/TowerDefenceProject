using UnityEngine;

public abstract class Arrow : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            SpecialEffect(enemy);
            Destroy(gameObject);
        }
    }

    public abstract void SpecialEffect(Enemy enemy);
}
