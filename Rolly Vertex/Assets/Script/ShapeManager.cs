using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    //public Transform pos;
    public GameObject[] shape1;
    public static ShapeManager SM;
    private void Awake()
    {
        SM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShapGendrate()
    {
        while (true)
        {
            int R = Random.Range(0,19);
            yield return new WaitForSeconds(1);
            Instantiate(shape1[R],transform.position,Quaternion.identity);
            ScoreManager.Sm.addScore();
        }
    }
    public void St()
    {
        StopAllCoroutines();
    }
    public void ShapeStart()
    {
        StartCoroutine(ShapGendrate());
    }
   
}
