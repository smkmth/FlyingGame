using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

    //the left most point
    public Vector3 leftExtend;
    //the right most point
    public Vector3 rightExtend;
    //the bottom most point
    public Vector3 downExtend;
    //the top most point
    public Vector3 upExtend;

    public Vector3 screenMiddle;

    /*
    private void OnDrawGizmos()
    {
        DrawExtendGizmos();
    }

    void DrawExtendGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawLine(leftExtend, rightExtend);
        Gizmos.DrawLine(downExtend, upExtend);
    }
    */
}
