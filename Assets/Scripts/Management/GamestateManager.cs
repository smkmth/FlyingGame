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
    private ScreenManager screen;
    private PooledObjectManager pool;
    
    [Header("Object Pooler Settings")]
    //how many objects we want to allocate upfront
    [SerializeField]
    private int BulletsToPool;
    [SerializeField]
    private int EnemiesToPool;
    [SerializeField]
    private int PlayersToPool;

    [SerializeField]
    private string PlayerName;
    [SerializeField]
    private string EnemyName;
    [SerializeField]
    private string BulletName;

    public GameObject       BulletPrefab;
    public GameObject       PlayerPrefab;
    public List<GameObject> EnemyPrefabList;

    public GameObject gunPrefab;
    public GameObject enginePrefab;
    public GameObject hullPrefab;



    [Header("Enemy Spawner Settings")]
    [SerializeField]
    private int AmountOfEnemies;
    [SerializeField]
    private float LowXRange;
    [SerializeField]
    private float HighXRange;
    [SerializeField]
    private float LowYRange;
    [SerializeField]
    private float HighYRange;
    [SerializeField]
    public float WaveTimer;
    private float timer;

    [Header ("Start Positions")]
    public Vector3 PlayerStartPos;

    private Vector3 EnemyStartPos;

    public List<GameObject> EnemyList;

    public GameState CurrentGameState { get; set; }

    private void Awake()
    {

        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();

        CurrentGameState = GameState.SetUp;
        
    }


    public void StartGame()
    {
        InitialSpawn();
        CurrentGameState = GameState.Playing;
        timer = 0;

    }

    public void InitialSpawn()
    {
        pool.DespawnAllObjects();
        InitScene();

        Player = pool.SpawnObject(PlayerName, PlayerStartPos, true);
        ShipBuilder.CreateShip(Player, hullPrefab, enginePrefab, gunPrefab, InputComponentType.Player, 100);
    }

    public void InitScene()
    {
        //pool.Init(ShipBuilder.CreateShip(hull, input, enginePrefab, gunPrefab), PlayersToPool, PlayerName);
        pool.Init(PlayerPrefab, PlayersToPool, PlayerName);
        pool.Init(BulletPrefab, BulletsToPool, BulletName);
        InitEnemies();
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    public void InitEnemies()
    {
        foreach (GameObject enemy in EnemyPrefabList)
        {
            pool.Init(enemy, EnemiesToPool, EnemyName);
        }
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
                EnemySpawn(AmountOfEnemies, LowXRange, HighXRange, LowYRange, HighYRange);
                timer = 0;
            }
        }
    }

    public void EnemySpawn(int amountOfEnemies, float lowXRange, float highXRange, float lowYRange, float highYRange)
    {
        
        for (int i = 0; i < amountOfEnemies; i++)
        {
            EnemyStartPos.x = Random.Range(lowXRange, highXRange);
            EnemyStartPos.y = Random.Range(lowYRange, highYRange);
            GameObject enemy = pool.SpawnObject(EnemyName, EnemyStartPos, false);
            if (enemy)
            {
                enemy.layer = 11;

                EnemyList.Add(enemy);
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
        StartGame();
    }
 

    public void TeardownSpawn()
    {
        pool.TearDownObjects();

    }

   
}
