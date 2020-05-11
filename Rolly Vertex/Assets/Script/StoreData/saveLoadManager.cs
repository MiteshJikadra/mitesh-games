using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveLoadManager : MonoBehaviour
{
    public static void saveData(SaveData saveScore)
    {
        Debug.Log("Saving data");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/Rolly.m", FileMode.Create);

        SaveData data = saveScore;

        bf.Serialize(file, data);
        file.Close();
    }

    public static SaveData LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/Rolly.m"))
        {
            Debug.Log("ll");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/Rolly.m", FileMode.Open);

            SaveData data = bf.Deserialize(file) as SaveData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("File does not exists");
            return null;
        }
    }
    //private void OnApplicationFocus(bool focus)
    //{
    //    if (focus)
    //    {
    //        LoadData();
    //    }
    //    else
    //    {
    //        saveData();
    //    }
    //}

}

//    public static saveLoadManager instance;

//    public SaveData Data;

//    public SaveData DefaultData;



//    private void Awake()
//    {
//        if(instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            Debug.Log("MULTIPLE INSTANCES");
//            Destroy(this);
//        }

//        LoadData();
//    }

//    public static void saveData(SaveData saveScore)
//    {

//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file = new FileStream(Application.persistentDataPath + "/Rolly.m", FileMode.Create);

//        SaveData data = saveScore;

//        bf.Serialize(file, data);
//        file.Close();
//        Debug.Log("Saving data");
//    }

//    public static SaveData LoadData()
//    {
//        if (File.Exists(Application.persistentDataPath + "/Rolly.m"))
//        {

//            BinaryFormatter bf = new BinaryFormatter();
//            FileStream file = new FileStream(Application.persistentDataPath + "/Rolly.m", FileMode.Open);

//            SaveData Data = bf.Deserialize(file) as SaveData;
//            file.Close();
//            Debug.Log("Load Data");
//            return Data;

//        }
//        else
//        {
//            Debug.Log("Load Data");
//            //saveData(DefaultData);
//            return null;

//        }
//    }

//    private void OnApplicationFocus(bool focus)
//    {
//        if (focus)
//        {
//            LoadData();
//        }
//        else
//        {
//            saveData(Data);
//        }
//    }
//}
