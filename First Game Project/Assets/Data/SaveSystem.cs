using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SaveScore(LogicScript Logic)
    {
        ScoreData scoreData = new ScoreData(Logic);

        string path = Application.persistentDataPath + "/score";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, scoreData);

        stream.Close();
    }

    public static ScoreData loadScore()
    {
        string path = Application.persistentDataPath + "/score";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ScoreData scoreData = formatter.Deserialize(stream) as ScoreData;

            stream.Close();
            
            return scoreData;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            ScoreData scoreData = new ScoreData();

            formatter.Serialize(stream, scoreData);

            stream.Close();

            return null;
        }
    }
}
