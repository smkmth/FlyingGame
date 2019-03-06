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

    public override bool CanBeDamaged { get; set; }


    public override int Health { get; set; }

    public override UIManager uiManager { get; set; }

    public PooledObjectManager pool;
    public InputComponent input;
    private Rigidbody rb; 

    private float rollTimer;
    private bool rolling;

    public float RollTime;


    private void Start()
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        GunList = gunArray;
        MainEngine = mainEngine;
        CanBeDamaged = true;
        
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        input = gameObject.GetComponentInParent<InputComponent>();
        rb = gameObject.GetComponentInParent<Rigidbody>();



    }

    public override void BlowUp()
    {
        pool.DespwanObject(gameObject.transform.parent.gameObject);
    }

    //This is just setting up the UI
    public override void SetUp()
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        uiManager.SetHealthBar(MaxHealth);
        

    }

    private void Update()
    {


        if (input.GetRoll)
        {
            CanBeDamaged = false;
        }
        else
        {
            CanBeDamaged = true;

        }



    }



}
