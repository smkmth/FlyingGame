using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "EnemyWave", order = 1)]
public class EnemyWave : ScriptableObject
{
    public List<BezierCurve> bezierCurves;
 
}

