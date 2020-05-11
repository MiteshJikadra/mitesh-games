using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public GameObject[] PowerBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PowerB()
    {
        while (true)
        {
            int R = Random.Range(0, 4);
            yield return new WaitForSeconds(7);
            Instantiate(PowerBall[R], transform.position, Quaternion.identity);
        }
    }
    public void powerballStart()
    {
        StartCoroutine(PowerB());
    }
}
