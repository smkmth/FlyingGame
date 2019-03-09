using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The body of the ship, holds the ships mesh, deals with
/// taking damage. 
/// </summary>
public abstract class Hull : MonoBehaviour {

    //the ui manager for this ship
    public abstract UIManager UIManager { get; set; }

    //list of all the parts associated with this ship. not used atm
   /* public abstract Engine MainEngine { get; set; }
    public abstract List<Gun> GunList { get; set; }
    */

    //how much health this ship has now
    public abstract int Health { get; set; }

    //how much health does this ship have when they are full health
    public abstract int MaxHealth { get; set; }

    //disables taking damage. Off when rolling
    public abstract bool CanBeDamaged { get; set; }

    //How many guns this ship can have - and where they sit on the ship
    public abstract List<Transform> GunSlots { get; set; }
    
    //called when the ship is destroyed 
    public abstract void BlowUp();

    //Sets up everything for the ship itself, like health= maxhealth
    public abstract void Init();

    //Sets up stuff specifically for the player, like the UI and stuff. 
    public abstract void SetUpPlayer();

    public abstract void TakeDamage(int damageToTake);


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();

            TakeDamage(bullet.bulletDamage);
        }
    }


}
