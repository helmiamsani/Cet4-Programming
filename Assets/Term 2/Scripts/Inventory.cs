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
    public LinearHealth.LinearHealth health;


    
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

    void DisplayItem()
    {
        switch (selectedItem.Type)
        {
            case ItemType.Food:
                // Box and description of THE FOOOD
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);

                if (health.curHealth < health.maxHealth)
                {
                    if(GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }

                if(GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage + "\nAmount: " + selectedItem.Amount);

                EquipItem(curWeapon, 0);

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour + "\nAmount: " + selectedItem.Amount);

                EquipItem(curHelm, 1);

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Crafting:
                // Box and description of THE CRAFTING
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                    {
                        DepleteAmount();
                    }
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Quest:
                break;

            case ItemType.Ingredient:
                // Box and description of THE INGREDIENTS
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                    {
                        DepleteAmount();
                    }
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Potion:
                // Box and description of THE POTION
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);

                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                    {
                        health.curHealth += selectedItem.Heal;
                        DepleteAmount();
                    }
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            case ItemType.Scroll:
                // Box and description of THE SCROLL
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.ItemName + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (health.curHealth < health.maxHealth)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Read"))
                    {
                        DepleteAmount();
                    }
                }

                if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;

            default:
                break;
        }
    }

    void DepleteAmount()
    {
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            inv.Remove(selectedItem);
            selectedItem = null;
        }
        return;
    }

    void Discard()
    {
        if(selectedItem.Type == ItemType.Weapon)
        {
            if(curWeapon != null && selectedItem.Mesh.name == curWeapon.name)
            {
                Destroy(curWeapon);
            }
        }
        else if(selectedItem.Type == ItemType.Apparel)
        {
            if (curHelm != null && selectedItem.Mesh.name == curHelm.name)
            {
                Destroy(curHelm);
            }
        }
        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        if(clone.GetComponent<Collider>() == null)
        {
            clone.AddComponent<BoxCollider>();
        }
        DepleteAmount();
    }

    void EquipItem(GameObject item, int location)
    {
        if(item == null || selectedItem.Mesh.name != item.name)
        {
            if (GUI.Button(new Rect(15f * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
            {
                if (item != null)
                {
                    Destroy(item);
                }

                item = Instantiate(selectedItem.Mesh, equippedLocations[location]);

                if(selectedItem.Type == ItemType.Weapon)
                {
                    curWeapon = item;
                }
                else if(selectedItem.Type == ItemType.Apparel)
                {
                    curHelm = item;
                }

                if (item.GetComponent<ItemHandler>() != null)
                {
                    item.GetComponent<ItemHandler>().enabled = false;
                }
                item.name = selectedItem.Mesh.name;
            }
        }
        else
        {
            if(item != null && selectedItem.Mesh.name == item.name)
            {
                if(GUI.Button(new Rect(15f * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "UnEquip"))
                {
                    Destroy(item);
                }
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

            DisplayItem();
        }
    }
}
