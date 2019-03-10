using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private PooledObjectManager pool;
    private ScreenManager screen;

    [HideInInspector]
    public float bulletMaxSpeed;
    [HideInInspector]
    public int bulletDamage;


    private float topScreenPos;
    private float bottomScreenPos;
    private float rightScreenPos;
    private float leftScreenPos;

    // Use this for initialization
    void Start()
    {

        gameObject.tag = "bullet";

        rb = gameObject.GetComponent<Rigidbody>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();


        topScreenPos = (screen.upExtend.y - 5);
        bottomScreenPos = screen.downExtend.y;
        rightScreenPos = screen.rightExtend.x;
        leftScreenPos = screen.leftExtend.x;


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * bulletMaxSpeed;

        if (transform.position.y > topScreenPos || transform.position.y < bottomScreenPos)
        {
           pool.DespwanObject(this.gameObject);
        }
        if (transform.position.x > rightScreenPos || transform.position.x < leftScreenPos)
        {
            pool.DespwanObject(this.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        pool.DespwanObject(this.gameObject);
    }
}
    
