using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;
public class Printer : Generator,IHasTable
{
    public GameObject table;
    public GameObject paper;
    
    void Start()
    {   
        myGenerator= new ItemGenerator(true,10,10);
        myItemCreator=this.GetComponent<ItemCreate>();
        //myItem=paper.GetComponent<Paper>();
        myTable=table;
        //table.addComponent(ItemCreate(paper));
       // myTable.setItemSize(myItem.size);
        task=StartCoroutine(Produce()); 
    }

    void OnMouseDown (){
        collectOne();
     }


     
    public Vector3 getTablePossition(){
        return table.transform.position;
    }

    public void Update() {
        if(myGenerator.isGenerating){
            //Debug.Log(myGenerator.isOn());
            myGenerator.taskTime+=Time.deltaTime;
            transform.localScale =  new Vector3(1,1f+Mathf.Sin(myGenerator.getTaskPercent()*Mathf.PI),1);
        }
    }  
}