using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Generator : MonoBehaviour
{
    internal ItemGenerator myGenerator;
    internal Coroutine task;
    internal BaseItem myItem;
    internal GameObject myTable;
    internal ItemCreate myItemCreator;
    
  

     internal void collectOne(){
        myGenerator.collectOne();
        if(!myGenerator.isGenerating)
        task=StartCoroutine(Produce()); 
     }

    internal IEnumerator Produce(){
        while (true){
            
            if(myGenerator.isOn()){
                //start taskStart anim
                
                yield return new WaitForSeconds(myGenerator.startGenerating());
                myGenerator.stopGenerating();
                //start taskFinshed anim
                //genereteItem
                bool isFull=myItemCreator.addSome(this);
                if(isFull){
                    
                }
                //Debug.Log(isFull);
            }else{
                StopCoroutine(task);
                yield return null;
            }
            
        }
        }

    
}
