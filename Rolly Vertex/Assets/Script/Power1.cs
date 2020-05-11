using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {    
        PlayerMove.PM.ZSpeed = 20;
        Destroy(this.gameObject);
        
    }
    
   

}
