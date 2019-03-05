using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MachineGun
{


    public Vector3 ExtremeRight;
    public Vector3 ExtremeLeft;
    public int amountOfBulletsToSpread;

    public Vector3 AimPos;



    protected override void FireShot()
    {
        for (int i = 0; i < amountOfBulletsToSpread; i++)
        {
            currentClip -= 1;
            GameObject bulletObj = pool.SpawnObject("Bullet", gunPos.position, Quaternion.Euler(AimPos));


            Bullet bullet = bulletObj.GetComponent<Bullet>();

            if (isPlayer)
            {
                bullet.gameObject.layer = LayerMask.NameToLayer("PlayerBullet");

            }
            else
            {
                bullet.gameObject.layer = LayerMask.NameToLayer("EnemyBullet");


            }
        }



    }



}
