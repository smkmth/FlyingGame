using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGunShip : Hull
{
    [SerializeField]
    private Engine mainEngine;
    public override Engine MainEngine { get; set; }

    [SerializeField]
    private List<Gun> gunArray;
    public override List<Gun> GunList { get; set ; }

    [SerializeField]
    private int maxHealth;
    public override int MaxHealth { get; set; }

    public override int Health { get; set; }

    private PooledObjectManager pool;


    private void Start()
    {
        
        MaxHealth = maxHealth;
        GunList = gunArray;
        MainEngine = mainEngine;
        Health = MaxHealth;

        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();


    }



    public override void BlowUp()
    {
        Debug.Log("BlewUp");
        pool.DespwanObject(gameObject);
    }
}
