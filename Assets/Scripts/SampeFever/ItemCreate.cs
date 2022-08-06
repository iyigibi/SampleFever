using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class ItemCreate:MonoBehaviour
{
    private GameObject newItem;
    public GameObject whatToCreate;
    public void addSome(Generator _generator){
        //Implement pooling!!!!!!!!!!!!!!!!!!!
        Vector3 pos=new Vector3(0,0,0);
        newItem=Instantiate(whatToCreate, pos, Quaternion.identity);
        Vector3 toPos=_generator.myTable.GetComponent<Table>().givePlace().position;
        Debug.Log(toPos);
        iTween.MoveTo(newItem.gameObject, iTween.Hash("position", toPos, "time", 0.5f, "islocal", true));
    }

    
    
    
}