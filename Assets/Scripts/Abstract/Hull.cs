using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputComponent))]
public abstract class Hull : MonoBehaviour {

    public abstract Engine MainEngine { get; set; }
    public abstract List<Gun> GunList { get; set; }

    public abstract int Health { get; set; }

    public abstract int MaxHealth { get; set; }

    public abstract void BlowUp();


    public void TakeDamage(int damageToTake)
    {
        Health -= damageToTake;
        if (Health <= 0)
        {
            BlowUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log( other.name + " hit " + name);

        if (other.tag == "bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            TakeDamage(bullet.bulletDamage);
        }
    }


}
