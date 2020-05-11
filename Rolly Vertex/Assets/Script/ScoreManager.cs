using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public Text ScoreGO;
    public int highScore1 = 0;
    public Text HS1;
    public GameObject[] Background;
    public int Index;
    //public int BGIndex;
    //public int Index11 = 0;
    //public int index11 = 0;


    public static ScoreManager Sm;
    private void Awake()
    {
        Sm = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        loadplayer();
        Background[Index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //loadplayer();

    }
    public void addScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
        ScoreGO.text = Score.ToString();
        
        if (Score > highScore1)
        {
            highScore1 = Score;
            HS1.text = highScore1.ToString();
            //Index = Index11;
            SaveData a = new SaveData(highScore1, Index);
            saveLoadManager.saveData(a);

        }
    }
    public void loadplayer()
    {
        SaveData data = saveLoadManager.LoadData();
        highScore1 = data.Score;
        Index = data.BGIndex;
        //Index11 = data.BGIndex;

        HS1.text = highScore1.ToString();
        //Index=Index11;
     
    }

    public void scene()
        {
        loadplayer();
        SceneManager.LoadScene(0);
            
        }

        public void enableBG(int BGIndex)
        {

        Index = BGIndex;
        for (int i = 0; i < Background.Length; i++)
            {
            
            if (i == BGIndex)
                {
               
                Background[i].SetActive(true);
                SaveData a = new SaveData(highScore1, Index);
                saveLoadManager.saveData(a);
                }
                else
                {
                    Background[i].SetActive(false);
                }
            }

        }
        //public void Tube1anable()
        //{
        //    tube1.SetActive(true);
        //    tube2.SetActive(false);
        //    tube3.SetActive(false);
        //    tube4.SetActive(false);

        //}
        //public void Tube2anable()
        //{
        //    tube1.SetActive(false);
        //    tube2.SetActive(true);
        //    tube3.SetActive(false);
        //    tube4.SetActive(false);

        //}
        //public void Tube3anable()
        //{
        //    tube1.SetActive(false);
        //    tube2.SetActive(false);
        //    tube3.SetActive(true);
        //    tube4.SetActive(false);

        //}
        //public void Tube4anable()
        //{
        //    tube1.SetActive(false);
        //    tube2.SetActive(false);
        //    tube3.SetActive(false);
        //    tube4.SetActive(true);

        //}

    }

