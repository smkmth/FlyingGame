using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "EnemyWave", order = 1)]
public class EnemyWave : ScriptableObject
{
    //the enemy ships to build for this wave
    public List<ShipParts> EnemyShips;
    //The bezier curves to apply to each ship 
    public List<BezierCurve> bezierCurves;
 
}

