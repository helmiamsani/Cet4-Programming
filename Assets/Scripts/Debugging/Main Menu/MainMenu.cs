﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public bool loadScreen, playOptions, loadOptions, options, audio, brightness, resolution, controls;//these are all of out toggles to control what screen is on and when

    public GUIStyle logoTitleStyle;//this is how you make a GUIstyle i havent connected it to anything in the script it is purely example

    public float audioSlider, brightnessSlider;//both the audio and brightness slider values which we can adjust in the options section

    public bool usedResolution, nonUsedResolution, fullScreen, windowed;//my specific toggles for different resolutions and also full screen vs windowed they are seperate for the toggle GUI

    public KeyCode forward, backward, right, left, jump, sprint, crouch;//these are just basic example keyCodes that i have made

    public KeyCode holdingKey;//this is the key that we will be replacing, IT HOLDS THE CURRENT VALUE OF THE KEY WE ARE TRYING TO REPLACE 

    public AudioSource audi;//audio source in the game

    void Start() // Use this for initialization
    {

        loadScreen = true;//sets the intro screen to true

        nonUsedResolution = true;//setting resolution 5 as out main resolution

        fullScreen = true;//setting full screen to true

        forward = KeyCode.W;//setting forward to W

        backward = KeyCode.S;//setting backward to S

        left = KeyCode.A;//setting left to A

        right = KeyCode.D;//setting right to D

        jump = KeyCode.Space;//setting jump to Space

        sprint = KeyCode.LeftShift;//settin sprint to Left Shift

        crouch = KeyCode.LeftControl;//setting crouch to Left Control

        audi = GameObject.Find("Audio").GetComponent<AudioSource>();//find the Game object in your scene named Audio and get the audio source from it

        audioSlider = audi.volume;//set the audio slider to the same level as the audio source

        brightnessSlider = RenderSettings.ambientIntensity;//setting the brightness slider to the value of the games ambient lighting
    }

    void Update() // Update is called once per frame
    {

        if (loadScreen)//if currently on load screen
        {

            if (Input.anyKey)//and any key is pressed

            {

                Debug.Log("A key or mouse click has been detected");//show in the console that any key has been pressed

                loadScreen = false;//load to main menu

            }

        }

        if (options)
        {

            audi.volume = audioSlider;//set the audio source to the same level as the audio slider

            RenderSettings.ambientIntensity = brightnessSlider;//setting the games ambient lighting to the value of the brightness slider

        }

    }



    void OnGUI() //this section allows for you to render your GUI elements in screen
    {

        float scrW = Screen.width / 16;//setting up the width for a screen resolution of 16:9

        float scrH = Screen.height / 9;//setting up the height for a screen resolution of 16:9

        //basic continue screen

        if (loadScreen)//in load screen is active
        {

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 

            GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//standard logo or title block in the upper section of the screen

            GUI.Box(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "Press AnyKey");//notification to press anykey  in the lower/middle section of the screen

        }

        if (!loadScreen)//if the load screen is no longer active
        {

            if (!(playOptions || options))//and playoptions or options arent active then show the basic main menu screen
            {

                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 

                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//standard logo ot title block in the upper section of the screen

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "Play"))//play button on the menu screen 
                {

                    playOptions = true;//if pressed then go to the play options page

                }

                if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Options"))//options buttin on the menu screen
                {

                    options = true;//if pressed then go to the options page

                }

                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Exit"))//exit button on the menu screen
                {

                    Application.Quit();//when pressed exit the games application 

                    Debug.Log("Exit was pressed");//in the console show me that this button was pressed

                }

            }

            if (playOptions && !loadOptions)//inside the play options screen
            {

                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 

                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//logo or title block in the upper section of the screen

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "New Game"))//allow us to load/ create a new game
                {

                    SceneManager.LoadScene(1);//load game/charater selection/ level selection

                }

                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))//if back is pressed then
                {

                    playOptions = false;//turn off the play options

                    //allowing us to go back to our main menu

                }

                if (PlayerPrefs.HasKey("SavedGame"))//if we have save files
                {

                    if (GUI.Button(new Rect(4 * scrW, 3.5f * scrH, 8 * scrW, 1 * scrH), "Continue"))//allow us to load last game
                    {

                        string curCharacterSave = PlayerPrefs.GetString("LastCharacter");//grab the name of the last played character

                        int level = PlayerPrefs.GetInt(curCharacterSave + "levelNo");//grab the current level of the last played character					


                        SceneManager.LoadScene(level);//load the level of the last played character

                    }

                    if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Load"))//if load is pressed then open the load options	
                    {
                        loadOptions = true;//set the load options page to active	
                    }
                }

                if (loadOptions)//if load options ar active then show	
                {
                    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
                    GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//logo or title block in the upper section of the screen

                    //this amount is purely example

                    int saveAmount = 4;//using this value as  fake amount of save files as a cheat speedy way to call files...yes this way does have issues but it effective for the example

                    string[] savedGameName = new string[saveAmount];

                    for (int i = 0; i < saveAmount; i++)
                    {
                        savedGameName[i] = PlayerPrefs.GetString("Character_" + i.ToString());
                        if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH + (i * (1 * scrH)), 8 * scrW, 1 * scrH), savedGameName[i]))
                        {
                            int level = PlayerPrefs.GetInt(savedGameName[i] + "levelNo");//grab the current level of the character

                            SceneManager.LoadScene(level);//load the level of the character							
                        }
                    }

                    if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))//if back is pressed then						
                    {
                        loadOptions = false;//turn off the load options	
                                            //allowing us to go back to our play options menu
                    }
                }

            }

            if (options)//this section will hold all of the options we can change 
            {

                //background boxes

                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 

                GUI.Box(new Rect(0.25f * scrW, 0.25f * scrH, 7.625f * scrW, 8.5f * scrH), "");//right back ground block

                GUI.Box(new Rect(8.125f * scrW, 0.25f * scrH, 7.625f * scrW, 8.5f * scrH), "");//left background block



                //audio slider

                GUI.Box(new Rect(0.5f * scrW, 0.5f * scrH, 7.125f * scrW, 1f * scrH), "Audio");//title and block for audio options

                audioSlider = GUI.HorizontalSlider(new Rect(0.5f * scrW, 1f * scrH, 7.125f * scrW, 0.25f * scrH), audioSlider, 0.0F, 1.0F);//audio sliderbar 

                GUI.Label(new Rect(4f * scrW, 1.125f * scrH, 0.75f * scrW, 0.25f * scrH), Mathf.FloorToInt(audioSlider * 100).ToString());// showing out 0 to 100



                //brightness slider

                GUI.Box(new Rect(0.5f * scrW, 1.5f * scrH, 7.125f * scrW, 1f * scrH), "Brightness");//title and block for brightness options

                brightnessSlider = GUI.HorizontalSlider(new Rect(0.5f * scrW, 2f * scrH, 7.125f * scrW, 0.25f * scrH), brightnessSlider, 0.0F, 1.0F);//brightness sliderbar

                GUI.Label(new Rect(4f * scrW, 2.125f * scrH, 0.75f * scrW, 0.25f * scrH), Mathf.FloorToInt(brightnessSlider * 100).ToString());// showing out 0 to 100



                //resolution

                GUI.Box(new Rect(0.5f * scrW, 2.5f * scrH, 7.125f * scrW, 6f * scrH), "Resolutions");//title and block for resolution options



                #region Resolution types

                /*

                THE TOGGLES BELOW ARE NOT AFFECTED BY FULLSCREEN VS WINDOWED

                 */
    
                if (GUI.Toggle(new Rect(1.5f * scrW, 3.5f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "1024 x 576"))//if this toggle is pressed
                {

                    Screen.SetResolution(1024, 576, fullScreen);//screen resolution is 1024 x 576

                    usedResolution = true;//setting resolution 1 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;

                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 4f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "1152 x 648"))//if this toggle is pressed
                {

                    Screen.SetResolution(1152, 648, fullScreen);//screen resolution is 1152 x 648

                    usedResolution = true;//setting resolution 2 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;

                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), usedResolution, "1280 x 720"))//if this toggle is pressed
                {

                    Screen.SetResolution(1280, 720, fullScreen);//screen resolution is 1280 x 720

                    usedResolution = true;//setting resolution 3 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;
                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 5f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "1366 x 768"))//if this toggle is pressed
                {

                    Screen.SetResolution(1366, 768, fullScreen);//screen resolution is 1366 x 768

                    usedResolution = true;//setting resolution 4 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;
                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 5.5f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "1600 x 900"))//if this toggle is pressed
                {

                    Screen.SetResolution(1600, 900, fullScreen);//screen resolution is 1600 x 900

                    usedResolution = true;//setting resolution 5 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;

                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 6f * scrH, 2 * scrW, 0.5f * scrH), usedResolution, "1920 x 1080"))//if this toggle is pressed
                {

                    Screen.SetResolution(1920, 1080, fullScreen);//screen resolution is 1920 x 1080

                    usedResolution = true;//setting resolution 6 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;

                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 6.5f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "2560 x 1440"))//if this toggle is pressed
                {

                    Screen.SetResolution(2560, 1440, fullScreen);//screen resolution is 2560 x 1440

                    usedResolution = true;//setting resolution 7 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;

                }

                if (GUI.Toggle(new Rect(1.5f * scrW, 7f * scrH, 2f * scrW, 0.5f * scrH), usedResolution, "3840 x 2160"))//if this toggle is pressed
                {

                    Screen.SetResolution(3840, 2160, fullScreen);//screen resolution is 3840 x 2160

                    usedResolution = true;//setting resolution 8 to true

                    ///ALL OTHERS ARE FALSE///

                    nonUsedResolution = false;
                }

                #endregion

                /*

                THE TOGGLES BELOW ARE WHAT CHANGE THE FULLSCREEN VS WINDOWED
    
                 */
                //full Screen / windowed toggles

                if (GUI.Toggle(new Rect(5.5f * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), fullScreen, "FullScreen")) //when pressed
                {

                    Screen.fullScreen = true;//setting fullscreen to true

                    fullScreen = true;//changes the toggle to true allowing the GUI to be filled

                    windowed = false;//changes the toggle to false to show that windowed is unselected

                }

                if (GUI.Toggle(new Rect(5.5f * scrW, 6f * scrH, 2 * scrW, 0.5f * scrH), windowed, "Windowed"))//when pressed
                {

                    Screen.fullScreen = false; //setting fullscreen to false

                    fullScreen = false;//changes the toggle to false showing that fullscreen is unselected

                    windowed = true;//changes windowed to true allowing the GUI to be filled

                }



                //Controls

                GUI.Box(new Rect(8.4f * scrW, 0.5f * scrH, 7.125f * scrW, 8f * scrH), "Controls");//left control block



                Event e = Event.current;

                /*

                THE WAY THIS CONTROL SELECTION IS SET UP IS THAT YOU CANT SET A KEY BINDING TO A KEY THAT ALREADY EXISTS

                 */

                #region GUI BUTTONS FOR CONTROL CHANGE

                ////////////////////////////////////////////////////////////////////////FORWARD////////////////////////////////////////////////////////////////////////////

                if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited
                {
                    if (GUI.Button(new Rect(14f * scrW, 1f * scrH, 1f * scrW, 1f * scrH), forward.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed
                    {
                        holdingKey = forward;//set our holding key to the key of this button

                        forward = KeyCode.None;//set this button to none allowing only this one to be edited
                    }
                }

                else
                {
                    GUI.Box(new Rect(14f * scrW, 1f * scrH, 1f * scrW, 1f * scrH), forward.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed
                }

                ////////////////////////////////////////////////////////////////////////BACKWARD////////////////////////////////////////////////////////////////////////////



                if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 2f * scrH, 1f * scrW, 1f * scrH), backward.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed

                    {

                        holdingKey = backward;//set our holding key to the key of this button

                        backward = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 2f * scrH, 1f * scrW, 1f * scrH), backward.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                ////////////////////////////////////////////////////////////////////////LEFT////////////////////////////////////////////////////////////////////////////



                if (!(forward == KeyCode.None || backward == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 3f * scrH, 1f * scrW, 1f * scrH), left.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed

                    {

                        holdingKey = left;//set our holding key to the key of this button

                        left = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 3f * scrH, 1f * scrW, 1f * scrH), left.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                ////////////////////////////////////////////////////////////////////////RIGHT////////////////////////////////////////////////////////////////////////////

                if (!(forward == KeyCode.None || left == KeyCode.None || backward == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 4f * scrH, 1f * scrW, 1f * scrH), right.ToString()))

                    {

                        holdingKey = right;//set our holding key to the key of this button

                        right = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 4f * scrH, 1f * scrW, 1f * scrH), right.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                ////////////////////////////////////////////////////////////////////////JUMP////////////////////////////////////////////////////////////////////////////

                if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || backward == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 5f * scrH, 1f * scrW, 1f * scrH), jump.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed

                    {

                        holdingKey = jump;//set our holding key to the key of this button

                        jump = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 5f * scrH, 1f * scrW, 1f * scrH), jump.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                ////////////////////////////////////////////////////////////////////////SPRINT////////////////////////////////////////////////////////////////////////////

                if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || backward == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 6f * scrH, 1f * scrW, 1f * scrH), sprint.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed

                    {

                        holdingKey = sprint;//set our holding key to the key of this button

                        sprint = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 6f * scrH, 1f * scrW, 01f * scrH), sprint.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                ////////////////////////////////////////////////////////////////////////CROUCH////////////////////////////////////////////////////////////////////////////

                if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || backward == KeyCode.None || sprint == KeyCode.None))

                //if all the other keys are not equal to none than this one can be edited

                {

                    if (GUI.Button(new Rect(14f * scrW, 7f * scrH, 1f * scrW, 1f * scrH), crouch.ToString()))//if the GUI button for foward (that is also showing the current key) is pressed

                    {

                        holdingKey = crouch;//set our holding key to the key of this button

                        crouch = KeyCode.None;//set this button to none allowing only this one to be edited

                    }

                }

                else

                {

                    GUI.Box(new Rect(14f * scrW, 7f * scrH, 1f * scrW, 1f * scrH), crouch.ToString());//if any other button except for this one is set to none make this one a box so it cant be changed

                }

                #endregion





                #region Key Change



                if (forward == KeyCode.None)//if forward is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == sprint || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            forward = e.keyCode;//set forward to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                        else //otherwise if it is the same as another key

                        {

                            forward = holdingKey;//set forward back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                    }

                }

                if (backward == KeyCode.None)//if backward is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == sprint || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            backward = e.keyCode;//set backward to the events key press

                            holdingKey = KeyCode.None;

                        }

                        else//otherwise if it is the same as another key

                        {

                            backward = holdingKey;//set backward back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                    }

                }

                if (left == KeyCode.None)//if left is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == backward || e.keyCode == right || e.keyCode == jump || e.keyCode == sprint || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            left = e.keyCode;//set left to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                        else//otherwise if it is the same as another key

                        {

                            left = holdingKey;//set left back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }



                    }

                }

                if (right == KeyCode.None)//if right is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump || e.keyCode == sprint || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            right = e.keyCode;//set right to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                        else//otherwise if it is the same as another key

                        {

                            right = holdingKey;//set right back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                    }

                }

                if (jump == KeyCode.None)//if jump is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == sprint || e.keyCode == right || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            jump = e.keyCode;//set jump to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                        else//otherwise if it is the same as another key

                        {

                            jump = holdingKey;//set jump back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                    }

                }

                if (sprint == KeyCode.None)//if sprint is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump || e.keyCode == right || e.keyCode == crouch))

                        //if that key is not the same as any other movements key press than

                        {

                            sprint = e.keyCode;//set sprint to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                        else//otherwise if it is the same as another key

                        {

                            sprint = holdingKey;//set sprint back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none



                        }



                    }

                }

                if (crouch == KeyCode.None)//if crouch is set to none and

                {

                    if (e.isKey)//if an event is triggerent by a key press

                    {

                        Debug.Log("Detected key code: " + e.keyCode);//write in my console what that key is

                        if (!(e.keyCode == forward || e.keyCode == backward || e.keyCode == left || e.keyCode == jump || e.keyCode == right || e.keyCode == sprint))

                        //if that key is not the same as any other movements key press than

                        {

                            crouch = e.keyCode;//set crouch to the events key press

                            holdingKey = KeyCode.None;//set the holding key to none



                        }

                        else//otherwise if it is the same as another key

                        {

                            crouch = holdingKey;//set crouch back to what holding key is now

                            holdingKey = KeyCode.None;//set the holding key to none

                        }

                    }

                }

                #endregion

                /*

                 GUI LABELING EACH OF THE CONTROL BUTTONS

                */

                GUI.Box(new Rect(8.75f * scrW, 1f * scrH, 6.25f * scrW, 1f * scrH), "Forward");

                GUI.Box(new Rect(8.75f * scrW, 2f * scrH, 6.25f * scrW, 1f * scrH), "Backward");

                GUI.Box(new Rect(8.75f * scrW, 3f * scrH, 6.25f * scrW, 1f * scrH), "Left");

                GUI.Box(new Rect(8.75f * scrW, 4f * scrH, 6.25f * scrW, 1f * scrH), "Right");

                GUI.Box(new Rect(8.75f * scrW, 5f * scrH, 6.25f * scrW, 1f * scrH), "Jump");

                GUI.Box(new Rect(8.75f * scrW, 6f * scrH, 6.25f * scrW, 1f * scrH), "Sprint");

                GUI.Box(new Rect(8.75f * scrW, 7f * scrH, 6.25f * scrW, 1f * scrH), "Crouch");







                if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))

                //if none of the keys are set to none

                {

                    if (GUI.Button(new Rect(12.5f * scrW, 8f * scrH, 3 * scrW, 0.5f * scrH), "Back"))//if back is pressed then

                    {

                        options = false;//turn off the options

                        //allowing us to go back to our main menu

                    }

                }

            }

        }

    }

}