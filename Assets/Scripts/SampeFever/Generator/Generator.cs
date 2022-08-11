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

    internal void EndJob(){
        myGenerator.jobComplate=true;
         collectOne();
     }
    internal void StartJob(){
        myGenerator.jobComplate=false;
        collectOne();
     }

    internal IEnumerator Produce(){
        while (true){
            
            if(myGenerator.isOn()){
                //start taskStart anim
                bool isNotFull=myItemCreator.addSome(this);
                //Debug.Log(isNotFull);
                if(!isNotFull){
                    StopCoroutine(task);
                    yield return null;
                }
                yield return new WaitForSeconds(myGenerator.startGenerating());
                myGenerator.stopGenerating();
                //start taskFinshed anim
                //genereteItem
                
                //Debug.Log(isFull);
            }else{
                StopCoroutine(task);
                yield return null;
            }
            
        }
        }

    
}
