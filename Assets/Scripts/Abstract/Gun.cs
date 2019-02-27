using UnityEngine;

public abstract class Gun  : MonoBehaviour
{

    public abstract int Ammo { get; set; }

    public abstract int ClipSize { get; set; }

    public abstract void FireGun(bool firing);


	
}
