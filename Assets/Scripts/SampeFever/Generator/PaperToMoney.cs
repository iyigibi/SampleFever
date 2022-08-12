using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;
public class PaperToMoney : Generator,IHasTable
{
    public GameObject table;
    public bool activeOnStart;

    
    void Start()
    {   
        myTable=table;
        myGenerator= new ItemGenerator(activeOnStart,9999,40);
        myItemCreator=this.GetComponent<ItemCreate>();
        myTable.GetComponent<Table>().generator=(Generator)this;

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