using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hull : MonoBehaviour {

    public abstract UIManager uiManager { get; set; }

    public abstract Engine MainEngine { get; set; }
    public abstract List<Gun> GunList { get; set; }


    public abstract int Health { get; set; }

    public abstract int MaxHealth { get; set; }

    public abstract bool CanBeDamaged { get; set; }

    public abstract void BlowUp();

    public abstract void SetUp();

    public void TakeDamage(int damageToTake)
    {
        if (CanBeDamaged)
        {
            Health -= damageToTake;
            Debug.Log(this.name + " hit, now they have " + Health + " health");
            if (uiManager)
            {
                uiManager.UpdateHealthBar(Health);
            }
            if (Health <= 0)
            {
                BlowUp();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            TakeDamage(bullet.bulletDamage);
        }
    }


}
