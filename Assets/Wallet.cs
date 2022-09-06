using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int coin;
    // Start is called before the first frame update
    internal void TakeMoney(){
        coin++;
    }
    internal bool GiveMoney(){
        if(coin>0){
            coin--;
            return true;
        };
        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
