using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class WorldMapUI : MonoBehaviour
{
    //basics
    public Map WorldMap;
    public Image map;
    //prefabs
    public GameObject citydot;
    public GameObject maplabel;
    //colors
    public Color PlayerOccupiedColor;
    public Color UnOccupiedColor;
 
    public List<Button> buttons;

    public Place PlayerLocation;

    public Dictionary<string, GameObject> PlacestoGameObjects = new Dictionary<string, GameObject>();

    private GamestateManager manager;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GamestateManager>();
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        int i = 0;
        foreach(Place place in WorldMap.places)
        {
            GameObject dot = Instantiate(citydot, map.transform);
            dot.GetComponent<RectTransform>().SetParent(map.transform);
            dot.transform.position = place.maplocation;

            GameObject dotlabel = Instantiate(maplabel, dot.transform);
            dotlabel.GetComponent<RectTransform>().SetParent(dot.transform);



            TextMeshProUGUI dotlabeltext = dotlabel.GetComponent<TextMeshProUGUI>();
            dotlabeltext.SetText(place.FormattedName);

            Image dotimage = dot.GetComponent<Image>(); 
            if (place.PlayerIsHere)
            {
                dotimage.color = PlayerOccupiedColor;
                PlayerLocation = place;
            }
            else
            {
                dotimage.color = UnOccupiedColor;
            }

            
            buttons[i].transform.position = place.maplocation;
            buttons[i].GetComponent<RectTransform>().SetParent(dot.transform);
            buttons[i].name = place.name;

            PlacestoGameObjects.Add(place.name, dot);

            i++;

        }

    }

    public void RedrawPlaces()
    {
        foreach(Place place in WorldMap.places)
        {
            Image dotimage = PlacestoGameObjects[place.name].GetComponent<Image>();

            if (place.PlayerIsHere)
            {
                dotimage.color = PlayerOccupiedColor;
                PlayerLocation = place;

            }
            else
            {
                dotimage.color = UnOccupiedColor;
            }
        }
    }

    public void OnClicked(Button button)
    {
        foreach (Place place in WorldMap.places)
        {
            if (place.name == button.name)
            {
                manager.SetLevelToLoad(place.connections[0].Level);
                PlayerLocation.PlayerIsHere = false;
                PlayerLocation = place;
                PlayerLocation.PlayerIsHere = true;                
                uiManager.StartGame();
                
            }
        }
        RedrawPlaces();

    }

}
