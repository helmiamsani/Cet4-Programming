using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // formatting this shit to binary
using UnityEngine;

public static class Save
{
    public static void SavePlayerData(PlayerManager player)
    {
        // reference to binary formatter (this changing the code into binary language)
        BinaryFormatter formatter = new BinaryFormatter();

        // path to save to "/save.rar" file
        string path = Application.persistentDataPath + "/save.rar"; 

        // file stream create file at path
        FileStream stream = new FileStream(path, FileMode.Create);

        // dataToSave with player info
        DataToSave data = new DataToSave(player);

        // format and serialize location and data 
        formatter.Serialize(stream, data);

        // end
        stream.Close();
    }

    public static DataToSave LoadPlayerData()
    {
        // File is existed
        string path = Application.persistentDataPath + "/save.rar";
        if (File.Exists(path))
        {
            // reference to binary formatter (this changing the code into binary language)
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("Fucking Error Matee");
            return null;
        }
    }
}

