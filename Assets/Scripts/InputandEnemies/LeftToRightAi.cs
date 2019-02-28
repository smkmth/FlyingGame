using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRightAi : InputComponent {


    public override float GetForward { get; set; }

    public override float GetLeft { get; set; }

    public override bool GetFire { get; set; }

    private ScreenManager screen;


    [Range(0.1f,1f)]
    public float HowFar;

    private bool goingRight;

    

    // Use this for initialization
    void Start () {
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
    
        if(transform.position.x > (screen.rightExtend.x * HowFar))
        {
            goingRight = false;
  
        }
        else if (transform.position.x < (screen.leftExtend.x * HowFar))
        {
            goingRight = true;
  

        }

        if (goingRight)
        {
            GetLeft = 1.0f;
        }else
        {
            GetLeft = -1.0f;
        }

        GetFire = true;
		
	}
}
