using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Stack
{
    public List<Place> places = new List<Place>();
    private int rowStackCount;
    private int colStackCount;
    private int maxStack;
    internal int maxItem;
    public int itemCount=0;

    private Vector3 itemSize;
    public Stack(GameObject _gameObject,int _rowStackCount,int _colStackCount,int _maxStack)
    {
            rowStackCount=_rowStackCount;
            colStackCount=_colStackCount;
            maxStack=_maxStack;
        int k=0;
        
        for(int i=0;i<maxStack*(colStackCount);i++){
            if(i>maxStack*k-1){
                        k++;            
            }
                for(int j=0;j<rowStackCount;j++){
                    
                    places.Add(new Place(new Vector3((j-1)*0.8f,(k-1)*0.8f,((i-(k-1)*(maxStack)))*-0.1f-0.51f),false,_gameObject));
                }
            
        };
        maxItem=places.Count;
    }

    public bool IsFull(){
        if(itemCount>=places.Count){
            return true;
        }
        return false;
    }
    public Place givePlace(GameObject _item){
            Place givenPlace;

            
            if(IsFull()){
                return null;
            }
            givenPlace = places[itemCount];
            givenPlace.setTaken(_item);
            itemCount++;
            return givenPlace;
        }
}
