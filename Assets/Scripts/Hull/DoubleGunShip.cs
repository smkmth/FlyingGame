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

    public override UIManager uiManager { get; set; }

    private PooledObjectManager pool;

    private void Start()
    {
        Debug.Log("start");
        MaxHealth = maxHealth;
        GunList = gunArray;
        MainEngine = mainEngine;
        Health = MaxHealth;


        Debug.Log(name + " spawned ");

        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
    }

    public override void BlowUp()
    {

        pool.DespwanObject(gameObject);
    }

    public override void SetUp()
    {
        Debug.Log("setup");
        Health = MaxHealth;
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        uiManager.SetHealthBar(MaxHealth);

        if (!uiManager)
        {
            Debug.Log("Failed setup");
        }
    }

    
}
