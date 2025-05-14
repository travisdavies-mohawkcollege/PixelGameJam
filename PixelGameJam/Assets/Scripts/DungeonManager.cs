using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //Declare Variables
    public GameObject dungeonPrefab;
    public Camera dungeonCam;
    public GameObject hoardPrefab;
    public GameObject playerRoomPrefab;
    public GameObject nextRoomMarker;
    public GameObject entrance;
    public GameObject roomLock;
    public int roomCount;
    public int roomsOwned;
    public float roomWidth;
    float roomHeight;
    public float cameraClampLeft;
    
    bool hasTrap;
    float roomCentre;
    float roomOffsetX;
    List<GameObject> rooms = new List<GameObject>();
    List<bool> isLockedList = new List<bool>();
    List<GameObject> roomLocks = new List<GameObject>();
    public Vector3 entrancePos = new Vector3(-9.85f, 0, 0);
    //Variables for locked rooms
    bool isLocked;
    int unlockCost;
    //mask layer for deciding whats interactable
    public LayerMask raycastLayerMask;
    float lockAnimationTime = 2f;
    int lockToBreak;



    // Start is called before the first frame update
    void Start()
    {
        roomCount = 4;
        roomsOwned = 4;
        roomOffsetX = 0;
        roomWidth = dungeonPrefab.transform.localScale.x;
        roomHeight = dungeonPrefab.transform.localScale.y;
        roomCentre = roomWidth / 2;
        entrance.transform.position = entrancePos;
        //set hoard, player and entrance to be not locked, new rooms start at 4
        isLockedList.Add(false);
        isLockedList.Add(false);
        isLockedList.Add(false);
        isLockedList.Add(false);
        rooms.Add(playerRoomPrefab);
        rooms.Add(hoardPrefab);
        rooms.Add(entrance);
        rooms.Add(dungeonPrefab);

    }

    // Update is called once per frame
    void Update()
    {
        if (roomCount <= roomsOwned)
        {
            CreateRoom();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Make a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //see if ray hit something on the mask layer
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, raycastLayerMask);
            if (hit)
            {
                Debug.Log("You clicked " +hit.collider.tag);
                if(hit.collider.tag == "isLocked")
                {
                    roomsOwned += 1;
                    hit.collider.tag = "isUnlocked";
                    roomLocks[lockToBreak].gameObject.SetActive(false);
                    lockToBreak += 1;                  

                }
            }

        }

    }

    void CreateRoom()
    {
        //Create a new room
        roomCount += 1;
        entrancePos.x -=3.28f;
        entrance.transform.position = entrancePos;
        roomOffsetX = nextRoomMarker.transform.position.x;
        GameObject newRoom = Instantiate(dungeonPrefab, new Vector3(roomOffsetX, 0, 0), Quaternion.identity);
        rooms.Add(newRoom);
        isLockedList.Add(true);
        if(newRoom.tag == "isLocked")
        {
            isLocked = true;
            unlockCost = 1;
            
        }
        //create lock on new room, locks start at 0
        GameObject newLock = Instantiate(roomLock, new Vector3(roomOffsetX, -0.5f, -1), Quaternion.identity);
       // newLock.transform.parent = newRoom.transform;
        roomLocks.Add(newLock);



    }



}
