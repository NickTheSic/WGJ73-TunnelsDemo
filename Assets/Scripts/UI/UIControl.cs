using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public GameObject Menu;
    GameObject battleMenu;

    PlayerInventory pi;

    public Button Give;

	// Use this for initialization
	void Start () {
        Menu = GameObject.Find("GiveItem");
        battleMenu = GameObject.Find("BattleMenu");
        pi = GameObject.Find("Level").GetComponent<PlayerInventory>();

        Give.onClick.AddListener(GiveFunction);

	}

    public void GiveFunction()
    {
        Debug.Log("Click");
        if (pi.onFred)
        {
            if (pi.HasPotions > 0)
            {
                pi.HasPotions--;
                pi.happyFred = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (pi.MenuActive)
            Menu.SetActive(true);
        else
            Menu.SetActive(false);

        if (pi.InBattle == true)
            battleMenu.SetActive(true);
        else
            battleMenu.SetActive(false);

    }
}
