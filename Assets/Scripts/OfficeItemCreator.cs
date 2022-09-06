using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeItemCreator : MonoBehaviour
{

    internal Coroutine Progress;
    [SerializeField]
    private float price;
    [SerializeField]
    private GameObject whatToCreate;
    private float paid=0;
    private Image barImage;
    private Wallet wallet;

    void Start()
    {
        barImage=transform.GetChild(0).GetChild(1).GetComponent<Image>();
    }

    void Update()
    {
        
    }
    internal IEnumerator ProgressStep(){
        while (true){
            if(paid==price){
                //spawnIt
                StopCoroutine(Progress);
                yield return new WaitForSeconds(0.005f);
            }else{
                bool moneyGot=wallet.GiveMoney();
                if(moneyGot){
                    paid++;
                    barImage.fillAmount=(paid/price);
                }
                
                yield return new WaitForSeconds(0.005f);
            }
            
        }
    }
    internal void OnWorkerEnter(GameObject gameObject_){
        wallet=gameObject_.GetComponent<Wallet>();
        Progress=StartCoroutine(ProgressStep()); 
    }
    internal void OnWorkerExit(){
        Debug.Log("bing"+paid);
        StopCoroutine(Progress);
    }
}
