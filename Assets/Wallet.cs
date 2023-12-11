using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    private int coin;
    public TextMeshProUGUI yazi;
    public static Wallet instance;
    // Start is called before the first frame update
    private void Start()
    {
        if (instance)
        {
            Destroy(instance);
        }
        instance = this;
    }
    public void TakeMoney(){
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
    void Awake()
    {
        displayMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
