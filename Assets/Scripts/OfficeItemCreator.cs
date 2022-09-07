using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficeItemCreator : MonoBehaviour
{


    internal Coroutine Progress;
    private bool isProgressRunning=false;
    [SerializeField]
    private float price;
    [SerializeField]
    private GameObject whatToCreate;

    private Pooler pooler;
    private float paid=0;
    private Image barImage;
    private Wallet wallet;
    private TextMeshProUGUI yazi;


    void Start()
    {
        barImage=transform.GetChild(0).GetChild(1).GetComponent<Image>();
        yazi=transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        displayMoney();
        pooler=Pooler.Instance;
        if(paid==price){
            StartCoroutineFunc();
        }
    }

    void Update()
    {
        
    }
    private void displayMoney(){
            yazi.text = paid.ToString()+"/"+price.ToString();
    }

    internal IEnumerator ProgressStep(){
        while (true){
            yield return new WaitForSeconds(0.05f);
            if(paid==price){
                pooler.SpawnFromPool(whatToCreate.name,transform.position,transform.rotation);
                //Spawner.Spawn(whatToCreate,transform.position,transform.rotation);
                
                Destroy(gameObject);
                StopCoroutineFunc();
                
            }else{
                bool moneyGot=wallet.GiveMoney();
                if(moneyGot){
                    paid++;
                    displayMoney();
                    
                    barImage.fillAmount=(paid/price);
                }
                
                
            }
            
        }
    }
    internal void OnWorkerEnter(GameObject gameObject_){
        wallet=gameObject_.GetComponent<Wallet>();
        StartCoroutineFunc();
        
    }
    internal void OnWorkerExit(){
        StopCoroutineFunc();
    }
    private void StartCoroutineFunc(){
        if(!isProgressRunning){
            Progress=StartCoroutine(ProgressStep());
            isProgressRunning=true;
        }
    }
    private void StopCoroutineFunc(){
        if(isProgressRunning){
            StopCoroutine(Progress);
            isProgressRunning=false;
        };
    }
}
