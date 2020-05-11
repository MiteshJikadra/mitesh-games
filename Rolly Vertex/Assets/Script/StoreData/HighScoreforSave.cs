using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveData
{
    public int Score, BGIndex;
    public SaveData(int scoreH,int index)
    {
        Score = scoreH;
        BGIndex = index;
    
    }
}
