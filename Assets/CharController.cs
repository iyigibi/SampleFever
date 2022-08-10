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
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Touch theTouch;
         if(Input.touchCount > 0 )
         { 
                theTouch = Input.GetTouch(0);
            if(theTouch.phase == TouchPhase.Moved)
            {
                if(delta==Vector2.zero){
                    delta=theTouch.deltaPosition;
                }
                delta=Vector2.Lerp(delta,theTouch.deltaPosition,Time.deltaTime*10);
                Debug.Log(delta.magnitude);
                if(delta.magnitude>maxSpeed){
                    delta=delta.normalized*maxSpeed;
                }         
            } else if(theTouch.phase==TouchPhase.Ended){
                delta=Vector2.zero;
            }
         }
                
               
                preDelta=Vector2.Lerp(preDelta,delta*1f,Time.deltaTime*1);
                
                
                rb.velocity=preDelta;
                transform.right=rb.velocity.normalized;
                //if(rb.velocity.magnitude>maxSpeed){ rb.velocity=rb.velocity.normalized*maxSpeed;};
                
         
    }
}
