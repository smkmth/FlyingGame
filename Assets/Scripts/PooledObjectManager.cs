using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PooledObjectManager : MonoBehaviour {


    public GameObject Guy;
    public GameObject Bullet;

    private List<GameObject> ObjectPool;

     //how many objects we want to allocate upfront

    [SerializeField]
    private int ObjectCap;

    [SerializeField]
    private int BulletsToPool;

    [SerializeField]
    private int GuysToPool;

    [SerializeField]
    private bool PermissivePool;

    private int currentpoolcount;

    [SerializeField]
    private string GuyName;

    [SerializeField]
    private string BulletName;

    public Vector3 testpos;

    // Use this for initialization
    void Awake () {

        ObjectPool = new List<GameObject>();

        currentpoolcount = 0;
        Init(Bullet, BulletsToPool, ObjectPool, BulletName);
        Init(Guy, GuysToPool, ObjectPool, GuyName);
        SpawnObject("Guy", testpos);

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

    public GameObject SpawnObject(string nameToLookFor, Vector3 transformPos)
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
                    anobject.transform.SetPositionAndRotation(transformPos,Quaternion.identity);
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
