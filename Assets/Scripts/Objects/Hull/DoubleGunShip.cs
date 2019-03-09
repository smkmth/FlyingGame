using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGunShip : Hull
{
    [SerializeField]
    private List<Transform> gunslots;
    public override List<Transform> GunSlots { get; set; }

    [SerializeField]
    private int maxHealth;
    public override int MaxHealth { get; set; }

    public override int Health { get; set; }

    public override bool CanBeDamaged { get; set; }
    
    public override UIManager UIManager { get; set; }

    private PooledObjectManager pool;
    private InputComponent input;
    private ScoreManager score;
    public Renderer[] materials;
    public Color shipColor; 


    private void Start()
    {
        //this weird pattern so i can set up properties in inspector
        MaxHealth = maxHealth;
        Health = MaxHealth;
 
        CanBeDamaged = true;
        GunSlots = gunslots;
        
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        input = gameObject.GetComponentInParent<InputComponent>();

        materials = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in materials)
        {

            r.material.SetColor("_MatColor", shipColor);
        }

    }

    public override void Init()
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        CanBeDamaged = true;
        GunSlots = gunslots;
        foreach (Renderer r in materials)
        {

            r.material.SetColor("_MatColor", shipColor);
        }

    }
    public override void BlowUp()
    {
        if (transform.parent.name != "Player")
        {
            score.AddPoint(10);
            Health = MaxHealth;

        }

        pool.DespwanObject(gameObject.transform.parent.gameObject);
    }

    //This is just setting up the UI
    public override void SetUpPlayer()
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        UIManager = GameObject.Find("UI").GetComponent<UIManager>();
        UIManager.SetHealthBar(MaxHealth);

    }
    public IEnumerator HitEffect()
    {
        foreach (Renderer r in materials)
        {
            Color myColor = new Color(1f, 1f, 1f, 1f);
            r.material.SetColor("_MatColor", myColor);
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer r in materials)
        {

            r.material.SetColor("_MatColor", shipColor);
        }
        yield return null;

    }

    public override void TakeDamage(int damageToTake)
    {
        if (CanBeDamaged)
        {
            StartCoroutine(HitEffect());
            Health -= damageToTake;
          
            Debug.Log(this.name + " hit, now they have " + Health + " health");
            if (UIManager)
            {
                UIManager.UpdateHealthBar(Health);
            }
            if (Health <= 0)
            {
                StopAllCoroutines();
                foreach (Renderer r in materials)
                {

                    r.material.SetColor("_MatColor", shipColor);
                }
                BlowUp();
            }
        }
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
