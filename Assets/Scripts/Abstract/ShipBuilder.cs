using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputComponentType
{
    Player, 
    LeftToRightAi

}
public enum GunParts
{
    Machinegun,
    Shotgun

}
public enum EngineParts
{
    Engine,
    SlowerEngine

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
