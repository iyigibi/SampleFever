using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    public int coin;
    public int gold;
    public int arrow;
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

    public void TakeGold()
    {
        gold++;
        displayMoney();
    }
    public void TakeArrow()
    {
        arrow++;
        displayMoney();
    }
    public void TakeMoney(){
        coin++;
        displayMoney();
    }
    internal bool GiveGold()
    {
        if (gold > 0)
        {
            gold--;
            displayMoney();
            return true;
        };
        return false;
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
        yazi.text = "W: "+coin.ToString() + ", G:" + gold.ToString() + ", A:" + arrow.ToString();
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
