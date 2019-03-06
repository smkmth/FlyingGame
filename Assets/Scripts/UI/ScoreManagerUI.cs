using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetText("0");

    }


    public void SetScoreUI(int val)
    {
        text.SetText(val.ToString()); 
    }
}
