using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch (itemID)
        {
            #region  Food 0 - 99
            case 0:
                name = "Cupcake";
                value = 2;
                description = "Munchy and Crunchy";
                icon = "Food/Cupcake_icon";
                mesh = "Food/Cupcake_Mesh";
                type = ItemType.Food;
                heal = 3;
                amount = 1;
                break;
            case 1:
                name = "Pancake";
                value = 4;
                description = "Munchy and Crunchy";
                icon = "Food/Pancake_icon";
                mesh = "Food/Pancake_Mesh";
                type = ItemType.Food;
                heal = 10;
                amount = 1;
                break;
            case 2:
                name = "Chicken";
                value = 7;
                description = "Munchy and Crunchy";
                icon = "Food/Chicken_icon";
                mesh = "Food/Chicken_Mesh";
                type = ItemType.Food;
                heal = 13;
                amount = 1;
                break;
            case 3:
                name = "Coffee";
                value = 4;
                description = "Munchy and Crunchy";
                icon = "Food/Coffee_icon";
                mesh = "Food/Coffee_Mesh";
                type = ItemType.Food;
                heal = 8;
                amount = 1;
                break;
            #endregion

            #region  Weapon 100 - 199
            case 100:
                name = "Sword Level 100";
                value = 100;
                description = "It will kill you if not careful";
                icon = "Weapons/Sword_icon";
                mesh = "Weapons/Sword_Mesh";
                type = ItemType.Weapon;
                damage = 30;
                amount = 1;
                break;
            case 101:
                name = "Shuriken";
                value = 10;
                description = "It will kill you if not careful";
                icon = "Weapons/Shuriken_icon";
                mesh = "Weapons/Shuriken_Mesh";
                type = ItemType.Weapon;
                damage = 30;
                amount = 1;
                break;
            case 102:
                name = "Kunai";
                value = 10;
                description = "It will kill you if not careful";
                icon = "Weapons/Kunai_icon";
                mesh = "Weapons/Kunai_Mesh";
                type = ItemType.Weapon;
                damage = 30;
                amount = 1;
                break;
            #endregion

            #region  Apparel 200 - 299
            case 200:
                name = "Diamond Armour";
                value = 500;
                description = "It will save you";
                icon = "Apparels/DiamondArmour_icon";
                mesh = "Apparels/DiamondArmour_Mesh";
                type = ItemType.Apparel;
                armour = 100;
                amount = 1;
                break;

            case 201:
                name = "Diamond Pants";
                value = 499;
                description = "It will save you";
                icon = "Apparels/DiamondPants_icon";
                mesh = "Apparels/DiamondPants_Mesh";
                type = ItemType.Apparel;
                armour = 85;
                amount = 1;
                break;

            case 202:
                name = "Diamond Helmet";
                value = 498;
                description = "It will save you";
                icon = "Apparels/DiamondHelmet_icon";
                mesh = "Apparels/DiamondHelmet_Mesh";
                type = ItemType.Apparel;
                armour = 90;
                amount = 1;
                break;
            #endregion

            #region  Crafting 300 - 399
            case 300:
                name = "Dynamite";
                value = 2;
                description = "It will kill you";
                icon = "Crafting/Dynamite_icon";
                mesh = "Crafting/Dynamite_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;

            case 301:
                name = "Test Tube";
                value = 2;
                description = "It will kill you";
                icon = "Crafting/TestTube_icon";
                mesh = "Crafting/TestTube_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;

            case 302:
                name = "Time Bomb";
                value = 2;
                description = "It will kill you";
                icon = "Crafting/TimeBomb_icon";
                mesh = "Crafting/TimeBomb_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            #endregion

            #region  Quest 400 - 499
            case 400:
                name = "Dragon Egg";
                value = 1000;
                description = "Every one will try to rob you";
                icon = "Quests/DragonEgg_icon";
                mesh = "Quests/DragonEgg_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;

            case 401:
                name = "Ruby";
                value = 1000;
                description = "Every one will try to rob you";
                icon = "Quests/Ruby_icon";
                mesh = "Quests/Ruby_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;

            case 402:
                name = "Purple Diamond";
                value = 1000;
                description = "Every one will try to rob you";
                icon = "Quests/PurpleDiamond_icon";
                mesh = "Quests/PurpleDiamond_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            #endregion

            #region  Ingredients 500 - 599
            case 500:
                name = "Green Cow";
                value = 50;
                description = "It will kill you";
                icon = "Ingredients/GreenCow_icon";
                mesh = "Ingredients/GreenCow_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;

            case 501:
                name = "Green Dragon";
                value = 70;
                description = "It will kill you";
                icon = "Ingredients/GreenDragon_icon";
                mesh = "Ingredients/GreenDragon_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;

            case 502:
                name = "Blueberries";
                value = 2;
                description = "It will save you";
                icon = "Ingredients/Blueberries_icon";
                mesh = "Ingredients/Blueberries_Mesh";
                type = ItemType.Ingredient;
                amount = 1;
                break;
            #endregion

            #region  Potions 600 - 699
            case 600:
                name = "Super Health Potion";
                value = 50;
                description = "Increase 40 to your health";
                icon = "Potions/SuperHealthPotion_icon";
                mesh = "Potions/SuperHealthPotion_Mesh";
                type = ItemType.Potion;
                heal = 40;
                amount = 1;
                break;

            case 601:
                name = "Super Damage Potion";
                value = 50;
                description = "Decrase 60 to your health";
                icon = "Potions/SuperDamagePotion_icon";
                mesh = "Potions/SuperDamagePotion_Mesh";
                type = ItemType.Potion;
                damage = 60;
                amount = 1;
                break;

            case 602:
                name = "Super Armour Potion";
                value = 50;
                description = "Increase 40 to your armour";
                icon = "Potions/SuperArmourPotion_icon";
                mesh = "Potions/SuperArmourPotion_Mesh";
                type = ItemType.Ingredient;
                heal = 40;
                amount = 1;
                break;
            #endregion

            #region  Scrolls 700 - 799
            case 700:
                name = "Earth Scroll";
                value = 50;
                description = "Increase armour to 40";
                icon = "Scrolls/EarthScroll_icon";
                mesh = "Scrolls/EarthScroll_Mesh";
                type = ItemType.Scroll;
                armour = 40;
                amount = 1;
                break;

            case 701:
                name = "Fire Scroll";
                value = 50;
                description = "Increase damage to 40";
                icon = "Scrolls/FireScroll_icon";
                mesh = "Scrolls/FireScroll_Mesh";
                type = ItemType.Scroll;
                damage = 40;
                amount = 1;
                break;

            case 702:
                name = "Water Scroll";
                value = 50;
                description = "Increase health to 40";
                icon = "Scrolls/WaterScroll_icon";
                mesh = "Scrolls/WaterScroll_Mesh";
                type = ItemType.Scroll;
                heal = 40;
                amount = 1;
                break;
            #endregion

            default:
                itemID = 0;
                name = "Apple";
                value = 6;
                description = "Munchy and Crunchy";
                icon = "Food/Apple_icon";
                mesh = "Food/Apple_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
        }

        Item temp = new Item
        {
            ItemName = name,
            Description = description,
            ID = itemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icons/" + icon) as Texture2D
        };
        return temp;
    }
}
