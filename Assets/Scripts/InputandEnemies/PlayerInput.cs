﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputComponent {

    public override float GetForward { get; set; }
    public override float GetLeft { get; set; }

    public override bool GetFire { get; set; }
    public override bool GetRoll { get; set; }
    public override bool GetFineMov { get; set; }
    public override bool UseSpcPower { get; set; }
    private float rollTimer;
    private float RollTime;

    private void Start()
    {
        GetForward = 0;
        GetLeft = 0;
        GetFire = false;
        RollTime = 1.0f;
        rollTimer = 0.0f;
        GetFineMov = false;
    }


    // Update is called once per frame
    void Update() {

        //movement
        GetForward = Input.GetAxis("Vertical");
        GetLeft = Input.GetAxis("Horizontal");
        UseSpcPower = Input.GetButtonDown("SpcPower");

        if (UseSpcPower)
        {
            Debug.Log("used");
        }

        if (Input.GetButton("FineMove"))
        {
            GetFineMov = true;
        }
        else
        {
            GetFineMov = true;
        }
        //firing
        if (Input.GetButton("Fire1"))
        {
            GetFire = true;

        }
        else
        {
            GetFire = false;
        }

        //rolling
        if (Input.GetButtonDown("Roll"))
        {
            if (!GetRoll)
            {
                GetRoll = true;
                rollTimer = 0.0f;
            }
        }

        if (GetRoll == true)
        {
            rollTimer += Time.deltaTime;
            if (rollTimer > RollTime)
            {
                GetRoll = false;
            }
        }

    }

    
}
