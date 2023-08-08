using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour {

    public const int iSize = 10;
    public const int jSize = 12;

    int[,] LevelArray = new int[iSize, jSize]
    {
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,0,2,0,0,0,0,0,0,1,0},
        {0,1,0,1,1,1,0,1,1,0,1,0},
        {0,1,0,1,0,0,0,1,0,0,1,0},
        {0,1,0,1,0,1,1,1,0,0,1,0},
        {0,1,0,1,1,1,1,1,0,0,1,0},
        {0,1,0,0,0,0,0,0,0,3,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0}
    };

    public const int f = 1; //floor number
    public const int w = 0; //Number to indicate wall;

    int[,] ItemPlacementArray = new int[iSize, jSize]
    {
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,0,0,2,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0}
    };

    public static int SPACING = 3;

    public GameObject[] Pieces;
    public GameObject[] Items;

    private GameObject[,] worldObjects = new GameObject[iSize, jSize];
    public Vector3[,] locations = new Vector3[iSize,jSize];


    PlayerInventory pi;

    public GameObject _player;
    private GameObject Cam;
    private float x, y, z;
    private float rotY;

    public GameObject Fred; //CHANGE THIS TO THE ACTUAL NAME OF THE CHARACTER;

    private AudioSource source;
    public AudioClip[] clip;

    public GameObject MiniMap;
    private float MMY;

	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
		for (int i = 0; i < iSize; i++)
        {
            for (int j = 0; j < jSize; j++)
            {
               GameObject piece = Instantiate(Pieces[LevelArray[i,j]], new Vector3((j * SPACING) - SPACING, 0, (i * SPACING) - SPACING), Quaternion.identity) as GameObject;
                piece.transform.SetParent(this.transform);

                worldObjects[i, j] = piece;

                locations[i, j] = new Vector3((j * SPACING) - SPACING, 0, (i * SPACING) - SPACING);

                if (ItemPlacementArray[i,j] == 1)
                {
                    Cam = Instantiate(_player, new Vector3(0, 1, 0), Quaternion.identity);
                    Cam.name = "_player";
                    x = (j * SPACING) - SPACING;
                    z = (i * SPACING) - SPACING;
                    rotY = 270;
                }

                if (ItemPlacementArray[i,j] == 2)
                {

                    GameObject fred = Instantiate(Fred, new Vector3((j * SPACING) - SPACING, 1.3f, (i * SPACING) - SPACING), Quaternion.identity) as GameObject;
                    fred.name = "Fred";

                }

                /*if (ItemPlacementArray[i,j] == 2)
                {
                    GameObject item = Instantiate(Items[ItemPlacementArray[i,j] - 2], new Vector3((j * SPACING) - SPACING, 1.0f, (i * SPACING) - SPACING), Quaternion.identity) as GameObject;
                }*/
            }
        }

        //x = Cam.transform.position.x;
        y = Cam.transform.position.y;
        //z = Cam.transform.position.z;
        MMY = MiniMap.transform.position.y;

        pi = GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        Cam.transform.position = new Vector3(x, y, z);
        MiniMap.transform.position = new Vector3(x, MMY, z);
        Cam.transform.eulerAngles = new Vector3(0, rotY, 0);

        if (rotY >= 360)
            rotY = 0;
        if (rotY < 0)
            rotY = 270;

        if (!pi.InBattle)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                rotY += 90;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                rotY -= 90;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {

                if (rotY == 0 && !CheckWall())
                    z += SPACING;
                if (rotY == 90 && !CheckWall())
                    x += SPACING;
                if (rotY == 180 && !CheckWall())
                    z -= SPACING;
                if (rotY == 270 && !CheckWall())
                    x -= SPACING;

            }
        }
	}

    bool CheckWall()
    {
        for (int i = 0; i < iSize; i++)
        {
            for (int j = 0; j < jSize; j++)
            {
                if (rotY == 0)
                {
                    if ((j*SPACING)-SPACING == Cam.transform.position.x && (i*SPACING) - SPACING == Cam.transform.position.z + SPACING && worldObjects[i,j].tag == "Wall")
                        return true;
                }
                if (rotY == 90)
                {
                    if ((j * SPACING) - SPACING == Cam.transform.position.x + SPACING && (i * SPACING) - SPACING == Cam.transform.position.z && worldObjects[i, j].tag == "Wall")
                        return true;
                }
                if (rotY == 180)
                {
                    if ((j * SPACING) - SPACING == Cam.transform.position.x && (i * SPACING) - SPACING == Cam.transform.position.z - SPACING && worldObjects[i, j].tag == "Wall")
                        return true;
                }
                if (rotY == 270)
                {
                    if ((j * SPACING) - SPACING == Cam.transform.position.x - SPACING && (i * SPACING) - SPACING == Cam.transform.position.z && worldObjects[i, j].tag == "Wall")
                        return true;
                }
            }
        }
        source.PlayOneShot(clip[1]);
        return false;
    }

    /*public bool InDoorRange(float dx, float dz)
    {
        if (dx - SPACING == x || dx + SPACING == x || dz - SPACING == z || dz + SPACING== z)
        {
            Debug.Log("In Range of Door");
            return true;
        }

        return false;
    }*/

    public void DeleteObject (Vector3 pos)
    {
        for (int i = 0; i < iSize; i++)
        {
            for (int j = 0; j< jSize; j++)
            {
                if (locations[i,j] == pos)
                {
                    source.PlayOneShot(clip[0]);
                    GameObject piece = Instantiate(Pieces[f], new Vector3((j * SPACING) - SPACING, 0, (i * SPACING) - SPACING), Quaternion.identity) as GameObject;
                    worldObjects[i, j] = piece;
                    LevelArray[i, j] = f;
                }
            }
        }
    }

    public bool HasKeys()
    {
        if (pi.Keys > 0)
            return true;

        return false;
    }


}
