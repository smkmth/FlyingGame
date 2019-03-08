using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShipBuilderUI : MonoBehaviour
{
    public GameObject ShipBuildingMenu;
    public Dropdown gundropdown;
    public Dropdown gun2dropdown;
    public Dropdown enginedropdown;
    public Dropdown hulldropdown;
    public GamestateManager manager;
    [SerializeField]
    public ShipParts parts;

    public List<GameObject> selectedGunList;

    public void Start()
    {
        ShipBuildingMenu.SetActive(false);

        gundropdown.ClearOptions();
        gundropdown.AddOptions(System.Enum.GetNames(typeof(GunParts)).ToList());

        gun2dropdown.ClearOptions();
        gun2dropdown.AddOptions(System.Enum.GetNames(typeof(GunParts)).ToList());

        enginedropdown.ClearOptions();
        enginedropdown.AddOptions(System.Enum.GetNames(typeof(EngineParts)).ToList());

        hulldropdown.ClearOptions();
        hulldropdown.AddOptions(System.Enum.GetNames(typeof(HullParts)).ToList());
    }

    public void TurnOnMenu()
    {
        ShipBuildingMenu.SetActive(true);
    }
    public void TurnOffMenu()
    {
        ShipBuildingMenu.SetActive(false);
        selectedGunList.Clear();
        CreateGunList(gun2dropdown);
        CreateGunList(gundropdown);
        SelectHull();
        SelectEngine();
        manager.playerGunList = selectedGunList;
        foreach (GameObject gun in selectedGunList)
        {
            Debug.Log(gun.name);
        }
    }

    public void CreateGunList(Dropdown dropdown)
    {
        int selectionIndex = dropdown.value;

        switch (selectionIndex)
        {
            case (int)GunParts.Machinegun:
                //case 1:
                foreach (Gun gun in parts.Guns)
                {
                    if (gun.name == "MachineGun")
                    {
                        selectedGunList.Add(gun.gameObject);
                    }

                }
                break;
            case (int)GunParts.Shotgun:
                foreach (Gun gun in parts.Guns)
                {
                    if (gun.name == "Shotgun")
                    {
                        selectedGunList.Add(gun.gameObject);
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
    public void SelectHull()
    {
        int selectionIndex = hulldropdown.value;

        switch (selectionIndex)
        {
            case (int)HullParts.StrongShip:
                //case 1:
                foreach (Hull hull in parts.Hulls)
                {
                    if (hull.name == "StrongShip")
                    {
                        manager.hullPrefab = hull.gameObject;
                    }

                }
                break;
            case (int)HullParts.WeakShip:
                foreach (Hull hull in parts.Hulls)
                {
                    if (hull.name == "WeakShip")
                    {
                        manager.hullPrefab = hull.gameObject;
                    }

                }
                break;
        }
    }
}
