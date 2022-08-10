using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Vector3 movementVector;
    private Rigidbody2D rb;
    private float maxSpeed=5;
    private Vector2 delta=Vector2.zero;
    private Vector2 preDelta=Vector2.zero;
    private bool touchDown=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Touch theTouch;
        

         if(Input.touchCount > 0 )
         { 
                theTouch = Input.GetTouch(0);
                if(theTouch.phase == TouchPhase.Began)
            {
                preDelta=delta=theTouch.position;
                touchDown=true;
            }
            if(theTouch.phase == TouchPhase.Moved)
            {
                delta=theTouch.position;
                       
            } else if(theTouch.phase==TouchPhase.Ended){
                preDelta=delta=Vector2.zero;
                touchDown=false;
            }
         }
                
               
               // preDelta=Vector2.Lerp(preDelta,delta*1f,Time.deltaTime*1);
                
                //if(rb.velocity.magnitude>maxSpeed){ rb.velocity=rb.velocity.normalized*maxSpeed;};
                
         
    }

    void LateUpdate(){
            if(touchDown){
                rb.velocity=(delta-preDelta)*0.01f;
                transform.up=rb.velocity.normalized;
                }else{
                    rb.velocity=Vector2.zero;
                }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Table>().collectors.Add(gameObject);
        
        //spriteMove = -0.1f;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        col.gameObject.GetComponent<Table>().collectors.Remove(gameObject);
        //spriteMove = -0.1f;
    }


}