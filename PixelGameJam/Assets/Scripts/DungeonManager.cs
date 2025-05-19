using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //Declare Variables


    // Prefabs and Refrences
    public GameObject dungeonPrefab;
    public Camera dungeonCam;
    public GameObject hoardPrefab;
    public GameObject playerRoomPrefab;
    public GameObject nextRoomMarker;
    public GameObject entrance;
    public GameObject roomLock;
    public GameObject TrapManager;
    public GameObject initialTrapRoom;
    public GameObject roomToTrap;
    public GameObject[] spawns = new GameObject[4];


    //Variables for room generation
    public int roomCount;
    public int roomsOwned;
    public float roomWidth;
    float roomHeight;
    float roomCentre;
    float roomOffsetX;
    public Vector3 entrancePos = new Vector3(0.053f, 0, 0);
    int lockToBreak;
    bool isLocked;
    bool firstTrap = true;

    //Variables for camera
    public float cameraClampLeft;

    //trap variables
    bool hasTrap;
    public int optionSelected;

    //Lists
    List<GameObject> rooms = new List<GameObject>();
    List<bool> isLockedList = new List<bool>();
    List<GameObject> roomLocks = new List<GameObject>();
    List<bool> hasTrapList = new List<bool>();
    bool[] spawnFilled = new bool[4];

    //spawn variables
    public int spawnToUse = 0;

    //Variables for locked rooms
    int unlockCost;

    //mask layer for deciding whats interactable
    public LayerMask raycastLayerMask;




    // Start is called before the first frame update
    void Start()
    {
        roomCount = 3;
        roomsOwned = 3;
        roomOffsetX = 0;
        roomWidth = dungeonPrefab.transform.localScale.x;
        roomHeight = dungeonPrefab.transform.localScale.y;
        roomCentre = roomWidth / 2;
        entrance.transform.position = entrancePos;
        spawnFilled[0] = false;
        spawnFilled[1] = false;
        spawnFilled[2] = false;
        spawnFilled[3] = false;

        //set hoard, player and entrance to be not locked, new rooms start at 3
        isLockedList.Add(false);
        isLockedList.Add(false);
        isLockedList.Add(false);

        rooms.Add(playerRoomPrefab);
        rooms.Add(hoardPrefab);
        rooms.Add(entrance);

        //set existing rooms to trapped or not
        hasTrapList.Add(false);
        hasTrapList.Add(false);
        hasTrapList.Add(false);

        //roomToTrap = initialTrapRoom;
        CreateRoom();

        /* for (int i=0; i < 8; i++)
         {
             roomToTrap.transform.GetChild(i).gameObject.SetActive(false);
         }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCount <= roomsOwned)
        {
            CreateRoom();
        }

        MouseHandler();


    }

    void CreateRoom()
    {
        //Create a new room
        roomCount += 1;
        entrancePos.x -= 3.28f;
        entrance.transform.position = entrancePos;
        roomOffsetX = nextRoomMarker.transform.position.x;
        GameObject newRoom = Instantiate(dungeonPrefab, new Vector3(roomOffsetX, 0, 0), Quaternion.identity);
        rooms.Add(newRoom);
        isLockedList.Add(true);
        if (newRoom.tag == "isLocked")
        {
            isLocked = true;
            unlockCost = 1;

        }
        //create lock on new room, locks start at 0
        GameObject newLock = Instantiate(roomLock, new Vector3(roomOffsetX, -0.5f, -1), Quaternion.identity);
        // newLock.transform.parent = newRoom.transform;
        roomLocks.Add(newLock);
        for (int i = 0; i < 8; i++)
        {
            newRoom.transform.GetChild(i).gameObject.SetActive(false);
        }

    }


    //Handle Dungeon Interactions with mouse
    void MouseHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Make a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //see if ray hit something on the mask layer
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, raycastLayerMask);
            if (hit)
            {
                Debug.Log("You clicked " + hit.collider.tag);
                if (hit.collider.tag == "isLocked")
                {
                    roomsOwned += 1;
                    hit.collider.tag = "isUnlocked";
                    roomLocks[lockToBreak].gameObject.SetActive(false);
                    lockToBreak += 1;

                }
                if (hit.collider.tag == "hoard")
                {
                    //open hoard
                }
                if (hit.collider.tag == "playerRoom")
                {
                    //open player room
                }
                if (hit.collider.tag == "isUnlocked")
                {



                    roomToTrap = rooms[roomCount - 1];


                    TrapManager.GetComponent<TrapManager>().TrapChooser();
                    hit.collider.tag = "hasTrap";
                    // roomToTrap.tag = "hasTrap";


                }
                else
                {
                    Debug.Log("room type exception");
                }
            }

        }
    }

    public void SpawnHandler()
    {
        if (!spawnFilled[0])
        {
            spawnFilled[0] = true;
            spawnToUse = 0;
        }
        else if (!spawnFilled[1])
        {
            spawnFilled[1] = true;
            spawnToUse = 1;
        }
        else if (!spawnFilled[2])
        {
            spawnFilled[2] = true;
            spawnToUse = 2;
        }
        else if (!spawnFilled[3])
        {
            spawnFilled[3] = true;
            spawnToUse = 3;
        }
        else
        {
            Debug.Log("No more spawns available");
        }
    }
    public void ResetSpawns()
    {
        for (int i = 0; i < spawnFilled.Length; i++)
        {
            spawnFilled[i] = false;
        }
    }
}


