using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PooledObjectManager : MonoBehaviour {


    private List<GameObject> ObjectPool;

    public bool NoSpawning;

    [SerializeField]
    private bool PermissivePool;

    private int currentpoolcount;

    [SerializeField]
    private int ObjectCap;




    // Use this for initialization
    void Awake () {

        ObjectPool = new List<GameObject>();
        currentpoolcount = 0;
        NoSpawning = false;
      
	}

 

    public void Init(GameObject objectToInit, int numToInit, string nameToSave)
    {

        for (int i = 0; i < numToInit; i++)
        {
            if (currentpoolcount < ObjectCap || PermissivePool)
            {
                currentpoolcount++;
                GameObject thing = Instantiate(objectToInit);
                thing.SetActive(false);
                thing.name = nameToSave;
                ObjectPool.Add(thing);
          
            }
            else
            {
                Assert.IsTrue(false, "Overflow at " + currentpoolcount + " " + nameToSave + "s");
                return;
            }
        }
    }

    public GameObject InitGameObject(GameObject objectToInit, int numToInit, string nameToSave)
    {
        GameObject thing = null;
        for (int i = 0; i < numToInit; i++)
        {
            if (currentpoolcount < ObjectCap || PermissivePool)
            {
                currentpoolcount++;
                thing = Instantiate(objectToInit);
                thing.SetActive(false);
                thing.name = nameToSave;
                ObjectPool.Add(thing);
 

            }
            else
            {
                Assert.IsTrue(false, "Overflow at " + currentpoolcount + " " + nameToSave + "s");
                return null;
            }
        }
        return thing;
    }

    public List<GameObject> InitList(GameObject objectToInit, int numToInit, string nameToSave)
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
                ObjectPool.Add(thing);
                gameObjectList.Add(thing);
              
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
        if (!NoSpawning)
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
                        //Debug.Log(anobject.name + " spawned " + transformPos);
                        return anobject;
                    }
                }
            }
        }
        return null;
    }

    public GameObject SpawnObject(string nameToLookFor, Vector3 transformPos, Quaternion facingDirection)
    {
        if (!NoSpawning)
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

                        anobject.transform.SetPositionAndRotation(transformPos, facingDirection);

                        //Debug.Log(anobject.name + " spawned " + transformPos + facingDirection);


                        return anobject;
                    }
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
                    anobject.transform.SetPositionAndRotation(new Vector3(0, 60,0), Quaternion.identity);
                    //Debug.Log(anobject.name + " despawned");

                }
            }
        }
    }

    public void DespawnTheseObjects(string objectsToDespawn)
    {
        foreach (GameObject anobject in ObjectPool)
        {
            if (anobject.name == objectsToDespawn)
            {
                anobject.SetActive(false);
                anobject.transform.SetPositionAndRotation(new Vector3(0, 60, 0), Quaternion.identity);
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

    public IEnumerator StopSpawningForTime(float timeToStop)
    {

        NoSpawning = true;
        yield return new WaitForSeconds(timeToStop);
        NoSpawning = false;


    }
}
