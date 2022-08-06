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
                places.Add(new Place(new Vector3((j-1)*0.8f,i*0.1f+0.21f,0),false));
                
            }
        }

    }
    internal void setItemSize(Vector3 _size){
        itemSize=_size;
    }

    internal Place givePlace(){
        Place givenPlace = places[itemCount];
        givenPlace.setTaken();
        itemCount++;
        return givenPlace;
    }
    void onClick(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
