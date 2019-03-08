using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierEnemy : InputComponent
{
    public override float GetForward { get; set; }
    public override float GetLeft { get; set; }
    public override bool GetFire { get; set; }
    public override bool GetRoll { get; set; }

    [Range(0.01f, 1f)]
    public float SlowDownFactor;
    bool moving; 
    //public EnemyMovement movement;

    public BezierCurve bezierCurve;

    [HideInInspector]
    public Vector3 StartPoint = new Vector3(-0.0f, 0.0f, 0.0f);
    [HideInInspector]
    public Vector3 EndPoint = new Vector3(-2.0f, 2.0f, 0.0f);
    [HideInInspector]
    public Vector3 StartTangent = Vector3.zero;
    [HideInInspector]
    public Vector3 EndTangent = Vector3.zero;

    [HideInInspector]
    public float BezierTimer = 0.0f;
    Vector3 curvepos;
    private PooledObjectManager pool;

    public void Awake()
    {
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();

    }

    public void SetBezier(BezierCurve curve)
    {
        bezierCurve = curve; 
        StartPoint = curve.startPoint;
        EndPoint = curve.endPoint;
        StartTangent = curve.startTangent;
        EndTangent = curve.endTangent;
        moving = true;
        

    }



    public void Update()
    {
        if (moving)
        {
            BezierTimer += Time.deltaTime * SlowDownFactor;
        }
        if (BezierTimer > 2)
        {
            moving = false;
            pool.DespwanObject(this.gameObject);
            BezierTimer = 0;
            
        }

        // curvepos = ((1 - BezierTimer )* (1 - BezierTimer) * StartPoint) + (1 * BezierTimer * (1 - BezierTimer) * StartTangent) + (1 * BezierTimer * (1 - BezierTimer) * EndTangent) +(BezierTimer * BezierTimer) * EndPoint;

        float u = 1 - BezierTimer;
        float tt = BezierTimer * BezierTimer;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * BezierTimer;

        Vector3 p = uuu * StartPoint;
        p += 3 * uu * BezierTimer * StartTangent;
        p += 3 * u * tt * EndTangent;
        p += ttt * EndPoint;

        curvepos = p;
  
        curvepos.z = 0.0f;


        transform.position = curvepos;

    }

}
