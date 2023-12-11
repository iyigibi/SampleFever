using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Generator : MonoBehaviour
{
    internal ItemGenerator myGenerator;
    internal Coroutine task;
    internal bool taskIsRunning;
    internal BaseItem myItem;
    public GameObject myTable;
    internal ItemCreate myItemCreator;
    
  

     internal void collectOne(bool once=false){
        
        if(!taskIsRunning){
            myGenerator.collectOne();
            task=StartCoroutine(Produce(once)); 
            taskIsRunning=true;
        }
        
     }

    internal void EndJob(){
        myGenerator.jobComplate=true;
         collectOne();
     }
    internal void StartJob(bool once=false){
        myGenerator.jobComplate=false;
        collectOne(once);
     }

    internal IEnumerator Produce(bool once=false){
        while (true){
            
            if(myGenerator.isOn()){
                //start taskStart anim
                bool isNotFull=myItemCreator.addSome(this);
                //Debug.Log(isNotFull);
                if(!isNotFull){
                    if(taskIsRunning){
                        StopCoroutine(task);
                    taskIsRunning=false;
                    }

                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(myGenerator.startGenerating());
                myGenerator.stopGenerating();
                if(once){
                    if(taskIsRunning){
                        StopCoroutine(task);
                    taskIsRunning=false;
                    }
                    
                    yield return null;
                }
                //start taskFinshed anim
                //genereteItem
                
                //Debug.Log(isFull);
            }else{
                if(taskIsRunning){
                    StopCoroutine(task);
                taskIsRunning=false;
                }
                
                yield return null;
            }
            
        }
        }

    
}
