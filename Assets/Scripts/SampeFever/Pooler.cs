using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
[System.Serializable]
public class Pool{
    public GameObject prefab;
    public int size;
}

public static Pooler Instance;
private void Awake() {
    Instance=this;
}

public List<Pool> pools;

public Dictionary<string,List<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        foreach (Pool pool in pools){
            List<GameObject> objectPool = new List<GameObject>();
            for(int i=0;i<pool.size;i++){
                GameObject obj=Instantiate(pool.prefab);
                obj.name=pool.prefab.name;
                obj.SetActive(false);

                objectPool.Add(obj);
            }

            poolDictionary.Add(pool.prefab.name, objectPool);
        }
    }


    public GameObject SpawnFromPool (string tag,Vector3 position,Quaternion rotation){
        //Debug.Log(tag);
        if(!poolDictionary.ContainsKey(tag)){
            //Debug.Log("no item");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag][0];
        poolDictionary[tag].RemoveAt(0);

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position=position;
        objectToSpawn.transform.rotation=rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj!=null){
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Add(objectToSpawn);
        return objectToSpawn;
    }

    public void SendToPool(GameObject gameObject_,float delay=0f){
        StartCoroutine(SendToPoolFunc(gameObject_,delay));
    }

    private IEnumerator SendToPoolFunc(GameObject gameObject_,float delay){
        yield return new WaitForSeconds(delay);
        List<GameObject> myList=poolDictionary[gameObject_.name];
        int objIndex = myList.FindIndex(d => d == gameObject_);
        myList.RemoveAt(objIndex);
        myList.Insert(0,gameObject_);
        gameObject_.SetActive(false);
    }

}