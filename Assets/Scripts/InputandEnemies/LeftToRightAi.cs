using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeftToRightAi : InputComponent {

    public AIState state;

    public override float GetForward { get; set; }

    public override float GetLeft { get; set; }

    public override bool GetFire { get; set; }
    public override bool GetRoll { get; set; }



    private ScreenManager screen;


 
    private float HowFarX;
    private float HowFarY;

    private float RandomXHigh;
    private float RandomXLow;
    private float RandomYHigh;
    private float RandomYLow;



    private bool goingRight;
    private bool goingDown;

    

    // Use this for initialization
    void Start ()
    {
        state = AIState.MovingToInitPos;
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();        

    }

    public void Init(float howfarx, float howfary, float randomxhigh, float randomxlow, float randomyhigh, float randomylow )
    {
        //Debug.Log("Init");
        HowFarX = howfarx;
        HowFarY = howfary;
        RandomXHigh = randomxhigh;
        RandomXLow = randomxlow;
        RandomYHigh = randomyhigh;
        RandomYLow = randomylow;
        /*
        HowFarX += Random.Range(RandomXLow, RandomXHigh);
        if (HowFarX > 1)
        {
            HowFarX = 1;
        }
        if (HowFarX < .3f)
        {
            HowFarX = 0.3f;
        }
        HowFarY += Random.Range(RandomYLow, RandomYHigh);
        if (HowFarY > 1)
        {
            HowFarY = 1;
        }
        if (HowFarY < .3f)
        {
            HowFarY = .3f;
        }
       */
        
        //Debug.Log(" how far x = " + HowFarX + "how far y = " + HowFarY);

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.y < (screen.downExtend.y * HowFarY))
        {
            goingDown = false;
            state = AIState.InPos;

        } else
        {
            goingDown = true;
        }

        if (goingDown)
        {
            GetForward = -1.0f;
        }
        else
        {
            GetForward = Mathf.Lerp(GetForward, 0.0f, 0.4f);
        }

        if (state == AIState.InPos)
        {

            if (transform.position.x > (screen.rightExtend.x * HowFarX))
            {
                goingRight = false;
            }
            else if (transform.position.x < (screen.leftExtend.x * HowFarX))
            {
                goingRight = true;
            }

            if (goingRight)
            {
                GetLeft = Mathf.Lerp(GetLeft, 1f, 0.4f); 
            }
            else
            {
                GetLeft = Mathf.Lerp(GetLeft, -1f, 0.4f);
            }
            GetFire = true;
        }		
	}
}
