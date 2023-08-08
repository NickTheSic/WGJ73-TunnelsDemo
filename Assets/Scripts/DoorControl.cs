using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour {

    public GameObject Floor;

    private CreateLevel cl;
    private PlayerInventory pi;

    Text Description;
    string[] descText = new string[2] { "You don't have a key", "Press space to unlock the door" };

    private float x, y, z;

    private bool InDoorRange = false;

    private void Start()
    {
        cl = GameObject.Find("Level").GetComponent<CreateLevel>();
        pi = GameObject.Find("Level").GetComponent<PlayerInventory>();

        Description = GameObject.FindGameObjectWithTag("info").GetComponent<Text>();

        x = this.transform.position.x;
        z = this.transform.position.z;
        y = this.transform.position.y;

    }

    // Update is called once per frame
    void Update () {

        this.transform.position = new Vector3(x, 1.7f, z);

		if (InDoorRange&& cl.HasKeys())
        {
            Description.text = descText[1];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //GameObject n_Floor = Instantiate(Floor, new Vector3(x,y,z), Quaternion.identity);
                //n_Floor.tag = "Untagged";
                cl.DeleteObject(new Vector3 (x,y,z));
                pi.Keys--;
                Destroy(this.gameObject);
            }
        }
        else if (InDoorRange)
        {
            Description.text = descText[0];
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InDoorRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InDoorRange = false;
            Description.text = "";
        }
    }

}
