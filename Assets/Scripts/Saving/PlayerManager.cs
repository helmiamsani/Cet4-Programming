using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public new string name;
    public float maxHealth, curHealth;
    public LinearDelayHealth.DelayHealth health;
    public CheckPoint checkPoint;
    public float x, y, z;

    public void SavePlayer()
    {
        maxHealth = health.maxHealth;
        curHealth = health.curHealth;
        x = checkPoint.curCheckPoint.x;
        y = checkPoint.curCheckPoint.y;
        z = checkPoint.curCheckPoint.z;
        Save.SavePlayerData(this);
        Debug.Log("Saved");
    }

    public void LoadPlayer()
    {
        DataToSave data = Save.LoadPlayerData();
        level = data.level;
        name = data.playerName;
        maxHealth = data.maxHealth;
        curHealth = data.curHealth;
        health.curHealth = curHealth;
        health.maxHealth = maxHealth;
        x = data.x;
        y = data.y;
        z = data.z;
        this.transform.position = new Vector3(x, y, z);
        Debug.Log("Load");
    }

}
