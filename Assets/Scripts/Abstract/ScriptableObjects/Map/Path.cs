using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Path",  order = 1)]
public class Path : ScriptableObject
{
    public Place End;
    public Place Start;
    public Level Level;
}
