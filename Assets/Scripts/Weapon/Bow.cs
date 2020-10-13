using UnityEngine;

public class Bow : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        var bullet = Instantiate(Arrow, shootPoint.position, transform.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, gameObject.transform.rotation.z));
    }
}
