using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static int money;
    public Item selectedItem;

    public Vector2 scr;
    public Vector2 scrollPos;

    public string[] sortType;
    public string selectedType;

    public Transform[] equippedLocations;
    /*
     0 = right hand
     1 = left hand
         */
    public Transform dropLocation;
    public GameObject curWeapon;
    public GameObject curHelm;


    
    #endregion
    void Start()
    {
        sortType = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingredients", "Potion", "Scroll" };

        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(602));
        inv.Add(ItemData.CreateItem(700));
        inv.Add(ItemData.CreateItem(701));
        inv.Add(ItemData.CreateItem(702));

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].ItemName);
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Movement.canMove = true;
            Cursor.visible = false;
            return false;
        }
        else
        {
            if(scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }

            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Movement.canMove = false;
            Cursor.visible = true;
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(1));
            inv.Add(ItemData.CreateItem(2));
            inv.Add(ItemData.CreateItem(100));
            inv.Add(ItemData.CreateItem(101));
            inv.Add(ItemData.CreateItem(102));
            inv.Add(ItemData.CreateItem(200));
            inv.Add(ItemData.CreateItem(201));
            inv.Add(ItemData.CreateItem(202));
            inv.Add(ItemData.CreateItem(300));
            inv.Add(ItemData.CreateItem(301));
            inv.Add(ItemData.CreateItem(302));
            inv.Add(ItemData.CreateItem(400));
            inv.Add(ItemData.CreateItem(401));
            inv.Add(ItemData.CreateItem(402));
            inv.Add(ItemData.CreateItem(500));
            inv.Add(ItemData.CreateItem(501));
            inv.Add(ItemData.CreateItem(502));
            inv.Add(ItemData.CreateItem(600));
            inv.Add(ItemData.CreateItem(601));
            inv.Add(ItemData.CreateItem(602));
            inv.Add(ItemData.CreateItem(700));
            inv.Add(ItemData.CreateItem(701));
            inv.Add(ItemData.CreateItem(702));
        }
    }

    void DisplayInv(string sortType)
    {
        // If we pick a type
        if (!(sortType == "All" || sortType == ""))
        {
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);

            int a = 0; // Amount f that type
            int s = 0; // Slot position of item
            for (int i = 0; i < inv.Count; i++)
            {
                if(inv[i].Type == type) // Find our types
                {
                    a++; // Increase the amount of this type
                }
            }
            // If the amount of this type is less or equal to the amount we can display on screen without scrolling
            if(a <= 34)
            {
                for (int i = 0; i < inv.Count; i++) 
                {
                    if(inv[i].Type == type)// if it is the type we want to diplay
                    {
                        // We display a button that is of this type and slot them under the last one
                        if(GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s *(0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].ItemName))
                        {
                            selectedItem = inv[i]; // Select the time from its position in the inventory
                            Debug.Log(selectedItem.ItemName);
                        }
                        s++; // Increase the slot pos so the next one slides under
                    }
                }
            }
            else // If more than amount of viewable items
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0,0,0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), true, true);

                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if(inv[i].Type == type)
                    {
                        if(GUI.Button(new Rect(0,s * (0.25f *scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].ItemName))
                        {
                            selectedItem = inv[i]; // Select the time from its position in the inventory
                            Debug.Log(selectedItem.ItemName);
                        }
                        s++; // Increase the slot pos so the next one slides under
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
        // If we are viewing All
        else
        {
            if(inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].ItemName))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.ItemName);
                    }
                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), true, true);

                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {                 
                    if (GUI.Button(new Rect(0, i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].ItemName))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.ItemName);
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    void OnGUI()
    {
        if (showInv)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortType.Length; i++)
            {
                if(GUI.Button(new Rect(5.5f * scr.x + i * (scr.x), 0.25f * scr.y, scr.x, 0.25f * scr.y), sortType[i]))
                {
                    selectedType = sortType[i];
                }
            }
            DisplayInv(selectedType);
            if(selectedType != null)
            {
                GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
            }
        }
    }
}
