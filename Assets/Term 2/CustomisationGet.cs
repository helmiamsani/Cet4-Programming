using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer character;

    [Header("Loaded File")]
    public int skin, hair, mouth, eyes, armour, clothes;
    public string charName;

    private CustomisationSet customSet;

    #region Start
    private void Start()
    {
        //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();

        //Run the function LoadTexture	
        LoadTexture();
    }
    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        //check to see if our save file for this character
        string path = Application.persistentDataPath + "/Save.png";
        if (File.Exists(path))
        {
            SavedData data = SaveCustomasation.LoadPlayerData();
            SetTexture("Skin", data.skin);
            skin = data.skin;
            SetTexture("Hair", data.hair);
            hair = data.hair;
            SetTexture("Mouth", data.mouth);
            mouth = data.mouth;
            SetTexture("Skin", data.skin);
            eyes = data.eyes;
            SetTexture("Armour", data.armour);
            armour = data.armour;
            SetTexture("Clothes", data.clothes);
            clothes = data.clothes;
            charName = data.charName;
        }

        else
        {
            SetTexture("Skin",customSet.skinIndex = 0);
            SetTexture("Hair", customSet.hairIndex = 0);
            SetTexture("Mouth", customSet.mouthIndex = 0);
            SetTexture("Eyes", customSet.eyesIndex = 0);
            SetTexture("Clothes", customSet.clothesIndex = 0);
            SetTexture("Armour", customSet.armourIndex = 0);
        }
    }
    #endregion

    #region SetTexture

    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int index)
    {
        //we need variables that exist only within this function
        //these are int material index and Texture2D textures
        Texture2D tex = null;
        int matIndex = 0;
        //inside a switch statement that is swapped by the string name of our material
        switch (type)
        {
            //case skin      
            case "Skin":
                //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                //material index element number is 1
                matIndex = 1;
                break;

            case "Hair":
                //textures is our Resource.Load Character Hair save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                //material index element number is 2
                matIndex = 4;
                break;

            case "Mouth":
                //textures is our Resource.Load Character Mouth save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                //material index element number is 3
                matIndex = 2;
                break;

            case "Eyes":
                //textures is our Resource.Load Character Eyes save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                //material index element number is 4
                matIndex = 3;
                break;

            case "Clothes":
                //textures is our Resource.Load Character Clothes save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                //material index element number is 5
                matIndex = 5;
                break;

            case "Armour":
                //textures is our Resource.Load Character Armour save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                //material index element number is 6
                matIndex = 6;
                break;
        }

        //Material array is equal to our characters material list
        Material[] mats = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[matIndex].mainTexture = tex;
        //our characters materials are equal to the material array
        character.materials = mats;
    }
    #endregion
}
