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
    public Stack stack;
    public GameObject tray;
    [SerializeField]
    private Animator animator;
    public List<Enemy> agro =new List<Enemy>();
    public Enemy targetedEnemy;
    public static CharController Instance;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        stack=new Stack(tray,1,2,20);
        Instance=this;
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
                Vector2 velocity=( delta-preDelta)*0.02f;
                float sqrMag=velocity.sqrMagnitude;
            Vector2 velocityNorm =velocity.normalized;
                if(sqrMag>maxSpeed){
                    velocity=velocityNorm*maxSpeed;
                }
                
                rb.velocity=velocity;
                animator.SetBool("isWalking",true);
                animator.SetFloat("speed",sqrMag);
                //animator.SetFloat("speedm", velocity.magnitude);
            transform.up=velocityNorm;
                }else{
                    rb.velocity=Vector2.zero;
                    animator.SetBool("isWalking",false);
                }
            if(stack.IsEmpty()){
                animator.SetBool("isCarrying",false);
            }else{
                animator.SetBool("isCarrying",true);
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Table _table=col.gameObject.GetComponent<Table>();
        if(_table && !stack.IsFull()){
             _table.AddCollector(gameObject);
        }
        Desk _desk=col.gameObject.GetComponent<Desk>();
        if(_desk && !stack.IsEmpty()){
             _desk.AddDropper(gameObject);
        }
        OfficeItemCreator creator=col.gameObject.GetComponent<OfficeItemCreator>();
        if(creator){
            creator.OnWorkerEnter(gameObject);
        }

        Enemy enemy=col.gameObject.GetComponent<Enemy>();
        if(enemy){


            AddToAgro(enemy);
            //enemy.AddDropper(gameObject);
        }

       
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Table _table=col.gameObject.GetComponent<Table>();
        if(_table){
             _table.RemoveCollector(gameObject);
        }
        Desk _desk=col.gameObject.GetComponent<Desk>();
        if(_desk){
             _desk.RemoveDropper(gameObject);
        }
        OfficeItemCreator creator=col.gameObject.GetComponent<OfficeItemCreator>();
        if(creator){
            creator.OnWorkerExit();
        }

        Enemy enemy=col.gameObject.GetComponent<Enemy>();
        if(enemy){
            RemoveFromAgro(enemy);
            //enemy.RemoveDropper(gameObject);
        }
        
    }
    Enemy newTarget;
    void AddToAgro(Enemy enemy)
    {
        agro.Add(enemy);
        newTarget = enemy;
    }
    void RemoveFromAgro(Enemy enemy)
    {

        agro.Remove(enemy);
    }

    private void FixedUpdate()
    {
        if (agro.Count > 0)
        {
            float minDistance = 9999;
            foreach(Enemy enemy in agro)
            {
                float distance= Vector3.Distance(transform.position, enemy.transform.position);
                
                if (distance < minDistance)
                {
                    newTarget = enemy;
                    minDistance = distance;
                };
                
            };
            if (targetedEnemy != newTarget)
            {
                if (targetedEnemy && targetedEnemy.droppers.Contains(gameObject))
                {
                    targetedEnemy.RemoveDropper(gameObject);
                }
                
                targetedEnemy = newTarget;
                targetedEnemy.AddDropper(gameObject);
            }



        }
        else
        {
            if (targetedEnemy && targetedEnemy.droppers.Contains(gameObject))
            {
                targetedEnemy.RemoveDropper(gameObject);
                targetedEnemy=null;
                newTarget=null;
            }
        }
    }


}
