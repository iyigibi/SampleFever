using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;
public class Printer : Generator,IHasTable
{
    public Transform table;
    public Paper paper;
    
    void Start()
    {   
        myGenerator= new ItemGenerator(true,10,10);
        myItem=paper;
        task=StartCoroutine(Produce()); 
    }

    void OnMouseDown (){
        collectOne();
     }


     
    public Vector3 getTablePossition(){
        return table.position;
    }

    public void Update() {
        if(myGenerator.isGenerating){
            //Debug.Log(myGenerator.isOn());
            myGenerator.taskTime+=Time.deltaTime;
            transform.localScale =  new Vector3(1,1f+Mathf.Sin(myGenerator.getTaskPercent()*Mathf.PI),1);
        }
    }  
}