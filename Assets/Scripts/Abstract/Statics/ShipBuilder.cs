using System.Collections;
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
public enum HullParts
{
    MonsterShip,
    StrongShip,
    WeakShip
    
}
/// <summary>
/// static methods for creating ships from the parts 
/// programatically at runtime- and the enums for naming
/// these parts in menus
/// </summary>
public static class ShipBuilder 
{
   
    
    //Creates and returns ship given a shipbase prefab, a ship hull prefab, an engine prefab, a gun prefab, and an enum for the input type.  
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

    //Creates and returns a ship given a shipbase prefab, a ship hull prefab, an engine prefab, a list of gun prefabs, and an enum for the input type.  
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


    //Creates and returns a ship from a ship base, a scriptable object shipparts, and an inputcomponenttype enum. 
    public static GameObject CreateShip(GameObject shipbase, ShipParts parts, InputComponentType input)
    {

        GameObject ship = GameObject.Instantiate(parts.Hulls[0].gameObject, shipbase.transform);
        Hull hull = ship.GetComponent<Hull>();
        hull.Init();
        for (int i = 0; i < hull.GunSlots.Count; i++)
        {
            GameObject gun = GameObject.Instantiate(parts.Guns[i].gameObject, shipbase.transform);
            gun.transform.position = hull.GunSlots[i].transform.position;
        }
        GameObject.Instantiate(parts.Engines[0], shipbase.transform);
        switch (input)
        {
            case InputComponentType.Player:
                {

                    shipbase.AddComponent<PlayerInput>();
                    break;

                }
            case InputComponentType.LeftToRightAi:
                {
                    shipbase.AddComponent<LeftToRightAi>();
                    break;

                }
            case InputComponentType.BeizerEnemy:
                {
                    shipbase.AddComponent<BezierEnemy>();
                    break;

                }
        }

        return shipbase;
    }

    //sets all the layers on a gameobject and its children to be a layer specifed in the argument
    public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }





}
