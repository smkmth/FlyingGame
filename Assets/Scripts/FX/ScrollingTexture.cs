using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

    public float ScrollSpeed;
    public float Offset;
    public float Rotate;
    public Renderer rend;


	// Use this for initialization
	void Start () {


        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {

        Offset += (Time.deltaTime * ScrollSpeed) / 10.0f;
        Vector2 movement = new Vector2(0, -Offset);
        rend.material.SetTextureOffset("_MainTex", movement);
		
	}
}
