using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private PooledObjectManager pool;
    private ScreenManager screen;


    public float bulletMaxSpeed;
    public int bulletDamage;
    public bool facingForward;

    private float topScreenPos;
    private float bottomScreenPos;
    // public string whoShotMe;


    // Use this for initialization
    void Start()
    {

        gameObject.tag = "bullet";

        rb = gameObject.GetComponent<Rigidbody>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();

        //  topScreenPos = screen.upExtend.y;
        // bottomScreenPos = screen.downExtend.y;


        topScreenPos = 100f;
        bottomScreenPos = -100f;


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * bulletMaxSpeed;
      


        if (transform.position.y > topScreenPos || transform.position.y < bottomScreenPos)
        {
           pool.DespwanObject(this.gameObject);

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        pool.DespwanObject(this.gameObject);
    }
}
    
