using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class ItemCreate:MonoBehaviour
{
    private GameObject newItem;
    public GameObject whatToCreate;
    private Pooler pooler;

    private void Awake(){
            pooler=Pooler.Instance;
    }

    public bool addSome(Generator _generator){
        //Implement pooling!!!!!!!!!!!!!!!!!!!
        Vector3 pos=_generator.transform.position;
        /////take from pool
        //newItem=Instantiate(whatToCreate, pos, Quaternion.identity);
        newItem=pooler.SpawnFromPool(whatToCreate.name,pos,Quaternion.identity);
        Table myTable=_generator.myTable.GetComponent<Table>();
        
        Place myPlace=myTable.askForPlace(newItem);
        if(myPlace==null){
            ///send to pool
           // if()
            _generator.EndJob();
            pooler.SendToPool(newItem);
            //Destroy(newItem);
            return false;
        }
        //newItem.transform.position=myTable._transform.parent.position;
        float speed=0.5f;
        if(!myPlace.holder.GetComponent<Table>() && newItem.GetComponent<Money>()){
            speed=0.2f;
            //Destroy(newItem,speed);
            pooler.SendToPool(newItem,speed);
            Wallet.instance.TakeMoney();
            
        }
        Transform holderTransform=myPlace.holder.transform;
        
        Vector3 toPos=myPlace.position+holderTransform.localPosition;
        newItem.transform.SetParent(holderTransform.parent,true);
//
        iTween.MoveTo(newItem.gameObject, iTween.Hash("position", toPos, "time", speed, "islocal", true));
        iTween.RotateTo(newItem.gameObject, iTween.Hash(
                     "rotation", new Vector3(0,0,32f*Random.value-16f),
                     "time", speed,
                      "islocal", true,
                     "easetype", "linear"
                 ));
        

        return true;
    }

    
    
    
}
