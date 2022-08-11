using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;
public class Printer : Generator,IHasTable
{
    public GameObject table;
    public GameObject paper;
    public bool activeOnStart;
    
    void Start()
    {   
        myTable=table;
        myGenerator= new ItemGenerator(activeOnStart,9999,40);
        myItemCreator=this.GetComponent<ItemCreate>();
        myTable.GetComponent<Table>().generator=(Generator)this;
        
        //myItem=paper.GetComponent<Paper>();
        
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
            transform.localScale =  new Vector3(1f+Mathf.Sin(myGenerator.getTaskPercent()*Mathf.PI),transform.localScale.y,transform.localScale.z);
        }
    }  
}