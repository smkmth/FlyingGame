﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputComponentType
{
    Player, 
    LeftToRightAi,
    BeizerEnemy

}
public enum GunParts
{
    Machinegun,
    Shotgun

}
public enum EngineParts
{
    Engine,
    SlowerEngine,
    

}
public static class ShipBuilder 
{
   

    public static GameObject CreateShip(GameObject ship, GameObject body, GameObject engine, GameObject gun, InputComponentType input)
    {
 
        GameObject.Instantiate(body, ship.transform);
        GameObject.Instantiate(gun, ship.transform);
        GameObject.Instantiate(engine, ship.transform);
        switch (input)
        {
            case InputComponentType.Player:
                {

                    ship.AddComponent<PlayerInput>();
                    break;

                }
            case InputComponentType.LeftToRightAi:
                {
                    ship.AddComponent<LeftToRightAi>();
                    break;

                }
            case InputComponentType.BeizerEnemy:
                {
                    ship.AddComponent<BezierEnemy>();
                    break;

                }
        }

        return ship; 
    }
    public static GameObject CreateShip(GameObject ship, GameObject body, GameObject engine, List<GameObject> guns, InputComponentType input)
    {

        GameObject.Instantiate(body, ship.transform);
        Hull hull = body.GetComponent<Hull>();
        hull.Init();
        for(int i = 0; i < hull.GunSlots.Count; i++)
        {
            GameObject gun = GameObject.Instantiate(guns[i], ship.transform);
            gun.transform.position = hull.GunSlots[i].transform.position;
        }
        GameObject.Instantiate(engine, ship.transform);
        switch (input)
        {
            case InputComponentType.Player:
                {

                    ship.AddComponent<PlayerInput>();
                    break;

                }
            case InputComponentType.LeftToRightAi:
                {
                    ship.AddComponent<LeftToRightAi>();
                    break;

                }
            case InputComponentType.BeizerEnemy:
                {
                    ship.AddComponent<BezierEnemy>();
                    break;

                }
        }

        return ship; 
    }


    public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }





}
