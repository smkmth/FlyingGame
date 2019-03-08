using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    [Header("Enemy Spawner Settings")]
    [SerializeField]
    private int AmountOfEnemies;
    [Range(-1f, 1f)]
    [SerializeField]
    private float LowXRange;
    [Range(-1f, 1f)]
    [SerializeField]
    private float HighXRange;
    [Range(-1f, 1f)]
    [SerializeField]
    private float LowYRange;
    [Range(-1f, 1f)]
    [SerializeField]
    private float HighYRange;
    [SerializeField]
    [Range(0.1f, 1f)]
    private float HowFarX;
    [SerializeField]
    [Range(-1f, 1f)]
    private float HowFarY;




    public List<GameObject> EnemyList;
    public EnemyWave wave;
    private float timer;
    private string EnemyName;


    private Vector3 EnemyStartPos;
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


    }


    public void EnemySpawn()
    {
        
        for (int i = 0; i < AmountOfEnemies; i++)
        {
            GameObject enemy = pool.SpawnObject(EnemyName, EnemyStartPos, false);

            if (enemy)
            {
                enemy.layer = 11;
                EnemyList.Add(enemy);
                BezierEnemy enemycomp = enemy.GetComponent<BezierEnemy>();
                enemycomp.BezierTimer = 0.0f;
                enemycomp.SetBezier(wave.bezierCurves[0]);
                enemycomp.SlowDownFactor = .2f;
            }
            
        }
    }

    
   
 

}
