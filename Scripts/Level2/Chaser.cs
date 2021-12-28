using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{ GameManager manager;
    public Transform traget;
    public float speed=  4f;
    Rigidbody bodyE;
    // Start is called before the first frame update
    void Start()
    {
        bodyE = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
            Vector3 pos = Vector3.MoveTowards(transform.position, traget.position, speed * Time.deltaTime);
            bodyE.MovePosition(pos);
            transform.LookAt(traget);
        
        
    }
}
