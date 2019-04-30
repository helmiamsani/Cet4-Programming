using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public bool showDialog;
    public Vector2 screen;
    public string[] dialogText;
    public int index, optionsIndex; 

    public void OnGUI()
    {
        if (showDialog == true)
        {
            // || is equal to OR
            if(screen.x != Screen.width / 16 || screen.y != Screen.height / 9)
            {
                screen.x = Screen.width / 16;
                screen.y = Screen.height / 9;
            }

            GUI.Box(new Rect(0, 6 * screen.y, Screen.width, 3 * screen.y), dialogText[index]);

            // !index + 1 >= dialogText.length
            // !index >= dialogText.length - 1
            // index < dialogText
            if (!(index + 1 >= dialogText.Length || index == optionsIndex))
            {
                if(GUI.Button(new Rect(screen.x * 15, screen.y * 8.5f, screen.x, screen.y * 0.5f), "Next"))
                {
                    index++;
                }
            }

            else if (index == optionsIndex)
            {
                if(GUI.Button(new Rect(13 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Accept"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(14 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Decline"))
                {
                    index = dialogText.Length - 1; 
                }
            }

            else
            {
                if (GUI.Button(new Rect(screen.x * 15, screen.y * 8.5f, screen.x, screen.y * 0.5f), "Bye"))
                {
                    index = 0;
                    showDialog = false;
                    Movement.canMove = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    // Enable camera and player movement
                }
            }

        }
    }

}
