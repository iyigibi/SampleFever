using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Table : MonoBehaviour
{
    public List<Place> places = new List<Place>();
    private int rowStackCount=3;
    private int colStackCount=2;
    private int maxStack=3;
    internal int maxItem;

    public List<GameObject> collectors = new List<GameObject>();
    public int itemCount=0;
    private Vector3 itemSize;
    void Start()
    {
        var k=0;
        
        for(var i=0;i<maxStack*(colStackCount);i++){
            if(i>maxStack*k-1){
                        k++;
                        
            }
                for(var j=0;j<rowStackCount;j++){
                    
                    places.Add(new Place(new Vector3((j-1)*0.8f,(k-1)*-0.8f,((i-(k-1)*(maxStack)))*-0.1f-0.51f),false,gameObject));
                }
            
        };
        maxItem=places.Count;


    }
    internal void setItemSize(Vector3 _size){
        itemSize=_size;
    }

    internal Place givePlace(GameObject _item){
        Place givenPlace;
        if(collectors.Count>0)
        {
            

        }
        if(itemCount>=places.Count){
            return null;
        }
        givenPlace = places[itemCount];
        givenPlace.setTaken(_item);
        itemCount++;
        return givenPlace;
    }

    internal void removePlace(){
        itemCount--;
        places[itemCount].setEmty();
    }
    void onClick(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
