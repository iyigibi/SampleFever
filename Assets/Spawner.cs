using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject newItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Spawn(GameObject whatToCreate, Vector3 pos_,Quaternion rot_){
        Debug.Log("");
        newItem=Instantiate(whatToCreate,pos_,rot_);
    }

}
