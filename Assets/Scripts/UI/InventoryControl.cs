using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

    Text inventory;

    PlayerInventory pi;

	// Use this for initialization
	void Start () {

        inventory = GameObject.Find("Inventory").GetComponent<Text>();

        pi = GameObject.Find("Level").GetComponent<PlayerInventory>();

    }
	
	// Update is called once per frame
	void Update () {

        inventory.text = "Inventory:\n" +
            "Sword: " + GetSword() +
            "Shield: " + GetShield() +
            "Armor: " + GetArmor() +
            "Potions: " + GetPotions() +
            "Keys: " + GetKeys();

	}

    string GetSword()
    {
        string sword = "";

        if (pi.SwordLevel == 1)
            sword = "Steel";

        if (pi.SwordLevel == 0)
        {
            sword = "Rusted";
        }

        return sword + "\n";
    }

    string GetShield()
    {
        string shield = "";

        if (pi.ShieldLevel == 1)
            shield = "Steel";

        return shield +"\n";
    }

    string GetArmor()
    {
        string armor = "Cloth";

        if (pi.HasArmor == 1)
        {
            armor = "Steel";
        }

        return armor + "\n";
    }

    string GetPotions()
    {
        return pi.HasPotions.ToString()+ "\n";
    }

    string GetKeys()
    {
        return pi.Keys.ToString()+ "\n";
    }

}
