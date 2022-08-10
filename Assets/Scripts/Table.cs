using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Table : MonoBehaviour
{
    public List<Place> places = new List<Place>();
    public int itemCount=0;
    private Vector3 itemSize;
    void Start()
    {
        
        for(var i=0;i<100;i++){
            for(var j=0;j<3;j++){
                places.Add(new Place(new Vector3((j-1)*0.8f,0,-i*0.1f-0.51f),false));
            }
        }

    }
    internal void setItemSize(Vector3 _size){
        itemSize=_size;
    }

    internal Place givePlace(GameObject _item){
        Place givenPlace = places[itemCount];
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
