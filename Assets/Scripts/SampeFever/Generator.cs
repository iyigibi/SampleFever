using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Generator : MonoBehaviour
{
    internal ItemGenerator myGenerator;
    internal Coroutine task;

    internal Item myItem;
    
  

     internal void collectOne(){
        myGenerator.collectOne();
        if(!myGenerator.isGenerating)
        task=StartCoroutine(Produce()); 
     }

    internal IEnumerator Produce(){
        while (true){
            
            if(myGenerator.isOn()){
                //start taskStart anim
                myItem.addSome();
                yield return new WaitForSeconds(myGenerator.startGenerating());
                myGenerator.stopGenerating();
                //start taskFinshed anim
                //genereteItem
            }else{
                StopCoroutine(task);
                yield return null;
            }
            
        }
        }

    
}
