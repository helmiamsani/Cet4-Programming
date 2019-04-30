using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int level;
    public string playerName;
    public float maxHealth, curHealth;
    public float x, y, z;



    public DataToSave(PlayerManager player)
    {
        level = player.level;
        playerName = player.name;
        maxHealth = player.maxHealth;
        curHealth = player.curHealth;
        x = player.x;
        y = player.y;
        z = player.z;
    }
}
