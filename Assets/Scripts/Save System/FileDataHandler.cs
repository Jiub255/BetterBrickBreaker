using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string _dataDirPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }

    public HighScoreData LoadHighScores()
    {
        // Use Path.Combine to account for different OS's having different path separators. 
        string fullPath = Path.Combine(_dataDirPath, _dataFileName);
        HighScoreData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // Load the serialized data from the file. 
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize the data from Json back into the C# object. 
                loadedData = JsonUtility.FromJson<HighScoreData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occured when trying to load data from file {fullPath} \n {e}");
            }
        }
        return loadedData;
    }

    public GameData Load()
    {
        // Use Path.Combine to account for different OS's having different path separators. 
        string fullPath = Path.Combine(_dataDirPath, _dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // Load the serialized data from the file. 
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize the data from Json back into the C# object. 
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occured when trying to load data from file {fullPath} \n {e}");
            }
        }
        return loadedData;
    }

    public void SaveHighScores(HighScoreData data)
    {
        // Use Path.Combine to account for different OS's having different path separators. 
        string fullPath = Path.Combine(_dataDirPath, _dataFileName);
        try
        {
            // Create the directory the file will be written to if it doesn't already exist. 
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the C# game data object into Json. 
            // The optional second parameter being true formats the Json data. (What does format mean? prettyPrint?)
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write the serialized data to the file. 
            // Best to use using blocks when dealing with files, so the connection to the file is closed after reading/writing to it. 
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error occured when trying to save data to file {fullPath} \n {e}");
        }
    }

    public void Save(GameData data)
    {
        // Use Path.Combine to account for different OS's having different path separators. 
        string fullPath = Path.Combine(_dataDirPath, _dataFileName);
        try
        {
            // Create the directory the file will be written to if it doesn't already exist. 
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the C# game data object into Json. 
            // The optional second parameter being true formats the Json data. (What does format mean? prettyPrint?)
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write the serialized data to the file. 
            // Best to use using blocks when dealing with files, so the connection to the file is closed after reading/writing to it. 
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error occured when trying to save data to file {fullPath} \n {e}");
        }
    }
}