using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
public class Filebase
{
    public void SaveHighscore(List<GameHighscore> hs)
    {
        String path = Application.persistentDataPath + "/highscore.data";
        File.WriteAllText(path, JsonConvert.SerializeObject(hs));
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
