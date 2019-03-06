using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPos
{
    TooRight,
    TooLeft,
    TooHigh,
    TooLow,
    Fine
}
public class Speedy : Engine
{


    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float rollForce;

    [SerializeField]
    private float acceleration;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private InputComponent input;

    public PlayerPos playerPos;

    public override float MaxSpeed { get; set; }

    public override float Acceleration { get; set; }

    public Vector3 moveForward;
    public Vector3 moveLeft;
    private ScreenManager screen;

    public override float RollForce { get; set; }

    private Vector3 rollVector;
    public Vector3 rollTorque;

    public bool rolling = false;

    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponentInParent<Rigidbody>();
        input = gameObject.GetComponentInParent<InputComponent>();

        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();

        MaxSpeed = maxSpeed;
        Acceleration = acceleration;
        RollForce = rollForce; 

        moveLeft = new Vector3(0, 0, 0);
        moveForward = new Vector3(0, 0, 0);

        playerPos = PlayerPos.Fine;
    }

    public override void MoveForward(float input)
    {
       
        if (playerPos == PlayerPos.TooHigh)
        {
            input = -1;
        } 
        if (playerPos == PlayerPos.TooLow)
        {
            input = 1;
        }
        moveForward.y = input;
        rb.AddForce(moveForward * Acceleration);
    }

    public override void MoveLeft(float input)
    {  
        if (playerPos == PlayerPos.TooRight)
        {
            input = -1;
        }
        if (playerPos == PlayerPos.TooLeft)
        {
            input = 1;
        }
        moveLeft.x = input;
        rb.AddForce(moveLeft * Acceleration);
    }



    IEnumerator Roll()
    {
        rolling = true;
        float currentroll = 0.0f;
        float rollperframe = 360f / 60.0f;
       
        while (transform.eulerAngles.y + 180 < 360)
        {
            currentroll += rollperframe;
           
            rb.angularVelocity = new Vector3(0, rollperframe, 0);
           
            rb.AddForce(new Vector3(input.GetLeft * RollForce, 0, 0));

            yield return new WaitForEndOfFrame();
        }
        rb.angularVelocity = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, 0);
        rolling = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (input.GetRoll)
        {
            if (input.GetLeft != 0)
            {
                if (!rolling)
                {
                    StartCoroutine(Roll());
                }
            }
        }

        if (rb.velocity.magnitude < MaxSpeed && !input.GetRoll)
        {
            MoveLeft(input.GetLeft);
            MoveForward(input.GetForward);
        }
       

        if ((screen.upExtend.y - transform.position.y) < 0)
        {
            playerPos = PlayerPos.TooHigh;
        }
        else if ((screen.downExtend.y - transform.position.y) > 0)
        {
            playerPos = playerPos = PlayerPos.TooLow;
        }
        else if ((transform.position.x - screen.rightExtend.x) > 0)
        {
            playerPos = PlayerPos.TooRight;
        }
        else if((screen.leftExtend.x - transform.position.x ) > 0)
        {
            playerPos = PlayerPos.TooLeft;
        }
        else
        {
            playerPos = PlayerPos.Fine;
        }

    }
}


