using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gameover;
    public AudioClip ball;
    public static SoundManager SM;
    private void Awake()
    {
        SM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(loadingPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void GO()
    {
        ScoreManager.Sm.loadplayer();
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(gameover);
        //ScoreManager.Sm.loadplayer();
        



    }
    public void Ball()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(ball);
    }
    
}
