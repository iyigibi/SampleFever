using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Enemy : MonoBehaviour
{
    public List<GameObject> droppers = new List<GameObject>();
        [SerializeField]
    private Generator generator;
    Stack stack;
        internal Coroutine workerToDeskCoroutine;
        internal bool workerToDeskCoroutineIsRunning;
        internal Coroutine DeskToTableCoroutine;
        internal bool DeskToTableCoroutineIsRunning;
        private Table table;
           [SerializeField]
        private int costForNewItem=4;
        private int itemTaken=0;
        private Pooler pooler;
        public float health=100;

    void Awake(){
        stack=new Stack(gameObject,1,1,50);
        pooler=Pooler.Instance;
        
    }
    void Start(){

       // table=((Generator)generator).myTable.GetComponent<Table>();
    }

    void Update(){
        
        transform.right=(CharController.Instance.transform.position-transform.position).normalized;
        transform.position=transform.position+transform.right*Time.deltaTime*2f;
    }
    internal void AddDropper(GameObject _dropper){

        droppers.Add(_dropper);
        //generator.StartJob();
        startWorkerToDesk();
        
        //startDeskToTable();
        
    }
        internal void RemoveDropper(GameObject _gameObject){
       // Debug.Log(collectors.IndexOf(_gameObject));
        
        droppers.Remove(_gameObject);
        //generator.StartJob();
    }

        internal IEnumerator DeskToTable(){
        while (true){
            if(!stack.IsEmpty()){
                GameObject takenItem=stack.takePlace();
                pooler.SendToPool(takenItem);
                //Destroy(takenItem);
                itemTaken++;
                if(itemTaken==costForNewItem){
                    //generator.StartJob(true);
                    itemTaken=0;
                }
                
            }else{
                stopDeskToTable();
            }
            
                yield return new WaitForSeconds(0.2f);
        }
        }

        internal IEnumerator workerToDesk(){
        while (true){
            if(stack.IsFull() || droppers.Count==0 || health<1){
                stopWorkerToDesk();
                yield return new WaitForSeconds(0.2f);
                
            }else{
                CharController activeDropper=droppers[0].GetComponent<CharController>();
                if(!activeDropper.stack.IsEmpty()){
                    GameObject takenItem=activeDropper.stack.takePlace();
                    if(!takenItem){
                        stopWorkerToDesk();
                        yield return new WaitForSeconds(0.2f);
                        
                    }
                    Place myPlace=stack.givePlace(takenItem);
                            

                    Transform holderTransform=myPlace.holder.transform;
        
                    Vector3 toPos=myPlace.position+holderTransform.localPosition;
                    takenItem.transform.SetParent(holderTransform.parent,true);
            //
            
                    iTween.MoveTo(takenItem.gameObject, iTween.Hash("position", toPos, "time", 0.1f, "islocal", true,
                                "easetype", "linear"));
                    /*
                    iTween.RotateTo(takenItem.gameObject, iTween.Hash(
                                "rotation", new Vector3(0,0,32f*Random.value-16f),
                                "time", 0.2f,
                                "islocal", true,
                                "easetype", "linear"
                            ));
*/

                    yield return new WaitForSeconds(0.2f);
                    
                    takenItem=stack.takePlace();
                     pooler.SendToPool(takenItem.gameObject);
                     health-=5;
                    if(health<1)
                    {
                        pooler.SendToPool(gameObject,0.4f);
                    }
                }else{
                    stopWorkerToDesk();
                    yield return new WaitForSeconds(0.2f);
                    
                }
                
            }
            //yield return new WaitForSeconds(0.5f);
        }
        }

        
        void stopWorkerToDesk(){
                if(workerToDeskCoroutineIsRunning){
                    StopCoroutine(workerToDeskCoroutine);
                    workerToDeskCoroutineIsRunning=false;
                    
                }
        }
        void startWorkerToDesk(){
                if(!workerToDeskCoroutineIsRunning){
                    workerToDeskCoroutine=StartCoroutine(workerToDesk());
                    workerToDeskCoroutineIsRunning=true;
                }
        }

        void stopDeskToTable(){
            if(DeskToTableCoroutineIsRunning){
                StopCoroutine(DeskToTableCoroutine);
                DeskToTableCoroutineIsRunning=false;
                
            }
        }


        void startDeskToTable(){
                if(!DeskToTableCoroutineIsRunning){
                    DeskToTableCoroutine=StartCoroutine(DeskToTable());
                    DeskToTableCoroutineIsRunning=true;
                }
        }
}
