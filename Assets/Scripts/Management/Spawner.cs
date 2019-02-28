using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PooledObjectManager pool;

    public Vector3 PlayerStartPos;
    public Vector3 EnemyStartPos;

    private GameObject player;
    private GamestateManager gamestate;


    private void Start()
    {
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        gamestate = GetComponent<GamestateManager>();

        player = pool.SpawnObject("Player", PlayerStartPos, true);
        gamestate.Player = player;
        pool.SpawnObject("Enemy", EnemyStartPos, false);
        
    }


    


}
