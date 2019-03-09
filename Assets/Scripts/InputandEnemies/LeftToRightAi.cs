using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeftToRightAi : InputComponent {

    public AIState state;

    public override float GetForward { get; set; }
    public override float GetLeft { get; set; }

    public override bool GetFire { get; set; }
    public override bool GetRoll { get; set; }

    private float HowFarX;
    private float HowFarY;

    private float RandomXHigh;
    private float RandomXLow;
    private float RandomYHigh;
    private float RandomYLow;

    private bool goingRight;
    private bool goingDown;

    private ScreenManager screen;
    

    // Use this for setting up default relationships
    void Start ()
    {
        state = AIState.MovingToInitPos;
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();        
    }
    //Use this for initialization
    public void Init(float howfarx, float howfary, float randomxhigh, float randomxlow, float randomyhigh, float randomylow )
    {
        HowFarX = howfarx;
        HowFarY = howfary;
        RandomXHigh = randomxhigh;
        RandomXLow = randomxlow;
        RandomYHigh = randomyhigh;
        RandomYLow = randomylow;
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
