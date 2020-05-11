﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 moveDirection;//the movement of ball each frame
    private float degress = 0; // the degress of ball each frame
    private Vector3 m_CurrPos;// current pos of ball
    public float RotateSpeed = 5;// rotate spedd of ball
    public float ZSpeed = 30; // the speed the ball move on the Z Axie 100.
    public float R = 2.4f;//the radius of the ball rotate.
    private float m_degress = 0;// the total degress of ball
    public Animation PlayerAnimation;//the animation attach to the ball.
    private Vector3 mouseCurrentPos;//current mouse pos
    private Vector3 mousePreviousPos;//previous mouse pos
    public static PlayerMove PM;
    public TrailRenderer TR;
    public ParticleSystem PlayerParticle;
    public GameObject gameoverEfect;
    public GameObject gameovercanvas;
    public GameObject scorecanvas;
    
    private void Awake()
    {
        PM = this;
    }
    //public ParticleSystem PlayerParticle;
    //public void Init()
    //{
    //    this.characterController = base.GetComponent<CharacterController>();
    //    transform.position = new Vector3(0, -R, 9);
    //    if (PlayerAnimation != null)
    //        PlayerAnimation.Stop();
    //    if (PlayerParticle != null)
    //        PlayerParticle.Stop();
    //}

    //public void GameStart()
    //{
    //    if (PlayerAnimation != null)
    //        PlayerAnimation.Play();
    //    if (PlayerParticle != null)
    //        PlayerParticle.Play();
    //}

    private void FixedUpdate()
    {
        //if (GameManager.Instacne.GameState != GameStateEnum.StartGame)
        //    return;
        degress = 0;
        if (Input.GetMouseButtonDown(0))
        {
            mouseCurrentPos = mousePreviousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            //calculate the degress each frame when the finger swipe
            mouseCurrentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float deltaMousePos = (mousePreviousPos.x - mouseCurrentPos.x);
            float sign = Mathf.Sign(deltaMousePos);
            float speed = Mathf.Abs(deltaMousePos * 200);

            speed = Mathf.Clamp(speed, 0, RotateSpeed);
            speed *= -sign;
            degress = speed;
            mousePreviousPos = mouseCurrentPos;
        }
        m_degress += degress;
        if (m_degress >= 360)
            m_degress -= 360;
        degress = degress / 180 * Mathf.PI;
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        Vector2 pos = temp.normalized * R;
        //calculate the new position ,when ball rotate degress angle.
        float x = pos.x * Mathf.Cos(degress) - pos.y * Mathf.Sin(degress);
        float y = pos.x * Mathf.Sin(degress) + pos.y * Mathf.Cos(degress);
        m_CurrPos = new Vector3(x, y, 0);
        //calculate the movement of ball each frame
        moveDirection = m_CurrPos - transform.position;

        moveDirection.z = ZSpeed * Time.deltaTime;
        this.characterController.Move(this.moveDirection);
        //set the rotation when ball rotate degress angle.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, m_degress));
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Obstacles")
        {
            Instantiate(gameoverEfect,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            ShapeManager.SM.St();
            gameovercanvas.SetActive(true);
            scorecanvas.SetActive(false);
            SoundManager.SM.GO();
            //SaveData a = new SaveData(ScoreManager.Sm.highScore1, ScoreManager.Sm.Index);
            //saveLoadManager.saveData(a);

        }
        if (other.gameObject.tag == "Power")
        {
            Debug.Log("shbshb");
            StartCoroutine(speedup());
            SoundManager.SM.Ball();

        }
        if (other.gameObject.tag=="Power3")
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            StartCoroutine(ballsize());
            SoundManager.SM.Ball();
        }
        if (other.gameObject.tag == "Power4")
        {
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            StartCoroutine(ballsize());
            SoundManager.SM.Ball();
        }

    }
    IEnumerator speedup()
    {
        TR.enabled = true;
        yield return new WaitForSeconds(4);
        PlayerMove.PM.ZSpeed = 30;
        TR.enabled = false;
    }
    IEnumerator ballsize()
    {
        yield return new WaitForSeconds(4);
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

    }

}
