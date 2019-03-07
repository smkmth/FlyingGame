using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierEnemy : InputComponent
{
    public override float GetForward { get; set; }
    public override float GetLeft { get; set; }
    public override bool GetFire { get; set; }
    public override bool GetRoll { get; set; }

    //public EnemyMovement movement;

    public Vector3 StartPoint = new Vector3(-0.0f, 0.0f, 0.0f);
    public Vector3 endPoint = new Vector3(-2.0f, 2.0f, 0.0f);
    public Vector3 startTangent = Vector3.zero;
    public Vector3 endTangent = Vector3.zero;


    public void Start()
    {
    }

    public void Update()
    {
    }
}
