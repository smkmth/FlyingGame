using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Speedy : Engine {


    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float acceleration;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private InputComponent input;

    public override float MaxSpeed { get; set; }
   
    public override float Acceleration { get ; set ; }

    private Vector3 moveForward;
    private Vector3 moveLeft;



    // Use this for initialization
    void Start () {

        rb = gameObject.GetComponentInParent<Rigidbody>();
        input = gameObject.GetComponentInParent<InputComponent>();

        MaxSpeed = maxSpeed;
        Acceleration = acceleration;
		
        Vector3 moveLeft = new Vector3(0, 0, 0);
        Vector3 moveForward = new Vector3(0, 0, 0);
	}
	
    public override void MoveForward(float input)
    {
        moveForward.y = input;
        rb.AddForce(moveForward * Acceleration);

    }

    public override void MoveLeft(float input)
    {
        moveForward.x = input;
        rb.AddForce(moveLeft * Acceleration);

    }

    // Update is called once per frame
    void LateUpdate () {

        if (rb.velocity.magnitude < MaxSpeed)
        {
            MoveForward(input.GetForward);
            MoveLeft(input.GetLeft);
        }



    }
}
