using UnityEngine;
using System.Collections;
using UnityScript;
//this script can be found in the Component section under the option Intro RPG/Player/Interact
[AddComponentMenu("Intro PRG/RPG/Player/Interact")]
public class Interact : MonoBehaviour 
{
    #region Variables

    #endregion
    #region Start
    
    //connect our Camera to the mainCam variable via tag
    private void Start()
    {

    }
    #endregion
    #region Update
    private void Update()
    {
        //if our interact key is pressed
        if (Input.GetButtonDown("Interact"))
        {
            //create a ray
            Ray interact;
            //this ray is shooting out from the main cameras screen point center of screen
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //create hit info
            RaycastHit hitInfo;
            //if this physics raycast hits something within 10 units
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Dialog dlg = hitInfo.transform.GetComponent<Dialog>();
                    if(dlg != null)
                    {
                        dlg.showDialog = true;
                        // disable movement
                        Movement.canMove = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    //Debug that we hit a NPC
                    Debug.Log("Taking to NPC");
                }
                #endregion
                #region Item
                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we hit an Item
                    Debug.Log("Item");
                }

                #endregion
            }

        }
    }



    #endregion
}






