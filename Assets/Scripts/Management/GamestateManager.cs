using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    SetUp,
    Playing,
    GameOver,
    Pause,
    Win
}
public class GamestateManager : MonoBehaviour {

    private GameObject Player;

    public UIManager uIManager;
    public ScoreManager scoreManager;
    private ScreenManager screen;
    private PooledObjectManager pool;


    [Header("Object Pooler Settings")]
    //how many objects we want to allocate upfront
    [SerializeField]
    private int BulletsToPool;
    [SerializeField]
    private int PlayersToPool;

    //This name is how we index the spawnobject method. we always 
    //spawn objects using these variables, not just a string so accidentally 
    //changing the name here dosnt break stuff. 
    [HideInInspector]
    public string PlayerName;
    [HideInInspector]
    public string EnemyName;
    [HideInInspector]
    public string BulletName;

    public GameObject BulletPrefab;

    [Header("Ship Parts")]

    //set this to be a ship base prefab. 
    public GameObject ShipBase;
    
    //these guys are set by the ship builder ui
    [HideInInspector]
    public GameObject gunPrefab;
    [HideInInspector]
    public GameObject enginePrefab;
    [HideInInspector]
    public GameObject hullPrefab;
    [HideInInspector]
    public List<GameObject> playerGunList;


    [Header ("Start Position")]
    public Vector3 PlayerStartPos;

    public GameState CurrentGameState { get; set; }

    private EnemyWaveSpawner wavespawner;

    private void Awake()
    {

        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        wavespawner = GetComponent<EnemyWaveSpawner>();

        CurrentGameState = GameState.SetUp;
        //set these here so they dont get changed
        PlayerName = "Player";
        EnemyName = "Enemy";
        BulletName = "Bullet";

    }


    public void InitGame()
    {
        foreach (GameObject gun in playerGunList)
        {
            Debug.Log(gun.name);
        }
        InitScene(hullPrefab, enginePrefab, playerGunList);
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
        wavespawner.InitEnemies();
    }

    public void StartGame()
    {
        Player = pool.SpawnObject(PlayerName, PlayerStartPos, true);
        CurrentGameState = GameState.Playing;
        Player.GetComponentInChildren<Hull>().SetUpPlayer();
        wavespawner.timer = 0.0f;
        Pause(false);
        wavespawner.InitReset();
        scoreManager.Restart();


    }

    public GameObject GetPlayer()
    {
        return Player;
    }


    // Update is called once per frame
    void Update () {

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
        }
        else if (CurrentGameState == GameState.Win)
        {
            Win();
        }

        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Paused");
            if (CurrentGameState == GameState.Pause)
            {
                Pause(false);
            }
            else if (CurrentGameState == GameState.Playing)
            {
                Pause(true);

            }
        }
    }

    void GameOver()
    {
        uIManager.GameOver();
        pool.DespawnAllObjects();

    }
    void Win()
    {
        uIManager.Win();
        pool.DespawnAllObjects();
    }

    public void Pause(bool paused)
    {
        if (paused)
        {
            CurrentGameState = GameState.Pause;
            Time.timeScale = 0;
            uIManager.TogglePauseMenu(true);
        }
        else
        {
            CurrentGameState = GameState.Playing;
            Time.timeScale = 1;
            uIManager.TogglePauseMenu(false);

        }


    
    }

    public void QuitToMainMenu()
    {
        TeardownSpawn();
        CurrentGameState = GameState.MainMenu;

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
