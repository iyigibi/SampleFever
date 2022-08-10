using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector3.Lerp(transform.position,target.transform.position+new Vector3(0,-10,-10),Time.deltaTime*5);
    }
}
