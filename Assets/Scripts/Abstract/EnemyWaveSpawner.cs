using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    //the wave asset, atm it just stores a load of bezier curves 
    public EnemyWave wave;

    //timer for the wave spawner, its public so the gamestate manager can reset it easier 
    [HideInInspector]
    public float timer;
    public float WaveTimer;
    
    
    //list of enemies for initing
    [HideInInspector]
    public List<GameObject> EnemyList;

    //because this class is now handling its own init, it needs the enemey name to be able to address the
    //enemy, but this is copied from the gamemanager. 
    private string EnemyName;

    //just the classes we need ref to. 
    private PooledObjectManager pool;
    private ScreenManager screen;
    private GamestateManager manager;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find("ObjectPooler").GetComponent<PooledObjectManager>();
        screen = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();

        manager = GetComponent<GamestateManager>();
        EnemyName = manager.EnemyName;
        timer = 0.0f; 


    }

    //Creates a whole load of enemies, and sets their layer to 'Goon'. it is called by GamestateManager
    //on startup
    public void InitEnemies()
    {
        EnemyList = pool.InitList(AIShipBase, EnemiesToPool, EnemyName);
        foreach (GameObject aenemey in EnemyList)
        {
            ShipBuilder.CreateShip(aenemey, enemyShip, InputComponentType.BeizerEnemy);
            ShipBuilder.SetLayerRecursively(aenemey, (LayerMask.NameToLayer("Goon")));

        }
    }

    //this actually spawns the enemies when they are created. i set the enemies bezier curve here so it 
    //can be randomised everytime the enemey is created. it spawns the amountofenmiestospawnonwave, it is
    //called on this classes update method. 
    public void EnemySpawn()
    {
        for (int i = 0; i < AmountOfEnemiesToSpawnOnWave; i++)
        {
            GameObject enemy = pool.SpawnObject(EnemyName, EnemyResetPos, false);

            if (enemy)
            {
                BezierEnemy enemycomp = enemy.GetComponent<BezierEnemy>();
                enemycomp.BezierTimer = 0.0f;
                enemycomp.SetBezier(wave.bezierCurves[Random.Range(0,wave.bezierCurves.Count)]);
                enemycomp.SlowDownFactor = .2f;
               
            }
            
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
       
    }





}
