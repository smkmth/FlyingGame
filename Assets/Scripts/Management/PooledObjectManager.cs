using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PooledObjectManager : MonoBehaviour {


    public GameObject Player;
    public List<GameObject> EnemyList;
    public GameObject Enemy;
    public GameObject Bullet;

    private List<GameObject> ObjectPool;

     //how many objects we want to allocate upfront

    [SerializeField]
    private int ObjectCap;

    [SerializeField]
    private int BulletsToPool;

    [SerializeField]
    private int EnemiesToPool;

    [SerializeField]
    private int PlayersToPool;

    [SerializeField]
    private bool PermissivePool;

    private int currentpoolcount;

    [SerializeField]
    private string PlayerName;

    [SerializeField]
    private string EnemyName;

    [SerializeField]
    private string BulletName;



    // Use this for initialization
    void Awake () {

        ObjectPool = new List<GameObject>();
        currentpoolcount = 0;

      
	}

    public void SetUpScene()
    {
        //always init player first, enemies next then bullets last 
        Init(Player, PlayersToPool, ObjectPool, PlayerName);
        Init(Bullet, BulletsToPool, ObjectPool, BulletName);
        EnemyList = InitList(Enemy, EnemiesToPool, ObjectPool, EnemyName);

    }

    private void Init(GameObject objectToInit, int numToInit, List<GameObject> listToInitTo, string nameToSave)
    {
       
        
        for (int i = 0; i < numToInit; i++)
        {
            if (currentpoolcount < ObjectCap || PermissivePool)
            {
                currentpoolcount++;
                GameObject thing = Instantiate(objectToInit);
                thing.SetActive(false);
                thing.name = nameToSave;
                listToInitTo.Add(thing);
                if (i == 0)
                {
                    thing.layer = 10;
                }
                else
                {
                    thing.layer = 11;
                }
            }
            else
            {
                Assert.IsTrue(false, "Overflow at " + currentpoolcount + " " + nameToSave + "s");
                return;
            }
        }
    }
    private List<GameObject> InitList(GameObject objectToInit, int numToInit, List<GameObject> listToInitTo, string nameToSave)
    {
        List<GameObject> gameObjectList = new List<GameObject>();
        for (int i = 0; i < numToInit; i++)
        {
            if (currentpoolcount < ObjectCap || PermissivePool)
            {
                currentpoolcount++;
                GameObject thing = Instantiate(objectToInit);
                thing.SetActive(false);
                thing.name = nameToSave;
                listToInitTo.Add(thing);
                gameObjectList.Add(thing);
                if (i == 0)
                {
                    thing.layer = 10;
                }
                else
                {
                    thing.layer = 11;
                }
              
            }
            else
            {
                Assert.IsTrue(false, "Overflow at " + currentpoolcount + " " + nameToSave + "s");
                return null;
            }

        }
        return gameObjectList; 
    }


    public GameObject SpawnObject(string nameToLookFor, Vector3 transformPos, bool facingForward)
    {
        //iterate over array
        foreach (GameObject anobject in ObjectPool)
        {
            //check if two game objects are the same
            if (anobject.name == nameToLookFor)
            {
                //check if the object has any deactivated versions
                if (!anobject.activeSelf)
                {
                    anobject.SetActive(true);
                    if (facingForward)
                    {
                        anobject.transform.SetPositionAndRotation(transformPos, Quaternion.identity);
                    }
                    else
                    {
                        anobject.transform.SetPositionAndRotation(transformPos, Quaternion.AngleAxis(180, Vector3.forward));

                    }
                    return anobject;
                }
            }
        }
        return null;
    }

    public void DespwanObject(GameObject objectToDespawn)
    {
        foreach (GameObject anobject in ObjectPool)
        {
            //check if two game objects are the same
            if (anobject.GetInstanceID() == objectToDespawn.GetInstanceID())
            {
                //check if the object has any deactivated versions
                if (anobject.activeSelf)
                {
                    anobject.SetActive(false);
                    anobject.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                }
            }
        }
    }
    //destroys all the objects in the scene
    public void TearDownObjects()
    {
        foreach(GameObject anobject in ObjectPool)
        {
            Destroy(anobject);

        }
        ObjectPool.Clear();
    }

    public void DespawnAllObjects()
    {
        foreach(GameObject anobject in ObjectPool)
        {
            DespwanObject(anobject);
        }

    }
}
