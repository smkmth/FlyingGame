using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShipBuilder
{
    public static GameObject CreateShip(Hull hull, InputComponent input, GameObject engine, GameObject gun)
    {
        Debug.Log("here");
        GameObject ship = new GameObject("Ship");


        //hull = ship.AddComponent<Hull>(hull);
        input = ship.AddComponent<InputComponent>();
        engine = new GameObject();
        engine.transform.parent = ship.transform;
        gun = new GameObject();
        gun.transform.parent = ship.transform;
        return ship; 
    }



	
}
