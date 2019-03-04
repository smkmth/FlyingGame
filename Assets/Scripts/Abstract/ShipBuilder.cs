using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputComponentType
{
    Player, 
    LeftToRightAi

}
public static class ShipBuilder
{
    public static GameObject CreateShip(GameObject ship, GameObject body, GameObject engine, GameObject gun, InputComponentType input, int maxHealth)
    {
        ship.layer = LayerMask.NameToLayer("Player");

        GameObject.Instantiate(body, ship.transform);
        GameObject.Instantiate(gun, ship.transform);
        GameObject.Instantiate(engine, ship.transform);
        body.GetComponent<Hull>().MaxHealth = maxHealth;
        body.GetComponent<Hull>().SetUp();

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



	
}
