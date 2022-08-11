using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Table : MonoBehaviour
{


    public List<GameObject> collectors = new List<GameObject>();
    public Stack stack;
    internal Generator generator;


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
    void onClick(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
