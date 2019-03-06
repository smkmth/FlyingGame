using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShipBuilderUI : MonoBehaviour
{
    public GameObject ShipBuildingMenu;
    public Dropdown gundropdown;
    public Dropdown enginedropdown;
    public GamestateManager manager;
    [SerializeField]
    public ShipParts parts;

    public void Start()
    {
        gundropdown.ClearOptions();
        gundropdown.AddOptions(System.Enum.GetNames(typeof(GunParts)).ToList());
        ShipBuildingMenu.SetActive(false);

        enginedropdown.ClearOptions();
        enginedropdown.AddOptions(System.Enum.GetNames(typeof(EngineParts)).ToList());
    }

    public void TurnOnMenu()
    {
        ShipBuildingMenu.SetActive(true);
    }
    public void TurnOffMenu()
    {
        ShipBuildingMenu.SetActive(false);
        SelectGun();
        SelectEngine();
    }

    public void SelectGun()
    {
        int selectionIndex = gundropdown.value;

        switch (selectionIndex)
        {
            case (int)GunParts.Machinegun:
                //case 1:
                foreach (Gun gun in parts.Guns)
                {
                    if (gun.name == "MachineGun")
                    {
                        manager.gunPrefab = gun.gameObject;
                    }

                }
                break;
            case (int)GunParts.Shotgun:
                foreach (Gun gun in parts.Guns)
                {
                    if (gun.name == "Shotgun")
                    {
                        manager.gunPrefab = gun.gameObject;
                    }

                }
                break;
        }
    }
    public void SelectEngine()
    {
        int selectionIndex = enginedropdown.value;

        switch (selectionIndex)
        {
            case (int)EngineParts.Engine:
                //case 1:
                foreach (Engine engine in parts.Engines)
                {
                    if (engine.name == "Engine")
                    {
                        manager.enginePrefab = engine.gameObject;
                    }

                }
                break;
            case (int)EngineParts.SlowerEngine:
                foreach (Engine engine in parts.Engines)
                {
                    if (engine.name == "SlowerEngine")
                    {
                        manager.enginePrefab = engine.gameObject;
                    }

                }
                break;
        }
    }
}
