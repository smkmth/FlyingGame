using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShadows : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().receiveShadows = false;
    }


}
