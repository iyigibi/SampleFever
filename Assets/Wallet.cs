using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    private int coin;
    public TextMeshProUGUI yazi;
    // Start is called before the first frame update
    internal void TakeMoney(){
        coin++;
        displayMoney();
    }
    internal bool GiveMoney(){
        if(coin>0){
            coin--;
            displayMoney();
            return true;
        };
        return false;
    }

    private void displayMoney(){
        yazi.text = coin.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
