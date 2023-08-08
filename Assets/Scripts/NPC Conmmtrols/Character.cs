using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public GameObject _player;
    PlayerInventory pi;

    Text Description;

    string text;

    int CharacterNum = 0;

	// Use this for initialization
	void Start () {

        _player = GameObject.FindGameObjectWithTag("PlayerCam");
        Description = GameObject.FindGameObjectWithTag("info").GetComponent<Text>();

        pi = GameObject.Find("Level").GetComponent<PlayerInventory>();

        if (this.gameObject.name == "Fred")
        {
            Fred();
        }

	}
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(_player.transform.position);

        if (CharacterNum == 1 && pi.happyFred)
        {
            Description.text = "Thank you!";
            pi.Keys++;
            Destroy(this.gameObject);
        }

	}

    void Fred()
    {

        text = "Fred:\nCan you help me? I need a potion so I can heal my wounds and get out of here";

        CharacterNum = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "_player")
        {
            Description.text = text;
            pi.MenuActive = true;

            if (CharacterNum == 1)
            {
                pi.onFred = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "_player")
        {
            Description.text = "";
            pi.MenuActive = false;

            if (CharacterNum == 1)
            {
                pi.onFred = false;
            }

        }
    }

}
