using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// a scriptable object for any list of parts, either for individual ships, or a
/// master list, or for ui lists
/// </summary>
[CreateAssetMenu(fileName = "MasterPartList", order = 1)]
public class ShipParts : ScriptableObject
{

    public List<Hull>   Hulls;
    public List<Gun>    Guns;
    public List<Engine> Engines;

}
