using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineGun : Gun {

    [SerializeField]
    private PooledObjectManager pool;

    [SerializeField]
    private InputComponent input;

    [SerializeField]
    private Transform gunPos; 

    public override int Ammo { get; set; }

    public override int ClipSize { get ; set; }

    public override void FireGun(bool firing)
    {
        if (firing)
        {
            GameObject bullet = pool.SpawnObject("Bullet", gunPos.position);
            
        }

    }

    // Use this for initialization
    void Start () {

        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        input = gameObject.GetComponent<InputComponent>();
		
	}
	
	// Update is called once per frame
	void Update () {


        FireGun(input.GetFire);

		
	}
}
