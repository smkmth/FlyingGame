using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DontDestroyOnLoad : MonoBehaviour {

    //tags we need:
    //bullet

    //makes this object persistant, error checks scene.
    //if somthing is broken assert! seems like a lot, only 
    //ever called once on start up, can be commented out on release.
    //important for dev as these problems come up and are very
    //easily mistaken for bugs :<
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        //Check names, ensures all of these things exist in the scene on start up. 
        //You have to ensure for the most case they have the relevent scripts attached
        if (GameObject.Find("ObjectPooler") == null)
        { 
            Assert.IsTrue(false, "No PooledObjectManager called ObjectPooler in scene"); 
        }
        if (GameObject.Find("ScreenManager") == null)
        {
            Assert.IsTrue(false, "No ScreenManager called ScreenManager in scene");
        }
        if (GameObject.Find("ScoreManager") == null)
        {
            Assert.IsTrue(false, "No ScoreManager called ScoreManager in scene");
        }
        if (GameObject.Find("GameManager") == null)
        {
            Assert.IsTrue(false, "No GamestateManager called GameManger in scene");
        }
        if (GameObject.Find("GameManager").GetComponent<EnemyWaveSpawner>() == null)
        {
            Assert.IsTrue(false, "No EnemyWaveSpawner in object called GameManger in scene");
        }
        if (GameObject.Find("UI") == null)
        {
            Assert.IsTrue(false, "No UI in object called UI in scene");
        }

        //check layers exists using a bitwise operation. you need to have these layers in the game cos 
        //thats how the collision works, and if they are wrong, things will break in weird ways. 
        if (LayerMask.NameToLayer("PlayerBullet") == (LayerMask.NameToLayer("PlayerBullet") | (1 << 9)))
        {
            Assert.IsTrue(false, "No Layer PlayerBullet at index 9");
        }
        if (LayerMask.NameToLayer("Player") == (LayerMask.NameToLayer("Player") | (1 << 10)))
        {
            Assert.IsTrue(false, "No Layer Player at index 10");
        }
        if (LayerMask.NameToLayer("Goon") == (LayerMask.NameToLayer("Goon") | (1 << 11)))
        {
            Assert.IsTrue(false, "No Layer Goon at index 11");
        }
        if (LayerMask.NameToLayer("EnemyBullet") == (LayerMask.NameToLayer("EnemyBullet") | (1 << 12)))
        {
            Assert.IsTrue(false, "No Layer EnemyBullet at index 12");
        }


    }

}
