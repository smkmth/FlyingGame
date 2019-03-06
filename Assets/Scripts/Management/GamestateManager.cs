using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    SetUp,
    Playing,
    GameOver
}
public class GamestateManager : MonoBehaviour {

    private GameObject Player;

    public UIManager uIManager;
    public ScoreManager scoreManager;
    private ScreenManager screen;
    private PooledObjectManager pool;

    [SerializeField]
    public ShipParts parts;

    [Header("Object Pooler Settings")]
    //how many objects we want to allocate upfront
    [SerializeField]
    private int BulletsToPool;
    [SerializeField]
    private int EnemiesToPool;
    [SerializeField]
    private int PlayersToPool;

    [SerializeField]
    public string PlayerName;
    [SerializeField]
    public string EnemyName;
    [SerializeField]
    public string BulletName;

    public GameObject       BulletPrefab;

    [Header("Ship Parts")]

    public GameObject ShipBase;
    [HideInInspector]
    public GameObject gunPrefab;
    [HideInInspector]
    public GameObject enginePrefab;
    [HideInInspector]
    public GameObject hullPrefab;
    [HideInInspector]
    public GameObject enemyHullPrefab;
    [HideInInspector]
    public GameObject enemyEnginePrefab;
    [HideInInspector]
    public List<GameObject> playerGunList;


    private float timer;

    public float WaveTimer;

    public EnemyWaveSpawner wavespawner;

    public List<GameObject> EnemeyGuns;

    [Header ("Start Positions")]
    public Vector3 PlayerStartPos;


    public List<GameObject> EnemyList;

    public GameState CurrentGameState { get; set; }

    private void Awake()
    {

        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        wavespawner = GetComponent<EnemyWaveSpawner>();

        CurrentGameState = GameState.SetUp;
        
    }


    public void InitGame()
    {
        foreach (GameObject gun in playerGunList)
        {
            Debug.Log(gun.name);
        }
        InitScene(parts.Hulls[0].gameObject, enginePrefab, playerGunList);
        StartGame();

    }

    private void InitScene(GameObject playerhull, GameObject playerengine, List<GameObject> playerguns)
    {
        pool.TearDownObjects();
        //setup player
        Player = pool.InitGameObject(ShipBase, PlayersToPool, PlayerName);
        ShipBuilder.CreateShip(Player, playerhull, playerengine, playerguns, InputComponentType.Player);
        ShipBuilder.SetLayerRecursively(Player, LayerMask.NameToLayer("Player"));

        //set up bullets
        pool.Init(BulletPrefab, BulletsToPool, BulletName);
        //set up enemies
        InitEnemies();
    }

    public void StartGame()
    {
        Player = pool.SpawnObject(PlayerName, PlayerStartPos, true);
        CurrentGameState = GameState.Playing;
        Player.GetComponentInChildren<Hull>().SetUp();
        timer = 0;
    }


    public void InitEnemies()
    {
        EnemyList = pool.InitList(ShipBase, EnemiesToPool, EnemyName);
        foreach (GameObject aenemey in EnemyList)
        {
            ShipBuilder.CreateShip(aenemey, parts.Hulls[0].gameObject, parts.Engines[1].gameObject, EnemeyGuns, InputComponentType.LeftToRightAi);
            ShipBuilder.SetLayerRecursively(aenemey, (LayerMask.NameToLayer("Goon")));
        }
    }

    public GameObject GetPlayer()
    {
        return Player;
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (CurrentGameState == GameState.Playing)
        {
            if (Player)
            {
                if (Player.activeSelf != true)
                {
                    CurrentGameState = GameState.GameOver;
                    GameOver();
                }
                else
                {
                    CurrentGameState = GameState.Playing;
                }
            }
            if (timer > WaveTimer)
            {
                wavespawner.EnemySpawn();
                timer = 0;
            }
        }

    }



    void GameOver()
    {
        uIManager.GameOver();

    }

    public void Restart()
    {
        pool.DespawnAllObjects();
        scoreManager.Restart();
        StartGame();
    }
 

    public void TeardownSpawn()
    {
        pool.TearDownObjects();

    }


}
