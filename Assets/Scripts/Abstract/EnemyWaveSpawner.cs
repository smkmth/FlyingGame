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
    [Range(0.1f, 1f)]
    private float HowFarY;




    public List<GameObject> EnemyList;
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
            EnemyStartPos.x = Random.Range(screen.rightExtend.x *LowXRange, screen.rightExtend.x * HighXRange);
            EnemyStartPos.y = screen.upExtend.y + 20.0f;
            GameObject enemy = pool.SpawnObject(EnemyName, EnemyStartPos, false);
            if (enemy)
            {
                enemy.layer = 11;
                EnemyList.Add(enemy);
            }
            LeftToRightAi enemycomp = enemy.GetComponent<LeftToRightAi>();
            enemycomp.Init(HowFarX, HowFarY, HighXRange, LowXRange, HighYRange, LowYRange);

        }
    }

    
   
 

}
