using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class ItemCreate:MonoBehaviour
{
    private GameObject newItem;
    public GameObject whatToCreate;

    public bool addSome(Generator _generator){
        //Implement pooling!!!!!!!!!!!!!!!!!!!
        Vector3 pos=_generator.transform.position;
        /////take from pool
        newItem=Instantiate(whatToCreate, pos, Quaternion.identity);
        Table myTable=_generator.myTable.GetComponent<Table>();
        
        Place myPlace=myTable.askForPlace(newItem);
        if(myPlace==null){
            ///send to pool
           // if()
            _generator.EndJob();
            Destroy(newItem);
            return false;
        }
        //newItem.transform.position=myTable._transform.parent.position;
        Transform holderTransform=myPlace.holder.transform;
        
        Vector3 toPos=myPlace.position+holderTransform.localPosition;
        newItem.transform.SetParent(holderTransform.parent,true);
//
        iTween.MoveTo(newItem.gameObject, iTween.Hash("position", toPos, "time", 0.5f, "islocal", true));
        iTween.RotateTo(newItem.gameObject, iTween.Hash(
                     "rotation", new Vector3(0,0,32f*Random.value-16f),
                     "time", 0.5f,
                      "islocal", true,
                     "easetype", "linear"
                 ));

                 return true;
    }

    
    
    
}
