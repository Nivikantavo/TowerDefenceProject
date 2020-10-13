using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        int pelletCount = 5;
        float shootAngel = gameObject.transform.rotation.z;
        for (float i = 0; i < pelletCount; i ++)
        {
            CreationPellet(shootAngel, shootPoint);
            shootAngel += 2f;
        }
    }

    public void CreationPellet(float angelOfRotation, Transform shootPoint)
    {
        var bullet = Instantiate(Arrow, shootPoint.position, Quaternion.identity);
        bullet.transform.Rotate(new Vector3(0, 0, angelOfRotation));
    }
}
