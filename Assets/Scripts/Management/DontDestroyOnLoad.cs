using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DontDestroyOnLoad : MonoBehaviour {



    //makes this object persistant, error checks scene.
    //if somthing is broken, check we have "bullet" tag 
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (GameObject.Find("ObjectPooler") == null)
        { 
        
            Assert.IsTrue(false, "No PooledObjectManager called ObjectPooler in scene");
          
        }
        if (GameObject.Find("ScreenManager") == null)
        { 
        
            Assert.IsTrue(false, "No ScreenManager called ScreenManager in scene");
          
        }
      
       
    }
}
