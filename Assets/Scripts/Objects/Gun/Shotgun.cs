using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MachineGun
{

    [SerializeField]
    public Vector3 ExtremeRight;

    [SerializeField]
    private Vector3 ExtremeLeft;

    [SerializeField]
    private int amountOfBulletsToSpread;

    public Vector3 AimPos;


    /// <summary>
    /// Overriden fireshot, itterates over amountofbulletstospread, lerping
    /// extremeleft and right to produce a spread shot.
    /// </summary>
    protected override void FireShot()
    {
        for (int i = 0; i <= amountOfBulletsToSpread; i++)
        {
            currentClip -= 1;
            float lerpval = (float)i / 10;
            AimPos = Vector3.Lerp( ExtremeRight, ExtremeLeft, lerpval);
            AimPos -= transform.parent.localRotation.eulerAngles;
            GameObject bulletObj = pool.SpawnObject("Bullet", gunPos.position, Quaternion.Euler(AimPos));

            if (bulletObj)
            {

                Bullet bullet = bulletObj.GetComponent<Bullet>();
                if (isPlayer)
                {
                    bullet.gameObject.layer = LayerMask.NameToLayer("PlayerBullet");

                }
                else
                {
                    bullet.gameObject.layer = LayerMask.NameToLayer("EnemyBullet");
                }
                bullet.bulletMaxSpeed = BulletSpeed;
                bullet.bulletDamage = BulletDamage;

            }
        }



    }



}
