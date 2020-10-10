﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public abstract class ISaveable<T> {
    public void SaveData(string path) {
        DataSaver.SaveData<T>(path, this);
    }
    public T LoadData(string path) {        
        var temp = DataSaver.LoadData<T>(path);
        return temp == null ? GetDefault() : temp;        
    }
    public abstract T GetDefault();
}

public class DataSaver 
{
    public static void SaveData<T>(string path, ISaveable<T> data) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, data);
        file.Close();
    }
    public static T LoadData<T>(string path) {
        if (File.Exists(path)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            T loadData = (T)bf.Deserialize(file);
            if (loadData == null)
            {
                Debug.LogError("El user no tiene data de Opciones");
            }
            file.Close();
            return loadData;
        }
        else
        {
            Debug.LogError("No Existe un archivo de data de opciones en el savePath");
            return default(T);
        }
    }

    public static void SaveData<T>(string path, T data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, data);
        file.Close();
    }
   
}
