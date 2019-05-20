using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public int skin, hair, mouth, eyes, armour, clothes;

    public string charName;


    public SavedData(CustomisationSet custom)
    {
        skin = custom.skinIndex;
        hair = custom.hairIndex;
        mouth = custom.mouthIndex;
        eyes = custom.eyesIndex;
        armour = custom.armourIndex;
        clothes = custom.clothesIndex;

        charName = custom.characterName;

    }
}
