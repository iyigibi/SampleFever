using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testere : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    bool active =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        transform.Rotate(angularSpeed * Time.deltaTime, 0, 0);
    }

    public void Play()
    {
        active = true;
    }
    public void Stop()
    {
        active = false;

    }
}
