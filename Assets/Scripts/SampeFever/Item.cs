using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Item : MonoBehaviour
{
    public Item newItem;
    public void addSome(){
        
        newItem=Instantiate(this, new Vector3(0, 0, 0), Quaternion.identity);
        iTween.MoveTo(newItem.gameObject, iTween.Hash("position", new Vector3(0,0,-1), "time", 0.5f, "islocal", true));
    }

    
    
    
}
