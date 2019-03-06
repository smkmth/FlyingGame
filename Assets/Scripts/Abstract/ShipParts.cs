using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "MasterPartList", menuName = "PartLists", order = 1)]
public class ShipParts : ScriptableObject
{

    public List<Hull>   Hulls;
    public List<Gun>    Guns;
    public List<Engine> Engines;

}
