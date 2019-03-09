using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
//this class handles the initing of enemies, chosing what stuff the enemies have, and spawning of waves of enemies at the right times
public class EnemyWaveSpawner : MonoBehaviour
{

    [Header("Enemy Pool Settings")]

    //how many enemies should we allocate for? tip: more then 40 is kind of overkill
    public int EnemiesToPool; 
  
    //where the enemies are reset on death (make this offscreen)
    [SerializeField]
    private Vector3 EnemyResetPos;

    //The prefab ship base, not really different to the player ship base, but i left this open for future dev
    public GameObject AIShipBase;

    [Header("Enemy Wave Settings")]

    //a list of the parts which the ai is given
    public ShipParts enemyShip;

    //how many AIs we should spawn per wave. be carefull atm, they overlap if to many spawn at once. 
    [SerializeField]
    private int AmountOfEnemiesToSpawnOnWave;

    //The level asset, stores a wave timer, randombezier value and List of waves. 
    public Level currentLevel;
    //the wave asset, stores a load of enemies and their corrosponding curves. 
    public EnemyWave currentWave; 

    //timer for the wave spawner, its public so the gamestate manager can reset it easier 
    [HideInInspector]
    public float timer;
    public float WaveTimer;

    //Checking this makes the enemies ignore the bezier list order, and just picks random beziers from the
    //list
    public bool RandomBezier;

    public int DeadEnemies; 

    //list of enemies for initing
    [HideInInspector]
    public List<GameObject> EnemyList;

    //because this class is now handling its own init, it needs the enemey name to be able to address the
    //enemy, but this is copied from the gamemanager. 
    private string EnemyName;

    //The current wave we are on. 
    private int waveCount;

    //just the classes we need ref to. 
    private PooledObjectManager pool;
    private ScreenManager screen;
    private GamestateManager manager;
    private ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        manager = GetComponent<GamestateManager>();
        EnemyName = manager.EnemyName;
        currentWave = currentLevel.Waves[0];
        timer = 0.0f;
        DeadEnemies = 0;
        waveCount = 0;



    }


    public void InitReset()
    {
        currentWave = currentLevel.Waves[0];
        timer = 0.0f;
        DeadEnemies = 0;
        waveCount = 0;


    }
    //Creates a whole load of enemies, and sets their layer to 'Goon'. it is called by GamestateManager
    //on startup, double itterates through waves in level, then enemies in waves. 
    public void InitEnemies()
    {
        
        foreach (EnemyWave wave in currentLevel.Waves)
        {
            EnemyList = pool.InitList(AIShipBase, wave.EnemyShips.Count, wave.name);
            int i = 0;
            foreach (GameObject aenemy in EnemyList)
            {

                Assert.IsTrue(aenemy, "Spawn Failed!");
                ShipBuilder.CreateShip(aenemy, wave.EnemyShips[i], InputComponentType.BeizerEnemy);
                ShipBuilder.SetLayerRecursively(aenemy, (LayerMask.NameToLayer("Goon")));
                if (!currentLevel.RandomBezier)
                {
                    BezierEnemy enemycomp = aenemy.GetComponent<BezierEnemy>();
                    enemycomp.BezierTimer = 0.0f;
                    enemycomp.SetBezier(wave.bezierCurves[i]);
                    enemycomp.SlowDownFactor = wave.SlowdownFactor;

                }
                //itterate the foreach loop 
                i++;
            }
        }
    }

    public void InitWaves()
    {

        EnemyList = pool.InitList(AIShipBase, currentWave.EnemyShips.Count, EnemyName);
        int i = 0;
        foreach (GameObject aenemy in EnemyList)
        {

            Assert.IsTrue(aenemy, "Spawn Failed!");
            ShipBuilder.CreateShip(aenemy, currentWave.EnemyShips[i], InputComponentType.BeizerEnemy);
            ShipBuilder.SetLayerRecursively(aenemy, (LayerMask.NameToLayer("Goon")));
            if (!RandomBezier)
            {
                BezierEnemy enemycomp = aenemy.GetComponent<BezierEnemy>();
                enemycomp.BezierTimer = 0.0f;
                enemycomp.SetBezier(currentWave.bezierCurves[i]);
                enemycomp.SlowDownFactor = .2f;

            }
            //itterate the foreach loop 
            i++;
        }
    }

    //this actually spawns the enemies when they are created. i set the enemies bezier curve here so it 
    //can be randomised everytime the enemey is created. it spawns the amountofenmiestospawnonwave, it is
    //called on this classes update method. 
    public void EnemySpawn()
    {
        for (int i = 0; i < AmountOfEnemiesToSpawnOnWave; i++)
        {
            GameObject enemy = pool.SpawnObject(currentWave.name, EnemyResetPos, false);
            BezierEnemy enemycomp = enemy.GetComponent<BezierEnemy>();
            if (RandomBezier)
            {
                if (enemy)
                {
                    enemycomp.SetBezier(currentWave.bezierCurves[Random.Range(0, currentWave.bezierCurves.Count)]);
                    enemycomp.SlowDownFactor = .2f;

                }
            }
            enemycomp.InitOnSpawn(); 
        }
    }
    //while we are in gamestate playing, this method counts up the time, untill it reaches wave timer,
    //then calls the enemyspawn method and resets the timer. 
    public void Update()
    {
        timer += Time.deltaTime;
        if (manager.CurrentGameState == GameState.Playing)
        {
          
            if (timer > WaveTimer)
            {
                EnemySpawn();
                timer = 0;

            }
        }

        if (DeadEnemies >= currentWave.EnemyShips.Count)
        {
            DeadEnemies = 0; 
            if (waveCount <= currentLevel.Waves.Count)
            {
                waveCount++;
                currentWave = currentLevel.Waves[waveCount];

            }
            else
            {
                manager.CurrentGameState = GameState.Win;
                Debug.Log("VICTORY!");
            }
        }



       
    }





}
