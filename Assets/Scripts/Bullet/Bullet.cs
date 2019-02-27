using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private PooledObjectManager pool;


    [SerializeField]
    private float bulletMaxSpeed;



    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();


    }

    // Update is called once per frame
    void Update()
    {


        rb.velocity = (Vector3.up * bulletMaxSpeed);



        if (transform.position.y > 1000)
        {
            pool.DespwanObject(this.gameObject);

        }



    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collide");
        pool.DespwanObject(this.gameObject);

    }
}
    
