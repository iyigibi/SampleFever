using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleFever;

public class Desk : MonoBehaviour
{
    public List<GameObject> droppers = new List<GameObject>();
    Stack stack;
        internal Coroutine workerToDeskCoroutine;
    void Awake(){
        stack=new Stack(gameObject,1,1,50);
    }
    internal void AddDropper(GameObject _dropper){
        droppers.Add(_dropper);
        //generator.StartJob();
        workerToDeskCoroutine=StartCoroutine(workerToDesk());
    }
        internal void RemoveDropper(GameObject _gameObject){
       // Debug.Log(collectors.IndexOf(_gameObject));
        
        droppers.Remove(_gameObject);
        //generator.StartJob();
    }


        internal IEnumerator workerToDesk(){
        while (true){
            if(stack.IsFull() || droppers.Count==0){
                StopCoroutine(workerToDeskCoroutine);
                yield return new WaitForSeconds(0.2f);
            }else{
                CharController activeDropper=droppers[0].GetComponent<CharController>();
                if(!activeDropper.stack.IsEmpty()){
                    GameObject takenItem=activeDropper.stack.takePlace();
                    if(!takenItem){
                        StopCoroutine(workerToDeskCoroutine);
                        yield return new WaitForSeconds(0.2f);
                    }
                    Place myPlace=stack.givePlace(takenItem);

                    Transform holderTransform=myPlace.holder.transform;
        
                    Vector3 toPos=myPlace.position+holderTransform.localPosition;
                    takenItem.transform.SetParent(holderTransform.parent,true);
            //
                    iTween.MoveTo(takenItem.gameObject, iTween.Hash("position", toPos, "time", 0.5f, "islocal", true));
                    iTween.RotateTo(takenItem.gameObject, iTween.Hash(
                                "rotation", new Vector3(0,0,32f*Random.value-16f),
                                "time", 0.5f,
                                "islocal", true,
                                "easetype", "linear"
                            ));


                    yield return new WaitForSeconds(0.2f);
                }else{
                    StopCoroutine(workerToDeskCoroutine);
                    yield return new WaitForSeconds(0.2f);
                }
                
            }
            //yield return new WaitForSeconds(0.5f);
        }
        }
}
