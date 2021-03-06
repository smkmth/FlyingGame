﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun {


    //where the bullets come from (attached to gameobject)
    [SerializeField]
    protected Transform gunPos;

    //total ammo
    [SerializeField]
    private int fullAmmo;
    [SerializeField]
    private int currentAmmo;
    public override int Ammo { get; set; }

    //current clip 
    [SerializeField]
    private int fullClip;
    [SerializeField]
    public int currentClip;
    public override int ClipSize { get ; set; }

    //how many bullets every second
    [SerializeField]
    private float fireRate;
    public override float FireRate { get ; set; }

    //how long it takes to reload
    [SerializeField]
    private float reloadTime;
    public override float ReloadTime { get ; set; }

    //how long it takes to reload
    [SerializeField]
    private float bulletSpeed;
    public override float BulletSpeed { get; set; }    
    
    //how long it takes to reload
    [SerializeField]
    private int bulletDamage;
    public override int BulletDamage { get; set; }

    [HideInInspector]
    public bool facingForward;
    [HideInInspector]
    public bool isPlayer;

    private string bulletName;

    protected GamestateManager manager;
    protected PooledObjectManager pool;
    protected InputComponent input;


    //the timer we check reload and firerate with
    private float timer;

    //What our gun is doing
    public override GunState CurrentGunState { get; set; }

    // Use this for initialization
    protected void Start()
    {
        //get components 
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        input = gameObject.GetComponentInParent<InputComponent>();
        manager = GameObject.Find("GameManager").GetComponent<GamestateManager>();
        //set editor settings
        FireRate = fireRate;
        Ammo = fullAmmo;
        ClipSize = fullClip;
        ReloadTime = reloadTime;
        BulletSpeed = bulletSpeed;
        BulletDamage = bulletDamage;
        //initilaze values
        timer = 0.0f;
        CurrentGunState = GunState.Idle;
        
        //check facing direction
        if (transform.parent.name != manager.PlayerName)
        {
            facingForward = false;
            isPlayer = false;
        }
        else
        {
            facingForward = true;
            isPlayer = true;
        }
        bulletName = manager.BulletName;
    }

    public override void FireGun(bool firing)
    {
         if (firing == true )
         {
            if (currentClip >= 0)
            {
                CurrentGunState = GunState.Firing;
            }
            else if (currentClip <= 0)
            {
                CurrentGunState = GunState.Reloading;
            }
        }
        else if (firing == false)
        {
            CurrentGunState = GunState.Idle;
        }
    }

    protected virtual void FireShot()
    {
        currentClip -= 1;
        GameObject bulletObj = pool.SpawnObject(bulletName, gunPos.position, facingForward);
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

    void Reload()
    {
        CurrentGunState = GunState.Idle;
        currentClip = ClipSize;
    }


	
	// Update is called once per frame
	void Update () {

        FireGun(input.GetFire);
        timer += Time.deltaTime;

        switch (CurrentGunState) {
            case GunState.Firing:
                {
                    if (timer > FireRate)
                    {
                        timer = 0;
                        FireShot();
                    }
                    break;
                }
            case GunState.Reloading:
                {
                    if (timer > ReloadTime)
                    {
                        timer = 0;
                        Reload();
                    }
                    break;
                }
            case GunState.NoAmmo:
                {
                    break;
                }
            case GunState.Idle:
                {
                    break;
                }
        }  
    }
}
