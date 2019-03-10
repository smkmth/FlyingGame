using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBomb : SpcPower
{ 

    public override float   PowerRechargeRate { get; set; }
    public override float   MaxPowerMeter  {get; set; }

    public override void UsePower()
    {
        pool.DespawnTheseObjects("Bullet");
    }

    private PooledObjectManager pool;
    private InputComponent input;
    private GamestateManager manager;

    private void Start()
    {
        //get components 
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        input = gameObject.GetComponentInParent<InputComponent>();
        manager = GameObject.Find("GameManager").GetComponent<GamestateManager>();
    }

    public void Update()
    {

        if (input.UseSpcPower)
        {
            UsePower();
            StartCoroutine(pool.StopSpawningForTime(3.0f));

        }

    }

}
