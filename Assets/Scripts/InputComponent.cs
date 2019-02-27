using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InputComponent : MonoBehaviour {

    public float GetForward;
    public float GetLeft;
    public bool GetFire;

    private void Start()
    {
        GetForward = 0;
        GetLeft = 0;
        GetFire = false;
    }


    // Update is called once per frame
    void Update () {
        
        //movement
        GetForward = Input.GetAxis("Vertical");
        GetLeft     = Input.GetAxis("Horizontal");
        //firing
        if (Input.GetButton("Fire1"))
        {
            GetFire = true;

        }
        else
        {
            GetFire = false;
        }
            
      

		
	}
}
