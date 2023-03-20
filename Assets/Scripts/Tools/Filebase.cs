using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Puzzle;
using UnityEditorInternal;
using UnityEngine;
public class Filebase
{
    private static Filebase _mInstance;
    public static Filebase Instance
    {
        get
        {
            if (_mInstance == null) _mInstance = new Filebase();
            return _mInstance;
        }
    }
    private Filebase()
    {
        
    }

    public void SaveHighscore(List<GameHighscore> hs)
    {
        String path = Application.persistentDataPath + "/highscore.data";
        File.WriteAllText(path, JsonConvert.SerializeObject(hs));
    }

    public List<EncryptionPuzzle> LoadEncryptionPuzzles()
    {
        String path = "Assets/Resources/Questions/Encryption.json";
        if (File.Exists(path))
        {
           
            List<EncryptionPuzzle> list = JsonConvert.DeserializeObject<List<EncryptionPuzzle>>(File.ReadAllText(path));
            return list;
        }
        return default;
    }
    public List<WebPuzzle> LoadWebPuzzles()
    {
        String path = "Assets/Resources/Questions/Web.json";
        if (File.Exists(path))
        {
            List<WebPuzzle> list = JsonConvert.DeserializeObject<List<WebPuzzle>>(File.ReadAllText(path));
            return list;
        }
        return default;
    }

    public List<GameHighscore> LoadHighscore()
    {
        String path = Application.persistentDataPath + "/highscore.data";
        if (File.Exists(path))
        {
            List<GameHighscore> list = JsonConvert.DeserializeObject<List<GameHighscore>>(File.ReadAllText(path));
            return list;
        }
        return default;
    }
}
