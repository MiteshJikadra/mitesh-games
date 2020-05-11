using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rolly;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public List<ScreenData> ScreenDataList;
    UIScreenView currentScreen;
    public SceneName DefaultScreen;
    //public Text[] highScore;
    //public Text[] score;
    // private Score scoreInstance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (var item in ScreenDataList)
        {
            item.screen.Disable();
        }
        ChangeScreen(DefaultScreen);
    }
    public void ChangeScreen(SceneName sceneName)
    {

        ScreenData temp = ScreenDataList.Find(x => x.screenName == sceneName);

        if (currentScreen != null)
        {

            currentScreen.Hide();

        }
        currentScreen = temp.screen;
        currentScreen.Show();
    }

}
[System.Serializable]
public class ScreenData
{

    public SceneName screenName;
    public UIScreenView screen;

}