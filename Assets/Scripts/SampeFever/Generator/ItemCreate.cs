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
        Vector3 pos=new Vector3(0,0,0);
        /////take from pool
        newItem=Instantiate(whatToCreate, pos, Quaternion.identity);
        Place myPlace=_generator.myTable.GetComponent<Table>().givePlace(newItem);
        if(myPlace==null){
            ///send to pool
            Destroy(newItem);
            return false;
        }
        
        Transform holderTransform=myPlace.holder.transform;
        Vector3 toPos=myPlace.position+holderTransform.localPosition;
        newItem.transform.SetParent(holderTransform.parent,false);

        iTween.MoveTo(newItem.gameObject, iTween.Hash("position", toPos, "time", 0.5f, "islocal", true));
        iTween.RotateBy(newItem.gameObject, iTween.Hash(
                     "z", 0.08f*Random.value-0.04f, 
                     "time", 0.5f,
                     "easetype", "linear"
                 ));
                 return true;
    }

    
    
    
}
