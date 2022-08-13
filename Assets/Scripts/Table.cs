using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Table : MonoBehaviour
{


    public List<GameObject> collectors = new List<GameObject>();
    public Stack stack;
    internal Generator generator;
    internal Coroutine tableToWorkerCoroutine;
    internal bool tableToWorkerCoroutineIsRunning;
            
    [SerializeField]
    internal bool drivenByADesk;
    public Desk myDesk;



    void Awake()
    {
            stack=new Stack(gameObject,3,2,5);

    }
    internal void setItemSize(Vector3 _size){
        //itemSize=_size;
    }

    internal void AddCollector(GameObject _gameObject){
        collectors.Add(_gameObject);
        
        if(!tableToWorkerCoroutineIsRunning){
            tableToWorkerCoroutine=StartCoroutine(tableToWorker());
            tableToWorkerCoroutineIsRunning=true;
            }
        if(!drivenByADesk){
            generator.StartJob();
        }else{
            
            if(!myDesk.DeskToTableCoroutineIsRunning){
                myDesk.DeskToTableCoroutine=StartCoroutine(myDesk.DeskToTable());
                myDesk.DeskToTableCoroutineIsRunning=true;
            }
            
        }
        
    }
    internal void RemoveCollector(GameObject _gameObject){
       // Debug.Log(collectors.IndexOf(_gameObject));
        
        collectors.Remove(_gameObject);
        //generator.StartJob();
    }

    internal Place askForPlace(GameObject _item){
  
        Place givenPlace;
        if(collectors.Count>0)
        {
            if(_item.GetComponent<Money>()){
                        givenPlace=new Place(new Vector3(0,0,0),false,collectors[0].transform.GetChild(0).gameObject);
            }else{
                    givenPlace=collectors[0].GetComponent<CharController>().stack.givePlace(_item);
            }
            
            if(givenPlace!=null){
                return givenPlace;
            };
            RemoveCollector(collectors[0]);
            
        }
        givenPlace=stack.givePlace(_item);
        return givenPlace;
    }

    internal void removePlace(){
        stack.itemCount--;
        stack.places[stack.itemCount].setEmty();
    }

    internal IEnumerator tableToWorker(){
        while (true){
            if(stack.IsEmpty() || collectors.Count==0){
                if(tableToWorkerCoroutineIsRunning){
                            StopCoroutine(tableToWorkerCoroutine);
                            tableToWorkerCoroutineIsRunning=false;
                        }
                yield return new WaitForSeconds(0.2f);
            }else{
                CharController activeCollector=collectors[0].GetComponent<CharController>();
                
                if(!activeCollector.stack.IsFull()){
                    
                    GameObject takenItem=stack.takePlace();
                    if(!takenItem){
                        if(tableToWorkerCoroutineIsRunning){
                            StopCoroutine(tableToWorkerCoroutine);
                            tableToWorkerCoroutineIsRunning=false;
                        }
                        
                        yield return new WaitForSeconds(0.2f);
                    }
                    Place myPlace;
                    float speed=0.5f;
                    if(takenItem.gameObject.GetComponent<Money>()){
                        myPlace=new Place(new Vector3(0,0,-1),false,collectors[0].transform.GetChild(0).gameObject);
                        speed=0.1f;
                        Destroy(takenItem, speed);
                        
                    }else{
                        myPlace=activeCollector.stack.givePlace(takenItem);
                    }
                    

                    Transform holderTransform=myPlace.holder.transform;
        
                    Vector3 toPos=myPlace.position+holderTransform.localPosition;
                    takenItem.transform.SetParent(holderTransform.parent,true);
            //
                    iTween.MoveTo(takenItem.gameObject, iTween.Hash("position", toPos, "time", speed, "islocal", true));
                    iTween.RotateTo(takenItem.gameObject, iTween.Hash(
                                "rotation", new Vector3(0,0,32f*Random.value-16f),
                                "time", speed,
                                "islocal", true,
                                "easetype", "linear"
                            ));

                    
                    yield return new WaitForSeconds(0.2f);
                }else{
                    StopCoroutine(tableToWorkerCoroutine);
                    tableToWorkerCoroutineIsRunning=false;
                    yield return new WaitForSeconds(0.2f);
                }
                
            }
            //yield return new WaitForSeconds(0.5f);
        }

        }

    void onClick(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
