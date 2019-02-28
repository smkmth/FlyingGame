using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PooledObjectManager pool;

    public Vector3 PlayerStartPos;
    public Vector3 EnemyStartPos;

    private GameObject player;
    private GameObject enemy;

    public List<GameObject> enemyList;
    private GamestateManager gamestate;

    public void InitialSpawn()
    {
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();

        pool.SetUpScene();

        player = pool.SpawnObject("Player", PlayerStartPos, true);

        enemy = pool.SpawnObject("Enemy", EnemyStartPos, false);

        player.GetComponent<Hull>().SetUp();
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void TeardownSpawn()
    {
        pool.TearDownObjects();

    }

    public void ResetObjects()
    {
        pool.DespawnAllObjects();
        InitialSpawn();
    }


    


}
