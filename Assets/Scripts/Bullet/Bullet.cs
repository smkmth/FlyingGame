using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private PooledObjectManager pool;


    public float bulletMaxSpeed;
    public int bulletDamage;
    public bool facingForward;


    // Use this for initialization
    void Start()
    {

        gameObject.tag = "bullet";

        rb = gameObject.GetComponent<Rigidbody>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();


    }

    // Update is called once per frame
    void Update()
    {

        if (facingForward)
        {
            rb.velocity = (Vector3.up * bulletMaxSpeed);
        }
        else
        {   

            rb.velocity = (-Vector3.up * bulletMaxSpeed);

        }



        if (transform.position.y > 100 || transform.position.y < -100)
        {
            pool.DespwanObject(this.gameObject);

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        pool.DespwanObject(this.gameObject);

    }
}
    
