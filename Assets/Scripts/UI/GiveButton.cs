using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveButton : MonoBehaviour {


    PlayerInventory pi;
	// Use this for initialization
	void Start () {

        pi = GameObject.Find("Level").GetComponent<PlayerInventory>();

    }

    void OnMouseDown()
    {
        Debug.Log("Click");
        if (pi.onFred)
        {
            if (pi.HasPotions > 0)
            {
                pi.HasPotions--;
                pi.happyFred = true;
                pi.onFred = false;
                pi.MenuActive = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
