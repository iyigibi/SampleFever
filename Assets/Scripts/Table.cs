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



    void Awake()
    {
            stack=new Stack(gameObject,3,2,5);

    }
    internal void setItemSize(Vector3 _size){
        //itemSize=_size;
    }

    internal void AddCollector(GameObject _gameObject){
        collectors.Add(_gameObject);
        generator.StartJob();
        tableToWorkerCoroutine=StartCoroutine(tableToWorker());
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
            givenPlace=collectors[0].GetComponent<CharController>().stack.givePlace(_item);
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
            if(stack.IsEmpty()){
                StopCoroutine(tableToWorkerCoroutine);
            }else{
                Debug.Log("table to worker");

                yield return new WaitForSeconds(0.5f);
            }
            
        }
        }

    void onClick(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
