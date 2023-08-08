using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsControl : MonoBehaviour {

    CreateLevel cl;

    private float x, y, z;

    private bool OnStairs = false;

    AudioSource source;
    public AudioClip clip;

    // Use this for initialization
    void Start () {
        cl = GameObject.Find("Level").GetComponent<CreateLevel>();

        source = GetComponent<AudioSource>();

        x = this.transform.position.x;
        z = this.transform.position.z;
        y = this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(x, -0.1f, z);

        if (OnStairs)
        {
            Debug.Log("OnStairs");
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnStairs = true;
            source.PlayOneShot(clip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnStairs = false;
        }
    }
}
