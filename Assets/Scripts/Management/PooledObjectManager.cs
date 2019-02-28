using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PooledObjectManager : MonoBehaviour {


    public GameObject Player;
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
        Init(Bullet, BulletsToPool, ObjectPool, BulletName);
        Init(Player, PlayersToPool, ObjectPool, PlayerName);
        Init(Enemy, EnemiesToPool, ObjectPool, EnemyName);


	}



    private void Init(GameObject objectToInit, int numToInit, List<GameObject> listToInitTo, string nameToSave)
    {
        if (numToInit > (currentpoolcount - ObjectCap))
        {
            Assert.IsTrue(true, "Need more allocation");
        }
        
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
                Debug.Log("Overflow at " + currentpoolcount);
                return;
            }
        }
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
}
