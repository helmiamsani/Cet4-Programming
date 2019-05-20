using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // formatting this shit to binary
using UnityEngine;

public static class SaveCustomasation
{
    public static void SavePlayerCustomisation(CustomisationSet custom)
    {
        // reference to binary formatter (this changing the code into binary language)
        BinaryFormatter formatter = new BinaryFormatter();

        // path to save to "/save.rar" file
        string path = Application.persistentDataPath + "/Save.png";

        // file stream create file at path
        FileStream stream = new FileStream(path, FileMode.Create);

        // dataToSave with player info
        SavedData data = new SavedData(custom);

        // format and serialize location and data 
        formatter.Serialize(stream, data);

        // end
        stream.Close();
    }

    public static SavedData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/Save.png";

        if (File.Exists(path))
        {
            // Reference to binary formatter (this changing the code into binary language)
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return data;
        }

        else
        {
            Debug.Log("Error!!!");
            return null;
        }
    }
}
