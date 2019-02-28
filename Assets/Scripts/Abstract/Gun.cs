using UnityEngine;
public enum GunState
{
    Idle,
    Firing,
    EmptyClip,
    Reloading,
    NoAmmo
    

}
public abstract class Gun  : MonoBehaviour
{

    public abstract int Ammo { get; set; }

    public abstract int ClipSize { get; set; }

    public abstract void FireGun(bool firing);

    public abstract GunState CurrentGunState { get; set; }

    public abstract float FireRate { get; set; }

    public abstract float ReloadTime { get; set; }

    public abstract float BulletSpeed { get; set; }

    public abstract int BulletDamage { get; set; }




	
}
