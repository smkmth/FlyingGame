using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", order = 1)]
public class Level : ScriptableObject
{

    public List<EnemyWave> Waves;

    public float WaveTimer;

    public bool RandomBezier;

    
}
