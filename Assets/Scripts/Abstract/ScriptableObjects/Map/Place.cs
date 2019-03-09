using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Place", order = 1)]
public class Place : ScriptableObject
{
    public List<Path> connections;

    public Vector2 maplocation;

    public bool PlayerIsHere;

    public string FormattedName;
   
}
